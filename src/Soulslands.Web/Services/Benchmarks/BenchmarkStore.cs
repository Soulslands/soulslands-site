using Microsoft.Extensions.Options;

namespace Soulslands.Web.Services.Benchmarks;

// Result files ship with the site, so they are read once, on first use, and kept
// in memory until the next restart (deploy), like the devlog.
public class BenchmarkStore
{
    public const string DefaultFolder = "benchmark";

    private readonly Lazy<IReadOnlyList<BenchmarkFile>> _files;

    public BenchmarkStore(IOptions<BenchmarkOptions> options, IWebHostEnvironment environment, ILogger<BenchmarkStore> logger)
    {
        Directory = string.IsNullOrWhiteSpace(options.Value.Directory)
            ? Path.Combine(environment.ContentRootPath, "WikiContent", DefaultFolder)
            : Path.Combine(environment.ContentRootPath, options.Value.Directory);
        _files = new Lazy<IReadOnlyList<BenchmarkFile>>(() => LoadOrNothing(Directory, logger));
    }

    public string Directory { get; }

    // Every valid file, ordered by milestone, scenario and machine.
    public IReadOnlyList<BenchmarkFile> Files => _files.Value;

    public IReadOnlyList<BenchmarkFile> ForMilestone(string milestone) => [.. Files.Where(f => f.Milestone == milestone)];

    // Full path of a raw file (relative "raw/..." path) shipped in a milestone folder, or null
    // when it is not on disk. Defence in depth: callers already rule out "..", but the file must
    // sit in the milestone folder.
    public string? RawFilePath(string milestone, string relative)
    {
        var folder = Path.GetFullPath(Path.Combine(Directory, milestone)) + Path.DirectorySeparatorChar;
        var file = Path.GetFullPath(Path.Combine(folder, relative));
        return file.StartsWith(folder, StringComparison.Ordinal) && File.Exists(file) ? file : null;
    }

    // The loader already skips bad files one by one; this last guard keeps the pages up
    // (with no results) even if something unexpected escapes it.
    private static IReadOnlyList<BenchmarkFile> LoadOrNothing(string directory, ILogger logger)
    {
        try
        {
            return BenchmarkLoader.Load(directory, logger);
        }
        catch (Exception e)
        {
            logger.LogError(e, "Benchmark: errore imprevisto leggendo {Directory}, nessun risultato mostrato", directory);
            return [];
        }
    }
}
