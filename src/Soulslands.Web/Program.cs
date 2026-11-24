using Soulslands.Web.Services;
using Soulslands.Web.Services.Benchmarks;
using Soulslands.Web.Services.Devlog;

// The Soulslands site is static (W-21, W-22): scripts/build-static.sh renders these pages into
// dist/ with Soulslands.StaticExport, and Cloudflare serves the files. This app is the generator
// and its local preview (dotnet run): pages read WikiContent/ (wiki, devlog, benchmark results)
// from files, with no database, no sign-in and no cookies.
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddOptions<StudioOptions>()
    .Bind(builder.Configuration.GetSection(StudioOptions.Section))
    .Validate(o => StudioOptions.IsValidAccountUrl(o.AccountUrl), "Studio:AccountUrl deve essere un indirizzo https assoluto.")
    .Validate(o => StudioOptions.IsValidUrl(o.StudioUrl), "Studio:StudioUrl deve essere un indirizzo https assoluto (http solo su localhost).")
    .ValidateOnStart();
builder.Services.AddOptions<SiteOptions>()
    .Bind(builder.Configuration.GetSection(SiteOptions.Section))
    .Validate(o => SiteOptions.IsValidBaseUrl(o.BaseUrl), "Site:BaseUrl deve essere un indirizzo http o https assoluto, senza query.")
    .ValidateOnStart();
builder.Services.Configure<WikiOptions>(builder.Configuration.GetSection(WikiOptions.Section));
builder.Services.AddSingleton<WikiStore>();
builder.Services.Configure<DevlogOptions>(builder.Configuration.GetSection(DevlogOptions.Section));
builder.Services.AddSingleton<DevlogStore>();
builder.Services.Configure<BenchmarkOptions>(builder.Configuration.GetSection(BenchmarkOptions.Section));
builder.Services.AddSingleton<BenchmarkStore>();

var app = builder.Build();

// The wiki is read now, so a page that is not public stops the start (and the export) at once.
app.Services.GetRequiredService<WikiStore>();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

// The not-found page, which the export writes as dist/404.html.
app.UseStatusCodePagesWithReExecute("/StatusCode/{0}");

app.UseRouting();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();
DevlogFeed.Map(app);
SearchIndex.Map(app);

app.Run();

public partial class Program;
