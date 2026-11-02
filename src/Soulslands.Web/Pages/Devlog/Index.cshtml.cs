using Microsoft.AspNetCore.Mvc.RazorPages;
using Soulslands.Web.Services.Devlog;

namespace Soulslands.Web.Pages.Devlog;

public class IndexModel(DevlogStore store) : PageModel
{
    public IReadOnlyList<DevlogPost> Posts { get; private set; } = [];

    public void OnGet() => Posts = store.Posts;
}
