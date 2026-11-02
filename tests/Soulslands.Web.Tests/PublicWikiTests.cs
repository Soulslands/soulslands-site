using System.Text.RegularExpressions;
using Soulslands.Web.Services;

namespace Soulslands.Web.Tests;

// ADR-0035 section 2: this repository is public, so its wiki folder holds only public pages.
// Staff pages live in SoulslandsHQ `wiki/`. The check fails on any page that says
// `visibility: staff` (any case) and on any `/wiki/<slug>` link to a slug that is not here.
internal static partial class PublicWiki
{
    // The route words under /wiki/ that are not page slugs (Pages/Wiki).
    private static readonly HashSet<string> Routes = ["modifica"];

    [GeneratedRegex(@"^visibility:\s*staff\s*$", RegexOptions.IgnoreCase | RegexOptions.Multiline)]
    private static partial Regex StaffField();

    [GeneratedRegex(@"(?<![\w/.-])/wiki/([a-z0-9]+(?:-[a-z0-9]+)*)")]
    private static partial Regex WikiLink();

    public static List<string> Problems(string folder)
    {
        var files = Directory.EnumerateFiles(folder, "*.md", SearchOption.AllDirectories).Order().ToList();
        var slugs = new HashSet<string>();
        // Devlog posts are not wiki pages (WikiContentImporter skips their folder): their
        // links are checked, their slugs are not wiki slugs.
        var devlog = Path.Combine(folder, WikiContentImporter.DevlogFolder) + Path.DirectorySeparatorChar;
        foreach (var file in files.Where(f => !f.StartsWith(devlog, StringComparison.Ordinal)))
        {
            if (WikiContentImporter.Parse(File.ReadAllText(file)) is { } page)
            {
                slugs.Add(page.Slug);
            }
        }

        var problems = new List<string>();
        foreach (var file in files)
        {
            var name = Path.GetRelativePath(folder, file).Replace('\\', '/');
            var text = File.ReadAllText(file);
            if (StaffField().IsMatch(text))
            {
                problems.Add($"{name}: visibility: staff (staff pages live in SoulslandsHQ wiki/)");
            }

            foreach (Match link in WikiLink().Matches(text))
            {
                var slug = link.Groups[1].Value;
                if (!Routes.Contains(slug) && !slugs.Contains(slug))
                {
                    problems.Add($"{name}: link to /wiki/{slug}, a slug not in this repository");
                }
            }
        }
        return problems;
    }
}

public sealed class PublicWikiTests : IDisposable
{
    private static readonly string WikiContent =
        Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "../../../../../src/Soulslands.Web/WikiContent"));

    private readonly string _dir = Directory.CreateTempSubdirectory("public-wiki-").FullName;

    public void Dispose() => Directory.Delete(_dir, recursive: true);

    private void Write(string name, string text)
    {
        var path = Path.Combine(_dir, name);
        Directory.CreateDirectory(Path.GetDirectoryName(path)!);
        File.WriteAllText(path, text);
    }

    private static string Page(string slug, string body = "Testo.", string visibility = "Pubblica") => $"""
        ---
        title: Pagina {slug}
        slug: {slug}
        visibility: {visibility}
        ---
        {body}
        """;

    [Fact]
    public void TheRealWikiHasNoStaffPageAndNoBrokenLink()
    {
        Assert.True(Directory.Exists(WikiContent), WikiContent);
        Assert.True(Directory.EnumerateFiles(WikiContent, "*.md", SearchOption.AllDirectories).Count() > 100);
        Assert.Empty(PublicWiki.Problems(WikiContent));
    }

    [Fact]
    public void AFixtureOfPublicPagesPasses()
    {
        Write("generale/benvenuto.md", Page("benvenuto", "Vedi [la guida](/wiki/guida#inizio) e [la cronologia](/wiki/guida/cronologia)."));
        Write("generale/guida.md", Page("guida", "Torna a [benvenuto](/wiki/benvenuto) o alla [wiki](/wiki)."));
        Write("devlog/post.md", "---\ntitle: Post\nslug: post\n---\nLa [guida](/wiki/guida).");

        Assert.Empty(PublicWiki.Problems(_dir));
    }

    [Theory]
    [InlineData("Staff")]
    [InlineData("staff")]
    [InlineData("STAFF ")]
    public void AStaffPageFails(string visibility)
    {
        Write("generale/benvenuto.md", Page("benvenuto"));
        Write("sviluppo/segreto.md", Page("segreto", visibility: visibility));

        Assert.Equal(["sviluppo/segreto.md: visibility: staff (staff pages live in SoulslandsHQ wiki/)"], PublicWiki.Problems(_dir));
    }

    [Theory]
    [InlineData("[piano](/wiki/architettura-piano)")]
    [InlineData("[piano](/wiki/architettura-piano#m0)")]
    [InlineData("[storia](/wiki/architettura-piano/cronologia)")]
    [InlineData("<a href=\"/wiki/architettura-piano\">piano</a>")]
    public void ALinkToAMissingSlugFails(string link)
    {
        Write("generale/benvenuto.md", Page("benvenuto", "Vedi " + link + "."));

        Assert.Equal(["generale/benvenuto.md: link to /wiki/architettura-piano, a slug not in this repository"], PublicWiki.Problems(_dir));
    }

    [Fact]
    public void ALinkFromADevlogPostToAMissingSlugFails()
    {
        Write("generale/benvenuto.md", Page("benvenuto", "Vedi il [devlog](/devlog/post)."));
        Write("devlog/post.md", "---\ntitle: Post\nslug: post\n---\nIl [piano](/wiki/architettura-piano) e il [post](/wiki/post).");

        Assert.Equal(
            [
                "devlog/post.md: link to /wiki/architettura-piano, a slug not in this repository",
                "devlog/post.md: link to /wiki/post, a slug not in this repository",
            ],
            PublicWiki.Problems(_dir));
    }
}
