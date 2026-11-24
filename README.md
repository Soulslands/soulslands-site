# Soulslands: sito web

Sito ufficiale di Soulslands: pagine del gioco, devlog, pagine dei benchmark, wiki (pubblica e Staff), elenco dei server della community con heartbeat.

Account, accesso, acquisto, key regalo, download, pagine legali e API del launcher stanno nel sito dello studio Mahoroba (`Arutosio/mahoroba-website`, SoulslandsGame ADR-0024): questo sito non ha account propri e fa entrare le persone tramite il provider OpenID Connect dello studio.

Stack: ASP.NET Core su .NET 10, Razor Pages, client OpenID Connect, EF Core (SQLite in sviluppo, PostgreSQL in produzione).

## Avvio in locale

Serve il .NET 10 SDK.

```bash
cd src/Soulslands.Web
dotnet run          # http://localhost:5000
```

All'avvio il sito applica le migrazioni e importa le pagine della wiki. Tutto funziona senza studio tranne l'accesso ("Accedi" porta al sito dello studio).

### Accesso con lo studio in locale

Per entrare davvero serve lo studio avviato in locale (README di `mahoroba-website`, "Run for development"), su `https://localhost:5001`, con questo sito registrato come client. Il segreto del client è lo stesso nei due siti e resta nei user secrets:

```bash
SECRET=$(openssl rand -hex 32)
# nello studio (cartella di mahoroba-website)
dotnet user-secrets set "Oidc:Clients:0:ClientId" "soulslands-website" --project src/Mahoroba.Web
dotnet user-secrets set "Oidc:Clients:0:ClientSecret" "$SECRET" --project src/Mahoroba.Web
dotnet user-secrets set "Oidc:Clients:0:RedirectUris:0" "http://localhost:5000/signin-oidc" --project src/Mahoroba.Web
dotnet user-secrets set "Oidc:Clients:0:PostLogoutRedirectUris:0" "http://localhost:5000/signout-callback-oidc" --project src/Mahoroba.Web
# in questo sito (cartella src/Soulslands.Web)
dotnet user-secrets set "Studio:AccountUrl" "https://localhost:5001"
dotnet user-secrets set "Studio:StudioUrl" "https://localhost:5001"
dotnet user-secrets set "Studio:ClientSecret" "$SECRET"
```

Lo studio accetta un indirizzo `http://` solo su localhost e solo in Development.

## Accesso tramite lo studio

