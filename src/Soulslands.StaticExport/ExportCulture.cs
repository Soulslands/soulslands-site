using System.Globalization;

namespace Soulslands.StaticExport;

// The export runs with Italian culture data from ICU, whatever the build machine has. The wiki
// tree is sorted with the current culture (WikiNavigation) and the pages format numbers and dates
// with it. The project carries its own ICU (Microsoft.ICU.ICU4C.Runtime, app-local ICU on
// Linux x64, Cloudflare's build image), and build-static.sh runs the SDK in invariant mode when
// the machine has no libicu. If ICU is still missing, the export stops here and says so, instead
// of writing pages sorted and formatted without culture data.
public static class ExportCulture
{
    public const string Name = "it-IT";

    // null when the culture has real ICU data; otherwise the reason, in Italian.
    public static string? Check(CultureInfo culture)
    {
        if (culture.DateTimeFormat.GetMonthName(10) != "ottobre")
        {
            return $"la cultura {culture.Name} non ha i nomi dei mesi in italiano";
        }
        // ICU collation puts an accented letter next to its base letter; ordinal order (invariant
        // mode) puts it after z.
        if (string.Compare("è", "f", culture, CompareOptions.None) >= 0)
        {
            return $"la cultura {culture.Name} non ordina le lettere accentate";
        }
        return null;
    }

    public static bool Apply(TextWriter error)
    {
        CultureInfo culture;
        try
        {
            culture = CultureInfo.GetCultureInfo(Name, predefinedOnly: true);
        }
        catch (CultureNotFoundException)
        {
            error.WriteLine($"ICU non disponibile: la cultura {Name} non esiste (modalità invariant?). Installa libicu o lascia attiva l'ICU del progetto (Soulslands.StaticExport.csproj).");
            return false;
        }
        if (Check(culture) is { } problem)
        {
            error.WriteLine($"ICU non disponibile: {problem}. Installa libicu o lascia attiva l'ICU del progetto (Soulslands.StaticExport.csproj).");
            return false;
        }
        CultureInfo.DefaultThreadCurrentCulture = culture;
        CultureInfo.DefaultThreadCurrentUICulture = culture;
        CultureInfo.CurrentCulture = culture;
        CultureInfo.CurrentUICulture = culture;
        return true;
    }
}
