---
title: Prati alpini
slug: bioma-prati-alpini
category: Mondo / Biomi
visibility: Pubblica
---
# 🌼 Prati alpini
*Erba fiorita, stelle alpine e laghetti gelidi sotto la roccia nuda*

---

## 📜 Panoramica

I prati alpini sono le praterie d'alta quota: pendii erbosi e dolci che si stendono tra il bosco di abeti e pini dei versanti delle [montagne](/wiki/bioma-montagne) e la roccia nuda delle pareti più in alto. In estate l'erba alta si riempie di stelle alpine, genziane e margherite; tra i dossi restano piccoli specchi d'acqua fredda, i laghetti glaciali. Gli alberi sono pochi e bassi, il cielo è grande, e dai pendii si vede il mondo sotto. Chi sale in montagna ci passa tutto il tempo di un'ascesa: è il posto dove fermarsi, accamparsi e raccogliere erbe rare prima dei tratti più duri.

| Caratteristica | Valore |
|----------------|--------|
| **Clima** | Fresco, con l'aria sottile dell'alta quota |
| **Pericolo** | ⭐⭐ (deciso da Aruto, 02/11/2026) |
| **Dove si forma** | In quota, dove il clima è fresco, e **solo sui pendii dolci**: dove il terreno è ripido resta roccia nuda (vedi [Come si decide un bioma](/wiki/biomi#come-si-decide-un-bioma)) |
| **Stagioni** | In estate fiorisce; d'inverno la neve copre i prati (deciso da Aruto, 02/11/2026) e i laghetti gelano |

> 📝 **Dove comincia un prato (valori di partenza della squadra, non ancora confermati da Aruto; [ADR-0037](https://github.com/Soulslands/soulslands-game/blob/main/docs/adr/0037-biome-placement.md), [#494](https://github.com/Soulslands/soulslands-game/pull/494)).** Il prato sta tra Y 128 e Y 168 (quota con il solito scarto casuale), dove il clima va da freddo a mite (temperatura da -0,5 a 0,2) e dove il terreno sale **al massimo 0,6 blocchi per blocco**. Il limite proposto era 1: lo abbiamo abbassato a 0,6 perché a 1 le [montagne](/wiki/bioma-montagne) perdevano più della metà della loro superficie sul seed 7 (misurato da noi). Sopra quel limite il terreno resta montagna (pietra con chiazze d'erba); da 1,5 blocchi per blocco in su la superficie è roccia nuda.
>
> **Stagioni.** Le stagioni non esistono ancora nel gioco: per ora il generatore crea i prati senza neve e i laghetti senza ghiaccio, come d'estate. La neve d'inverno resta la regola decisa, e arriverà con le stagioni.

---

## 🧱 Blocchi tipici

| Blocco | Note |
|--------|------|
| Erba `grass`, terra `dirt` | Superficie dei pendii dolci |
| Erba alta `tall_grass`, cespuglio `bush` | Coprono il prato |
| Stella alpina `edelweiss`, genziana `gentian` | Fiori d'alta quota, per l'[Alchemy](/wiki/skill-alchemy) e la tintura blu |
| Margherita `daisy`, ranuncolo `buttercup` | Fiori dei prati |
| Lichene `lichen` | Sui sassi e sulle rocce affioranti |
| Pietra `stone`, granito `granite`, ghiaia `gravel` | Chiazze di sassi e roccia che affiora; la ghiaia crolla se scavata da sotto |
| Acqua `water` | Laghetti glaciali (`glacial_pond`) e, più di rado, laghi di montagna (`mountain_lake`); il ghiaccio d'inverno arriverà con le stagioni (vedi [Laghi e fiumi](/wiki/laghi-e-fiumi#laghi-di-montagna)) |

La tinta dell'erba è quella di tutti i biomi finché non arrivano le tinte per bioma (vedi [Texture dei blocchi](/wiki/texture-blocchi#tinta-di-bioma)): il colore del prato non cambia rispetto alle pianure, a cambiare sono le piante.

---

## 🌲 Alberi e legni

| Albero | Legno | Frequenza |
|--------|-------|-----------|
| Abete rosso, abete bianco, pino | [Regular](/wiki/legno-regular) | Pochi, bassi e radi (le chance del pacchetto sono basse, 1-1,2% per specie) |

Più si sale, più gli alberi diminuiscono; oltre Y 220 non cresce nulla. Il legno qui scarseggia: si porta dal bosco più in basso. Vedi [Alberi](/wiki/alberi).

---

## ⛏️ Minerali

| Dove | Minerali |
|------|----------|
| Rocce affioranti a bassa quota | [Iron](/wiki/minerale-iron), [Rusty](/wiki/minerale-rusty), [Steel](/wiki/minerale-steel) |
| Rocce affioranti a media quota (Y 100–180) | [Shadow Iron](/wiki/minerale-shadow-iron), [Silver](/wiki/minerale-silver), [Dull Copper](/wiki/minerale-dull-copper) |
| Sottosuolo | Tabella standard di [Grotte e sottosuolo](/wiki/grotte-e-sottosuolo) |

Le vene si piazzano per quota, non per bioma, come spiega la pagina delle [montagne](/wiki/bioma-montagne#minerali): un prato a Y 150 ha le vene di Y 150.

---

## 🐾 Creature

| Creatura | Quando | Ostile |
|----------|--------|--------|
| [Capra di montagna](/wiki/animale-capra-di-montagna), [lama](/wiki/animale-lama) | Giorno | No |
| [Aquila](/wiki/animale-aquila), [uccelli](/wiki/animale-uccello) | Giorno | No |
| [Lepre](/wiki/animale-lepre) | Alba e tramonto | No |
| [Puma](/wiki/animale-puma) | Alba e tramonto, intorno ai laghetti | Sì |
| [Arpia](/wiki/mostro-arpia) | Sulle pareti sopra il prato | Sì |
| [Ettin](/wiki/mostro-ettin), [ogre](/wiki/mostro-ogre), [ciclope](/wiki/mostro-ciclope) | Dove il prato confina con le pendici e le vallate alte | Sì |
| [Elementale dell'acqua](/wiki/mostro-elementale-dell-acqua) | Notte, nei laghetti più profondi | Sì |
| [Marmotta](/wiki/animale-marmotta) | Giorno, vicino alle tane tra i massi | No |

> 🐿️ **La creatura del bioma.** Ogni bioma nuovo ha una creatura tutta sua; per i prati alpini è la [marmotta](/wiki/animale-marmotta): ⭐, pacifica, si rizza sulle zampe vicino alla tana e fischia quando arriva un predatore, e le altre creature del prato fuggono. Bottino: pelle grezza, carne di marmotta e grasso di marmotta (balsamo per le pozioni di cura). Tutte le altre creature della pagina sono quelle dei biomi vicini (**deciso da Aruto, 02/11/2026**).

> 🐿️ **Le creature nuove arrivano dopo.** La marmotta qui sopra e le altre creature dei biomi nuovi non esistono ancora nel gioco: il compito che le aggiunge è ancora da fare. Per ora nel prato vivono solo le creature dei biomi vicini.

Dettagli in [Animali](/wiki/animali) e [Mostri](/wiki/mostri); il riepilogo di tutti i biomi è in [Creature per bioma](/wiki/creature-per-bioma).

---

## ⚠️ Pericoli

- I prati finiscono in pareti a picco: le cadute fanno danno in base all'altezza.
- Si è visibili da lontano e ci sono pochi ripari; le arpie attaccano dall'alto.
- Quando arriveranno le stagioni, d'inverno il ghiaccio dei laghetti non reggerà le cavalcature.

> 💡 La stella alpina e la genziana si trovano proprio nei prati alti delle montagne: è il posto per rifornire l'[Alchemy](/wiki/skill-alchemy).

---

*Vedi anche: [Biomi](/wiki/biomi) | [Montagne](/wiki/bioma-montagne) | [Laghi e fiumi](/wiki/laghi-e-fiumi) | [Taiga](/wiki/bioma-taiga)*
