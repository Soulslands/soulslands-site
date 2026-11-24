---
name: website-dotnet
description: Conventions of the two ASP.NET Core .NET 10 Razor Pages repos - soulslands-site (the static Soulslands site - devlog, benchmark and wiki pages read from files, exported to Cloudflare, no database) and mahoroba-website (the studio app - Identity, OIDC provider, EF Core with SQLite and Postgres migrations, Stripe, gift keys, launcher/session API, email). Use before changing or testing code in either repo.
---

# Website conventions (soulslands-site and mahoroba-website)

Both repos have their own `CLAUDE.md`: read it first. Which feature lives in which app is fixed by ADR-0024 section 6 (mahoroba-website `docs/adr/`).

## Common

- Target `net10.0`, `Nullable` and `ImplicitUsings` on. **Razor Pages only**, no MVC controllers.
- Machine endpoints are minimal APIs in static classes with `Map(...)` and static handlers using `[FromServices]`; contracts live next to the code, there is no `Api/` folder.
- `Program.cs`: top-level statements, services registered inline, ends with `public partial class Program` for tests.
- Options: each class has `public const string Section`, bound with `Configure<T>(GetSection(T.Section))`.
- C#: file-scoped namespaces, primary constructors, collection expressions `[]`, `required` members. Code, identifiers, comments and commits in English.
- Colours (and in the studio fonts) live in one CSS file, checked by `ThemeTests`: soulslands-site `wwwroot/css/theme.css`, mahoroba-website `wwwroot/css/tokens.css` (`DESIGN.md`).
- Tests: xUnit with `WebApplicationFactory` through a `SiteFactory` in the test project, `IClassFixture<SiteFactory>`; per-test settings with `WithWebHostBuilder(b => b.UseSetting(...))`. Playwright tests are in `tests/*.E2E`, outside the solution. Every new endpoint, page rule or refusal gets a test.
- Page text: soulslands-site in Italian (page folders too: `Pages/Wiki`, `Devlog`, `Benchmark`); mahoroba-website in English with Japanese under `/ja` (`@T["English"]` plus `Resources/SharedResource.ja.resx`), Italian only on the dev host.

## soulslands-site (static)

Solution `Soulslands.slnx`: `src/Soulslands.Web` (the Razor app), `src/Soulslands.StaticExport`, `tests/Soulslands.Web.Tests`; `tests/Soulslands.Web.E2E` is outside it. Checks before a PR: `dotnet build` and `dotnet test` from the repo root.

- The site is static (W-21, W-22). `scripts/build-static.sh` runs `src/Soulslands.StaticExport`, which hosts the Razor app in memory (`WebApplicationFactory`), crawls every public page as an anonymous visitor and writes `dist/` with `_headers`, `_redirects` and the wiki search index. Cloudflare Workers Builds (project `soulslands-site`, static assets only, `wrangler.jsonc` `build.command`) runs it on every push to `main`.
- Nothing dynamic comes back: no database, sign-in, cookie, form, secret or endpoint that writes. A dynamic feature belongs in the studio app. The export fails on runtime markers (sign-in, Admin, server list, `document.cookie`) and on an internal link without a file.
- Content is files read once at startup: `WikiStore` (wiki pages, slug rule `WikiStore.IsValidSlug`), `DevlogStore` (`WikiContent/devlog/`), `BenchmarkStore` (`WikiContent/benchmark/`). The only minimal APIs are `DevlogFeed` and `SearchIndex` (`/wiki/indice-ricerca.json`).
- Public pages only: `Services/PublicPages.cs` (CODEOWNERS) fails closed. A wiki page needs exactly `visibility: Pubblica`, a post that or nothing; anything else stops `dotnet run` and the export, naming the file (ADR-0035). Page content in `WikiContent/` belongs to `wiki-writer`; the engine is yours.
- "Aggiornata il" is the last Git commit of each file (`GitDates`). `build-static.sh` unshallows a shallow clone first; a test that needs dates builds a temp repository (`TestGit`).
- `dist/` must stay byte-stable: Razor emits the source indentation, so removing an `@if` wrapper changes the output. When a layout changes, build `dist/` at the base and at the head and compare with `diff -r`.
- Options: `Studio`, `Site`, `Wiki`, `Devlog`, `Benchmark`. Links to the studio come from `StudioOptions` (`Studio:AccountUrl`, https only, and `Studio:StudioUrl`). Pages moved to the studio redirect through `SiteFiles.MovedPages` (`dist/_redirects`).
- Tests: `SiteFactory` (`tests/Soulslands.Web.Tests/SiteFactory.cs`) sets only the studio URLs; point a store at fixtures with `UseSetting("Wiki:Directory", dir)`. `NoDatabaseTests`, `NoPageSetsACookie` and `SiteTests.NothingOfTheDynamicSiteAnswers` guard the static shape; `StaticSiteE2ETests` runs on the exported `dist/`.
- CI (`ci.yml`): `build-and-test`, `e2e` and `static-site` (the export, a server-parts grep, the browser tests on `dist/`).

