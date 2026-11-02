namespace Soulslands.Web.Services;

// Markdown files in WikiContent/ (wiki pages and devlog posts) open with a block
// of "key: value" lines between two "---" lines.
public static class FrontMatter
{
    public record Document(IReadOnlyDictionary<string, string> Fields, string Body);

    // Returns null when the file has no closed front matter block.
    public static Document? Parse(string text)
    {
        var lines = text.Replace("\r\n", "\n").TrimStart('﻿').Split('\n');
        if (lines.Length == 0 || lines[0].Trim() != "---")
        {
            return null;
        }

        var fields = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        for (var i = 1; i < lines.Length; i++)
        {
            if (lines[i].Trim() == "---")
            {
                var body = string.Join('\n', lines[(i + 1)..]).Trim() + "\n";
                return new Document(fields, body);
            }

            var colon = lines[i].IndexOf(':');
            if (colon > 0)
            {
                fields[lines[i][..colon].Trim()] = lines[i][(colon + 1)..].Trim().Trim('"', '\'');
            }
        }

        return null;
    }
}