- **Flusso**: authorization code con PKCE verso `Studio:AccountUrl` (default `https://account.mahoroba.studio`), client confidenziale `soulslands-website`, scope `openid profile roles`, risposta in `form_post` su `/signin-oidc`. Codice in `Services/Auth/`.
- **Cosa arriva**: `sub` (l'id dell'account, un UUID minuscolo), `name` (il nome pubblico, solo se l'account ne ha uno), `role` (i ruoli Staff dello studio). Mai l'email. Il sito salva il `sub` dove serve un utente: proprietario dei server, autore delle modifiche alla wiki.
- **Cookie**: `__Host-Soulslands`, solo per questo host, `Secure`, `HttpOnly`, `SameSite=Lax`, dura 1 ora e non si rinnova. Dopo un'ora il browser ripassa dallo studio, che lo fa rientrare senza password finché la sessione dello studio è valida: così un ruolo tolto o un account bloccato arriva qui entro un'ora. Il cookie contiene solo l'id token, che serve per uscire.
- **Esci**: chiude la sessione qui e nello studio (`/connect/endsession` con `id_token_hint` e `client_id`).
- **Data Protection**: le chiavi stanno nel database di questo sito con il nome di applicazione `Soulslands.Web`, mai condivise con lo studio; cookie e token antiforgery restano validi dopo un riavvio.
- Una pagina della wiki nascosta o inesistente risponde 404; se il browser ha ancora il cookie scaduto, torna invece dallo studio per rientrare (stessa risposta per pagine Staff e inesistenti, così non si scopre quali pagine Staff esistono).
- I vecchi indirizzi delle pagine passate allo studio (`/Acquista`, `/Riscatta`, `/Download`, `/Privacy`, `/Termini`, `/Contatti`) rimandano lì.
- La scelta dei caratteri (Cursed Souls o quelli del browser) è in `/Preferenze` e resta in un cookie del browser.

| Impostazione | Cosa | Default |
|---|---|---|
| `Studio:AccountUrl` | Host degli account dello studio, emittente OIDC; sempre `https://`, anche in locale (con `http://` il sito non parte) | `https://account.mahoroba.studio` |
| `Studio:StudioUrl` | Pagine dello studio (privacy, termini, contatti) | `https://mahoroba.studio` |
| `Studio:ClientId` | Id del client registrato nello studio | `soulslands-website` |
| `Studio:ClientSecret` | Segreto del client: user secrets o `.env`, mai nel repository | vuoto |

## Test

```bash
dotnet test
```

I test nel browser (Playwright, Chromium headless) stanno in `tests/Soulslands.Web.E2E/`, fuori da `Soulslands.slnx`, così `dotnet test` dalla radice non richiede un browser. Avviano il sito vero su Kestrel con una porta libera, con post e risultati di benchmark delle fixture (mai `WikiContent/`). Per eseguirli la prima volta:

```bash
dotnet build tests/Soulslands.Web.E2E
pwsh tests/Soulslands.Web.E2E/bin/Debug/net10.0/playwright.ps1 install chromium   # una volta, scarica il browser
dotnet test tests/Soulslands.Web.E2E
```

La CI li esegue nel job `e2e`.

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

`category` può avere una sottocategoria (`Classi / Magia`), `visibility` è `Pubblica` o `Staff`. All'avvio il sito crea le pagine nuove e aggiorna quelle cambiate, ma non sovrascrive mai una pagina modificata dal sito.

## Devlog

I post del devlog stanno in `src/Soulslands.Web/WikiContent/devlog/`, un file Markdown per post. Non sono pagine wiki: l'import della wiki salta la cartella `devlog/`. Il sito li legge al primo accesso e li tiene in memoria fino al riavvio, quindi un post nuovo arriva con il deploy. `/devlog` elenca i post dal più recente, `/devlog/{slug}` mostra un post (Markdown come la wiki, diagrammi ```mermaid compresi). I post sono pubblici.

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

- `slug`: stessa regola della wiki (minuscole, cifre e trattini, non `modifica`); deve essere unico tra i post.
- `date`: formato `YYYY-MM-DD`; stabilisce l'ordine dell'elenco.
- Un post con un campo mancante o non valido, o con uno slug già usato, viene ignorato e segnalato nel log con il nome del file.

La cartella si può cambiare con `Devlog:Directory` (percorso assoluto o relativo alla cartella del sito); i test la usano per leggere post da una cartella temporanea.

Il feed Atom (`/devlog/feed.xml`) costruisce id e link da `Site:BaseUrl` (es. `https://soulslands.arutosio.com`), così restano stabili qualunque sia l'indirizzo della richiesta; se è vuoto (sviluppo, modalità di casa) li prende dalla richiesta. In produzione lo imposta `docker-compose.yml` da `SITE_DOMAIN`, vedi `deploy/README.md`.

## Benchmark

I risultati dei benchmark sono file JSON nel formato v1 definito dall'ADR-0002 di SoulslandsGame (`docs/adr/0002-benchmark-result-v1.md`, schema in `docs/benchmark/`). Li pubblica il wiki-writer in `src/Soulslands.Web/WikiContent/benchmark/<milestone>/`, un file per scenario e macchina (`<scenario>--<macchina>.json`); i file grezzi stanno in `<milestone>/raw/`. Come per il devlog, il sito li legge al primo accesso e li tiene in memoria fino al riavvio.

- `/benchmark/{milestone}` (per esempio `/benchmark/m0`): una pagina pubblica per milestone con commit, data, hardware, sistema operativo, versioni e impostazioni di Soulslands e di Minecraft, scenario e la tabella delle metriche (p50, p99, massimo, soglia, valore di Minecraft). Le righe in cui Minecraft fa meglio sono segnate e mai nascoste; i valori di Minecraft con `origin: estimate` compaiono come stima con la fonte. Una milestone senza file validi risponde 404.
- `/benchmark/{milestone}/raw/{file}`: scarica un file grezzo, solo se un risultato di quella milestone lo elenca in `raw`.
- Un file con `format_version` diverso da 1, o senza un campo obbligatorio, viene ignorato e segnalato nel log con il suo percorso; gli altri file restano visibili. I campi sconosciuti vengono ignorati.
- I file `.json` arrivano nell'output di build e publish grazie al Web SDK; per i file grezzi c'è una regola apposita nel `.csproj`. `scripts/check-benchmark-publish.sh` lo verifica: copia per un momento una fixture in `WikiContent/benchmark/`, esegue `dotnet publish` e la rimuove.

La cartella si può cambiare con `Benchmark:Directory` (percorso assoluto o relativo alla cartella del sito); i test usano le fixture in `tests/Soulslands.Web.Tests/Fixtures/Benchmark/`, copiate dagli esempi dell'ADR, che non sono misure e non vanno mai copiate in `WikiContent/`.

## Ruoli

I ruoli arrivano dallo studio (claim `role`) e valgono per tutto lo studio; si assegnano nelle pagine admin dello studio.

| Ruolo | Wiki pubblica | Wiki Staff | Modifica wiki | Admin del sito (server, bacheca) |
|---|---|---|---|---|
| Giocatore (nessun ruolo) | sì | no | no | no |
| Agente | sì | sì | no | no |
| Moderatore | sì | sì | sì | no |
| Admin | sì | sì | sì | sì |

Le pagine Staff rispondono 404 a chi non è staff e non compaiono negli elenchi né nella ricerca.

## Sito statico su Cloudflare

`soulslands.mahoroba.studio` è un sito statico servito da Cloudflare Workers come *static assets* (progetto Workers Builds `soulslands-site`, configurazione in `wrangler.jsonc`: solo file, nessuno script Worker). `scripts/build-static.sh` avvia il sito in memoria (`src/Soulslands.StaticExport`, nessuna porta aperta), visita ogni pagina pubblica come un visitatore anonimo e scrive tutto in `dist/`:

- ogni pagina come `<percorso>/index.html` (la home `index.html`, la pagina 404 `404.html`), il feed `devlog/feed.xml`, i file grezzi dei benchmark e i file di `wwwroot` che le pagine usano;
- `_redirects`: le vecchie pagine passate allo studio (`/Acquista`, `/Riscatta`, `/Download` sull'host degli account, `/Privacy`, `/Termini`, `/Contatti` sul sito dello studio), `/Preferenze` verso la home e le grafie minuscole (`/media`, `/download`...), perché Cloudflare distingue maiuscole e minuscole;
- `_headers`: Content-Security-Policy senza script inline (gli stili inline restano permessi: li usano i diagrammi mermaid e le barre di avanzamento), `nosniff`, `Referrer-Policy`, `X-Frame-Options: DENY`, `Permissions-Policy`;
- `wiki/indice-ricerca.json`: l'indice della ricerca nella wiki, filtrato nel browser.

Workers applica `_headers` e `_redirects` della cartella `dist/` come Pages; `/Media` risponde 307 verso `/Media/` (`html_handling: auto-trailing-slash`) e ogni percorso senza file riceve `404.html` con stato 404 (`not_found_handling: 404-page`).

Nel sito statico non ci sono accesso, menu Admin, elenco dei server, editor della wiki né cookie. La bacheca della home arriva dallo studio nel browser (`https://account.mahoroba.studio/api/games/soulslands/announcements`) e resta nascosta se è vuota o lo studio non risponde; la scelta dei caratteri è un pulsante nel piè di pagina, salvato in `localStorage`.

Lo script si ferma con un errore, nominando il file, se `WikiContent/` contiene una pagina `visibility: staff`, se in `dist/` c'è il nome di una pagina staff, un pezzo del sito dinamico (accesso, Admin, server) o `document.cookie`, o se un link interno di una pagina non ha un file in `dist/`. Se .NET manca (l'immagine di build di Cloudflare non lo ha) installa l'SDK indicato in `global.json` con la copia di `scripts/dotnet-install.sh` (Microsoft, licenza MIT) in `~/.dotnet`. L'export porta con sé l'ICU (i dati della lingua italiana: ordine della wiki, numeri) su Linux x64, quindi non dipende dalla `libicu` della macchina; se mancasse comunque si ferma con "ICU non disponibile" invece di scrivere pagine sbagliate.

In locale:

```bash
scripts/build-static.sh                      # scrive dist/
python3 -m http.server -d dist 8000          # http://localhost:8000
npx wrangler dev                             # come Cloudflare (wrangler.jsonc), con _headers e _redirects
```

**Impostazioni nella dashboard di Cloudflare** (Workers & Pages → `soulslands-site` → Settings → Build; repository GitHub `Soulslands/soulslands-site`, non il vecchio `soulslands-website`):

| Impostazione | Valore |
|---|---|
| Build command | `scripts/build-static.sh` |
| Deploy command | `npx wrangler deploy` |
| Non-production branch deploy command | `npx wrangler versions upload` |
| Root directory | vuota (radice del repository) |
| Production branch | `main` |
| Build variable | `SITE_BASE_URL` = `https://soulslands.mahoroba.studio` (è anche il valore usato se manca; serve ai link assoluti del feed) |

Il nome del Worker nella dashboard deve restare `soulslands-site`, come `name` in `wrangler.jsonc`, altrimenti la build fallisce. Il Worker nasce con il primo deploy da `main`: prima di allora le build delle pull request (`versions upload`) falliscono con "This Worker does not exist on your account". La build non usa segreti; sulle URL di anteprima la bacheca resta nascosta (lo studio risponde solo a `soulslands.mahoroba.studio`). Il dominio `soulslands.mahoroba.studio` si collega in Settings → Domains & Routes → Custom domain.

**Alternativa**: lo stesso `dist/` funziona su Cloudflare Pages (preset None, build command `scripts/build-static.sh`, output `dist`), oppure si carica da GitHub Actions con `npx wrangler deploy` e un token API di Cloudflare come segreto del repository (`CLOUDFLARE_API_TOKEN`, `CLOUDFLARE_ACCOUNT_ID`), che solo Aruto può creare: non è in questo repository.

La CI controlla tutto nel job `static-site`: esegue `scripts/build-static.sh` e i test nel browser (`StaticSiteE2ETests`) sulla `dist/` servita come da Cloudflare (`tests/Soulslands.Web.E2E/serve-static.py`).

## Deploy con Docker e PostgreSQL

In produzione il sito usa PostgreSQL (`Database:Provider` = `Postgres`), in sviluppo e nei test SQLite. Le due basi dati hanno migrazioni separate: `Data/Migrations` per SQLite e `Data/Migrations/Postgres` per PostgreSQL. Dopo una modifica al modello vanno create entrambe:

```bash
cd src/Soulslands.Web
dotnet ef migrations add NomeModifica
Database__Provider=Postgres dotnet ef migrations add NomeModifica --context PostgresDbContext --output-dir Data/Migrations/Postgres
```

Per mettere online sito, database, HTTPS (Caddy) e backup notturni basta `docker compose up -d --build` dopo aver compilato `.env`: la guida passo passo è in [deploy/README.md](deploy/README.md).

Il sito applica le migrazioni all'avvio. `/api/health` dice se sito e database sono sani, ed è usato dall'healthcheck del container. Il sito non è esposto direttamente: lo raggiunge solo Caddy, ed è per questo che può fidarsi degli header `X-Forwarded-Proto` e `X-Forwarded-For` (così l'indirizzo di ritorno dell'accesso, `/signin-oidc`, usa https).

Questo database è nuovo rispetto a quello del sito con gli account: una sola migrazione iniziale per SQLite e una per PostgreSQL. Un database creato prima va cancellato (vedi `deploy/README.md`).

## Server della community

Chi ha un account dello studio registra fino a 5 server in "I miei server" (`/Server`) e riceve per ognuno una chiave `ssk_...`. Il server di gioco manda un heartbeat su `/api/servers/heartbeat` con quella chiave: la pagina Stato e `/api/servers` mostrano chi è online e quanti giocatori ci sono. Login del launcher e `join`/`hasjoined` stanno nello studio, sotto `/games/soulslands/`. La documentazione completa è nella pagina Staff della wiki "API launcher e session server" (`soulslands-hq/wiki/sviluppo/sviluppo-api-launcher.md`).

## Tema grafico

Aspetto e struttura sono separati. Tutti i colori del sito stanno in `wwwroot/css/theme.css` come variabili CSS (`--ss-orange`, `--ss-gold`, `--ss-cyan`, …, più le versioni `-rgb` per le trasparenze e le tonalità delle braci). `site.css`, le pagine e `site.js` leggono solo quelle variabili: per cambiare palette si modifica soltanto `theme.css`. Un test (`ThemeTests`) fallisce se un colore scritto a mano compare fuori dal tema.

## Struttura

```
src/Soulslands.Web/
  Data/             ruoli, pagine wiki, server, bacheca, migrazioni
  Pages/            home, wiki, devlog, benchmark, stato, i miei server, admin, accedi/esci
  Services/         accesso tramite lo studio (Auth/), permessi wiki, Markdown, import wiki, server, devlog, benchmark
  WikiContent/      tutte le pagine della wiki in Markdown (importate all'avvio); devlog/ contiene i post del devlog, benchmark/ i risultati dei benchmark
tests/Soulslands.Web.Tests/
```
