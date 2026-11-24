using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Soulslands.Web.Services;

namespace Soulslands.Web.Pages.Wiki;

public class ViewModel(WikiStore wiki) : PageModel
{
    public WikiPage WikiPage { get; private set; } = null!;

    public string Html { get; private set; } = "";

    // Most pages open with their own "# Title" line; then the header doesn't repeat it.
    public bool HasOwnTitle { get; private set; }

    // The diagram library is large, so pages without diagrams don't load it.
    public bool HasDiagrams { get; private set; }

    public List<WikiNavigation.Section> Sections { get; private set; } = [];

    public IActionResult OnGet(string slug)
    {
        if (wiki.Find(slug) is not { } page)
        {
            return NotFound();
        }

        WikiPage = page;
        Html = MarkdownRenderer.ToHtml(page.Content);
        HasOwnTitle = page.Content.TrimStart().StartsWith("# ");
        HasDiagrams = MarkdownRenderer.HasDiagrams(Html);
        Sections = WikiNavigation.Build(wiki.Pages);
        return Page();
    }
}
