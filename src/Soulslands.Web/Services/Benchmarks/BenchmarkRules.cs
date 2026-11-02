namespace Soulslands.Web.Services.Benchmarks;

public enum ThresholdStatus
{
    Met,
    Missed,
    NotMeasured,
}

// The reading rules of ADR-0002 ("Rules every reader applies the same way"), shared
// with the regression gate (M0-19) so pages and gate never disagree.
public static class BenchmarkRules
{
    public const int SupportedFormatVersion = 1;

    public const string BetterLower = "lower";
    public const string BetterHigher = "higher";
    public const string OriginMeasured = "measured";
    public const string OriginEstimate = "estimate";

    public static readonly string[] Stats = ["p50", "p99", "max", "value"];

    public static double? Stat(IBenchmarkStats stats, string? stat) => stat switch
    {
        "p50" => stats.P50,
        "p99" => stats.P99,
        "max" => stats.Max,
        "value" => stats.Value,
        _ => null,
    };

    // "≤ threshold" for lower-is-better rows, "≥" for higher-is-better ones; a statistic
    // our side did not measure is "not measured", never a failure.
    public static ThresholdStatus Check(BenchmarkMetric metric, BenchmarkThreshold threshold)
    {
        if (Stat(metric, threshold.Stat) is not { } ours || threshold.Value is not { } limit)
        {
            return ThresholdStatus.NotMeasured;
        }

        var met = metric.Better == BetterHigher ? ours >= limit : ours <= limit;
        return met ? ThresholdStatus.Met : ThresholdStatus.Missed;
    }

    // Both sides have the `compare` statistic and Minecraft's is strictly better. Ties are not wins.
    public static bool MinecraftWins(BenchmarkMetric metric)
    {
        if (metric.Minecraft is null
            || Stat(metric, metric.Compare) is not { } ours
            || Stat(metric.Minecraft, metric.Compare) is not { } theirs)
        {
            return false;
        }

        return metric.Better == BetterHigher ? theirs > ours : theirs < ours;
    }

    // The file has Minecraft numbers to compare with (a version block or any row value).
    public static bool HasMinecraftSide(BenchmarkResult result) =>
        result.Minecraft is not null || result.Metrics?.Any(m => m.Minecraft is not null) == true;
}
