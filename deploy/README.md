# Mettere online il sito

Il sito gira con un solo comando su un server Linux con Docker. Lo stack contiene:

- **Caddy**, che fa da porta d'ingresso e gestisce l'HTTPS da solo;
- **il sito**;
- **PostgreSQL**;
- **un backup notturno del database**.

## Prima prova in casa (PC Linux o Raspberry Pi)

Prima di comprare un server puoi provare tutto su un PC Linux o su un Raspberry Pi di casa, senza dominio. Il sito si apre da qualsiasi dispositivo della tua rete, in HTTP semplice.

Sul Raspberry serve un **Raspberry Pi 4 o 5 con almeno 2 GB** e il sistema operativo **a 64 bit**: `uname -m` deve rispondere `aarch64`. La prima compilazione sul Raspberry richiede qualche minuto.

1. Installa Docker (punto 1 qui sotto) e aggiungi il tuo utente al gruppo docker con `sudo usermod -aG docker $USER`, poi esci e rientra.
2. Scarica il codice e prepara `.env` come al punto 3, ma con `SITE_DOMAIN=:80`.
3. Avvia con `docker compose up -d --build`.
4. Trova l'indirizzo della macchina con `hostname -I` e apri `http://QUELL-INDIRIZZO` dal telefono o da un altro PC.

In questa modalità manca l'HTTPS, e quindi il sito è **in sola lettura**: lo studio accetta come indirizzo di ritorno solo `https://` (o `http://localhost` in sviluppo) e i cookie dell'accesso viaggiano solo in HTTPS. Il pulsante **Accedi** e ogni pagina che chiede l'accesso aprono una pagina che lo spiega, invece di mandarti allo studio (da `http://localhost` l'accesso funziona come in sviluppo). Wiki, devlog, benchmark e la pagina Stato funzionano.

Quando passi al server vero, cambia `SITE_DOMAIN` con il dominio e rilancia `docker compose up -d`: Caddy prende il certificato da solo.

### Cosa cambia con `SITE_DOMAIN`

All'avvio il container del sito legge `SITE_DOMAIN` (lo fa la riga `entrypoint` del servizio `web` in `docker-compose.yml`, perché Compose da solo non sa distinguere i due casi):

- **con un dominio** (es. `soulslands.arutosio.com`): il sito costruisce i link assoluti (il feed del devlog, `/devlog/feed.xml`) da `https://SITE_DOMAIN`, qualunque indirizzo arrivi nella richiesta, e risponde `400` a ogni richiesta per un altro nome (`AllowedHosts=SITE_DOMAIN;localhost`; `localhost` serve al controllo di salute interno del container);
- **in casa** (`:80`, o qualsiasi valore che inizia con `:`): i link seguono l'indirizzo usato nella richiesta e il sito accetta qualunque nome (`AllowedHosts=*`), così lo apri dall'IP della macchina.

`SITE_DOMAIN` deve essere **un solo nome host** (es. `soulslands.arutosio.com`) **oppure `:80`**. Se per errore scrivi anche `https://` davanti, una `/` o una porta in fondo (`:443`), il sito le toglie da solo. Se scrivi più nomi separati da spazi o virgole, il sito parte lo stesso ma accetta qualunque nome e prende i link dalla richiesta, e nel log (`docker compose logs web`) compare un avviso che inizia con `Attenzione: SITE_DOMAIN contiene più nomi`.

Non serve nessuna altra variabile in `.env`.

## 1. Il server

Serve una macchina Linux raggiungibile da internet: va bene una VPS con 2 GB di RAM e 20 GB di disco (Hetzner, OVH, Contabo, DigitalOcean…) o un PC di casa con le porte 80 e 443 aperte verso l'esterno.

Installa Docker:

```bash
curl -fsSL https://get.docker.com | sh
```

## 2. Il dominio

Scegli il nome, per esempio `soulslands.arutosio.com`. Nel pannello DNS del dominio crea un record:

| Tipo | Nome | Valore |
|------|------|--------|
| A | `soulslands` | l'indirizzo IPv4 del server |
| AAAA | `soulslands` | l'indirizzo IPv6 del server, solo se ce l'ha |

Aspetta che il nome risponda (`ping soulslands.arutosio.com` mostra l'IP del server).

## 3. La configurazione

Il repository è pubblico: `git clone` non chiede né utente né token.

```bash
git clone https://github.com/Soulslands/soulslands-site.git
cd soulslands-site
cp .env.example .env
nano .env
```

Compila almeno:

- `SITE_DOMAIN`: il nome scelto, senza `https://`;
- `POSTGRES_PASSWORD`: una password lunga e casuale (`openssl rand -base64 32`);
- `OIDC_SOULSLANDS_SECRET`: il segreto con cui questo sito entra nello studio Mahoroba (`openssl rand -hex 32`). Lo stesso valore va nel `.env` dello studio, che registra questo sito con gli indirizzi `https://SITE_DOMAIN/signin-oidc` e `https://SITE_DOMAIN/signout-callback-oidc` (`SOULSLANDS_URL` nel `.env` dello studio). È un segreto.
- `STUDIO_ACCOUNT_URL` e `STUDIO_URL` solo se lo studio non sta su `https://account.mahoroba.studio` e `https://mahoroba.studio`.

Account, acquisti, key regalo, download, email, privacy e termini stanno nello studio: qui non servono né SMTP né Stripe. Gli Admin, i Moderatori e gli Agenti sono quelli dello studio.

## 4. Avvio

```bash
docker compose up -d --build
```

Al primo avvio Caddy chiede il certificato HTTPS: dopo circa un minuto il sito risponde su `https://SITE_DOMAIN`. Per controllare:

```bash
docker compose ps                  # tutti "running" / "healthy"
docker compose logs -f web caddy   # log del sito e del proxy
curl https://SITE_DOMAIN/api/health
```

Per aggiornare il sito dopo nuove modifiche su GitHub:

```bash
git pull
docker compose up -d --build
```

Le migrazioni del database si applicano da sole all'avvio.

**Dal sito con gli account (prima di ottobre 2026) a questo**: il database riparte da una sola migrazione nuova e gli account sono passati allo studio, quindi il vecchio database va cancellato una volta (si perdono i server registrati e le pagine della wiki modificate dal sito; le pagine di `WikiContent/` tornano da sole): `docker compose down -v` (cancella anche i certificati di Caddy, che li richiede da solo), poi `docker compose up -d --build`. Togli da `.env` le variabili che non servono più (`ADMIN_*`, `SMTP_*`, `STRIPE_*`, `LEGAL_*`, `DOWNLOAD_*`, `LAUNCHER_LOGIN_*`).

## 5. Backup

Ogni notte alle 03:30 (UTC) il servizio `backup` salva il database in `backups/`, tenendo le ultime 14 copie (`BACKUP_KEEP`). Copia ogni tanto quella cartella fuori dal server.

Per ripristinare una copia:

```bash
gunzip -c backups/soulslands-AAAAMMGG-HHMM.sql.gz | docker compose exec -T db psql -U soulslands -d soulslands
```

## Cosa non va pubblicato

`.env` contiene password e chiavi: resta solo sul server ed è già escluso da git. Le porte del sito (8080) e del database (5432) non sono esposte: da fuori si entra solo da Caddy sulle porte 80 e 443.
