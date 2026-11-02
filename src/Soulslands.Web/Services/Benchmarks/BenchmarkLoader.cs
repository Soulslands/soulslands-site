using System.Globalization;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace Soulslands.Web.Services.Benchmarks;

// Reads published benchmark results: WikiContent/benchmark/<milestone>/*.json in format v1
// (SoulslandsGame docs/adr/0002-benchmark-result-v1.md). Raw files in <milestone>/raw/ are
// never read as results. A bad file is logged with its path and ignored; it never breaks a page.
// Log lines are in Italian like the rest of the site and always name the file.
public static partial class BenchmarkLoader
{
    private static readonly JsonSerializerOptions Json = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
    };

    [GeneratedRegex(@"^m[0-9]+\z")]
    public static partial Regex MilestonePattern();

    [GeneratedRegex(@"^[0-9a-f]{40}\z")]
    private static partial Regex CommitPattern();

    [GeneratedRegex(@"^[0-9]{4}-[0-9]{2}-[0-9]{2}T[0-9]{2}:[0-9]{2}:[0-9]{2}(\.[0-9]+)?(Z|[+-][0-9]{2}:[0-9]{2})\z")]
    private static partial Regex DatePattern();

    // Metric ids are dotted snake_case (ADR-0002): tick.ms, tick.phase.simulation.ms.
    [GeneratedRegex(@"^[a-z0-9_]+(\.[a-z0-9_]+)*\z")]
    public static partial Regex MetricNamePattern();

    // Patterns end with \z, not $: $ also matches before a final newline ("m2\n").
    // Relative raw path as the schema allows it: forward slashes, no "..", no leading dot or slash.
    [GeneratedRegex(@"^[A-Za-z0-9_-][A-Za-z0-9_.-]*(/[A-Za-z0-9_-][A-Za-z0-9_.-]*)*\z")]
    public static partial Regex RelativePathPattern();

    // A raw file shipped with the site: a relative path under raw/ of the milestone folder.
    public static bool IsLocalRawPath(string path) =>
        path.StartsWith("raw/", StringComparison.Ordinal) && RelativePathPattern().IsMatch(path);

    // Every valid file of every milestone folder, ordered by milestone, scenario and machine.
    public static IReadOnlyList<BenchmarkFile> Load(string directory, ILogger logger)
    {
        if (!Directory.Exists(directory))
        {
            logger.LogInformation("Cartella benchmark {Directory} non trovata, nessun risultato", directory);
            return [];
        }

        // Paths in log lines start one level above the benchmark folder: WikiContent/benchmark/m0/x.json.
        var displayRoot = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetFullPath(directory).TrimEnd(Path.DirectorySeparatorChar))) ?? directory;
        var files = new List<BenchmarkFile>();
        try
        {
            foreach (var folder in Directory.EnumerateDirectories(directory).Order(StringComparer.Ordinal))
            {
                var milestone = Path.GetFileName(folder);
                if (!MilestonePattern().IsMatch(milestone))
                {
                    logger.LogWarning("Cartella benchmark {Folder} non è una milestone (m0, m1, ...), ignorata", Display(displayRoot, folder));
                    continue;
                }

                foreach (var file in Directory.EnumerateFiles(folder, "*.json", SearchOption.TopDirectoryOnly).Order(StringComparer.Ordinal))
                {
                    if (Read(file, milestone, Display(displayRoot, file), logger) is { } result)
                    {
                        files.Add(new BenchmarkFile(milestone, Path.GetFileName(file), result));
                    }
                }
            }
        }
        catch (Exception e) when (e is IOException or UnauthorizedAccessException)
        {
            logger.LogError(e, "Cartella benchmark {Directory} non leggibile, nessun risultato", directory);
            return [];
        }

        logger.LogInformation("Benchmark: {Count} file di risultati caricati", files.Count);
        return [.. files
            .OrderBy(f => MilestoneNumber(f.Milestone))
            .ThenBy(f => f.Result.Scenario!.Id, StringComparer.Ordinal)
            .ThenBy(f => f.Result.Hardware!.Machine, StringComparer.Ordinal)
            .ThenBy(f => f.FileName, StringComparer.Ordinal)];
    }

    public static int MilestoneNumber(string milestone) =>
        int.TryParse(milestone.AsSpan(1), NumberStyles.None, CultureInfo.InvariantCulture, out var n) ? n : int.MaxValue;

    // One file never breaks the others: anything unexpected is logged with the file and skipped.
    private static BenchmarkResult? Read(string file, string folderMilestone, string display, ILogger logger)
    {
        try
        {
            return ReadChecked(file, folderMilestone, display, logger);
        }
        catch (Exception e)
        {
            logger.LogError(e, "risultato benchmark {File}: errore imprevisto durante la lettura, ignorato", display);
            return null;
        }
    }

    private static BenchmarkResult? ReadChecked(string file, string folderMilestone, string display, ILogger logger)
    {
        string text;
        try
        {
            text = File.ReadAllText(file);
        }
        catch (Exception e) when (e is IOException or UnauthorizedAccessException)
        {
            logger.LogWarning("risultato benchmark {File}: non leggibile, ignorato ({Error})", display, e.Message);
            return null;
        }

        var result = Parse(text, out var error);
        if (result is null)
        {
            logger.LogWarning("risultato benchmark {File}: {Error}", display, error);
            return null;
        }

        if (result.Milestone != folderMilestone)
        {
            logger.LogWarning("risultato benchmark {File}: la milestone {Milestone} non corrisponde alla cartella {Folder}, ignorato",
                display, result.Milestone, folderMilestone);
            return null;
        }

        // A raw path that is neither under raw/ nor an https URL is kept but shown as text, never served.
        foreach (var raw in result.Raw ?? [])
        {
            var path = raw.Path!;
            if (!IsLocalRawPath(path) && !path.StartsWith("https://", StringComparison.Ordinal))
            {
                logger.LogWarning("risultato benchmark {File}: il file grezzo {Path} non è un percorso raw/... né un URL https, mostrato come testo senza link",
                    display, path);
            }
        }

        return result;
    }

    // Returns null and says why when the file is not a valid v1 result.
    public static BenchmarkResult? Parse(string text, out string? error)
    {
        JsonDocument document;
        try
        {
            document = JsonDocument.Parse(text);
        }
        catch (JsonException e)
        {
            error = $"JSON non valido, ignorato ({e.Message})";
            return null;
        }

        using (document)
        {
            var root = document.RootElement;
            if (root.ValueKind != JsonValueKind.Object)
            {
                error = "non è un oggetto JSON, ignorato";
                return null;
            }

            if (!root.TryGetProperty("format_version", out var versionElement)
                || versionElement.ValueKind != JsonValueKind.Number
                || !versionElement.TryGetInt64(out var version))
            {
                error = "format_version mancante o non intero, ignorato";
                return null;
            }

            if (version != BenchmarkRules.SupportedFormatVersion)
            {
                error = version > BenchmarkRules.SupportedFormatVersion
                    ? $"format_version {version} è più recente di quello che il sito conosce ({BenchmarkRules.SupportedFormatVersion}); aggiornare il sito"
                    : $"format_version {version} non supportato (il sito conosce {BenchmarkRules.SupportedFormatVersion}), ignorato";
                return null;
            }

            BenchmarkResult? result;
            try
            {
                result = root.Deserialize<BenchmarkResult>(Json);
            }
            catch (JsonException e)
            {
                error = $"non è un risultato benchmark v1 valido, ignorato ({e.Message})";
                return null;
            }

            if (result is null)
            {
                error = "risultato vuoto, ignorato";
                return null;
            }

            var problems = Validate(result);
            if (problems.Count > 0)
            {
                error = $"non è un risultato benchmark v1 valido, ignorato: {string.Join("; ", problems)}";
                return null;
            }

            error = null;
            return result with { StartedAt = DateTimeOffset.Parse(result.Date!, CultureInfo.InvariantCulture) };
        }
    }

    // The fields ADR-0002 marks as required. Unknown fields and unknown values of open strings
    // (kind, unit, server software...) are accepted and shown as they are.
    private static List<string> Validate(BenchmarkResult r)
    {
        var problems = new List<string>();
        void Require(bool ok, string problem)
        {
            if (!ok)
            {
                problems.Add(problem);
            }
        }

        Require(!string.IsNullOrWhiteSpace(r.Kind), "kind mancante");
        Require(r.Milestone is not null && MilestonePattern().IsMatch(r.Milestone), "milestone mancante o non nel formato m<numero>");
        Require(r.Repo is null || !string.IsNullOrWhiteSpace(r.Repo), "repo vuoto");
        Require(r.Commit is not null && CommitPattern().IsMatch(r.Commit), "commit mancante o non uno SHA-1 di 40 caratteri");
        Require(r.Date is not null && DatePattern().IsMatch(r.Date)
                && DateTimeOffset.TryParse(r.Date, CultureInfo.InvariantCulture, DateTimeStyles.None, out _),
            "date mancante o non RFC 3339 con offset");

        if (r.Hardware is not { } hw)
        {
            problems.Add("hardware mancante");
        }
        else
        {
            Require(!string.IsNullOrWhiteSpace(hw.Machine), "hardware.machine mancante");
            Require(!string.IsNullOrWhiteSpace(hw.Model), "hardware.model mancante");
            Require(!string.IsNullOrWhiteSpace(hw.Cpu), "hardware.cpu mancante");
            Require(hw.Cores >= 1, "hardware.cores mancante o minore di 1");
            Require(hw.RamMib >= 1, "hardware.ram_mib mancante o minore di 1");
            Require(!string.IsNullOrWhiteSpace(hw.Arch), "hardware.arch mancante");
            Require(hw.Os is { } os && !string.IsNullOrWhiteSpace(os.Family) && !string.IsNullOrWhiteSpace(os.Name)
                    && !string.IsNullOrWhiteSpace(os.Version),
                "hardware.os richiede family, name e version");
        }

        if (r.Scenario is not { } sc)
        {
            problems.Add("scenario mancante");
        }
        else
        {
            Require(!string.IsNullOrWhiteSpace(sc.Id), "scenario.id mancante");
            Require(sc.Seed is not null, "scenario.seed mancante");
            Require(sc.DurationS > 0, "scenario.duration_s mancante o non maggiore di 0");
            Require(sc.WarmupS >= 0, "scenario.warmup_s mancante o minore di 0");
            Require(!string.IsNullOrWhiteSpace(sc.Script), "scenario.script mancante");
        }

        if (r.Metrics is not { Count: > 0 } metrics)
        {
            problems.Add("metrics richiede almeno una riga");
            return problems;
        }

        for (var i = 0; i < metrics.Count; i++)
        {
            var where = $"metrics[{i}]";
            if (metrics[i] is not { } m)
            {
                problems.Add($"{where} è null");
                continue;
            }

            Require(m.Name is not null && MetricNamePattern().IsMatch(m.Name), $"{where}.name mancante o non in snake_case puntato (tick.ms)");
            Require(!string.IsNullOrWhiteSpace(m.Unit), $"{where}.unit mancante");
            Require(m.Better is BenchmarkRules.BetterLower or BenchmarkRules.BetterHigher, $"{where}.better deve essere lower o higher");
            Require(BenchmarkRules.Stats.Contains(m.Compare), $"{where}.compare deve essere p50, p99, max o value");
            Require(m.HasOwnValue || m.Minecraft is not null, $"{where} non ha valori di nessuno dei due lati");
            foreach (var t in m.Thresholds ?? [])
            {
                Require(t is not null && BenchmarkRules.Stats.Contains(t.Stat) && t.Value is not null, $"{where}.thresholds richiede stat e value");
            }

            if (m.Minecraft is { } mc)
            {
                Require(mc.Origin is BenchmarkRules.OriginMeasured or BenchmarkRules.OriginEstimate,
                    $"{where}.minecraft.origin deve essere measured o estimate");
                Require(!mc.IsEstimate || (mc.Source?.StartsWith("https://", StringComparison.Ordinal) ?? false),
                    $"{where}.minecraft è una stima senza fonte https");
                Require(mc.P50 is not null || mc.P99 is not null || mc.Max is not null || mc.Value is not null,
                    $"{where}.minecraft non ha valori");
            }
        }

        // One row per metric: the history groups rows by name, so a repeated name is ambiguous.
        foreach (var name in metrics.Where(m => m?.Name is not null).GroupBy(m => m!.Name!, StringComparer.Ordinal)
                     .Where(g => g.Count() > 1).Select(g => g.Key))
        {
            problems.Add($"metrics: nome {name} ripetuto");
        }

        if (metrics.Any(m => m?.HasOwnValue == true))
        {
            Require(r.Soulslands is not null, "soulslands obbligatorio quando una riga ha valori del nostro lato");
        }

        if (r.Soulslands is { } ours)
        {
            Require(!string.IsNullOrWhiteSpace(ours.GameVersion), "soulslands.game_version mancante");
            Require(!string.IsNullOrWhiteSpace(ours.SlworldTag), "soulslands.slworld_tag mancante");
            Require(!string.IsNullOrWhiteSpace(ours.Rustc), "soulslands.rustc mancante");
        }

        if (r.Minecraft is not null)
        {
            Require(!string.IsNullOrWhiteSpace(r.Minecraft.Version), "minecraft.version mancante");
        }

        if (metrics.Any(m => m?.Minecraft?.Origin == BenchmarkRules.OriginMeasured))
        {
            Require(!string.IsNullOrWhiteSpace(r.Minecraft?.Version), "minecraft.version obbligatorio quando un valore di Minecraft è misurato");
        }

        foreach (var raw in r.Raw ?? [])
        {
            Require(!string.IsNullOrWhiteSpace(raw?.Path), "raw[].path mancante");
        }

        return problems;
    }

    private static string Display(string root, string path) => Path.GetRelativePath(root, path).Replace('\\', '/');
}
