---
title: Fiordi e gole
slug: bioma-fiordi-e-gole
category: Mondo / Biomi
visibility: Pubblica
---
# 🏔️ Fiordi e gole
*Valli strette e profonde, scavate dall'acqua e dalle pareti a picco*

---

## 📜 Panoramica

Fiordi e gole sono due **forme del terreno** che diventano biomi: in tutti e due la valle è stretta, profonda e chiusa da pareti ripide di roccia, ma in uno c'è il mare e nell'altro un fiume. Nascono dalle valli del terreno v2 (vedi [Come si decide un bioma](/wiki/biomi#come-si-decide-un-bioma) e [ADR-0032](https://github.com/Soulslands/soulslands-game/blob/main/docs/adr/0032-generator-versions-terrain-v2.md)): dove una valle di fiume tocca il mare o taglia un'alta quota, il terreno si approfondisce ancora.

| | Fiordo | Gola |
|---|--------|------|
| **Id** | `soulslands:fjord` | `soulslands:gorge` |
| **Che cos'è** | Una valle stretta e profonda di una costa fredda, allagata dal mare: acqua salata tra due pareti | Una valle stretta e profonda di fiume nell'entroterra, con le pareti a picco e il fiume sul fondo |
| **Dove si forma** | Dove la valle di un fiume arriva a una [costa](/wiki/bioma-coste) **fredda** | Dove un [fiume](/wiki/laghi-e-fiumi#fiumi) attraversa un terreno alto |
| **Pericolo** | ⭐⭐ (deciso da Aruto, 02/11/2026) | ⭐⭐ (deciso da Aruto, 02/11/2026) |
| **Fondo** | Acqua di mare, bioma `fjord` | Il fondo della gola resta bioma `river` (deciso da Aruto, 02/11/2026) |
| **Inverno** | L'acqua gela in superficie (deciso da Aruto, 02/11/2026) | Nessuna regola propria |

> 📝 La soglia di freddo che decide un fiordo, la quota che decide una gola e la larghezza e la profondità delle due valli non hanno ancora numeri: i limiti esatti si propongono insieme ai compiti di generazione.

---

## 🧱 Blocchi tipici

| Blocco | Note |
|--------|------|
| Pietra `stone`, granito `granite` | Le pareti a picco; la roccia nuda si vede da lontano |
| Ghiaia `gravel`, sabbia `sand` | Ai piedi delle pareti e sul fondo; la ghiaia crolla se scavata da sotto |
| Erba `grass`, terra `dirt` | Sui ripiani e sul bordo delle pareti, dove il pendio si addolcisce |
| Felce `fern`, lichene `lichen` | Sulle pareti umide e sulle rocce |
| Acqua `water` | Fiordo: acqua di mare, salata e non potabile; gola: acqua dolce di fiume, con rapide dove il pendio è forte (vedi [Laghi e fiumi](/wiki/laghi-e-fiumi#la-corrente)) |
| Argilla `clay` | Sul fondo poco profondo e sulle rive di una gola |

---

## 🌲 Alberi e legni

| Albero | Legno | Frequenza |
|--------|-------|-----------|
| Abete rosso, abete bianco, pino | [Regular](/wiki/legno-regular) | Sui ripiani e sul bordo delle pareti, dove la taiga o la montagna arrivano alla valle |
| Salice | [Regular](/wiki/legno-regular) | Sulle rive di una gola, dove la sponda è bassa |

Come sulle altre [coste](/wiki/bioma-coste), gli alberi di un fiordo sono quelli del bioma vicino: verso la tundra ne restano pochi. Sulle pareti a picco non cresce nulla. Vedi [Alberi](/wiki/alberi).

---

## ⛏️ Minerali

| Dove | Minerali |
|------|----------|
| Pareti basse | [Iron](/wiki/minerale-iron), [Rusty](/wiki/minerale-rusty), [Steel](/wiki/minerale-steel) |
| Sottosuolo | Tabella standard di [Grotte e sottosuolo](/wiki/grotte-e-sottosuolo) |

Le vene si piazzano per quota, non per bioma: dove una parete a picco taglia una vena, la vena si vede, come sulle pareti delle [montagne](/wiki/bioma-montagne#minerali).

---

## 🐾 Creature

**Nel fiordo**

| Creatura | Quando | Ostile |
|----------|--------|--------|
| [Tricheco](/wiki/animale-tricheco), foche, gabbiani | Giorno | No |
| [Delfini](/wiki/animale-delfino) | In acqua, vicino alla riva | No |
| [Serpente marino](/wiki/mostro-serpente-marino) | Acque al largo, a volte sulla riva | Sì |
| [Elementale dell'acqua](/wiki/mostro-elementale-dell-acqua) | Notte, raro | Sì |
| **Lontra** (proposta, da confermare) | Giorno, sulle rive | No |

**Nella gola**

| Creatura | Quando | Ostile |
|----------|--------|--------|
| [Capra di montagna](/wiki/animale-capra-di-montagna), [aquila](/wiki/animale-aquila), [corvo](/wiki/animale-corvo) | Giorno | No |
| [Orso bruno](/wiki/animale-orso-bruno) | Giorno, vicino all'acqua | Se provocato |
| [Arpia](/wiki/mostro-arpia) | Sulle pareti | Sì |
| [Puma](/wiki/animale-puma) | Alba e tramonto | Sì |
| **Lontra** (proposta, da confermare) | Giorno, sulle rive del fiume | No |

> 🆕 **Proposta (da confermare).** Per fiordi e gole si propone la **lontra**, una sola creatura per tutte e due: ⭐, giocherellona, nuota veloce e porta a riva i pesci che prende. Bottino: pelle grezza, pelliccia di lontra (cuoio leggero, calda) e carne di pesce. Tutte le altre creature della pagina sono quelle dei biomi vicini (**deciso da Aruto, 02/11/2026**).

In tutti e due, di notte compaiono [scheletri](/wiki/mostro-scheletro) e [zombie](/wiki/mostro-zombie) come altrove in superficie. Dettagli in [Animali](/wiki/animali), [Mostri](/wiki/mostri) e [Creature marine](/wiki/mostri-marini); il riepilogo è in [Creature per bioma](/wiki/creature-per-bioma).

---

## ⚠️ Pericoli

- Le cadute dalle pareti fanno danno in base all'altezza, ma un'acqua profonda almeno due blocchi annulla il danno da caduta (vedi [Cascate e sorgenti](/wiki/laghi-e-fiumi#cascate-e-sorgenti)).
- Nel fiordo l'acqua è profonda e fredda: sott'acqua l'aria dura circa 30 secondi (vedi [Nuotare e respirare](/wiki/oceani#nuotare-e-respirare)).
- Nella gola la corrente dei fiumi di montagna è forte e nelle rapide non si risale a nuoto.
- Le pareti sono strette: la luce arriva poco e i mostri possono comparire nell'ombra anche di giorno (vedi [Spawn delle creature](/wiki/spawn-creature)).

> 💡 Un fiordo è un porto naturale: acqua profonda e riparata dal vento, a due passi dal legno dei boschi sul bordo.

---

*Vedi anche: [Biomi](/wiki/biomi) | [Coste](/wiki/bioma-coste) | [Laghi e fiumi](/wiki/laghi-e-fiumi) | [Montagne](/wiki/bioma-montagne) | [Oceani](/wiki/oceani)*
