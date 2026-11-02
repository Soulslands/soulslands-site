namespace Soulslands.Web.Services.Devlog;

public record DevlogPost(string Slug, string Title, DateOnly Date, string Summary, string Author, string Content)
{
    // Rendered once when posts are loaded: posts only change with a deploy.
    public string Html { get; } = MarkdownRenderer.ToHtml(Content);

    public bool HasDiagrams => MarkdownRenderer.HasDiagrams(Html);
}
