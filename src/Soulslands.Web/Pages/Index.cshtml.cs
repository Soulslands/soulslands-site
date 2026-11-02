using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Soulslands.Web.Data;
using Soulslands.Web.Services.Devlog;

namespace Soulslands.Web.Pages;

public class IndexModel(ApplicationDbContext db, DevlogStore devlog) : PageModel
{
    public const int LatestPostCount = 3;

    public List<Announcement> Announcements { get; private set; } = [];

    // Newest devlog posts; the block is hidden when there are none.
    public IReadOnlyList<DevlogPost> LatestPosts { get; private set; } = [];

    public static readonly (string Title, string Text)[] Features =
    [
        ("Mondi senza confini", "Ogni mondo è a voxel, generato proceduralmente e modificabile blocco per blocco. Server dedicato gratuito: ospita il tuo."),
        ("Skill fino a 100.0", "Ogni skill cresce usandola. Spada, magia, artigianato, furto: diventi ciò che fai."),
        ("Razze e classi", "Ogni razza ha statistiche diverse. Forza, Destrezza e Intelligenza decidono vita, stamina e mana."),
        ("Gilde e guerre", "Party, gilde, alleanze, conquista di territori e guerre aperte tra gilde."),
        ("Full loot e PK", "Chi uccide altri giocatori diventa rosso. Solo un chierico può purificarne l'anima."),
        ("Completamente moddabile", "Server dedicati e un sistema di mod allo stesso livello di Minecraft."),
    ];

    public async Task OnGetAsync()
    {
        LatestPosts = [.. devlog.Posts.Take(LatestPostCount)];
        Announcements = await db.Announcements.AsNoTracking()
            .OrderByDescending(a => a.CreatedAt)
            .Take(5)
            .ToListAsync();
    }
}
