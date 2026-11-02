using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Soulslands.Web.Services.Auth;

namespace Soulslands.Web.Pages.Account;

// "Accedi" sends the browser to the studio's sign-in; after it, back to returnUrl (local only).
// With ?errore=1 (a failed callback) it shows a message instead; in LAN mode
// (StudioSignIn.IsReadOnly) it says the site is read-only.
public class AccediModel : PageModel
{
    public bool ReadOnly { get; private set; }

    public IActionResult OnGet(string? returnUrl, int? errore)
    {
        var target = Url.IsLocalUrl(returnUrl) ? returnUrl : "/";
        ReadOnly = StudioSignIn.IsReadOnly(Request);
        if (errore is not null || ReadOnly)
        {
            return Page();
        }
        if (User.Identity?.IsAuthenticated == true)
        {
            return LocalRedirect(target);
        }
        return Challenge(new AuthenticationProperties { RedirectUri = target }, StudioSignIn.StudioScheme);
    }
}
