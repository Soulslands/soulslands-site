using System.Text.Json;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Soulslands.StaticExport;
using Soulslands.Web.Services.Auth;

namespace Soulslands.Web.Tests;

// The static site of W-21 (scripts/build-static.sh): one export of a small fixture wiki
// (Fixtures/StaticWiki plus the benchmark fixtures), shared by the tests of this class.
public sealed class StaticExportFixture : IAsyncLifetime
{
    public string Wiki { get; } = StaticExportTests.FixtureWiki();
    public string Dist { get; } = Path.Combine(Path.GetTempPath(), $"soulslands-dist-{Guid.NewGuid():N}");
    public int ExitCode { get; private set; }
    public string Output { get; private set; } = "";
    public string Errors { get; private set; } = "";

    public async Task InitializeAsync() =>
        (ExitCode, Output, Errors) = await StaticExportTests.ExportAsync(Wiki, Dist);

    public Task DisposeAsync()
    {
        Directory.Delete(Wiki, recursive: true);
        if (Directory.Exists(Dist))
        {
            Directory.Delete(Dist, recursive: true);
        }
        return Task.CompletedTask;
    }
}

public class StaticExportTests(StaticExportFixture export) : IClassFixture<StaticExportFixture>
{
    private static readonly string Fixtures = Path.Combine(AppContext.BaseDirectory, "Fixtures");

    // The fixture wiki in a temporary folder: two public pages, one devlog post and two benchmark
    // milestones (one raw file); extra pages are written next to them.
    public static string FixtureWiki(params (string Name, string Text)[] extraPages)
    {
        var wiki = Directory.CreateTempSubdirectory("static-wiki-").FullName;
        Copy(Path.Combine(Fixtures, "StaticWiki"), wiki);
        foreach (var milestone in new[] { "m0", "m2" })
        {
            Copy(Path.Combine(Fixtures, "Benchmark", milestone), Path.Combine(wiki, "benchmark", milestone));
        }
        foreach (var (name, text) in extraPages)
        {
            File.WriteAllText(Path.Combine(wiki, name), text);
        }
        return wiki;
    }

    public static async Task<(int ExitCode, string Output, string Errors)> ExportAsync(string wiki, string dist)
    {
        using var output = new StringWriter();
        using var errors = new StringWriter();
        var code = await StaticExporter.RunAsync(new ExportOptions { OutputDirectory = dist, WikiDirectory = wiki }, output, errors);
        return (code, output.ToString(), errors.ToString());
    }

    private static void Copy(string from, string to)
    {
        Directory.CreateDirectory(to);
        foreach (var file in Directory.EnumerateFiles(from, "*", SearchOption.AllDirectories))
        {
            var target = Path.Combine(to, Path.GetRelativePath(from, file));
            Directory.CreateDirectory(Path.GetDirectoryName(target)!);
            File.Copy(file, target);
        }
    }

    private string Read(string relative) => File.ReadAllText(Path.Combine(export.Dist, relative));

    private IEnumerable<string> HtmlFiles() =>
        Directory.EnumerateFiles(export.Dist, "*.html", SearchOption.AllDirectories);

    [Fact]
    public void ExportWritesEveryPublicPage()
    {
        Assert.True(export.ExitCode == 0, export.Errors);
        foreach (var page in new[]
                 {
                     "index.html", "404.html", "_redirects", "_headers",
                     "Media/index.html", "Regole/index.html", "Stato/index.html",
                     "wiki/index.html", "wiki/lanterna-di-prova/index.html", "wiki/diagramma-di-prova/index.html",
                     "wiki/indice-ricerca.json",
                     "devlog/index.html", "devlog/post-statico/index.html", "devlog/feed.xml",
                     "benchmark/index.html", "benchmark/m0/index.html", "benchmark/m2/index.html",
                     "benchmark/m2/raw/wander-build--aruto-linux-pc.ticks.csv.gz",
                 })
        {
            Assert.True(File.Exists(Path.Combine(export.Dist, page)), page);
        }
        Assert.NotEmpty(Directory.GetDirectories(Path.Combine(export.Dist, "benchmark", "storia")));
        Assert.Contains("Pagine wiki esportate: 2 (file pubblici in WikiContent fuori da devlog/: 2)", export.Output);
        // The page with a diagram brings mermaid along; the 404 page is the site's own.
        Assert.Matches(@"<script src=""/lib/mermaid/mermaid[^""]*\.js""", Read("wiki/diagramma-di-prova/index.html"));
        Assert.Single(Directory.GetFiles(Path.Combine(export.Dist, "lib", "mermaid"), "mermaid*.js", SearchOption.AllDirectories));
        Assert.Contains("404", Read("404.html"));
        Assert.Contains("https://soulslands.mahoroba.studio/devlog/post-statico", Read("devlog/feed.xml"));
    }

