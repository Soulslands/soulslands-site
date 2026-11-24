using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Soulslands.Web.Services;

namespace Soulslands.Web.Tests;

// The site is static (W-22): public pages read from files, no sign-in, no database, no cookies,
// and nothing of the old dynamic site answers any more.
public class SiteTests(SiteFactory factory) : IClassFixture<SiteFactory>
{
    private HttpClient Client() => factory.CreateClient(new WebApplicationFactoryClientOptions { AllowAutoRedirect = false });

    [Fact]
    public async Task AnyoneReadsAWikiPage()
    {
        var response = await Client().GetAsync("/wiki/razze");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Contains("Razze", await response.Content.ReadAsStringAsync());
    }

    [Fact]
    public async Task AMissingWikiPageIsNotFound()
    {
        Assert.Equal(HttpStatusCode.NotFound, (await Client().GetAsync("/wiki/pagina-che-non-esiste")).StatusCode);
    }

    [Theory]
    [InlineData("/")]
    [InlineData("/wiki")]
    [InlineData("/Regole")]
    [InlineData("/Media")]
    [InlineData("/Stato")]
    [InlineData("/devlog")]
    [InlineData("/benchmark")]
    public async Task PublicSectionsLoad(string path)
    {
        Assert.Equal(HttpStatusCode.OK, (await Client().GetAsync(path)).StatusCode);
    }

    // The old dynamic site's sign-in, admin, server list, editor, preferences and API routes.
    // /Preferenze and the pages moved to the studio redirect only in dist/_redirects.
    [Theory]
    [InlineData("/Account/Accedi")]
    [InlineData("/Account/Esci")]
    [InlineData("/signin-oidc")]
    [InlineData("/Admin/Server")]
    [InlineData("/Admin/Bacheca")]
    [InlineData("/Server")]
    [InlineData("/wiki/modifica")]
    [InlineData("/wiki/modifica/razze")]
    [InlineData("/wiki/razze/cronologia")]
    [InlineData("/Preferenze")]
    [InlineData("/api/health")]
    [InlineData("/api/servers")]
    public async Task NothingOfTheDynamicSiteAnswers(string path)
    {
        Assert.Equal(HttpStatusCode.NotFound, (await Client().GetAsync(path)).StatusCode);
    }

    [Theory]
    [InlineData("/")]
    [InlineData("/wiki")]
    [InlineData("/wiki/razze")]
    [InlineData("/Stato")]
    public async Task NoPageSetsACookie(string path)
    {
        var response = await Client().GetAsync(path);

        Assert.False(response.Headers.Contains("Set-Cookie"), $"{path} sets a cookie");
    }

    [Fact]
    public async Task HeaderAndFooterLinkToTheStudioAndOfferNoSignIn()
    {
        var home = await Client().GetStringAsync("/");

        Assert.Contains("href=\"" + SiteFactory.AccountUrl + "/store\"", home);
        Assert.Contains("href=\"" + SiteFactory.AccountUrl + "/identity/account/register\"", home);
        Assert.Contains("href=\"" + SiteFactory.StudioUrl + "/privacy\"", home);
        Assert.DoesNotContain("Accedi", home);
        Assert.DoesNotContain("/Account/", home);
    }

    [Theory]
    [InlineData("http://localhost:5001")]
    [InlineData("http://account.studio.test")]
    [InlineData("account.studio.test")]
    public void TheAnnouncementsHostIsHttpsOnly(string accountUrl)
    {
        var broken = factory.WithWebHostBuilder(b => b.UseSetting("Studio:AccountUrl", accountUrl));

        var error = Assert.ThrowsAny<Exception>(() => broken.CreateClient());

        Assert.Contains("Studio:AccountUrl", Assert.IsType<OptionsValidationException>(error.GetBaseException()).Message);
    }

    // The preview (dotnet run) serves the wiki search index the export writes into dist/.
    [Fact]
    public async Task TheWikiSearchIndexIsServed()
    {
        var response = await Client().GetAsync(SearchIndex.Url);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal("application/json", response.Content.Headers.ContentType?.MediaType);
        var store = factory.Services.GetRequiredService<WikiStore>();
        Assert.Equal(SearchIndex.For(store.Pages), await response.Content.ReadAsStringAsync());
        Assert.Contains("\"slug\":\"razze\"", await response.Content.ReadAsStringAsync());
    }
}

// The site starts, renders and stops without creating a database file (W-22 accept line).
public class NoDatabaseTests
{
    private static readonly string[] Patterns = ["*.db", "*.db-shm", "*.db-wal", "*.sqlite"];

    private static Dictionary<string, DateTime> DatabaseFiles(string directory, SearchOption option) =>
        Patterns.SelectMany(p => Directory.EnumerateFiles(directory, p, option))
            .ToDictionary(f => f, File.GetLastWriteTimeUtc);

    [Fact]
    public async Task NoDatabaseFileIsCreated()
    {
        var started = DateTime.UtcNow.AddSeconds(-1);
        string contentRoot;
        var tempBefore = DatabaseFiles(Path.GetTempPath(), SearchOption.TopDirectoryOnly);
        using (var site = new SiteFactory())
        {
            contentRoot = site.Services.GetRequiredService<IWebHostEnvironment>().ContentRootPath;
            var client = site.CreateClient();
            foreach (var path in new[] { "/", "/wiki", "/wiki/razze", "/Regole", "/Stato", "/devlog", "/benchmark" })
            {
                Assert.Equal(HttpStatusCode.OK, (await client.GetAsync(path)).StatusCode);
            }
        }

        // A checkout that ran the old dynamic site may still hold its app.db: only a file written
        // by this run counts.
        var written = DatabaseFiles(contentRoot, SearchOption.AllDirectories).Where(f => f.Value >= started).Select(f => f.Key);
        Assert.Empty(written);
        var newInTemp = DatabaseFiles(Path.GetTempPath(), SearchOption.TopDirectoryOnly).Keys.Except(tempBefore.Keys).ToList();
        Assert.DoesNotContain(newInTemp, f => Path.GetFileName(f).StartsWith("soulslands", StringComparison.OrdinalIgnoreCase));
    }
}
