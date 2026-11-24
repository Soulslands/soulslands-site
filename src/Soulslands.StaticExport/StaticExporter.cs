using System.Diagnostics;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Soulslands.Web.Services;
using Soulslands.Web.Services.Benchmarks;
using Soulslands.Web.Services.Devlog;

namespace Soulslands.StaticExport;

// Renders every public page of the site into a folder Cloudflare (or python3 -m http.server)
// serves as is: pages as <path>/index.html, the home page as index.html, the not-found page as
// 404.html, every other response (feed, raw benchmark files, wwwroot files) at its own path.
// Starts from the known routes, then follows every same-origin href, src and CSS url() it finds.
public static partial class StaticExporter
{
    public const string NotFoundProbe = "/pagina-che-non-esiste-404";

    public static readonly string SearchIndexFile = SearchIndex.Url.TrimStart('/');

    // Parts of the old dynamic site (removed in W-22) that must never come back (W-21 accept line).
    public static readonly string[] RuntimeMarkers =
        ["Accedi", "Esci", "/Account/", "/Admin/", "/Server", "/wiki/modifica", "/cronologia", "Preferenze", "__Host-Soulslands"];

    public const string CookieScript = "document.cookie";

    public static async Task<int> RunAsync(ExportOptions options, TextWriter output, TextWriter error)
    {
        var clock = Stopwatch.StartNew();
        if (!SiteOptions.IsValidBaseUrl(options.BaseUrl) || string.IsNullOrWhiteSpace(options.BaseUrl))
        {
            error.WriteLine($"SITE_BASE_URL non valido: {options.BaseUrl}");
            return 2;
        }
        var wiki = options.WikiDirectory is { Length: > 0 } given ? Path.GetFullPath(given) : FindWikiContent();
        if (wiki is null || !Directory.Exists(wiki))
        {
            error.WriteLine($"Cartella WikiContent non trovata: {wiki ?? "(cercata da " + Directory.GetCurrentDirectory() + ")"}");
            return 2;
        }

        // First guard: every source page says "visibility: Pubblica", before anything is rendered or written.
        var staff = StaffGuard.FindRefusedPages(wiki);
        if (staff.Count > 0)
        {
            foreach (var page in staff)
            {
                error.WriteLine($"Pagina non pubblicabile nella wiki: {page.File}: {page.Reason} (il sito statico è pubblico, ADR-0035)");
            }
            // An earlier export may hold the page while it was public: no deploy of it either.
            var earlier = Path.GetFullPath(options.OutputDirectory);
            if (File.Exists(Path.Combine(earlier, "_headers")))
            {
                Directory.Delete(earlier, recursive: true);
            }
            return 1;
        }

        var outputDirectory = Path.GetFullPath(options.OutputDirectory);
        if (!PrepareOutput(outputDirectory, error))
        {
            return 2;
        }

        var complete = false;
        try
        {
            var errors = new List<string>();
            int pageCount;
            int wikiPages;
            int wikiSources;
            List<string> topLevelPages;
            await using (var host = new ExportHost(wiki, options.BaseUrl.TrimEnd('/'), options.ConfigureWebHost))
            {
                var studio = host.Services.GetRequiredService<IOptions<StudioOptions>>().Value;
                var pages = host.Services.GetRequiredService<WikiStore>().Pages;

                var crawler = new Crawler(host, outputDirectory, SiteFiles.RedirectSources.ToHashSet(StringComparer.Ordinal), errors);
                foreach (var seed in Seeds(host.Services, pages))
                {
                    crawler.Enqueue(seed, "(pagina di partenza)");
                }
                await crawler.RunAsync();
                pageCount = crawler.Pages;

                topLevelPages = [.. Directory.GetDirectories(outputDirectory)
                    .Where(d => File.Exists(Path.Combine(d, "index.html")))
                    .Select(Path.GetFileName)
                    .OfType<string>()];
                File.WriteAllText(Path.Combine(outputDirectory, "_redirects"), SiteFiles.RedirectsFile(studio, topLevelPages));
                File.WriteAllText(Path.Combine(outputDirectory, "_headers"), SiteFiles.HeadersFile(studio));

                wikiPages = pages.Count(p => File.Exists(Path.Combine(outputDirectory, "wiki", p.Slug, "index.html")));
                wikiSources = PublicSourcePages(wiki);
            }

            // Checks of dist/ itself, as the browser and Cloudflare will see it.
            errors.AddRange(Verify(outputDirectory, StaffGuard.Needles(staff), SiteFiles.RedirectSources));
            foreach (var (path, target) in SiteFiles.LowercaseRedirects(SiteFiles.Redirects(new StudioOptions { AccountUrl = "https://a.invalid", StudioUrl = "https://s.invalid" }), topLevelPages)
                         .Where(r => r.Target.StartsWith('/')))
            {
                if (!Resolves(outputDirectory, target, new HashSet<string>(SiteFiles.RedirectSources)))
                {
                    errors.Add($"_redirects: {path} rimanda a {target}, che non esiste in dist");
                }
            }
            if (wikiPages != wikiSources)
            {
                errors.Add($"Pagine wiki esportate {wikiPages}, ma i file pubblici in WikiContent (fuori da devlog/) sono {wikiSources}: una pagina non valida o uno slug duplicato");
            }

            if (errors.Count > 0)
            {
                foreach (var line in errors)
                {
                    error.WriteLine(line);
                }
                error.WriteLine($"Esportazione fallita: {errors.Count} errori.");
                return 1;
            }

            var files = Directory.EnumerateFiles(outputDirectory, "*", SearchOption.AllDirectories).Select(f => new FileInfo(f)).ToList();
            output.WriteLine($"Pagine wiki esportate: {wikiPages} (file pubblici in WikiContent fuori da devlog/: {wikiSources})");
            output.WriteLine($"Pagine HTML: {pageCount}; file in {outputDirectory}: {files.Count}, {files.Sum(f => f.Length) / 1024.0 / 1024.0:0.0} MB");
            output.WriteLine($"Indice di ricerca: {new FileInfo(Path.Combine(outputDirectory, SearchIndexFile)).Length / 1024.0:0} KB");
            output.WriteLine($"Esportazione completata in {clock.Elapsed.TotalSeconds:0.0} s");
            complete = true;
            return 0;
        }
        finally
        {
            // A refused or broken export leaves no dist/ that a manual "wrangler deploy" could upload.
            if (!complete && Directory.Exists(outputDirectory))
            {
                Directory.Delete(outputDirectory, recursive: true);
            }
        }
    }