    [Fact]
    public void ExportHasNoServerParts()
    {
        Assert.True(export.ExitCode == 0, export.Errors);
        foreach (var file in HtmlFiles())
        {
            var html = File.ReadAllText(file);
            foreach (var marker in StaticExporter.RuntimeMarkers)
            {
                Assert.False(html.Contains(marker, StringComparison.Ordinal), $"{file}: {marker}");
            }
            Assert.DoesNotContain("type=\"importmap\"", html);
            Assert.DoesNotMatch(@"<script(?![^>]*\ssrc=)[^>]*>", html);
        }
        foreach (var file in Directory.EnumerateFiles(export.Dist, "*", SearchOption.AllDirectories))
        {
            Assert.DoesNotContain("document.cookie", File.ReadAllText(file));
        }
        // The font choice is a footer switch whose script runs in <head>.
        var home = Read("index.html");
        Assert.Matches(@"<head>(?:(?!</head>).)*<script src=""/js/fonts[^""]*\.js""></script>", home.ReplaceLineEndings(" "));
        Assert.Contains("id=\"font-toggle\"", home);
    }

    [Fact]
    public void AnnouncementsAreReadInTheBrowser()
    {
        var home = Read("index.html");
        Assert.Matches(@"<section[^>]*id=""bacheca""[^>]*data-src=""https://account\.mahoroba\.studio/api/games/soulslands/announcements\?lang=en""[^>]*hidden", home);
        Assert.Matches(@"<script src=""/js/announcements[^""]*\.js""", home);
    }

    [Fact]
    public void RedirectsFileMatchesMovedPages()
    {
        var studio = new StudioOptions { AccountUrl = "https://account.mahoroba.studio", StudioUrl = "https://mahoroba.studio" };
        var expected = StudioSignIn.MovedPages
            .Select(p => $"{p.Path} {(p.OnAccountHost ? studio.Account(p.Target) : studio.Studio(p.Target))} 302")
            .Append("/Preferenze / 302");
        var lines = Read("_redirects").Split('\n', StringSplitOptions.RemoveEmptyEntries).Where(l => !l.StartsWith('#')).ToList();
        Assert.Equal(expected, lines.Where(l => l.EndsWith(" 302")));
        Assert.Contains("/Acquista https://account.mahoroba.studio/store 302", lines);
        // Pages matches paths case-sensitively; the dynamic site did not.
        Assert.Contains("/acquista https://account.mahoroba.studio/store 301", lines);
        Assert.Contains("/preferenze / 301", lines);
        Assert.Contains("/media /Media/ 301", lines);
        Assert.Contains("/regole /Regole/ 301", lines);
        Assert.Contains("/stato /Stato/ 301", lines);
        Assert.DoesNotContain(lines, l => l.StartsWith("/wiki ") || l.StartsWith("/devlog "));
    }

    [Fact]
    public void WranglerConfigServesDistAsStaticAssets()
    {
        var dir = new DirectoryInfo(AppContext.BaseDirectory);
        while (dir is not null && !File.Exists(Path.Combine(dir.FullName, "Soulslands.slnx")))
        {
            dir = dir.Parent;
        }
        Assert.NotNull(dir);
        using var config = JsonDocument.Parse(File.ReadAllText(Path.Combine(dir.FullName, "wrangler.jsonc")),
            new JsonDocumentOptions { CommentHandling = JsonCommentHandling.Skip, AllowTrailingCommas = true });
        var root = config.RootElement;
        // The Workers Builds project in Cloudflare's dashboard has this name; a different one fails the build.
        Assert.Equal("soulslands-site", root.GetProperty("name").GetString());
        Assert.False(root.TryGetProperty("main", out _), "assets only: no Worker script, so _headers and _redirects apply");
        // The dashboard runs only "npx wrangler deploy": wrangler itself must build dist/ first.
        Assert.Equal("bash scripts/build-static.sh", root.GetProperty("build").GetProperty("command").GetString());
        // The domain is attached in the dashboard; a clash with its DNS record would fail the deploy.
        Assert.False(root.TryGetProperty("routes", out _) || root.TryGetProperty("route", out _));
        var assets = root.GetProperty("assets");
        Assert.Equal("./dist", assets.GetProperty("directory").GetString());
        Assert.Equal("404-page", assets.GetProperty("not_found_handling").GetString());
        Assert.Equal("auto-trailing-slash", assets.GetProperty("html_handling").GetString());
        Assert.Matches(@"^\d{4}-\d{2}-\d{2}$", root.GetProperty("compatibility_date").GetString());
    }

