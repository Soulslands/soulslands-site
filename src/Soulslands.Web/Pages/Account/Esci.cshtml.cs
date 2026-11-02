using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Soulslands.Web.Services.Auth;

namespace Soulslands.Web.Pages.Account;

// Signs out of this site and of the studio: the studio gets id_token_hint and client_id,
// so it signs out at once and comes back to /signout-callback-oidc, then home.
public class EsciModel : PageModel
{
    public IActionResult OnPost()
    {
        if (User.Identity?.IsAuthenticated != true)
        {
            return LocalRedirect("/");
        }
        return SignOut(new AuthenticationProperties { RedirectUri = "/" }, StudioSignIn.CookieScheme, StudioSignIn.StudioScheme);
    }
}
