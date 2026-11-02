using System.Net;
using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Soulslands.Web.Data;
using Soulslands.Web.Services;
using Soulslands.Web.Services.Auth;

namespace Soulslands.Web.Tests;

public class SiteFactory : WebApplicationFactory<Program>
{
    private readonly string _dbPath;
    private readonly bool _ownsDb;

    public SiteFactory() : this(null)
    {
    }

    // A given dbPath is kept on Dispose, so a second host can start on the same database.
    protected SiteFactory(string? dbPath)
    {
        _ownsDb = dbPath is null;
        _dbPath = dbPath ?? Path.Combine(Path.GetTempPath(), $"soulslands-test-{Guid.NewGuid():N}.db");
    }

    // The studio's OIDC provider, answered in memory: challenges redirect to it, and
    // StudioSiteFactory signs in through it.
    public FakeStudio Studio { get; } = new();

    // False: the real sign-in cookie is the default scheme (StudioSiteFactory).
    protected virtual bool UseTestAuth => true;

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseSetting("ConnectionStrings:DefaultConnection", $"DataSource={_dbPath}");
        builder.UseSetting("Studio:AccountUrl", FakeStudio.AccountUrl);
        builder.UseSetting("Studio:StudioUrl", FakeStudio.StudioUrl);
        builder.UseSetting("Studio:ClientSecret", FakeStudio.ClientSecret);
        builder.ConfigureTestServices(services =>
        {
            Studio.Install(services);
            if (UseTestAuth)
            {
                services.AddAuthentication(TestAuthHandler.SchemeName)
                    .AddScheme<AuthenticationSchemeOptions, TestAuthHandler>(TestAuthHandler.SchemeName, _ => { });
            }
        });
    }

    // The staff page the visibility tests read. This repository holds no staff page (ADR-0035
    // section 2, PublicWikiTests), so the page is a fixture imported from a temporary folder.
    public const string StaffSlug = "pagina-riservata";

    public const string StaffPage = $"""
        ---
        title: Pagina riservata
        slug: {StaffSlug}
        category: Prova
        visibility: Staff
        ---
        Testo riservato allo staff.
        """;

    protected override IHost CreateHost(IHostBuilder builder)
    {
        var host = base.CreateHost(builder);
        var folder = Directory.CreateTempSubdirectory("wiki-staff-");
        try
        {
            File.WriteAllText(Path.Combine(folder.FullName, StaffSlug + ".md"), StaffPage);
            using var scope = host.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            WikiContentImporter.ImportAsync(db, folder.FullName, NullLogger.Instance).GetAwaiter().GetResult();
        }
        finally
        {
            folder.Delete(recursive: true);
        }
        return host;
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
        Microsoft.Data.Sqlite.SqliteConnection.ClearAllPools();
        if (_ownsDb)
        {
            File.Delete(_dbPath);
        }
    }
}

// Signs the request in with the roles listed in the X-Test-Roles header and, when X-Test-User
// is set, as that studio account id. The claims have the shape the studio's id token gives
// (sub, name, role), read the same way as the real sign-in cookie.
public class TestAuthHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder)
    : AuthenticationHandler<AuthenticationSchemeOptions>(options, logger, encoder)
{
    public const string SchemeName = "Test";
    public const string Header = "X-Test-Roles";
    public const string UserHeader = "X-Test-User";
    public const string DefaultSubject = "00000000-0000-4000-8000-000000000001";

    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        if (!Request.Headers.TryGetValue(Header, out var value))
        {
            return Task.FromResult(AuthenticateResult.NoResult());
        }

        var subject = Request.Headers.TryGetValue(UserHeader, out var userId) ? userId.ToString() : DefaultSubject;
        var claims = value.ToString()
            .Split(',', StringSplitOptions.RemoveEmptyEntries)
            .Select(r => new Claim(StudioSignIn.RoleClaim, r))
            .Append(new Claim(StudioSignIn.NameClaim, "Tester"))
            .Append(new Claim(StudioSignIn.SubjectClaim, subject));
        var identity = new ClaimsIdentity(claims, SchemeName, StudioSignIn.NameClaim, StudioSignIn.RoleClaim);
        return Task.FromResult(AuthenticateResult.Success(new AuthenticationTicket(new ClaimsPrincipal(identity), SchemeName)));
    }
}

public class WikiVisibilityTests(SiteFactory factory) : IClassFixture<SiteFactory>
{
    private HttpClient Client(string? roles = null)
    {
        var client = factory.CreateClient(new WebApplicationFactoryClientOptions { AllowAutoRedirect = false });
        if (roles is not null)
        {
            client.DefaultRequestHeaders.Add(TestAuthHandler.Header, roles);
        }
        return client;
    }

    [Fact]
    public async Task AnonymousCanReadPublicPage()
    {
        var response = await Client().GetAsync("/wiki/benvenuto");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("Giocatore")]
    public async Task PlayersGet404OnStaffPage(string? roles)
    {
        var client = Client(roles);
        Assert.Equal(HttpStatusCode.NotFound, (await client.GetAsync("/wiki/" + SiteFactory.StaffSlug)).StatusCode);
        Assert.Equal(HttpStatusCode.NotFound, (await client.GetAsync("/wiki/" + SiteFactory.StaffSlug + "/cronologia")).StatusCode);
    }

    [Fact]
    public async Task PlayersDoNotSeeStaffPagesInListOrSearch()
    {
        var client = Client();
        Assert.DoesNotContain("/wiki/" + SiteFactory.StaffSlug, await client.GetStringAsync("/wiki"));
        Assert.DoesNotContain("/wiki/" + SiteFactory.StaffSlug, await client.GetStringAsync("/wiki?q=riservata"));
    }

    [Theory]
    [InlineData(Roles.Admin)]
    [InlineData(Roles.Moderatore)]
    [InlineData(Roles.Agente)]
    public async Task StaffCanReadStaffPage(string role)
    {
        var client = Client(role);
        Assert.Equal(HttpStatusCode.OK, (await client.GetAsync("/wiki/" + SiteFactory.StaffSlug)).StatusCode);
        Assert.Contains("/wiki/" + SiteFactory.StaffSlug, await client.GetStringAsync("/wiki"));
    }

    [Fact]
    public async Task AgentsCannotEdit()
    {
        var response = await Client(Roles.Agente).GetAsync("/wiki/modifica/" + SiteFactory.StaffSlug);
        Assert.NotEqual(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task ModeratorsCanEdit()
    {
        var response = await Client(Roles.Moderatore).GetAsync("/wiki/modifica/" + SiteFactory.StaffSlug);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Theory]
    [InlineData("/Regole")]
    [InlineData("/Media")]
    [InlineData("/Stato")]
    [InlineData("/Preferenze")]
    public async Task PublicSectionsLoad(string path)
    {
        Assert.Equal(HttpStatusCode.OK, (await Client().GetAsync(path)).StatusCode);
    }

    [Theory]
    [InlineData("/Admin/Bacheca")]
    [InlineData("/Admin/Server")]
    public async Task AdminPagesNeedAdmin(string path)
    {
        Assert.NotEqual(HttpStatusCode.OK, (await Client(Roles.Moderatore).GetAsync(path)).StatusCode);
        Assert.Equal(HttpStatusCode.OK, (await Client(Roles.Admin).GetAsync(path)).StatusCode);
    }
}
