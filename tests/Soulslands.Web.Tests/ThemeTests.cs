using System.Text.RegularExpressions;

namespace Soulslands.Web.Tests;

// Look and structure stay separate: colours live only in theme.css, so a new
// palette never means touching layout, pages or scripts.
public partial class ThemeTests
{
    private static readonly string WebRoot = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "../../../../../src/Soulslands.Web"));

    [GeneratedRegex(@"#[0-9a-fA-F]{3,8}\b|rgba?\(\s*\d|hsla?\(\s*\d")]
    private static partial Regex ColourLiteral();

    public static TheoryData<string> FilesWithoutColours()
    {
        var files = new TheoryData<string> { "wwwroot/css/site.css", "wwwroot/js/site.js", "wwwroot/js/wiki-diagrams.js" };
        foreach (var view in Directory.EnumerateFiles(Path.Combine(WebRoot, "Pages"), "*.cshtml", SearchOption.AllDirectories))
        {
            files.Add(Path.GetRelativePath(WebRoot, view));
        }
        return files;
    }

    [Theory]
    [MemberData(nameof(FilesWithoutColours))]
    public void ColoursOnlyComeFromTheTheme(string relativePath)
    {
        var text = File.ReadAllText(Path.Combine(WebRoot, relativePath));
        var literals = ColourLiteral().Matches(text).Select(m => m.Value).ToList();
        Assert.True(literals.Count == 0, $"{relativePath} has colour literals {string.Join(", ", literals)}; move them to wwwroot/css/theme.css");
    }

    [Fact]
    public void LayoutLoadsTheThemeBeforeTheSiteStyles()
    {
        var layout = File.ReadAllText(Path.Combine(WebRoot, "Pages/Shared/_Layout.cshtml"));
        Assert.True(layout.IndexOf("css/theme.css", StringComparison.Ordinal) is var theme and >= 0
            && theme < layout.IndexOf("css/site.css", StringComparison.Ordinal));
    }

    [GeneratedRegex(@"font-family:(?!\s*var\(--ss-font-)[^;]+;")]
    private static partial Regex FontLiteral();

    [Theory]
    [MemberData(nameof(FilesWithoutColours))]
    public void FontsOnlyComeFromTheTheme(string relativePath)
    {
        var text = File.ReadAllText(Path.Combine(WebRoot, relativePath));
        var literals = FontLiteral().Matches(text).Select(m => m.Value).ToList();
        Assert.True(literals.Count == 0, $"{relativePath} sets fonts directly ({string.Join(", ", literals)}); use the --ss-font-* variables from theme.css");
    }

    [Fact]
    public void FontsAreServedByTheSiteItself()
    {
        var layout = File.ReadAllText(Path.Combine(WebRoot, "Pages/Shared/_Layout.cshtml"));
        Assert.DoesNotContain("fonts.googleapis.com", layout);
        Assert.True(File.Exists(Path.Combine(WebRoot, "wwwroot/fonts/uo-classic.ttf")));
    }

    // An unclosed rule silently swallows every rule after it.
    [Theory]
    [InlineData("wwwroot/css/site.css")]
    [InlineData("wwwroot/css/theme.css")]
    public void StylesheetBracesAreBalanced(string relativePath)
    {
        var depth = 0;
        foreach (var c in Regex.Replace(File.ReadAllText(Path.Combine(WebRoot, relativePath)), @"/\*.*?\*/", "", RegexOptions.Singleline))
        {
            depth += c == '{' ? 1 : c == '}' ? -1 : 0;
            Assert.True(depth >= 0, $"{relativePath} closes a rule that was never opened");
        }
        Assert.True(depth == 0, $"{relativePath} has {depth} unclosed rule(s)");
    }
}
