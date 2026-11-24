using System.Diagnostics;
using System.Globalization;

namespace Soulslands.Web.Services;

// The time each wiki page last changed, from Git: the committer date of the last commit that
// touched its file. The static site shows it as "Aggiornata il", so two exports of the same commit
// are identical and a fix to one page re-dates only that page. Without Git, outside a repository or
// in a shallow clone (whose oldest commit would date every page it holds) there is no date at all:
// the export then leaves the line out rather than guess.
public static class GitDates
{
    // UTC time by full file path, for the files under the folder that Git has committed; empty
    // when Git cannot give the full history.
    public static IReadOnlyDictionary<string, DateTime> LastCommits(string directory)
    {
        var dates = new Dictionary<string, DateTime>(StringComparer.Ordinal);
        if (Run(directory, "rev-parse", "--is-shallow-repository") is not "false"
            || Run(directory, "rev-parse", "--show-toplevel") is not { Length: > 0 } top)
        {
            return dates;
        }
        // Newest first: the first date seen for a file is its last change.
        var log = Run(directory, "-c", "core.quotepath=off", "log", "--format=%x01%cI", "--name-only", "--no-renames", "--", ".");
        if (log is null)
        {
            return dates;
        }
        DateTime? current = null;
        foreach (var line in log.Split('\n'))
        {
            if (line.StartsWith('\u0001'))
            {
                current = DateTimeOffset.Parse(line[1..], CultureInfo.InvariantCulture).UtcDateTime;
            }
            else if (line.Length > 0 && current is { } date)
            {
                dates.TryAdd(Path.GetFullPath(Path.Combine(top, line)), date);
            }
        }
        return dates;
    }

    // Standard output of a git command (trimmed), or null when git is missing or fails.
    private static string? Run(string directory, params string[] args)
    {
        var start = new ProcessStartInfo("git")
        {
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
        };
        start.ArgumentList.Add("-C");
        start.ArgumentList.Add(directory);
        foreach (var arg in args)
        {
            start.ArgumentList.Add(arg);
        }
        try
        {
            using var process = Process.Start(start);
            if (process is null)
            {
                return null;
            }
            var stderr = process.StandardError.ReadToEndAsync();
            var output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            _ = stderr.Result;
            return process.ExitCode == 0 ? output.Trim() : null;
        }
        catch (System.ComponentModel.Win32Exception)
        {
            return null;
        }
    }
}
