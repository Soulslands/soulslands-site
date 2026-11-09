---
title: Laghi e fiumi
slug: laghi-e-fiumi
category: Mondo
visibility: Pubblica
---
# 🏞️ Laghi e fiumi
*L'acqua dolce che scava le valli, disseta i viaggiatori e nasconde chi aspetta sulla riva*

---

## 📋 Indice

- [Panoramica](#panoramica)
- [Fiumi](#fiumi)
- [Laghi](#laghi)
- [Cascate e sorgenti](#cascate-e-sorgenti)
- [Acqua e lava come blocchi](#acqua-e-lava-come-blocchi)
- [Pesca](#pesca)
- [Creature delle acque dolci](#creature-delle-acque-dolci)
- [Acqua per bioma](#acqua-per-bioma)
- [Pericoli e consigli](#pericoli-e-consigli)

---

## 📜 Panoramica

Lontano dal mare, l'acqua di Soulslands scorre nei **fiumi**, riposa nei **laghi**, salta dalle **cascate** e sgorga dalle **sorgenti**. È acqua dolce: si beve, riempie borracce e bottiglie, serve a cucinare e a irrigare i campi, mentre l'acqua del mare è salata e non è potabile (vedi [Coste](/wiki/bioma-coste)). Fiumi e laghi sono anche le prime acque in cui si impara a nuotare, a pescare e a guidare una barca.

| Acqua | Che cos'è | Dove |
|-------|-----------|------|
| **Fiumi** | Due biomi veri e propri: `river` e `frozen_river` | Corrono nelle valli e arrivano al mare, a un lago o a un'oasi |
| **Laghi** | Forme del terreno, non biomi: prendono il bioma della zona in cui si trovano | Ovunque, con un tipo diverso per ogni clima |
| **Cascate e sorgenti** | Acqua che esce dalla roccia o cade da un dislivello | Montagne, colline, canyon, scogliere |
| **Acque sotterranee** | Fiumi e laghi nelle grotte | [Grotte e sottosuolo](/wiki/grotte-e-sottosuolo) |

Per il mare aperto vedi [Oceani](/wiki/oceani).

---

## 🏞️ Fiumi

I fiumi corrono nelle valli tra montagne e colline e sfociano nel mare, in un lago o, nel deserto, in un'oasi. Il generatore non simula la discesa dell'acqua: un fiume non nasce da una sorgente e non scende per forza lungo il pendio, segue il fondo della sua valle. Il canale è largo 8-24 blocchi, con una mediana di circa 16 (misurato da noi sui seed 7, 42 e 1997, [#336](https://github.com/Soulslands/soulslands-game/pull/336), [ADR-0032](https://github.com/Soulslands/soulslands-game/blob/main/docs/adr/0032-generator-versions-terrain-v2.md)). Sono un **bioma a sé**, una striscia d'acqua che taglia i biomi di terraferma: il letto e l'acqua appartengono al fiume, le rive al bioma che il fiume attraversa. Gli ID completi hanno il prefisso `soulslands:`.

| Bioma | ID | Dove | Larghezza | Profondità | Corrente |
|-------|----|------|-----------|------------|----------|
| **Fiume** | `river` | Quasi ovunque; nella tundra e sulle vette innevate diventa fiume ghiacciato | 8 – 24 blocchi | 3 – 6 blocchi al centro, fino a 10 vicino alla foce | Lenta in pianura, forte in montagna |
| **Fiume ghiacciato** | `frozen_river` | [Tundra](/wiki/bioma-tundra), vette innevate | 6 – 16 blocchi | 3 – 5 blocchi sotto il ghiaccio | Scorre sotto una crosta di ghiaccio |

I **ruscelli** non sono un bioma: sono rivoli larghi 1 – 3 blocchi e profondi uno o due, che si gettano nei fiumi. Sono comuni nelle foreste e sulle colline.

### 🌊 La corrente

L'acqua dei fiumi è fatta di **blocchi sorgente**, come quella dei laghi, quindi un fiume non si prosciuga se qualcuno scava la riva o raccoglie un secchio d'acqua. Il bioma fiume, però, dà a ogni blocco d'acqua una **direzione di corrente** verso valle, che spinge tutto ciò che galleggia o nuota:

- **Nuotatori**: nuotare controcorrente consuma molta stamina, e nelle rapide è impossibile.
- **Barche**: scendere un fiume è il modo più veloce per viaggiare nell'entroterra; risalirlo con la barca a remi è lento ma possibile.
- **Oggetti e corpi**: ciò che cade in un fiume viene trascinato a valle e si ferma in un'ansa, contro la riva o alla foce.

| Tratto | Dove | Corrente | Note |
|--------|------|----------|------|
| **Anse e meandri** | Pianure, paludi, giungla | Lenta | Acqua calma, ninfee e canne: il posto migliore per pescare |
| **Tratto normale** | Foreste, colline, taiga | Media | Si risale a nuoto, ma con fatica |
| **Rapide** | Pendii di montagna, [canyon rossi](/wiki/bioma-canyon-rossi) | Forte | Rocce affioranti: le barche urtano e si danneggiano, a nuoto non si risale |
| **Cascata** | Salti di quota | Verticale | Vedi [Cascate e sorgenti](#cascate-e-sorgenti) |
| **Foce** | Dove il fiume incontra il mare | Debole | Banchi di sabbia e argilla; nei climi caldi spesso si apre in una distesa di [mangrovie](/wiki/bioma-mangrovie) |

> 💡 La barca a remi è il mezzo ideale per i fiumi (vedi [Oceani](/wiki/oceani#navi)). Nei fiumi più larghi e profondi passa anche una nave piccola, mentre navi medie e galeoni si incagliano.

### 🏖️ Rive e letto del fiume

| Blocco | ID | Dove |
|--------|----|------|
| Sabbia | `sand` | Rive e letto dei fiumi lenti |
| Argilla | `clay` | Chiazze sul letto e sulle rive: è la fonte più comoda di argilla per mattoni e ceramiche |
| Ghiaia | `gravel` | Fiumi veloci e torrenti di montagna |
| Fango | `mud` | Fiumi di paludi, giungla e mangrovie |
| Canne | `reed` | Acque basse lungo le rive |
| Ninfee | `lily_pad` | Anse e tratti lenti |
| Nontiscordardimé | `forget_me_not` | Rive erbose dei fiumi e degli stagni |
| Ghiaccio | `ice` | Crosta dei fiumi ghiacciati e, d'inverno, dei fiumi dei biomi freddi |

Lungo le rive crescono i **salici** (`willow`), che amano l'acqua più di ogni altro albero; nei biomi freddi li sostituiscono abeti rossi (`spruce`) e betulle (`birch`), nella giungla le palme (`palm`). Vedi [Alberi](/wiki/alberi).

### 🧊 Fiumi ghiacciati

Nella tundra e sulle vette i fiumi sono coperti da una crosta di ghiaccio (`ice`) spessa uno o due blocchi, su cui si cammina come su una strada. Sotto, però, l'acqua continua a scorrere. Le rive sono di neve (`snow`) e ghiaia (`gravel`), con pini di brina (`frost_pine`) e abeti rossi (`spruce`).

> ⚠️ Il ghiaccio regge chi va a piedi, ma si rompe sotto le cavalcature e i carichi pesanti (vedi [Tundra e nevi](/wiki/bioma-tundra)). Chi cade in un buco viene trascinato dalla corrente **sotto la crosta**: bisogna ritrovare il buco o rompere il ghiaccio sopra la testa prima che finisca l'aria.

---

## 💧 Laghi

I laghi **non sono biomi**: sono forme del terreno che prendono alberi, blocchi e creature del bioma in cui si trovano. Tranne i laghi di cratere, che restano rotondi, un lago sta solo su terreno pianeggiante: niente argini di pietra sulla parte bassa e niente sponde scavate nel pendio ([#345](https://github.com/Soulslands/soulslands-game/pull/345); nel pacchetto del gioco i laghi sono tornati numerosi con [#347](https://github.com/Soulslands/soulslands-game/pull/347)). Un lago di montagna appartiene al bioma [Montagne](/wiki/bioma-montagne), un'oasi al [Deserto](/wiki/bioma-deserto). L'acqua dei laghi è ferma: nessuna corrente, solo onde quando tira vento.

| Tipo | Dove | Dimensioni | Fondale e rive |
|------|------|------------|----------------|
| **Stagno di foresta** | Foreste, pianure, taiga, foresta incantata | 5 – 15 blocchi, profondo 1 – 3 | Argilla (`clay`), terra (`dirt`), fango (`mud`); canne e ninfee; salici e betulle intorno |
| **Lago di montagna** | Valli alte delle montagne, taiga (con il terreno v2 per ora ne restano pochi: la correzione è pianificata) | 20 – 80 blocchi, profondo fino a 20 | Ghiaia, pietra (`stone`), sabbia; abeti rossi, abeti bianchi (`fir`) e pini (`pine`) |
| **Oasi** | [Deserto](/wiki/bioma-deserto), [savana](/wiki/bioma-savana), [canyon rossi](/wiki/bioma-canyon-rossi) | 6 – 20 blocchi, profonda 2 – 4 | Sabbia, erba (`grass`), argilla; palme (`palm`), canne, erba alta (`tall_grass`) |
| **Lago di cratere** | Vulcani spenti: ai margini delle [terre vulcaniche](/wiki/bioma-terre-vulcaniche), in montagna, sulle [isole](/wiki/bioma-isole) vulcaniche | 15 – 40 blocchi, rotondo, profondo 20 – 30 | Pareti di basalto (`basalt`), sabbia nera (`black_sand`) e pomice (`pumice`) sulle rive, ossidiana (`obsidian`) sul fondo |
| **Lago ghiacciato** | Tundra e vette (sempre); taiga, brughiera e montagne (d'inverno) | Variabile | Ghiaccio (`ice`) in superficie, ghiaccio compatto (`packed_ice`) lungo le rive della tundra, ghiaia sul fondo |
| **Pozze della palude** | [Palude](/wiki/bioma-palude), torbiere della [brughiera](/wiki/bioma-brughiera) | 3 – 12 blocchi, raramente oltre 2 di profondità | Fango, torba (`peat`), argilla sotto il fango; canne, ninfee e lenticchia d'acqua (`duckweed`); cipressi di palude (`bog_cypress`) e salici |
| **Lago di lava** | Superficie delle [terre vulcaniche](/wiki/bioma-terre-vulcaniche), sottosuolo profondo | 5 – 40 blocchi | Lava (`lava`), basalto e ossidiana lungo i bordi |
| **Lago sotterraneo** | Caverne e grotte allagate | Variabile, a volte enorme | Pietra, ghiaia, argilla, stalagmiti (`stalagmite`) |

### 🌳 Stagni di foresta

Piccoli specchi d'acqua calma nelle radure: sono il primo posto dove un principiante impara a pescare. Al tramonto ci vengono a bere i cervi, di notte si riempiono del verso delle rane toro. L'argilla del fondo è la più facile da raccogliere.

### ⛰️ Laghi di montagna

Laghi limpidi e gelidi nelle valli tra le vette, alimentati da cascate e sorgenti. Sono profondi, e l'acqua è così chiara che si vede il fondale. D'inverno gelano; intorno a Y 180 e oltre restano ghiacciati tutto l'anno (il limite oscilla di circa 20 blocchi, come quello della neve). Nei più profondi vive a volte un [elementale dell'acqua](/wiki/mostro-elementale-dell-acqua).

Nei [prati alpini](/wiki/bioma-prati-alpini) ci sono anche i **laghetti glaciali** (`glacial_pond`): piccoli, larghi 4-16 blocchi e profondi 1-3, con letto e sponde di ghiaia ([#494](https://github.com/Soulslands/soulslands-game/pull/494)). Il ghiaccio d'inverno vale per loro come per i laghi di montagna, ma arriverà con le stagioni: ora il generatore li crea sempre liquidi.

### 🌴 Oasi

Nel deserto l'oasi è l'unica acqua potabile per giorni di cammino: una pozza limpida circondata da palme, canne ed erba, dove i viaggiatori riempiono le borracce e gli [ostard del deserto](/wiki/animale-ostard-del-deserto) vengono a bere. Nella savana e nei canyon rossi le oasi sono più piccole e d'estate si restringono. Le oasi abbandonate, di notte, attirano i [ghoul](/wiki/mostro-ghoul).

### 🌋 Laghi di cratere

Nel cratere di un vulcano spento l'acqua piovana forma un lago rotondo, profondo e blu scuro, chiuso da pareti di basalto. Il fondo è di ossidiana e lungo le rive si trovano sabbia nera e pomice. È uno dei laghi più profondi del mondo e uno dei migliori per la pesca rara.

### ❄️ Laghi ghiacciati

Nella tundra i laghi sono coperti di ghiaccio tutto l'anno; nella taiga, nella brughiera e in montagna gelano solo d'inverno. Sul ghiaccio si cammina, si costruisce e si pesca: basta rompere un blocco per aprire un buco nell'acqua. Il ghiaccio, però, si rompe sotto le cavalcature.

### 🐸 Pozze della palude

Acqua bassa, stagnante e torbida, raramente più profonda di due blocchi, tra fango, torba e radici di cipresso. Nella brughiera le stesse pozze sono scure di torba e avvolte dalla nebbia. D'estate le pozze delle paludi si restringono e lasciano il fango scoperto (vedi [Il Mondo](/wiki/mondo#meteo-e-stagioni)). Sotto la superficie può nascondersi un [tentacolo di palude](/wiki/mostro-tentacolo-di-palude): non sporgetevi dalle rive.

### 🔥 Laghi di lava

Nelle [terre vulcaniche](/wiki/bioma-terre-vulcaniche) la lava forma laghi e fiumi anche in superficie: colate lente che scendono dai crateri e si allargano in pozze incandescenti, orlate di basalto e ossidiana. Illuminano la zona come in pieno giorno e incendiano tutto ciò che è infiammabile. Sotto terra, più si scende più l'acqua lascia il posto alla lava: nel sottosuolo profondo e nell'Abisso i laghi sotterranei sono soprattutto di lava.

### 🕳️ Laghi e fiumi sotterranei

Nelle grotte l'acqua forma laghi immobili nelle grandi caverne, fiumi sotterranei con correnti che trascinano e gallerie completamente allagate. Al buio i mostri compaiono a qualsiasi ora. Ogni bioma delle grotte ha la sua acqua:

| Grotta | ID | Acqua tipica |
|--------|----|--------------|
| Grotte allagate | `flooded_caves` | Fiumi e laghi sotterranei sotto coste e paludi; alcune gallerie sbucano in mare |
| Grotte di muschio | `moss_caves` | Pozze limpide tra le radici luminose, sotto foreste e giungla |
| Grotte di stalattiti | `dripstone_caves` | L'acqua gocciola dalle stalattiti e riempie piccole pozze |
| Grotte di ghiaccio | `ice_caves` | Laghi sotterranei ghiacciati sotto tundra e vette |
| Caverne di lava | `lava_caverns` | Laghi e fiumi di lava negli strati profondi |

Vedi [Grotte e sottosuolo](/wiki/grotte-e-sottosuolo).

---

## 💦 Cascate e sorgenti

| Elemento | Dove | Caratteristiche |
|----------|------|-----------------|
| **Sorgente** | Pareti di montagne e colline, fondo delle valli | Un blocco d'acqua sorgente che esce dalla roccia o dal terreno e dà vita a un ruscello; acqua limpida e potabile |
| **Sorgente calda** | Margini delle [terre vulcaniche](/wiki/bioma-terre-vulcaniche), qualche valle di montagna e di tundra | Acqua calda e fumante che non gela mai: chi ci si immerge non subisce il danno da freddo |
| **Cascata** | Montagne, [canyon rossi](/wiki/bioma-canyon-rossi), bordi degli altipiani, scogliere sul mare | Acqua che cade in verticale da 5 fino a 80 blocchi, con una pozza profonda alla base |
| **Rapide** | Pendii ripidi | Vedi [La corrente](#la-corrente) |

- Una cascata **non si risale a nuoto**: servono una scala, gradini scavati nella roccia accanto o un'altra strada.
- Dietro le cascate più alte a volte si apre una **grotta**.
- Cadere in un'acqua profonda almeno due blocchi **annulla il danno da caduta**: la pozza alla base di una cascata è la via più rapida per scendere da una montagna, per chi ha il coraggio di saltare.

> 💡 Una sorgente calda in mezzo alla neve è il posto migliore per un rifugio nella tundra.

---

## 🧱 Acqua e lava come blocchi

Acqua (`water`) e lava (`lava`) sono blocchi liquidi e si comportano come in Minecraft. Vedi anche [Blocchi](/wiki/blocchi).

### Sorgente e flusso

Ogni liquido esiste in due forme: il **blocco sorgente**, che resta dov'è, e il **flusso**, che parte dalla sorgente, scende verso il basso e si allarga in piano finché ne ha la forza. Se la sorgente sparisce, il flusso si ritira.

| | Acqua (`water`) | Lava (`lava`) |
|---|-----------------|---------------|
| **Sorgente** | Si raccoglie con un secchio; il flusso no | Si raccoglie con un secchio; il flusso no |
| **Flusso in piano** | Fino a 7 blocchi dalla sorgente | Fino a 3 blocchi; 7 nelle terre vulcaniche e nel Cuore del mondo |
| **Velocità** | Veloce | Lenta |
| **Cadute** | Scende in verticale fino al primo blocco solido, poi si allarga | Lo stesso, più lentamente |
| **Nuove sorgenti** | Un flusso tra due sorgenti diventa a sua volta sorgente: una pozza 2×2 non si esaurisce mai | Mai |
| **Luce** | Cala man mano che si scende sott'acqua | Livello 15: illumina tutto intorno |
| **Effetti** | Spegne il fuoco e chi brucia, trascina oggetti e corpi, spegne le torce e sradica le piante che travolge | Incendia legno, foglie ed erba vicini; distrugge gli oggetti e i corpi che ci cadono dentro |

### Acqua e lava che si incontrano

| Incontro | Risultato |
|----------|-----------|
| L'acqua raggiunge una **sorgente** di lava | Ossidiana (`obsidian`) |
| L'acqua raggiunge un **flusso** di lava | Ciottoli (`cobblestone`) |
| La lava cade dall'alto sull'acqua | Pietra (`stone`) |

> 💡 Versare acqua su un lago di lava lo trasforma in un pavimento di ossidiana: è il modo più sicuro per attraversarlo, ma l'ossidiana è durissima e per scavarla serve un piccone di qualità. Un flusso d'acqua e uno di lava che si toccano producono invece ciottoli all'infinito, come il generatore di ciottoli di Minecraft.

### Il ghiaccio e le stagioni

Nei biomi freddi l'acqua ferma esposta al cielo **gela**: la superficie di laghi e fiumi diventa ghiaccio (`ice`), a partire dalle rive. Il mondo ha quattro stagioni, e d'inverno i laghi del nord ghiacciano (vedi [Il Mondo](/wiki/mondo#meteo-e-stagioni)).

| Dove | Quando gela |
|------|-------------|
| Tundra, vette innevate, fiumi ghiacciati | Sempre |
| Taiga, montagne, brughiera, Terre dei Morti | D'inverno |
| Foreste temperate, pianure, palude | Mai: d'inverno può nevicare, ma l'acqua resta liquida |
| Giungla, mangrovie, savana, deserto, terre vulcaniche | Mai |

- In primavera il ghiaccio formato d'inverno torna acqua. Anche una fonte di luce forte vicina (torce, fuochi, lava) lo scioglie lentamente.
- Il ghiaccio compatto (`packed_ice`) e il ghiaccio di ghiacciaio (`glacier_ice`) non si sciolgono mai.
- Rompere un blocco di ghiaccio che ha acqua sotto lo trasforma in acqua: è così che si apre un buco per pescare.

---

## 🎣 Pesca

In acqua dolce si pesca con la skill [Fishing](/wiki/skill-fishing) e una canna da pesca: dalla riva, da un pontile, da una barca o attraverso un buco nel ghiaccio. Le acque vicine alle città sono le migliori per imparare.

| Acqua | Cosa si pesca | Fishing consigliato | Note |
|-------|---------------|---------------------|------|
| Ruscelli e fiumi | Trote, pesci d'acqua dolce, stivali vecchi | 0+ | La corrente trascina la lenza: si pesca meglio nelle anse. Le uova di [rana toro](/wiki/animale-rana-toro) sono l'esca migliore per i pesci di fiume |
| Stagni di foresta | Carpe, pesci comuni | 0+ | Acqua calma, ideale per i principianti |
| Oasi | Pochi pesci comuni | 0+ | Si pesca poco: qui l'acqua vale più del pesce |
| Pozze della palude | Carpe, rottami, stivali vecchi | 10+ | A volte abbocca qualcosa che non è un pesce: un tentacolo di palude |
| Laghi di montagna | Trote grandi, pesci d'acqua fredda | 30+ | Acqua profonda e limpida |
| Laghi ghiacciati | Pesci d'acqua fredda | 40+ | Bisogna aprire un buco nel ghiaccio |
| Laghi e fiumi sotterranei | Pesci ciechi | 50+ | Al buio, con i mostri intorno: tenete le torce accese |
| Laghi di cratere | Pesci rari d'acqua dolce | 60+ | Molto profondi; a volte abbocca un elementale dell'acqua |
| Laghi di lava | Niente | Nessuno | La lenza brucia |

- Con la **pioggia** si pesca meglio, come in mare (vedi [Il Mondo](/wiki/mondo#meteo-e-stagioni)).
- Per il pesce di mare e i tesori del fondale vedi la [pesca in mare](/wiki/oceani#pesca).

---

## 🐸 Creature delle acque dolci

Fiumi e laghi attirano animali che vengono a bere e predatori che li aspettano. Di notte, sulle rive, valgono le regole di spawn di tutta la superficie: al buio compaiono anche scheletri, zombie e gli altri mostri notturni del bioma (vedi [Spawn delle creature](/wiki/spawn-creature) e [Giorno e notte](/wiki/giorno-e-notte)). L'elenco completo per bioma è in [Creature per bioma](/wiki/creature-per-bioma).

| Acqua | ☀️ Di giorno | 🌑 Di notte |
|-------|--------------|-------------|
| **Fiumi** | Gru (Crane), uccelli, [cervi](/wiki/animale-cervo) che bevono all'alba e al tramonto, [orsi bruni](/wiki/animale-orso-bruno) che pescano nei torrenti | [Rane toro](/wiki/animale-rana-toro) sulle rive; [lizardman](/wiki/mostro-lizardman) lungo i fiumi vicino alle paludi |
| **Fiumi lenti dei biomi caldi** | [Alligatori](/wiki/animale-alligatore) sulle rive; nella giungla [serpenti giganti](/wiki/animale-serpente-gigante) e serpenti d'argento (Silver Serpent) | Alligatori, lizardman, [rospi giganti](/wiki/animale-rospo-gigante), serpenti giganti |
| **Fiumi e laghi ghiacciati** | [Orsi polari](/wiki/animale-orso-polare), [lupi bianchi](/wiki/animale-lupo-bianco), [troll del gelo](/wiki/mostro-troll-del-gelo), [leopardi delle nevi](/wiki/animale-leopardo-delle-nevi) all'alba e al tramonto | Orsi polari, lupi bianchi, [troll del gelo](/wiki/mostro-troll-del-gelo), [elementali della neve](/wiki/mostro-elementale-della-neve) durante le bufere, [elementali del ghiaccio](/wiki/mostro-elementale-del-ghiaccio), più forti di notte e d'inverno |
| **Stagni di foresta** | Cervi, conigli, uccelli, [orsi neri](/wiki/animale-orso-nero) | Rane toro, [mongbat](/wiki/mostro-mongbat), [lupi grigi](/wiki/animale-lupo-grigio) |
| **Laghi di montagna** | [Capre di montagna](/wiki/animale-capra-di-montagna), [aquile](/wiki/animale-aquila), orsi bruni, [puma](/wiki/animale-puma) all'alba e al tramonto | [Elementale dell'acqua](/wiki/mostro-elementale-dell-acqua) nei laghi più profondi |
| **Oasi** | [Ostard del deserto](/wiki/animale-ostard-del-deserto), [lepri](/wiki/animale-lepre) all'alba, [serpenti](/wiki/animale-serpente) | [Scorpioni](/wiki/mostro-scorpione-gigante), [ghoul](/wiki/mostro-ghoul) nelle oasi abbandonate |
| **Laghi di cratere** | Aquile, [drake](/wiki/mostro-drake) in volo | Elementale dell'acqua nelle acque profonde |
| **Pozze della palude** | Alligatori, rane toro, rospi giganti, gru, [tentacolo di palude](/wiki/mostro-tentacolo-di-palude) (sempre, più attivo al crepuscolo) | Bogling, cosa della palude (Bog Thing), [wisp](/wiki/mostro-wisp) nella nebbia, lizardman, zombie |
| **Laghi di lava** | [Lucertole di lava](/wiki/animale-lucertola-di-lava), [elementali del fuoco](/wiki/mostro-elementale-del-fuoco), coleotteri di fuoco (Fire Beetle) | Gli stessi, più [segugi infernali](/wiki/mostro-segugio-infernale) e [gatti infernali](/wiki/mostro-gatto-infernale) |
| **Laghi e fiumi sotterranei** | Sotto terra non c'è differenza: tentacoli di palude nelle pozze stagnanti, [troll](/wiki/mostro-troll) e lizardman nelle grotte umide, [melme](/wiki/mostro-slime), [ratti giganti](/wiki/animale-ratto-gigante), pesci ciechi | Come di giorno |

> ⚠️ Gli alligatori aspettano immobili tra le canne con solo gli occhi fuori dall'acqua, e il tentacolo di palude afferra chi si sporge dalla riva: in palude, guardate l'acqua prima di avvicinarvi.

---

## 📊 Acqua per bioma

| Bioma | Fiumi e ruscelli | Laghi e pozze | Colore dell'acqua | Ghiaccio |
|-------|------------------|---------------|-------------------|----------|
| [Pianure e praterie](/wiki/bioma-pianure) | Fiumi larghi e lenti con anse, rive di sabbia e ghiaia | Stagni tra le colline | Azzurra | No |
| [Foresta temperata](/wiki/bioma-foresta-temperata) | Ruscelli e fiumi con argilla e ghiaia | Stagni di foresta | Azzurra | No |
| [Foresta autunnale](/wiki/bioma-foresta-autunnale) | Come la foresta temperata: ruscelli e fiumi con argilla e ghiaia | Stagni di foresta | Azzurra | No |
| [Foresta profonda](/wiki/bioma-foresta-profonda) | Ruscelli scuri sotto le chiome | Stagni in penombra, dove i mostri compaiono anche di giorno | Verde scura | No |
| [Foresta incantata](/wiki/bioma-foresta-incantata) | Ruscelli limpidi | Laghetti con funghi luminosi sulle rive | Turchese, con riflessi argentei di notte | No |
| [Taiga](/wiki/bioma-taiga) | Fiumi limpidi e freddi | Molti laghi tra gli abeti | Blu scura | D'inverno |
| [Brughiera](/wiki/bioma-brughiera) | Ruscelli tra le colline | Pozze scure di torba nella nebbia | Bruna, quasi nera | D'inverno |
| [Montagne](/wiki/bioma-montagne) | Torrenti, rapide, cascate, sorgenti | Laghi di montagna, laghi di cratere | Limpida, azzurro chiaro | D'inverno; sempre intorno a Y 180 e oltre |
| [Prati alpini](/wiki/bioma-prati-alpini) | Ruscelli e sorgenti dei versanti | Laghetti glaciali | Limpida, azzurro chiaro | D'inverno |
| [Fiordi e gole](/wiki/bioma-fiordi-e-gole) | Gola: il fiume sul fondo, piano e a livello del mare (rapide e cascate arriveranno con M5-12n); fiordo: la foce allagata dal mare | Nessuno proprio | Gola: limpida; fiordo: quella del mare vicino (vedi [Oceani](/wiki/oceani#biomi-oceanici)) | Solo davanti alla tundra |
| [Tundra e nevi](/wiki/bioma-tundra) | Fiumi ghiacciati (`frozen_river`) | Laghi ghiacciati | Blu ghiaccio | Sempre |
| [Palude](/wiki/bioma-palude) | Canali lenti tra gli isolotti | Pozze stagnanti, raramente oltre 2 blocchi | Verde bruna, torbida | No |
| [Mangrovie](/wiki/bioma-mangrovie) | Canali di marea dove i fiumi incontrano il mare | Lagune tra le radici | Verde, salmastra e non potabile | No |
| [Giungla](/wiki/bioma-giungla) | Fiumi lenti e larghi, rive di fango e palme | Pozze tra le radici giganti | Verde | No |
| [Steppa](/wiki/bioma-steppa) | Pochi ruscelli lenti | Pozze che d'estate si restringono | Azzurra | No |
| [Savana](/wiki/bioma-savana) | Pochi fiumi lenti | Pozze che d'estate si restringono; acqua nel tronco cavo dei baobab | Torbida, color sabbia | No |
| [Deserto](/wiki/bioma-deserto) | Rari e corti, spesso finiscono in un'oasi | Oasi | Turchese | No |
| [Canyon rossi](/wiki/bioma-canyon-rossi) | Un fiume sul fondo dei canyon, con rapide e cascate | Rare oasi | Rossastra, per l'argilla rossa (`red_clay`) | No |
| [Terre vulcaniche](/wiki/bioma-terre-vulcaniche) | Fiumi di lava | Laghi di lava; sorgenti calde ai margini | Lava | No |
| [Terre dei Morti](/wiki/bioma-terre-dei-morti) | Ruscelli lenti e grigi | Pozze stagnanti nella nebbia | Grigia | D'inverno |
| [Lande d'Ombra](/wiki/bioma-lande-d-ombra) | Quasi assenti | Rare pozze scure in fondo alle crepe | Nera, con riflessi viola | No |
| [Coste](/wiki/bioma-coste) | Foci dei fiumi | Lagune salate | Quella del mare vicino (vedi [Oceani](/wiki/oceani#biomi-oceanici)) | Solo davanti alla tundra |
| [Isole](/wiki/bioma-isole) | Ruscelli sulle isole grandi | Pozze; laghi di cratere sulle isole vulcaniche spente | Come il bioma dell'isola | Solo sulle isole ghiacciate |

---

## ⚠️ Pericoli e consigli

- **Annegare**: sott'acqua l'aria dura circa 30 secondi, e con un'armatura di piastre si affonda (vedi [Nuotare e respirare](/wiki/oceani#nuotare-e-respirare)). Nei fiumi la corrente rende tutto più difficile.
- **Ghiaccio sottile**: non attraversate laghi e fiumi ghiacciati a cavallo. Sotto la crosta di un fiume ghiacciato la corrente trascina via.
- **Rapide e cascate**: una barca nelle rapide si danneggia, e una cascata si scende ma non si risale.
- **Falde d'acqua**: scavando nel sottosuolo superficiale si può aprire una falda che allaga la galleria; più in basso, la stessa sorpresa può essere di lava. Tenete un blocco a portata di mano per tappare il buco.
- **Lava**: tutto ciò che il corpo porta con sé brucia (vedi [Terre vulcaniche](/wiki/bioma-terre-vulcaniche)). Un secchio d'acqua trasforma la lava in ossidiana e può salvare la vita.
- **Corpi alla deriva**: chi muore in un fiume lascia il corpo alla corrente. Cercatelo a valle, nelle anse o alla foce, prima che lo trovi qualcun altro (vedi [Full loot](/wiki/full-loot)).

> 💡 Una casa sulla riva di un fiume ha acqua potabile, argilla, pesce e una strada già pronta verso il mare: è il posto ideale per un villaggio di gilda (vedi [Città di gilda](/wiki/citta-di-gilda)).

---

*Vedi anche: [Oceani](/wiki/oceani) | [Grotte e sottosuolo](/wiki/grotte-e-sottosuolo) | [Biomi](/wiki/biomi) | [Blocchi](/wiki/blocchi) | [Palude](/wiki/bioma-palude) | [Fishing](/wiki/skill-fishing)*
