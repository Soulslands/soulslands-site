using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Soulslands.Web.Pages;

public class StatusCodeModel : PageModel
{
    public int Code { get; private set; }

    public void OnGet(int code)
    {
        Code = code;
    }
}
