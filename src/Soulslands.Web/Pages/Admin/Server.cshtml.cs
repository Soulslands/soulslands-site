using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Soulslands.Web.Data;
using Soulslands.Web.Services.Servers;

namespace Soulslands.Web.Pages.Admin;

// Moderation view of every community server: who registered it (the studio account id,
// to look up in the studio's admin pages), and a way to remove servers that break the rules.
public class ServerModel(ApplicationDbContext db) : PageModel
{
    public List<(ServerInfo Server, string? OwnerId)> Servers { get; private set; } = [];

    public async Task OnGetAsync()
    {
        var owners = await db.GameServers.AsNoTracking()
            .ToDictionaryAsync(s => s.Id, s => s.OwnerId);
        Servers = (await ServerStatus.ListAsync(db))
            .Select(s => (s, owners.GetValueOrDefault(s.Id)))
            .ToList();
    }

    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {
        await db.GameServers.Where(s => s.Id == id).ExecuteDeleteAsync();
        return RedirectToPage();
    }
}
