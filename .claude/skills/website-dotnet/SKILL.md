---
name: website-dotnet
description: Conventions of the Soulslands website codebase (ASP.NET Core .NET 10, Razor Pages, minimal APIs, Identity, EF Core with SQLite and Postgres migrations, Stripe, gift keys, launcher/session API, wiki engine, xUnit tests). Use before changing or testing any code in the website repository.
---

# Soulslands website conventions

Repo `~/GitRepositories/soulslands-website`, solution `Soulslands.slnx`: `src/Soulslands.Web` (the site) and `tests/Soulslands.Web.Tests` (xUnit). Target `net10.0`, `Nullable` and `ImplicitUsings` on. Deployment guide in Italian: `deploy/README.md`.

## Shape of the code

- **Razor Pages only** for the site, no MVC controllers. Page names and UI are Italian (`Pages/Acquista`, `Riscatta`, `Download`, `Admin/Utenti`, `Wiki/...`); Identity pages in `Areas/Identity` are translated to Italian (`ItalianIdentityErrorDescriber`).
- **APIs are minimal APIs** written as static classes with `Map(IEndpointRouteBuilder)` and static handlers using `[FromServices]` (`Services/Launcher/LauncherApi`, `Services/Servers/ServerStatus`, `Services/Payments/StripeWebhook`). There is no `Api/` folder; contracts live next to the code (`Services/Launcher/LauncherContracts.cs`).
- **`Program.cs`**: top-level statements, services registered inline, ends with `public partial class Program;` for tests. `/Admin` is protected by the `Admin` policy.
- **Options**: each options class has `public const string Section` and is bound with `Configure<T>(GetSection(T.Section))` (`Payments`, `Legal`, `Email`).
- **C# style**: file-scoped namespaces, primary constructors, collection expressions `[]`, `required` members. Identifiers and comments in English; user-facing text, log messages, role names (`Admin`, `Moderatore`, `Agente`) and enum values like `Pubblica`/`Staff` in Italian.
- **Theme**: colours only as CSS variables in `wwwroot/css/theme.css`; `ThemeTests` fails on a hard-coded colour elsewhere. Emails keep their own palette in `Services/Email/EmailLayout.cs`.

## Data

- SQLite in development and tests; PostgreSQL in production (`Database:Provider=Postgres`, set by the Dockerfile), with a separate `PostgresDbContext`.
- **Every model change needs both migrations**, from `src/Soulslands.Web`:

  ```sh
  dotnet ef migrations add <Name>
  Database__Provider=Postgres dotnet ef migrations add <Name> --context PostgresDbContext --output-dir Data/Migrations/Postgres
  ```
- `Services/DataSeeder.cs` runs at startup: migrations, roles, admin from `Seed:AdminEmail`/`Seed:AdminPassword`, then `WikiContentImporter`. Data Protection keys live in the database.

## Money, keys and accounts

- `IPaymentGateway`: `StripePaymentGateway` and `SimulatedPaymentGateway` (only with `Payments:Provider=Simulato` **and** Development, never elsewhere). Webhook `POST /api/stripe/webhook` verifies the signature; orders complete in `OrderFulfillment`.
- Gift keys `XXXXX-XXXXX-XXXXX-XXXXX`: stored as SHA-256 (redeem) plus Data Protection ciphertext (shown to buyer). Redeem at `/Riscatta`.
- Rate limits in `Services/RateLimits.cs`: `redeem` 10/min per user, `launcher` 20/min per IP, 429 on excess. Keep them on any new public endpoint.
- Secrets: `dotnet user-secrets` locally, `.env`/environment in production. Never commit or print them.

## Game-facing API (contract with launcher and server)

`POST /api/launcher/login|logout`, `GET /api/launcher/me` (Bearer token, 30 days); `POST /api/session/join` (30 s tickets), `GET /api/session/hasjoined?playerId=&serverId=`; (no server list or heartbeat endpoints since 2026-10-26: removed with the public server list); `GET /api/health`. Documented in `soulslands-hq/wiki/sviluppo/sviluppo-api-launcher.md`: a change here updates that page in the same PR and must be announced to the PM (launcher and game depend on it). `/api` routes return bare status codes (no status pages).

## Wiki engine

`Services/WikiContentImporter.cs` (import), `WikiAccess.cs` (slug rule `^[a-z0-9]+(-[a-z0-9]+)*$`, not `modifica`, permissions), `WikiNavigation.cs`, `MarkdownRenderer.cs` (Markdig), `Pages/Wiki/*`. Import creates new pages and updates a page only if it was last updated by `sistema`, so pages edited on the site are never overwritten. Staff pages 404 for non-staff.

## Tests and CI

- `dotnet test` from the repo root. xUnit 2.9 with `WebApplicationFactory`: `SiteFactory` (in `tests/Soulslands.Web.Tests/WikiVisibilityTests.cs`) gives each run its own temp SQLite file; `TestAuthHandler` signs in from headers `X-Test-Roles` and `X-Test-User`. Use `IClassFixture<SiteFactory>`.
- Add tests for every new endpoint, every page with access rules and every money or key path.
- CI (`.github/workflows/ci.yml`): restore, build, `dotnet test`, plus a multi-arch Docker build (amd64, arm64).
- Local run: `cd src/Soulslands.Web && dotnet run` (Development; without SMTP, emails go to the log). Stripe locally: `stripe listen --forward-to http://localhost:5080/api/stripe/webhook`.
