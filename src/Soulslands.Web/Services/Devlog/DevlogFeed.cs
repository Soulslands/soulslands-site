using System.Globalization;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Soulslands.Web.Services.Devlog;

// Atom 1.0 feed of the devlog at /devlog/feed.xml (outside /api: it is part of the site).
// The literal route wins over the /devlog/{slug} page, and "feed.xml" is never a valid slug.
public static class DevlogFeed
{
    public const string Path = "/devlog/feed.xml";
    public const string ContentType = "application/atom+xml";
    public const int MaxEntries = 20;

    private static readonly XNamespace Atom = "http://www.w3.org/2005/Atom";

    public static void Map(IEndpointRouteBuilder app) => app.MapGet(Path, Handle);

    public static IResult Handle(HttpContext context, [FromServices] DevlogStore store, [FromServices] IOptions<SiteOptions> site)
    {
        var baseUrl = BaseUrl(context.Request, site.Value);
        var xml = ToXml(Build(store.Posts, baseUrl));
        context.Response.Headers.CacheControl = "public, max-age=900";
        return Results.Text(xml, $"{ContentType}; charset=utf-8", Encoding.UTF8);
    }

    // With a real domain (Site:BaseUrl) ids and links depend only on it and the slug, so
    // they stay stable whatever Host a request carries. Without it (home mode, development)
    // they follow the request: scheme from X-Forwarded-Proto behind the proxy, see Program.cs.
    public static string BaseUrl(HttpRequest request, SiteOptions site) =>
        string.IsNullOrWhiteSpace(site.BaseUrl)
            ? $"{request.Scheme}://{request.Host}{request.PathBase}"
            : site.BaseUrl.Trim();

    // Newest posts first (the store already sorts them), at most MaxEntries.
    // Post HTML comes from MarkdownRenderer (raw HTML off, unsafe links replaced) and is
    // escaped as text inside <content type="html">, so a post cannot break the XML.
    public static XDocument Build(IReadOnlyList<DevlogPost> posts, string baseUrl)
    {
        baseUrl = baseUrl.TrimEnd('/');
        var listUrl = $"{baseUrl}/devlog";
        var entries = posts.Take(MaxEntries).ToList();
        // An empty feed still needs an <updated>; the epoch says "nothing published yet".
        var updated = entries.Count > 0 ? Timestamp(entries.Max(p => p.Date)) : "1970-01-01T00:00:00Z";

        var feed = new XElement(Atom + "feed",
            // Relative links inside post content (/wiki/...) resolve against the site.
            new XAttribute(XNamespace.Xml + "base", baseUrl + "/"),
            new XAttribute(XNamespace.Xml + "lang", "it"),
            new XElement(Atom + "id", listUrl),
            new XElement(Atom + "title", "Devlog di Soulslands"),
            new XElement(Atom + "subtitle", "Notizie dallo sviluppo di Soulslands."),
            new XElement(Atom + "updated", updated),
            new XElement(Atom + "link", new XAttribute("rel", "self"), new XAttribute("type", ContentType), new XAttribute("href", baseUrl + Path)),
            new XElement(Atom + "link", new XAttribute("rel", "alternate"), new XAttribute("type", "text/html"), new XAttribute("href", listUrl)),
            new XElement(Atom + "author", new XElement(Atom + "name", "Soulslands")),
            entries.Select(post => Entry(post, listUrl)));

        return new XDocument(new XDeclaration("1.0", "utf-8", null), feed);
    }

    private static XElement Entry(DevlogPost post, string listUrl)
    {
        var url = $"{listUrl}/{post.Slug}";
        var date = Timestamp(post.Date);
        return new XElement(Atom + "entry",
            new XElement(Atom + "id", url),
            new XElement(Atom + "title", post.Title),
            new XElement(Atom + "link", new XAttribute("rel", "alternate"), new XAttribute("type", "text/html"), new XAttribute("href", url)),
            new XElement(Atom + "published", date),
            new XElement(Atom + "updated", date),
            new XElement(Atom + "author", new XElement(Atom + "name", post.Author)),
            new XElement(Atom + "summary", post.Summary),
            new XElement(Atom + "content", new XAttribute("type", "html"), post.Html));
    }

    // Posts carry a day only: midnight UTC of that day, RFC 3339.
    private static string Timestamp(DateOnly date) =>
        date.ToDateTime(TimeOnly.MinValue, DateTimeKind.Utc).ToString("yyyy-MM-dd'T'HH:mm:ss'Z'", CultureInfo.InvariantCulture);

    private static string ToXml(XDocument document)
    {
        var builder = new StringBuilder();
        var settings = new XmlWriterSettings { Encoding = Encoding.UTF8, Indent = true };
        using (var writer = new Utf8StringWriter(builder))
        using (var xml = XmlWriter.Create(writer, settings))
        {
            document.Save(xml);
        }
        return builder.ToString();
    }

    // StringWriter reports UTF-16, which would end up in the XML declaration.
    private sealed class Utf8StringWriter(StringBuilder builder) : StringWriter(builder, CultureInfo.InvariantCulture)
    {
        public override Encoding Encoding => Encoding.UTF8;
    }
}
