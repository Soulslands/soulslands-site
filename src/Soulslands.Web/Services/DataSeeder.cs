using Microsoft.EntityFrameworkCore;
using Soulslands.Web.Data;

namespace Soulslands.Web.Services;

// Runs at startup: migrations, then the wiki pages from WikiContent/. Accounts and roles
// live in the studio (SoulslandsGame ADR-0024), so nothing else is seeded.
public static class DataSeeder
{
    public static async Task SeedAsync(IServiceProvider services)
    {
        var db = services.GetRequiredService<ApplicationDbContext>();
        await db.Database.MigrateAsync();

        var logger = services.GetRequiredService<ILoggerFactory>().CreateLogger(nameof(WikiContentImporter));
        await WikiContentImporter.ImportAsync(db, WikiDirectory(services), logger);
    }

    // WikiContent/ next to the app, or Wiki:Directory (the static export builds from a fixture
    // folder in its tests).
    public static string WikiDirectory(IServiceProvider services)
    {
        var configured = services.GetRequiredService<IConfiguration>()["Wiki:Directory"];
        return string.IsNullOrWhiteSpace(configured)
            ? Path.Combine(services.GetRequiredService<IWebHostEnvironment>().ContentRootPath, "WikiContent")
            : configured;
    }
}
