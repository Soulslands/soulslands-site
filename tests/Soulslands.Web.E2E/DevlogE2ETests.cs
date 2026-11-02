using System.Xml.Linq;
using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;

namespace Soulslands.Web.E2E;

[Collection(BrowserCollection.Name)]
public class DevlogE2ETests(BrowserFixture browser)
{
    private string Url(string path) => browser.Site.BaseUrl + path;

    [Fact]
    public async Task ListToPostAndBack()
    {
        var page = await browser.NewPageAsync();
        await page.GotoAsync(Url("/devlog"));

        var titles = page.Locator(".devlog-item h2 a");
        await Expect(titles).ToHaveCountAsync(3);
        // Newest first.
        Assert.Equal(["Benchmark pubblici", "Il piano delle milestone", "Il sito è pronto"], await titles.AllInnerTextsAsync());

        await titles.Nth(1).ClickAsync();
        await Expect(page).ToHaveURLAsync(Url("/devlog/secondo-post"));
        await Expect(page.Locator("h1")).ToHaveTextAsync("Il piano delle milestone");
        await Expect(page.Locator(".devlog-post time")).ToHaveAttributeAsync("datetime", "2026-10-17");
        await Expect(page.Locator(".devlog-post .wiki-content strong")).ToHaveTextAsync("secondo-post");

        // The link back in the post, then the browser's own back button.
        await page.GetByRole(AriaRole.Link, new() { Name = "Tutti i post" }).ClickAsync();
        await Expect(page).ToHaveURLAsync(Url("/devlog"));
        await Expect(titles).ToHaveCountAsync(3);

        await titles.First.ClickAsync();
        await Expect(page).ToHaveURLAsync(Url("/devlog/terzo-post"));
        await page.GoBackAsync();
        await Expect(page).ToHaveURLAsync(Url("/devlog"));
    }

    [Fact]
    public async Task FeedAnswersAtomWithEveryPost()
    {
        var page = await browser.NewPageAsync();
        await page.GotoAsync(Url("/"));
        // The layout advertises the feed to readers.
        var alternate = page.Locator("link[rel=alternate][type='application/atom+xml']");
        await Expect(alternate).ToHaveAttributeAsync("href", "/devlog/feed.xml");

        var response = await page.Context.APIRequest.GetAsync(Url("/devlog/feed.xml"));
        Assert.Equal(200, response.Status);
        Assert.StartsWith("application/atom+xml", response.Headers["content-type"]);

        XNamespace atom = "http://www.w3.org/2005/Atom";
        var feed = XDocument.Parse(await response.TextAsync()).Root!;
        Assert.Equal(atom + "feed", feed.Name);
        Assert.Equal("Devlog di Soulslands", feed.Element(atom + "title")!.Value);
        var entries = feed.Elements(atom + "entry").ToList();
        Assert.Equal(3, entries.Count);
        Assert.Equal("Benchmark pubblici", entries[0].Element(atom + "title")!.Value);
        Assert.EndsWith("/devlog/terzo-post", entries[0].Element(atom + "link")!.Attribute("href")!.Value);
    }

    [Fact]
    public async Task HomeShowsLatestPostsAndLinksToThem()
    {
        var page = await browser.NewPageAsync();
        await page.GotoAsync(Url("/"));

        var block = page.Locator("section[aria-labelledby=home-devlog-title]");
        await Expect(block.GetByRole(AriaRole.Heading, new() { Name = "Dal devlog" })).ToBeVisibleAsync();
        await Expect(block.Locator(".devlog-item").First).ToContainTextAsync("Benchmark pubblici");

        await block.GetByRole(AriaRole.Link, new() { Name = "Benchmark pubblici" }).ClickAsync();
        await Expect(page).ToHaveURLAsync(Url("/devlog/terzo-post"));

        await page.GotoAsync(Url("/"));
        await block.GetByRole(AriaRole.Link, new() { Name = "Tutti i post" }).ClickAsync();
        await Expect(page).ToHaveURLAsync(Url("/devlog"));
    }

    [Fact]
    public async Task MenuLinksReachDevlogAndBenchmark()
    {
        var page = await browser.NewPageAsync();
        await page.GotoAsync(Url("/Regole"));

        var nav = page.Locator("nav.navbar");
        await nav.GetByRole(AriaRole.Link, new() { Name = "Devlog", Exact = true }).ClickAsync();
        await Expect(page).ToHaveURLAsync(Url("/devlog"));
        await Expect(page.Locator("h1")).ToHaveTextAsync("Devlog");

        await nav.GetByRole(AriaRole.Link, new() { Name = "Benchmark", Exact = true }).ClickAsync();
        await Expect(page).ToHaveURLAsync(Url("/benchmark"));
        await Expect(page.Locator("h1")).ToHaveTextAsync("Benchmark");
    }

    [Theory]
    [InlineData("/devlog/non-esiste")]
    [InlineData("/benchmark/m9")]
    [InlineData("/benchmark/storia/nessuna.metrica")]
    public async Task UnknownPagesAnswer404(string path)
    {
        var page = await browser.NewPageAsync();
        var response = await page.GotoAsync(Url(path));
        Assert.Equal(404, response!.Status);
    }
}
