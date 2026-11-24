using System.Diagnostics;
using System.Text.Json;
using Microsoft.Playwright;
using Soulslands.StaticExport;
using static Microsoft.Playwright.Assertions;

namespace Soulslands.Web.E2E;

// The static site of W-21 in a headless browser, served from dist/ by serve-static.py (http.server
// plus the "/*" headers of _headers and 404.html, like Cloudflare Pages). Two exports: the real
// WikiContent (or STATIC_DIST, the one scripts/build-static.sh wrote in CI) and the fixture wiki
// with a mermaid diagram, so the Content-Security-Policy is checked on a diagram too.
public sealed class StaticSiteFixture : IAsyncLifetime
{
    public const string AnnouncementsUrl = "https://account.mahoroba.studio/api/games/soulslands/announcements";

    private readonly List<Process> _servers = [];
    private readonly List<string> _temp = [];
    private IPlaywright _playwright = null!;

    public IBrowser Browser { get; private set; } = null!;
    public string SiteDist { get; private set; } = "";
    public string SiteUrl { get; private set; } = "";
    public string FixtureUrl { get; private set; } = "";

    public async Task InitializeAsync()
    {
        SiteDist = Environment.GetEnvironmentVariable("STATIC_DIST") is { Length: > 0 } given
            ? Path.GetFullPath(given)
            : await ExportAsync(null);
        var fixtureWiki = Directory.CreateTempSubdirectory("static-wiki-").FullName;
        _temp.Add(fixtureWiki);
        CopyTree(Path.Combine(E2eSite.Fixtures, "StaticWiki"), fixtureWiki);
        var fixtureDist = await ExportAsync(fixtureWiki);

        SiteUrl = await ServeAsync(SiteDist);
        FixtureUrl = await ServeAsync(fixtureDist);
        _playwright = await Playwright.CreateAsync();
        Browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
    }

    public async Task DisposeAsync()
    {
        await Browser.DisposeAsync();
        _playwright.Dispose();
        foreach (var server in _servers)
        {
            server.Kill(entireProcessTree: true);
            await server.WaitForExitAsync();
            server.Dispose();
        }
        foreach (var dir in _temp.Where(Directory.Exists))
        {
            Directory.Delete(dir, recursive: true);
        }
    }

    // A fresh context (no cookies, no storage); the studio's announcements answer `announcements`
    // (an empty list by default), so no test reaches the real studio.
    public async Task<(IPage Page, List<string> Errors)> NewPageAsync(string announcements = "[]")
    {
        var context = await Browser.NewContextAsync(new BrowserNewContextOptions { ViewportSize = new ViewportSize { Width = 1280, Height = 800 } });
        context.SetDefaultTimeout(15_000);
        await context.RouteAsync(AnnouncementsUrl + "*", route => route.FulfillAsync(new RouteFulfillOptions
        {
            Status = 200,
            ContentType = "application/json",
            Headers = new Dictionary<string, string> { ["Access-Control-Allow-Origin"] = "*" },
            Body = announcements,
        }));
        var page = await context.NewPageAsync();
        var errors = new List<string>();
        page.Console += (_, message) =>
        {
            if (message.Type == "error")
            {
                errors.Add($"{page.Url}: {message.Text}");
            }
        };
        page.PageError += (_, error) => errors.Add($"{page.Url}: {error}");
        return (page, errors);
    }

    private async Task<string> ExportAsync(string? wiki)
    {
        var dist = Path.Combine(Path.GetTempPath(), $"soulslands-dist-{Guid.NewGuid():N}");
        _temp.Add(dist);
        using var output = new StringWriter();
        using var errors = new StringWriter();
        var code = await StaticExporter.RunAsync(new ExportOptions { OutputDirectory = dist, WikiDirectory = wiki }, output, errors);
        if (code != 0)
        {
            throw new InvalidOperationException($"Esportazione fallita ({code}): {errors}");
        }
        return dist;
    }