    [Fact]
    public void ExportRefusesCultureWithoutIcuData()
    {
        Assert.Null(ExportCulture.Check(System.Globalization.CultureInfo.GetCultureInfo(ExportCulture.Name)));
        Assert.NotNull(ExportCulture.Check(System.Globalization.CultureInfo.InvariantCulture));
    }

    [Fact]
    public void HeadersFileSetsAPolicyWithoutInlineScripts()
    {
        var headers = Read("_headers");
        var block = Regex.Match(headers, @"^/\*\n((?:  .+\n)+)", RegexOptions.Multiline).Groups[1].Value;
        var csp = Regex.Match(block, "Content-Security-Policy: (.+)").Groups[1].Value;
        var directives = csp.Split(';', StringSplitOptions.TrimEntries).ToDictionary(d => d.Split(' ')[0], d => d);
        Assert.Equal("script-src 'self'", directives["script-src"]);
        Assert.Equal("default-src 'self'", directives["default-src"]);
        Assert.Equal("connect-src 'self' https://account.mahoroba.studio", directives["connect-src"]);
        Assert.Equal("object-src 'none'", directives["object-src"]);
        Assert.Equal("base-uri 'self'", directives["base-uri"]);
        Assert.Equal("frame-ancestors 'none'", directives["frame-ancestors"]);
        Assert.Contains("  X-Content-Type-Options: nosniff\n", block);
        Assert.Contains("  Referrer-Policy: strict-origin-when-cross-origin\n", block);
        Assert.Contains("  X-Frame-Options: DENY\n", block);
        Assert.Contains("  Permissions-Policy: camera=()", block.Replace("accelerometer=(), ", ""));
    }

    [Fact]
    public void SearchIndexListsEveryPublicPage()
    {
        using var index = JsonDocument.Parse(Read(StaticExporter.SearchIndexFile));
        var entries = index.RootElement.EnumerateArray().ToList();
        Assert.Equal(["diagramma-di-prova", "lanterna-di-prova"], entries.Select(e => e.GetProperty("slug").GetString()));
        var lantern = entries[1];
        Assert.Equal("Lanterna di prova", lantern.GetProperty("title").GetString());
        Assert.Equal("Prova", lantern.GetProperty("category").GetString());
        Assert.StartsWith("Una pagina della wiki di prova", lantern.GetProperty("text").GetString());
        Assert.DoesNotContain("flowchart", entries[0].GetProperty("text").GetString());
        Assert.Contains("id=\"wiki-search\"", Read("wiki/index.html"));
    }

    // First guard: a staff page in the WikiContent the export builds from stops it before anything is written.
    [Fact]
    public async Task StaffPageInTheSourceFailsTheBuild()
    {
        var wiki = FixtureWiki(("segreta.md", SiteFactory.StaffPage));
        var dist = Path.Combine(Path.GetTempPath(), $"soulslands-dist-{Guid.NewGuid():N}");
        try
        {
            var (code, _, errors) = await ExportAsync(wiki, dist);
            Assert.NotEqual(0, code);
            Assert.Contains(Path.Combine(wiki, "segreta.md"), errors);
            Assert.False(File.Exists(Path.Combine(dist, "index.html")));
        }
        finally
        {
            Directory.Delete(wiki, recursive: true);
            if (Directory.Exists(dist))
            {
                Directory.Delete(dist, recursive: true);
            }
        }
    }

