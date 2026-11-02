using Microsoft.EntityFrameworkCore;

namespace Soulslands.Web.Data;

// Same model as ApplicationDbContext; a separate type so PostgreSQL keeps its
// own migrations in Data/Migrations/Postgres. Create them with
// Database__Provider=Postgres dotnet ef migrations add Name --context PostgresDbContext --output-dir Data/Migrations/Postgres
public class PostgresDbContext(DbContextOptions<PostgresDbContext> options) : ApplicationDbContext(options);
