using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Soulslands.Web.Pages;

// The font switch (Cursed Souls or the browser's). Accounts live in the studio now, so the
// choice is kept in a cookie of this site for this browser, signed in or not.
public class PreferenzeModel : PageModel
{
    public const string FontsCookie = "ss-fonts";
    public const string BrowserFonts = "browser";

    [BindProperty]
    public bool UseBrowserFonts { get; set; }

    public static bool WantsBrowserFonts(HttpRequest request) => request.Cookies[FontsCookie] == BrowserFonts;

    public void OnGet()
    {
        UseBrowserFonts = WantsBrowserFonts(Request);
    }

    public IActionResult OnPost()
    {
        if (UseBrowserFonts)
        {
            Response.Cookies.Append(FontsCookie, BrowserFonts, new CookieOptions
            {
                Path = "/", HttpOnly = true, SameSite = SameSiteMode.Lax, IsEssential = true,
                Secure = Request.IsHttps, MaxAge = TimeSpan.FromDays(365),
            });
        }
        else
        {
            Response.Cookies.Delete(FontsCookie, new CookieOptions { Path = "/" });
        }
        return RedirectToPage();
    }
}
