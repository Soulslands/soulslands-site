using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Soulslands.Web.Data;
using Soulslands.Web.Services;

namespace Soulslands.Web.Pages;

// Shows the "regolamento" wiki page, so the rules are edited like any wiki page.
public class RegoleModel(ApplicationDbContext db) : PageModel
{
    public const string Slug = "regolamento";

    public string? Html { get; private set; }

    public async Task OnGetAsync()
    {
        var page = await db.WikiPages.AsNoTracking()
            .FirstOrDefaultAsync(p => p.Slug == Slug && p.Visibility == WikiVisibility.Pubblica);
        Html = page is null ? null : MarkdownRenderer.ToHtml(page.Content);
    }
}
