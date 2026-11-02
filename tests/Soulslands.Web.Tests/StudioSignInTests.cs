using System.Net;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing.Handlers;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Soulslands.Web.Data;
using Soulslands.Web.Services.Auth;

namespace Soulslands.Web.Tests;

// The site with its real sign-in (cookie + OIDC client), against FakeStudio, and a clock the
// test can move forward.
public sealed class StudioSiteFactory(string? dbPath = null) : SiteFactory(dbPath)
{
    public ShiftedTime Time { get; } = new();

    protected override bool UseTestAuth => false;

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        base.ConfigureWebHost(builder);
        builder.ConfigureTestServices(services => services.AddSingleton<TimeProvider>(Time));
    }

    // A browser on https (the __Host- cookie is Secure) that does not follow redirects.
    public HttpClient Browser(CookieContainer jar) =>
        CreateDefaultClient(new Uri("https://localhost"), new CookieContainerHandler(jar));

    // Accedi, the studio's authorize step (here: a code from FakeStudio), then the form_post
    // to /signin-oidc that the studio's page sends.
    public async Task<SignedIn> SignInAsync(CookieContainer jar, string subject, string? name, string[] roles, string returnUrl = "/Server")
    {
        var browser = Browser(jar);
        var challenge = await browser.GetAsync("/Account/Accedi?returnUrl=" + Uri.EscapeDataString(returnUrl));
        Assert.Equal(HttpStatusCode.Redirect, challenge.StatusCode);
        var authorize = challenge.Headers.Location!;
        var code = Studio.IssueCode(authorize, subject, name, roles);
        var callback = await browser.PostAsync("/signin-oidc", new FormUrlEncodedContent(new Dictionary<string, string>
        {
            ["code"] = code,
            ["state"] = QueryHelpers.ParseQuery(authorize.Query)["state"].ToString(),
        }));
        Assert.Equal(HttpStatusCode.Redirect, callback.StatusCode);
        return new SignedIn(browser, authorize, Studio.IdTokenFor(code), callback);
    }
}

public sealed record SignedIn(HttpClient Browser, Uri Authorize, string IdToken, HttpResponseMessage Callback);

public sealed class ShiftedTime : TimeProvider
{
    public TimeSpan Offset { get; set; }

    public override DateTimeOffset GetUtcNow() => base.GetUtcNow() + Offset;
}

public partial class StudioSignInTests
{
    private static readonly string NewSubject = Guid.NewGuid().ToString();

    [GeneratedRegex("name=\"__RequestVerificationToken\" type=\"hidden\" value=\"([^\"]+)\"")]
    private static partial Regex TokenPattern();

    private static string AuthCookie(HttpResponseMessage response) =>
        response.Headers.GetValues("Set-Cookie").Single(c => c.StartsWith(StudioSignIn.CookieName + "=", StringComparison.Ordinal));

    [Fact]
    public async Task AccediAsksTheStudioForACodeWithPkce()
    {
        using var site = new StudioSiteFactory();
        var response = await site.Browser(new()).GetAsync("/Account/Accedi");

        var location = response.Headers.Location!;
        Assert.Equal(FakeStudio.AccountUrl + "/connect/authorize", location.GetLeftPart(UriPartial.Path));
        var query = QueryHelpers.ParseQuery(location.Query);
        Assert.Equal("code", query["response_type"]);
        Assert.Equal("form_post", query["response_mode"]);
        Assert.Equal("S256", query["code_challenge_method"]);
        Assert.Equal("openid profile roles", query["scope"]);
        Assert.Equal(FakeStudio.ClientId, query["client_id"]);
        Assert.Equal("https://localhost/signin-oidc", query["redirect_uri"]);
        // The studio refuses both (ADR-0024 section 2).
        Assert.False(query.ContainsKey("prompt"));
        Assert.False(query.ContainsKey("max_age"));
    }

    [Fact]
    public async Task CodeIsRedeemedWithTheClientSecretAndTheVerifier()
    {
        using var site = new StudioSiteFactory();
        await site.SignInAsync(new(), NewSubject, "Aruto", []);

        var request = Assert.Single(site.Studio.TokenRequests);
        Assert.Equal(FakeStudio.ClientSecret, request["client_secret"]);
        Assert.False(string.IsNullOrEmpty(request["code_verifier"]));
        Assert.Equal("https://localhost/signin-oidc", request["redirect_uri"]);
    }

