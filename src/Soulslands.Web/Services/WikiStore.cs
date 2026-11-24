using System.Text.RegularExpressions;
using Microsoft.Extensions.Options;

namespace Soulslands.Web.Services;

// The wiki pages kept as Markdown files in WikiContent/ (outside devlog/, which DevlogStore reads).
// They change only with a commit, so they are read once, at startup, and kept in memory. A page
// that is not public stops the load (PublicPages, fail closed): the site and its static export
// never start with a staff page in the folder.
public partial class WikiStore
{
    public const string DevlogFolder = "devlog";

    private readonly Dictionary<string, WikiPage> _bySlug;

    public WikiStore(IOptions<WikiOptions> options, IWebHostEnvironment environment, ILogger<WikiStore> logger)
    {
        Directory = Path.GetFullPath(string.IsNullOrWhiteSpace(options.Value.Directory)
            ? Path.Combine(environment.ContentRootPath, "WikiContent")
            : Path.Combine(environment.ContentRootPath, options.Value.Directory));
        Pages = Load(Directory, logger);
        _bySlug = Pages.ToDictionary(p => p.Slug, StringComparer.Ordinal);
    }

    public string Directory { get; }

    // In the order of their file paths; the first file wins when two share a slug.
    public IReadOnlyList<WikiPage> Pages { get; }

    public WikiPage? Find(string slug) => _bySlug.GetValueOrDefault(slug);

    public static IReadOnlyList<WikiPage> Load(string directory, ILogger logger)
    {
        if (!System.IO.Directory.Exists(directory))
        {
            logger.LogWarning("Cartella wiki {Directory} non trovata", directory);
            return [];
        }

        var dates = GitDates.LastCommits(directory);
        var pages = new List<WikiPage>();
        var slugs = new HashSet<string>(StringComparer.Ordinal);
        foreach (var file in System.IO.Directory.EnumerateFiles(directory, "*.md", SearchOption.AllDirectories).Order())
        {
            if (PublicPages.IsDevlogFile(directory, file))
            {
                continue;
            }

            var text = File.ReadAllText(file);
            if (PublicPages.Refusal(text, isDevlog: false) is { } reason)
            {
                throw new InvalidOperationException($"Pagina non pubblicabile nella wiki: {file}: {reason} (il sito è pubblico, ADR-0035)");
            }

            var parsed = Parse(text);
            if (parsed is null || !IsValidSlug(parsed.Slug))
            {
                logger.LogWarning("Pagina wiki non valida, ignorata: {File}", file);
                continue;
            }

            var page = dates.TryGetValue(Path.GetFullPath(file), out var date) ? parsed with { UpdatedAt = date } : parsed;
            if (!slugs.Add(page.Slug))
            {
                logger.LogWarning("Slug wiki duplicato {Slug} in {File}, ignorato", page.Slug, file);
                continue;
            }
            pages.Add(page);
        }

        logger.LogInformation("Wiki: {Pages} pagine lette da {Directory}", pages.Count, directory);
        return pages;
    }

    // A page from its file: front matter with slug and title, the Markdown body. Null when either
    // is missing. Visibility is not read here: PublicPages has already refused every other value.
    public static WikiPage? Parse(string text)
    {
        var document = FrontMatter.Parse(text);
        if (document is null
            || !document.Fields.TryGetValue("slug", out var slug)
            || !document.Fields.TryGetValue("title", out var title)
            || string.IsNullOrWhiteSpace(title))
        {
            return null;
        }

        document.Fields.TryGetValue("category", out var category);
        return new WikiPage(slug, title, string.IsNullOrWhiteSpace(category) ? null : category, document.Body);
    }

    // Lowercase words joined by single hyphens; also the rule for devlog slugs.
    public static bool IsValidSlug(string? slug) => slug is not null && SlugRegex().IsMatch(slug);

    [GeneratedRegex("^[a-z0-9]+(-[a-z0-9]+)*$")]
    private static partial Regex SlugRegex();
}
