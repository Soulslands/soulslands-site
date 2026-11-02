using Microsoft.EntityFrameworkCore;
using Soulslands.Web.Data;

namespace Soulslands.Web.Services;

// Loads the wiki pages kept as Markdown files in WikiContent/ into the database.
// Pages edited on the site by a person are never overwritten: only pages still
// owned by the importer ("sistema") are updated when their file changes.
public static class WikiContentImporter
{
    public const string SystemAuthor = "sistema";

    public const string DevlogFolder = "devlog";

    public record ParsedPage(string Slug, string Title, string? Category, WikiVisibility Visibility, string Content);

    public static async Task ImportAsync(ApplicationDbContext db, string directory, ILogger logger)
    {
        if (!Directory.Exists(directory))
        {
            logger.LogWarning("Cartella wiki {Directory} non trovata", directory);
            return;
        }

        var pages = new Dictionary<string, ParsedPage>();
        foreach (var file in Directory.EnumerateFiles(directory, "*.md", SearchOption.AllDirectories).Order())
        {
            if (IsDevlogFile(directory, file))
            {
                continue;
            }

            var parsed = Parse(await File.ReadAllTextAsync(file));
            if (parsed is null || !WikiAccess.IsValidSlug(parsed.Slug))
            {
                logger.LogWarning("Pagina wiki non valida, ignorata: {File}", file);
                continue;
            }

            if (!pages.TryAdd(parsed.Slug, parsed))
            {
                logger.LogWarning("Slug wiki duplicato {Slug} in {File}, ignorato", parsed.Slug, file);
            }
        }

        var existing = await db.WikiPages.ToDictionaryAsync(p => p.Slug);
        var changed = 0;
        foreach (var page in pages.Values)
        {
            if (!existing.TryGetValue(page.Slug, out var entity))
            {
                entity = new WikiPage { Slug = page.Slug, Title = page.Title, Content = page.Content };
                db.WikiPages.Add(entity);
            }
            else if (entity.UpdatedBy != SystemAuthor || Matches(entity, page))
            {
                continue;
            }

            entity.Title = page.Title;
            entity.Category = page.Category;
            entity.Content = page.Content;
            entity.Visibility = page.Visibility;
            entity.UpdatedAt = DateTime.UtcNow;
            entity.UpdatedBy = SystemAuthor;
            entity.Revisions.Add(new WikiRevision
            {
                Title = page.Title,
                Content = page.Content,
                Visibility = page.Visibility,
                Author = SystemAuthor,
            });
            changed++;
        }

        await db.SaveChangesAsync();
        logger.LogInformation("Wiki: {Files} file letti, {Changed} pagine create o aggiornate", pages.Count, changed);
    }

    private static bool Matches(WikiPage entity, ParsedPage page) =>
        entity.Title == page.Title
        && entity.Category == page.Category
        && entity.Content == page.Content
        && entity.Visibility == page.Visibility;

    public static ParsedPage? Parse(string text)
    {
        var document = FrontMatter.Parse(text);
        if (document is null
            || !document.Fields.TryGetValue("slug", out var slug)
            || !document.Fields.TryGetValue("title", out var title)
            || string.IsNullOrWhiteSpace(title))
        {
            return null;
        }

        var visibility = document.Fields.TryGetValue("visibility", out var v)
            && v.Equals("Staff", StringComparison.OrdinalIgnoreCase)
                ? WikiVisibility.Staff
                : WikiVisibility.Pubblica;
        document.Fields.TryGetValue("category", out var category);

        return new ParsedPage(slug, title, string.IsNullOrWhiteSpace(category) ? null : category, visibility, document.Body);
    }

    // Devlog posts live in WikiContent/devlog/ next to the wiki pages but are not
    // wiki pages: DevlogStore reads them. Exact lowercase match, like the path
    // DevlogStore opens, so a file is never skipped here and missed there.
    private static bool IsDevlogFile(string directory, string file)
    {
        var relative = Path.GetRelativePath(directory, file);
        var first = relative.Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar)[0];
        return relative != first && first == DevlogFolder;
    }
}
