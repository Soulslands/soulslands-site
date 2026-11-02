using System.Net;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Soulslands.Web.Services.Benchmarks;

namespace Soulslands.Web.Tests;

// Fixtures are the ADR-0002 examples (tests/Soulslands.Web.Tests/Fixtures/Benchmark/README.md);
// tests never read or write src/Soulslands.Web/WikiContent/benchmark/.
internal static class BenchmarkFixtures
{
    public static readonly string Root = Path.Combine(AppContext.BaseDirectory, "Fixtures", "Benchmark");

    public const string WanderBuild = "m2/wander-build--aruto-linux-pc.json";
    public const string ChunkGeneration = "m0/chunk-generation--aruto-linux-pc.json";
    public const string BuildSpeed = "m0/build-leaf-relaunch--aruto-linux-pc.json";
    // Derived, not an ADR example: the chunk-generation run again in m2, for the history view.
    public const string ChunkGenerationM2 = "m2/chunk-generation--aruto-linux-pc.json";

    public static string Text(string relative) => File.ReadAllText(Path.Combine(Root, relative));

    public static JsonObject Node(string relative) => JsonNode.Parse(Text(relative))!.AsObject();

    // Writes <dir>/<milestone>/<name> and returns its full path.
    public static string Write(string dir, string milestone, string name, string text)
    {
        var folder = Directory.CreateDirectory(Path.Combine(dir, milestone)).FullName;
        var path = Path.Combine(folder, name);
        File.WriteAllText(path, text);
        return path;
    }
}

internal sealed class ListLogger : ILogger
{
    public List<string> Warnings { get; } = [];

    public IDisposable? BeginScope<TState>(TState state) where TState : notnull => null;

    public bool IsEnabled(LogLevel logLevel) => true;

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        if (logLevel >= LogLevel.Warning)
        {
            Warnings.Add(formatter(state, exception));
        }
    }
}

public sealed class BenchmarkLoaderTests : IDisposable
{
    private readonly string _dir = Directory.CreateTempSubdirectory("benchmark-").FullName;

    public void Dispose() => Directory.Delete(_dir, recursive: true);

    private string Bench => Path.Combine(_dir, "WikiContent", "benchmark");

    [Fact]
    public void ParsesEveryFieldOfTheBotSwarmExample()
    {
        var r = BenchmarkLoader.Parse(BenchmarkFixtures.Text(BenchmarkFixtures.WanderBuild), out var error);

        Assert.Null(error);
        Assert.NotNull(r);
        Assert.Equal("bot-swarm", r.Kind);
        Assert.Equal("m2", r.Milestone);
        Assert.Equal("SoulslandsGame", r.RepoOrDefault);
        Assert.Equal("0123456789abcdef0123456789abcdef01234567", r.Commit);
        Assert.Equal(new DateTimeOffset(2026, 10, 18, 21, 4, 0, TimeSpan.Zero), r.StartedAt);
        Assert.Equal(4, r.Hardware!.Cores);
        Assert.Equal(32, r.Hardware.HostCores);
        Assert.Equal(8192, r.Hardware.RamMib);
        Assert.Equal("CachyOS", r.Hardware.Os!.Name);
        Assert.Equal("v0.9.0", r.Soulslands!.SlworldTag);
        Assert.Equal("paper", r.Minecraft!.Server!.Software);
        Assert.Equal("25.0.1", r.Minecraft.Java!.Version);
        Assert.Equal(5, r.Minecraft.Java.Flags!.Count);
        Assert.Equal(1997UL, r.Scenario!.Seed);
        Assert.Equal(60, r.Scenario.WarmupS);
        Assert.Equal(4, r.Metrics!.Count);
        Assert.Equal(14.8, r.Metrics[0].P99);
        Assert.Equal(2, r.Metrics[0].Thresholds!.Count);
        Assert.Equal(145.0, r.Metrics[0].Minecraft!.P99);
        Assert.Equal(2, r.Raw!.Count);
    }

    [Fact]
    public void LoadsEveryExampleOrderedByMilestone()
    {
        var files = BenchmarkLoader.Load(BenchmarkFixtures.Root, NullLogger.Instance);

        Assert.Equal(
            ["m0/build-leaf-relaunch", "m0/criterion-chunk-generation", "m2/criterion-chunk-generation", "m2/wander-build"],
            files.Select(f => $"{f.Milestone}/{f.Result.Scenario!.Id}"));
    }

    [Fact]
    public void ReadsTheRepoField()
    {
        var node = BenchmarkFixtures.Node(BenchmarkFixtures.ChunkGeneration);
        node["repo"] = "SLWorldLib";

        Assert.Equal("SLWorldLib", BenchmarkLoader.Parse(node.ToJsonString(), out _)!.RepoOrDefault);
    }

