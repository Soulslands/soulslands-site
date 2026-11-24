using System.Net;
using System.Text;
using System.Text.Encodings.Web;
using Soulslands.Web.Services;

namespace Soulslands.StaticExport;

// Fail closed on staff pages (ADR-0035): the public site must never hold one. First guard, the
// allow-list of PublicPages over every .md file of the WikiContent/ the export builds from (wiki
// pages and devlog posts), before anything is rendered; WikiStore applies the same rule to the
// wiki pages it loads. Second guard: no file of dist/ names a refused page (slug or title) or
// carries "visibility: staff".
public static class StaffGuard
{
    public sealed record RefusedPage(string File, string Reason, string? Slug, string? Title);

    public static IReadOnlyList<RefusedPage> FindRefusedPages(string wikiDirectory)
    {
        var refused = new List<RefusedPage>();
        foreach (var file in Directory.EnumerateFiles(wikiDirectory, "*.md", SearchOption.AllDirectories).Order(StringComparer.Ordinal))
        {
            var text = File.ReadAllText(file);
            if (PublicPages.Refusal(text, PublicPages.IsDevlogFile(wikiDirectory, file)) is { } reason)
            {
                var fields = FrontMatter.Parse(text)?.Fields;
                refused.Add(new RefusedPage(file, reason, fields?.GetValueOrDefault("slug"), fields?.GetValueOrDefault("title")));
            }
        }
        return refused;
    }

    // The strings no file of dist/ may contain: the marker, and each staff page's slug and title as
    // written, HTML-encoded and JSON-encoded.
    public static IReadOnlyList<string> Needles(IEnumerable<RefusedPage> refusedPages)
    {
        var needles = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { PublicPages.StaffMarker };
        foreach (var page in refusedPages)
        {
            foreach (var value in new[] { page.Slug, page.Title })
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    continue;
                }
                var trimmed = value.Trim();
                needles.Add(trimmed);
                needles.Add(WebUtility.HtmlEncode(trimmed));
                needles.Add(HtmlEncoder.Default.Encode(trimmed));
                needles.Add(JavaScriptEncoder.Default.Encode(trimmed));
            }
        }
        return [.. needles];
    }

    // Each file of dist/ (pages, search index, feed, sitemap, scripts) that holds a needle, ignoring case.
    public static IReadOnlyList<string> ScanOutput(string outputDirectory, IReadOnlyList<string> needles)
    {
        var hits = new List<string>();
        foreach (var file in Directory.EnumerateFiles(outputDirectory, "*", SearchOption.AllDirectories).Order(StringComparer.Ordinal))
        {
            var text = Encoding.UTF8.GetString(File.ReadAllBytes(file));
            foreach (var needle in needles)
            {
                if (text.Contains(needle, StringComparison.OrdinalIgnoreCase))
                {
                    hits.Add($"{Path.GetRelativePath(outputDirectory, file)}: contiene \"{needle}\"");
                }
            }
        }
        return hits;
    }
}
