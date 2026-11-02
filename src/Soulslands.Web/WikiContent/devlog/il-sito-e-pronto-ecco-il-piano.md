---
title: Il sito è pronto, ecco il piano
slug: il-sito-e-pronto-ecco-il-piano
date: 2026-10-18
summary: Il sito di Soulslands è finito: account, acquisto, key regalo, download, wiki e questo devlog. E il piano per il gioco, in dieci traguardi, senza date.
author: Il team di Soulslands
---
# Il sito è pronto, ecco il piano

Soulslands è un gioco di ruolo online medievale e fantastico, in un mondo di blocchi che si può scavare e costruire, generato mentre lo si esplora. Prima di scrivere il gioco abbiamo finito il sito: da oggi è la nostra vetrina, e questo è il primo post del devlog.

## Cosa trovi oggi sul sito

- **Account.** Ti registri con email e password, confermi l'indirizzo e puoi attivare la protezione a due fattori. Il tuo account è un account dello studio Mahoroba e serve per entrare nei server online.
- **Acquisto.** Comprando Soulslands attivi il tuo account. Il pagamento passa da Stripe. Chi ha l'account attivo può giocare sui server online.
- **Key regalo.** Puoi regalare il gioco a un amico: il pagamento crea una key che ti resta sempre visibile nella pagina Acquista. L'amico si registra e la riscatta in una pagina apposita. Ogni key vale una sola volta.
- **Download.** C'è una pagina con due blocchi.
  - Il **launcher** è riservato agli account attivi. È un programma che installa il gioco, lo tiene aggiornato e gestisce le versioni e le istanze con le loro mod. Formati: `Setup.exe` per Windows, `.app` per macOS su Apple Silicon, `AppImage` per Linux.
  - Il **server dedicato** è gratuito per tutti, anche senza aver comprato il gioco. Non esiste un server ufficiale: ogni mondo online è ospitato dai giocatori. Formati: `.zip` per Windows e macOS su Apple Silicon, `.tar.gz` per Linux x86_64 e Linux aarch64 (anche Raspberry Pi), più un'immagine Docker per amd64 e arm64.
- **Wiki.** Regole, razze, classi, creature, mondo e materiali, scritte e riviste dal team. Ne trovi l'elenco nella [wiki](/wiki).
- **Devlog.** Quello che stai leggendo. Ogni post è anche nel feed `/devlog/feed.xml`, per leggerlo con il tuo lettore di notizie, e gli ultimi compaiono nella home.

Una precisazione onesta: le build del launcher e del server non sono ancora pubblicate. Finché non lo sono, la pagina Download mostra "Disponibile presto" al posto del pulsante. Il gioco stesso non è ancora giocabile.

## Il piano, in parole semplici

Il piano ha dieci traguardi, da M0 a M9. **Non ha date né stime di durata**: un traguardo è chiuso quando passano i suoi controlli, non quando scade un termine. Ogni traguardo finisce con un benchmark pubblico, cioè una misura fatta da un gruppo di giocatori simulati (i "bot"), e con un post in questo devlog.

1. **M0, Fondamenta.** La base tecnica: il progetto in Rust, i controlli automatici che girano a ogni modifica su Linux, Windows e macOS, il server che parte in un container e genera un mondo senza schermo.
2. **M1, Vedere il mondo.** Il client mostra il terreno, con la telecamera isometrica e quella in prima persona, e permette di scavare e piazzare blocchi. Funziona su Windows, Linux e macOS.
3. **M2, Multigiocatore.** Più persone nello stesso mondo, con l'accesso tramite l'account del sito. Se il server si spegne di colpo, si perdono al massimo gli ultimi secondi di gioco e nessun oggetto viene duplicato.
4. **M3, Sistemi di gioco di base.** Statistiche, abilità che crescono usandole, combattimento misto (mischia e archi liberi, incantesimi a bersaglio), personaggi umani, morte e fantasma, contenitori, crafting e creature. Qui nasce il launcher, e a fine traguardo c'è l'**alpha chiusa**: le prime persone vere nel gioco.
5. **M4, Società.** Reputazione e criminali, furto, perdita di tutto ciò che si porta alla morte, guardie, gilde, gruppi, territori e guerre.
6. **M5, Grafica e visione.** Lo stile visivo definitivo, la nebbia di guerra che ingrigisce ciò che il personaggio non vede, installer e aggiornamenti automatici. A fine traguardo c'è l'**alpha pubblica**, dal sito, con l'elenco dei server della community. *Nota del 26/10/2026: il piano è cambiato, non ci sarà un elenco pubblico; ogni giocatore terrà il proprio elenco di server nel gioco, come in Minecraft.*
7. **M6, Modding.** Pacchetti di dati e mod che un server può richiedere: il client li scarica da solo. Nel launcher ogni istanza ha le sue mod. Nasce anche il kit pubblico per chi vuole scrivere mod.
8. **M7, Un server per una comunità grande.** Un solo server che regge molti giocatori usando tutti i core del computer, con controlli di prestazioni e sicurezza. A fine traguardo c'è l'**accesso anticipato**.
9. **M8, Cluster.** Lo stesso mondo distribuito su più processi e più macchine.
10. **M9, Cluster, ricerca.** Spingere il cluster più in là di quanto abbia mai fatto un gioco simile. È ricerca: il gioco esce e vive anche se questo traguardo non riesce.

I passi sono in questo ordine per una ragione: prima un gioco che si può giocare, poi la scala. Nessun numero di giocatori è una promessa: se mai arriveremo a una cifra molto grande, la annunceremo solo dopo averla dimostrata con le misure.

## Dove seguirci

Ogni traguardo avrà il suo post qui. Se vuoi capire come è costruito il gioco, le pagine pubbliche della [wiki](/wiki) raccontano il mondo e le regole, e il feed del devlog ti avvisa quando c'è qualcosa di nuovo.
