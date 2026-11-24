using Microsoft.AspNetCore.Mvc.RazorPages;
using Soulslands.Web.Services;

namespace Soulslands.Web.Pages;

// Shows the "regolamento" wiki page, so the rules are written like any wiki page.
public class RegoleModel(WikiStore wiki) : PageModel
{
    public const string Slug = "regolamento";

    public string? Html { get; private set; }

    public void OnGet()
    {
        Html = wiki.Find(Slug) is { } page ? MarkdownRenderer.ToHtml(page.Content) : null;
    }
}