    [Fact]
    public void RefusesANewerFormatVersionWithAnItalianLineNamingTheFileAndBothVersions()
    {
        var node = BenchmarkFixtures.Node(BenchmarkFixtures.WanderBuild);
        node["format_version"] = 2;
        BenchmarkFixtures.Write(Bench, "m2", "siege--node16.json", node.ToJsonString());
        BenchmarkFixtures.Write(Bench, "m2", "wander-build--aruto-linux-pc.json", BenchmarkFixtures.Text(BenchmarkFixtures.WanderBuild));
        var logger = new ListLogger();

        var files = BenchmarkLoader.Load(Bench, logger);

        Assert.Equal("wander-build--aruto-linux-pc.json", Assert.Single(files).FileName);
        var line = Assert.Single(logger.Warnings);
        Assert.Equal("risultato benchmark WikiContent/benchmark/m2/siege--node16.json: format_version 2 è più recente di quello che il sito conosce (1); aggiornare il sito", line);
    }

    [Theory]
    [InlineData("0")]
    [InlineData("\"1\"")]
    [InlineData("1.5")]
    [InlineData("null")]
    public void RefusesOtherFormatVersions(string version)
    {
        var node = BenchmarkFixtures.Node(BenchmarkFixtures.WanderBuild);
        node["format_version"] = JsonNode.Parse(version);

        Assert.Null(BenchmarkLoader.Parse(node.ToJsonString(), out var error));
        Assert.Contains("format_version", error);
    }

    [Fact]
    public void RefusesAFileWithoutFormatVersion()
    {
        var node = BenchmarkFixtures.Node(BenchmarkFixtures.WanderBuild);
        node.Remove("format_version");

        Assert.Null(BenchmarkLoader.Parse(node.ToJsonString(), out var error));
        Assert.Contains("format_version", error);
    }

    [Theory]
    [InlineData("kind")]
    [InlineData("milestone")]
    [InlineData("commit")]
    [InlineData("date")]
    [InlineData("hardware")]
    [InlineData("scenario")]
    [InlineData("metrics")]
    [InlineData("soulslands")]
    [InlineData("minecraft")]
    public void RefusesAMissingRequiredField(string field)
    {
        var node = BenchmarkFixtures.Node(BenchmarkFixtures.WanderBuild);
        node.Remove(field);

        Assert.Null(BenchmarkLoader.Parse(node.ToJsonString(), out var error));
        Assert.Contains(field, error);
    }

    [Theory]
    [InlineData("hardware", "cpu")]
    [InlineData("hardware", "os")]
    [InlineData("scenario", "seed")]
    [InlineData("scenario", "script")]
    [InlineData("soulslands", "rustc")]
    public void RefusesAMissingNestedField(string parent, string field)
    {
        var node = BenchmarkFixtures.Node(BenchmarkFixtures.WanderBuild);
        node[parent]!.AsObject().Remove(field);

        Assert.Null(BenchmarkLoader.Parse(node.ToJsonString(), out var error));
        Assert.Contains($"{parent}.{field}", error);
    }

    [Theory]
    [InlineData("commit", "\"abc123\"")]
    [InlineData("date", "\"2026-10-18 21:04\"")]
    [InlineData("date", "\"2026-10-18T21:04:00\"")]
    [InlineData("milestone", "\"M2\"")]
    [InlineData("metrics", "[]")]
    public void RefusesAnInvalidValue(string field, string json)
    {
        var node = BenchmarkFixtures.Node(BenchmarkFixtures.WanderBuild);
        node[field] = JsonNode.Parse(json);

        Assert.Null(BenchmarkLoader.Parse(node.ToJsonString(), out var error));
        Assert.Contains(field, error);
    }

    [Fact]
    public void RefusesAnEstimateWithoutSourceAndAWronglyTypedField()
    {
        var node = BenchmarkFixtures.Node(BenchmarkFixtures.ChunkGeneration);
        node["metrics"]![1]!["minecraft"]!.AsObject().Remove("source");
        Assert.Null(BenchmarkLoader.Parse(node.ToJsonString(), out var error));
        Assert.Contains("stima", error);

        node = BenchmarkFixtures.Node(BenchmarkFixtures.ChunkGeneration);
        node["hardware"]!["cores"] = "thirty-two";
        Assert.Null(BenchmarkLoader.Parse(node.ToJsonString(), out error));
        Assert.Contains("cores", error);
    }

    [Fact]
    public void IgnoresUnknownFieldsAndShowsAnUnknownKind()
    {
        var node = BenchmarkFixtures.Node(BenchmarkFixtures.WanderBuild);
        node["kind"] = "soak-test";
        node["future_field"] = new JsonObject { ["anything"] = 1 };
        node["metrics"]![0]!["confidence"] = 0.95;
        node["hardware"]!["disk"] = "nvme";

        var r = BenchmarkLoader.Parse(node.ToJsonString(), out var error);

        Assert.Null(error);
        Assert.Equal("soak-test", r!.Kind);
        Assert.Equal("soak-test", BenchmarkFormat.Kind(r.Kind!));
    }

