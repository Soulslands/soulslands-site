using System.Net;
using System.Xml.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Soulslands.Web.Services.Devlog;

namespace Soulslands.Web.Tests;

internal static class DevlogFixtures
{
    public static string Post(string slug, string date, string title = "Titolo", string body = "Testo del post.") => $"""
        ---
        title: {title}
        slug: {slug}
        date: {date}
        summary: Riassunto di {slug}
        author: Aruto
        ---
        {body}
        """;
}

public sealed class DevlogLoaderTests : IDisposable
{
    private readonly string _dir = Directory.CreateTempSubdirectory("devlog-").FullName;

    public void Dispose() => Directory.Delete(_dir, recursive: true);

    private void Write(string name, string text) => File.WriteAllText(Path.Combine(_dir, name), text);

    [Fact]
    public void ParsesEveryField()
    {
        var post = DevlogLoader.Parse(DevlogFixtures.Post("primo-post", "2026-10-18", "Il sito è pronto", "# Ciao\nTesto."), out var error);

        Assert.Null(error);
        Assert.NotNull(post);
        Assert.Equal("primo-post", post.Slug);
        Assert.Equal("Il sito è pronto", post.Title);
        Assert.Equal(new DateOnly(2026, 10, 18), post.Date);
        Assert.Equal("Riassunto di primo-post", post.Summary);
        Assert.Equal("Aruto", post.Author);
        Assert.StartsWith("# Ciao", post.Content);
    }

    [Theory]
    [InlineData("title")]
    [InlineData("slug")]
    [InlineData("date")]
    [InlineData("summary")]
    [InlineData("author")]
    public void RejectsAMissingField(string field)
    {
        var lines = DevlogFixtures.Post("primo-post", "2026-10-18").Split('\n').Where(l => !l.StartsWith(field + ":"));

        Assert.Null(DevlogLoader.Parse(string.Join('\n', lines), out var error));
        Assert.Contains(field, error);
    }

    [Theory]
    [InlineData("Primo Post", "2026-10-18")]
    [InlineData("modifica", "2026-10-18")]
    [InlineData("primo-post", "18/10/2026")]
    [InlineData("primo-post", "2026-13-01")]
    [InlineData("primo-post", "2026-10-18T10:00")]
    public void RejectsAnInvalidSlugOrDate(string slug, string date)
    {
        Assert.Null(DevlogLoader.Parse(DevlogFixtures.Post(slug, date), out var error));
        Assert.NotNull(error);
    }

    [Fact]
    public void RejectsAFileWithoutFrontMatter()
    {
        Assert.Null(DevlogLoader.Parse("# Solo testo", out var error));
        Assert.NotNull(error);
    }

    [Fact]
    public void LoadLogsAndSkipsInvalidPostsAndDuplicates()
    {
        Write("a.md", DevlogFixtures.Post("primo-post", "2026-10-01"));
        Write("b.md", DevlogFixtures.Post("primo-post", "2026-10-02", "Doppione"));
        Write("c.md", DevlogFixtures.Post("senza-data", "ieri"));
        var logger = new ListLogger();

        var posts = DevlogLoader.Load(_dir, logger);

        var post = Assert.Single(posts);
        Assert.Equal("Titolo", post.Title);
        Assert.Contains(logger.Warnings, w => w.Contains("c.md") && w.Contains("data non valida"));
        Assert.Contains(logger.Warnings, w => w.Contains("b.md") && w.Contains("duplicato"));
    }

    [Fact]
    public void LoadLogsAndSkipsAnUnreadableFile()
    {
        Write("buono.md", DevlogFixtures.Post("buono", "2026-10-01"));
        Write("bloccato.md", DevlogFixtures.Post("bloccato", "2026-10-02"));
        var logger = new ListLogger();

        // An exclusive handle makes reading fail on every platform (.NET emulates FileShare on Unix).
        List<DevlogPost> posts;
        using (new FileStream(Path.Combine(_dir, "bloccato.md"), FileMode.Open, FileAccess.ReadWrite, FileShare.None))
        {
            posts = [.. DevlogLoader.Load(_dir, logger)];
        }

        Assert.Equal("buono", Assert.Single(posts).Slug);
        Assert.Contains(logger.Warnings, w => w.Contains("bloccato.md") && w.Contains("non leggibile"));
    }