    [Fact]
    public async Task CookieIsHostOnlyAndHoldsOnlyTheIdToken()
    {
        using var site = new StudioSiteFactory();
        var signedIn = await site.SignInAsync(new(), NewSubject, "Aruto", [Roles.Agente]);

        var header = AuthCookie(signedIn.Callback).ToLowerInvariant();
        Assert.Contains("; path=/", header);
        Assert.Contains("; secure", header);
        Assert.Contains("; httponly", header);
        Assert.Contains("; samesite=lax", header);
        Assert.DoesNotContain("domain=", header);
        // A session cookie: the 1 hour lives in the ticket, not in the browser.
        Assert.DoesNotContain("expires=", header);

        var value = AuthCookie(signedIn.Callback).Split(';')[0][(StudioSignIn.CookieName.Length + 1)..];
        var cookieOptions = site.Services.GetRequiredService<IOptionsMonitor<CookieAuthenticationOptions>>().Get(StudioSignIn.CookieScheme);
        var ticket = cookieOptions.TicketDataFormat.Unprotect(value)!;
        var token = Assert.Single(ticket.Properties.GetTokens());
        Assert.Equal("id_token", token.Name);
        Assert.Equal(signedIn.IdToken, token.Value);
        Assert.Equal(StudioSignIn.CookieLifetime, ticket.Properties.ExpiresUtc - ticket.Properties.IssuedUtc);
        Assert.Equal(NewSubject, ticket.Principal.FindFirst("sub")?.Value);
        Assert.True(ticket.Principal.IsInRole(Roles.Agente));
    }

    [Fact]
    public async Task CookieLastsOneHourAndDoesNotSlide()
    {
        using var site = new StudioSiteFactory();
        var signedIn = await site.SignInAsync(new(), NewSubject, "Aruto", []);

        site.Time.Offset = TimeSpan.FromMinutes(40);
        var later = await signedIn.Browser.GetAsync("/Server");
        Assert.Equal(HttpStatusCode.OK, later.StatusCode);
        Assert.False(later.Headers.TryGetValues("Set-Cookie", out var cookies)
            && cookies.Any(c => c.StartsWith(StudioSignIn.CookieName, StringComparison.Ordinal)));

        site.Time.Offset = TimeSpan.FromMinutes(61);
        var expired = await signedIn.Browser.GetAsync("/Server");
        Assert.Equal(HttpStatusCode.Redirect, expired.StatusCode);
        Assert.StartsWith(FakeStudio.AccountUrl + "/connect/authorize", expired.Headers.Location!.ToString());
    }

    [Theory]
    [InlineData(Roles.Admin)]
    [InlineData(Roles.Moderatore)]
    [InlineData(Roles.Agente)]
    public async Task StudioStaffRolesReadTheStaffWiki(string role)
    {
        using var site = new StudioSiteFactory();
        var signedIn = await site.SignInAsync(new(), NewSubject, "Staff", [role]);

        Assert.Equal(HttpStatusCode.OK, (await signedIn.Browser.GetAsync("/wiki/" + SiteFactory.StaffSlug)).StatusCode);
    }

    [Fact]
    public async Task AccountWithoutRoleOrNameIsAPlayer()
    {
        using var site = new StudioSiteFactory();
        var signedIn = await site.SignInAsync(new(), NewSubject, name: null, []);

        Assert.Equal(HttpStatusCode.NotFound, (await signedIn.Browser.GetAsync("/wiki/" + SiteFactory.StaffSlug)).StatusCode);
        var home = await signedIn.Browser.GetStringAsync("/");
        Assert.Contains("Il mio account", home);
        Assert.Contains("href=\"" + FakeStudio.AccountUrl + "/identity/account/manage\"", home);
    }

    [Fact]
    public async Task StudioSignInMissingName()
    {
        using var site = new StudioSiteFactory();
        var signedIn = await site.SignInAsync(new(), NewSubject, name: null, []);

        var home = await signedIn.Browser.GetStringAsync("/");
        Assert.Contains("title=\"Il mio account Mahoroba\">" + StudioSignIn.DefaultName + "</a>", home);
    }

    // LAN mode (SITE_DOMAIN=:80, deploy/README.md): plain http on a LAN address never goes to the
    // studio; every challenged page lands on the read-only notice.
    [Theory]
    [InlineData("/Account/Accedi")]
    [InlineData("/Server")]
    public async Task LanModeOverHttpIsReadOnly(string path)
    {
        using var site = new StudioSiteFactory();
        var browser = site.CreateClient(new() { BaseAddress = new Uri("http://192.168.1.20"), AllowAutoRedirect = true });

        var response = await browser.GetAsync(path);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal("/Account/Accedi", response.RequestMessage!.RequestUri!.AbsolutePath);
        Assert.Contains("qui si può solo leggere", await response.Content.ReadAsStringAsync());
        Assert.Empty(site.Studio.TokenRequests);
    }