    [Fact]
    public void StaffPageIsFoundEvenWhenTheImporterWouldRefuseIt()
    {
        var wiki = FixtureWiki(("rotta.md", "---\nvisibility: staff\n---\nSenza titolo né slug."));
        try
        {
            Assert.Equal([Path.Combine(wiki, "rotta.md")], StaffGuard.FindRefusedPages(wiki).Select(p => p.File));
        }
        finally
        {
            Directory.Delete(wiki, recursive: true);
        }
    }

    // Second guard: the scan of dist/ finds a staff page's title or slug in a page, the search JSON
    // and a sitemap, and the marker anywhere.
    [Fact]
    public void ScanOfDistFindsStaffNames()
    {
        var needles = StaffGuard.Needles([new StaffGuard.RefusedPage("segreta.md", "prova", SiteFactory.StaffSlug, "Pagina riservata")]);
        var dist = Directory.CreateTempSubdirectory("static-dist-").FullName;
        try
        {
            Directory.CreateDirectory(Path.Combine(dist, "wiki"));
            File.WriteAllText(Path.Combine(dist, "index.html"), "<html><body><h1>Pagina riservata</h1></body></html>");
            File.WriteAllText(Path.Combine(dist, "wiki", "indice-ricerca.json"), """[{"slug":"altro","title":"Pagina riservata"}]""");
            File.WriteAllText(Path.Combine(dist, "sitemap.xml"), $"<urlset><url><loc>https://x/wiki/{SiteFactory.StaffSlug}</loc></url></urlset>");
            File.WriteAllText(Path.Combine(dist, "feed.xml"), "<feed>visibility: Staff</feed>");
            File.WriteAllText(Path.Combine(dist, "pulita.html"), "<html><body>Niente di riservato</body></html>");

            var errors = StaticExporter.Verify(dist, needles, []);

            foreach (var file in new[] { "index.html", "wiki/indice-ricerca.json", "sitemap.xml", "feed.xml" })
            {
                Assert.Contains(errors, e => e.StartsWith("Nome di una pagina staff in dist: " + file.Replace('/', Path.DirectorySeparatorChar)));
            }
            Assert.DoesNotContain(errors, e => e.Contains("pulita.html"));
        }
        finally
        {
            Directory.Delete(dist, recursive: true);
        }
    }

    // The link check reads dist/ itself: a same-origin link without a file fails, naming link and
    // page; paths are case-sensitive, a _redirects source counts as a file.
    [Fact]
    public void VerifyFindsLinksWithoutAFile()
    {
        var dist = Directory.CreateTempSubdirectory("static-dist-").FullName;
        try
        {
            Directory.CreateDirectory(Path.Combine(dist, "media"));
            Directory.CreateDirectory(Path.Combine(dist, "wiki", "pagina"));
            File.WriteAllText(Path.Combine(dist, "media", "index.html"), "<p>media</p>");
            File.WriteAllText(Path.Combine(dist, "wiki", "pagina", "index.html"),
                """<a href="/media">ok</a> <a href="/Media">maiuscolo</a> <a href="../manca">relativo</a> <img src="/img/x.png"> <a href="/Download">spostata</a> <a href="https://altro.example/x">fuori</a>""");

            var errors = StaticExporter.Verify(dist, [], SiteFiles.RedirectSources);

            var page = Path.Combine("wiki", "pagina", "index.html");
            Assert.Equal(
            [
                $"Link senza file in dist: /Media (nella pagina {page})",
                $"Link senza file in dist: ../manca (nella pagina {page})",
                $"Link senza file in dist: /img/x.png (nella pagina {page})",
            ], errors);
        }
        finally
        {
            Directory.Delete(dist, recursive: true);
        }
    }

