namespace Soulslands.StaticExport;

public sealed record ExportOptions
{
    public const string DefaultBaseUrl = "https://soulslands.mahoroba.studio";

    // Emptied and written by the export; refused when it holds files of something else.
    public required string OutputDirectory { get; init; }

    // The WikiContent/ folder the site is built from (wiki pages, devlog/, benchmark/); default the
    // repository's src/Soulslands.Web/WikiContent, found from the current folder upwards.
    public string? WikiDirectory { get; init; }

    // Public address of the site: the feed's absolute links (Site:BaseUrl).
    public string BaseUrl { get; init; } = DefaultBaseUrl;

    // Tests only: changes the hosted app, e.g. to make it misbehave and see the export refuse it.
    public Action<Microsoft.AspNetCore.Hosting.IWebHostBuilder>? ConfigureWebHost { get; init; }
}
