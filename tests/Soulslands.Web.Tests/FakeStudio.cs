using System.Collections.Concurrent;
using System.Net;
using System.Net.Http.Json;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;

namespace Soulslands.Web.Tests;

// The studio's OIDC provider as the site sees it (SoulslandsGame ADR-0024 section 2): fixed
// discovery data, a test signing key, and a token endpoint answered in memory through the
// site's backchannel. The test plays the browser: it reads the authorize redirect, asks for a
// code here and posts it to /signin-oidc, as the studio's form_post page would.
public sealed class FakeStudio : HttpMessageHandler
{
    public const string AccountUrl = "https://account.studio.test";
    public const string StudioUrl = "https://studio.test";
    public const string Issuer = AccountUrl + "/";
    public const string ClientId = "soulslands-website";
    public const string ClientSecret = "test-client-secret";

    private readonly RsaSecurityKey _key = new(RSA.Create(2048)) { KeyId = "test-signing" };
    private readonly ConcurrentDictionary<string, string> _idTokensByCode = new();
    private readonly ConcurrentDictionary<string, bool> _usedCodes = new();

    public FakeStudio()
    {
        Configuration = new OpenIdConnectConfiguration
        {
            Issuer = Issuer,
            AuthorizationEndpoint = AccountUrl + "/connect/authorize",
            TokenEndpoint = AccountUrl + "/connect/token",
            EndSessionEndpoint = AccountUrl + "/connect/endsession",
        };
        Configuration.SigningKeys.Add(_key);
    }

    public OpenIdConnectConfiguration Configuration { get; }

    // Every form the site posted to the token endpoint.
    public ConcurrentQueue<Dictionary<string, string>> TokenRequests { get; } = new();

    public void Install(IServiceCollection services) =>
        services.PostConfigure<OpenIdConnectOptions>(OpenIdConnectDefaults.AuthenticationScheme, options =>
        {
            options.Configuration = Configuration;
            options.ConfigurationManager = new StaticConfigurationManager<OpenIdConnectConfiguration>(Configuration);
            options.Backchannel = new HttpClient(this);
        });

    // What the studio does after the user signs in: a one-time code whose id token carries
    // the nonce of this authorize request. name is left out when null, as the studio does
    // for an account without a display name.
    public string IssueCode(Uri authorizeRequest, string subject, string? name, params string[] roles)
    {
        var query = QueryHelpers.ParseQuery(authorizeRequest.Query);
        var claims = new Dictionary<string, object> { ["sub"] = subject, ["nonce"] = query["nonce"].ToString() };
        if (name is not null)
        {
            claims["name"] = name;
        }
        if (roles.Length > 0)
        {
            claims["role"] = roles;
        }
        var now = DateTime.UtcNow;
        var idToken = new JsonWebTokenHandler().CreateToken(new SecurityTokenDescriptor
        {
            Issuer = Issuer,
            Audience = ClientId,
            Claims = claims,
            IssuedAt = now,
            NotBefore = now,
            Expires = now.AddMinutes(20),
            SigningCredentials = new SigningCredentials(_key, SecurityAlgorithms.RsaSha256),
        });
        var code = Base64UrlEncoder.Encode(RandomNumberGenerator.GetBytes(16));
        _idTokensByCode[code] = idToken;
        return code;
    }

    public string IdTokenFor(string code) => _idTokensByCode[code];

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        if (request.Method != HttpMethod.Post || request.RequestUri?.ToString() != Configuration.TokenEndpoint)
        {
            return new HttpResponseMessage(HttpStatusCode.NotFound);
        }
        var form = QueryHelpers.ParseQuery(await request.Content!.ReadAsStringAsync(cancellationToken))
            .ToDictionary(p => p.Key, p => p.Value.ToString());
        TokenRequests.Enqueue(form);
        // Like OpenIddict: a confidential client, PKCE required, each code used once.
        if (form.GetValueOrDefault("client_id") != ClientId || form.GetValueOrDefault("client_secret") != ClientSecret
            || form.GetValueOrDefault("grant_type") != "authorization_code"
            || string.IsNullOrEmpty(form.GetValueOrDefault("code_verifier"))
            || !_idTokensByCode.TryGetValue(form.GetValueOrDefault("code") ?? "", out var idToken)
            || !_usedCodes.TryAdd(form["code"], true))
        {
            return new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = JsonContent.Create(new { error = "invalid_grant" }) };
        }
        return new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = JsonContent.Create(new Dictionary<string, object>
            {
                ["access_token"] = "opaque-access-token",
                ["token_type"] = "Bearer",
                ["expires_in"] = 1200,
                ["id_token"] = idToken,
            }),
        };
    }
}
