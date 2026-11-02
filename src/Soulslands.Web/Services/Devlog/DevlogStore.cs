using Microsoft.Extensions.Options;

namespace Soulslands.Web.Services.Devlog;

// Posts are files shipped with the site, so they are read once, on first use,
// and kept in memory until the next restart (deploy).
public class DevlogStore
{
    private readonly Lazy<IReadOnlyList<DevlogPost>> _posts;

    public DevlogStore(IOptions<DevlogOptions> options, IWebHostEnvironment environment, ILogger<DevlogStore> logger)
    {
        var directory = string.IsNullOrWhiteSpace(options.Value.Directory)
            ? Path.Combine(environment.ContentRootPath, "WikiContent", WikiContentImporter.DevlogFolder)
            : Path.Combine(environment.ContentRootPath, options.Value.Directory);
        _posts = new Lazy<IReadOnlyList<DevlogPost>>(() => DevlogLoader.Load(directory, logger));
    }

    // Newest first.
    public IReadOnlyList<DevlogPost> Posts => _posts.Value;

    public DevlogPost? Find(string slug) => Posts.FirstOrDefault(p => p.Slug == slug);
}
