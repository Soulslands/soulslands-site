using Microsoft.AspNetCore.Mvc.RazorPages;
using Soulslands.Web.Services;

namespace Soulslands.Web.Pages.Wiki;

public class IndexModel(WikiStore wiki) : PageModel
{
    public IReadOnlyList<WikiPage> Pages => wiki.Pages;

    public List<WikiNavigation.Section> Sections { get; private set; } = [];

    public void OnGet()
    {
        Sections = WikiNavigation.Build(Pages);
    }
}
