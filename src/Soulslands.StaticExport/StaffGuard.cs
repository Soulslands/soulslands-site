using System.Net;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.RegularExpressions;
using Soulslands.Web.Data;
using Soulslands.Web.Services;

namespace Soulslands.StaticExport;

// Fail closed on staff pages (ADR-0035): the public site must never hold one. First guard: the
// WikiContent/ the export builds from holds no staff page at all. Second guard: no file of dist/
// names a staff page of that source (slug or title) or carries "visibility: staff". The pages are
// also rendered as an anonymous visitor, so WikiAccess already hides staff pages.
public static partial class StaffGuard
{
    public const string StaffMarker = "visibility: staff";

    public sealed record StaffPage(string File, string? Slug, string? Title);

    // Every .md file (devlog included) whose front matter says staff, read the way the importer reads
    // it or, for a file the importer would refuse, by the raw line.
    public static IReadOnlyList<StaffPage> FindStaffPages(string wikiDirectory)
    {
        var found = new List<StaffPage>();
        foreach (var file in Directory.EnumerateFiles(wikiDirectory, "*.md", SearchOption.AllDirectories).Order(StringComparer.Ordinal))
        {
            var text = File.ReadAllText(file);
            var parsed = WikiContentImporter.Parse(text);
            if (parsed?.Visibility == WikiVisibility.Staff)
            {
                found.Add(new StaffPage(file, parsed.Slug, parsed.Title));
            }
            else if (StaffLine().IsMatch(text))
            {
                var fields = FrontMatter.Parse(text)?.Fields;
                found.Add(new StaffPage(file, fields?.GetValueOrDefault("slug"), fields?.GetValueOrDefault("title")));
            }
        }
        return found;
    }

    // The strings no file of dist/ may contain: the marker, and each staff page's slug and title as
    // written, HTML-encoded and JSON-encoded.
    public static IReadOnlyList<string> Needles(IEnumerable<StaffPage> staffPages)
    {
        var needles = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { StaffMarker };
        foreach (var page in staffPages)
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

    [GeneratedRegex(@"^\s*visibility\s*:\s*[""']?staff\b", RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.CultureInvariant)]
    private static partial Regex StaffLine();
}
