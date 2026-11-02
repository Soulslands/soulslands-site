namespace Soulslands.Web.Data;

// Staff roles come from the studio's "role" claims (studio-wide, ADR-0024 section 2).
// Players have no role: any signed-in user without a staff role is a player.
public static class Roles
{
    public const string Admin = "Admin";
    public const string Moderatore = "Moderatore";
    public const string Agente = "Agente";

    public static readonly string[] All = [Admin, Moderatore, Agente];

    // Can read Staff wiki pages.
    public static readonly string[] Staff = [Admin, Moderatore, Agente];

    // Can create and edit wiki pages.
    public static readonly string[] WikiEditors = [Admin, Moderatore];

    public const string WikiEditorsCsv = Admin + "," + Moderatore;
}
