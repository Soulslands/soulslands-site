using Markdig;
using Markdig.Syntax;
using Markdig.Syntax.Inlines;

namespace Soulslands.Web.Services;

public static class MarkdownRenderer
{
    // Raw HTML is disabled so wiki authors cannot inject scripts.
    private static readonly MarkdownPipeline Pipeline = new MarkdownPipelineBuilder()
        .UseAdvancedExtensions()
        .DisableHtml()
        .Build();

    private static readonly string[] UnsafeSchemes = ["javascript:", "vbscript:", "data:"];

    public static string ToHtml(string markdown)
    {
        var document = Markdown.Parse(markdown, Pipeline);

        foreach (var link in document.Descendants<LinkInline>())
        {
            if (IsUnsafeUrl(link.Url))
            {
                link.Url = "#";
            }
        }

        return document.ToHtml(Pipeline);
    }

    // ```mermaid blocks come out as <pre class="mermaid">, drawn in the browser by wiki-diagrams.js.
    public static bool HasDiagrams(string html) => html.Contains("class=\"mermaid\"", StringComparison.Ordinal);

    private static bool IsUnsafeUrl(string? url)
    {
        if (string.IsNullOrWhiteSpace(url))
        {
            return false;
        }

        // Browsers ignore whitespace and control characters inside the scheme.
        var compact = new string(url.Where(c => !char.IsWhiteSpace(c) && !char.IsControl(c)).ToArray());
        return UnsafeSchemes.Any(s => compact.StartsWith(s, StringComparison.OrdinalIgnoreCase));
    }
}
