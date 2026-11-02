using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Soulslands.Web.Data;
using Soulslands.Web.Services;
using Soulslands.Web.Services.Auth;

namespace Soulslands.Web.Pages.Wiki;

[Authorize(Roles = Roles.WikiEditorsCsv)]
public class EditModel(ApplicationDbContext db) : PageModel
{
    [BindProperty]
    public InputModel Input { get; set; } = new();

    public bool IsNew { get; private set; }

    public class InputModel
    {
        [Required(ErrorMessage = "Il titolo è obbligatorio.")]
        [StringLength(200)]
        public string Title { get; set; } = "";

        [Required(ErrorMessage = "Lo slug è obbligatorio.")]
        [StringLength(100)]
        public string Slug { get; set; } = "";

        [StringLength(100)]
        public string? Category { get; set; }

        [Required(ErrorMessage = "Il contenuto è obbligatorio.")]
        public string Content { get; set; } = "";

        public WikiVisibility Visibility { get; set; } = WikiVisibility.Pubblica;
    }

    public async Task<IActionResult> OnGetAsync(string? slug)
    {
        if (slug is null)
        {
            IsNew = true;
            return Page();
        }

        var page = await db.WikiPages.AsNoTracking().FirstOrDefaultAsync(p => p.Slug == slug);
        if (page is null)
        {
            return NotFound();
        }

        Input = new InputModel
        {
            Title = page.Title,
            Slug = page.Slug,
            Category = page.Category,
            Content = page.Content,
            Visibility = page.Visibility,
        };
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(string? slug)
    {
        IsNew = slug is null;
        if (!IsNew)
        {
            Input.Slug = slug!;
        }

        if (!WikiAccess.IsValidSlug(Input.Slug))
        {
            ModelState.AddModelError("Input.Slug", "Usa solo lettere minuscole, numeri e trattini.");
        }

        if (!ModelState.IsValid)
        {
            return Page();
        }

        WikiPage? page;
        if (IsNew)
        {
            if (await db.WikiPages.AnyAsync(p => p.Slug == Input.Slug))
            {
                ModelState.AddModelError("Input.Slug", "Esiste già una pagina con questo slug.");
                return Page();
            }

            page = new WikiPage { Slug = Input.Slug, Title = Input.Title, Content = Input.Content };
            db.WikiPages.Add(page);
        }
        else
        {
            page = await db.WikiPages.FirstOrDefaultAsync(p => p.Slug == slug);
            if (page is null)
            {
                return NotFound();
            }
        }

        var author = StudioSignIn.SubjectId(User);
        var authorName = User.Identity?.Name;
        page.Title = Input.Title;
        page.Category = string.IsNullOrWhiteSpace(Input.Category) ? null : Input.Category.Trim();
        page.Content = Input.Content;
        page.Visibility = Input.Visibility;
        page.UpdatedAt = DateTime.UtcNow;
        page.UpdatedBy = author;
        page.UpdatedByName = authorName;
        page.Revisions.Add(new WikiRevision
        {
            Title = Input.Title,
            Content = Input.Content,
            Visibility = Input.Visibility,
            Author = author,
            AuthorName = authorName,
        });

        await db.SaveChangesAsync();
        return RedirectToPage("/Wiki/View", new { slug = page.Slug });
    }
}
