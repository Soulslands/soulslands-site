using System.Net;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace Soulslands.Web.Services.Auth;

// Sign-in through the studio (SoulslandsGame ADR-0024 section 2): authorization code with PKCE
// against the studio's OIDC provider, then this site's own cookie. The cookie lasts 1 hour and
// never slides, so a role removed, an account blocked or a studio sign-out reaches this site
// within the hour (the browser goes back to the studio, which signs it in again silently).
// The cookie keeps the id token only, for id_token_hint at sign-out; never an access or
// refresh token, a password or an email.
public static class StudioSignIn
{
    public const string CookieScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    public const string StudioScheme = OpenIdConnectDefaults.AuthenticationScheme;
    public const string CookieName = "__Host-Soulslands";
    public static readonly TimeSpan CookieLifetime = TimeSpan.FromHours(1);

    // Claims of the studio's id token, kept with their JWT names (no inbound mapping).
    public const string SubjectClaim = "sub";
    public const string NameClaim = "name";
    public const string RoleClaim = "role";

    // The name of an account without a display name; never derived from the email, which would
    // leak part of the address as the public wiki author name.
    public const string DefaultName = "Giocatore";

    // LAN mode (SITE_DOMAIN=:80, deploy/README.md): plain http on a host that is not loopback.
    // The studio accepts http redirect URIs only on loopback and browsers drop the Secure
    // sign-in cookies elsewhere, so such a request never goes to the studio. Loopback http
    // (local development) signs in as usual.
    public static bool IsReadOnly(HttpRequest request)
    {
        if (request.IsHttps)
        {
            return false;
        }
        var host = request.Host.Host.Trim('[', ']');
        return !(string.Equals(host, "localhost", StringComparison.OrdinalIgnoreCase)
            || (IPAddress.TryParse(host, out var ip) && IPAddress.IsLoopback(ip)));
    }

    public static string? SubjectId(ClaimsPrincipal user) => user.FindFirstValue(SubjectClaim);


    // A wiki page this request may not see (missing, or Staff for a non-staff user). A browser
    // that still sends this site's cookie but is not signed in (the hour ran out) goes back to
    // the studio, which signs it in again silently; everyone else gets 404. Missing and Staff
    // pages answer the same way in both cases, so neither reveals that a Staff page exists.
    public static IActionResult NotVisible(PageModel page) =>
        page.User.Identity?.IsAuthenticated != true && page.Request.Cookies.ContainsKey(CookieName)
            ? page.Challenge(new AuthenticationProperties { RedirectUri = page.Request.Path + page.Request.QueryString }, StudioScheme)
            : page.NotFound();