    [Fact]
    public void LogsAndSkipsBrokenFilesAndAMilestoneMismatch()
    {
        BenchmarkFixtures.Write(Bench, "m0", "broken.json", "{ not json");
        BenchmarkFixtures.Write(Bench, "m0", "array.json", "[1, 2]");
        BenchmarkFixtures.Write(Bench, "m0", "elsewhere.json", BenchmarkFixtures.Text(BenchmarkFixtures.WanderBuild));
        BenchmarkFixtures.Write(Bench, "m0", "good.json", BenchmarkFixtures.Text(BenchmarkFixtures.BuildSpeed));
        var logger = new ListLogger();

        var files = BenchmarkLoader.Load(Bench, logger);

        Assert.Equal("good.json", Assert.Single(files).FileName);
        Assert.Contains(logger.Warnings, w => w.Contains("WikiContent/benchmark/m0/broken.json") && w.Contains("JSON non valido"));
        Assert.Contains(logger.Warnings, w => w.Contains("WikiContent/benchmark/m0/array.json"));
        Assert.Contains(logger.Warnings, w => w.Contains("WikiContent/benchmark/m0/elsewhere.json") && w.Contains("non corrisponde alla cartella"));
    }

    [Fact]
    public void NeverReadsRawFilesOrOtherFoldersAsResults()
    {
        BenchmarkFixtures.Write(Bench, "m0", "good.json", BenchmarkFixtures.Text(BenchmarkFixtures.BuildSpeed));
        BenchmarkFixtures.Write(Bench, Path.Combine("m0", "raw"), "estimates.json", "{\"mean\": 1}");
        BenchmarkFixtures.Write(Bench, "drafts", "x.json", BenchmarkFixtures.Text(BenchmarkFixtures.BuildSpeed));
        var logger = new ListLogger();

        var files = BenchmarkLoader.Load(Bench, logger);

        Assert.Equal("good.json", Assert.Single(files).FileName);
        Assert.DoesNotContain(logger.Warnings, w => w.Contains("estimates.json"));
        Assert.Contains(logger.Warnings, w => w.Contains("drafts") && w.Contains("non è una milestone"));
    }

    [Theory]
    [InlineData("milestone", "m2\n")]
    [InlineData("commit", "0123456789abcdef0123456789abcdef01234567\n")]
    [InlineData("date", "2026-10-18T21:04:00Z\n")]
    public void RefusesATrailingNewlineInCheckedFields(string field, string value)
    {
        var node = BenchmarkFixtures.Node(BenchmarkFixtures.WanderBuild);
        node[field] = value;

        Assert.Null(BenchmarkLoader.Parse(node.ToJsonString(), out var error));
        Assert.Contains(field, error);
    }

    [Theory]
    [InlineData("tick.ms", true)]
    [InlineData("tick.phase.simulation.ms", true)]
    [InlineData("disk.write_bytes_per_s_2", true)]
    [InlineData("Tick.ms", false)]
    [InlineData("tick..ms", false)]
    [InlineData(".tick", false)]
    [InlineData("tick.ms.", false)]
    [InlineData("tick-ms", false)]
    [InlineData("tick ms", false)]
    [InlineData("tick.ms\n", false)]
    [InlineData("", false)]
    public void MetricNamesAreDottedSnakeCase(string name, bool valid)
    {
        var node = BenchmarkFixtures.Node(BenchmarkFixtures.WanderBuild);
        node["metrics"]![0]!["name"] = name;

        var result = BenchmarkLoader.Parse(node.ToJsonString(), out var error);

        Assert.Equal(valid, result is not null);
        if (!valid)
        {
            Assert.Contains("metrics[0].name", error);
        }
    }

    [Fact]
    public void RefusesARepeatedMetricName()
    {
        var node = BenchmarkFixtures.Node(BenchmarkFixtures.WanderBuild);
        node["metrics"]![1]!["name"] = node["metrics"]![0]!["name"]!.GetValue<string>();

        Assert.Null(BenchmarkLoader.Parse(node.ToJsonString(), out var error));
        Assert.Contains("nome tick.ms ripetuto", error);
    }

    [Theory]
    [InlineData("raw/x.csv.gz", true)]
    [InlineData("raw/sub/x.json", true)]
    [InlineData("raw/x.csv.gz\n", false)]
    [InlineData("raw/../x.json", false)]
    [InlineData("x.csv.gz", false)]
    public void LocalRawPathsAreRelativeUnderRaw(string path, bool local)
    {
        Assert.Equal(local, BenchmarkLoader.IsLocalRawPath(path));
    }

    [Theory]
    [InlineData("metrics", "[null]")]
    [InlineData("raw", "[null]")]
    public void NullRowsAreRefusedNotThrown(string field, string json)
    {
        var node = BenchmarkFixtures.Node(BenchmarkFixtures.WanderBuild);
        node[field] = JsonNode.Parse(json);

        Assert.Null(BenchmarkLoader.Parse(node.ToJsonString(), out var error));
        Assert.Contains(field, error);
    }

    [Fact]
    public void ANullThresholdIsRefusedNotThrown()
    {
        var node = BenchmarkFixtures.Node(BenchmarkFixtures.WanderBuild);
        node["metrics"]![0]!["thresholds"] = JsonNode.Parse("[null]");

        Assert.Null(BenchmarkLoader.Parse(node.ToJsonString(), out var error));
        Assert.Contains("thresholds", error);
    }

