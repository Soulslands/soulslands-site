using Soulslands.Web.Services;

namespace Soulslands.Web.Tests;

public class MarkdownRendererTests
{
    [Fact]
    public void RendersMarkdown()
    {
        Assert.Contains("<strong>100.0</strong>", MarkdownRenderer.ToHtml("**100.0**"));
    }

    [Fact]
    public void EscapesRawHtml()
    {
        var html = MarkdownRenderer.ToHtml("<script>alert(1)</script>");
        Assert.DoesNotContain("<script>", html);
    }

    [Theory]
    [InlineData("[x](javascript:alert(1))")]
    [InlineData("[x](JavaScript:alert(1))")]
    [InlineData("[x](data:text/html,hi)")]
    public void NeutralizesUnsafeLinks(string markdown)
    {
        var html = MarkdownRenderer.ToHtml(markdown);
        Assert.Contains("href=\"#\"", html);
    }

    [Fact]
    public void KeepsSafeLinks()
    {
        Assert.Contains("href=\"https://example.com\"", MarkdownRenderer.ToHtml("[x](https://example.com)"));
    }

    [Fact]
    public void RendersMermaidBlocksAsDiagrams()
    {
        var html = MarkdownRenderer.ToHtml("```mermaid\nflowchart LR\n  A[\"Client\"] --> B[\"<b>Server</b>\"]\n```");
        Assert.Contains("<pre class=\"mermaid\">flowchart LR", html);
        Assert.Contains("A[\"Client\"] -->", html);
        Assert.DoesNotContain("<b>", html);
        Assert.True(MarkdownRenderer.HasDiagrams(html));
    }

    [Fact]
    public void OtherCodeBlocksAreNotDiagrams()
    {
        var html = MarkdownRenderer.ToHtml("```rust\nlet class = \"mermaid\";\n```");
        Assert.False(MarkdownRenderer.HasDiagrams(html));
    }
}
