using System.Security.Claims;
using System.Text.RegularExpressions;
using Soulslands.Web.Data;

namespace Soulslands.Web.Services;

public static class WikiAccess
{
    public static bool IsStaff(ClaimsPrincipal user) => Roles.Staff.Any(user.IsInRole);

    public static bool CanEdit(ClaimsPrincipal user) => Roles.WikiEditors.Any(user.IsInRole);

    public static bool CanRead(ClaimsPrincipal user, WikiVisibility visibility) =>
        visibility == WikiVisibility.Pubblica || IsStaff(user);

    // Filters a query down to the pages this user may see, so Staff pages never
    // leak through lists or search.
    public static IQueryable<WikiPage> VisibleTo(this IQueryable<WikiPage> pages, ClaimsPrincipal user) =>
        IsStaff(user) ? pages : pages.Where(p => p.Visibility == WikiVisibility.Pubblica);

    // "modifica" is taken by the edit route (/wiki/modifica/...).
    public static bool IsValidSlug(string? slug) =>
        slug is not null && slug != "modifica" && SlugRegex.IsMatch(slug);

    private static readonly Regex SlugRegex = new("^[a-z0-9]+(-[a-z0-9]+)*$", RegexOptions.Compiled);
}
