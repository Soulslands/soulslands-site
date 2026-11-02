using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Soulslands.Web.E2E;

// The real site on Kestrel and a free port, so a browser can reach it (TestServer has no socket).
// Posts and benchmark results come from the fixtures next to the test assembly, never from WikiContent/.
// Sign-in goes through the studio and is covered by the unit tests (StudioSignInTests).
public sealed class E2eSite : WebApplicationFactory<Program>
{
    private readonly string _dbPath = Path.Combine(Path.GetTempPath(), $"soulslands-e2e-{Guid.NewGuid():N}.db");

    public E2eSite()
    {
        UseKestrel(0);
        StartServer();
    }

    public static string Fixtures => Path.Combine(AppContext.BaseDirectory, "Fixtures");

    public string BaseUrl => Services.GetRequiredService<IServer>().Features.Get<IServerAddressesFeature>()!
        .Addresses.First().Replace("[::]", "localhost").Replace("0.0.0.0", "localhost");

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseSetting("ConnectionStrings:DefaultConnection", $"DataSource={_dbPath}");
        builder.UseSetting("Devlog:Directory", Path.Combine(Fixtures, "Devlog"));
        builder.UseSetting("Benchmark:Directory", Path.Combine(Fixtures, "Benchmark"));
        builder.UseSetting("Studio:AccountUrl", "https://account.studio.test");
        builder.UseSetting("Studio:StudioUrl", "https://studio.test");
        builder.ConfigureLogging(l => l.SetMinimumLevel(LogLevel.Warning));
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
        Microsoft.Data.Sqlite.SqliteConnection.ClearAllPools();
        File.Delete(_dbPath);
    }
}
