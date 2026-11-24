using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Soulslands.Web.Services;

// This repository and the site are public and hold public pages only (ADR-0035): staff pages live
// in soulslands-hq/wiki/. The rule is an allow-list, so it fails closed: a wiki page is published
// only if its front matter says exactly "visibility: Pubblica" (a devlog post may also say
// nothing); any other value, a missing one, a key spelled like it ("visibilità", "Visibilita") or a
// "visibility: staff" line anywhere refuses the page. WikiStore refuses to load such a page and the
// static export refuses to build (Soulslands.StaticExport.StaffGuard).
public static partial class PublicPages
{
    public const string StaffMarker = "visibility: staff";

    public const string VisibilityKey = "visibility";

    public const string Public = "Pubblica";

    // Why a file may not be published, or null. Reads the front matter block line by line the way
    // FrontMatter.Parse does (CRLF, BOM, "key: value", trimmed value without quotes).
    public static string? Refusal(string text, bool isDevlog)
    {
        if (StaffLine().IsMatch(text))
        {
            return $"contiene una riga \"{StaffMarker}\"";
        }
        var lines = text.Replace("\r\n", "\n").TrimStart('﻿').Split('\n');
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

    // Whether a file under the WikiContent folder is a devlog post (under the top-level devlog/
    // folder, exact lowercase match like the path DevlogStore opens) rather than a wiki page.
    public static bool IsDevlogFile(string wikiDirectory, string file)
    {
        var relative = Path.GetRelativePath(wikiDirectory, file);
        var first = relative.Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar)[0];
        return relative != first && first == WikiStore.DevlogFolder;
    }

    // Lower case without accents: "Visibilità" -> "visibilita".
    private static string Fold(string key) =>
        new string([.. key.Normalize(NormalizationForm.FormD).Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)])
            .ToLowerInvariant();

    [GeneratedRegex(@"^\s*visibility\s*:\s*[""']?staff\b", RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.CultureInvariant)]
    private static partial Regex StaffLine();
}
