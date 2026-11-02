using System.Globalization;
using System.Text.Json;
using Soulslands.Web.Services.Devlog;

namespace Soulslands.Web.Services.Benchmarks;

// Italian labels and number formatting for the benchmark pages. Result files carry
// ids only (ADR-0002): an id without a label here is shown as it is.
public static class BenchmarkFormat
{
    public const string NotStated = "non indicato";

    // Italian separators without relying on the server's ICU data.
    private static readonly NumberFormatInfo Numbers = new()
    {
        NumberDecimalSeparator = ",",
        NumberGroupSeparator = ".",
        NegativeSign = "-",
    };

    private static readonly Dictionary<string, string> MetricLabels = new(StringComparer.Ordinal)
    {
        ["tick.ms"] = "Durata del tick",
        ["tick.instability"] = "Instabilità del tick",
        ["mem.per_player_mib"] = "Memoria per giocatore",
        ["mem.idle_mib"] = "Memoria a server vuoto",
        ["startup.s"] = "Avvio del server",
        ["net.up_bytes_per_player_s"] = "Rete in salita per giocatore",
        ["net.down_bytes_per_player_s"] = "Rete in discesa per giocatore",
        ["net.bytes_per_chunk"] = "Byte per chunk",
        ["gen.chunk_us"] = "Generazione di un chunk",
        ["gen.columns_per_s_per_core"] = "Colonne generate al secondo per core",
        ["build.leaf_change_relaunch_s"] = "Modifica a un crate foglia e riavvio",
        ["build.core_change_s"] = "Ricompilazione dopo una modifica a ss-core",
        ["frame.ms"] = "Durata del frame",
        ["fps"] = "Fotogrammi al secondo",
    };

    private static readonly Dictionary<string, string> Units = new(StringComparer.Ordinal)
    {
        ["ns"] = "ns",
        ["us"] = "µs",
        ["ms"] = "ms",
        ["s"] = "s",
        ["bytes"] = "byte",
        ["kib"] = "KiB",
        ["mib"] = "MiB",
        ["bytes_per_s"] = "byte/s",
        ["kib_per_s"] = "KiB/s",
        ["per_s"] = "al secondo",
        ["fps"] = "fps",
        ["count"] = "numero",
        ["percent"] = "%",
        ["ratio"] = "rapporto",
    };

    private static readonly Dictionary<string, string> Kinds = new(StringComparer.Ordinal)
    {
        ["bot-swarm"] = "Bot swarm (server)",
        ["criterion"] = "Microbenchmark (criterion)",
        ["build-speed"] = "Velocità di compilazione",
        ["client-scene"] = "Scena del client",
    };

    public static string MetricLabel(string name)
    {
        if (MetricLabels.TryGetValue(name, out var label))
        {
            return label;
        }

        // tick.phase.<phase>.ms: one label for every phase.
        var parts = name.Split('.');
        return parts is ["tick", "phase", var phase, "ms"] ? $"Tick, fase {phase}" : name;
    }

    public static string Unit(string unit) => Units.GetValueOrDefault(unit, unit);

    public static string Kind(string kind) => Kinds.GetValueOrDefault(kind, kind);

    public static string Stat(string stat) => stat == "value" ? "valore" : stat;

    public static string Number(double value)
    {
        var abs = Math.Abs(value);
        var format = abs == 0 || abs >= 1 ? "#,0.###" : "0.######";
        return value.ToString(format, Numbers);
    }

    public static string Number(double? value) => value is { } v ? Number(v) : "—";

    // "18 ottobre 2026, 21:04 UTC".
    public static string Date(DateTimeOffset date)
    {
        var utc = date.ToUniversalTime();
        return $"{DevlogLoader.FormatDate(DateOnly.FromDateTime(utc.DateTime))}, {utc.ToString("HH:mm", CultureInfo.InvariantCulture)} UTC";
    }

    public static string Seconds(double? seconds) => seconds is { } s ? $"{Number(s)} s" : NotStated;

    public static string OrNotStated(string? text) => string.IsNullOrWhiteSpace(text) ? NotStated : text;

    // A settings map as "key = value" pairs, in the file's order.
    public static IEnumerable<KeyValuePair<string, string>> Settings(Dictionary<string, JsonElement>? settings) =>
        (settings ?? []).Select(p => KeyValuePair.Create(p.Key, p.Value.ValueKind switch
        {
            JsonValueKind.String => p.Value.GetString() ?? "",
            JsonValueKind.True => "sì",
            JsonValueKind.False => "no",
            JsonValueKind.Number => p.Value.TryGetDouble(out var d) ? Number(d) : p.Value.GetRawText(),
            _ => p.Value.GetRawText(),
        }));
}
