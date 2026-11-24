# CLAUDE.md: soulslands-site (the Soulslands website)

Context for Claude Code sessions working in this repository. Part 1 describes Soulslands and its repositories; part 2 ("This repository") is about this repo. This repository is public: never add secrets, keys, `.env` values or staff material here.

## Soulslands in one paragraph

Soulslands is a medieval fantasy sandbox MMO written in Rust: the systems of Ultima Online (skills that rise by use up to 100.0, stats STR/DEX/INT driving stamina/mana/HP, races, classes, guilds, territory wars, full loot, stealing, PK reds redeemed by clerics, town guards, UO-style free-form backpacks and banks, carving creatures for crafting materials) in a fully editable procedural cubic-voxel world like Minecraft, with Minecraft-level modding. Owner: **Aruto** (GitHub `Arutosio`), who writes in Italian. The game is sold only on the official website by Aruto's future studio **Mahoroba** (registered before the public alpha). Platforms: Windows, Linux, macOS on Apple Silicon only.

## Decisions already made (do not reopen them)

- **World**: cubic voxels, heights y -64..319, sea at y 63, generated as players explore; creatures (the classic UO bestiary) spawn with the terrain. Each server is **one shared world** (no shards); everything (characters, items, banks) is saved server-side inside the world folder, which is portable like a Minecraft world.
- **Hosting**: like Minecraft, the dedicated server (SoulslandsServer: .zip / .tar.gz / Docker) is a free public download and anyone can host it; there is no official server. Joining online needs an activated (paid or gift-key) account checked by the website's session server. The client is installed by the **Soulslands Launcher** (Prism-like versions and instances).
- **Gameplay**: mixed combat (free aim for melee, bows, thrown potions; UO Sphere-style targeted spells); death leaves you a ghost for at least 1 minute like UO; human-shaped Valheim-like characters whose look is chosen at character creation (no website skins); in-game name unique per world; day/night cycle 2 real hours.
- **Look**: isometric or first-person camera, switchable; light graphics; hand-painted WoW-style textures, blocks painted at 64 px.
- **Tech**: Bevy 0.20 as client frame with our own voxel renderer; own server framework (bevy_ecs as a library), 20 Hz tick, own protocol on QUIC (quinn); mods = data packs + resource packs + sandboxed WASM (Wasmtime) on the server. 300,000 players in one world is a research goal (milestone M9), not a promise.
- **Language**: all code, identifiers, ids, asset names, logs and repo text in **English**. Ids are `namespace:name` (`soulslands:oak_log`); asset names are rational, never `00x1`. The game ships English-only but with Minecraft-style localization (one Fluent file per language). The website and its wiki are in Italian.

## Repositories (GitHub org `Soulslands`)

| Repo | What | Visibility |
|---|---|---|
| `soulslands-site` | This repository: the Soulslands game site (ASP.NET Core, .NET 10): game pages, devlog, benchmark pages, public wiki; a static site on Cloudflare that links to the studio | Public (since 2026-11-02, ADR-0035) |
| `soulslands-website` (old name on purpose) | The site's previous repository, kept as a read-only archive with the full history; links to its old pull requests stay on that name | Private, archived |
| `soulslands-game` | The game: one Cargo workspace with `game/` (the `ss-*` crates, apps, the data pack), `world/` (the world library), `launcher/` (the Soulslands Launcher); ADRs in `docs/adr/` | Private |
| `soulslands-assets` | Art pipeline: style source, the `texgen` generator, textures and icons, license register | Private |
| `soulslands-modsdk` | The mod SDK (from milestone M6) | Private, public later |
| `soulslands-hq` | The team headquarters: every agent skill (edited only there), agent definitions, staff wiki (`wiki/`), work board, roadmap, decisions and knowledge. No game code | Private |
| `Arutosio/mahoroba-website` | The Mahoroba studio site (outside the org): accounts, store, gift keys, downloads, launcher and session API; the game sites sign in through it (ADR-0024) | Private |

Only Aruto creates repositories; agents cannot.

## Where the source of truth lives

- **Architecture and plan**: staff wiki pages in `soulslands-hq/wiki/sviluppo/architettura/` (`architettura.md` is the index; `architettura-piano.md` holds milestones M0-M9 with exit criteria; `architettura-repository.md` the repo/crate map; `architettura-rischi.md` the later open choices). Change a decision there in the same PR as the code.
- **Open design questions**: `soulslands-hq/wiki/sviluppo/decisioni-da-confermare.md`.
- **Gameplay**: wiki folders `regole/`, `meccaniche/`, `skill/`, `razze/`, `classi/`, `gilde/`, `equipaggiamento/`, `risorse/`.
- **World content**: `WikiContent/mondo/` (blocks, trees, biomes, caves, oceans, lakes and rivers, structures, day and night).
- **Creatures**: `WikiContent/creature/` (103 pages, materials page `materiali-creature`).
- **Agent skills**: edited only in `.claude/skills/` of `Soulslands/soulslands-hq` (the team headquarters), which holds every skill. This repository keeps copies of the three its sessions need (`aspnet-core`, `website-dotnet`, `wiki-writing`), refreshed with `scripts/sync-skills.sh soulslands-site=<path>` in soulslands-hq; never edit a copy here. Each skill links its architecture page.