    [Fact]
    public void LoadSortsNewestFirst()
    {
        Write("vecchio.md", DevlogFixtures.Post("vecchio", "2026-01-05"));
        Write("nuovo.md", DevlogFixtures.Post("nuovo", "2026-10-18"));
        Write("medio.md", DevlogFixtures.Post("medio", "2026-06-30"));

        var slugs = DevlogLoader.Load(_dir, NullLogger.Instance).Select(p => p.Slug);

        Assert.Equal(["nuovo", "medio", "vecchio"], slugs);
    }

    [Fact]
    public void MissingFolderGivesNoPosts()
    {
        Assert.Empty(DevlogLoader.Load(Path.Combine(_dir, "non-esiste"), NullLogger.Instance));
    }

    [Fact]
    public void FormatsDatesInItalian()
    {
        Assert.Equal("18 ottobre 2026", DevlogLoader.FormatDate(new DateOnly(2026, 10, 18)));
        Assert.Equal("1 gennaio 2027", DevlogLoader.FormatDate(new DateOnly(2027, 1, 1)));
    }

    private sealed class ListLogger : ILogger
    {
        public List<string> Warnings { get; } = [];

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull => null;

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            if (logLevel == LogLevel.Warning)
            {
                Warnings.Add(formatter(state, exception));
            }
        }
    }
}

// The site with posts from a temporary folder, never from the real WikiContent/devlog.
public sealed class DevlogSiteFactory : SiteFactory
{
    public string PostsDirectory { get; } = Directory.CreateTempSubdirectory("devlog-site-").FullName;

    public DevlogSiteFactory()
    {
        File.WriteAllText(Path.Combine(PostsDirectory, "vecchio.md"), DevlogFixtures.Post("vecchio", "2026-01-05", "Post vecchio"));
        File.WriteAllText(Path.Combine(PostsDirectory, "medio.md"), DevlogFixtures.Post("medio", "2026-06-30", "Post medio",
            "Vedi [la wiki](/wiki/guida) e [il sito](https://example.org/)."));
        File.WriteAllText(Path.Combine(PostsDirectory, "nuovo.md"), DevlogFixtures.Post("nuovo", "2026-10-18", "Post nuovo",
            "## Il piano\n\n```mermaid\ngraph LR\n  M0 --> M1\n```\n"));
        File.WriteAllText(Path.Combine(PostsDirectory, "ostile.md"), DevlogFixtures.Post("ostile", "2025-12-01", "Post ostile",
            "<script>alert('xss')</script>\n\n[clicca](javascript:alert(1))\n"));
        File.WriteAllText(Path.Combine(PostsDirectory, "rotto.md"), DevlogFixtures.Post("rotto", "domani", "Post rotto"));
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        base.ConfigureWebHost(builder);
        builder.UseSetting("Devlog:Directory", PostsDirectory);
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
        if (Directory.Exists(PostsDirectory))
        {
            Directory.Delete(PostsDirectory, recursive: true);
        }
    }
}

public class DevlogPageTests(DevlogSiteFactory factory) : IClassFixture<DevlogSiteFactory>
{
    // The import map lists every static asset, so only a <script src> tag counts.
    private const string MermaidScript = "<script src=\"[^\"]*/mermaid/mermaid[^\"]*\\.js";

    private HttpClient Client() => factory.CreateClient(new WebApplicationFactoryClientOptions { AllowAutoRedirect = false });

    [Fact]
    public async Task ListShowsValidPostsNewestFirstToAnonymousVisitors()
    {
        var response = await Client().GetAsync("/devlog");
        var html = await response.Content.ReadAsStringAsync();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var nuovo = html.IndexOf("Post nuovo", StringComparison.Ordinal);
        var vecchio = html.IndexOf("Post vecchio", StringComparison.Ordinal);
        Assert.True(nuovo >= 0 && vecchio > nuovo, "newest post must come first");
        Assert.Contains("href=\"/devlog/nuovo\"", html);
        Assert.Contains("18 ottobre 2026", html);
        Assert.Contains("Riassunto di nuovo", html);
        Assert.DoesNotContain("Post rotto", html);
    }

    [Fact]
    public async Task PostRendersMarkdownWithDiagrams()
    {
        var response = await Client().GetAsync("/devlog/nuovo");
        var html = await response.Content.ReadAsStringAsync();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Contains("<h1 class=\"mb-1\">Post nuovo</h1>", html);
        Assert.Contains("<h2 id=\"il-piano\">Il piano</h2>", html);
        Assert.Contains("class=\"mermaid\"", html);
        Assert.Matches(MermaidScript, html);
        Assert.Contains("Aruto", html);
    }