    // Local development on plain http loopback signs in through the studio as usual.
    [Theory]
    [InlineData("http://localhost:5000")]
    [InlineData("http://127.0.0.1:5000")]
    [InlineData("http://[::1]:5000")]
    public async Task LoopbackHttpStillSignsIn(string baseUrl)
    {
        using var site = new StudioSiteFactory();
        var browser = site.CreateDefaultClient(new Uri(baseUrl));

        var response = await browser.GetAsync("/Account/Accedi");

        Assert.Equal(HttpStatusCode.Redirect, response.StatusCode);
        Assert.StartsWith(FakeStudio.AccountUrl + "/connect/authorize", response.Headers.Location!.OriginalString);
    }

    [Fact]
    public async Task ReturnUrlStaysOnThisSite()
    {
        using var site = new StudioSiteFactory();
        var signedIn = await site.SignInAsync(new(), NewSubject, "Aruto", [], returnUrl: "https://evil.test/");

        Assert.Equal("/", signedIn.Callback.Headers.Location!.OriginalString);
    }

    [Fact]
    public async Task SignOutSendsTheIdTokenHintAndClientIdToTheStudio()
    {
        using var site = new StudioSiteFactory();
        var signedIn = await site.SignInAsync(new(), NewSubject, "Aruto", []);
        var home = await signedIn.Browser.GetStringAsync("/");

        var response = await signedIn.Browser.PostAsync("/Account/Esci", new FormUrlEncodedContent(new Dictionary<string, string>
        {
            ["__RequestVerificationToken"] = TokenPattern().Match(home).Groups[1].Value,
        }));

        Assert.Equal(HttpStatusCode.Redirect, response.StatusCode);
        var location = response.Headers.Location!;
        Assert.Equal(FakeStudio.AccountUrl + "/connect/endsession", location.GetLeftPart(UriPartial.Path));
        var query = QueryHelpers.ParseQuery(location.Query);
        Assert.Equal(signedIn.IdToken, query["id_token_hint"]);
        Assert.Equal(FakeStudio.ClientId, query["client_id"]);
        Assert.Equal("https://localhost/signout-callback-oidc", query["post_logout_redirect_uri"]);
        Assert.Contains("expires=Thu, 01 Jan 1970", AuthCookie(response));
        Assert.Equal(HttpStatusCode.Redirect, (await signedIn.Browser.GetAsync("/Server")).StatusCode);
    }

    [Theory]
    [InlineData("http://localhost:5001")]
    [InlineData("http://account.studio.test")]
    [InlineData("account.studio.test")]
    public void TheStudioIsReachedOnlyOverHttps(string accountUrl)
    {
        using var site = new StudioSiteFactory();
        var broken = site.WithWebHostBuilder(b => b.UseSetting("Studio:AccountUrl", accountUrl));

        var error = Assert.ThrowsAny<Exception>(() => broken.CreateClient());

        Assert.Contains("Studio:AccountUrl", Assert.IsType<OptionsValidationException>(error.GetBaseException()).Message);
    }

    [Theory]
    [InlineData("/wiki/" + SiteFactory.StaffSlug)]
    [InlineData("/wiki/" + SiteFactory.StaffSlug + "/cronologia")]
    [InlineData("/wiki/non-esiste")]
    public async Task AHiddenWikiPageAfterTheHourSendsTheBrowserBackToTheStudio(string path)
    {
        using var site = new StudioSiteFactory();
        var signedIn = await site.SignInAsync(new(), NewSubject, "Giocatore", []);

        site.Time.Offset = TimeSpan.FromMinutes(61);
        var expired = await signedIn.Browser.GetAsync(path);
        Assert.Equal(HttpStatusCode.Redirect, expired.StatusCode);
        Assert.StartsWith(FakeStudio.AccountUrl + "/connect/authorize", expired.Headers.Location!.ToString());

        // Staff or missing, the same answer: a visitor without the cookie gets 404 for both,
        // and so does a signed-in player (CookieLastsOneHour..., AccountWithoutRoleOrNameIsAPlayer).
        Assert.Equal(HttpStatusCode.NotFound, (await site.Browser(new()).GetAsync(path)).StatusCode);
    }

    [Fact]
    public async Task OtherSitesCannotSignPeopleOutWithALink()
    {
        using var site = new StudioSiteFactory();
        var signedIn = await site.SignInAsync(new(), NewSubject, "Aruto", []);

        await signedIn.Browser.GetAsync("/signout-oidc");

        Assert.Equal(HttpStatusCode.OK, (await signedIn.Browser.GetAsync("/Server")).StatusCode);
    }