    [Fact]
    public void AFileWithNullRowsNeverStopsTheOthers()
    {
        var node = BenchmarkFixtures.Node(BenchmarkFixtures.BuildSpeed);
        node["metrics"] = JsonNode.Parse("[null, null]");
        BenchmarkFixtures.Write(Bench, "m0", "a-null-rows.json", node.ToJsonString());
        BenchmarkFixtures.Write(Bench, "m0", "good.json", BenchmarkFixtures.Text(BenchmarkFixtures.BuildSpeed));
        var logger = new ListLogger();

        var files = BenchmarkLoader.Load(Bench, logger);

        Assert.Equal("good.json", Assert.Single(files).FileName);
        Assert.Contains(logger.Warnings, w => w.Contains("WikiContent/benchmark/m0/a-null-rows.json"));
    }

    [Theory]
    [InlineData("../secret.csv")]
    [InlineData("/etc/passwd")]
    [InlineData("ticks.csv.gz")]
    [InlineData("http://example.com/ticks.csv.gz")]
    public void WarnsAboutAnInvalidRawPathButKeepsTheFile(string path)
    {
        var node = BenchmarkFixtures.Node(BenchmarkFixtures.WanderBuild);
        node["raw"]![0]!["path"] = path;
        BenchmarkFixtures.Write(Bench, "m2", "wander-build--aruto-linux-pc.json", node.ToJsonString());
        var logger = new ListLogger();

        var files = BenchmarkLoader.Load(Bench, logger);

        Assert.Single(files);
        var line = Assert.Single(logger.Warnings);
        Assert.Equal(
            $"risultato benchmark WikiContent/benchmark/m2/wander-build--aruto-linux-pc.json: il file grezzo {path} non è un percorso raw/... né un URL https, mostrato come testo senza link",
            line);
    }

    [Fact]
    public void ValidRawPathsGiveNoWarning()
    {
        var node = BenchmarkFixtures.Node(BenchmarkFixtures.WanderBuild);
        node["raw"]![1]!["path"] = "https://example.com/ticks.csv.gz";
        BenchmarkFixtures.Write(Bench, "m2", "wander-build--aruto-linux-pc.json", node.ToJsonString());
        var logger = new ListLogger();

        Assert.Single(BenchmarkLoader.Load(Bench, logger));
        Assert.Empty(logger.Warnings);
    }

    [Fact]
    public void MissingFolderGivesNoResults()
    {
        Assert.Empty(BenchmarkLoader.Load(Path.Combine(_dir, "missing"), NullLogger.Instance));
    }
}

public class BenchmarkRulesTests
{
    private static BenchmarkMetric Row(string better, string compare, double? ours, double? theirs, string origin = "measured") => new()
    {
        Name = "x",
        Unit = "ms",
        Better = better,
        Compare = compare,
        P99 = compare == "p99" ? ours : null,
        Value = compare == "value" ? ours : null,
        Minecraft = new BenchmarkMinecraftValue
        {
            Origin = origin,
            P99 = compare == "p99" ? theirs : null,
            Value = compare == "value" ? theirs : null,
        },
    };

    [Theory]
    [InlineData("lower", 14.8, 145.0, false)]
    [InlineData("lower", 2450.0, 1900.0, true)]
    [InlineData("lower", 20.0, 20.0, false)]
    [InlineData("higher", 236.0, 170.0, false)]
    [InlineData("higher", 150.0, 170.0, true)]
    [InlineData("higher", 170.0, 170.0, false)]
    public void MinecraftWinsOnlyWhenStrictlyBetter(string better, double ours, double theirs, bool wins)
    {
        Assert.Equal(wins, BenchmarkRules.MinecraftWins(Row(better, "p99", ours, theirs)));
    }

    [Fact]
    public void MinecraftDoesNotWinWithoutTheCompareStatisticOnBothSides()
    {
        Assert.False(BenchmarkRules.MinecraftWins(Row("lower", "p99", null, 1)));
        Assert.False(BenchmarkRules.MinecraftWins(Row("lower", "p99", 10, null)));
        Assert.False(BenchmarkRules.MinecraftWins(Row("lower", "p99", 10, 1) with { Minecraft = null }));
    }

    [Fact]
    public void TheExampleRowWhereMinecraftWinsIsFound()
    {
        var r = BenchmarkLoader.Parse(BenchmarkFixtures.Text(BenchmarkFixtures.WanderBuild), out _)!;

        Assert.Equal(["net.up_bytes_per_player_s"], r.Metrics!.Where(BenchmarkRules.MinecraftWins).Select(m => m.Name));
    }

    [Theory]
    [InlineData("lower", 25.0, ThresholdStatus.Met)]
    [InlineData("lower", 25.1, ThresholdStatus.Missed)]
    [InlineData("higher", 200.0, ThresholdStatus.Met)]
    [InlineData("higher", 199.0, ThresholdStatus.Missed)]
    public void ThresholdIsInclusiveInTheBetterDirection(string better, double ours, ThresholdStatus expected)
    {
        var limit = better == "lower" ? 25.0 : 200.0;
        var row = Row(better, "p99", ours, null);

        Assert.Equal(expected, BenchmarkRules.Check(row, new BenchmarkThreshold("p99", limit, null)));
    }