    [Fact]
    public async Task PostCannotInjectScriptsOrJavascriptLinks()
    {
        var response = await Client().GetAsync("/devlog/ostile");
        var html = await response.Content.ReadAsStringAsync();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.DoesNotContain("<script>alert", html);
        Assert.Contains("&lt;script&gt;alert", html);
        Assert.DoesNotContain("javascript:", html, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("<a href=\"#\">clicca</a>", html);
    }

    [Fact]
    public async Task PostWithoutDiagramsDoesNotLoadMermaid()
    {
        var html = await Client().GetStringAsync("/devlog/vecchio");
        Assert.DoesNotMatch(MermaidScript, html);
    }

    [Theory]
    [InlineData("/devlog/non-esiste")]
    [InlineData("/devlog/rotto")]
    [InlineData("/devlog/Nuovo")]
    public async Task UnknownSlugAnswers404(string path)
    {
        Assert.Equal(HttpStatusCode.NotFound, (await Client().GetAsync(path)).StatusCode);
    }

    [Fact]
    public async Task WikiDoesNotShowPosts()
    {
        Assert.Equal(HttpStatusCode.NotFound, (await Client().GetAsync("/wiki/nuovo")).StatusCode);
    }

    [Fact]
    public async Task MenuLinksTheDevlog()
    {
        Assert.Contains("href=\"/devlog\"", await Client().GetStringAsync("/"));
    }
}

public sealed class EmptyDevlogSiteFactory : SiteFactory
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        base.ConfigureWebHost(builder);
        builder.UseSetting("Devlog:Directory", Path.Combine(Path.GetTempPath(), $"devlog-missing-{Guid.NewGuid():N}"));
    }
}

public class EmptyDevlogTests(EmptyDevlogSiteFactory factory) : IClassFixture<EmptyDevlogSiteFactory>
{
    [Fact]
    public async Task HomeHidesTheDevlogBlockWithoutPosts()
    {
        var html = await factory.CreateClient().GetStringAsync("/");

        Assert.DoesNotContain("Dal devlog", html);
        Assert.DoesNotContain("href=\"/devlog/", html.Replace(DevlogFeed.Path, ""));
    }

    [Fact]
    public async Task FeedIsValidAndEmptyWithoutPosts()
    {
        var response = await factory.CreateClient().GetAsync(DevlogFeed.Path);
        var feed = XDocument.Parse(await response.Content.ReadAsStringAsync()).Root!;

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(DevlogFeed.ContentType, response.Content.Headers.ContentType?.MediaType);
        Assert.Equal(Atom + "feed", feed.Name);
        Assert.Empty(feed.Elements(Atom + "entry"));
        Assert.Equal("1970-01-01T00:00:00Z", feed.Element(Atom + "updated")?.Value);
    }

    private static readonly XNamespace Atom = "http://www.w3.org/2005/Atom";

    [Fact]
    public async Task MissingFolderShowsAnEmptyList()
    {
        var response = await factory.CreateClient().GetAsync("/devlog");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Contains("Nessun post per ora.", await response.Content.ReadAsStringAsync());
    }
}

public class DevlogFeedTests(DevlogSiteFactory factory) : IClassFixture<DevlogSiteFactory>
{
    private static readonly XNamespace Atom = "http://www.w3.org/2005/Atom";