    [Fact]
    public async Task AFailedCallbackShowsTheSignInPageAgain()
    {
        using var site = new StudioSiteFactory();
        var browser = site.Browser(new());

        var response = await browser.PostAsync("/signin-oidc", new FormUrlEncodedContent(new Dictionary<string, string>
        {
            ["code"] = "forged",
            ["state"] = "forged",
        }));

        Assert.Equal(HttpStatusCode.Redirect, response.StatusCode);
        Assert.Equal("/Account/Accedi?errore=1", response.Headers.Location!.OriginalString);
        Assert.Contains("non è riuscito", await browser.GetStringAsync("/Account/Accedi?errore=1"));
        Assert.Empty(site.Studio.TokenRequests);
    }

    [Fact]
    public async Task CookieAndAntiforgeryTokenSurviveARestart()
    {
        var dbPath = Path.Combine(Path.GetTempPath(), $"soulslands-restart-{Guid.NewGuid():N}.db");
        var jar = new CookieContainer();
        string token;
        try
        {
            using (var before = new StudioSiteFactory(dbPath))
            {
                var signedIn = await before.SignInAsync(jar, NewSubject, "Aruto", []);
                token = TokenPattern().Match(await signedIn.Browser.GetStringAsync("/Server")).Groups[1].Value;
                Assert.Equal("Soulslands.Web", before.Services.GetRequiredService<IOptions<DataProtectionOptions>>().Value.ApplicationDiscriminator);
            }

            using var after = new StudioSiteFactory(dbPath);
            var browser = after.Browser(jar);
            Assert.Equal(HttpStatusCode.OK, (await browser.GetAsync("/Server")).StatusCode);
            var created = await browser.PostAsync("/Server", new FormUrlEncodedContent(new Dictionary<string, string>
            {
                ["__RequestVerificationToken"] = token,
                ["Name"] = "Dopo il riavvio",
                ["Address"] = "play.example.test:7777",
            }));
            Assert.Equal(HttpStatusCode.Redirect, created.StatusCode);
            using var scope = after.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            Assert.Equal(NewSubject, db.GameServers.Single(s => s.Name == "Dopo il riavvio").OwnerId);
        }
        finally
        {
            Microsoft.Data.Sqlite.SqliteConnection.ClearAllPools();
            File.Delete(dbPath);
        }
    }

    // One fresh initial migration per database (ADR-0024 section 1), both with the key ring.
    [Fact]
    public void EachDatabaseHasOneInitialMigrationWithTheKeyRing()
    {
        using var sqlite = new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlite("DataSource=:memory:").Options);
        using var postgres = new PostgresDbContext(new DbContextOptionsBuilder<PostgresDbContext>().UseNpgsql("Host=localhost").Options);
        foreach (DbContext context in new DbContext[] { sqlite, postgres })
        {
            var migrations = context.GetService<IMigrationsAssembly>();
            var (id, type) = Assert.Single(migrations.Migrations);
            Assert.EndsWith("_InitialCreate", id);
            var migration = migrations.CreateMigration(type, context.Database.ProviderName!);
            var tables = migration.UpOperations.OfType<CreateTableOperation>().Select(t => t.Name).ToList();
            Assert.Contains("DataProtectionKeys", tables);
            Assert.Contains("GameServers", tables);
            Assert.DoesNotContain("AspNetUsers", tables);
        }
    }
}

// Pages that moved to the studio answer with a redirect there, so old links keep working.
public class MovedPagesTests(SiteFactory factory) : IClassFixture<SiteFactory>
{
    [Theory]
    [InlineData("/Acquista", FakeStudio.AccountUrl + "/store")]
    [InlineData("/Riscatta", FakeStudio.AccountUrl + "/redeem")]
    [InlineData("/Download", FakeStudio.AccountUrl + "/download")]
    [InlineData("/Privacy", FakeStudio.StudioUrl + "/privacy")]
    [InlineData("/termini", FakeStudio.StudioUrl + "/terms")]
    [InlineData("/Contatti", FakeStudio.StudioUrl + "/contact")]
    public async Task OldPageRedirectsToTheStudio(string path, string target)
    {
        var client = factory.CreateClient(new() { AllowAutoRedirect = false });
        var response = await client.GetAsync(path);

        Assert.Equal(HttpStatusCode.Redirect, response.StatusCode);
        Assert.Equal(target, response.Headers.Location!.ToString());
    }

    [Fact]
    public async Task HeaderLinksToTheStudio()
    {
        var home = await factory.CreateClient().GetStringAsync("/");

        Assert.Contains("href=\"" + FakeStudio.AccountUrl + "/store\"", home);
        Assert.Contains("href=\"" + FakeStudio.AccountUrl + "/identity/account/register\"", home);
        Assert.Contains("href=\"" + FakeStudio.StudioUrl + "/privacy\"", home);
        Assert.Contains("href=\"/Account/Accedi?returnUrl=%2F\"", home);
    }
}
