using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Soulslands.Web.Data;

namespace Soulslands.Web.Pages.Admin;

public class BachecaModel(ApplicationDbContext db) : PageModel
{
    [BindProperty]
    [Required(ErrorMessage = "Scrivi il testo dell'avviso.")]
    [StringLength(300)]
    public string Text { get; set; } = "";

    public List<Announcement> Items { get; private set; } = [];

    public async Task OnGetAsync()
    {
        await LoadAsync();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            await LoadAsync();
            return Page();
        }

        db.Announcements.Add(new Announcement { Text = Text.Trim() });
        await db.SaveChangesAsync();
        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {
        await db.Announcements.Where(a => a.Id == id).ExecuteDeleteAsync();
        return RedirectToPage();
    }

    private async Task LoadAsync()
    {
        Items = await db.Announcements.AsNoTracking().OrderByDescending(a => a.CreatedAt).ToListAsync();
    }
}
