# Soulslands: sito web

Sito ufficiale di Soulslands: pagine del gioco, devlog, pagine dei benchmark e wiki pubblica. È un **sito statico**: `scripts/build-static.sh` produce la cartella `dist/` e Cloudflare la serve su `soulslands.mahoroba.studio`.

Tutto quello che ha bisogno di un server sta nel sito dello studio Mahoroba (`Arutosio/mahoroba-website`, SoulslandsGame ADR-0024): account, accesso, acquisto, key regalo, download, pagine legali, API del launcher e del session server (`/api/games/soulslands/`) e la bacheca degli annunci. Questo sito non ha account, database, cookie né segreti: rimanda allo studio con dei link.

Stack: ASP.NET Core su .NET 10 e Razor Pages, usati solo per generare le pagine; Markdig per il Markdown.

## Avvio in locale

Serve il .NET 10 SDK.

```bash
cd src/Soulslands.Web
dotnet run          # anteprima su http://localhost:5000
```

L'anteprima mostra le stesse pagine della build statica, lette dai file di `WikiContent/`; non serve né lo studio né un database. Per vedere il sito esattamente come su Cloudflare usa `scripts/build-static.sh` (sotto, "Sito statico su Cloudflare").

| Impostazione | Cosa | Default |
|---|---|---|
| `Studio:AccountUrl` | Host degli account dello studio (negozio, download, key regalo, bacheca); sempre `https://` (con `http://` il sito non parte) | `https://account.mahoroba.studio` |
| `Studio:StudioUrl` | Pagine dello studio (privacy, termini, contatti) | `https://mahoroba.studio` |
| `Site:BaseUrl` | Indirizzo pubblico del sito, per i link assoluti del feed | vuoto (`dotnet run`); `https://soulslands.mahoroba.studio` nella build |
| `Wiki:Directory`, `Devlog:Directory`, `Benchmark:Directory` | Cartelle di wiki, devlog e benchmark (assolute o relative alla cartella del sito); i test le puntano alle fixture | `WikiContent`, `WikiContent/devlog`, `WikiContent/benchmark` |

## Test

```bash
dotnet test
```

I test non creano file di database (`NoDatabaseTests` lo verifica) e non leggono `WikiContent/` dove non serve: post, benchmark e pagine di prova vengono dalle fixture in `tests/Soulslands.Web.Tests/Fixtures/`.

I test nel browser (Playwright, Chromium headless) stanno in `tests/Soulslands.Web.E2E/`, fuori da `Soulslands.slnx`, così `dotnet test` dalla radice non richiede un browser. Avviano il sito vero su Kestrel con una porta libera, e `StaticSiteE2ETests` prova la `dist/` servita come da Cloudflare. Per eseguirli la prima volta:

```bash
dotnet build tests/Soulslands.Web.E2E
(cd tests/Soulslands.Web.E2E/bin/Debug/net10.0 && .playwright/node/linux-x64/node .playwright/package/cli.js install chromium)   # una volta, scarica il browser (senza pwsh, come la CI)
dotnet test tests/Soulslands.Web.E2E
```

La CI li esegue nei job `e2e` e `static-site`.

## Wiki

Le pagine stanno in `src/Soulslands.Web/WikiContent/` come file Markdown con front matter:

```
---
title: Elfo
slug: razza-elfo
category: Razze
visibility: Pubblica
---
```

`category` può avere una sottocategoria (`Classi / Magia`). Il sito legge le pagine all'avvio (`Services/WikiStore.cs`) e le tiene in memoria; una pagina cambia solo con un commit. "Aggiornata il" è la data dell'ultimo commit Git del file.

Questo repository è pubblico e contiene solo pagine pubbliche (ADR-0035): le pagine Staff stanno in `soulslands-hq/wiki/`. La regola è chiusa per difetto (`Services/PublicPages.cs`): se una pagina non dice esattamente `visibility: Pubblica` (una chiave scritta in altro modo, un altro valore, una riga `visibility: staff`), il sito non parte e la build statica si ferma, nominando il file. Uno slug duplicato o non valido viene ignorato e segnalato nel log.

## Devlog

