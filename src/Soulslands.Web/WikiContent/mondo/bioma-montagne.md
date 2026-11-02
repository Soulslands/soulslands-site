---
title: Montagne
slug: bioma-montagne
category: Mondo / Biomi
visibility: Pubblica
---
# ⛰️ Montagne
*Più sali, più la roccia è ricca e l'aria è sottile*

---

## 📜 Panoramica

Le catene montuose si alzano fino al limite del cielo, ispirate alle montagne di Minoc e alle vette dove i draghi facevano il nido. Sono il paradiso dei minatori: le vene di minerale **affiorano direttamente sulle pareti**, e in quota compaiono minerali che altrove si trovano solo in profondità. La neve comincia intorno a Y 180, ma il limite non è una linea retta: sale e scende di circa 20 blocchi da un punto all'altro, quindi la neve arriva più in basso in un punto e più in alto in un altro, e non copre mai le pareti a picco. Scogliere e fianchi ripidi restano di roccia nuda, con erba e neve solo dove il pendio è dolce (misurato da noi: sui fianchi ripidi su cento colonne ripide la roccia nuda passa da circa 20 a circa 99, vedi [ADR-0032](https://github.com/Soulslands/soulslands-game/blob/main/docs/adr/0032-generator-versions-terrain-v2.md), [#340](https://github.com/Soulslands/soulslands-game/pull/340)).

| Caratteristica | Valore |
|----------------|--------|
| **Clima** | Temperato alla base, gelido in vetta |
| **Pericolo** | ⭐⭐ alla base, ⭐⭐⭐⭐ in vetta |
| **Strutture** | Miniere abbandonate, nani in rovina, nidi di wyvern e draghi, accampamenti di ciclopi |
| **Effetto** | Cadute pericolose; frane quando si scava sotto blocchi di ghiaia |
| **Varianti** | Sui pendii dolci tra il bosco dei versanti e la roccia nuda si stendono i [prati alpini](/wiki/bioma-prati-alpini); dove un fiume taglia l'alta quota, la valle si stringe in una [gola](/wiki/bioma-fiordi-e-gole) |

---

## 🧱 Blocchi tipici

| Blocco | Note |
|--------|------|
| Pietra `stone`, granito `granite`, diorite `diorite`, andesite `andesite`, basalto `basalt` | Tutto il bioma |
| Ghiaia `gravel` | Crolla se scavata da sotto |
| Erba `grass`, erba alta `tall_grass` | Pascoli sui versanti |
| Stella alpina `edelweiss`, genziana `gentian`, lichene `lichen` | Pendii rocciosi e prati alti (vedi [Prati alpini](/wiki/bioma-prati-alpini)) |
| Neve `snow`, neve farinosa `powder_snow`, ghiaccio `ice`, ghiaccio compatto `packed_ice`, ghiaccio di ghiacciaio `glacier_ice` | Intorno a Y 180 (il limite varia di circa 20 blocchi, mai sulle pareti a picco; [#340](https://github.com/Soulslands/soulslands-game/pull/340)) |
| Cristalli | Nelle fenditure profonde |

---

## 🌲 Alberi e legni

| Albero | Legno | Frequenza |
|--------|-------|-----------|
| Quercia | [Oak](/wiki/legno-oak) | Pendici basse |
| Abete rosso, abete bianco, pino | [Regular](/wiki/legno-regular) | Versanti |
| Pino di brina | [Frostwood](/wiki/legno-frostwood) | Raro, vicino alle vette innevate |

Più si sale, più gli alberi sono bassi e radi; oltre Y 220 non cresce nulla. Vedi [Alberi](/wiki/alberi).

---

## ⛏️ Minerali

| Dove | Minerali |
|------|----------|
| Pareti basse | [Iron](/wiki/minerale-iron), [Rusty](/wiki/minerale-rusty), [Steel](/wiki/minerale-steel) |
| Pareti medie (Y 100–180) | [Shadow Iron](/wiki/minerale-shadow-iron), [Silver](/wiki/minerale-silver), [Dull Copper](/wiki/minerale-dull-copper) |
| Vette (oltre Y 180 circa) | [Bronze](/wiki/minerale-bronze), [Titanio](/wiki/minerale-titanio) (raro), [Valorite](/wiki/minerale-valorite) (rarissimo) |
| Sotto la montagna | Tabella standard, con vene più grandi |

> Le vene dei minerali si piazzano per quota, non per bioma: le fasce di Y 100–180 e oltre Y 180 restano quelle di prima, mentre il limite della neve ora oscilla di circa 20 blocchi, quindi una vena "da vetta" può affiorare poco sotto la neve e una "da parete" poco sopra ([ADR-0032](https://github.com/Soulslands/soulslands-game/blob/main/docs/adr/0032-generator-versions-terrain-v2.md)).

---

## 🐾 Creature

| Creatura | Quando | Ostile |
|----------|--------|--------|
| Capre di montagna, lama | Pendici | No |
| Ciclope, Titano | Vallate alte | Sì |
| Ettin, ogre, ogre lord | Grotte e pendici | Sì |
| Harpy, stone harpy | Pareti | Sì |
| Drake, wyvern | Vette | Sì |
| Drago | Nidi in vetta, raro | Sì |
| Elementali di terra e dei minerali | Miniere | Sì |
| Aquile | Giorno | No |

---

## ⚠️ Pericoli

- Le cadute fanno danno in base all'altezza.
- Le vette sono territorio di drake e wyvern che attaccano dall'alto.

> 💡 I ciclopi e i titani delle vallate alte sono la fonte del [cuoio Cyclop](/wiki/cuoio-cyclop); gli ettin del [cuoio Ettin](/wiki/cuoio-ettin).

---

*Vedi anche: [Biomi](/wiki/biomi) | [Prati alpini](/wiki/bioma-prati-alpini) | [Fiordi e gole](/wiki/bioma-fiordi-e-gole) | [Minerali](/wiki/minerali) | [Grotte e sottosuolo](/wiki/grotte-e-sottosuolo)*
