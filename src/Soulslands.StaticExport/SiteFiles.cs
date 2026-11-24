using System.Text;
using Soulslands.Web.Services.Auth;

namespace Soulslands.StaticExport;

// The two Cloudflare control files of dist/, read by Workers static assets and by Pages
// (developers.cloudflare.com/workers/static-assets/headers/ and .../redirects/).
public static class SiteFiles
{
    // Old paths of the pages that moved to the studio (the dynamic site's MovedPages), and the font
    // preferences page that the footer switch replaced. 302 like the dynamic site.
    public static IReadOnlyList<(string Path, string Target)> Redirects(StudioOptions studio) =>
    [
        .. StudioSignIn.MovedPages.Select(p => (p.Path, p.OnAccountHost ? studio.Account(p.Target) : studio.Studio(p.Target))),
        ("/Preferenze", "/"),
    ];

    public static IReadOnlyList<string> RedirectSources =>
        [.. Redirects(new StudioOptions { AccountUrl = "https://account.invalid", StudioUrl = "https://studio.invalid" }).Select(r => r.Path)];

    // Cloudflare matches paths and _redirects sources case-sensitively (wrangler 4.167 `pages dev`:
    // /media is 404 next to /Media/), while the dynamic site's routes ignored case. So
    // the lowercase spelling of every redirect source and of every top-level page with capitals
    // (/Media, /Regole, /Stato) redirects to the real one.
    public static IReadOnlyList<(string Path, string Target)> LowercaseRedirects(
        IEnumerable<(string Path, string Target)> redirects, IEnumerable<string> topLevelPages) =>
    [
        .. redirects.Where(r => r.Path != r.Path.ToLowerInvariant()).Select(r => (r.Path.ToLowerInvariant(), r.Target)),
        .. topLevelPages.Where(p => p != p.ToLowerInvariant()).Order(StringComparer.Ordinal).Select(p => ("/" + p.ToLowerInvariant(), "/" + p + "/")),
    ];

    public static string RedirectsFile(StudioOptions studio, IEnumerable<string> topLevelPages)
    {
        var text = new StringBuilder("# Written by scripts/build-static.sh (Soulslands.StaticExport); do not edit.\n");
        var redirects = Redirects(studio);
        foreach (var (path, target) in redirects)
        {
            text.Append(path).Append(' ').Append(target).Append(" 302\n");
        }
        text.Append("# Lowercase spellings: Pages matches paths case-sensitively.\n");
        foreach (var (path, target) in LowercaseRedirects(redirects, topLevelPages))
        {
            text.Append(path).Append(' ').Append(target).Append(" 301\n");
        }
        return text.ToString();
    }

    // No inline script anywhere (scripts are files under wwwroot/js); styles allow 'unsafe-inline'
    // because mermaid writes <style> into its diagrams and the progress bars use style attributes.
    // connect-src adds the studio's account host: the home page reads its announcements there.
    public static string ContentSecurityPolicy(StudioOptions studio)
    {
        var account = new Uri(studio.AccountUrl).GetLeftPart(UriPartial.Authority);
        return string.Join("; ",
            "default-src 'self'",
            "script-src 'self'",
            "style-src 'self' 'unsafe-inline'",
            "img-src 'self' data:",
            "font-src 'self'",
            $"connect-src 'self' {account}",
            "object-src 'none'",
            "base-uri 'self'",
            "form-action 'self'",
            "frame-ancestors 'none'");
    }

    public const string PermissionsPolicy =
        "accelerometer=(), camera=(), geolocation=(), gyroscope=(), magnetometer=(), microphone=(), payment=(), usb=()";

    public static string HeadersFile(StudioOptions studio) =>
        $"""
        # Written by scripts/build-static.sh (Soulslands.StaticExport); do not edit.
        /*
          Content-Security-Policy: {ContentSecurityPolicy(studio)}
          X-Content-Type-Options: nosniff
          Referrer-Policy: strict-origin-when-cross-origin
          X-Frame-Options: DENY
          Permissions-Policy: {PermissionsPolicy}

        # wwwroot files carry a content hash in their name (MapStaticAssets): they never change.
        /css/*
          Cache-Control: public, max-age=31536000, immutable
        /js/*
          Cache-Control: public, max-age=31536000, immutable
        /lib/*
          Cache-Control: public, max-age=31536000, immutable

        # Raw benchmark files are downloads, as on the dynamic site.
        /benchmark/:milestone/raw/*
          Content-Disposition: attachment

        """;
}
