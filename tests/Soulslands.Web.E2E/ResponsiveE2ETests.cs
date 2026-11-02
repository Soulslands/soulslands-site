using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;

namespace Soulslands.Web.E2E;

// Reviewers asked for phone width and "both themes". The site has a single colour theme (dark, set in the
// layout, no switch); what a visitor can change is the colour scheme of the browser, which the page must
// ignore, and the font (Cursed Souls or the browser's, chosen on /Preferenze). So both are covered here.
[Collection(BrowserCollection.Name)]
public class ResponsiveE2ETests(BrowserFixture browser)
{
    public static TheoryData<string> Pages => new()
    {
        "/", "/devlog", "/devlog/primo-post", "/benchmark", "/benchmark/m2", "/benchmark/m0",
        "/benchmark/storia/gen.chunk_us", "/Preferenze",
    };

    [Theory]
    [MemberData(nameof(Pages))]
    public async Task NothingOverflowsAtPhoneWidthInBothColourSchemes(string path)
    {
        foreach (var scheme in new[] { ColorScheme.Dark, ColorScheme.Light })
        {
            var page = await browser.NewPageAsync(BrowserFixture.Phone, scheme);
            await page.GotoAsync(browser.Site.BaseUrl + path);

            Assert.Equal("dark", await page.Locator("html").GetAttributeAsync("data-bs-theme"));
            await AssertNoHorizontalScrollAsync(page, $"{path} ({scheme})");
            Assert.True(await page.EvaluateAsync<bool>("matchMedia('(prefers-color-scheme: " + (scheme == ColorScheme.Dark ? "dark" : "light") + ")').matches"));
            await page.Context.CloseAsync();
        }
    }

    [Theory]
    [MemberData(nameof(Pages))]
    public async Task TextIsReadableAtPhoneWidthInBothColourSchemesAndBothFonts(string path)
    {
        foreach (var scheme in new[] { ColorScheme.Dark, ColorScheme.Light })
        {
            foreach (var browserFonts in new[] { false, true })
            {
                var page = await browser.NewPageAsync(BrowserFixture.Phone, scheme, browserFonts);
                await page.GotoAsync(browser.Site.BaseUrl + path);
                await AssertTextIsReadableAsync(page, $"{path} ({scheme}, {(browserFonts ? "browser fonts" : "site fonts")})");
                await page.Context.CloseAsync();
            }
        }
    }

    [Theory]
    [MemberData(nameof(Pages))]
    public async Task NothingOverflowsAtPhoneWidthWithBrowserFonts(string path)
    {
        var page = await browser.NewPageAsync(BrowserFixture.Phone, browserFonts: true);
        await page.GotoAsync(browser.Site.BaseUrl + path);

        await Expect(page.Locator("html")).ToHaveClassAsync(new System.Text.RegularExpressions.Regex("ss-browser-fonts"));
        await AssertNoHorizontalScrollAsync(page, $"{path} (browser fonts)");
    }

    [Fact]
    public async Task PreferencesPageSwitchesToBrowserFonts()
    {
        var page = await browser.NewPageAsync(BrowserFixture.Phone);
        await page.GotoAsync(browser.Site.BaseUrl + "/Preferenze");
        await Expect(page.Locator("html")).Not.ToHaveClassAsync(new System.Text.RegularExpressions.Regex("ss-browser-fonts"));

        await page.GetByLabel("Usa i caratteri predefiniti del browser").CheckAsync();
        await page.GetByRole(AriaRole.Button, new() { Name = "Salva" }).ClickAsync();

        await Expect(page.Locator("html")).ToHaveClassAsync(new System.Text.RegularExpressions.Regex("ss-browser-fonts"));
        await page.GotoAsync(browser.Site.BaseUrl + "/devlog");
        await Expect(page.Locator("html")).ToHaveClassAsync(new System.Text.RegularExpressions.Regex("ss-browser-fonts"));
        await page.Context.CloseAsync();
    }

    [Fact]
    public async Task PhoneMenuOpensAndReachesDevlogAndBenchmark()
    {
        var page = await browser.NewPageAsync(BrowserFixture.Phone);
        await page.GotoAsync(browser.Site.BaseUrl + "/");

        var devlog = page.Locator("nav.navbar").GetByRole(AriaRole.Link, new() { Name = "Devlog", Exact = true });
        await Expect(devlog).ToBeHiddenAsync();
        await page.Locator(".navbar-toggler").ClickAsync();
        await Expect(devlog).ToBeVisibleAsync();
        await Expect(page.Locator("nav.navbar").GetByRole(AriaRole.Link, new() { Name = "Benchmark", Exact = true })).ToBeVisibleAsync();
        await devlog.ClickAsync();
        await Expect(page).ToHaveURLAsync(browser.Site.BaseUrl + "/devlog");
    }

    [Fact]
    public async Task WideTablesScrollInsideTheirOwnBoxOnAPhone()
    {
        var page = await browser.NewPageAsync(BrowserFixture.Phone);
        await page.GotoAsync(browser.Site.BaseUrl + "/benchmark/m2");

        var wrap = page.Locator(".bench-table-wrap").First;
        var overflowX = await wrap.EvaluateAsync<string>("e => getComputedStyle(e).overflowX");
        Assert.Contains(overflowX, new[] { "auto", "scroll" });
        // The table is wider than its box, so it scrolls there.
        Assert.True(await wrap.EvaluateAsync<bool>("e => e.scrollWidth > e.clientWidth"));
    }

    private static async Task AssertNoHorizontalScrollAsync(IPage page, string what)
    {
        var (scroll, inner) = await page.EvaluateAsync<int[]>("[document.documentElement.scrollWidth, window.innerWidth]") is [var s, var i] ? (s, i) : (0, 0);
        Assert.True(scroll <= inner, $"{what}: page scrolls sideways ({scroll}px content in a {inner}px window)");
    }

    // Text must not be the colour of its own background (a hard-coded colour or a scheme leak would do that).
    private static async Task AssertTextIsReadableAsync(IPage page, string what)
    {
        var contrast = await page.EvaluateAsync<double>("""
            () => {
              const parse = c => c.match(/[\d.]+/g).map(Number);
              const lum = ([r, g, b]) => [r, g, b].map(v => { v /= 255; return v <= 0.03928 ? v / 12.92 : ((v + 0.055) / 1.055) ** 2.4; })
                .reduce((a, v, i) => a + v * [0.2126, 0.7152, 0.0722][i], 0);
              const bg = parse(getComputedStyle(document.body).backgroundColor);
              const fg = parse(getComputedStyle(document.querySelector('main') ?? document.body).color);
              const [a, b] = [lum(fg), lum(bg)].sort((x, y) => y - x);
              return (a + 0.05) / (b + 0.05);
            }
            """);
        Assert.True(contrast >= 4.5, $"{what}: body text contrast is {contrast:F1}:1, under 4.5:1");
    }
}
