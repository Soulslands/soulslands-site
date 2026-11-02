namespace Soulslands.Web.Services.Benchmarks;

// One published milestone on the index: its files and the date of its latest run.
public sealed record BenchmarkMilestone(string Milestone, IReadOnlyList<BenchmarkFile> Files)
{
    public DateTimeOffset LatestRun => Files.Max(f => f.Result.StartedAt);
}

// One measurement of a metric: the row and the file it comes from.
public sealed record BenchmarkPoint(BenchmarkFile File, BenchmarkMetric Metric);

// The same metric of the same scenario on the same machine, across milestones (ADR-0002:
// history groups rows by scenario.id + hardware.machine + metric name). Points are ordered
// by milestone, oldest first, then by run date.
public sealed record BenchmarkSeries(string Metric, string Scenario, string Machine, IReadOnlyList<BenchmarkPoint> Points)
{
    public IEnumerable<string> Milestones => Points.Select(p => p.File.Milestone).Distinct();

    public BenchmarkPoint Latest => Points[^1];
}

// Index and history views over the published files; no state of its own.
public static class BenchmarkHistory
{
    // Every milestone with at least one valid file, newest milestone first.
    public static IReadOnlyList<BenchmarkMilestone> Milestones(IReadOnlyList<BenchmarkFile> files) =>
        [.. files
            .GroupBy(f => f.Milestone)
            .OrderByDescending(g => BenchmarkLoader.MilestoneNumber(g.Key))
            .Select(g => new BenchmarkMilestone(g.Key, [.. g]))];

    // Every series, ordered by metric name, scenario and machine.
    public static IReadOnlyList<BenchmarkSeries> Series(IReadOnlyList<BenchmarkFile> files) =>
        [.. files
            .SelectMany(f => f.Result.Metrics!.Select(m => new BenchmarkPoint(f, m)))
            .GroupBy(p => (Metric: p.Metric.Name!, Scenario: p.File.Result.Scenario!.Id!, Machine: p.File.Result.Hardware!.Machine!))
            .OrderBy(g => g.Key.Metric, StringComparer.Ordinal)
            .ThenBy(g => g.Key.Scenario, StringComparer.Ordinal)
            .ThenBy(g => g.Key.Machine, StringComparer.Ordinal)
            .Select(g => new BenchmarkSeries(g.Key.Metric, g.Key.Scenario, g.Key.Machine,
                [.. g.OrderBy(p => BenchmarkLoader.MilestoneNumber(p.File.Milestone))
                     .ThenBy(p => p.File.Result.StartedAt)
                     .ThenBy(p => p.File.FileName, StringComparer.Ordinal)]))];

    public static IReadOnlyList<BenchmarkSeries> ForMetric(IReadOnlyList<BenchmarkFile> files, string metric) =>
        [.. Series(files).Where(s => s.Metric == metric)];
}
