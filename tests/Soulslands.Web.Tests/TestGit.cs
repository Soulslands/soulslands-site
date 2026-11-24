namespace Soulslands.Web.Tests;

// Runs git in a temp repository for the tests of the "Aggiornata il" dates (GitDates). The date, when
// given, is both the author and the committer date of a commit.
internal static class TestGit
{
    public static void Run(string directory, string? date, params string[] args)
    {
        var start = new System.Diagnostics.ProcessStartInfo("git") { UseShellExecute = false, RedirectStandardError = true, RedirectStandardOutput = true };
        foreach (var arg in new[] { "-C", directory, "-c", "user.name=Prova", "-c", "user.email=prova@example.invalid", "-c", "commit.gpgsign=false" }.Concat(args))
        {
            start.ArgumentList.Add(arg);
        }
        if (date is not null)
        {
            start.Environment["GIT_COMMITTER_DATE"] = date;
            start.Environment["GIT_AUTHOR_DATE"] = date;
        }
        using var process = System.Diagnostics.Process.Start(start)!;
        var err = process.StandardError.ReadToEnd();
        process.StandardOutput.ReadToEnd();
        process.WaitForExit();
        Assert.True(process.ExitCode == 0, $"git {string.Join(' ', args)}: {err}");
    }
}
