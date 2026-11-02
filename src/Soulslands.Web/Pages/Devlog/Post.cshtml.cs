using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Soulslands.Web.Services.Devlog;

namespace Soulslands.Web.Pages.Devlog;

public class PostModel(DevlogStore store) : PageModel
{
    public DevlogPost Post { get; private set; } = null!;

    // Posts may open with their own "# Title" line; then the header doesn't repeat it.
    public bool HasOwnTitle { get; private set; }

    public IActionResult OnGet(string slug)
    {
        if (store.Find(slug) is not { } post)
        {
            return NotFound();
        }

        Post = post;
        HasOwnTitle = post.Content.TrimStart().StartsWith("# ");
        return Page();
    }
}