    [Fact]
    public void VerifyRefusesServerPartsAndCookies()
    {
        var dist = Directory.CreateTempSubdirectory("static-dist-").FullName;
        try
        {
            File.WriteAllText(Path.Combine(dist, "index.html"), "<header><a href=\"#\">Accedi</a></header><main>Testo</main>");
            Directory.CreateDirectory(Path.Combine(dist, "link"));
            Directory.CreateDirectory(Path.Combine(dist, "testo"));
            File.WriteAllText(Path.Combine(dist, "link", "index.html"), "<main><p>Vedi la <a href=\"/Admin/\">pagina</a></p></main>");
            File.WriteAllText(Path.Combine(dist, "testo", "index.html"),
                "<header><a href=\"/\">Home</a></header><main class=\"py-4\"><p>Esci dal gioco dalle Preferenze grafiche, lato client/Server.</p></main>");
            File.WriteAllText(Path.Combine(dist, "x.js"), "document.cookie = 'a=b';");

            var errors = StaticExporter.Verify(dist, [], []);

            Assert.Contains("index.html: contiene \"Accedi\", che il sito statico non può avere", errors);
            Assert.Contains("link/index.html: contiene \"/Admin/\", che il sito statico non può avere", errors);
            Assert.Contains("x.js: contiene document.cookie", errors);
            // The words in the text of a page are not the dynamic site's menu.
            Assert.DoesNotContain(errors, e => e.StartsWith("testo/"));
        }
        finally
        {
            Directory.Delete(dist, recursive: true);
        }
    }

    // During the export a page linking a missing page or file fails it, naming both.
    [Fact]
    public async Task BrokenLinkFailsTheExport()
    {
        var wiki = FixtureWiki(("rotta.md", "---\ntitle: Link rotti\nslug: link-rotti\nvisibility: Pubblica\n---\n[manca](/wiki/pagina-mancante) e ![x](/img/mancante.png)"));
        var dist = Path.Combine(Path.GetTempPath(), $"soulslands-dist-{Guid.NewGuid():N}");
        try
        {
            var (code, _, errors) = await ExportAsync(wiki, dist);
            Assert.NotEqual(0, code);
            Assert.Contains("/wiki/pagina-mancante (nella pagina /wiki/link-rotti/index.html)", errors);
            Assert.Contains("/img/mancante.png (nella pagina /wiki/link-rotti/index.html)", errors);
            // Nothing a manual "wrangler deploy" could upload after a failed export.
            Assert.False(Directory.Exists(dist));
        }
        finally
        {
            Directory.Delete(wiki, recursive: true);
            if (Directory.Exists(dist))
            {
                Directory.Delete(dist, recursive: true);
            }
        }
    }
    // The allow-list of the first guard: only "visibility: Pubblica" is published; the spellings the
    // importer would read as public get refused too, naming the file.
    [Theory]
    [InlineData("visibility: \" Staff\"")]
    [InlineData("visibilità: Staff")]
    [InlineData("Visibilita: Staff\nvisibility: Pubblica")]
    [InlineData("visibility: Riservata")]
    [InlineData("visibility: Pubblica\nvisibility: Bozza")]
    [InlineData("visibility:\n  Staff")]
    [InlineData("category: Prova")]
    public void OnlyPublicPagesPassTheSourceCheck(string frontMatterLines)
    {
        var wiki = FixtureWiki(("dubbia.md", $"---\ntitle: Pagina dubbia\nslug: pagina-dubbia\n{frontMatterLines}\n---\nTesto."));
        try
        {
            var refused = Assert.Single(StaffGuard.FindRefusedPages(wiki));
            Assert.Equal(Path.Combine(wiki, "dubbia.md"), refused.File);
            Assert.Equal("pagina-dubbia", refused.Slug);
        }
        finally
        {
            Directory.Delete(wiki, recursive: true);
        }
    }

    [Theory]
    [InlineData("", true)]
    [InlineData("visibility: Pubblica\n", true)]
    [InlineData("visibility: Staff\n", false)]
    [InlineData("visibilità: Pubblica\n", false)]
    public void DevlogPostsMaySayNothingOrPubblica(string visibility, bool published)
    {
        var text = $"---\ntitle: Post\nslug: post\ndate: 2026-11-20\n{visibility}---\nTesto.";
        Assert.Equal(published, StaffGuard.Refusal(text, isDevlog: true) is null);
    }

    // Every page of the real WikiContent says "visibility: Pubblica": the allow-list refuses none.
    [Fact]
    public void RealWikiContentPassesTheSourceCheck()
    {
        Assert.Empty(StaffGuard.FindRefusedPages(Path.Combine(RepositoryRoot(), "src", "Soulslands.Web", "WikiContent")));
    }

