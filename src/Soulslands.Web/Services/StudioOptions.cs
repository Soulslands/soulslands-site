namespace Soulslands.Web.Services;

// Section "Studio": where the links to the Mahoroba studio app point. The studio holds accounts,
// store, gift keys, downloads and the legal pages (SoulslandsGame ADR-0024); this site only links
// to it and reads the studio's public announcements in the browser.
public class StudioOptions
{
    public const string Section = "Studio";

    // The account host (store, download, redeem, announcements), e.g. https://account.mahoroba.studio.
    public string AccountUrl { get; set; } = "";

    // The studio pages (privacy, terms, contact), e.g. https://mahoroba.studio.
    public string StudioUrl { get; set; } = "";

    public string Account(string path) => AccountUrl.TrimEnd('/') + path;

    public string Studio(string path) => StudioUrl.TrimEnd('/') + path;

    // The announcements are fetched from the account host by the visitor's browser: https only.
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
