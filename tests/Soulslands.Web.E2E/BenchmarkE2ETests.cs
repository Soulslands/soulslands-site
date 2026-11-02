using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;

namespace Soulslands.Web.E2E;

[Collection(BrowserCollection.Name)]
public class BenchmarkE2ETests(BrowserFixture browser)
{
    private string Url(string path) => browser.Site.BaseUrl + path;

    [Fact]
    public async Task IndexToMilestonePageWithAMinecraftWinsRow()
    {
        var page = await browser.NewPageAsync();
        await page.GotoAsync(Url("/benchmark"));

        // Newest milestone first: m2 before m0.
        var items = page.Locator(".bench-index-item");
        Assert.Equal(["m2", "m0"], await items.EvaluateAllAsync<string[]>("els => els.map(e => e.dataset.milestone)"));

        await items.First.GetByRole(AriaRole.Link, new() { Name = "Benchmark M2" }).ClickAsync();
        await Expect(page).ToHaveURLAsync(Url("/benchmark/m2"));
        await Expect(page.Locator("h1")).ToHaveTextAsync("Benchmark M2");
        await Expect(page.Locator("section.bench-result")).ToHaveCountAsync(2);

        // The row where Minecraft is better stays visible, in the bot-swarm result.
        var wins = page.Locator("section#wander-build--aruto-linux-pc tr", new() { Has = page.Locator(".bench-mc-badge") });
        await Expect(wins).ToHaveCountAsync(1);
        await Expect(wins).ToBeVisibleAsync();
        await Expect(wins).ToContainTextAsync("net.up_bytes_per_player_s");
        await Expect(wins.Locator(".bench-mc-badge")).ToHaveTextAsync("Minecraft vince");

        await page.GetByRole(AriaRole.Link, new() { Name = "Tutti i benchmark" }).ClickAsync();
        await Expect(page).ToHaveURLAsync(Url("/benchmark"));
    }

    [Fact]
    public async Task MetricHistoryListsEveryMilestoneThatMeasuredIt()
    {
        var page = await browser.NewPageAsync();
        await page.GotoAsync(Url("/benchmark"));

        var row = page.Locator("tr[data-series^='gen.chunk_us|']");
        await Expect(row).ToContainTextAsync("M0, M2");
        await row.GetByRole(AriaRole.Link).ClickAsync();
        await Expect(page).ToHaveURLAsync(Url("/benchmark/storia/gen.chunk_us"));

        var history = page.Locator("table.bench-history tbody tr");
        await Expect(history).ToHaveCountAsync(2);
        Assert.Equal(["m0", "m2"], await history.EvaluateAllAsync<string[]>("els => els.map(e => e.dataset.milestone)"));

        // From the history row back to the result it comes from.
        await history.Last.GetByRole(AriaRole.Link, new() { Name = "M2" }).ClickAsync();
        await Expect(page).ToHaveURLAsync(new System.Text.RegularExpressions.Regex("/benchmark/m2#"));
    }

    [Fact]
    public async Task RawFileIsADownload()
    {
        var page = await browser.NewPageAsync();
        await page.GotoAsync(Url("/benchmark/m2"));

        var download = await page.RunAndWaitForDownloadAsync(() =>
            page.GetByRole(AriaRole.Link, new() { Name = "raw/wander-build--aruto-linux-pc.ticks.csv.gz" }).ClickAsync());
        Assert.Equal("wander-build--aruto-linux-pc.ticks.csv.gz", download.SuggestedFilename);
        var path = await download.PathAsync();
        Assert.True(new FileInfo(path!).Length > 0);
    }

    [Fact]
    public async Task RawPathsOutsideTheResultAreNotServed()
    {
        var page = await browser.NewPageAsync();
        foreach (var path in new[] { "/benchmark/m2/raw/../chunk-generation--aruto-linux-pc.json", "/benchmark/m2/raw/not-listed.csv.gz" })
        {
            var response = await page.Context.APIRequest.GetAsync(Url(path));
            Assert.Equal(404, response.Status);
        }
    }
}
