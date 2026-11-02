using Microsoft.Playwright;

namespace Soulslands.Web.E2E;

// One headless Chromium and one site for the whole run.
public sealed class BrowserFixture : IAsyncLifetime
{
    public static readonly (string Name, int Width, int Height) Phone = ("phone", 390, 844);
    public static readonly (string Name, int Width, int Height) Desktop = ("desktop", 1280, 800);

    private IPlaywright _playwright = null!;
    public IBrowser Browser { get; private set; } = null!;
    public E2eSite Site { get; } = new();

    public async Task InitializeAsync()
    {
        _playwright = await Playwright.CreateAsync();
        Browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
    }

    public async Task DisposeAsync()
    {
        await Browser.DisposeAsync();
        _playwright.Dispose();
        Site.Dispose();
    }

    // A fresh browser context (own cookies) at the given size and colour scheme. With browserFonts the
    // visitor has chosen the browser's fonts on /Preferenze (a cookie of this site).
    public async Task<IPage> NewPageAsync(
        (string Name, int Width, int Height)? size = null,
        ColorScheme scheme = ColorScheme.Dark,
        bool browserFonts = false)
    {
        var (_, width, height) = size ?? Desktop;
        var context = await Browser.NewContextAsync(new BrowserNewContextOptions
        {
            ViewportSize = new ViewportSize { Width = width, Height = height },
            ColorScheme = scheme,
        });
        if (browserFonts)
        {
            await context.AddCookiesAsync([new Cookie { Name = "ss-fonts", Value = "browser", Url = Site.BaseUrl }]);
        }
        context.SetDefaultTimeout(10_000);
        return await context.NewPageAsync();
    }
}

[CollectionDefinition(Name)]
public sealed class BrowserCollection : ICollectionFixture<BrowserFixture>
{
    public const string Name = "browser";
}
