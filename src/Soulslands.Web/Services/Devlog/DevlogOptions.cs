namespace Soulslands.Web.Services.Devlog;

public class DevlogOptions
{
    public const string Section = "Devlog";

    // Folder of the posts; relative paths start from the content root.
    // Empty means WikiContent/devlog, next to the wiki pages.
    public string? Directory { get; set; }
}