    [Fact]
    public void AThresholdOnAStatisticWeDidNotMeasureIsNotMeasuredNotFailed()
    {
        var row = Row("lower", "p99", 10, null);

        Assert.Equal(ThresholdStatus.NotMeasured, BenchmarkRules.Check(row, new BenchmarkThreshold("max", 50, null)));
    }

    [Fact]
    public void FormatsNumbersAndDatesInItalian()
    {
        Assert.Equal("30.000", BenchmarkFormat.Number(30000));
        Assert.Equal("6,1", BenchmarkFormat.Number(6.1));
        Assert.Equal("0,00042", BenchmarkFormat.Number(0.00042));
        Assert.Equal("—", BenchmarkFormat.Number((double?)null));
        Assert.Equal("18 ottobre 2026, 13:30 UTC", BenchmarkFormat.Date(DateTimeOffset.Parse("2026-10-18T15:30:00+02:00")));
        Assert.Equal("Durata del tick", BenchmarkFormat.MetricLabel("tick.ms"));
        Assert.Equal("Tick, fase simulation", BenchmarkFormat.MetricLabel("tick.phase.simulation.ms"));
        Assert.Equal("disk.iops", BenchmarkFormat.MetricLabel("disk.iops"));
    }
}

public class BenchmarkHistoryTests
{
    private static readonly IReadOnlyList<BenchmarkFile> Files = BenchmarkLoader.Load(BenchmarkFixtures.Root, NullLogger.Instance);

    [Fact]
    public void MilestonesAreNewestFirstWithTheirLatestRun()
    {
        var milestones = BenchmarkHistory.Milestones(Files);

        Assert.Equal(["m2", "m0"], milestones.Select(m => m.Milestone));
        Assert.Equal(new DateTimeOffset(2026, 10, 19, 3, 0, 0, TimeSpan.Zero), milestones[0].LatestRun);
        Assert.Equal(2, milestones[1].Files.Count);
    }

    [Fact]
    public void ASeriesIsOneMetricOfOneScenarioOnOneMachineAcrossMilestones()
    {
        var series = Assert.Single(BenchmarkHistory.ForMetric(Files, "gen.chunk_us"));

        Assert.Equal(("criterion-chunk-generation", "aruto-linux-pc"), (series.Scenario, series.Machine));
        Assert.Equal(["m0", "m2"], series.Milestones);
        Assert.Equal([412.3, 398.0], series.Points.Select(p => p.Metric.P50!.Value));
    }

    [Fact]
    public void ADifferentScenarioOrMachineIsAnotherSeries()
    {
        var other = Files.Single(f => f.Milestone == "m2" && f.Result.Scenario!.Id == "criterion-chunk-generation");
        var moved = other with { Result = other.Result with { Hardware = other.Result.Hardware! with { Machine = "pi5" } } };

        var series = BenchmarkHistory.ForMetric([.. Files, moved], "gen.chunk_us");

        Assert.Equal(["aruto-linux-pc", "pi5"], series.Select(s => s.Machine));
        Assert.Equal(["m2"], series[1].Milestones);
    }

    [Fact]
    public void EveryMetricOfEveryFileIsInExactlyOneSeries()
    {
        var series = BenchmarkHistory.Series(Files);

        Assert.Equal(Files.Sum(f => f.Result.Metrics!.Count), series.Sum(s => s.Points.Count));
        Assert.Equal(series.Select(s => s.Metric).Order(StringComparer.Ordinal), series.Select(s => s.Metric));
    }
}

// The site reading benchmark results from the test fixtures, never from WikiContent/benchmark.
public sealed class BenchmarkSiteFactory : SiteFactory
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        base.ConfigureWebHost(builder);
        builder.UseSetting("Benchmark:Directory", BenchmarkFixtures.Root);
    }
}

public partial class BenchmarkPageTests(BenchmarkSiteFactory factory) : IClassFixture<BenchmarkSiteFactory>, IDisposable
{
    private readonly List<string> _tempDirs = [];

    public void Dispose()
    {
        foreach (var dir in _tempDirs)
        {
            Directory.Delete(dir, recursive: true);
        }
    }

    private HttpClient Client() => factory.CreateClient(new WebApplicationFactoryClientOptions { AllowAutoRedirect = false });

    // A site whose benchmark folder holds only the given files (milestone/name -> JSON).
    private HttpClient ClientWith(params (string Milestone, string Name, string Json)[] files)
    {
        var dir = Directory.CreateTempSubdirectory("benchmark-site-").FullName;
        _tempDirs.Add(dir);
        foreach (var (milestone, name, json) in files)
        {
            BenchmarkFixtures.Write(dir, milestone, name, json);
        }

        return factory.WithWebHostBuilder(b => b.UseSetting("Benchmark:Directory", dir))
            .CreateClient(new WebApplicationFactoryClientOptions { AllowAutoRedirect = false });
    }