## How to work here

- Aruto granted full autonomy on the Soulslands repos: branch, commit, open a PR and merge it when CI is green. Ask only real questions. Talk to Aruto in Italian.
- Planning, chat history and project notes live in a Claude project that a local session cannot read; this file, the wiki and the skills are the handoff. If a decision is missing here, ask Aruto rather than guessing.
- Agreed order: finish the website first (the game's showcase), then game milestone M0. In parallel the world content goes into the data pack: natural blocks with texture specs first, then built blocks/furniture/placeable containers, then the structures redone with real blocks.
- **Phases and CI**: the roadmap is ordered by product phases (`soulslands-hq/docs/roadmap/phases.md`). This repository is public, so its GitHub Actions run on free hosted runners: `.github/workflows/ci.yml` on every push to `main` and every pull request; run `dotnet build` and `dotnet test` from the repo root before opening a PR.

## This repository

The Soulslands game site, **a static site** (W-21, W-22): game pages, devlog (Atom feed), benchmark pages and the public Markdown wiki, all read from files in `src/Soulslands.Web/WikiContent/`. There is no sign-in, no database, no server list, no cookie and no server-side state. Everything dynamic lives in the Mahoroba studio site (`Arutosio/mahoroba-website`, ADR-0024 in soulslands-game): accounts, store, gift keys, downloads, legal pages, the launcher/session API under `/api/games/soulslands/` and the home page announcements, which the visitor's browser fetches from the studio. This site only links there (`StudioOptions`, section `Studio`); the old paths of moved pages redirect to the studio through `dist/_redirects`. The UI text is Italian.

- **Run / test**: see `README.md` (`dotnet run` in `src/Soulslands.Web` for a preview, `dotnet test` from the root; the Playwright tests in `tests/Soulslands.Web.E2E/` are outside the solution). CI (`.github/workflows/ci.yml`): build and tests, the browser tests, and the static site job.
- **Build and deploy**: `scripts/build-static.sh` runs the site in memory (`src/Soulslands.StaticExport`), crawls every public page and writes `dist/` with `_headers`, `_redirects` and the wiki search index. Cloudflare Workers Builds (project `soulslands-site`, static assets only, `wrangler.jsonc`) runs it on every push to `main` and serves `dist/` at `soulslands.mahoroba.studio` (domain decided 2026-10-25). The build uses no secret. Settings: README, "Sito statico su Cloudflare".
- **Nothing dynamic may come back**: no endpoint that writes, no form, no cookie, no database, no secret. The export fails on runtime markers (sign-in, Admin, server list, `document.cookie`) and on a broken internal link; `SiteTests.NothingOfTheDynamicSiteAnswers` and `NoDatabaseTests` guard the preview. A new dynamic feature belongs in the studio app (ADR-0024 section 6).
- **Theme**: every colour and font lives only in `src/Soulslands.Web/wwwroot/css/theme.css`; `ThemeTests` fails otherwise. Style: orange/black/grey, ember particles, gradients, glow and transparency like the Cursed Souls UO site, gold glow for titles and key text, cyan only for small details. Visitors can switch from the Cursed Souls UO font to browser fonts with the footer button (kept in `localStorage`).
- **Wiki**: Markdown with front matter (`title`, `slug`, `category`, `visibility: Pubblica`) in `src/Soulslands.Web/WikiContent/`, read once at startup by `WikiStore` (the devlog is in `devlog/`, read by `DevlogStore`). This repository is public and holds public pages only (ADR-0035): staff pages live in `soulslands-hq/wiki/`. The rule fails closed (`Services/PublicPages.cs`): a page that does not say exactly `visibility: Pubblica` stops `WikiStore`, so neither `dotnet run` nor the export starts, and `PublicWikiTests` fails on such a page or on a `/wiki/<slug>` link to a slug that is not here. "Aggiornata il" is the file's last Git commit. Pages may use ```mermaid diagrams. Old content was carried over from the Cursed Souls wiki (github.com/UOCursedSouls/WebPageUOCursedSouls). Avoid the names "Ultima" and "Britannia" in public text (EA trademarks).

## Work in progress elsewhere (avoid these files)

- The "world library" work is editing the block pages of the wiki right now: `WikiContent/mondo/blocchi.md` and the new `mondo/texture-blocchi.md` and `mondo/blocchi-costruzione.md`. Do not touch them until that PR is merged; pull `main` first.
