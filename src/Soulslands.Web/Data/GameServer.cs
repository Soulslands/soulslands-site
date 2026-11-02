using System.ComponentModel.DataAnnotations;

namespace Soulslands.Web.Data;

// A community game server listed on the Stato page and in the launcher.
// Anyone with a studio account can host and register one; Soulslands runs no
// official server. The server proves who it is with an API key (stored as a
// hash) when it reports in.
public class GameServer
{
    public int Id { get; set; }

    // The studio account ("sub" claim, a lowercase UUID) that registered the server and manages its key.
    [MaxLength(450)]
    public string OwnerId { get; set; } = "";

    [MaxLength(60)]
    public string Name { get; set; } = "";

    // host:port the launcher connects to.
    [MaxLength(255)]
    public string Address { get; set; } = "";

    [MaxLength(64)]
    public string ApiKeyHash { get; set; } = "";

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? LastHeartbeatAt { get; set; }

    public int PlayersOnline { get; set; }

    public int MaxPlayers { get; set; }

    [MaxLength(40)]
    public string? Version { get; set; }
}
