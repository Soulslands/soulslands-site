using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Soulslands.Web.Services.Benchmarks;

namespace Soulslands.Web.Pages.Benchmark;

// One metric across milestones: a table per scenario and machine (ADR-0002 history key).
public class HistoryModel(BenchmarkStore store) : PageModel
{
    public string Metric { get; private set; } = "";

    public IReadOnlyList<BenchmarkSeries> Series { get; private set; } = [];

    public IActionResult OnGet(string metric)
    {
        if (!BenchmarkLoader.MetricNamePattern().IsMatch(metric))
        {
            return NotFound();
        }

        Series = BenchmarkHistory.ForMetric(store.Files, metric);
        if (Series.Count == 0)
        {
            return NotFound();
        }

        Metric = metric;
        return Page();
    }

    public static string Comparison(BenchmarkMetric m) =>
        $"confronto su {BenchmarkFormat.Stat(m.Compare!)}, {(m.Better == BenchmarkRules.BetterHigher ? "più alto è meglio" : "più basso è meglio")}";

    // Columns shown only when at least one point of the series has that statistic.
    public static IReadOnlyList<string> StatColumns(BenchmarkSeries series) =>
        [.. BenchmarkRules.Stats.Where(stat => series.Points.Any(p => BenchmarkRules.Stat(p.Metric, stat) is not null))];
}
