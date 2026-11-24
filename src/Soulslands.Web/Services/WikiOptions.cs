namespace Soulslands.Web.Services;

public class WikiOptions
{
    public const string Section = "Wiki";

    // Folder of the wiki pages; relative paths start from the content root. Empty means
    // WikiContent/ next to the app. The static export and the tests point it at other folders.
    public string? Directory { get; set; }
}