I post del devlog stanno in `src/Soulslands.Web/WikiContent/devlog/`, un file Markdown per post. Non sono pagine wiki: la wiki salta la cartella `devlog/`. Il sito li legge al primo accesso e li tiene in memoria, quindi un post nuovo arriva con la build successiva. `/devlog` elenca i post dal più recente, `/devlog/{slug}` mostra un post (Markdown come la wiki, diagrammi ```mermaid compresi). I post sono pubblici: un post può non dire nulla sulla visibilità o dire `visibility: Pubblica`; ogni altro valore (o una riga `visibility: staff`) ferma l'avvio del sito e la build statica, nominando il file, come per la wiki.

Il front matter ha cinque campi, tutti obbligatori:

```
---
title: Il sito è pronto
slug: il-sito-e-pronto
date: 2026-10-18
summary: Una o due frasi che compaiono nell'elenco dei post.
author: Aruto
---
```

- `slug`: stessa regola della wiki (minuscole, cifre e trattini); deve essere unico tra i post.
- `date`: formato `YYYY-MM-DD`; stabilisce l'ordine dell'elenco.
- Un post con un campo mancante o non valido, o con uno slug già usato, viene ignorato e segnalato nel log con il nome del file.

La cartella si può cambiare con `Devlog:Directory` (percorso assoluto o relativo alla cartella del sito); i test la usano per leggere post da una cartella temporanea.

Il feed Atom (`/devlog/feed.xml`) costruisce id e link da `Site:BaseUrl` (es. `https://soulslands.arutosio.com`), così restano stabili qualunque sia l'indirizzo della richiesta; se è vuoto (`dotnet run`) li prende dalla richiesta. Nella build statica lo imposta `scripts/build-static.sh` (variabile `SITE_BASE_URL`, predefinita `https://soulslands.mahoroba.studio`).

## Benchmark

I risultati dei benchmark sono file JSON nel formato v1 definito dall'ADR-0002 di SoulslandsGame (`docs/adr/0002-benchmark-result-v1.md`, schema in `docs/benchmark/`). Li pubblica il wiki-writer in `src/Soulslands.Web/WikiContent/benchmark/<milestone>/`, un file per scenario e macchina (`<scenario>--<macchina>.json`); i file grezzi stanno in `<milestone>/raw/`. Come per il devlog, il sito li legge al primo accesso e li tiene in memoria.

- `/benchmark/{milestone}` (per esempio `/benchmark/m0`): una pagina pubblica per milestone con commit, data, hardware, sistema operativo, versioni e impostazioni di Soulslands e di Minecraft, scenario e la tabella delle metriche (p50, p99, massimo, soglia, valore di Minecraft). Le righe in cui Minecraft fa meglio sono segnate e mai nascoste; i valori di Minecraft con `origin: estimate` compaiono come stima con la fonte. Una milestone senza file validi risponde 404.
- `/benchmark/{milestone}/raw/{file}`: scarica un file grezzo, solo se un risultato di quella milestone lo elenca in `raw`.
- Un file con `format_version` diverso da 1, o senza un campo obbligatorio, viene ignorato e segnalato nel log con il suo percorso; gli altri file restano visibili. I campi sconosciuti vengono ignorati.
- La build statica copia in `dist/` ogni file grezzo elencato da un risultato; i file `.json` restano in `WikiContent/` (le pagine li mostrano già).

La cartella si può cambiare con `Benchmark:Directory` (percorso assoluto o relativo alla cartella del sito); i test usano le fixture in `tests/Soulslands.Web.Tests/Fixtures/Benchmark/`, copiate dagli esempi dell'ADR, che non sono misure e non vanno mai copiate in `WikiContent/`.

## Sito statico su Cloudflare

`soulslands.mahoroba.studio` è un sito statico servito da Cloudflare Workers come *static assets* (progetto Workers Builds `soulslands-site`, configurazione in `wrangler.jsonc`: solo file, nessuno script Worker). `scripts/build-static.sh` avvia il sito in memoria (`src/Soulslands.StaticExport`, nessuna porta aperta), visita ogni pagina pubblica come un visitatore anonimo e scrive tutto in `dist/`:

- ogni pagina come `<percorso>/index.html` (la home `index.html`, la pagina 404 `404.html`), il feed `devlog/feed.xml`, i file grezzi dei benchmark e i file di `wwwroot` che le pagine usano;
- `_redirects`: le vecchie pagine passate allo studio (`/Acquista`, `/Riscatta`, `/Download` sull'host degli account, `/Privacy`, `/Termini`, `/Contatti` sul sito dello studio), `/Preferenze` verso la home e le grafie minuscole (`/media`, `/download`...), perché Cloudflare distingue maiuscole e minuscole;
- `_headers`: Content-Security-Policy senza script inline (gli stili inline restano permessi: li usano i diagrammi mermaid e le barre di avanzamento), `nosniff`, `Referrer-Policy`, `X-Frame-Options: DENY`, `Permissions-Policy`;
- `wiki/indice-ricerca.json`: l'indice della ricerca nella wiki, filtrato nel browser.

"Aggiornata il" su una pagina della wiki è la data dell'ultimo commit Git del suo file, così due build dello stesso commit danno la stessa `dist/`. Cloudflare clona il repository con `--depth 1`: in un clone parziale con un remote lo script prima scarica il resto della storia (`git fetch --unshallow`, il repository è pubblico); se non ci riesce, o senza Git, stampa un avviso e la riga non compare. Se la build fallisce, `dist/` viene cancellata.

Workers applica `_headers` e `_redirects` della cartella `dist/` come Pages; `/Media` risponde 307 verso `/Media/` (`html_handling: auto-trailing-slash`) e ogni percorso senza file riceve `404.html` con stato 404 (`not_found_handling: 404-page`).

Il sito non ha accesso, menu Admin, elenco dei server, editor della wiki né cookie (sono stati tolti con W-22). La bacheca della home arriva dallo studio nel browser (`https://account.mahoroba.studio/api/games/soulslands/announcements`) e resta nascosta se è vuota o lo studio non risponde; la scelta dei caratteri è un pulsante nel piè di pagina, salvato in `localStorage`.

Lo script si ferma con un errore, nominando il file, se una pagina di `WikiContent/` non dice esattamente `visibility: Pubblica` (un post del devlog può anche non dirlo; ogni altro valore, una chiave scritta in altro modo come `visibilità` o una riga `visibility: staff` bloccano la build), se in `dist/` c'è il nome di una pagina staff, un pezzo del sito dinamico (accesso, Admin, server) o `document.cookie`, o se un link interno di una pagina non ha un file in `dist/`. Se .NET manca (l'immagine di build di Cloudflare non lo ha) installa l'SDK indicato in `global.json` con la copia di `scripts/dotnet-install.sh` (Microsoft, licenza MIT) in `~/.dotnet`. L'export porta con sé l'ICU (i dati della lingua italiana: ordine della wiki, numeri) su Linux x64, quindi non dipende dalla `libicu` della macchina; se mancasse comunque si ferma con "ICU non disponibile" invece di scrivere pagine sbagliate.

In locale:

```bash
scripts/build-static.sh                      # scrive dist/
python3 -m http.server -d dist 8000          # http://localhost:8000
npx wrangler dev                             # come Cloudflare (wrangler.jsonc): esegue la build, poi serve dist/ con _headers e _redirects
```

**Impostazioni nella dashboard di Cloudflare** (Workers & Pages → `soulslands-site` → Settings → Build; repository GitHub `Soulslands/soulslands-site`, non il vecchio `soulslands-website`). La build è in `wrangler.jsonc` (`build.command`): wrangler esegue `scripts/build-static.sh` prima di `deploy`, `versions upload` e `dev`, quindi nella dashboard bastano i comandi di deploy:

| Impostazione | Valore |
|---|---|
| Deploy command | `npx wrangler deploy` |
| Non-production branch deploy command | `npx wrangler versions upload` (il valore predefinito) |
| Build command | facoltativo, di solito vuoto; se vale `scripts/build-static.sh` la build gira due volte, senza danni (ogni volta riscrive `dist/` da zero) |
| Root directory | vuota (radice del repository) |
| Production branch | `main` |
| Build variable | facoltativa: `SITE_BASE_URL` vale già `https://soulslands.mahoroba.studio` (serve ai link assoluti del feed) |

Il nome del Worker nella dashboard deve restare `soulslands-site`, come `name` in `wrangler.jsonc`, altrimenti la build fallisce. Il Worker nasce con il primo deploy da `main`: prima di allora le build delle pull request (`versions upload`) falliscono con "This Worker does not exist on your account". La build non usa segreti; sulle URL di anteprima la bacheca resta nascosta (lo studio risponde solo a `soulslands.mahoroba.studio`). Il dominio `soulslands.mahoroba.studio` si collega a mano in Settings → Domains & Routes → Custom domain: `wrangler.jsonc` non ha `routes` né `custom_domain`, perché il dominio ha già un record DNS e un conflitto farebbe fallire tutto il deploy.

**Alternativa**: lo stesso `dist/` funziona su Cloudflare Pages (preset None, build command `scripts/build-static.sh`, output `dist`), oppure si carica da GitHub Actions con `npx wrangler deploy` e un token API di Cloudflare come segreto del repository (`CLOUDFLARE_API_TOKEN`, `CLOUDFLARE_ACCOUNT_ID`), che solo Aruto può creare: non è in questo repository.

La CI controlla tutto nel job `static-site`: esegue `scripts/build-static.sh` e i test nel browser (`StaticSiteE2ETests`) sulla `dist/` servita come da Cloudflare (`tests/Soulslands.Web.E2E/serve-static.py`).

## Tema grafico

Aspetto e struttura sono separati. Tutti i colori del sito stanno in `wwwroot/css/theme.css` come variabili CSS (`--ss-orange`, `--ss-gold`, `--ss-cyan`, …, più le versioni `-rgb` per le trasparenze e le tonalità delle braci). `site.css`, le pagine e `site.js` leggono solo quelle variabili: per cambiare palette si modifica soltanto `theme.css`. Un test (`ThemeTests`) fallisce se un colore scritto a mano compare fuori dal tema.

## Struttura

```
src/Soulslands.Web/
  Pages/            home, wiki, devlog, benchmark, regole, media, stato, pagine di errore
  Services/         wiki (WikiStore, regola delle pagine pubbliche), Markdown, devlog, benchmark, indice di ricerca, link allo studio
  WikiContent/      le pagine della wiki in Markdown; devlog/ contiene i post, benchmark/ i risultati dei benchmark
src/Soulslands.StaticExport/   la build statica (dist/), avviata da scripts/build-static.sh
tests/Soulslands.Web.Tests/    test unitari e di integrazione
tests/Soulslands.Web.E2E/      test nel browser (Playwright)
```
