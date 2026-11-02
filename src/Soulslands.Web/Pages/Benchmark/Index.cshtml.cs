using Microsoft.AspNetCore.Mvc.RazorPages;
using Soulslands.Web.Services.Benchmarks;

namespace Soulslands.Web.Pages.Benchmark;

// Every published milestone, newest first, and every metric series with a link to its history.
public class IndexModel(BenchmarkStore store) : PageModel
{
    public IReadOnlyList<BenchmarkMilestone> Milestones { get; private set; } = [];

    public IReadOnlyList<BenchmarkSeries> Series { get; private set; } = [];

    public void OnGet()
    {
        Milestones = BenchmarkHistory.Milestones(store.Files);
        Series = BenchmarkHistory.Series(store.Files);
    }

    // Git's usual short form; the full SHA stays in the title attribute and on the milestone page.
    public static string ShortCommit(string commit) => commit[..7];
}
