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

        var environment = services.GetRequiredService<IWebHostEnvironment>();
        var logger = services.GetRequiredService<ILoggerFactory>().CreateLogger(nameof(WikiContentImporter));
        await WikiContentImporter.ImportAsync(db, Path.Combine(environment.ContentRootPath, "WikiContent"), logger);
    }
}
