using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Soulslands.Web.Data;
using Soulslands.Web.Services.Auth;
using Soulslands.Web.Services.Servers;

namespace Soulslands.Web.Pages.Server;

// Anyone with a studio account, paid or not, can register the servers they host.
[Authorize]
public class IndexModel(ApplicationDbContext db) : PageModel
{
    public const int MaxServersPerAccount = 5;

    public List<ServerInfo> Servers { get; private set; } = [];

    [BindProperty, Required, MaxLength(60)]
    public string Name { get; set; } = "";

    [BindProperty, Required, MaxLength(255)]
    [RegularExpression(@"^[A-Za-z0-9.\-]+:\d{1,5}$", ErrorMessage = "Scrivi l'indirizzo come host:porta, per esempio play.miomondo.it:7777.")]
    public string Address { get; set; } = "";

    [TempData]
    public string? Error { get; set; }

    // The studio id: the cookie comes only from a validated id token, which always has a sub.
    private string OwnerId => StudioSignIn.SubjectId(User)!;

    // Shown once, right after it is created; only its hash is stored.
    [TempData]
    public string? NewKey { get; set; }

    [TempData]
    public string? NewKeyServer { get; set; }

    public async Task OnGetAsync()
    {
        Servers = await ServerStatus.ListAsync(db, OwnerId);
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            Servers = await ServerStatus.ListAsync(db, OwnerId);
            return Page();
        }
        if (await db.GameServers.CountAsync(s => s.OwnerId == OwnerId) >= MaxServersPerAccount)
        {
            Error = $"Puoi registrare al massimo {MaxServersPerAccount} server.";
            return RedirectToPage();
        }

        var key = ServerStatus.NewApiKey();
        db.GameServers.Add(new GameServer { OwnerId = OwnerId, Name = Name.Trim(), Address = Address.Trim(), ApiKeyHash = ServerStatus.HashKey(key) });
        await db.SaveChangesAsync();
        NewKey = key;
        NewKeyServer = Name.Trim();
        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostNewKeyAsync(int id)
    {
        var server = await db.GameServers.SingleOrDefaultAsync(s => s.Id == id && s.OwnerId == OwnerId);
        if (server is null)
        {
            return NotFound();
        }

        var key = ServerStatus.NewApiKey();
        server.ApiKeyHash = ServerStatus.HashKey(key);
        await db.SaveChangesAsync();
        NewKey = key;
        NewKeyServer = server.Name;
        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {
        await db.GameServers.Where(s => s.Id == id && s.OwnerId == OwnerId).ExecuteDeleteAsync();
        return RedirectToPage();
    }
}
