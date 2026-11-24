using System.Globalization;
using System.Net;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.RegularExpressions;
using Soulslands.Web.Services;

namespace Soulslands.StaticExport;

// Fail closed on staff pages (ADR-0035): the public site must never hold one. First guard, an
// allow-list over every .md file of the WikiContent/ the export builds from: a wiki page is
// published only if its front matter says exactly "visibility: Pubblica" (a devlog post may also
// say nothing); any other value, a missing one, a key spelled like it ("visibilità", "Visibilita")
// or a "visibility: staff" line anywhere refuses the build. Second guard: no file of dist/ names a
// refused page (slug or title) or carries "visibility: staff". The pages are also rendered as an
// anonymous visitor, so WikiAccess already hides staff pages.
public static partial class StaffGuard
{
    public const string StaffMarker = "visibility: staff";

    public const string VisibilityKey = "visibility";

    public const string Public = "Pubblica";

    public sealed record RefusedPage(string File, string Reason, string? Slug, string? Title);

    public static IReadOnlyList<RefusedPage> FindRefusedPages(string wikiDirectory)
    {
        var refused = new List<RefusedPage>();
        foreach (var file in Directory.EnumerateFiles(wikiDirectory, "*.md", SearchOption.AllDirectories).Order(StringComparer.Ordinal))
        {
            var text = File.ReadAllText(file);
            // The importer's rule (WikiContentImporter.IsDevlogFile): under the top-level devlog/ folder.
            var relative = Path.GetRelativePath(wikiDirectory, file);
            var first = relative.Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar)[0];
            var isDevlog = relative != first && first == WikiContentImporter.DevlogFolder;
            if (Refusal(text, isDevlog) is { } reason)
            {
                var fields = FrontMatter.Parse(text)?.Fields;
                refused.Add(new RefusedPage(file, reason, fields?.GetValueOrDefault("slug"), fields?.GetValueOrDefault("title")));
            }
        }
        return refused;
    }

    // Why a file may not be published, or null. Reads the front matter block line by line the way
    // FrontMatter.Parse does (CRLF, BOM, "key: value", trimmed value without quotes).
    public static string? Refusal(string text, bool isDevlog)
    {
        if (StaffLine().IsMatch(text))
        {
            return $"contiene una riga \"{StaffMarker}\"";
        }
        var lines = text.Replace("\r\n", "\n").TrimStart('\uFEFF').Split('\n');
        if (lines[0].Trim() != "---")
        {
            return "non inizia con un front matter (---)";
        }
        var visibilities = new List<string>();
        for (var i = 1; i < lines.Length; i++)
        {
            if (lines[i].Trim() == "---")
            {
                if (visibilities.Count == 0)
                {
                    return isDevlog ? null : $"manca \"{VisibilityKey}: {Public}\"";
                }
                var other = visibilities.FirstOrDefault(v => v != Public);
                return other is null ? null : $"{VisibilityKey} vale \"{other}\", non {Public}";
            }
            var colon = lines[i].IndexOf(':');
            if (colon <= 0)
            {
                continue;
            }
            var key = lines[i][..colon].Trim();
            var folded = Fold(key);
            if (folded == VisibilityKey)
            {
                visibilities.Add(lines[i][(colon + 1)..].Trim().Trim('"', '\''));
            }
            else if (folded.StartsWith("visib", StringComparison.Ordinal))
            {
                return $"chiave sconosciuta \"{key}\" (si scrive {VisibilityKey}: {Public})";
            }
        }
        return "front matter senza la riga --- di chiusura";
    }

    // Lower case without accents: "Visibilità" -> "visibilita".
    private static string Fold(string key) =>
        new string([.. key.Normalize(NormalizationForm.FormD).Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)])
            .ToLowerInvariant();

    // The strings no file of dist/ may contain: the marker, and each staff page's slug and title as
    // written, HTML-encoded and JSON-encoded.
    public static IReadOnlyList<string> Needles(IEnumerable<RefusedPage> refusedPages)
    {
        var needles = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { StaffMarker };
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

    [GeneratedRegex(@"^\s*visibility\s*:\s*[""']?staff\b", RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.CultureInvariant)]
    private static partial Regex StaffLine();
}
