using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.StaticFiles;
using Soulslands.Web.Services.Benchmarks;

namespace Soulslands.Web.Pages.Benchmark;

// Serves the raw files a published result links (WikiContent/benchmark/<milestone>/raw/...).
// Only paths listed in a valid result of that milestone are served, always as a download.
public class RawModel(BenchmarkStore store) : PageModel
{
    private static readonly FileExtensionContentTypeProvider ContentTypes = new();

    public static bool IsServable(string path) => BenchmarkLoader.IsLocalRawPath(path);

    public IActionResult OnGet(string milestone, string? path)
    {
        var relative = $"raw/{path}";
        if (!BenchmarkLoader.MilestonePattern().IsMatch(milestone) || path is null || !IsServable(relative))
        {
            return NotFound();
        }

        var listed = store.ForMilestone(milestone)
            .Any(f => f.Result.Raw?.Any(r => r.Path == relative) == true);
        if (!listed)
        {
            return NotFound();
        }

        var file = store.RawFilePath(milestone, relative);
        if (file is null)
        {
            return NotFound();
        }

        if (!ContentTypes.TryGetContentType(file, out var contentType))
        {
            contentType = "application/octet-stream";
        }

        // A download, never rendered on the site's origin.
        return PhysicalFile(file, contentType, Path.GetFileName(file));
    }
}
