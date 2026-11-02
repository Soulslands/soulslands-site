namespace Soulslands.Web.Services.Auth;

// Section "Studio": the Mahoroba studio app, which holds accounts, store, gift keys, downloads
// and the legal pages (SoulslandsGame ADR-0024). This site signs in through its OIDC provider.
public class StudioOptions
{
    public const string Section = "Studio";

    // The account host and OIDC issuer, e.g. https://account.mahoroba.studio. Always https, also
    // on localhost: discovery, keys and the token endpoint (whose id token the handler trusts
    // because it came over TLS) are fetched from here.
    public string AccountUrl { get; set; } = "";

    // The studio pages (privacy, terms, contact), e.g. https://mahoroba.studio.
    public string StudioUrl { get; set; } = "";

    public string ClientId { get; set; } = "soulslands-website";

    // From .env or user secrets, never from a file in the repository.
    public string? ClientSecret { get; set; }

    public string Account(string path) => AccountUrl.TrimEnd('/') + path;

    public string Studio(string path) => StudioUrl.TrimEnd('/') + path;

    public static bool IsValidAccountUrl(string? value) =>
        IsValidUrl(value) && new Uri(value!).Scheme == Uri.UriSchemeHttps;

    // Studio pages are plain links: https, or http only on a loopback address.
    public static bool IsValidUrl(string? value) =>
        Uri.TryCreate(value, UriKind.Absolute, out var uri)
        && (uri.Scheme == Uri.UriSchemeHttps || (uri.Scheme == Uri.UriSchemeHttp && uri.IsLoopback))
        && string.IsNullOrEmpty(uri.Query)
        && string.IsNullOrEmpty(uri.Fragment)
        && string.IsNullOrEmpty(uri.UserInfo);
}
