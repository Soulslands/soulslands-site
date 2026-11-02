---
title: Oceani
slug: oceani
category: Mondo
visibility: Pubblica
---
# 🌊 Oceani
*Il mare separa i continenti, e custodisce i loro segreti*

---

## 📋 Indice

- [Panoramica](#panoramica)
- [Profondità](#profondita)
- [Biomi oceanici](#biomi-oceanici)
- [Nuotare e respirare](#nuotare-e-respirare)
- [Navi](#navi)
- [Pesca](#pesca)
- [Creature marine](#creature-marine)
- [Isole e relitti](#isole-e-relitti)
- [Strutture marine](#strutture-marine)

---

## 📜 Panoramica

Gli oceani occupano gran parte del [mondo](/wiki/mondo) e separano i continenti. Il livello del mare è a **Y 63**. Come in Ultima Online, il mare è una regione a sé: pescatori, mercanti, pirati e cacciatori di serpenti marini lo percorrono con le loro navi. Come in Minecraft, però, il mare ha un **fondale vero** che si può raggiungere a nuoto, scavare e perfino abitare.

---

## 📏 Profondità

| Zona | Profondità del fondale | Cosa trovi |
|------|------------------------|-----------|
| **Acque basse** | Y 50 – 63 | Lagune, coralli, alghe, granchi, pesci comuni |
| **Mare aperto** | Y 20 – 50 | Banchi di pesci, delfini, primi serpenti marini |
| **Acque profonde** | Y -5 – 20 | Relitti, rovine sommerse, serpenti degli abissi, elementali d'acqua |
| **Fosse oceaniche** | Fino a Y -30 | Buio totale, kraken, Leviatano, minerali rari nel fondale |

> ⚠️ Più scendi, più il buio è totale: senza una fonte di luce non vedi nulla, e il campo visivo del personaggio si riduce a pochi blocchi.

---

## 🗺️ Biomi oceanici

Il mare non è uguale dappertutto. Come la terraferma, l'oceano è diviso in **biomi**, decisi dalla **temperatura** e dalla **profondità**: ognuno ha i suoi blocchi sul fondale, la sua vegetazione e le sue creature. La temperatura del mare segue quella delle terre vicine: le acque sono calde davanti a giungle, deserti, savane e mangrovie, temperate davanti a pianure e foreste, fredde davanti a taiga, brughiere e montagne, ghiacciate davanti alla tundra. In mare aperto, lontano dalle coste, si passa da una fascia all'altra lentamente.

Ogni bioma ha una **variante profonda** (prefisso `deep_`) con la stessa temperatura ma il fondale nelle acque profonde, tra Y -5 e Y 20; le varianti normali hanno il fondale nel mare aperto. Le acque basse lungo le coste fanno parte del bioma del mare vicino. Gli ID completi hanno il prefisso `soulslands:`, ad esempio `soulslands:warm_ocean`; i blocchi citati sono descritti in [Blocchi](/wiki/blocchi).

### 🌡️ Temperatura e fondali

| Bioma | ID | Temperatura | Fondale (Y) | Blocchi del fondale | Colore dell'acqua |
|-------|----|-------------|-------------|---------------------|-------------------|
| **Barriera corallina** | `coral_reef` | Calda | 50 – 60 | Sabbia (`sand`), pietra di corallo (`coral_stone`) | Turchese, trasparente |
| **Oceano caldo** | `warm_ocean` | Calda | 20 – 50 | Sabbia, argilla (`clay`), macchie di pietra di corallo | Turchese |
| **Oceano temperato** | `ocean` | Temperata | 20 – 50 | Sabbia, ghiaia (`gravel`), argilla | Blu |
| **Oceano freddo** | `cold_ocean` | Fredda | 20 – 50 | Ghiaia, pietra (`stone`), argilla | Blu scuro |
| **Oceano ghiacciato** | `frozen_ocean` | Gelida | 20 – 50 | Ghiaia, sabbia | Grigio-azzurro |
| **Oceano caldo profondo** | `deep_warm_ocean` | Calda | -5 – 20 | Sabbia, argilla, banchi di ostriche perlifere (`pearl_oyster`) | Blu intenso |
| **Oceano profondo** | `deep_ocean` | Temperata | -5 – 20 | Ghiaia, sabbia, argilla | Blu notte |
| **Oceano freddo profondo** | `deep_cold_ocean` | Fredda | -5 – 20 | Ghiaia, pietra | Blu notte |
| **Oceano ghiacciato profondo** | `deep_frozen_ocean` | Gelida | -5 – 20 | Ghiaia | Grigio-blu |
| **Fosse oceaniche** | `ocean_trench` | Qualsiasi | Fino a circa -30 | Ardesia profonda (`deepslate`) e ghiaia; le pareti attraversano pietra e pietra scura (`dark_stone`) | Nera |

- **Mari ghiacciati.** In superficie gli oceani ghiacciati sono coperti da lastre di ghiaccio (`ice`) su cui si cammina, interrotte da canali d'acqua libera; come il ghiaccio dei laghi, si rompono sotto le cavalcature. Gli iceberg sono di ghiaccio compatto (`packed_ice`) e ghiaccio di ghiacciaio (`glacier_ice`), con la neve (`snow`) in cima: si alzano fino a 30 blocchi sopra il mare e nella variante profonda sono ancora più grandi, con una base sommersa di decine di blocchi.
- **Vicino alle terre vulcaniche** qualsiasi oceano cambia fondale: sabbia nera (`black_sand`) e basalto (`basalt`), ossidiana (`obsidian`) dove le colate di lava arrivano al mare, e bocche di basalto da cui salgono colonne di bolle (vedi [Correnti e gorghi](#correnti-e-gorghi)).

### 🌿 Vegetazione e creature

Sott'acqua la luce cala man mano che si scende. Le acque basse sono illuminate di giorno, mentre i fondali del mare aperto e delle acque profonde restano al buio anche a mezzogiorno: laggiù le creature ostili compaiono a ogni ora, come nelle grotte (vedi [Spawn delle creature](/wiki/spawn-creature)). In superficie e nelle acque basse, invece, giorno e notte contano come sulla terraferma (vedi [Giorno e notte](/wiki/giorno-e-notte)).

| Bioma | Cosa cresce | ☀️ Di giorno | 🌑 Di notte |
|-------|-------------|--------------|-------------|
| **Barriera corallina** | Coralli rossi, blu, gialli, viola e rosa (`red_coral`, `blue_coral`, `yellow_coral`, `purple_coral`, `pink_coral`) con i loro blocchi (`red_coral_block`…) e ventagli (`red_coral_fan`…), spugne (`sponge`), anemoni luminosi (`sea_anemone`), corallo morto (`dead_coral_block`) nelle secche, erba marina (`seagrass`), qualche ostrica perlifera | Pesci tropicali, cavallucci marini (Sea Horse), tartarughe, granchi | Granchi giganti; elementale d'acqua (Water Elemental) nelle notti di tempesta |
| **Oceano caldo** | Prati di erba marina, coralli e blocchi di corallo sparsi, spugne | Delfini, banchi di pesci, tartarughe sulle secche; serpente marino (Sea Serpent) al largo | Serpente marino, elementale d'acqua |
| **Oceano temperato** | Foreste di kelp (`kelp`) alte fin quasi alla superficie, erba marina | Delfini, banchi di pesci, serpente marino | Serpente marino, elementale d'acqua; pirati annegati intorno ai relitti |
| **Oceano freddo** | Foreste di kelp fitte e scure | Foche e trichechi sugli scogli, delfini, banchi di pesci | Trichechi in acqua, serpente marino, elementale d'acqua |
| **Oceano ghiacciato** | Quasi niente: qualche alga lungo i bordi del ghiaccio | Orsi polari, foche e trichechi sulle lastre di ghiaccio | Orsi polari; lupi bianchi sul ghiaccio vicino alla costa; elementale della neve durante le bufere |
| **Oceano caldo profondo** | Banchi di ostriche perlifere sul fondale, anemoni luminosi (`sea_anemone`) che sono l'unica luce del fondo | In superficie delfini e serpenti marini; sul fondale buio, pirati annegati intorno ai relitti | Serpente degli abissi (Deep Sea Serpent) che sale in superficie, elementale delle profondità (Deep Water Elemental), kraken |
| **Oceano profondo** e **oceano freddo profondo** | Kelp solo dove il fondale risale; per il resto ghiaia e roccia nude | Serpenti marini in superficie; pirati annegati e, raro, il kraken sul fondale | Serpente degli abissi, elementale delle profondità, kraken |
| **Oceano ghiacciato profondo** | Niente: sotto la banchisa è sempre buio | Orsi polari e foche sugli iceberg | Serpente degli abissi ed elementale delle profondità sotto la banchisa; kraken |
| **Fosse oceaniche** | Niente: buio totale, rotto solo dal bagliore delle bocche di roccia magmatica (`magma_block`) | Serpente degli abissi, elementale delle profondità, kraken: laggiù l'ora non conta | Gli stessi e, rarissimo, il Leviatano (Leviathan): un solo esemplare per regione |

> 💡 Kelp ed erba marina si raccolgono per la cucina e l'alchimia, come le alghe delle [coste](/wiki/bioma-coste), e i coralli servono per decorare. Dalle ostriche perlifere si ricavano le **perle nere** (black pearl), uno degli otto reagenti della magia: per questo, prima o poi, ogni mago impara a nuotare.

### 🕳️ Il fondo delle acque profonde e delle fosse

Nelle acque profonde il buio è totale, ed è lì che l'oceano custodisce le sue ricchezze.

| Cosa | Dove | Note |
|------|------|------|
| **Ostriche perlifere** (`pearl_oyster`) | Fondali delle acque profonde, soprattutto nell'oceano caldo profondo; bordi delle fosse | Aprendole si ottengono le perle nere |
| **Minerali rari** | Fondo e pareti delle fosse oceaniche | Le fosse scoprono vene che sulla terraferma stanno molto più in basso: soprattutto [Orialco](/wiki/minerale-orialco), più raramente [Verite](/wiki/minerale-verite) e [Valorite](/wiki/minerale-valorite) |
| **Relitti** | Tutti i fondali | Più sono profondi, più sono ricchi; spesso li sorvegliano i pirati annegati |
| **Rovine sommerse e templi** | Acque profonde | Dungeon allagati: vedi [Strutture marine](#strutture-marine) |
| **Grotte allagate** (`flooded_caves`) | Sotto le coste e i fondali bassi | Gallerie piene d'acqua che collegano il mare ai fiumi e ai laghi sotterranei (vedi [Grotte e sottosuolo](/wiki/grotte-e-sottosuolo) e [Laghi e fiumi](/wiki/laghi-e-fiumi)) |

> ⚠️ Sott'acqua si scava più lentamente che all'asciutto, e in fondo a una fossa si lavora al buio, con l'aria contata e lontanissimi da un santuario. Servono pozioni di respirazione, una luce che non si spenga sott'acqua (come le lanterne fatte con la ghiandola luminosa del [serpente degli abissi](/wiki/mostro-serpente-degli-abissi)) e un gruppo che faccia la guardia.

### 🌀 Correnti e gorghi

| Fenomeno | Dove | Effetto |
|----------|------|---------|
| **Correnti marine** | Mare aperto, stretti tra isole e continenti | Spingono navi, barche e nuotatori in una direzione fissa: seguirle accorcia il viaggio, risalirle lo allunga. Si riconoscono dalle strisce di schiuma in superficie |
| **Gorghi** | Sopra le fosse oceaniche e vicino alle rovine sommerse | Trascinano verso il fondo nuotatori e oggetti, fanno girare su sé stesse le barche a remi e danneggiano le navi piccole |
| **Colonne di bolle** | Bocche di basalto sul fondale vicino alle terre vulcaniche | Spingono verso l'alto e ridanno aria a chi ci nuota dentro |
| **Iceberg e banchisa** | Mari ghiacciati | Ostacoli fissi: urtarli danneggia lo scafo come uno scoglio |

> 💡 Un cartografo esperto segna correnti e gorghi sulle mappe nautiche (vedi [Cartography](/wiki/skill-cartography)): con le correnti giuste una traversata dura molto meno.

---

## 🏊 Nuotare e respirare

- Ogni personaggio può **nuotare** in superficie senza limiti, ma con stamina che cala più in fretta se porta armature pesanti.
- Sott'acqua il personaggio ha una **riserva d'aria** di circa 30 secondi; finita l'aria perde vita ogni secondo.
- Pozioni di respirazione, elmi con bolla d'aria e incantesimi allungano l'apnea.
- Con un'armatura di piastre non si galleggia: si affonda lentamente.
- Gli oggetti caduti in acqua affondano fino al fondale, dove si possono recuperare.

---

## ⛵ Navi

Le navi sono costruite dai giocatori con [Carpentry](/wiki/skill-carpentry) e si guidano come in UO, con un timone e i comandi di rotta. Una nave è un oggetto del mondo: resta dove l'hai ancorata, salvata sul server, e chiunque può abbordarla se non è chiusa a chiave.

| Nave | Equipaggio | Stiva | Note |
|------|-----------|-------|------|
| **Barca a remi** | 1–2 | Piccola | Lenta, adatta a coste e fiumi |
| **Nave piccola** | 2–4 | Media | La più comune, veloce |
| **Nave media** | 4–8 | Grande | Può montare un cannone |
| **Galeone** | 8+ | Enorme | Più cannoni, cabina, stiva chiusa |

- Le navi possono subire danni (serpenti marini, cannoni, scogli) e vanno riparate.
- Una nave affondata scende sul fondale con il suo carico: chi la ritrova può saccheggiarla ([full loot](/wiki/full-loot)).

---

## 🎣 Pesca

La pesca usa la skill [Fishing](/wiki/skill-fishing) e una canna da pesca.

| Dove | Cosa si pesca | Fishing consigliato |
|------|---------------|---------------------|
| Fiumi e laghi | Pesce comune, stivali vecchi | 0+ |
| Coste | Pesce comune, conchiglie, alghe | 0+ |
| Mare aperto | Pesce grande, bottiglie con messaggio | 50+ |
| Acque profonde | Pesci rari, forzieri di relitti, mappe del tesoro | 80+ |
| Fosse oceaniche | Pesci leggendari, rischio di agganciare un serpente marino | 95+ |

> 💡 Pescare in acque profonde può far emergere un **serpente marino** o un **kraken**: tenete un combattente a bordo.

La pesca in fiumi, laghi, stagni e acque sotterranee è descritta in [Laghi e fiumi](/wiki/laghi-e-fiumi#pesca).

---

## 🐙 Creature marine

| Creatura | Zona | Ostile |
|----------|------|--------|
| Pesci, granchi | Ovunque | No |
| Delfino | Mare aperto | No |
| Cavalluccio marino (Sea Horse) | Acque basse tropicali | No |
| Serpente marino | Mare aperto, acque profonde | Sì |
| Serpente degli abissi (Deep Sea Serpent) | Acque profonde | Sì |
| Elementale d'acqua | Mare aperto, notte | Sì |
| Elementale delle profondità | Acque profonde | Sì |
| Kraken | Acque profonde e fosse | Sì |
| Leviatano | Fosse oceaniche, boss raro | Sì |

Tutti i dettagli in [Creature marine](/wiki/mostri-marini). Dove vivono, bioma per bioma e di giorno o di notte, è spiegato in [Biomi oceanici](#biomi-oceanici).

---

## 🏝️ Isole e relitti

- Gli oceani sono pieni di [isole](/wiki/bioma-isole), dalle piccole spiagge tropicali agli arcipelaghi maledetti.
- I **relitti** generati sul fondale contengono forzieri; quelli più profondi sono più ricchi.
- Le **rovine sommerse** sono piccoli dungeon allagati: serve apnea lunga o una via d'aria scavata.

---

## ⚓ Strutture marine

Il mare nasconde molte strutture, generate insieme ai fondali e alle coste. Sono descritte per intero nella pagina [Strutture](/wiki/strutture); qui c'è solo un riassunto di quelle legate al mare.

| Struttura | Dove | In breve |
|-----------|------|----------|
| **Relitti** | Fondali di tutti gli oceani, a volte spiaggiati su coste e isole | Navi affondate con il loro carico: più sono profonde, più sono ricche |
| **Rovine sommerse** | Acque profonde | Piccoli dungeon allagati, con il kraken come custode (vedi [Grotte e sottosuolo](/wiki/grotte-e-sottosuolo#dungeon-generati)) |
| **Tempio sommerso** | Fondali profondi | Un dungeon sommerso più grande e più pericoloso delle rovine |
| **Città sommersa** | Rarissima | La più grande e la più ricca delle strutture marine |
| **Covi dei pirati** | Coste, isole, grotte marine | Pirati, forzieri e mappe del tesoro |
| **Fari** | Coste, scogliere, faraglioni | Punti di riferimento per chi naviga |

> 💡 Per esplorare le strutture sommerse servono apnea lunga, luce e un modo per tornare in fretta a galla: vedi [Nuotare e respirare](#nuotare-e-respirare).

---

*Vedi anche: [Il Mondo](/wiki/mondo) | [Coste](/wiki/bioma-coste) | [Creature marine](/wiki/mostri-marini) | [Isole](/wiki/bioma-isole) | [Laghi e fiumi](/wiki/laghi-e-fiumi) | [Strutture](/wiki/strutture)*