    [GeneratedRegex(@"<tr class=""bench-mc-wins"" data-metric=""([^""]+)""")]
    private static partial Regex MinecraftWinsRow();

    [Fact]
    public async Task MilestonePageShowsEverythingTheWikiAsksForToAnonymousVisitors()
    {
        var response = await Client().GetAsync("/benchmark/m2");
        var html = WebUtility.HtmlDecode(await response.Content.ReadAsStringAsync());

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Contains("Benchmark M2", html);
        // Commit and date
        Assert.Contains("SoulslandsGame", html);
        Assert.Contains("0123456789abcdef0123456789abcdef01234567", html);
        Assert.Contains("18 ottobre 2026, 21:04 UTC", html);
        // Hardware and OS
        Assert.Contains("Custom desktop", html);
        Assert.Contains("AMD Ryzen 9 7950X 16-Core Processor", html);
        Assert.Contains("4 su 32 della macchina", html);
        Assert.Contains("8.192 MiB", html);
        Assert.Contains("CachyOS rolling (linux), kernel 7.2.9-2-cachyos", html);
        // Our side
        Assert.Contains("0.2.0", html);
        Assert.Contains("v0.9.0", html);
        Assert.Contains("rustc 1.99.1 (illustrative)", html);
        Assert.Contains("tick_hz", html);
        // Minecraft side
        Assert.Contains("26.4", html);
        Assert.Contains("paper build 120", html);
        Assert.Contains("Eclipse Temurin 25.0.1 (GC g1)", html);
        Assert.Contains("-XX:+UseG1GC", html);
        Assert.Contains("azalea 0.14.0", html);
        Assert.Contains("view_distance_chunks", html);
        // Scenario
        Assert.Contains("wander-build", html);
        Assert.Contains("apps/bot-swarm/scenarios/wander-build.toml", html);
        Assert.Contains("1997", html);
        Assert.Contains("300 s (riscaldamento escluso: 60 s)", html);
        // Table: p50, p99, max, threshold, Minecraft
        Assert.Contains("Durata del tick", html);
        Assert.Contains("14,8", html);
        Assert.Contains("31,2", html);
        Assert.Contains("p99 ≤ 25:", html);
        Assert.Contains("p99 145", html);
        Assert.Contains("rispettata", html);
        // The fixture says it is not a measurement, and the page shows it.
        Assert.Contains("Illustrative example for ADR-0002, not a measurement.", html);
    }

    [Fact]
    public async Task TheRowWhereMinecraftWinsIsShownAndMarked()
    {
        var html = await Client().GetStringAsync("/benchmark/m2");

        var marked = MinecraftWinsRow().Matches(html).Select(m => m.Groups[1].Value);
        Assert.Equal(["net.up_bytes_per_player_s"], marked);
        // Once in the legend, once in the row.
        Assert.Equal(2, Regex.Matches(html, "class=\"bench-mc-badge\">Minecraft vince</span>").Count);
        Assert.Contains("data-metric=\"tick.ms\"", html);
    }

    [Fact]
    public async Task EstimatesAreShownAsEstimatesWithTheirSource()
    {
        var html = WebUtility.HtmlDecode(await Client().GetStringAsync("/benchmark/m0"));

        Assert.Contains("criterion-chunk-generation", html);
        Assert.Contains("build-leaf-relaunch", html);
        Assert.Contains("<span class=\"bench-estimate\">stima</span>", html);
        Assert.Contains("href=\"https://modrinth.com/mod/c2me-fabric\"", html);
        Assert.Empty(MinecraftWinsRow().Matches(html));
    }

