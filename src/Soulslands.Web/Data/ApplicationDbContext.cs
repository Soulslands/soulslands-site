using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Soulslands.Web.Data;

// The SQLite context used in development and tests. Production uses
// PostgresDbContext, which shares this model but has its own migrations.
// No accounts here: people sign in through the studio (SoulslandsGame ADR-0024),
// and this database keeps only their studio id ("sub").
public class ApplicationDbContext : DbContext, IDataProtectionKeyContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected ApplicationDbContext(DbContextOptions options)
        : base(options)
    {
    }

    public DbSet<WikiPage> WikiPages => Set<WikiPage>();

    public DbSet<WikiRevision> WikiRevisions => Set<WikiRevision>();

    public DbSet<Announcement> Announcements => Set<Announcement>();

    public DbSet<DataProtectionKey> DataProtectionKeys => Set<DataProtectionKey>();

    public DbSet<GameServer> GameServers => Set<GameServer>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<WikiPage>().HasIndex(p => p.Slug).IsUnique();
        builder.Entity<GameServer>().HasIndex(s => s.ApiKeyHash).IsUnique();
        builder.Entity<GameServer>().HasIndex(s => s.OwnerId);
    }
}
