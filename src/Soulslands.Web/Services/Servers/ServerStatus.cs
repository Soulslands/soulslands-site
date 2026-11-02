using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Soulslands.Web.Data;

namespace Soulslands.Web.Services.Servers;

public record HeartbeatRequest(int PlayersOnline, int MaxPlayers, string? Version);

public record ServerInfo(int Id, string Name, string Address, bool Online, int PlayersOnline, int MaxPlayers, string? Version);

// Game servers report in every ~30 seconds; one that has been silent for
// longer than OfflineAfter shows as offline.
public static class ServerStatus
{
    public static readonly TimeSpan OfflineAfter = TimeSpan.FromSeconds(90);

    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/servers/heartbeat", HeartbeatAsync);
        app.MapGet("/api/servers", async ([FromServices] ApplicationDbContext db) => Results.Ok(await ListAsync(db)));
    }

    // Online servers first, busiest first. ownerId limits the list to one account's servers.
    public static async Task<List<ServerInfo>> ListAsync(ApplicationDbContext db, string? ownerId = null)
    {
        var query = db.GameServers.AsNoTracking();
        if (ownerId is not null)
        {
            query = query.Where(s => s.OwnerId == ownerId);
        }
        var servers = await query.ToListAsync();
        var now = DateTime.UtcNow;
        return servers
            .Select(s =>
            {
                var online = s.LastHeartbeatAt is { } last && now - last < OfflineAfter;
                return new ServerInfo(s.Id, s.Name, s.Address, online, online ? s.PlayersOnline : 0, s.MaxPlayers, s.Version);
            })
            .OrderByDescending(s => s.Online)
            .ThenByDescending(s => s.PlayersOnline)
            .ThenBy(s => s.Name, StringComparer.OrdinalIgnoreCase)
            .ToList();
    }

    // Authorization: Server <api key>
    private static async Task<IResult> HeartbeatAsync(HttpRequest request, [FromBody] HeartbeatRequest body, [FromServices] ApplicationDbContext db)
    {
        var header = request.Headers.Authorization.ToString();
        if (!header.StartsWith("Server ", StringComparison.Ordinal))
        {
            return Results.Unauthorized();
        }

        var hash = HashKey(header[7..].Trim());
        var now = DateTime.UtcNow;
        var players = Math.Max(0, body.PlayersOnline);
        var max = Math.Max(0, body.MaxPlayers);
        var version = body.Version is { Length: > 40 } v ? v[..40] : body.Version;
        var updated = await db.GameServers
            .Where(s => s.ApiKeyHash == hash)
            .ExecuteUpdateAsync(s => s
                .SetProperty(x => x.LastHeartbeatAt, now)
                .SetProperty(x => x.PlayersOnline, players)
                .SetProperty(x => x.MaxPlayers, max)
                .SetProperty(x => x.Version, version));
        return updated == 0 ? Results.Unauthorized() : Results.NoContent();
    }

    public static string NewApiKey() =>
        "ssk_" + Convert.ToHexStringLower(RandomNumberGenerator.GetBytes(24));

    public static string HashKey(string key) =>
        Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes(key)));
}
