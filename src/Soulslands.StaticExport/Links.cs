using System.Net;
using System.Text.RegularExpressions;

namespace Soulslands.StaticExport;

// Same-origin links of a page or a stylesheet, as paths of the static site.
public static partial class Links
{
    private static readonly Uri Origin = new("https://static.invalid/");

    public sealed record Link(string Raw, string Path, string? Query);

    // Every href and src of an HTML page, resolved against the address the page is served at
    // (a page in <path>/index.html is served at <path>/). Fragments, other sites and data:,
    // mailto:, tel:, javascript: links are left out.
    public static IEnumerable<Link> FromHtml(string html, string pageUrl) =>
        HtmlAttribute().Matches(html)
            .Select(m => WebUtility.HtmlDecode(m.Groups["v"].Success ? m.Groups["v"].Value : m.Groups["u"].Value))
            .Select(raw => Resolve(raw, pageUrl))
            .OfType<Link>();

    // The url(...) references of a stylesheet, resolved against the stylesheet's own address.
    public static IEnumerable<Link> FromCss(string css, string cssUrl) =>
        CssUrl().Matches(css)
            .Select(m => m.Groups["v"].Value.Trim())
            .Select(raw => Resolve(raw, cssUrl))
            .OfType<Link>();

    public static Link? Resolve(string raw, string baseUrl)
    {
        var value = raw.Trim();
        if (value.Length == 0 || value.StartsWith('#')
            || value.StartsWith("data:", StringComparison.OrdinalIgnoreCase)
            || value.StartsWith("mailto:", StringComparison.OrdinalIgnoreCase)
            || value.StartsWith("tel:", StringComparison.OrdinalIgnoreCase)
            || value.StartsWith("javascript:", StringComparison.OrdinalIgnoreCase))
        {
            return null;
        }
        if (!Uri.TryCreate(new Uri(Origin, baseUrl), value, out var target))
        {
            return new Link(raw, value, null);
        }
        if (target.Scheme is not ("http" or "https") || target.Authority != Origin.Authority)
        {
            return null;
        }
        var query = target.Query.Length > 1 ? target.Query[1..] : null;
        return new Link(raw, target.AbsolutePath, query);
    }

    [GeneratedRegex(@"\s(?:href|src)\s*=\s*(?:""(?<v>[^""]*)""|'(?<v>[^']*)'|(?<u>[^\s""'>]+))", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant)]
    private static partial Regex HtmlAttribute();

    [GeneratedRegex(@"url\(\s*[""']?(?<v>[^""')]+)[""']?\s*\)", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant)]
    private static partial Regex CssUrl();
}
