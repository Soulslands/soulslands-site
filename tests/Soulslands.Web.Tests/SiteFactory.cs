using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Soulslands.Web.Tests;

// The site in memory, reading the real WikiContent/ unless a subclass or WithWebHostBuilder points
// Wiki:Directory, Devlog:Directory or Benchmark:Directory elsewhere. No database, no sign-in.
public class SiteFactory : WebApplicationFactory<Program>
{
    public const string AccountUrl = "https://account.studio.test";
    public const string StudioUrl = "https://studio.test";

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseSetting("Studio:AccountUrl", AccountUrl);
        builder.UseSetting("Studio:StudioUrl", StudioUrl);
    }

    // A staff page, for the tests that prove the site and the export refuse one. This repository
    // holds no staff page (ADR-0035 section 2, PublicWikiTests): it is only ever written to a
    // temporary folder.
    public const string StaffSlug = "pagina-riservata";

    public const string StaffPage = $"""
        ---
        title: Pagina riservata
        slug: {StaffSlug}
        category: Prova
        visibility: Staff
        ---
        Testo riservato allo staff.
        """;
}
