using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;

namespace Soulslands.StaticExport;

// The real Soulslands.Web app in memory (no socket), as an anonymous visitor, reading its wiki,
// devlog and benchmark results from the given WikiContent/ folder.
internal sealed class ExportHost(string wikiDirectory, string baseUrl, Action<IWebHostBuilder>? configure = null)
    : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        // Production: no developer pages and no settings of the machine that builds.
        builder.UseEnvironment("Production");
        // The app's own folder (wwwroot, Pages), found from the build output upwards: also right
        // when the exporter runs from the test projects.
        builder.UseSolutionRelativeContentRoot(Path.Combine("src", "Soulslands.Web"), AppContext.BaseDirectory, "Soulslands.slnx");
        builder.UseStaticWebAssets();
        builder.UseSetting("Site:BaseUrl", baseUrl);
        builder.UseSetting("Wiki:Directory", wikiDirectory);
        builder.UseSetting("Devlog:Directory", Path.Combine(wikiDirectory, "devlog"));
        builder.UseSetting("Benchmark:Directory", Path.Combine(wikiDirectory, "benchmark"));
        // Warnings only (invalid wiki pages, devlog and benchmark files): appsettings.json asks Information.
        builder.UseSetting("Logging:LogLevel:Default", "Warning");
        builder.UseSetting("Logging:LogLevel:Microsoft.AspNetCore", "Warning");
        builder.UseSetting("Logging:LogLevel:Microsoft.Hosting.Lifetime", "Warning");
        configure?.Invoke(builder);
    }
}
