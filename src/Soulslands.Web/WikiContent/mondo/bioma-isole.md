---
title: Isole
slug: bioma-isole
category: Mondo / Biomi
visibility: Pubblica
---
# 🏝️ Isole
*Piccoli mondi in mezzo al mare*

---

## 📋 Indice

- [Panoramica](#panoramica)
- [Tipi di isola](#tipi-di-isola)
- [Blocchi tipici](#blocchi-tipici)
- [Alberi e legni](#alberi-e-legni)
- [Minerali](#minerali)
- [Creature](#creature)
- [Pericoli](#pericoli)

---

## 📜 Panoramica

Gli oceani di Soulslands sono punteggiati di **isole** e arcipelaghi, ispirati a Buccaneer's Den, Moonglow, Nujel'm, Magincia e alle isole sperdute dei mari di UO. Il contorno di un'isola è irregolare, con baie e promontori, non un cerchio ([#345](https://github.com/Soulslands/soulslands-game/pull/345), [ADR-0032](https://github.com/Soulslands/soulslands-game/blob/main/docs/adr/0032-generator-versions-terrain-v2.md); nel pacchetto del gioco le isole più piccole restano in un pezzo solo, [#347](https://github.com/Soulslands/soulslands-game/pull/347)). Un'isola può avere un bioma proprio (tropicale, roccioso, vulcanico, innevato) e spesso nasconde qualcosa che sul continente non c'è: minerali rari, creature uniche, rovine sommerse. Più un'isola è lontana dalla costa, più è pericolosa e ricca.

| Tipo di isola | Pericolo | Caratteristiche |
|---------------|----------|-----------------|
| **Tropicale** | ⭐⭐ | Palme, spiagge, frutti, tartarughe e uccelli |
| **Rocciosa** | ⭐⭐⭐ | Scogliere, nidi di harpy, grotte marine |
| **Vulcanica** | ⭐⭐⭐⭐ | Piccolo vulcano attivo, minerali del fuoco |
| **Maledetta** | ⭐⭐⭐⭐ | Relitti, pirati non-morti, nebbia |
| **Del tesoro** | ⭐⭐⭐ | Rovine sepolte, mappe del tesoro |
| **Ghiacciata** | ⭐⭐⭐ | Neve, iceberg, orsi polari e trichechi |
| **Dei funghi** | ⭐⭐ | Funghi giganti sul micelio, pochi mostri in superficie |
| **Arcipelago di isolotti** | ⭐⭐ | Decine di isolotti, lagune e secche |
| **Faraglioni** | ⭐⭐⭐ | Colonne di roccia nel mare, nidi di harpy e wyvern |

Un'isola è una massa di terra generata dentro un [bioma oceanico](/wiki/oceani#biomi-oceanici): il suo tipo dipende dalla temperatura del mare intorno. Le isole più grandi possono avere al centro un vero bioma di terraferma, come un pezzo di [giungla](/wiki/bioma-giungla), di [tundra](/wiki/bioma-tundra) o di [terre vulcaniche](/wiki/bioma-terre-vulcaniche), con le sue creature e le sue risorse.

---

## 🗺️ Tipi di isola

Per ogni tipo di isola trovi dove si genera, di cosa è fatta, chi la abita di giorno e di notte, cosa si raccoglie e quali strutture vi si incontrano. Le strutture sono descritte nella pagina [Strutture](/wiki/strutture); le regole su luce e ore del giorno in [Giorno e notte](/wiki/giorno-e-notte) e [Spawn delle creature](/wiki/spawn-creature). Come ovunque in superficie, di notte su tutte le isole possono comparire anche scheletri e zombie.

### 🌴 Isola tropicale

Spiagge bianche, palme e acqua turchese: è la più comune delle isole dei mari caldi, larga da poche decine a qualche centinaio di blocchi. Spesso è circondata da una barriera corallina.

| Voce | Valore |
|------|--------|
| **Dove** | Oceani caldi (`warm_ocean`), spesso dentro una barriera corallina (`coral_reef`) |
| **Blocchi** | Sabbia (`sand`) sulle spiagge con arenaria (`sandstone`) sotto, erba (`grass`) e felci (`fern`) all'interno, argilla (`clay`) nelle lagune, liane (`vines`) sugli alberi |
| **Alberi** | Palma (`palm`) ovunque; albero della giungla (`jungle`) sulle isole grandi; mangrovia (`mangrove`) sulle coste fangose delle isole più grandi (vedi [Mangrovie](/wiki/bioma-mangrovie)); albero sanguigno (`bloodwood`) raro, solo sulle isole remote |
| **Di giorno** | Uccelli, pappagalli tropicali, gabbiani, granchi e tartarughe sulle spiagge; [serpente gigante](/wiki/animale-serpente-gigante) tra la vegetazione; sulle isole grandi coperte di giungla anche [gorilla](/wiki/animale-gorilla) |
| **Di notte** | Serpente gigante, granchi giganti sulle spiagge, [pirati](/wiki/mostri-umanoidi) che sbarcano dalle navi; sulle isole grandi la [pantera](/wiki/animale-pantera) |
| **Risorse** | Noci di cocco e frutti tropicali, liane per le corde, corallo, perle dai granchi giganti; [Bloodwood](/wiki/legno-bloodwood) e [Verite](/wiki/minerale-verite) sulle isole remote |
| **Strutture tipiche** | Relitti spiaggiati, covi dei pirati, fari; sulle isole più grandi villaggi dei selvaggi |

### ⛰️ Isola rocciosa

Un blocco di roccia battuto dal vento, con scogliere a picco e poche spiagge di ghiaia. Le pareti sono piene di nidi e alla base si aprono le grotte marine.

| Voce | Valore |
|------|--------|
| **Dove** | Oceani temperati e freddi (`ocean`, `cold_ocean`) |
| **Blocchi** | Pietra (`stone`) e granito (`granite`) sulle scogliere, ghiaia (`gravel`) sulle spiagge, erba (`grass`) ed erica (`heather`) sulla cima |
| **Alberi** | Pochi: pini (`pine`) piegati dal vento |
| **Di giorno** | [Harpy](/wiki/mostro-arpia) in stormi, gabbiani e [aquile](/wiki/animale-aquila) sulle scogliere, foche sugli scogli bassi; [wyvern](/wiki/mostro-wyvern) sulle pareti più alte; raramente un Hiryu |
| **Di notte** | Le harpy restano nei nidi e attaccano solo chi si avvicina; granchi giganti sugli scogli, [elementale dell'acqua](/wiki/mostro-elementale-dell-acqua) nelle notti di tempesta |
| **Risorse** | [Iron](/wiki/minerale-iron) e [Steel](/wiki/minerale-steel) sulle scogliere, [Silver](/wiki/minerale-silver) un po' più frequente nelle grotte marine, piume |
| **Strutture tipiche** | Grotte marine (a volte con un covo dei pirati o dei contrabbandieri), fari, nidi di wyvern |

### 🌋 Isola vulcanica

Un piccolo vulcano attivo che esce dal mare, con colate di lava che scendono fino all'acqua e spiagge di sabbia nera. Le isole vulcaniche spente sono più tranquille e possono avere un lago nel cratere (vedi [Laghi e fiumi](/wiki/laghi-e-fiumi)).

| Voce | Valore |
|------|--------|
| **Dove** | Nei mari caldi e temperati; più frequenti davanti alle [terre vulcaniche](/wiki/bioma-terre-vulcaniche) |
| **Blocchi** | Basalto (`basalt`), sabbia nera (`black_sand`) sulle spiagge, terra di cenere (`ash_soil`), pomice (`pumice`), ossidiana (`obsidian`) dove la lava incontra il mare, lava (`lava`) nel cratere |
| **Alberi** | Alberi carbonizzati (`charred_tree`) sulle pendici, che danno carbone; sulle isole spente qualche palma (`palm`) lungo la costa |
| **Di giorno** | [Lucertole di lava](/wiki/animale-lucertola-di-lava), coleotteri di fuoco (Fire Beetle), [elementali del fuoco](/wiki/mostro-elementale-del-fuoco) vicino alla lava, [drake](/wiki/mostro-drake) intorno al cratere |
| **Di notte** | Elementali del fuoco e lucertole di lava, più [segugi infernali](/wiki/mostro-segugio-infernale) e [gatti infernali](/wiki/mostro-gatto-infernale) |
| **Risorse** | [Blood Rock](/wiki/minerale-blood-rock) vicino alla lava, vene di zolfo (`sulfur_vein`), ossidiana, pomice, carbone |
| **Strutture tipiche** | Nidi di draghi nel cratere (drake e, raramente, un drago), forge abbandonate |

### ❄️ Isola ghiacciata

Un'isola coperta di neve nei mari del nord, circondata da lastre di ghiaccio e iceberg. Le più grandi hanno un ghiacciaio al centro.

| Voce | Valore |
|------|--------|
| **Dove** | Oceani freddi e ghiacciati (`cold_ocean`, `frozen_ocean`) |
| **Blocchi** | Neve (`snow`, `snow_layer`), ghiaccio (`ice`) sulle pozze e lungo la riva, ghiaccio compatto (`packed_ice`) e ghiaccio di ghiacciaio (`glacier_ice`) nei ghiacciai, ghiaia (`gravel`) e pietra (`stone`) sulle coste |
| **Alberi** | Pini di brina (`frost_pine`), rari; abeti rossi (`spruce`) nelle valli riparate |
| **Di giorno** | [Orsi polari](/wiki/animale-orso-polare), [trichechi](/wiki/animale-tricheco) e foche sulla riva, [lupi bianchi](/wiki/animale-lupo-bianco); [leopardi delle nevi](/wiki/animale-leopardo-delle-nevi) all'alba e al tramonto |
| **Di notte** | Lupi bianchi, [troll del gelo](/wiki/mostro-troll-del-gelo), [elementali della neve](/wiki/mostro-elementale-della-neve) durante le bufere; i trichechi tornano in acqua |
| **Risorse** | [Frostwood](/wiki/legno-frostwood), avorio e grasso di tricheco, pelli; nel sottosuolo [Bronze](/wiki/minerale-bronze) e [Silver](/wiki/minerale-silver) più frequenti, come nella tundra |
| **Strutture tipiche** | Caverne di ghiaccio (dungeon), villaggi abbandonati, relitti imprigionati nel ghiaccio |

### 🍄 Isola dei funghi

Rarissima e inconfondibile: un'isola coperta di micelio e di funghi giganti alti come alberi, con funghi luminosi che di notte la fanno brillare in mezzo al mare. Ricorda i campi di funghi di Minecraft.

| Voce | Valore |
|------|--------|
| **Dove** | In mare aperto (`ocean`, `deep_ocean`), molto lontano dalle coste |
| **Blocchi** | Micelio (`mycelium`) al posto dell'erba, terra (`dirt`) sotto, funghi giganti (`giant_mushroom_stem`, `giant_mushroom_cap`), funghi marroni, rossi e luminosi (`brown_mushroom`, `red_mushroom`, `glow_mushroom`) |
| **Alberi** | Nessuno: i funghi giganti si abbattono come alberi ma non danno legno, solo blocchi di gambo e di cappello |
| **Di giorno** | Granchi e tartarughe sulle spiagge, uccelli marini |
| **Di notte** | Qualche [wisp](/wiki/mostro-wisp) attirato dalla luce dei funghi. Sul micelio i mostri faticano a comparire: gli spawn ostili in superficie sono molto più rari che altrove |
| **Risorse** | Funghi per la cucina e l'alchimia, micelio per coltivare funghi altrove, blocchi di fungo gigante per costruire |
| **Strutture tipiche** | Nessuna: la rarità è l'isola stessa. Sotto, spesso, si aprono le Caverne dei funghi giganti (`mushroom_caverns`), dove i mostri del buio compaiono come in ogni grotta (vedi [Grotte e sottosuolo](/wiki/grotte-e-sottosuolo)) |

### 💀 Isola maledetta

Un'isola avvolta da una nebbia che non si alza mai, con alberi morti, relitti sulle scogliere e i pirati che vi sono morti ancora di guardia ai loro tesori.

| Voce | Valore |
|------|--------|
| **Dove** | In qualsiasi mare |
| **Blocchi** | Terra morta (`dead_soil`), fango (`mud`), ghiaia (`gravel`), pietra (`stone`); ragnatele (`cobweb`) tra le rovine |
| **Alberi** | Alberi morti (`dead_tree`), che danno legno morto |
| **Di giorno** | La nebbia rende il giorno simile al crepuscolo: [scheletri](/wiki/mostro-scheletro) (gli scheletri pirati), pirati annegati intorno ai relitti, [corvi](/wiki/animale-corvo) |
| **Di notte** | [Wraith](/wiki/mostro-wraith), [spettri](/wiki/mostro-spettro), scheletri e [zombie](/wiki/mostro-zombie); i pirati annegati risalgono dai relitti e camminano sulla spiaggia |
| **Risorse** | Forzieri dei relitti, mappe del tesoro, ossa e polvere spettrale dai non-morti, belladonna (`nightshade_plant`) |
| **Strutture tipiche** | Relitti spiaggiati, covi dei pirati abbandonati, a volte l'ingresso di una cripta |

### 💰 Isola del tesoro

Una piccola isola sabbiosa dove qualcuno, tanto tempo fa, ha sepolto qualcosa. Le mappe del tesoro pescate in mare o trovate addosso ai pirati portano spesso qui.

| Voce | Valore |
|------|--------|
| **Dove** | Mari caldi e temperati, spesso vicino a un arcipelago |
| **Blocchi** | Sabbia (`sand`), erba (`grass`); arenaria (`sandstone`) e ciottoli (`cobblestone`) nelle rovine |
| **Alberi** | Palme (`palm`) |
| **Di giorno** | [Pirati](/wiki/mostri-umanoidi) nei covi, granchi, gabbiani, serpente gigante |
| **Di notte** | Pirati di ronda, granchi giganti, scheletri |
| **Risorse** | Tesori sepolti (si trovano decifrando le mappe con [Cartography](/wiki/skill-cartography) e scavando nel punto giusto), forzieri dei pirati, [Orialco](/wiki/minerale-orialco) nel sottosuolo delle isole lontane |
| **Strutture tipiche** | Rovine sepolte, covi dei pirati |

### 🏖️ Arcipelago di isolotti

Decine di isolotti larghi da 3 a 30 blocchi, separati da canali, banchi di sabbia e lagune poco profonde. È bellissimo da esplorare in barca a remi e insidioso per le navi grandi.

| Voce | Valore |
|------|--------|
| **Dove** | Acque basse dei mari caldi e temperati (`warm_ocean`, `ocean`, `coral_reef`) |
| **Blocchi** | Sabbia (`sand`) e ghiaia (`gravel`), banchi di sabbia appena sotto il pelo dell'acqua, pietra di corallo (`coral_stone`) ed erba marina (`seagrass`) nelle lagune, erba (`grass`) sugli isolotti più grandi |
| **Alberi** | Da una a tre palme (`palm`) per isolotto nei mari caldi; qualche pino (`pine`) nei mari temperati |
| **Di giorno** | Tartarughe, granchi e gabbiani sugli isolotti; cavallucci marini (Sea Horse) nelle lagune dei mari caldi; [delfini](/wiki/animale-delfino) nei canali |
| **Di notte** | Granchi giganti; elementale dell'acqua nelle notti di tempesta |
| **Risorse** | Corallo, pesca facile nelle lagune, qualche ostrica perlifera (`pearl_oyster`) sul bordo della barriera, noci di cocco |
| **Strutture tipiche** | Relitti incagliati sulle secche, fari, covi dei pirati nascosti tra gli isolotti |

### 🪨 Faraglioni

Colonne di roccia che escono a picco dal mare, larghe da 3 a 15 blocchi e alte fino a 60 sopra l'acqua, a volte unite da archi naturali. Non hanno spiagge: ci si arriva in barca e ci si arrampica.

| Voce | Valore |
|------|--------|
| **Dove** | Davanti alle coste a scogliera e intorno alle isole rocciose, nei mari temperati e freddi |
| **Blocchi** | Pietra (`stone`), granito (`granite`) e calcare (`limestone`), ghiaia (`gravel`) alla base, un ciuffo d'erba (`grass`) sulla cima |
| **Alberi** | Nessuno, a parte qualche pino (`pine`) solitario sulla cima dei faraglioni più larghi |
| **Di giorno** | Harpy, aquile e gabbiani; wyvern che fanno il nido sulla cima |
| **Di notte** | Harpy e wyvern restano nei nidi; foche e trichechi sugli scogli alla base; elementale dell'acqua nelle notti di tempesta |
| **Risorse** | Vene di [Iron](/wiki/minerale-iron) e [Steel](/wiki/minerale-steel) sulle pareti, piume |
| **Strutture tipiche** | Fari sui faraglioni più grandi, covi dei pirati nelle grotte alla base |

---

## 🧱 Blocchi tipici

| Blocco | Note |
|--------|------|
| Sabbia bianca (`sand`), corallo (`coral_stone`) | Spiagge e fondali |
| Conchiglie (`seashells`), legno di deriva (`driftwood`), ammofila (`beach_grass`) | Spiagge di quasi tutte le isole |
| Terriccio rosso (`jungle_soil`), orchidea (`orchid`), aloe (`aloe`) | Isole tropicali |
| Pietra lavica (`basalt`) | Isole vulcaniche |
| Erba tropicale (`grass`) | Isole tropicali |
| Sabbia nera (`black_sand`), ossidiana (`obsidian`), pomice (`pumice`), cenere vulcanica (`volcanic_ash`), tufo (`tuff`) | Spiagge, colate e pendici delle isole vulcaniche |
| Pietra (`stone`), granito (`granite`), diorite (`diorite`), calcare (`limestone`), ghiaia (`gravel`) | Isole rocciose e faraglioni |
| Lichene (`lichen`), ginestrone (`gorse`), nido (`bird_nest`) | Cime e sporgenze delle isole rocciose e dei faraglioni |
| Neve (`snow`), ghiaccio (`ice`, `packed_ice`, `glacier_ice`), terra gelata (`frozen_dirt`), ghiaccioli (`icicle`) | Isole ghiacciate |
| Micelio (`mycelium`), funghi giganti (`giant_mushroom_stem`, `giant_mushroom_cap`) | Isole dei funghi |
| Terra morta (`dead_soil`), cenere di tomba (`grave_ash`), arbusto secco (`dead_bush`), ragnatele (`cobweb`) | Isole maledette |

Tutti i blocchi sono descritti in [Blocchi](/wiki/blocchi).

---

## 🌲 Alberi e legni

| Albero | Legno | Frequenza |
|--------|-------|-----------|
| Palma (`palm`) | [Regular](/wiki/legno-regular) + noci di cocco | Comune |
| Albero sanguigno (`bloodwood`) | [Bloodwood](/wiki/legno-bloodwood) | Raro, isole tropicali remote |
| Albero della giungla (`jungle`) | [Regular](/wiki/legno-regular) | Comune sulle isole tropicali grandi |
| Mangrovia (`mangrove`) | [Regular](/wiki/legno-regular) | Coste fangose delle isole tropicali più grandi |
| Pino (`pine`) | [Regular](/wiki/legno-regular) + resina | Isole rocciose, faraglioni, arcipelaghi dei mari temperati |
| Abete rosso (`spruce`) | [Regular](/wiki/legno-regular) | Valli riparate delle isole ghiacciate |
| Pino di brina (`frost_pine`) | [Frostwood](/wiki/legno-frostwood) | Raro, isole ghiacciate |
| Albero carbonizzato (`charred_tree`) | [Regular](/wiki/legno-regular), soprattutto carbone | Isole vulcaniche |
| Albero morto (`dead_tree`) | Legno morto ([Regular](/wiki/legno-regular)) | Isole maledette |

Le isole dei funghi non hanno alberi: i funghi giganti non danno legno. Tutte le specie sono descritte in [Alberi](/wiki/alberi).

---

## ⛏️ Minerali

| Dove | Minerali |
|------|----------|
| Scogliere | [Iron](/wiki/minerale-iron), [Steel](/wiki/minerale-steel) |
| Sottosuolo delle isole lontane | [Orialco](/wiki/minerale-orialco) (la lega "atlantidea" si trova quasi solo qui) |
| Isole remote, profondità | [Valorite](/wiki/minerale-valorite), [Verite](/wiki/minerale-verite) |
| Grotte marine delle isole rocciose | [Silver](/wiki/minerale-silver) leggermente più frequente |
| Isole vulcaniche, vicino alla lava | [Blood Rock](/wiki/minerale-blood-rock), zolfo (`sulfur_vein`) |
| Sottosuolo delle isole ghiacciate | [Bronze](/wiki/minerale-bronze), [Silver](/wiki/minerale-silver) più frequenti |

---

## 🐾 Creature

| Creatura | Dove | Ostile |
|----------|------|--------|
| Uccelli marini, granchi, tartarughe | Spiagge | No |
| Pirati e banditi | Covi, isole del tesoro | Sì |
| Serpente gigante | Isole tropicali | Sì |
| Harpy | Isole rocciose | Sì |
| Scheletri pirati, wraith | Isole maledette | Sì |
| Serpente marino, kraken | Acque intorno alle isole | Sì |
| Wyvern, Hiryu | Isole rocciose e faraglioni | Sì |
| Lucertole di lava, elementali del fuoco, drake | Isole vulcaniche | Sì |
| Orsi polari, lupi bianchi, troll del gelo | Isole ghiacciate | Sì |
| Trichechi, foche | Isole ghiacciate, scogli dei mari freddi | No |
| Wisp | Isole dei funghi, di notte | Variabile |
| Cavallucci marini, delfini | Lagune e canali degli arcipelaghi | No |
| Pirati annegati | Relitti delle isole maledette | Sì |

Chi abita ogni tipo di isola di giorno e di notte è descritto in [Tipi di isola](#tipi-di-isola); l'elenco completo per bioma è in [Creature per bioma](/wiki/creature-per-bioma).

---

## ⚠️ Pericoli

- Si arriva solo via mare: la nave è indispensabile (vedi [Oceani](/wiki/oceani)).
- Chi muore su un'isola senza santuario deve tornare da fantasma camminando sul fondale.
- Secche, banchi di sabbia e scogli degli arcipelaghi danneggiano le navi grandi: tra gli isolotti conviene la barca a remi.
- Intorno alle isole ghiacciate gli iceberg sono scogli di ghiaccio, e a terra vale il danno da freddo della [tundra](/wiki/bioma-tundra).
- Sulle isole vulcaniche la lava distrugge tutto ciò che il corpo porta con sé.
- Sulle isole maledette la nebbia nasconde i non-morti anche di giorno.

> 💡 Un'isola remota è una base perfetta per una gilda: facile da difendere, difficile da raggiungere. Vedi [Città di gilda](/wiki/citta-di-gilda).

---

*Vedi anche: [Biomi](/wiki/biomi) | [Oceani](/wiki/oceani) | [Coste](/wiki/bioma-coste) | [Strutture](/wiki/strutture) | [Alberi](/wiki/alberi)*
