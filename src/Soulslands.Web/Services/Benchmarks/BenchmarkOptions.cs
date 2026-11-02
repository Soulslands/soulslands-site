namespace Soulslands.Web.Services.Benchmarks;

public class BenchmarkOptions
{
    public const string Section = "Benchmark";

    // Folder of the published results; relative paths start from the content root.
    // Empty means WikiContent/benchmark (ADR-0002).
    public string? Directory { get; set; }
}