    // Problems in a finished dist/: same-origin links without a file, staff names, runtime parts,
    // cookies. Each entry names the file (and the link).
    public static IReadOnlyList<string> Verify(string outputDirectory, IReadOnlyList<string> staffNeedles, IEnumerable<string> redirectSources)
    {
        var errors = new List<string>();
        var redirects = redirectSources.ToHashSet(StringComparer.Ordinal);
        foreach (var file in Directory.EnumerateFiles(outputDirectory, "*", SearchOption.AllDirectories).Order(StringComparer.Ordinal))
        {
            var relative = Path.GetRelativePath(outputDirectory, file).Replace('\\', '/');
            var text = File.ReadAllText(file);
            if (text.Contains(CookieScript, StringComparison.Ordinal))
            {
                errors.Add($"{relative}: contiene {CookieScript}");
            }
            if (!relative.EndsWith(".html", StringComparison.Ordinal))
            {
                continue;
            }
            var layout = LayoutAndAttributes(text);
            foreach (var marker in RuntimeMarkers.Where(m => layout.Contains(m, StringComparison.Ordinal)))
            {
                errors.Add($"{relative}: contiene \"{marker}\", che il sito statico non può avere");
            }
            var pageUrl = relative == "404.html" ? "/" : "/" + relative[..^"index.html".Length];
            foreach (var link in Links.FromHtml(text, pageUrl))
            {
                if (!Resolves(outputDirectory, link.Path, redirects))
                {
                    errors.Add($"Link senza file in dist: {link.Raw} (nella pagina {relative})");
                }
            }
        }
        errors.AddRange(StaffGuard.ScanOutput(outputDirectory, staffNeedles).Select(hit => "Nome di una pagina staff in dist: " + hit));
        return errors;
    }

    // Where a runtime part of the dynamic site would show: the page without the text of its <main>
    // (header, menu, footer, scripts), plus every attribute value of the whole page (links, forms).
    // The text of a wiki page or post may say "Esci dal gioco" or "Preferenze grafiche".
    public static string LayoutAndAttributes(string html)
    {
        var withoutMain = MainElement().Replace(html, "<main></main>");
        var attributes = string.Join('\n', AttributeValue().Matches(html).Select(m => m.Groups[1].Value));
        return withoutMain + "\n" + attributes;
    }