## mahoroba-website (studio app)

Solution `Mahoroba.slnx`: `src/Mahoroba.Web`, `tests/Mahoroba.Web.Tests`; `tests/Mahoroba.Web.E2E` outside it. Read `CLAUDE.md`, `DESIGN.md`, `docs/development.md`, `docs/PLAN.md` and ADR-0024 first. Checks before a PR: `scripts/ci.sh` (local CI; its `PASS ...` line goes in the PR body).

- **Accounts**: ASP.NET Core Identity, pages in `Areas/Identity/Pages/` (`LocalizedIdentityErrorDescriber`), admin in `Pages/Admin/`; OpenIddict OIDC provider in `Services/Auth/`. Every cookie is host-only `__Host-`; absolute links and redirects between hosts come from `Site:BaseUrl`/`Site:AccountHost`, never from the Host header.
- **Data**: SQLite in development and tests, PostgreSQL in production (`Database:Provider=Postgres`, `PostgresDbContext`); `DataSeeder` applies migrations at start. **Every model change needs both migrations**, from `src/Mahoroba.Web`:

  ```sh
  dotnet ef migrations add <Name> --context ApplicationDbContext --output-dir Data/Migrations
  Database__Provider=Postgres dotnet ef migrations add <Name> --context PostgresDbContext --output-dir Data/Migrations/Postgres
  ```
- **Money and keys**: `IPaymentGateway` with `StripePaymentGateway` and `SimulatedPaymentGateway` (only with `Payments:Provider=Simulated` **and** Development). `POST /api/stripe/webhook` verifies the signature; orders complete in `OrderFulfillment`. Gift keys `XXXXX-XXXXX-XXXXX-XXXXX` (`GiftKeyCodes`) are stored as SHA-256 (redeem) plus Data Protection ciphertext (shown to the buyer); redeem at `/Redeem`; ownership in `Services/Entitlements/`.
- **Rate limits**: `Services/RateLimits.cs` (section `RateLimits`: forms, sign-in, OIDC authorize and token, redeem, launcher login, launcher, hasjoined, skins...), 429 on excess. Every new public endpoint gets one.
- **Game-facing API** under `/api/games/<game>/` (`LauncherApi.Prefix`, unknown game 404): `launcher/login|logout|me` (Bearer token, 30 days), `session/join` (30 s tickets) and `session/hasjoined`, `profile` and skins, `reports`, `releases`, `announcements`, `reserved-names`, `page`. No server list and no heartbeat (Aruto, 2026-10-26). Contract: ADR-0014 and `soulslands-hq/wiki/sviluppo/sviluppo-api-launcher.md`; a change updates that page in the same round and goes through the PM (`architect`, `launcher-dev`, `server-dev`). `/api` routes return bare status codes.
- **Email**: `Services/Email/` (SMTP from `EmailOptions`, queued sender, own palette in `EmailLayout.cs`); tests capture mail with `CapturedEmails`.
- **Tests**: `SiteFactory` runs in Production with its own temp SQLite file and the OIDC test client; sign in with the `SignInAsync` helper. `LocalizationTests` fails on a string without its Japanese.
- **Security**: tests for every money, key or sign-in path; never log secrets, keys or `.env` values (`dotnet user-secrets` locally). PRs on CODEOWNERS paths start with "Aruto reviews (CODEOWNERS)".
