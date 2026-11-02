using System.Text.Json;

namespace Soulslands.Web.Services.Benchmarks;

// One benchmark run in format v1 (SoulslandsGame docs/adr/0002-benchmark-result-v1.md).
// Field names map from snake_case JSON; unknown fields are ignored, as the ADR asks of readers.
// Everything is nullable here: BenchmarkLoader checks the required fields and refuses
// a file that misses one, so pages can rely on them afterwards.
public sealed record BenchmarkResult
{
    public int FormatVersion { get; init; }
    public string? Kind { get; init; }
    public string? Milestone { get; init; }
    public string? Repo { get; init; }
    public string? Commit { get; init; }
    public bool? Dirty { get; init; }
    public string? Date { get; init; }
    public BenchmarkProducer? Producer { get; init; }
    public BenchmarkHardware? Hardware { get; init; }
    public BenchmarkSoulslands? Soulslands { get; init; }
    public BenchmarkMinecraft? Minecraft { get; init; }
    public BenchmarkScenario? Scenario { get; init; }
    public List<BenchmarkMetric>? Metrics { get; init; }
    public List<BenchmarkRawFile>? Raw { get; init; }
    public string? Notes { get; init; }

    // A file without `repo` measures SoulslandsGame.
    public string RepoOrDefault => string.IsNullOrWhiteSpace(Repo) ? "SoulslandsGame" : Repo;

    // Set by the loader once `date` is validated.
    public DateTimeOffset StartedAt { get; init; }
}

public sealed record BenchmarkProducer(string? Name, string? Version);

public sealed record BenchmarkHardware
{
    public string? Machine { get; init; }
    public string? Model { get; init; }
    public string? Cpu { get; init; }
    public int? Cores { get; init; }
    public int? HostCores { get; init; }
    public long? RamMib { get; init; }
    public string? Gpu { get; init; }
    public string? Arch { get; init; }
    public string? Virtualization { get; init; }
    public BenchmarkOs? Os { get; init; }
}

public sealed record BenchmarkOs(string? Family, string? Name, string? Version, string? Kernel);

public sealed record BenchmarkSoulslands
{
    public string? GameVersion { get; init; }
    public string? SlworldTag { get; init; }
    public string? Rustc { get; init; }
    public string? Profile { get; init; }
    public List<string>? Features { get; init; }
    public Dictionary<string, JsonElement>? Settings { get; init; }
}

public sealed record BenchmarkMinecraft
{
    public string? Version { get; init; }
    public BenchmarkMinecraftServer? Server { get; init; }
    public BenchmarkJava? Java { get; init; }
    public BenchmarkMinecraftClient? Client { get; init; }
    public BenchmarkBots? Bots { get; init; }
    public Dictionary<string, JsonElement>? Settings { get; init; }
}

public sealed record BenchmarkMinecraftServer(string? Software, string? Version);

public sealed record BenchmarkJava
{
    public string? Vendor { get; init; }
    public string? Version { get; init; }
    public string? Gc { get; init; }
    public List<string>? Flags { get; init; }
}

public sealed record BenchmarkMinecraftClient(string? Renderer, List<BenchmarkClientMod>? Mods);

public sealed record BenchmarkClientMod(string? Id, string? Version);

public sealed record BenchmarkBots(string? Tool, string? Version);

public sealed record BenchmarkScenario
{
    public string? Id { get; init; }
    public ulong? Seed { get; init; }
    public double? DurationS { get; init; }
    public double? WarmupS { get; init; }
    public string? Script { get; init; }
    public int? Bots { get; init; }
    public Dictionary<string, JsonElement>? Parameters { get; init; }
}

// The statistics both sides share: p50, p99, max, or a single value.
public interface IBenchmarkStats
{
    double? P50 { get; }
    double? P99 { get; }
    double? Max { get; }
    double? Value { get; }
}

public sealed record BenchmarkMetric : IBenchmarkStats
{
    public string? Name { get; init; }
    public string? Unit { get; init; }
    public string? Better { get; init; }
    public string? Compare { get; init; }
    public long? Samples { get; init; }
    public double? P50 { get; init; }
    public double? P99 { get; init; }
    public double? Max { get; init; }
    public double? Value { get; init; }
    public List<BenchmarkThreshold>? Thresholds { get; init; }
    public BenchmarkMinecraftValue? Minecraft { get; init; }

    public bool HasOwnValue => P50 is not null || P99 is not null || Max is not null || Value is not null;
}

public sealed record BenchmarkThreshold(string? Stat, double? Value, string? Source);

public sealed record BenchmarkMinecraftValue : IBenchmarkStats
{
    public string? Origin { get; init; }
    public string? Source { get; init; }
    public long? Samples { get; init; }
    public double? P50 { get; init; }
    public double? P99 { get; init; }
    public double? Max { get; init; }
    public double? Value { get; init; }

    public bool IsEstimate => Origin == BenchmarkRules.OriginEstimate;
}

public sealed record BenchmarkRawFile(string? Path, string? Description, string? Sha256);

// A result file read from WikiContent/benchmark/<milestone>/<name>.json.
public sealed record BenchmarkFile(string Milestone, string FileName, BenchmarkResult Result);
