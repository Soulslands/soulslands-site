using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using Soulslands.Web.Data;
using Soulslands.Web.Services;

namespace Soulslands.Web.Tests;

public class WikiContentImporterTests : IDisposable
{
    private readonly SqliteConnection _connection = new("DataSource=:memory:");
    private readonly string _dir = Directory.CreateTempSubdirectory("wiki-import-").FullName;

    public WikiContentImporterTests()
    {
        _connection.Open();
    }

    public void Dispose()
    {
        _connection.Dispose();
        Directory.Delete(_dir, recursive: true);
    }

    private ApplicationDbContext NewDb()
    {
        var db = new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlite(_connection).Options);
        db.Database.EnsureCreated();
        return db;
    }

    private void WriteFile(string name, string text) => File.WriteAllText(Path.Combine(_dir, name), text);

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
        var page = WikiContentImporter.Parse(Elf);

        Assert.NotNull(page);
        Assert.Equal("razza-elfo", page.Slug);
        Assert.Equal("Elfo", page.Title);
        Assert.Equal("Razze", page.Category);
        Assert.Equal(WikiVisibility.Pubblica, page.Visibility);
        Assert.StartsWith("# Elfo", page.Content);
    }

    [Fact]
    public void ParsesStaffVisibility()
    {
        var page = WikiContentImporter.Parse("---\ntitle: Note\nslug: note\nvisibility: Staff\n---\ntesto");
        Assert.Equal(WikiVisibility.Staff, page!.Visibility);
    }

    [Theory]
    [InlineData("# senza front matter")]
    [InlineData("---\ntitle: Manca lo slug\n---\ntesto")]
    [InlineData("---\nslug: manca-il-titolo\n---\ntesto")]
    [InlineData("---\ntitle: Non chiuso\nslug: non-chiuso\n")]
    public void RejectsInvalidFiles(string text)
    {
        Assert.Null(WikiContentImporter.Parse(text));
    }

    [Fact]
    public async Task ImportsNewPagesAndUpdatesUneditedOnes()
    {
        WriteFile("razza-elfo.md", Elf);
        await using (var db = NewDb())
        {
            await WikiContentImporter.ImportAsync(db, _dir, NullLogger.Instance);
        }

        WriteFile("razza-elfo.md", Elf.Replace("DEX cap 140.", "DEX cap 150."));
        await using (var db = NewDb())
        {
            await WikiContentImporter.ImportAsync(db, _dir, NullLogger.Instance);
            var page = await db.WikiPages.Include(p => p.Revisions).SingleAsync();
            Assert.Contains("150", page.Content);
            Assert.Equal(2, page.Revisions.Count);
        }
    }

    [Fact]
    public async Task NeverOverwritesPagesEditedOnTheSite()
    {
        WriteFile("razza-elfo.md", Elf);
        await using (var db = NewDb())
        {
            await WikiContentImporter.ImportAsync(db, _dir, NullLogger.Instance);
            var page = await db.WikiPages.SingleAsync();
            page.Content = "Modificata dal moderatore";
            page.UpdatedBy = "mod@soulslands.test";
            await db.SaveChangesAsync();
        }

        WriteFile("razza-elfo.md", Elf.Replace("DEX cap 140.", "DEX cap 150."));
        await using (var db = NewDb())
        {
            await WikiContentImporter.ImportAsync(db, _dir, NullLogger.Instance);
            Assert.Equal("Modificata dal moderatore", (await db.WikiPages.SingleAsync()).Content);
        }
    }

    [Fact]
    public async Task SkipsInvalidSlugsAndDuplicates()
    {
        WriteFile("a.md", Elf);
        WriteFile("b.md", Elf.Replace("title: Elfo", "title: Doppione"));
        WriteFile("c.md", Elf.Replace("slug: razza-elfo", "slug: Razza Elfo"));
        await using var db = NewDb();

        await WikiContentImporter.ImportAsync(db, _dir, NullLogger.Instance);

        var page = await db.WikiPages.SingleAsync();
        Assert.Equal("Elfo", page.Title);
    }

    [Fact]
    public async Task SkipsDevlogPosts()
    {
        Directory.CreateDirectory(Path.Combine(_dir, "devlog"));
        File.WriteAllText(Path.Combine(_dir, "devlog", "primo-post.md"), Elf.Replace("slug: razza-elfo", "slug: primo-post"));
        WriteFile("razza-elfo.md", Elf);
        await using var db = NewDb();

        await WikiContentImporter.ImportAsync(db, _dir, NullLogger.Instance);

        var page = await db.WikiPages.SingleAsync();
        Assert.Equal("razza-elfo", page.Slug);
        Assert.False(await db.WikiPages.AnyAsync(p => p.Slug == "primo-post"));
    }

    [Fact]
    public async Task OnlySkipsTheLowercaseDevlogFolder()
    {
        Directory.CreateDirectory(Path.Combine(_dir, "Devlog"));
        File.WriteAllText(Path.Combine(_dir, "Devlog", "pagina.md"), Elf);
        await using var db = NewDb();

        await WikiContentImporter.ImportAsync(db, _dir, NullLogger.Instance);

        Assert.Equal("razza-elfo", (await db.WikiPages.SingleAsync()).Slug);
    }
}
