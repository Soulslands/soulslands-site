---
title: Il Mondo
slug: mondo
category: Mondo
visibility: Pubblica
---
# 🌍 Il Mondo di Soulslands
*Un solo mondo, infinito, che nasce sotto i tuoi passi*

---

## 📋 Indice

- [Panoramica](#panoramica)
- [Generazione procedurale](#generazione-procedurale)
- [Chunk e altezze](#chunk-e-altezze)
- [Giorno e notte](#giorno-e-notte)
- [Meteo e stagioni](#meteo-e-stagioni)
- [Feudi e guardie](#feudi-e-guardie)
- [Dungeon](#dungeon)
- [Persistenza](#persistenza)
- [FAQ](#faq)

---

## 📜 Panoramica

Soulslands non ha una mappa fissa come la vecchia Britannia di Ultima Online. Ogni server è **un unico mondo condiviso** da tutti i suoi giocatori, senza copie o shard separati, fatto interamente di **blocchi cubici** (voxel) che puoi scavare, raccogliere e ricollocare. Foreste, montagne, oceani, grotte e dungeon vengono **generati proceduralmente** man mano che i giocatori esplorano, come in Minecraft, ma con l'anima di Cursed Souls: biomi ispirati alle terre di UO, creature classiche, città presidiate dalle guardie e un'economia interamente gestita dai giocatori.

| Caratteristica | Soulslands |
|----------------|-----------|
| **Dimensione** | Praticamente illimitata in orizzontale |
| **Giocatori** | Un solo mondo per server, pensato per reggere fino a ~300.000 personaggi |
| **Server** | Nessun server ufficiale: il server dedicato è gratuito e chiunque può ospitare un mondo |
| **Blocchi** | Tutti modificabili, tranne la Roccia del Mondo sul fondo e le zone protette |
| **Generazione** | Procedurale, deterministica (stesso seme per tutti) |
| **Salvataggio** | Tutto lato server: vedi [Persistenza del mondo](/wiki/persistenza-del-mondo) |
| **Visuale** | Prima persona (di partenza), terza persona o isometrica, con F5; ciò che il personaggio non vede è mostrato in grigio |

> 💡 Il mondo è uno solo: la casa che costruisci, la miniera che scavi e il corpo che lasci a terra restano lì per tutti gli altri giocatori.

---

## 🧭 Generazione procedurale

Il mondo parte da un **seme** unico del server. Quando un giocatore si avvicina a una zona mai visitata, il server genera il terreno di quella zona, sempre allo stesso modo per quel seme. Una volta generata, la zona **diventa permanente**: da quel momento conta solo ciò che i giocatori ci hanno fatto.

La generazione avviene a livelli:

1. **Continenti e oceani** — grandi masse di terra separate da [oceani](/wiki/oceani) profondi e arcipelaghi.
2. **Clima** — temperatura e umidità decidono il [bioma](/wiki/biomi): dal gelo della [tundra](/wiki/bioma-tundra) al caldo del [deserto](/wiki/bioma-deserto).
3. **Rilievo** — catene montuose con speroni e valli laterali, altipiani, pianure e colline, e valli dove scorrono i fiumi, fino alle coste. Il terreno è quello della versione 2 del generatore, pensato per sembrare naturale ([ADR-0032](https://github.com/Soulslands/soulslands-game/blob/main/docs/adr/0032-generator-versions-terrain-v2.md), [#336](https://github.com/Soulslands/soulslands-game/pull/336)): le montagne sono massicci e non una rete di creste, e a Y 128 o più sta circa il 18-22% della terraferma (misurato da noi sui seed 7, 42 e 1997).
4. **Sottosuolo** — strati di roccia, vene di [minerali](/wiki/minerali), [grotte e caverne](/wiki/grotte-e-sottosuolo), fiumi di lava nelle profondità.
5. **[Strutture](/wiki/strutture)** — feudi, villaggi, santuari, rovine, accampamenti di orchi, cripte, torri dei lich, ingressi di dungeon, relitti sulle coste.
6. **Popolazione** — le creature compaiono secondo le [regole di spawn](/wiki/spawn-creature).

> ⚠️ Il pericolo **non cresce con la distanza**: dipende dal bioma, dal luogo (dungeon, rovine, profondità sotto terra) e dalla notte, ed è lo stesso in tutto il mondo (**deciso da Aruto, 02/11/2026**; vedi [Spawn delle creature](/wiki/spawn-creature#gli-stessi-ovunque)).

---

## 🧱 Chunk e altezze

Le altezze sono quelle di Minecraft: il mondo va da Y -64 a Y 320, cioè 384 blocchi, con il mare a Y 63. Il mondo si genera man mano che i giocatori lo esplorano.

Il mondo è diviso in **chunk**, colonne di 16×16 blocchi che vanno dal fondo del mondo fino al cielo. Il chunk è l'unità usata per i limiti di popolazione delle creature e per i territori di gilda ([Pietra del Territorio](/wiki/pietra-territorio-gilda)); dietro le quinte il server genera, salva e invia il mondo a cubi di 32 blocchi per lato.

| Quota (Y) | Cosa trovi |
|-----------|-----------|
| **320** | Limite del cielo: oltre non si può costruire |
| **180 – 320** | Vette delle [montagne](/wiki/bioma-montagne), ghiacciai, nidi di wyvern e draghi; la neve comincia intorno a Y 180, con un limite che varia di circa 20 blocchi ([#340](https://github.com/Soulslands/soulslands-game/pull/340)) |
| **63** | **Livello del mare** |
| **40 – 63** | Fondali bassi, colline, primi strati di roccia |
| **0 – 40** | Sottosuolo superficiale, grotte, falde d'acqua |
| **-32 – 0** | Sottosuolo profondo, laghi di lava, dungeon |
| **-64 – -32** | L'Abisso: i minerali più rari e le creature peggiori |
| **-64** | Roccia del Mondo, indistruttibile |

Il dettaglio degli strati e dei minerali per profondità è nella pagina [Grotte e sottosuolo](/wiki/grotte-e-sottosuolo).

---

## ☀️ Giorno e notte

Un giorno completo di Soulslands dura **2 ore reali** (un'ora di gioco ogni 5 minuti reali): 80 minuti di luce e 40 di buio, uguali per tutti i giocatori del mondo. Di notte gli spawn ostili in superficie raddoppiano, i non-morti escono allo scoperto e senza una luce o una razza che vede al buio si vede solo intorno a sé. La luna cambia fase ogni giorno: la luna piena agita le bestie, la luna nuova porta gli spawn più rari. Dormire non salta la notte, perché il mondo è uno solo.

Tutti i dettagli (orari, livelli di luce, fasi lunari, creature diurne e notturne, durata del giorno sui server) sono nella pagina [Giorno e notte](/wiki/giorno-e-notte).

---

## 🌦️ Meteo e stagioni

Il meteo cambia per regione e dipende dal bioma.

| Fenomeno | Dove | Effetti |
|----------|------|---------|
| 🌧️ **Pioggia** | Foreste, pianure, coste, giungla | Spegne i fuochi all'aperto, -visibilità, la pesca rende di più |
| ⛈️ **Temporale** | Ovunque tranne deserto | Fulmini che possono incendiare il legno; elementali dell'aria più frequenti |
| ❄️ **Neve e bufera** | Tundra, alte montagne | Danno da freddo senza vestiti adeguati, rallentamento |
| 🌪️ **Tempesta di sabbia** | Deserto | Visibilità quasi nulla, stamina che cala più in fretta |
| 🌫️ **Nebbia** | Paludi, coste, terre dei morti | Campo visivo ridotto, spawn di wisp e spettri |
| 🌋 **Pioggia di cenere** | Terre vulcaniche | Danno da fuoco leggero e continuo senza protezione |

Il mondo ha **quattro stagioni** di 7 giorni reali ciascuna: d'inverno la neve scende fino alle foreste temperate e i laghi del nord ghiacciano, d'estate le paludi si restringono e il deserto è più caldo.

---

## 🏰 Feudi e guardie

Il generatore crea i **feudi**: grandi città murate in stile medievale, con castello, mercato, banca, guaritori, botteghe, taverna e locanda, governate da un signore NPC (vedi [Strutture](/wiki/strutture#feudi-villaggi-e-strade)). Sono i luoghi più sicuri del mondo, ma non il punto di partenza.

- I **nuovi personaggi** nascono al centro del mondo, nelle terre selvagge, come in Minecraft: nessun feudo viene forzato lì (**deciso da Aruto, 02/11/2026**).
- Ogni feudo ha una **zona di guardia**, che comprende la città murata e una fascia intorno alle mura: al suo interno le [guardie cittadine](/wiki/guardie-cittadine) proteggono gli innocenti.
- I blocchi dei feudi **non sono modificabili**: non si può scavare né demolire dentro un feudo. I villaggi invece sono terra libera.
- I feudi nascono su tutto il mondo con la stessa rarità, circa uno ogni 20 × 20 km: non c'è un limite oltre il quale non ne compaiono. Le città dei giocatori sono le [città di gilda](/wiki/citta-di-gilda).
- Ogni feudo ha un **santuario** dove i fantasmi possono tornare in vita (vedi [Morte e fantasmi](/wiki/morte-e-fantasmi)).

---

## 🗝️ Dungeon

Oltre alle grotte naturali, il mondo genera **dungeon**: strutture sotterranee costruite, con corridoi, sale, trappole, porte chiuse e un boss in fondo. I dungeon sono ispirati a quelli classici di UO (cripte, miniere infestate, templi demoniaci, nidi di draghi, fortezze degli orchi) e si trovano a profondità diverse a seconda della pericolosità.

| Tipo di dungeon | Bioma o profondità | Abitanti tipici |
|-----------------|-------------------|-----------------|
| **Cripta** | [Terre dei Morti](/wiki/bioma-terre-dei-morti), cimiteri | Scheletri, zombie, lich |
| **Fortezza orchesca** | [Foresta profonda](/wiki/bioma-foresta-profonda), [colline e montagne](/wiki/bioma-montagne) | Orchi, orc captain, orc lord |
| **Miniera infestata** | Sottosuolo medio | Elementali dei minerali, ratman |
| **Covo dei ragni** | [Giungla](/wiki/bioma-giungla), grotte | Ragni giganti, dread spider |
| **Tempio demoniaco** | [Terre vulcaniche](/wiki/bioma-terre-vulcaniche), Abisso | Imp, demoni, balron |
| **Nido di draghi** | Vette e caverne di lava | Drake, draghi, wyrm |
| **Rovine sommerse** | Fondali oceanici | Serpenti marini, elementali d'acqua |

Tutti i dettagli sono in [Grotte e sottosuolo](/wiki/grotte-e-sottosuolo).

---

## 💾 Persistenza

Ogni blocco scavato o piazzato, ogni oggetto lasciato a terra, ogni casa e ogni personaggio vengono salvati **sul server**, nel mondo. Non esistono salvataggi locali né personaggi da portare da un mondo all'altro. Leggi [Persistenza del mondo](/wiki/persistenza-del-mondo) per tutti i dettagli.

---

## ❓ FAQ

**D: Il mondo finisce da qualche parte?**
R: In orizzontale no: il server genera nuove terre finché i giocatori esplorano. Il pericolo non cresce con la distanza dal centro: dipende dal bioma, dal luogo e dalla notte.

**D: Posso distruggere un feudo?**
R: No. I feudi e i santuari sono protetti. I villaggi invece sono terra libera: si scava e si costruisce. Le [città di gilda](/wiki/citta-di-gilda) invece possono essere assediate secondo le regole delle guerre tra gilde.

**D: Se un'altra persona scava una montagna, la vedo anch'io scavata?**
R: Sì. Il mondo è uno solo e ogni modifica è visibile a tutti.

---

*Vedi anche: [Blocchi del mondo](/wiki/blocchi) | [Blocchi da costruzione](/wiki/blocchi-costruzione) | [Biomi](/wiki/biomi) | [Alberi](/wiki/alberi) | [Giorno e notte](/wiki/giorno-e-notte) | [Oceani](/wiki/oceani) | [Laghi e fiumi](/wiki/laghi-e-fiumi) | [Grotte e sottosuolo](/wiki/grotte-e-sottosuolo) | [Strutture del mondo](/wiki/strutture) | [Spawn delle creature](/wiki/spawn-creature)*
