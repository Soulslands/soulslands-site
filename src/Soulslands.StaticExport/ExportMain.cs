namespace Soulslands.StaticExport;

// dotnet run --project src/Soulslands.StaticExport -- --out dist [--wiki <WikiContent>] [--base-url <url>]
// Exit code 0 when dist/ is complete and every check passed; 1 on a failed check; 2 on bad arguments.
public static class ExportMain
{
    public static async Task<int> Main(string[] args)
    {
        var options = new ExportOptions
        {
            OutputDirectory = "",
            BaseUrl = Environment.GetEnvironmentVariable("SITE_BASE_URL") is { Length: > 0 } url ? url : ExportOptions.DefaultBaseUrl,
        };
        for (var i = 0; i < args.Length; i++)
        {
            var value = i + 1 < args.Length ? args[i + 1] : null;
            switch (args[i])
            {
                case "--out" when value is not null:
                    options = options with { OutputDirectory = value };
                    i++;
                    break;
                case "--wiki" when value is not null:
                    options = options with { WikiDirectory = value };
                    i++;
                    break;
                case "--base-url" when value is not null:
                    options = options with { BaseUrl = value };
                    i++;
                    break;
                default:
                    Console.Error.WriteLine($"Argomento sconosciuto: {args[i]}");
                    return 2;
            }
        }
        if (string.IsNullOrWhiteSpace(options.OutputDirectory))
        {
            Console.Error.WriteLine("Manca --out <cartella>.");
            return 2;
        }
        return await StaticExporter.RunAsync(options, Console.Out, Console.Error);
    }
}
