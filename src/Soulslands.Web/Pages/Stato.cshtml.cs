using Microsoft.AspNetCore.Mvc.RazorPages;
using Soulslands.Web.Data;
using Soulslands.Web.Services.Servers;

namespace Soulslands.Web.Pages;

public class StatoModel(ApplicationDbContext db) : PageModel
{
    public enum Phase
    {
        Completata,
        InCorso,
        Prevista,
    }

    public record RoadmapItem(Phase Status, string Title, string Description);

    public static readonly (string Name, int Percent)[] Progress =
    [
        ("Sito e wiki", 80),
        ("Engine e mondo", 0),
        ("Server dedicato", 0),
        ("Client", 0),
    ];

    public static readonly RoadmapItem[] Roadmap =
    [
        new(Phase.Completata, "Ideazione del progetto", "Visione del gioco: Ultima Online in un mondo a voxel generato e modificabile."),
        new(Phase.InCorso, "Sito web e wiki", "Account, acquisto, key regalo e wiki completa con tutto il mondo di Soulslands."),
        new(Phase.InCorso, "Documento di design", "Tutte le regole di gioco raccolte in un unico documento per lo sviluppo."),
        new(Phase.Prevista, "Engine voxel e generazione del mondo", "Chunk, biomi, oceani, grotte e salvataggio del mondo."),
        new(Phase.Prevista, "Server dedicato e rete", "Server dedicato gratuito per tutti: ogni mondo regge moltissimi giocatori insieme."),
        new(Phase.Prevista, "Client e grafica", "Visuale isometrica e in prima persona, grafica leggera, campo visivo."),
        new(Phase.Prevista, "Sistemi di Ultima Online", "Skill fino a 100.0, combattimento, crafting, karma, gilde e guerre."),
        new(Phase.Prevista, "Alpha chiusa", "I primi giocatori entrano nel mondo."),
    ];

    public static string Label(Phase phase) => phase switch
    {
        Phase.Completata => "Completata",
        Phase.InCorso => "In corso",
        _ => "Prevista",
    };

    public List<ServerInfo> Servers { get; private set; } = [];

    public int PlayersOnline => Servers.Sum(s => s.PlayersOnline);

    public bool AnyOnline => Servers.Any(s => s.Online);

    public async Task OnGetAsync()
    {
        Servers = await ServerStatus.ListAsync(db);
    }
}
