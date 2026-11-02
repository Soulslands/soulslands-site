namespace Soulslands.Web.Services;

// Public address of the site, used where an absolute link must not depend on the
// request's Host header (today the devlog Atom feed, whose ids must stay stable).
// docker-compose.yml sets it to https://SITE_DOMAIN; empty in home mode (SITE_DOMAIN=:80)
// and in development, where links follow the request.
public class SiteOptions
{
    public const string Section = "Site";

    // Absolute http or https URL without query or fragment, e.g. https://soulslands.arutosio.com.
    public string? BaseUrl { get; set; }

    public static bool IsValidBaseUrl(string? value) =>
        string.IsNullOrWhiteSpace(value)
        || (Uri.TryCreate(value, UriKind.Absolute, out var uri)
            && (uri.Scheme == Uri.UriSchemeHttps || uri.Scheme == Uri.UriSchemeHttp)
            && !string.IsNullOrEmpty(uri.Host)
            && string.IsNullOrEmpty(uri.Query)
            && string.IsNullOrEmpty(uri.Fragment)
            && string.IsNullOrEmpty(uri.UserInfo));
}
