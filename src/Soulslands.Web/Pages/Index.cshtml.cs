using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Soulslands.Web.Data;
using Soulslands.Web.Services;
using Soulslands.Web.Services.Auth;
using Soulslands.Web.Services.Devlog;

namespace Soulslands.Web.Pages;

public class IndexModel(ApplicationDbContext db, DevlogStore devlog, IOptions<SiteOptions> site, IOptions<StudioOptions> studio) : PageModel
{
    public const int LatestPostCount = 3;

    // The studio's public list of this game's announcements (ADR-0024 section 11.5), read in the browser.
    // The studio writes them in English or Japanese (or for every language) and knows no Italian:
    // ?lang=en gives the English ones and those for every language, never the Japanese-only ones.
    public const string AnnouncementsPath = "/api/games/soulslands/announcements?lang=en";

    public bool Static => site.Value.Static;

    public string AnnouncementsUrl => studio.Value.Account(AnnouncementsPath);

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
        if (Static)
        {
            return;
        }
        Announcements = await db.Announcements.AsNoTracking()
            .OrderByDescending(a => a.CreatedAt)
            .Take(5)
            .ToListAsync();
    }
}
