using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.RegularExpressions;
using Markdig;

namespace Soulslands.StaticExport;

// The wiki search of the static site (wwwroot/js/wiki-search.js): one entry per public page.
public static partial class SearchIndex
{
    public const int TextLength = 400;

    public sealed record Entry(string Slug, string Title, string? Category, string Text);

    private static readonly JsonSerializerOptions Json = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
    };

    public static Entry Build(string slug, string title, string? category, string markdown) =>
        new(slug, title, category, Cut(PlainText(markdown)));

    public static string Serialize(IEnumerable<Entry> entries) => JsonSerializer.Serialize(entries, Json);

    // Markdown as plain text on one line: no markup, no diagram source.
    public static string PlainText(string markdown)
    {
        var withoutDiagrams = Diagram().Replace(markdown, " ");
        var text = Markdown.ToPlainText(withoutDiagrams);
        return Spaces().Replace(text, " ").Trim();
    }

    // At most TextLength characters, cut at a word boundary.
    public static string Cut(string text)
    {
        if (text.Length <= TextLength)
        {
            return text;
        }
        var cut = text.LastIndexOf(' ', TextLength);
        return text[..(cut > TextLength / 2 ? cut : TextLength)];
    }

    [GeneratedRegex(@"```mermaid.*?```", RegexOptions.Singleline)]
    private static partial Regex Diagram();

    [GeneratedRegex(@"\s+")]
    private static partial Regex Spaces();
}
