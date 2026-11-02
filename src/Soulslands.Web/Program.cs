using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Soulslands.Web.Data;
using Soulslands.Web.Services;
using Soulslands.Web.Services.Auth;
using Soulslands.Web.Services.Benchmarks;
using Soulslands.Web.Services.Devlog;
using Soulslands.Web.Services.Servers;

// Used by the Docker HEALTHCHECK: the runtime image has no curl.
if (args.Contains("--healthcheck"))
{
    using var http = new HttpClient { Timeout = TimeSpan.FromSeconds(4) };
    try
    {
        var health = await http.GetAsync("http://localhost:8080/api/health");
        Environment.Exit(health.IsSuccessStatusCode ? 0 : 1);
    }
    catch (HttpRequestException)
    {
        Environment.Exit(1);
    }
}

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
// SQLite for development and tests, PostgreSQL in production (Database:Provider = "Postgres").
if (builder.Configuration["Database:Provider"] == "Postgres")
{
    builder.Services.AddDbContext<ApplicationDbContext, PostgresDbContext>(options => options.UseNpgsql(connectionString));
}
else
{
    builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(connectionString));
}
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// No accounts here: sign-in goes through the studio's OIDC provider (SoulslandsGame ADR-0024).
builder.AddStudioSignIn();
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Admin", "Admin");
});
builder.Services.AddAuthorizationBuilder()
    .AddPolicy("Admin", policy => policy.RequireRole(Roles.Admin));

// Keys live in this site's own database, under its own application name, so the sign-in
// cookie, the OIDC correlation cookies and antiforgery tokens survive restarts. Never shared
// with the studio (ADR-0024 section 6).
builder.Services.AddDataProtection()
    .SetApplicationName("Soulslands.Web")
    .PersistKeysToDbContext<ApplicationDbContext>();

builder.Services.AddOptions<SiteOptions>()
    .Bind(builder.Configuration.GetSection(SiteOptions.Section))
    .Validate(o => SiteOptions.IsValidBaseUrl(o.BaseUrl), "Site:BaseUrl deve essere un indirizzo http o https assoluto, senza query.")
    .ValidateOnStart();
builder.Services.Configure<DevlogOptions>(builder.Configuration.GetSection(DevlogOptions.Section));
builder.Services.AddSingleton<DevlogStore>();
builder.Services.Configure<BenchmarkOptions>(builder.Configuration.GetSection(BenchmarkOptions.Section));
builder.Services.AddSingleton<BenchmarkStore>();

// Behind a reverse proxy (Docker, nginx) the real scheme and client IP come
// from X-Forwarded-* headers; without this, the OIDC redirect URI would be http.
builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
    options.KnownIPNetworks.Clear();
    options.KnownProxies.Clear();
});

builder.Services.AddHealthChecks().AddDbContextCheck<ApplicationDbContext>();

var app = builder.Build();

app.UseForwardedHeaders();

using (var scope = app.Services.CreateScope())
{
    await DataSeeder.SeedAsync(scope.ServiceProvider);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Friendly error pages for the site only: the API must return bare status codes.
app.UseWhen(context => !context.Request.Path.StartsWithSegments("/api"),
    site => site.UseStatusCodePagesWithReExecute("/StatusCode/{0}"));

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();
app.MapHealthChecks("/api/health");
app.MapMovedPages();
ServerStatus.Map(app);
DevlogFeed.Map(app);

app.Run();

public partial class Program;
