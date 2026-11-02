using System.Globalization;

namespace Soulslands.Web.Services.Devlog;

// Reads devlog posts: Markdown files with front matter in WikiContent/devlog/.
// Required fields: title, slug, date (YYYY-MM-DD), summary, author.
public static class DevlogLoader
{
    public static readonly string[] RequiredFields = ["title", "slug", "date", "summary", "author"];

    // Returns the valid posts newest first. Invalid files and duplicate slugs are
    // logged and skipped; a missing folder gives an empty list.
    public static IReadOnlyList<DevlogPost> Load(string directory, ILogger logger)
    {
        if (!Directory.Exists(directory))
        {
            logger.LogInformation("Cartella devlog {Directory} non trovata, nessun post", directory);
            return [];
        }

        List<string> files;
        try
        {
            files = [.. Directory.EnumerateFiles(directory, "*.md", SearchOption.AllDirectories).Order()];
        }
        catch (Exception e) when (e is IOException or UnauthorizedAccessException)
        {
            logger.LogError(e, "Cartella devlog {Directory} non leggibile, nessun post", directory);
            return [];
        }

        var posts = new Dictionary<string, DevlogPost>();
        foreach (var file in files)
        {
            // One unreadable file must not take the whole devlog down: the store
            // caches the result until restart.
            string text;
            try
            {
                text = File.ReadAllText(file);
            }
            catch (Exception e) when (e is IOException or UnauthorizedAccessException)
            {
                logger.LogWarning("Post devlog non leggibile, ignorato: {File} ({Error})", file, e.Message);
                continue;
            }

            var post = Parse(text, out var error);
            if (post is null)
            {
                logger.LogWarning("Post devlog non valido, ignorato: {File} ({Error})", file, error);
                continue;
            }

            if (!posts.TryAdd(post.Slug, post))
            {
                logger.LogWarning("Slug devlog duplicato {Slug} in {File}, ignorato", post.Slug, file);
            }
        }

        logger.LogInformation("Devlog: {Count} post caricati", posts.Count);
        return [.. posts.Values.OrderByDescending(p => p.Date).ThenBy(p => p.Slug, StringComparer.Ordinal)];
    }

    // Returns null and says why when a field is missing or invalid.
    public static DevlogPost? Parse(string text, out string? error)
    {
        var document = FrontMatter.Parse(text);
        if (document is null)
        {
            error = "front matter mancante o non chiuso";
            return null;
        }

        var missing = RequiredFields
            .Where(f => !document.Fields.TryGetValue(f, out var value) || string.IsNullOrWhiteSpace(value))
            .ToList();
        if (missing.Count > 0)
        {
            error = $"campi mancanti: {string.Join(", ", missing)}";
            return null;
        }

        var slug = document.Fields["slug"];
        if (!WikiAccess.IsValidSlug(slug))
        {
            error = $"slug non valido: {slug}";
            return null;
        }

        if (!DateOnly.TryParseExact(document.Fields["date"], "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var date))
        {
            error = $"data non valida (serve YYYY-MM-DD): {document.Fields["date"]}";
            return null;
        }

        error = null;
        return new DevlogPost(slug, document.Fields["title"], date, document.Fields["summary"], document.Fields["author"], document.Body);
    }

    // Italian long date ("18 ottobre 2026") without relying on the server's ICU data.
    public static string FormatDate(DateOnly date) => $"{date.Day} {Months[date.Month - 1]} {date.Year}";

    private static readonly string[] Months =
    [
        "gennaio", "febbraio", "marzo", "aprile", "maggio", "giugno",
        "luglio", "agosto", "settembre", "ottobre", "novembre", "dicembre",
    ];
}