    private async Task<string> ServeAsync(string dist)
    {
        var server = Process.Start(new ProcessStartInfo("python3")
        {
            ArgumentList = { Path.Combine(AppContext.BaseDirectory, "serve-static.py"), dist },
            RedirectStandardOutput = true,
            UseShellExecute = false,
        })!;
        _servers.Add(server);
        var line = await server.StandardOutput.ReadLineAsync().WaitAsync(TimeSpan.FromSeconds(20));
        if (line is null || !line.StartsWith("PORT "))
        {
            throw new InvalidOperationException($"serve-static.py non è partito: {line}");
        }
        return $"http://127.0.0.1:{line[5..]}";
    }

    private static void CopyTree(string from, string to)
    {
        foreach (var file in Directory.EnumerateFiles(from, "*", SearchOption.AllDirectories))
        {
            var target = Path.Combine(to, Path.GetRelativePath(from, file));
            Directory.CreateDirectory(Path.GetDirectoryName(target)!);
            File.Copy(file, target);
        }
    }
}

public class StaticSiteE2ETests(StaticSiteFixture site) : IClassFixture<StaticSiteFixture>
{
    private List<JsonElement> SearchIndex()
    {
        using var index = JsonDocument.Parse(File.ReadAllText(Path.Combine(site.SiteDist, StaticExporter.SearchIndexFile)));
        return [.. index.RootElement.EnumerateArray().Select(e => e.Clone())];
    }

    private string FirstPostPath() =>
        "/devlog/" + Directory.GetDirectories(Path.Combine(site.SiteDist, "devlog")).Select(Path.GetFileName).Order().First();

    [Fact]
    public async Task EveryKindOfPageRendersWithoutConsoleErrors()
    {
        var wikiPage = "/wiki/" + SearchIndex()[0].GetProperty("slug").GetString();
        var (page, errors) = await site.NewPageAsync();
        foreach (var path in new[] { "/", "/wiki", wikiPage, "/devlog", FirstPostPath(), "/benchmark", "/Regole", "/Media", "/Stato" })
        {
            var response = await page.GotoAsync(site.SiteUrl + path, new PageGotoOptions { WaitUntil = WaitUntilState.NetworkIdle });
            Assert.True(response?.Status == 200, $"{path}: {response?.Status}");
            await Expect(page.Locator("footer.site-footer")).ToBeVisibleAsync();
        }

        var missingUrl = site.SiteUrl + "/pagina/che-non-esiste";
        var missing = await page.GotoAsync(missingUrl, new PageGotoOptions { WaitUntil = WaitUntilState.NetworkIdle });
        Assert.Equal(404, missing?.Status);
        // Chromium reports the 404 status of the page itself as a console error: expected here.
        errors.RemoveAll(e => e == $"{missingUrl}: Failed to load resource: the server responded with a status of 404 (Not Found)");
        await Expect(page.Locator("main h1")).ToHaveTextAsync("404");
        await Expect(page.Locator("main")).ToContainTextAsync("Questa pagina non esiste.");

        Assert.Empty(errors);
    }

    [Fact]
    public async Task NavigationAndFooterLinksAnswerOrLeaveTheSite()
    {
        var (page, _) = await site.NewPageAsync();
        await page.GotoAsync(site.SiteUrl + "/");
        var hrefs = await page.Locator("header a[href], footer a[href]").EvaluateAllAsync<string[]>("links => links.map(a => a.href)");
        Assert.NotEmpty(hrefs);
        var local = hrefs.Where(h => h.StartsWith(site.SiteUrl, StringComparison.Ordinal)).Distinct().ToList();
        Assert.Contains(site.SiteUrl + "/wiki", local);
        foreach (var href in local)
        {
            var response = await page.Context.APIRequest.GetAsync(href);
            Assert.True(response.Status == 200, $"{href}: {response.Status}");
        }
        // The rest leaves the site: the studio's store, download, legal and contact pages.
        Assert.All(hrefs.Except(local), h => Assert.StartsWith("https://", h));
    }