    public static void AddStudioSignIn(this WebApplicationBuilder builder)
    {
        var section = builder.Configuration.GetSection(StudioOptions.Section);
        builder.Services.AddOptions<StudioOptions>()
            .Bind(section)
            .Validate(o => StudioOptions.IsValidAccountUrl(o.AccountUrl),
                "Studio:AccountUrl deve essere un indirizzo https assoluto, anche in locale (per esempio https://localhost:5001).")
            .Validate(o => StudioOptions.IsValidUrl(o.StudioUrl),
                "Studio:StudioUrl deve essere un indirizzo https assoluto (http solo su localhost).")
            .ValidateOnStart();
        var studio = section.Get<StudioOptions>() ?? new();

        builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieScheme;
                options.DefaultChallengeScheme = StudioScheme;
            })
            .AddCookie(CookieScheme, options =>
            {
                // __Host-: Secure, Path=/ and no Domain, so the cookie is never sent to another host.
                options.Cookie.Name = CookieName;
                options.Cookie.Path = "/";
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                options.Cookie.HttpOnly = true;
                options.Cookie.SameSite = SameSiteMode.Lax;
                options.ExpireTimeSpan = CookieLifetime;
                options.SlidingExpiration = false;
                options.LoginPath = "/Account/Accedi";
                options.Events.OnRedirectToAccessDenied = context =>
                {
                    context.Response.StatusCode = StatusCodes.Status403Forbidden;
                    return Task.CompletedTask;
                };
            })
            .AddOpenIdConnect(StudioScheme, options =>
            {
                options.Authority = studio.AccountUrl;
                options.RequireHttpsMetadata = true;
                options.ClientId = studio.ClientId;
                options.ClientSecret = studio.ClientSecret;
                options.ResponseType = OpenIdConnectResponseType.Code;
                options.ResponseMode = OpenIdConnectResponseMode.FormPost;
                options.UsePkce = true;
                options.Scope.Clear();
                options.Scope.Add("openid");
                options.Scope.Add("profile");
                options.Scope.Add("roles");
                options.GetClaimsFromUserInfoEndpoint = false;
                options.MapInboundClaims = false;
                options.TokenValidationParameters.NameClaimType = NameClaim;
                options.TokenValidationParameters.RoleClaimType = RoleClaim;
                options.DisableTelemetry = true;
                // No front-channel logout endpoint yet (ADR-0024 section 2): an empty path turns
                // /signout-oidc off, so another site cannot sign people out with a plain link.
                options.RemoteSignOutPath = PathString.Empty;
                // Only the id token is kept (below), never the access token.
                options.SaveTokens = false;
                options.Events.OnTokenValidated = context =>
                {
                    var idToken = context.TokenEndpointResponse?.IdToken ?? context.ProtocolMessage.IdToken;
                    context.Properties!.StoreTokens([new AuthenticationToken { Name = OpenIdConnectParameterNames.IdToken, Value = idToken }]);
                    var identity = (ClaimsIdentity)context.Principal!.Identity!;
                    if (string.IsNullOrWhiteSpace(identity.Name))
                    {
                        identity.TryRemoveClaim(identity.FindFirst(NameClaim));
                        identity.AddClaim(new Claim(NameClaim, DefaultName));
                    }
                    return Task.CompletedTask;
                };
                // Every challenge (Accedi, [Authorize] pages, NotVisible) in LAN mode shows the
                // read-only notice instead of a studio error page.
                options.Events.OnRedirectToIdentityProvider = context =>
                {
                    if (IsReadOnly(context.Request))
                    {
                        context.Response.Redirect("/Account/Accedi");
                        context.HandleResponse();
                    }
                    return Task.CompletedTask;
                };
                options.Events.OnRedirectToIdentityProviderForSignOut = context =>
                {
                    // The studio signs out at once only with a valid id_token_hint for its client.
                    context.ProtocolMessage.ClientId = context.Options.ClientId;
                    return Task.CompletedTask;
                };
                options.Events.OnRemoteFailure = context =>
                {
                    // A refused or stale callback (back button, expired correlation cookie, the
                    // studio refusing): no error page, just the sign-in page with a message.
                    context.HttpContext.RequestServices.GetRequiredService<ILoggerFactory>()
                        .CreateLogger(typeof(StudioSignIn))
                        .LogWarning("Accesso tramite lo studio non riuscito: {Error}", context.Failure?.GetType().Name);
                    context.Response.Redirect("/Account/Accedi?errore=1");
                    context.HandleResponse();
                    return Task.CompletedTask;
                };
            });
    }

    // Pages that moved to the studio: old links (wiki pages, bookmarks) keep working.
    private static readonly (string Path, bool OnAccountHost, string Target)[] MovedPages =
    [
        ("/Acquista", true, "/store"),
        ("/Riscatta", true, "/redeem"),
        ("/Download", true, "/download"),
        ("/Privacy", false, "/privacy"),
        ("/Termini", false, "/terms"),
        ("/Contatti", false, "/contact"),
    ];

    public static void MapMovedPages(this IEndpointRouteBuilder app)
    {
        foreach (var (path, onAccountHost, target) in MovedPages)
        {
            app.MapGet(path, ([FromServices] IOptions<StudioOptions> studio) =>
                Results.Redirect(onAccountHost ? studio.Value.Account(target) : studio.Value.Studio(target)));
        }
    }
}