    [Fact]
    public async Task SourceRefusalFailsTheBuildForEachSpelling()
    {
        var wiki = FixtureWiki(("spazio.md", "---\ntitle: A\nslug: a-spazio\nvisibility: \" Staff\"\n---\nx"),
            ("accento.md", "---\ntitle: B\nslug: b-accento\nvisibilità: Staff\n---\nx"),
            ("riservata.md", "---\ntitle: C\nslug: c-riservata\nvisibility: Riservata\n---\nx"));
        var dist = Path.Combine(Path.GetTempPath(), $"soulslands-dist-{Guid.NewGuid():N}");
        try
        {
            var (code, _, errors) = await ExportAsync(wiki, dist);
            Assert.Equal(1, code);
            foreach (var name in new[] { "spazio.md", "accento.md", "riservata.md" })
            {
                Assert.Contains($"Pagina non pubblicabile nella wiki: {Path.Combine(wiki, name)}:", errors);
            }
            Assert.False(Directory.Exists(dist));
        }
        finally
        {
            Directory.Delete(wiki, recursive: true);
        }
    }

    // A page of the app that sets a cookie fails the export, naming the address.
    [Fact]
    public async Task ResponseWithACookieFailsTheExport()
    {
        var wiki = FixtureWiki();
        var dist = Path.Combine(Path.GetTempPath(), $"soulslands-dist-{Guid.NewGuid():N}");
        try
        {
            using var output = new StringWriter();
            using var errors = new StringWriter();
            var code = await StaticExporter.RunAsync(new ExportOptions
            {
                OutputDirectory = dist,
                WikiDirectory = wiki,
                ConfigureWebHost = builder => builder.ConfigureServices(services =>
                    services.AddSingleton<IStartupFilter, CookieOnMedia>()),
            }, output, errors);
            Assert.Equal(1, code);
            Assert.Contains("/Media imposta un cookie (Set-Cookie)", errors.ToString());
        }
        finally
        {
            Directory.Delete(wiki, recursive: true);
        }
    }

