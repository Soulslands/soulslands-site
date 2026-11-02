using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Soulslands.Web.Data;
using Soulslands.Web.Services;
using Soulslands.Web.Services.Auth;

namespace Soulslands.Web.Pages.Wiki;

public class ViewModel(ApplicationDbContext db) : PageModel
{
    public WikiPage WikiPage { get; private set; } = null!;

    public string Html { get; private set; } = "";

    public bool CanEdit { get; private set; }

    // Most pages open with their own "# Title" line; then the header doesn't repeat it.
    public bool HasOwnTitle { get; private set; }

    // The diagram library is large, so pages without diagrams don't load it.
    public bool HasDiagrams { get; private set; }

    public List<WikiNavigation.Section> Sections { get; private set; } = [];

    public async Task<IActionResult> OnGetAsync(string slug)
    {
        var page = await db.WikiPages.AsNoTracking().FirstOrDefaultAsync(p => p.Slug == slug);

        // Staff pages answer 404, not 403, so players cannot tell they exist.
        if (page is null || !WikiAccess.CanRead(User, page.Visibility))
        {
            return StudioSignIn.NotVisible(this);
        }

        WikiPage = page;
        Html = MarkdownRenderer.ToHtml(page.Content);
        HasOwnTitle = page.Content.TrimStart().StartsWith("# ");
        HasDiagrams = MarkdownRenderer.HasDiagrams(Html);
        CanEdit = WikiAccess.CanEdit(User);

        // Only titles are needed for the sidebar.
        var pages = await db.WikiPages.AsNoTracking().VisibleTo(User)
            .Select(p => new WikiPage { Slug = p.Slug, Title = p.Title, Category = p.Category, Visibility = p.Visibility, Content = "" })
            .ToListAsync();
        Sections = WikiNavigation.Build(pages);
        return Page();
    }
}