    [Fact]
    public async Task AnnouncementsAreShownAsPlainText()
    {
        const string text = "<img src=x onerror=alert(1)>";
        var announcements = JsonSerializer.Serialize(new[] { new { id = 1, text, createdAt = "2026-11-20T09:30:00Z" } });
        var (page, errors) = await site.NewPageAsync(announcements);
        var dialogs = 0;
        page.Dialog += (_, dialog) => { dialogs++; _ = dialog.DismissAsync(); };
        await page.GotoAsync(site.SiteUrl + "/", new PageGotoOptions { WaitUntil = WaitUntilState.NetworkIdle });

        var board = page.Locator("#bacheca");
        await Expect(board).ToBeVisibleAsync();
        await Expect(board.Locator("li")).ToHaveCountAsync(1);
        await Expect(board.Locator("li")).ToHaveTextAsync("20/11" + text);
        await Expect(board.Locator("img")).ToHaveCountAsync(0);
        Assert.Equal(0, dialogs);
        Assert.Empty(errors);
    }

    [Fact]
    public async Task EmptyAnnouncementsKeepTheBoardHidden()
    {
        var (page, _) = await site.NewPageAsync("[]");
        await page.GotoAsync(site.SiteUrl + "/", new PageGotoOptions { WaitUntil = WaitUntilState.NetworkIdle });
        await Expect(page.Locator("#bacheca")).ToBeHiddenAsync();
    }

    [Fact]
    public async Task WikiSearchFindsAPageByATitleWord()
    {
        var entry = SearchIndex().First(e => e.GetProperty("title").GetString()!.Split(' ').Any(w => w.Length >= 5));
        var title = entry.GetProperty("title").GetString()!;
        var word = title.Split(' ').First(w => w.Length >= 5);
        var (page, errors) = await site.NewPageAsync();
        await page.GotoAsync(site.SiteUrl + "/wiki");

        await page.GetByRole(AriaRole.Searchbox, new() { Name = "Cerca nella wiki" }).FillAsync(word.ToLowerInvariant());

        var result = page.Locator("#wiki-search-results a", new() { HasText = title });
        await Expect(result.First).ToBeVisibleAsync();
        await Expect(result.First).ToHaveAttributeAsync("href", "/wiki/" + entry.GetProperty("slug").GetString());
        await Expect(page.Locator("#wiki-index")).ToBeHiddenAsync();
        Assert.Empty(errors);
    }

    [Fact]
    public async Task DiagramIsDrawnUnderTheContentSecurityPolicy()
    {
        var (page, errors) = await site.NewPageAsync();
        var response = await page.GotoAsync(site.FixtureUrl + "/wiki/diagramma-di-prova", new PageGotoOptions { WaitUntil = WaitUntilState.NetworkIdle });
        Assert.Contains("script-src 'self'", response!.Headers["content-security-policy"]);
        await Expect(page.Locator("pre.mermaid svg")).ToBeVisibleAsync();
        Assert.Empty(errors);
    }

    [Fact]
    public async Task FontChoiceIsKeptInLocalStorageNotInACookie()
    {
        var (page, errors) = await site.NewPageAsync();
        await page.GotoAsync(site.SiteUrl + "/");
        var html = page.Locator("html");
        await Expect(html).Not.ToHaveClassAsync(new System.Text.RegularExpressions.Regex("ss-browser-fonts"));

        await page.Locator("#font-toggle").ClickAsync();
        await Expect(html).ToHaveClassAsync(new System.Text.RegularExpressions.Regex("ss-browser-fonts"));
        await page.GotoAsync(site.SiteUrl + "/Regole");
        await Expect(html).ToHaveClassAsync(new System.Text.RegularExpressions.Regex("ss-browser-fonts"));
        Assert.Equal("browser", await page.EvaluateAsync<string>("() => localStorage.getItem('ss-fonts')"));
        Assert.Empty(await page.Context.CookiesAsync());

        await page.Locator("#font-toggle").ClickAsync();
        await Expect(html).Not.ToHaveClassAsync(new System.Text.RegularExpressions.Regex("ss-browser-fonts"));
        Assert.Empty(errors);
    }
}
