using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;

namespace Soulslands.StaticExport;

// The real Soulslands.Web app in memory, as an anonymous visitor, in static mode (Site:Static): its
// own throwaway SQLite file holds the wiki pages imported from WikiContent/ at startup.
internal sealed class ExportHost(string databasePath, string wikiDirectory, string baseUrl, Action<IWebHostBuilder>? configure = null)
    : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        // Production: no developer pages and no user secrets of the machine that builds.
        builder.UseEnvironment("Production");
        // The app's own folder (wwwroot, Pages), found from the build output upwards: also right
        // when the exporter runs from the test projects.
        builder.UseSolutionRelativeContentRoot(Path.Combine("src", "Soulslands.Web"), AppContext.BaseDirectory, "Soulslands.slnx");
        builder.UseStaticWebAssets();
        builder.UseSetting("Site:Static", "true");
        builder.UseSetting("Site:BaseUrl", baseUrl);
        builder.UseSetting("ConnectionStrings:DefaultConnection", $"DataSource={databasePath}");
        builder.UseSetting("Wiki:Directory", wikiDirectory);
        builder.UseSetting("Devlog:Directory", Path.Combine(wikiDirectory, "devlog"));
        builder.UseSetting("Benchmark:Directory", Path.Combine(wikiDirectory, "benchmark"));
        // Warnings only (invalid wiki pages, devlog and benchmark files): appsettings.json asks Information.
        builder.UseSetting("Logging:LogLevel:Default", "Warning");
        builder.UseSetting("Logging:LogLevel:Microsoft.AspNetCore", "Warning");
        builder.UseSetting("Logging:LogLevel:Microsoft.EntityFrameworkCore", "Warning");
        builder.UseSetting("Logging:LogLevel:Microsoft.Hosting.Lifetime", "Warning");
        // The key ring of the throwaway database: nothing is protected during an export.
        builder.UseSetting("Logging:LogLevel:Microsoft.AspNetCore.DataProtection", "Error");
        configure?.Invoke(builder);
    }
}