    [Theory]
    [InlineData("/benchmark/m5")]
    [InlineData("/benchmark/M0")]
    [InlineData("/benchmark/latest")]
    public async Task AMilestoneWithoutFilesAnswers404(string url)
    {
        var response = await Client().GetAsync(url);

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task MissingMinecraftServerAndJavaVersionsShowNonIndicato()
    {
        var node = BenchmarkFixtures.Node(BenchmarkFixtures.WanderBuild);
        node["minecraft"]!.AsObject().Remove("server");
        node["minecraft"]!.AsObject().Remove("java");

        var html = await ClientWith(("m2", "wander-build--aruto-linux-pc.json", node.ToJsonString())).GetStringAsync("/benchmark/m2");

        Assert.Matches(@"<dt>Server</dt>\s*<dd>non indicato</dd>", html);
        Assert.Matches(@"<dt>Java</dt>\s*<dd>non indicato</dd>", html);
        Assert.Matches(@"<dt>Versione</dt>\s*<dd>26.4</dd>", html);
    }

    [Fact]
    public async Task ABrokenFileNeverBreaksThePage()
    {
        var newer = BenchmarkFixtures.Node(BenchmarkFixtures.WanderBuild);
        newer["format_version"] = 2;
        newer["scenario"]!["id"] = "siege";

        var client = ClientWith(
            ("m2", "siege--node16.json", newer.ToJsonString()),
            ("m2", "broken.json", "{"),
            ("m2", "wander-build--aruto-linux-pc.json", BenchmarkFixtures.Text(BenchmarkFixtures.WanderBuild)));
        var response = await client.GetAsync("/benchmark/m2");
        var html = await response.Content.ReadAsStringAsync();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Contains("id=\"wander-build--aruto-linux-pc\"", html);
        Assert.DoesNotContain("siege", html);
    }

    [Fact]
    public async Task OnlyBrokenFilesMeanNoPage()
    {
        var response = await ClientWith(("m3", "broken.json", "{")).GetAsync("/benchmark/m3");

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task ListedRawFilesAreLinkedAndDownloaded()
    {
        var client = Client();
        var html = await client.GetStringAsync("/benchmark/m2");
        Assert.Contains("href=\"/benchmark/m2/raw/wander-build--aruto-linux-pc.ticks.csv.gz\"", html);

        var response = await client.GetAsync("/benchmark/m2/raw/wander-build--aruto-linux-pc.ticks.csv.gz");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal("attachment", response.Content.Headers.ContentDisposition?.DispositionType);
        Assert.Equal(
            await File.ReadAllBytesAsync(Path.Combine(BenchmarkFixtures.Root, "m2/raw/wander-build--aruto-linux-pc.ticks.csv.gz")),
            await response.Content.ReadAsByteArrayAsync());
    }

    [Fact]
    public async Task ListedRawFileMissingOnDiskIsShownAsUnavailableNotLinked()
    {
        var html = await Client().GetStringAsync("/benchmark/m2");
        const string path = "raw/wander-build--aruto-linux-pc.minecraft-ticks.csv.gz";

        Assert.DoesNotContain($"href=\"/benchmark/m2/{path}\"", html);
        Assert.Matches($@"<code>{Regex.Escape(path)}</code>\s*<span class=""bench-raw-missing"">\(non disponibile\)</span>", html);
        // The shipped file next to it keeps its link and is not marked.
        Assert.Single(Regex.Matches(html, "non disponibile"));
    }

    [Theory]
    [InlineData("/benchmark/m2/raw/wander-build--aruto-linux-pc.minecraft-ticks.csv.gz")] // listed, file not shipped
    [InlineData("/benchmark/m2/raw/other.csv.gz")]                                       // not listed
    [InlineData("/benchmark/m2/raw/..%2Fwander-build--aruto-linux-pc.json")]
    [InlineData("/benchmark/m2/raw/%2E%2E/%2E%2E/m0/chunk-generation--aruto-linux-pc.json")]
    [InlineData("/benchmark/m0/raw/wander-build--aruto-linux-pc.ticks.csv.gz")]          // listed only in m2
    public async Task OtherRawPathsAnswer404(string url)
    {
        var response = await Client().GetAsync(url);

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task IndexListsEveryMilestoneNewestFirstWithDateAndCommit()
    {
        var response = await Client().GetAsync("/benchmark");
        var html = WebUtility.HtmlDecode(await response.Content.ReadAsStringAsync());

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(["m2", "m0"], Regex.Matches(html, @"data-milestone=""(m[0-9]+)"">").Select(m => m.Groups[1].Value));
        Assert.Contains("href=\"/benchmark/m2\"", html);
        Assert.Contains("href=\"/benchmark/m0\"", html);
        Assert.Contains("href=\"/benchmark/m0#criterion-chunk-generation--aruto-linux-pc\"", html);
        Assert.Contains("href=\"/benchmark/m2#wander-build--aruto-linux-pc\"", html);
        // Latest run of m2, and each file's date and commit.
        Assert.Contains("Ultima misura: <time datetime=\"2026-10-19T03:00:00.0000000+00:00\">19 ottobre 2026, 03:00 UTC</time>", html);
        Assert.Contains("18 ottobre 2026, 21:04 UTC", html);
        Assert.Contains("<code class=\"bench-commit\" title=\"0123456789abcdef0123456789abcdef01234567\">0123456</code>", html);
        Assert.Contains("<code class=\"bench-commit\" title=\"89abcdef0123456789abcdef0123456789abcdef\">89abcde</code>", html);
        Assert.Contains("href=\"/benchmark/storia/gen.chunk_us\"", html);
    }

    [Fact]
    public async Task IndexWithoutResultsSaysSo()
    {
        var response = await ClientWith().GetAsync("/benchmark");
        var html = WebUtility.HtmlDecode(await response.Content.ReadAsStringAsync());

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Contains("Nessun benchmark pubblicato per ora", html);
    }

    [Fact]
    public async Task IndexSurvivesBrokenFiles()
    {
        var nulls = BenchmarkFixtures.Node(BenchmarkFixtures.BuildSpeed);
        nulls["metrics"] = JsonNode.Parse("[null]");

        var response = await ClientWith(
            ("m0", "a-null-rows.json", nulls.ToJsonString()),
            ("m0", "broken.json", "{"),
            ("m0", "build-leaf-relaunch--aruto-linux-pc.json", BenchmarkFixtures.Text(BenchmarkFixtures.BuildSpeed))).GetAsync("/benchmark");
        var html = await response.Content.ReadAsStringAsync();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Contains("data-milestone=\"m0\"", html);
    }

    [GeneratedRegex(@"<tr (?:class=""(?<class>[^""]*)"" )?data-milestone=""(?<m>m[0-9]+)"">(?<row>.*?)</tr>", RegexOptions.Singleline)]
    private static partial Regex HistoryRow();

    private static string Text(string html) => Regex.Replace(WebUtility.HtmlDecode(Regex.Replace(html, "<[^>]+>", " ")), @"\s+", " ").Trim();

    [Fact]
    public async Task HistoryShowsValueAndThresholdInEveryMilestoneThatMeasuredIt()
    {
        var response = await Client().GetAsync("/benchmark/storia/gen.columns_per_s_per_core");
        var html = await response.Content.ReadAsStringAsync();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Contains("Colonne generate al secondo per core", WebUtility.HtmlDecode(html));
        var rows = HistoryRow().Matches(html).Select(m => (m.Groups["m"].Value, Text(m.Groups["row"].Value))).ToList();
        Assert.Equal(["m0", "m2"], rows.Select(r => r.Item1));
        Assert.Equal("M0 18 ottobre 2026, 02:00 UTC 89abcde 236 valore ≥ 200: rispettata valore 170 stima fonte", rows[0].Item2);
        Assert.Equal("M2 19 ottobre 2026, 03:00 UTC fedcba9 190 valore ≥ 200: mancata valore 170 stima fonte", rows[1].Item2);
        Assert.Contains("href=\"/benchmark/m2#criterion-chunk-generation--aruto-linux-pc\"", html);
    }

    [Fact]
    public async Task HistoryShowsEveryStatisticTheMetricHas()
    {
        var html = await Client().GetStringAsync("/benchmark/storia/gen.chunk_us");

        var rows = HistoryRow().Matches(html).Select(m => Text(m.Groups["row"].Value)).ToList();
        Assert.Equal(2, rows.Count);
        Assert.StartsWith("M0", rows[0]);
        Assert.Contains("412,3 455 470,1 —", rows[0]);
        Assert.Contains("398 430,2 441 —", rows[1]);
        Assert.DoesNotContain(">valore</th>", html);
    }

    [Fact]
    public async Task HistoryMarksTheMilestonesWhereMinecraftWins()
    {
        var html = await Client().GetStringAsync("/benchmark/storia/net.up_bytes_per_player_s");

        var row = Assert.Single(HistoryRow().Matches(html));
        Assert.Equal(("bench-mc-wins", "m2"), (row.Groups["class"].Value, row.Groups["m"].Value));
        Assert.Contains("Minecraft vince", row.Groups["row"].Value);
    }

    [Theory]
    [InlineData("/benchmark/storia/disk.iops")]
    [InlineData("/benchmark/storia/GEN.CHUNK_US")]
    [InlineData("/benchmark/storia/tick..ms")]
    public async Task HistoryOfAnUnmeasuredMetricAnswers404(string url)
    {
        var response = await Client().GetAsync(url);

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task MilestonePageLinksEachMetricToItsHistoryAndBackToTheIndex()
    {
        var html = await Client().GetStringAsync("/benchmark/m2");

        Assert.Contains("href=\"/benchmark/storia/tick.ms\"", html);
        Assert.Contains("href=\"/benchmark\"", html);
    }

    [Fact]
    public async Task TheMenuLinksTheBenchmarkIndex()
    {
        var html = await Client().GetStringAsync("/");

        Assert.Matches(@"<a class=""nav-link"" href=""/benchmark"">Benchmark</a>", html);
    }

    [Fact]
    public async Task HistoryShowsComparePerRowWhenAMilestoneChangedIt()
    {
        var m2 = BenchmarkFixtures.Node(BenchmarkFixtures.ChunkGenerationM2);
        m2["metrics"]![0]!["compare"] = "p99";

        var html = WebUtility.HtmlDecode(await ClientWith(
                ("m0", "chunk-generation--aruto-linux-pc.json", BenchmarkFixtures.Text(BenchmarkFixtures.ChunkGeneration)),
                ("m2", "chunk-generation--aruto-linux-pc.json", m2.ToJsonString()))
            .GetStringAsync("/benchmark/storia/gen.chunk_us"));

        var rows = HistoryRow().Matches(html).Select(m => Text(m.Groups["row"].Value)).ToList();
        Assert.Contains("il criterio di confronto cambia tra le milestone", html);
        Assert.StartsWith("M0 confronto su p50, più basso è meglio", rows[0]);
        Assert.StartsWith("M2 confronto su p99, più basso è meglio", rows[1]);
    }

    [Fact]
    public async Task HistoryWithOneComparisonSaysItOnceInTheHeader()
    {
        var html = WebUtility.HtmlDecode(await Client().GetStringAsync("/benchmark/storia/gen.chunk_us"));

        Assert.Contains("confronto su p50, più basso è meglio", html);
        Assert.DoesNotContain("class=\"bench-comparison\"", html);
    }
}