    [GeneratedRegex(@"<main\b[^>]*>.*?</main>", RegexOptions.Singleline | RegexOptions.IgnoreCase)]
    private static partial Regex MainElement();

    [GeneratedRegex(@"\s[\w:.-]+\s*=\s*(""[^""]*""|'[^']*')")]
    private static partial Regex AttributeValue();

    // Whether Cloudflare and http.server answer this path from dist/: a file, a folder with
    // index.html (both redirect <path> to <path>/), or a _redirects rule.
    public static bool Resolves(string outputDirectory, string path, IReadOnlySet<string> redirects)
    {
        if (redirects.Contains(path) || redirects.Contains(path.TrimEnd('/')))
        {
            return true;
        }
        var file = SafeFile(outputDirectory, path);
        if (file is null)
        {
            return false;
        }
        return path.EndsWith('/')
            ? File.Exists(Path.Combine(file, "index.html"))
            : File.Exists(file) || File.Exists(Path.Combine(file, "index.html"));
    }

    // The file a URL path maps to inside dist/, or null for a path that would leave it.
    public static string? SafeFile(string outputDirectory, string path)
    {
        string decoded;
        try
        {
            decoded = Uri.UnescapeDataString(path);
        }
        catch (UriFormatException)
        {
            return null;
        }
        var segments = decoded.Split('/', StringSplitOptions.RemoveEmptyEntries);
        if (segments.Any(s => s is "." or ".." || s.Contains('\\') || s.Contains('\0')))
        {
            return null;
        }
        var full = Path.GetFullPath(Path.Combine([outputDirectory, .. segments]));
        var root = outputDirectory.TrimEnd(Path.DirectorySeparatorChar) + Path.DirectorySeparatorChar;
        return full == outputDirectory.TrimEnd(Path.DirectorySeparatorChar) || full.StartsWith(root, StringComparison.Ordinal) ? full : null;
    }

    private static IEnumerable<string> Seeds(IServiceProvider services, IEnumerable<WikiPage> pages)
    {
        var links = services.GetRequiredService<LinkGenerator>();
        string Page(string page, object? values = null) =>
            links.GetPathByPage(page, values: values) ?? throw new InvalidOperationException($"Nessun indirizzo per {page}");

        yield return "/";
        yield return Page("/Media");
        yield return Page("/Regole");
        yield return Page("/Stato");
        yield return Page("/Wiki/Index");
        yield return SearchIndex.Url;
        foreach (var page in pages.OrderBy(p => p.Slug, StringComparer.Ordinal))
        {
            yield return Page("/Wiki/View", new { slug = page.Slug });
        }
        yield return Page("/Devlog/Index");
        foreach (var post in services.GetRequiredService<DevlogStore>().Posts)
        {
            yield return Page("/Devlog/Post", new { slug = post.Slug });
        }
        yield return DevlogFeed.Path;
        var benchmarks = services.GetRequiredService<BenchmarkStore>();
        yield return Page("/Benchmark/Index");
        foreach (var milestone in BenchmarkHistory.Milestones(benchmarks.Files))
        {
            yield return Page("/Benchmark/Milestone", new { milestone = milestone.Milestone });
        }
        foreach (var metric in BenchmarkHistory.Series(benchmarks.Files).Select(s => s.Metric).Distinct())
        {
            yield return Page("/Benchmark/History", new { metric });
        }
        foreach (var file in benchmarks.Files)
        {
            foreach (var raw in file.Result.Raw ?? [])
            {
                if (raw.Path is { } path && benchmarks.RawFilePath(file.Milestone, path) is not null)
                {
                    yield return $"/benchmark/{Uri.EscapeDataString(file.Milestone)}/{string.Join('/', path.Split('/').Select(Uri.EscapeDataString))}";
                }
            }
        }
    }

    private static int PublicSourcePages(string wiki) =>
        Directory.EnumerateFiles(wiki, "*.md", SearchOption.AllDirectories).Count(f => !PublicPages.IsDevlogFile(wiki, f));