    private sealed class CookieOnMedia : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next) => app =>
        {
            app.Use(async (context, call) =>
            {
                if (context.Request.Path == "/Media")
                {
                    context.Response.Headers.SetCookie = "traccia=1; Path=/";
                }
                await call(context);
            });
            next(app);
        };
    }

    // A source page the importer drops (here an invalid slug) is missing from dist/: the counts differ.
    [Fact]
    public async Task PageMissingFromDistFailsTheExport()
    {
        var wiki = FixtureWiki(("persa.md", "---\ntitle: Pagina persa\nslug: Slug_Non_Valido\nvisibility: Pubblica\n---\nTesto."));
        var dist = Path.Combine(Path.GetTempPath(), $"soulslands-dist-{Guid.NewGuid():N}");
        try
        {
            var (code, _, errors) = await ExportAsync(wiki, dist);
            Assert.Equal(1, code);
            Assert.Contains("Pagine wiki esportate 2, ma i file pubblici in WikiContent (fuori da devlog/) sono 3", errors);
        }
        finally
        {
            Directory.Delete(wiki, recursive: true);
        }
    }

    // STATIC_OUT pointing at a folder of the user's: refused, and nothing in it is touched.
    [Fact]
    public async Task FolderThatIsNotAnExportIsLeftAlone()
    {
        var wiki = FixtureWiki();
        var folder = Directory.CreateTempSubdirectory("static-user-").FullName;
        try
        {
            File.WriteAllText(Path.Combine(folder, "tesi.txt"), "da non perdere");
            var (code, _, errors) = await ExportAsync(wiki, folder);
            Assert.Equal(2, code);
            Assert.Contains("non vengono da un'esportazione", errors);
            Assert.Equal("da non perdere", File.ReadAllText(Path.Combine(folder, "tesi.txt")));
            Assert.Equal([Path.Combine(folder, "tesi.txt")], Directory.EnumerateFileSystemEntries(folder));
        }
        finally
        {
            Directory.Delete(wiki, recursive: true);
            Directory.Delete(folder, recursive: true);
        }
    }

    // Two exports of the same source are byte-identical (the fixture is not in Git: no update times).
    [Fact]
    public async Task TwoExportsOfTheSameSourceAreIdentical()
    {
        var again = Path.Combine(Path.GetTempPath(), $"soulslands-dist-{Guid.NewGuid():N}");
        try
        {
            var (code, _, errors) = await ExportAsync(export.Wiki, again);
            Assert.True(code == 0, errors);
            var first = Directory.EnumerateFiles(export.Dist, "*", SearchOption.AllDirectories).Select(f => Path.GetRelativePath(export.Dist, f)).Order(StringComparer.Ordinal).ToList();
            var second = Directory.EnumerateFiles(again, "*", SearchOption.AllDirectories).Select(f => Path.GetRelativePath(again, f)).Order(StringComparer.Ordinal).ToList();
            Assert.Equal(first, second);
            foreach (var file in first)
            {
                Assert.True(File.ReadAllBytes(Path.Combine(export.Dist, file)).SequenceEqual(File.ReadAllBytes(Path.Combine(again, file))), file);
            }
            Assert.DoesNotContain("Aggiornata il", Read("wiki/lanterna-di-prova/index.html"));
        }
        finally
        {
            if (Directory.Exists(again))
            {
                Directory.Delete(again, recursive: true);
            }
        }
    }

    // "Aggiornata il" is the file's last commit; nothing in a shallow clone or outside Git.
    [Fact]
    public void UpdateTimesComeFromTheLastCommitOfEachFile()
    {
        var repo = Directory.CreateTempSubdirectory("static-git-").FullName;
        var shallow = Path.Combine(Path.GetTempPath(), $"static-git-shallow-{Guid.NewGuid():N}");
        try
        {
            Git(repo, null, "init", "-q");
            File.WriteAllText(Path.Combine(repo, "a.md"), "uno");
            File.WriteAllText(Path.Combine(repo, "b.md"), "uno");
            Git(repo, "2026-10-18T21:04:00+02:00", "add", ".");
            Git(repo, "2026-10-18T21:04:00+02:00", "commit", "-q", "-m", "uno");
            File.WriteAllText(Path.Combine(repo, "b.md"), "due");
            Git(repo, "2026-11-20T08:30:00Z", "commit", "-q", "-am", "due");
            File.WriteAllText(Path.Combine(repo, "c.md"), "mai committato");

            var dates = GitDates.LastCommits(repo);
            Assert.Equal(new DateTime(2026, 10, 18, 19, 4, 0, DateTimeKind.Utc), dates[Path.Combine(Path.GetFullPath(repo), "a.md")]);
            Assert.Equal(new DateTime(2026, 11, 20, 8, 30, 0, DateTimeKind.Utc), dates[Path.Combine(Path.GetFullPath(repo), "b.md")]);
            Assert.False(dates.ContainsKey(Path.Combine(Path.GetFullPath(repo), "c.md")));

            Git(Path.GetTempPath(), null, "clone", "-q", "--depth", "1", "file://" + repo, shallow);
            Assert.Empty(GitDates.LastCommits(shallow));
            Assert.Empty(GitDates.LastCommits(export.Wiki));
        }
        finally
        {
            Directory.Delete(repo, recursive: true);
            if (Directory.Exists(shallow))
            {
                Directory.Delete(shallow, recursive: true);
            }
        }
    }

    private static void Git(string directory, string? date, params string[] args)
    {
        var start = new System.Diagnostics.ProcessStartInfo("git") { UseShellExecute = false, RedirectStandardError = true, RedirectStandardOutput = true };
        foreach (var arg in new[] { "-C", directory, "-c", "user.name=Prova", "-c", "user.email=prova@example.invalid", "-c", "commit.gpgsign=false" }.Concat(args))
        {
            start.ArgumentList.Add(arg);
        }
        if (date is not null)
        {
            start.Environment["GIT_COMMITTER_DATE"] = date;
            start.Environment["GIT_AUTHOR_DATE"] = date;
        }
        using var process = System.Diagnostics.Process.Start(start)!;
        var err = process.StandardError.ReadToEnd();
        process.StandardOutput.ReadToEnd();
        process.WaitForExit();
        Assert.True(process.ExitCode == 0, $"git {string.Join(' ', args)}: {err}");
    }

    private static string RepositoryRoot()
    {
        var dir = new DirectoryInfo(AppContext.BaseDirectory);
        while (dir is not null && !File.Exists(Path.Combine(dir.FullName, "Soulslands.slnx")))
        {
            dir = dir.Parent;
        }
        return dir?.FullName ?? throw new InvalidOperationException("Soulslands.slnx non trovato");
    }
}
