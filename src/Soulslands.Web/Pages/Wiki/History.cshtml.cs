using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Soulslands.Web.Data;
using Soulslands.Web.Services;
using Soulslands.Web.Services.Auth;

namespace Soulslands.Web.Pages.Wiki;

public class HistoryModel(ApplicationDbContext db) : PageModel
{
    public WikiPage WikiPage { get; private set; } = null!;

    public List<WikiRevision> Revisions { get; private set; } = [];

    public async Task<IActionResult> OnGetAsync(string slug)
    {
        var page = await db.WikiPages.AsNoTracking().FirstOrDefaultAsync(p => p.Slug == slug);
        if (page is null || !WikiAccess.CanRead(User, page.Visibility))
        {
            return StudioSignIn.NotVisible(this);
        }

        // A page that was once Staff keeps those revisions hidden from players.
        var revisions = db.WikiRevisions.AsNoTracking().Where(r => r.WikiPageId == page.Id);
        if (!WikiAccess.IsStaff(User))
        {
            revisions = revisions.Where(r => r.Visibility == WikiVisibility.Pubblica);
        }

        WikiPage = page;
        Revisions = await revisions.OrderByDescending(r => r.CreatedAt).ToListAsync();
        return Page();
    }
}