    private async Task<(HttpResponseMessage Response, XElement Feed)> GetFeed(Action<HttpRequestMessage>? configure = null)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, DevlogFeed.Path);
        configure?.Invoke(request);
        var response = await factory.CreateClient().SendAsync(request);
        var feed = XDocument.Parse(await response.Content.ReadAsStringAsync()).Root!;
        return (response, feed);
    }

    private static DateTimeOffset Date(XElement element, string name) =>
        DateTimeOffset.Parse(element.Element(Atom + name)!.Value, System.Globalization.CultureInfo.InvariantCulture);

    [Fact]
    public async Task FeedAnswersAtomWithValidPostsNewestFirst()
    {
        var (response, feed) = await GetFeed();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(DevlogFeed.ContentType, response.Content.Headers.ContentType?.MediaType);
        Assert.Equal(Atom + "feed", feed.Name);
        Assert.Equal("Devlog di Soulslands", feed.Element(Atom + "title")?.Value);
        Assert.Equal(new DateTimeOffset(2026, 10, 18, 0, 0, 0, TimeSpan.Zero), Date(feed, "updated"));

        var entries = feed.Elements(Atom + "entry").ToList();
        Assert.Equal(["Post nuovo", "Post medio", "Post vecchio", "Post ostile"], entries.Select(e => e.Element(Atom + "title")!.Value));
        Assert.Equal(new DateTimeOffset(2026, 6, 30, 0, 0, 0, TimeSpan.Zero), Date(entries[1], "updated"));
        Assert.Equal("Riassunto di medio", entries[1].Element(Atom + "summary")?.Value);
        Assert.Equal("Aruto", entries[1].Element(Atom + "author")?.Element(Atom + "name")?.Value);
        Assert.DoesNotContain(entries, e => e.Element(Atom + "title")!.Value == "Post rotto");
    }

    [Fact]
    public async Task FeedHasEveryElementAtomRequires()
    {
        var (_, feed) = await GetFeed();

        foreach (var name in new[] { "id", "title", "updated", "author" })
        {
            Assert.NotNull(feed.Element(Atom + name));
        }
        foreach (var entry in feed.Elements(Atom + "entry"))
        {
            foreach (var name in new[] { "id", "title", "updated", "link", "summary", "content" })
            {
                Assert.NotNull(entry.Element(Atom + name));
            }
            Assert.Equal("html", entry.Element(Atom + "content")!.Attribute("type")?.Value);
        }
    }

    [Fact]
    public async Task FeedLinksAreAbsoluteAndComeFromTheRequest()
    {
        var (_, feed) = await GetFeed();

        Assert.Equal("http://localhost/devlog", feed.Element(Atom + "id")?.Value);
        Assert.Equal("http://localhost/devlog/feed.xml", Link(feed, "self"));
        Assert.Equal("http://localhost/devlog", Link(feed, "alternate"));
        Assert.Equal("http://localhost/", feed.Attribute(XNamespace.Xml + "base")?.Value);
        var entry = feed.Elements(Atom + "entry").First();
        Assert.Equal("http://localhost/devlog/nuovo", entry.Element(Atom + "id")?.Value);
        Assert.Equal("http://localhost/devlog/nuovo", Link(entry, "alternate"));
        Assert.All(feed.Descendants(Atom + "link"), l => Assert.True(Uri.IsWellFormedUriString(l.Attribute("href")!.Value, UriKind.Absolute)));
    }

    [Fact]
    public async Task FeedFollowsTheHostAndSchemeBehindTheProxy()
    {
        var (_, feed) = await GetFeed(r =>
        {
            r.Headers.Host = "soulslands.example";
            r.Headers.Add("X-Forwarded-Proto", "https");
            r.Headers.Add("X-Forwarded-For", "203.0.113.7");
        });

        Assert.Equal("https://soulslands.example/devlog/feed.xml", Link(feed, "self"));
        Assert.Equal("https://soulslands.example/devlog/nuovo", Link(feed.Elements(Atom + "entry").First(), "alternate"));
    }

    [Fact]
    public async Task FeedUsesTheConfiguredBaseUrlWhateverTheHost()
    {
        var site = factory.WithWebHostBuilder(b => b.UseSetting("Site:BaseUrl", "https://soulslands.example/"));
        using var request = new HttpRequestMessage(HttpMethod.Get, DevlogFeed.Path);
        request.Headers.Host = "altro.example";
        request.Headers.Add("X-Forwarded-Proto", "http");
        var response = await site.CreateClient().SendAsync(request);
        var feed = XDocument.Parse(await response.Content.ReadAsStringAsync()).Root!;

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal("https://soulslands.example/devlog", feed.Element(Atom + "id")?.Value);
        Assert.Equal("https://soulslands.example/", feed.Attribute(XNamespace.Xml + "base")?.Value);
        Assert.Equal("https://soulslands.example/devlog/feed.xml", Link(feed, "self"));
        Assert.Equal("https://soulslands.example/devlog", Link(feed, "alternate"));
        var entries = feed.Elements(Atom + "entry").ToList();
        Assert.NotEmpty(entries);
        Assert.Equal("https://soulslands.example/devlog/nuovo", entries[0].Element(Atom + "id")?.Value);
        var urls = entries.Select(e => e.Element(Atom + "id")!.Value)
            .Concat(feed.Descendants(Atom + "link").Select(l => l.Attribute("href")!.Value));
        Assert.All(urls, u => Assert.StartsWith("https://soulslands.example/devlog", u));
        Assert.DoesNotContain("altro.example", await response.Content.ReadAsStringAsync());
    }

    [Theory]
    [InlineData("soulslands.example")]
    [InlineData("ftp://soulslands.example")]
    [InlineData("https://soulslands.example/?x=1")]
    public void InvalidBaseUrlStopsTheSiteAtStart(string value)
    {
        var site = factory.WithWebHostBuilder(b => b.UseSetting("Site:BaseUrl", value));

        var error = Assert.ThrowsAny<Exception>(() => site.CreateClient());
        Assert.IsType<Microsoft.Extensions.Options.OptionsValidationException>(error.GetBaseException());
    }

    [Fact]
    public async Task FeedContentIsRenderedSafely()
    {
        var response = await factory.CreateClient().GetAsync(DevlogFeed.Path);
        var raw = await response.Content.ReadAsStringAsync();
        var entries = XDocument.Parse(raw).Root!.Elements(Atom + "entry").ToList();
        var hostile = entries.Single(e => e.Element(Atom + "title")!.Value == "Post ostile").Element(Atom + "content")!.Value;
        var medio = entries.Single(e => e.Element(Atom + "title")!.Value == "Post medio").Element(Atom + "content")!.Value;

        // No live element sneaks into the XML, and the decoded HTML is what the post page shows.
        Assert.DoesNotContain("<script", raw, StringComparison.OrdinalIgnoreCase);
        Assert.DoesNotContain("javascript:", raw, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("&lt;script&gt;alert", hostile);
        Assert.Contains("<a href=\"#\">clicca</a>", hostile);
        Assert.Contains("<a href=\"/wiki/guida\">la wiki</a>", medio);
    }

    [Fact]
    public async Task LayoutAdvertisesTheFeed()
    {
        foreach (var path in new[] { "/", "/devlog", "/devlog/nuovo" })
        {
            var html = await factory.CreateClient().GetStringAsync(path);
            Assert.Contains("<link rel=\"alternate\" type=\"application/atom+xml\" title=\"Devlog di Soulslands\" href=\"/devlog/feed.xml\" />", html);
        }
    }

    [Fact]
    public async Task HomeShowsTheLatestThreePosts()
    {
        var html = await factory.CreateClient().GetStringAsync("/");

        Assert.Contains("Dal devlog", html);
        var positions = new[] { "Post nuovo", "Post medio", "Post vecchio" }.Select(t => html.IndexOf(t, StringComparison.Ordinal)).ToList();
        Assert.All(positions, p => Assert.True(p >= 0));
        Assert.Equal(positions.Order(), positions);
        Assert.DoesNotContain("Post ostile", html);
        Assert.Contains("href=\"/devlog/nuovo\"", html);
        Assert.Contains("<time datetime=\"2026-10-18\">18 ottobre 2026</time>", html);
        Assert.Contains("Riassunto di medio", html);
    }

    private static string? Link(XElement element, string rel) =>
        element.Elements(Atom + "link").FirstOrDefault(l => l.Attribute("rel")?.Value == rel)?.Attribute("href")?.Value;
}

public class DevlogFeedBuildTests
{
    [Fact]
    public void FeedKeepsAtMostTwentyNewestPosts()
    {
        var start = new DateOnly(2026, 1, 1);
        var posts = Enumerable.Range(0, 25)
            .Select(i => new DevlogPost($"post-{i}", $"Post {i}", start.AddDays(i), "Riassunto", "Aruto", "Testo"))
            .OrderByDescending(p => p.Date)
            .ToList();

        var entries = DevlogFeed.Build(posts, "https://example.org/").Root!
            .Elements(XNamespace.Get("http://www.w3.org/2005/Atom") + "entry").ToList();

        Assert.Equal(DevlogFeed.MaxEntries, entries.Count);
        Assert.Equal("https://example.org/devlog/post-24", entries[0].Elements().First().Value);
        Assert.Equal("https://example.org/devlog/post-5", entries[^1].Elements().First().Value);
    }
}
