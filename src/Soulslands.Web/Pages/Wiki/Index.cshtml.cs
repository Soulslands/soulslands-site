using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Soulslands.Web.Data;
using Soulslands.Web.Services;

namespace Soulslands.Web.Pages.Wiki;

public class IndexModel(ApplicationDbContext db, IOptions<SiteOptions> site) : PageModel
{
    // Written by the static export next to the page: slug, title, category and a plain-text cut of
    // every public page (Soulslands.StaticExport.SearchIndex).
    public const string SearchIndexUrl = "/wiki/indice-ricerca.json";

    public bool Static => site.Value.Static;

    public List<WikiPage> Pages { get; private set; } = [];

    public List<WikiNavigation.Section> Sections { get; private set; } = [];

    public string? Query { get; private set; }

    public bool CanEdit { get; private set; }

    public async Task OnGetAsync(string? q)
    {
        Query = q?.Trim();
        CanEdit = WikiAccess.CanEdit(User);

        var pages = db.WikiPages.AsNoTracking().VisibleTo(User);
        if (!string.IsNullOrEmpty(Query))
        {
            // LIKE ignores case on SQLite but not on PostgreSQL: compare lower-cased.
            var needle = Query.ToLower();
            pages = pages.Where(p => p.Title.ToLower().Contains(needle) || p.Content.ToLower().Contains(needle));
        }

        Pages = await pages.ToListAsync();
        Sections = WikiNavigation.Build(Pages);
    }
}