    private static string? FindWikiContent()
    {
        for (var dir = new DirectoryInfo(Directory.GetCurrentDirectory()); dir is not null; dir = dir.Parent)
        {
            var candidate = Path.Combine(dir.FullName, "src", "Soulslands.Web", "WikiContent");
            if (File.Exists(Path.Combine(dir.FullName, "Soulslands.slnx")) && Directory.Exists(candidate))
            {
                return candidate;
            }
        }
        return null;
    }

    // Empties the output folder; refuses one that holds files and no _headers (not an earlier export).
    private static bool PrepareOutput(string outputDirectory, TextWriter error)
    {
        if (Directory.Exists(outputDirectory))
        {
            if (Directory.EnumerateFileSystemEntries(outputDirectory).Any()
                && !File.Exists(Path.Combine(outputDirectory, "_headers")))
            {
                error.WriteLine($"{outputDirectory} contiene file che non vengono da un'esportazione: scegli un'altra cartella.");
                return false;
            }
            Directory.Delete(outputDirectory, recursive: true);
        }
        Directory.CreateDirectory(outputDirectory);
        return true;
    }

    // Fetches pages and files breadth first and writes each one once.
    private sealed class Crawler(ExportHost host, string outputDirectory, IReadOnlySet<string> redirects, List<string> errors)
    {
        private readonly HttpClient _client = host.CreateClient(new WebApplicationFactoryClientOptions
        {
            AllowAutoRedirect = false,
            HandleCookies = false,
            BaseAddress = new Uri("https://localhost"),
        });
        private readonly Queue<(string Url, string From)> _queue = new();
        private readonly HashSet<string> _seen = new(StringComparer.Ordinal);

        public int Pages { get; private set; }

        public void Enqueue(string url, string from)
        {
            var path = url.Split('?')[0];
            if (redirects.Contains(path) || !_seen.Add(path))
            {
                return;
            }
            _queue.Enqueue((url, from));
        }

        public async Task RunAsync()
        {
            await FetchAsync(NotFoundProbe, "(pagina 404)", HttpStatusCode.NotFound);
            while (_queue.TryDequeue(out var item))
            {
                await FetchAsync(item.Url, item.From, HttpStatusCode.OK);
            }
        }

        private async Task FetchAsync(string url, string from, HttpStatusCode expected)
        {
            using var response = await _client.GetAsync(url);
            if (response.Headers.Contains("Set-Cookie"))
            {
                errors.Add($"{url} imposta un cookie (Set-Cookie), che il sito statico non può avere");
            }
            if (response.StatusCode != expected)
            {
                errors.Add($"Link rotto: {url} (nella pagina {from}) risponde {(int)response.StatusCode}");
                return;
            }

            var path = url.Split('?')[0];
            var isHtml = response.Content.Headers.ContentType?.MediaType == "text/html";
            var relative = expected == HttpStatusCode.NotFound ? "404.html"
                : isHtml ? (path == "/" ? "index.html" : path.Trim('/') + "/index.html")
                : path.TrimStart('/');
            if (!isHtml && path.EndsWith('/'))
            {
                errors.Add($"{url} (nella pagina {from}) non è una pagina ma finisce con /");
                return;
            }
            var file = SafeFile(outputDirectory, "/" + relative);
            if (file is null)
            {
                errors.Add($"Indirizzo fuori da dist: {url} (nella pagina {from})");
                return;
            }
            Directory.CreateDirectory(Path.GetDirectoryName(file)!);
            var bytes = await response.Content.ReadAsByteArrayAsync();
            await File.WriteAllBytesAsync(file, bytes);

            var pageName = "/" + relative;
            if (isHtml)
            {
                Pages++;
                var pageUrl = expected == HttpStatusCode.NotFound ? "/" : path == "/" ? "/" : path.TrimEnd('/') + "/";
                foreach (var link in Links.FromHtml(Encoding.UTF8.GetString(bytes), pageUrl))
                {
                    Enqueue(link.Query is null ? link.Path : link.Path + "?" + link.Query, pageName);
                }
            }
            else if (response.Content.Headers.ContentType?.MediaType == "text/css")
            {
                foreach (var link in Links.FromCss(Encoding.UTF8.GetString(bytes), path))
                {
                    Enqueue(link.Query is null ? link.Path : link.Path + "?" + link.Query, pageName);
                }
            }
        }
    }
}
