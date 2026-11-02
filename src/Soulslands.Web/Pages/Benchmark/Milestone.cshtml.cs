using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Soulslands.Web.Services.Benchmarks;

namespace Soulslands.Web.Pages.Benchmark;

public class MilestoneModel(BenchmarkStore store) : PageModel
{
    public string Milestone { get; private set; } = "";

    public IReadOnlyList<BenchmarkFile> Files { get; private set; } = [];

    public IActionResult OnGet(string milestone)
    {
        if (!BenchmarkLoader.MilestonePattern().IsMatch(milestone))
        {
            return NotFound();
        }

        Files = store.ForMilestone(milestone);
        if (Files.Count == 0)
        {
            return NotFound();
        }

        Milestone = milestone;
        return Page();
    }

    // Relative raw files under raw/ are served by /benchmark/<milestone>/raw/... when they are on
    // disk; https URLs are linked as they are; anything else is shown as text (not shipped with the site).
    public string? RawLink(BenchmarkRawFile raw)
    {
        var path = raw.Path ?? "";
        if (path.StartsWith("https://", StringComparison.Ordinal))
        {
            return path;
        }

        return RawModel.IsServable(path) && store.RawFilePath(Milestone, path) is not null
            ? $"/benchmark/{Milestone}/{path}"
            : null;
    }

    // A raw/... file the result lists but the site does not ship: the link would be dead.
    public bool IsRawMissing(BenchmarkRawFile raw)
    {
        var path = raw.Path ?? "";
        return RawModel.IsServable(path) && store.RawFilePath(Milestone, path) is null;
    }

    // Anchor id of one result on the page: <scenario>--<machine>, like the file name.
    public static string Anchor(BenchmarkResult result) => $"{result.Scenario!.Id}--{result.Hardware!.Machine}";
}
