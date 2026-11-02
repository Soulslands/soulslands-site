---
name: wiki-writing
description: How Soulslands wiki pages are written - front matter, slugs, visibility, structure, the "Vedi anche" footer and the Italian style. Use whenever creating or editing Markdown in soulslands-site/src/Soulslands.Web/WikiContent/ (public pages) or soulslands-hq/wiki/ (staff pages).
---

# Writing the Soulslands wiki

The wiki lives as Markdown files in two roots (ADR-0035). Public pages (`visibility: Pubblica`) are in `~/GitRepositories/soulslands-site/src/Soulslands.Web/WikiContent/<category>/` (folders: classi, creature, equipaggiamento, generale, gilde, meccaniche, mondo, razze, regole, risorse, skill). Staff pages (`visibility: Staff`: the `sviluppo/` folder and `decisioni`) are in SoulslandsHQ, `~/GitRepositories/soulslands-hq/wiki/<category>/`, at the same relative paths as before; the public repository holds no staff page. A page lives in one root only, a public page never links a staff slug, and a `/wiki/<slug>` link resolves in either root. At startup the site imports new pages and updates changed ones, but never overwrites a page edited from the site.

## Front matter (required)

```markdown
---
title: Elfo Oscuro
slug: razza-elfo-oscuro
category: Razze
visibility: Pubblica
---
```

- `slug` must match `^[a-z0-9]+(-[a-z0-9]+)*$`, be unique, and not be `modifica`. Use a category prefix as the existing pages do (`razza-`, `mostro-`, `bioma-`, `architettura-`). A duplicate or invalid slug makes the page silently skipped.
- `category` may have a subcategory: `Classi / Magia`, `Sviluppo / Architettura`.
- `visibility`: `Pubblica` (default) or `Staff`. Development pages (`sviluppo/`, in `soulslands-hq/wiki/`) are `Staff` and start with "Pagina riservata ad Admin, Moderatori e Agenti."

## Page shape

- `# <emoji> Title`, then an italic tagline (gameplay pages) or a short intro saying what the page answers (architecture pages).
- Sections with `##` headings that start with an emoji, like the existing pages.
- Tables for values; Mermaid diagrams (` ```mermaid `) are rendered by the site, with a sentence before each diagram saying what it shows.
- Decision tables in architecture pages use the columns `Scelta | Perché | Scartato`.
- Links between pages: `[Testo](/wiki/<slug>)`; check every slug exists (`grep -r "^slug: <slug>$"`).
- Footer: gameplay pages end with `## 🔗 Vedi anche` and a list `- [Titolo](/wiki/slug) — breve descrizione`; architecture pages end with an italic line `*Vedi anche: [A](/wiki/a) | [B](/wiki/b)*`. Follow the style of the folder you are in.

## Italian style

- Plain, concrete Italian for players and staff, short sentences, no marketing tone. Explain technical terms the first time ("un worktree, cioè una copia di lavoro separata").
- Code, ids, crate names and file paths stay in English inside backticks: `soulslands:oak_log`, `ss-simulation`.
- Numbers with their source: a link, "misurato da noi", or "stima nostra". Dates as `17/10/2026`. Decimal comma in prose (`2,5 s`), thousands with a dot (`300.000`).
- Decisions by Aruto are written as "**Deciso da Aruto (gg/mm/aaaa):** ...". Proposals stay marked as proposals and are listed in `sviluppo/decisioni-da-confermare.md`.

## Devlog posts

Devlog posts are not wiki pages: they live in `WikiContent/devlog/<slug>.md`, one Markdown file per post, the wiki import skips that folder, and the site shows them on `/devlog`, `/devlog/<slug>`, the home page and the Atom feed. Their front matter has five fields, all required:

```markdown
---
title: Il sito è pronto, ecco il piano
slug: il-sito-e-pronto-ecco-il-piano
date: 2026-10-18
summary: Una o due frasi che compaiono nell'elenco dei post e nel feed.
author: Il team di Soulslands
---
```

- `slug` follows the wiki slug rule and is unique among posts; by convention it also matches the file name (the site keys posts by slug only); `date` is `YYYY-MM-DD` (it orders the list); no `category` or `visibility`: posts are always public.
- A post with a missing or invalid field, or a repeated slug, is skipped and logged with its file name, so check it shows on `/devlog` when running the site locally.
- Posts are public: no staff-only details (costs, keys, internal decisions not yet announced), no dates or durations for milestones, no "Ultima" or "Britannia". By convention the body starts with `# Title` (without it the page shows the front-matter title) and follows the Italian style below. Field rules are in the website `README.md`, section Devlog.

## Keeping it consistent

- When a fact changes, grep both roots (`WikiContent/` and `soulslands-hq/wiki/`) for the old fact and update every page in the same PR.
- Never edit pages listed as locked in `~/GitRepositories/soulslands-hq/docs/board.md`.
- Verify public pages with `dotnet build` and `dotnet test` in the website repo (they cover import and visibility), staff pages with `python3 scripts/check-roadmap.py` in soulslands-hq (it reads both roots).
