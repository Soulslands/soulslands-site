---
title: Spawn delle creature
slug: spawn-creature
category: Creature
visibility: Pubblica
---
# 🌱 Spawn delle creature

*Dove, quando e quante creature compaiono nel mondo*

---

## 📋 Indice

- [Panoramica](#panoramica)
- [Popolazione iniziale e spawn continuo](#popolazione-iniziale-e-spawn-continuo)
- [Bioma e profondità](#bioma-e-profondita)
- [Luce](#luce)
- [Giorno e notte](#giorno-e-notte)
- [Gli stessi ovunque](#gli-stessi-ovunque)
- [Limiti di densità](#limiti-di-densita)
- [Spawn rari e boss](#spawn-rari-e-boss)
- [Zone senza spawn](#zone-senza-spawn)
- [Consigli](#consigli)

---

## 📜 Panoramica

In Ultima Online i mostri comparivano da "spawner" piazzati a mano su una mappa fissa. In Soulslands il mondo è generato man mano che lo si esplora, quindi le creature seguono **regole di spawn** come in Minecraft: il server decide cosa far comparire in base a [bioma](/wiki/biomi), profondità, luce, ora del giorno, luogo e notte, rispettando un limite di creature per chunk.

> 📌 I numeri di spawn di questa pagina sono nostre stime e possono cambiare con il bilanciamento. Il caso decide solo quando e dove compare una creatura, mai cosa porta con sé: il bottino è fisso per creatura ([Regole deterministiche](/wiki/regole-deterministiche)).

---

## 🌍 Popolazione iniziale e spawn continuo

| Momento | Cosa succede |
|---------|-------------|
| **Generazione del chunk** | Quando un chunk viene generato per la prima volta riceve una popolazione iniziale di **animali** adatti al bioma (branchi di cervi, mandrie di cavalli, greggi) e gli **abitanti delle strutture** (orchi nelle fortezze, non-morti nelle cripte, boss nei dungeon). |
| **Spawn continuo** | Ogni pochi secondi il server prova a far comparire nuove creature nei chunk vicini ai giocatori (tra **24 e 96 blocchi** di distanza), mai sotto gli occhi di un giocatore. |
| **Scomparsa** | Le creature ostili comuni lontane da tutti i giocatori (oltre 128 blocchi) per alcuni minuti scompaiono, per lasciare spazio a nuovi spawn. Animali domati, creature con nome, boss e abitanti delle strutture non scompaiono mai. |

---

## 🗺️ Bioma e profondità

Ogni bioma ha la sua **tabella di spawn**: le creature possibili e il loro peso. In superficie conta il bioma; sottoterra conta soprattutto lo **strato di profondità** (vedi [Grotte e sottosuolo](/wiki/grotte-e-sottosuolo)). Le creature di ogni bioma, divise tra giorno e notte, sono riassunte in [Creature per bioma](/wiki/creature-per-bioma).

| Strato | Livello delle creature | Esempi |
|--------|------------------------|--------|
| Superficie | ⭐ – ⭐⭐⭐ secondo il bioma | Animali, orchi, scheletri, lizardman |
| Sottosuolo superficiale | ⭐ – ⭐⭐ | Ratti giganti, melme, scheletri, zombie |
| Strato medio | ⭐⭐ – ⭐⭐⭐ | Ragni giganti, gazer, troll, elementali dei minerali |
| Sottosuolo profondo | ⭐⭐⭐ – ⭐⭐⭐⭐ | Ogre lord, lich, gargoyle selvaggi, lava lizard |
| Abisso | ⭐⭐⭐⭐ – ⭐⭐⭐⭐⭐ | Daemon, elder gazer, Lich Lord, dread spider |
| Cuore del mondo | ⭐⭐⭐⭐⭐ | Balron, Ancient Wyrm, Shadow Wyrm |
| Oceani | ⭐ – ⭐⭐⭐⭐⭐ secondo la profondità dell'acqua | Delfini, serpenti marini, kraken (vedi [Oceani](/wiki/oceani)) |

Il bioma in superficie influenza anche il sottosuolo: sotto le [terre vulcaniche](/wiki/bioma-terre-vulcaniche) compaiono più creature di fuoco, sotto la [tundra](/wiki/bioma-tundra) più creature di ghiaccio, sotto le [Terre dei Morti](/wiki/bioma-terre-dei-morti) più non-morti.

---

## 💡 Luce

La luce è la regola più importante, come in Minecraft.

| Livello di luce del blocco | Spawn ostili | Spawn di animali |
|---------------------------|--------------|------------------|
| **0 – 4** (buio) | Sì, pieni | No |
| **5 – 7** (penombra) | Sì, ridotti | Rari |
| **8 – 15** (illuminato) | **No** | Sì, se il blocco è erba o terreno naturale |

- Una **torcia** illumina un raggio di circa 7 blocchi; lanterne e fuochi di più.
- Illuminare bene casa, miniera e accampamento impedisce che i mostri compaiano dentro.
- Le creature che compaiono altrove **possono comunque camminare** nelle zone illuminate.
- Nelle [Lande d'Ombra](/wiki/bioma-lande-d-ombra) la luce del sole non conta: solo la luce artificiale blocca gli spawn, e la pietra d'ombra ne riduce il raggio.

---

## 🌗 Giorno e notte

| Fase | Superficie | Sottosuolo |
|------|-----------|-----------|
| ☀️ Giorno | Pochi mostri, molti animali; i non-morti esposti al sole si indeboliscono | Invariato |
| 🌑 Notte | Spawn ostili **×2**, compaiono non-morti, mongbat, wraith, nightmare | Invariato |
| 🌑 Luna nuova | Come la notte, più la possibilità di spawn rari (vedi sotto) | Invariato |
| 🌫️ Nebbia o temporale | Spawn ostili come al crepuscolo anche di giorno | Invariato |

Nelle foreste profonde e sotto le chiome fitte il suolo resta buio anche di giorno, quindi i mostri compaiono comunque.

---

## 🧭 Gli stessi ovunque

Il pericolo e il bottino **non crescono** con la distanza dai feudi né dal centro del mondo (**deciso da Aruto, 02/11/2026**; vedi [ADR-0033](https://github.com/Soulslands/soulslands-game/blob/main/docs/adr/0033-walled-settlements-gate-roads.md)). In ogni punto del mondo le creature dipendono da tre cose:

| Cosa conta | Effetto |
|------------|---------|
| **Bioma** | La tabella di creature del bioma (vedi [Creature per bioma](/wiki/creature-per-bioma)) |
| **Luogo** | Dungeon, rovine e strutture hanno le loro creature e i loro boss; sottoterra conta la profondità (vedi [Bioma e profondità](#bioma-e-profondita)) |
| **Notte** | Gli spawn ostili in superficie raddoppiano (vedi [Giorno e notte](#giorno-e-notte)) |
| **Dentro la zona di guardia di un feudo** | **Nessuno spawn ostile** |

Le [città di gilda](/wiki/citta-di-gilda) riducono gli spawn ostili dentro il loro territorio, ma non li azzerano a meno di avere guardie (vedi [Guardie cittadine](/wiki/guardie-cittadine)).

---

## 📊 Limiti di densità

Per evitare che il mondo si riempia di mostri (o che un gruppo di giocatori li "accumuli"), ogni chunk ha un **limite di popolazione**.

| Categoria | Limite per chunk (16×16) | Limite per giocatore nell'area |
|-----------|-------------------------|--------------------------------|
| Mostri ostili | 6 | 40 |
| Animali | 8 | 20 |
| Creature acquatiche | 6 | 15 |
| Creature volanti | 3 | 10 |

- Se un chunk è pieno, il server prova altrove.
- Più giocatori nella stessa zona **non** moltiplicano all'infinito i mostri: il limite per area cresce in modo ridotto.
- Le creature domate, i pet e gli animali nelle stalle non contano nel limite.

---

## 👑 Spawn rari e boss

| Tipo | Come compare | Esempi |
|------|-------------|--------|
| **Variante rara** | Alcuni spawn sono una versione più forte con un nome proprio, più rara da trovare; ha un bottino fisso migliore, che lascia sempre | "Grak lo Sfregiato", orc lord con armi magiche |
| **Boss di dungeon** | Generato con il dungeon nella sua sala finale. Dopo l'uccisione torna dopo **2–6 ore reali** | Orc Lord, Lich Lord, Regina dei Solen, Balron |
| **Spawn di luna nuova** | Nelle notti di luna nuova, nei biomi corrotti | Ancient Lich, Skeletal Dragon |
| **Leggendari** | Nel Cuore del mondo e nei luoghi più rari (nidi, fosse oceaniche), rarissimi; un solo esemplare per regione | Ancient Wyrm, Drago antico, Leviatano, Fenice |
| **Elementali dei minerali** | Possono comparire quando si scava una vena del loro minerale | Elementale di Valorite |
| **Invasioni** | Eventi in cui un'orda attacca un feudo o una città di gilda | Orde di orchi, non-morti, demoni |

Un boss ucciso lascia il corpo con il bottino: i **diritti di loot** vanno prima a chi ha fatto più danno, poi il corpo diventa libero per tutti (vedi [Full loot](/wiki/full-loot)).

---

## 🚫 Zone senza spawn

- Dentro le zone di guardia dei feudi.
- Dentro le case e le costruzioni chiuse e illuminate dei giocatori.
- Sui blocchi non naturali illuminati (strade, pavimenti) per gli animali.
- Nei santuari di resurrezione.

---

## 💡 Consigli

- Prima di fare logout fuori città, illumina la zona e chiuditi: vedi [Persistenza del mondo](/wiki/persistenza-del-mondo).
- Per cacciare una creatura specifica, scegli il bioma e lo strato giusti e spegni le torce.
- I [Ranger](/wiki/classe-ranger) e gli [Esploratori](/wiki/classe-esploratore) con [Tracking](/wiki/skill-tracking) trovano le creature rare prima degli altri.

---

*Vedi anche: [Mostri](/wiki/mostri) | [Animali](/wiki/animali) | [Il Mondo](/wiki/mondo)*
