using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging.Abstractions;
using Soulslands.Web.Services;

namespace Soulslands.Web.Tests;

public class WikiStoreTests : IDisposable
{
    private readonly string _dir = Directory.CreateTempSubdirectory("wiki-store-").FullName;

    public void Dispose()
    {
        Directory.Delete(_dir, recursive: true);
    }

    private void WriteFile(string name, string text)
    {
        var path = Path.Combine(_dir, name);
        Directory.CreateDirectory(Path.GetDirectoryName(path)!);
        File.WriteAllText(path, text);
    }

    private IReadOnlyList<WikiPage> Load() => WikiStore.Load(_dir, NullLogger.Instance);

    private const string Elf = """
        ---
        title: Elfo
        slug: razza-elfo
        category: Razze
        visibility: Pubblica
        ---
        # Elfo
        DEX cap 140.
        """;

    [Fact]
    public void ParsesFrontMatter()
    {
        var page = WikiStore.Parse(Elf);

        Assert.NotNull(page);
        Assert.Equal("razza-elfo", page.Slug);
        Assert.Equal("Elfo", page.Title);
        Assert.Equal("Razze", page.Category);
        Assert.StartsWith("# Elfo", page.Content);
        Assert.Equal(default, page.UpdatedAt);
    }

    [Theory]
    [InlineData("# senza front matter")]
    [InlineData("---\ntitle: Manca lo slug\n---\ntesto")]
    [InlineData("---\nslug: manca-il-titolo\n---\ntesto")]
    [InlineData("---\ntitle: Non chiuso\nslug: non-chiuso\n")]
    public void RejectsInvalidFiles(string text)
    {
        Assert.Null(WikiStore.Parse(text));
    }

    [Fact]
    public void LoadsEveryPageOfTheFolderAndItsSubfolders()
    {
        WriteFile("razza-elfo.md", Elf);
        WriteFile(Path.Combine("mondo", "alberi.md"), Elf.Replace("slug: razza-elfo", "slug: alberi").Replace("title: Elfo", "title: Alberi"));

        Assert.Equal(["alberi", "razza-elfo"], Load().Select(p => p.Slug).Order(StringComparer.Ordinal));
    }

    [Fact]
    public void SkipsInvalidSlugsAndKeepsTheFirstOfTwoPagesWithOneSlug()
    {
        WriteFile("a.md", Elf);
        WriteFile("b.md", Elf.Replace("title: Elfo", "title: Doppione"));
        WriteFile("c.md", Elf.Replace("slug: razza-elfo", "slug: Razza Elfo"));

        var page = Assert.Single(Load());
        Assert.Equal("Elfo", page.Title);
    }

    [Fact]
    public void SkipsDevlogPosts()
    {
        WriteFile(Path.Combine("devlog", "primo-post.md"), Elf.Replace("slug: razza-elfo", "slug: primo-post").Replace("visibility: Pubblica\n", ""));
        WriteFile("razza-elfo.md", Elf);

        Assert.Equal("razza-elfo", Assert.Single(Load()).Slug);
    }

    [Fact]
    public void OnlySkipsTheLowercaseDevlogFolder()
    {
        WriteFile(Path.Combine("Devlog", "pagina.md"), Elf);

        Assert.Equal("razza-elfo", Assert.Single(Load()).Slug);
    }

    // Fail closed (ADR-0035): a page that does not say exactly "visibility: Pubblica" stops the load,
    // naming the file, whatever else the folder holds.
    [Theory]
    [InlineData(SiteFactory.StaffPage)]
    [InlineData("---\ntitle: Senza visibilità\nslug: senza-visibilita\n---\ntesto")]
    [InlineData("---\ntitle: Chiave storta\nslug: chiave-storta\nvisibilità: Pubblica\n---\ntesto")]
    [InlineData("---\ntitle: Altro valore\nslug: altro-valore\nvisibility: Interna\n---\ntesto")]
    [InlineData("---\ntitle: Due righe\nslug: due-righe\nvisibility: Pubblica\nvisibility: Staff\n---\ntesto")]
    public void RefusesAPageThatIsNotPublic(string text)
    {
        WriteFile("razza-elfo.md", Elf);
        WriteFile(Path.Combine("note", "segreta.md"), text);

        var error = Assert.Throws<InvalidOperationException>(Load);

        Assert.Contains(Path.Combine(_dir, "note", "segreta.md"), error.Message);
    }

    // The site does not even start with a staff page in its wiki folder: dotnet run and the static
    // export stop before any page is served.
    [Fact]
    public void TheSiteDoesNotStartWithAStaffPage()
    {
        WriteFile("razza-elfo.md", Elf);
        WriteFile(SiteFactory.StaffSlug + ".md", SiteFactory.StaffPage);
        using var factory = new SiteFactory();
        var site = factory.WithWebHostBuilder(b => b.UseSetting("Wiki:Directory", _dir));

        var error = Assert.ThrowsAny<Exception>(() => site.CreateClient());

        Assert.Contains(SiteFactory.StaffSlug + ".md", error.GetBaseException().Message);
    }

    // Outside a Git repository there is no update date: the page shows no "Aggiornata il" line.
    [Fact]
    public async Task PagesOutsideGitHaveNoUpdateDate()
    {
        WriteFile("razza-elfo.md", Elf);
        Assert.Equal(default, Assert.Single(Load()).UpdatedAt);

        using var factory = new SiteFactory();
        var site = factory.WithWebHostBuilder(b => b.UseSetting("Wiki:Directory", _dir));
        var html = await site.CreateClient().GetStringAsync("/wiki/razza-elfo");

        Assert.Contains("DEX cap 140.", html);
        Assert.DoesNotContain("Aggiornata il", html);
    }

    // The real WikiContent is a Git checkout: every page carries its last commit's date.
    [Fact]
    public async Task PagesOfTheRepositoryShowTheirLastCommitDate()
    {
        using var site = new SiteFactory();
        var html = await site.CreateClient().GetStringAsync("/wiki/razze");

        Assert.Matches(@"Aggiornata il \d\d/\d\d/\d{4} \d\d:\d\d UTC\s*</small>", html);
        Assert.DoesNotContain("da sistema", html);
    }

    [Theory]
    [InlineData("razze-e-classi", true)]
    [InlineData("skill100", true)]
    [InlineData("Razze", false)]
    [InlineData("razze--classi", false)]
    [InlineData("-razze", false)]
    [InlineData("razze e classi", false)]
    [InlineData("", false)]
    [InlineData(null, false)]
    public void ValidatesSlugs(string? slug, bool expected)
    {
        Assert.Equal(expected, WikiStore.IsValidSlug(slug));
    }
}
