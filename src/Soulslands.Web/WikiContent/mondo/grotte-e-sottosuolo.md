---
title: Grotte e sottosuolo
slug: grotte-e-sottosuolo
category: Mondo
visibility: Pubblica
---
# ⛏️ Grotte e sottosuolo
*Più scavi, più trovi. Più scendi, meno torni*

---

## 📋 Indice

- [Panoramica](#panoramica)
- [Strati di profondità](#strati-di-profondita)
- [Minerali per profondità](#minerali-per-profondita)
- [Grotte naturali](#grotte-naturali)
- [Biomi sotterranei](#biomi-sotterranei)
- [Dungeon generati](#dungeon-generati)
- [Creature del buio](#creature-del-buio)
- [Consigli per i minatori](#consigli-per-i-minatori)

---

## 📜 Panoramica

Sotto ogni bioma si estende un sottosuolo profondo quasi 200 blocchi: strati di roccia sempre più dura, grotte, fiumi sotterranei, laghi di lava e dungeon. Qui si trovano i [minerali](/wiki/minerali) che servono al [Blacksmithy](/wiki/skill-blacksmithy): più è raro il minerale, più bisogna scendere e più è alta la skill [Mining](/wiki/skill-mining) richiesta per estrarlo.

Le grotte non sono tutte uguali. Secondo il bioma in superficie e la profondità si entra in uno dei sette [biomi sotterranei](#biomi-sotterranei), dalle grotte di muschio sotto le foreste alle caverne di lava dell'Abisso, ognuno con le sue rocce, la sua luce, le sue risorse e le sue creature.

> ⚠️ Sotto terra non c'è luce naturale: senza torce le creature del buio compaiono ovunque. E chi muore in fondo all'Abisso lascia tutto sul corpo, a 150 blocchi da qualsiasi santuario.

---

## 🪨 Strati di profondità

| Strato | Quota (Y) | Roccia (blocco) | Scavata dà | Pericolo | Note |
|--------|-----------|-----------------|------------|----------|------|
| **Superficie** | sopra 40 | Terra e suolo del bioma (`dirt`, `grass`, `sand`…), poi pietra comune (`stone`) | Terra o sabbia; `cobblestone` dalla pietra | ⭐ | Affioramenti di minerali comuni |
| **Sottosuolo superficiale** | 0 – 40 | Pietra (`stone`) | `cobblestone` | ⭐⭐ | Grotte, falde d'acqua |
| **Strato medio** | -16 – 0 | Pietra scura (`dark_stone`) | `dark_cobblestone` | ⭐⭐⭐ | Grandi caverne, miniere abbandonate |
| **Sottosuolo profondo** | -32 – -16 | Ardesia profonda (`deepslate`) | `cobbled_deepslate` | ⭐⭐⭐⭐ | Laghi di lava, dungeon maggiori |
| **Abisso** | -48 – -32 | Basalto nero (`black_basalt`) | `cobbled_basalt` | ⭐⭐⭐⭐⭐ | Caverne immense, creature leggendarie |
| **Cuore del mondo** | -64 – -48 | Roccia infernale (`hellstone`) | `cobbled_hellstone` | ⭐⭐⭐⭐⭐ | Solo minerali leggendari e demoni; sotto Y -56 ogni caverna è piena di lava |
| **Roccia del Mondo** | -64 | Roccia del Mondo (`world_rock`), indistruttibile | Non si scava | — | Il fondo del mondo; in alcuni punti risale a macchie fino a Y -60 |

Non esistono livelli di piccone (qualsiasi piccone scava qualsiasi minerale, decide la skill Mining): la roccia più profonda è più dura e si scava più lentamente, e il materiale dell'attrezzo cambia solo velocità e durata (vedi [Attrezzi](/wiki/attrezzi)).

Tra uno strato e l'altro le due rocce si mescolano per qualche blocco, quindi il passaggio non è mai una linea netta. Il pietrisco (`cobblestone` e simili) si usa per costruire o si lavora in mattoni: tempi di scavo e usi di ogni roccia sono nella pagina [Blocchi](/wiki/blocchi#rocce-degli-strati).

---

## 💎 Minerali per profondità

Le profondità sono quelle **standard**: ogni [bioma](/wiki/biomi) può rendere alcune vene più frequenti o farle affiorare più in alto.

| Minerale | Mining richiesto | Rarità vena | Profondità tipica | Biomi favoriti |
|----------|------------------|-------------|-------------------|----------------|
| [Iron](/wiki/minerale-iron) | 0 | Molto comune | Ovunque | Tutti |
| [Rusty](/wiki/minerale-rusty) | 35 | Comune | Superficie – Y 20 | Foreste, pianure |
| [Old Copper](/wiki/minerale-old-copper) | 45 | Comune | Y 40 – 0 | Paludi, foresta profonda |
| [Steel](/wiki/minerale-steel) | 55 | Comune | Y 40 – 0 | Pianure, coste |
| [Dull Copper](/wiki/minerale-dull-copper) | 65 | Comune | Y 10 – -16 | Deserto, giungla |
| [Rose](/wiki/minerale-rose) | 65 | Non comune | Y 10 – -16 | Foresta incantata |
| [Shadow Iron](/wiki/minerale-shadow-iron) | 70 | Comune | Y 0 – -20 | Terre dei Morti, montagne |
| [Copper](/wiki/minerale-copper) | 75 | Comune | Y 0 – -20 | Paludi, foresta profonda |
| [Silver](/wiki/minerale-silver) | 75 | Non comune | Y 0 – -20 | Montagne, tundra, foresta incantata |
| [Bronze](/wiki/minerale-bronze) | 80 | Non comune | Y -16 – -32 | Tundra, deserto |
| [Orialco](/wiki/minerale-orialco) | 80 | Raro | Y -16 – -32 | Isole lontane |
| [Gold](/wiki/minerale-gold) | 85 | Non comune | Y -16 – -32 | Deserto |
| [Blood Rock](/wiki/minerale-blood-rock) | 85 | Raro | Y -20 – -32, vicino alla lava | Terre vulcaniche |
| [Agapite](/wiki/minerale-agapite) | 90 | Raro | Y -24 – -40 | Giungla |
| [Mytheril](/wiki/minerale-mytheril) | 90 | Raro | Y -32 – -48 | Foresta incantata, Terre dei Morti |
| [Verite](/wiki/minerale-verite) | 95 | Raro | Y -32 – -48 | Giungla, isole |
| [Black Rock](/wiki/minerale-black-rock) | 95 | Molto raro | Y -32 – -48 | Terre vulcaniche, Lande d'Ombra |
| [Titanio](/wiki/minerale-titanio) | 97 | Molto raro | Y -36 – -55 | Tundra, vette |
| [Valorite](/wiki/minerale-valorite) | 99 | Raro | Y -40 – -55 | Isole remote, vette |
| [Cobalto](/wiki/minerale-cobalto) | 99 | Rarissimo | Y -48 – -64 | Lande d'Ombra |
| [Demonic](/wiki/minerale-demonic) | 100 | Rarissimo | Y -50 – -64 | Terre vulcaniche, Lande d'Ombra |

> 💡 Le eccezioni sono le **vette delle montagne**: sopra Y 180 le pareti espongono Bronze, Titanio e perfino Valorite. Vedi [Montagne](/wiki/bioma-montagne).

---

## 🕳️ Grotte naturali

Il sottosuolo è attraversato da grotte scavate dal generatore del mondo, come in Minecraft. Di solito le grotte restano ad almeno 6 blocchi sotto il terreno, così il suolo non crolla sotto i piedi: ci si entra dagli **imbocchi** che si aprono sui fianchi delle colline e nelle pareti dei canyon, dai **pozzi** naturali e dai **burroni**, oppure scavando.

### ⛏️ Come si formano le grotte

| Forma | Dove | Caratteristiche |
|-------|------|-----------------|
| **Cunicoli** | Ovunque | Stretti, ramificati, collegano la superficie al sottosuolo. Sono gli *spaghetti* di Minecraft: gallerie larghe da 1 a 3 blocchi e lunghe anche centinaia, che si incrociano, salgono e scendono da uno strato all'altro |
| **Caverne** | Strato medio e profondo | Sale enormi con stalattiti, laghi sotterranei. Sono il *formaggio* di Minecraft: vuoti tondeggianti alti decine di blocchi, separati da pilastri e ponti di roccia |
| **Burroni** | Ovunque; i più grandi sotto le [montagne](/wiki/bioma-montagne) e nei [canyon rossi](/wiki/bioma-canyon-rossi) | Spaccature strette, profonde fino a 50 blocchi e lunghe fino a 150, spesso aperte verso il cielo. Le vene di minerale si vedono sulle pareti. Il sole arriva fino in fondo solo dove si vede il cielo: nelle anse e sotto le sporgenze è buio anche a mezzogiorno |
| **Fiumi sotterranei** | Sottosuolo superficiale e medio | Correnti che trascinano, pesci ciechi |
| **Falde acquifere** | Sotto il livello del mare (Y 63), soprattutto sotto [coste](/wiki/bioma-coste), [paludi](/wiki/bioma-palude) e grandi [fiumi](/wiki/laghi-e-fiumi) | Sacche d'acqua chiuse nella roccia: chi ci scava dentro allaga la galleria (vedi [Laghi e fiumi](/wiki/laghi-e-fiumi#laghi-e-fiumi-sotterranei)) |
| **Laghi di lava** | Sottosuolo profondo, terre vulcaniche | Luce naturale, danno da fuoco, Blood Rock |
| **Livello della lava** | Sotto Y -56 | Negli ultimi 8 blocchi sopra la Roccia del Mondo ogni grotta è piena di lava: è il mare di fuoco del Cuore del mondo |
| **Grotte marine** | Coste | Allagate a metà, accessibili con la bassa marea |

Le **grotte di cristallo**, insieme ad altri sei tipi di grotta, sono [biomi sotterranei](#biomi-sotterranei) e sono descritte nella sezione seguente.

> 💡 Burroni e grandi caverne sono il modo più rapido per trovare minerale senza scavare, perché le vene affiorano sulle pareti. Sono però anche le zone di spawn più grandi del sottosuolo: ampie, buie e piene di angoli ciechi. Entrateci con molte torce.

---

## 🍄 Biomi sotterranei

Come la superficie, anche il sottosuolo ha i suoi biomi. Il bioma di una grotta dipende dalla **profondità** e dal **bioma in superficie** che le sta sopra: sotto una giungla si trovano grotte di muschio, sotto la tundra grotte di ghiaccio e, scendendo abbastanza, ovunque si arriva alle caverne di lava. Ogni bioma sotterraneo ha un id come quelli di superficie, per esempio `soulslands:dripstone_caves` (vedi [Biomi](/wiki/biomi)), e decide rocce, piante, luce, risorse e creature della grotta.

| Bioma sotterraneo | Id | In breve |
|-------------------|----|----------|
| 🪨 [Grotte di stalattiti](#grotte-di-stalattiti) | `soulslands:dripstone_caves` | Il più diffuso: roccia stillante, stalattiti e stalagmiti |
| 🌿 [Grotte di muschio](#grotte-di-muschio) | `soulslands:moss_caves` | Muschio, liane e radici luminose sotto foreste e giungla |
| 💎 [Grotte di cristallo](#grotte-di-cristallo) | `soulslands:crystal_caves` | Cristalli di mana e geodi sotto la foresta incantata e la tundra |
| 🍄 [Caverne dei funghi giganti](#caverne-dei-funghi-giganti) | `soulslands:mushroom_caverns` | Funghi alti come alberi sotto la palude e la foresta profonda |
| 🧊 [Grotte di ghiaccio](#grotte-di-ghiaccio) | `soulslands:ice_caves` | Gallerie di ghiaccio sotto la tundra e le vette innevate |
| 🌋 [Caverne di lava](#caverne-di-lava) | `soulslands:lava_caverns` | Laghi e fiumi di lava negli strati profondi e sotto le terre vulcaniche |
| 💧 [Grotte allagate](#grotte-allagate) | `soulslands:flooded_caves` | Fiumi, laghi e gallerie sommerse sotto coste e paludi |

### 🗺️ Quale grotta trovi

Il sottosuolo si divide in due fasce: la **fascia alta**, dalle prime grotte sotto il terreno fino a Y 0, e la **fascia media**, da Y 0 a Y -32. Dove la tabella dice *comuni*, la grotta è di semplice roccia dello strato con qualche chiazza di stalattiti: le grotte di stalattiti sono il bioma sotterraneo più diffuso e se ne trovano sotto quasi tutti i biomi.

| Bioma in superficie | Fascia alta (fino a Y 0) | Fascia media (Y 0 – -32) |
|---------------------|--------------------------|--------------------------|
| [Foresta temperata](/wiki/bioma-foresta-temperata), [taiga](/wiki/bioma-taiga) | 🌿 Grotte di muschio | Comuni |
| [Giungla](/wiki/bioma-giungla) | 🌿 Grotte di muschio | 🌿 Grotte di muschio |
| [Foresta incantata](/wiki/bioma-foresta-incantata) | 🌿 Grotte di muschio | 💎 Grotte di cristallo |
| [Foresta profonda](/wiki/bioma-foresta-profonda) | 🍄 Caverne dei funghi giganti | 🍄 Caverne dei funghi giganti |
| [Palude](/wiki/bioma-palude) | 💧 Grotte allagate | 🍄 Caverne dei funghi giganti |
| [Mangrovie](/wiki/bioma-mangrovie), [coste](/wiki/bioma-coste), [isole](/wiki/bioma-isole), fondali degli [oceani](/wiki/oceani), grandi [fiumi](/wiki/laghi-e-fiumi) | 💧 Grotte allagate | Comuni |
| [Isola dei funghi](/wiki/bioma-isole#isola-dei-funghi) | 🍄 Caverne dei funghi giganti | 🍄 Caverne dei funghi giganti |
| [Tundra](/wiki/bioma-tundra), [isole ghiacciate](/wiki/bioma-isole#isola-ghiacciata) | 🧊 Grotte di ghiaccio | 🧊 Grotte di ghiaccio, alternate a 💎 grotte di cristallo |
| [Montagne](/wiki/bioma-montagne) | 🪨 Grotte di stalattiti; 🧊 grotte di ghiaccio dentro le vette innevate | 🪨 Grotte di stalattiti |
| [Deserto](/wiki/bioma-deserto), [savana](/wiki/bioma-savana), [canyon rossi](/wiki/bioma-canyon-rossi) | 🪨 Grotte di stalattiti | Comuni |
| [Pianure](/wiki/bioma-pianure), [brughiera](/wiki/bioma-brughiera) | Comuni | Comuni |
| [Terre dei Morti](/wiki/bioma-terre-dei-morti) | Comuni, con più non-morti | Comuni, con più non-morti |
| [Lande d'Ombra](/wiki/bioma-lande-d-ombra) | Comuni, con vene di pietra d'ombra (`shadow_stone`) che accorciano la luce delle torce | Come la fascia alta |
| [Terre vulcaniche](/wiki/bioma-terre-vulcaniche) | 🌋 Caverne di lava | 🌋 Caverne di lava |

**Sotto Y -32** il bioma in superficie conta poco. L'Abisso e il Cuore del mondo sono fatti di caverne comuni immense e completamente buie, dove si nascondono anche le città perdute (vedi [Strutture](/wiki/strutture#strutture-sotterranee-e-dungeon)), alternate a caverne di lava sempre più fitte man mano che si scende, fino al mare di lava sotto Y -56. Solo sotto le terre vulcaniche la lava domina a ogni profondità.

Ai confini tra due biomi di superficie anche le grotte sottostanti si mescolano, come in superficie.

### 🪨 Grotte di stalattiti

Il bioma sotterraneo più diffuso: sale di roccia stillante dove l'acqua gocciola da migliaia di stalattiti e scioglie lentamente il calcare. Il rumore delle gocce copre i passi, i tuoi e quelli dei mostri.

| Voce | Valore |
|------|--------|
| **Dove** | Fascia alta e media sotto le [montagne](/wiki/bioma-montagne); fascia alta sotto [deserto](/wiki/bioma-deserto), [savana](/wiki/bioma-savana) e [canyon rossi](/wiki/bioma-canyon-rossi); chiazze più piccole sotto quasi tutti gli altri biomi |
| **Blocchi** | Roccia stillante (`dripstone`), stalattiti (`stalactite`) sui soffitti e stalagmiti (`stalagmite`) sui pavimenti, calcare (`limestone`) con vene di calcite (`calcite`), pozze d'acqua (`water`) con il fondo di argilla (`clay`) |
| **Luce** | Nessuna: buio totale. I mostri compaiono ovunque finché non si piazzano torce |
| **Risorse e reagenti** | Calcare per la calce; l'acqua che gocciola da una stalattite riempie lentamente un secchio messo sotto, senza mai finire, ed è preziosa sotto il deserto; vene di [Old Copper](/wiki/minerale-old-copper) e [Copper](/wiki/minerale-copper) più frequenti; citrini e tormaline escono più spesso del normale |
| **Creature** | Le creature dello strato: [ratti giganti](/wiki/animale-ratto-gigante), [scheletri](/wiki/mostro-scheletro) e [melme](/wiki/mostro-slime) in alto; [ragni giganti](/wiki/mostro-ragno-gigante), [gazer](/wiki/mostro-gazer) ed [elementali della terra](/wiki/mostro-elementale-della-terra) più in basso; [mongbat](/wiki/mostro-mongbat) appesi ai soffitti; sotto il deserto anche [scorpioni giganti](/wiki/mostro-scorpione-gigante). Gli elementali dei minerali compaiono quando si scava una vena del loro tipo |
| **Pericoli** | Una stalattite cade su chi passa sotto se si rompe il blocco che la regge, o se la colpisce una freccia o un incantesimo; cadere su una stalagmite raddoppia il danno da caduta |
| **Dungeon e strutture** | Miniere abbandonate e miniere infestate sotto le montagne, formicai sotto il deserto |

### 🌿 Grotte di muschio

Le grotte più vive del sottosuolo, ispirate alle grotte lussureggianti di Minecraft: il muschio copre pavimenti e pareti, le liane pendono dal soffitto e le radici degli alberi che crescono in superficie scendono nella grotta, coperte di funghi luminosi.

| Voce | Valore |
|------|--------|
| **Dove** | Fascia alta sotto [foresta temperata](/wiki/bioma-foresta-temperata), [taiga](/wiki/bioma-taiga) e [foresta incantata](/wiki/bioma-foresta-incantata); sotto la [giungla](/wiki/bioma-giungla) scendono fino a Y -32 |
| **Blocchi** | Muschio (`moss_block`) su pavimenti e pareti, liane (`vines`), felci (`fern`) e cespugli (`bush`), argilla (`clay`) e pozze d'acqua (`water`) limpide; radici che scendono dal soffitto (`hanging_roots`, sotto la terra con radici `rooted_dirt`) coperte di funghi luminosi (`glow_mushroom`); tappeti di muschio (`moss_carpet`), lichene luminoso (`glow_lichen`) sulle pareti, liane delle grotte (`cave_vines`) con bacche luminose, pietra muschiosa (`mossy_stone`); sotto la giungla anche fango (`mud`) |
| **Luce** | Penombra: i funghi e il lichene luminosi danno luce 7, le bacche delle liane 6, abbastanza per vedere ma non per fermare gli spawn. Tra una macchia di funghi e l'altra è buio |
| **Risorse e reagenti** | Muschio sanguigno (`blood_moss`) sulla roccia umida, liane per le corde, argilla, funghi; smeraldi più frequenti del normale. Il muschio attutisce i passi: è un buon posto per allenare [Stealth](/wiki/skill-stealth) |
| **Creature** | [Melme](/wiki/mostro-slime), [mongbat](/wiki/mostro-mongbat), [senza testa](/wiki/mostro-headless-one), [tentacoli di palude](/wiki/mostro-tentacolo-di-palude) nelle pozze e [corpser](/wiki/mostro-corpser) tra le radici; sotto la giungla anche [ragni giganti](/wiki/mostro-ragno-gigante), [terathan](/wiki/mostro-terathan) e [scorpioni giganti](/wiki/mostro-scorpione-gigante) |
| **Pericoli** | Sul muschio i ragni si muovono senza far rumore; le ragnatele (`cobweb`) nascoste tra le liane rallentano molto chi ci finisce dentro; il muschio copre buche e pozzi |
| **Dungeon e strutture** | Covi dei ragni sotto la giungla, con la Matriarca dei terathan |

### 💎 Grotte di cristallo

Sale di roccia chiara dove crescono grappoli di cristalli di mana, che riempiono la grotta di una luce azzurra e fredda. I tesori più grandi sono i **geodi**: bolle di roccia vuote, rivestite di cristalli all'interno.

| Voce | Valore |
|------|--------|
| **Dove** | Fascia media (Y 0 – -32) sotto la [foresta incantata](/wiki/bioma-foresta-incantata) e sotto la [tundra](/wiki/bioma-tundra), dove si alternano alle grotte di ghiaccio |
| **Blocchi** | Cristalli di mana (`mana_crystal`) in grappoli su pavimenti, pareti e soffitti; marmo (`marble`) sotto la foresta incantata; ghiaccio compatto (`packed_ice`) sotto la tundra. I geodi, larghi 8–12 blocchi, hanno un guscio di basalto (`basalt`), uno strato di marmo e l'interno di cristallo |
| **Luce** | I cristalli emettono luce 10: accanto ai grappoli non compare nessun mostro, ma già a pochi blocchi la luce scende sotto 8 e le sale più grandi restano in penombra o al buio |
| **Risorse e reagenti** | Cristalli di mana (serve Mining 60) per [Alchemy](/wiki/skill-alchemy), per gli incantesimi e per [Imbuing](/wiki/skill-imbuing); vene di [Rose](/wiki/minerale-rose) e [Silver](/wiki/minerale-silver) più frequenti; ametiste e zaffiri escono più spesso, e ogni tanto uno zaffiro stellato |
| **Creature** | Elementali di cristallo (vedi [Elementali](/wiki/mostri-elementali)), [gazer](/wiki/mostro-gazer) e [wisp](/wiki/mostro-wisp) attirati dalla luce; sotto la tundra anche [ragni del gelo](/wiki/mostro-ragno-del-gelo) e [serpenti del ghiaccio](/wiki/animale-serpente-del-ghiaccio) |
| **Pericoli** | Gli elementali di cristallo restano immobili tra i grappoli e sembrano cristalli come gli altri; sotto la tundra fa freddo come in superficie |
| **Dungeon e strutture** | Nessuno: il tesoro sono i geodi stessi |

### 🍄 Caverne dei funghi giganti

Caverne alte e umide dove i funghi crescono come alberi, con gambi bianchi e cappelli larghi che formano un bosco sotterraneo. L'aria è pesante di spore.

| Voce | Valore |
|------|--------|
| **Dove** | Fascia alta e media sotto la [foresta profonda](/wiki/bioma-foresta-profonda); fascia media sotto la [palude](/wiki/bioma-palude); sotto le rare [isole dei funghi](/wiki/bioma-isole#isola-dei-funghi) |
| **Blocchi** | Funghi giganti (`giant_mushroom_stem`, `giant_mushroom_cap`) alti fino a 10 blocchi, micelio (`mycelium`) sul pavimento, funghi marroni, rossi e luminosi (`brown_mushroom`, `red_mushroom`, `glow_mushroom`), funghi a mensola (`shelf_fungus`) e lichene luminoso (`glow_lichen`) sulle pareti, radici pendenti (`hanging_roots`), fango (`mud`); sotto la palude anche torba (`peat`) |
| **Luce** | Penombra verdastra dove crescono i funghi luminosi (luce 7, che non ferma gli spawn); buio altrove |
| **Risorse e reagenti** | Funghi in quantità per [Cooking](/wiki/skill-cooking) e per l'alchimia; i funghi giganti si abbattono come alberi, ma danno blocchi di gambo e di cappello, non legno; la belladonna (`nightshade_plant`) cresce anche al buio; vene di [Old Copper](/wiki/minerale-old-copper) e [Copper](/wiki/minerale-copper) più frequenti; ambra |
| **Creature** | [Melme](/wiki/mostro-slime) e, più in basso, melme acide; [troll](/wiki/mostro-troll), [ragni giganti](/wiki/mostro-ragno-gigante) e mongbat maggiori (vedi [Mongbat](/wiki/mostro-mongbat)); sotto la palude [tentacoli di palude](/wiki/mostro-tentacolo-di-palude) e [lizardman](/wiki/mostro-lizardman); raro l'[elementale del veleno](/wiki/mostro-elementale-del-veleno) |
| **Pericoli** | Colpire un cappello rosso libera una nube di spore che avvelena leggermente; il fango rallenta; alcuni funghi sono velenosi se mangiati crudi (vedi [Taste Identification](/wiki/skill-taste-identification)) |
| **Dungeon e strutture** | Covi orcheschi e covi dei ragni sotto la foresta profonda |

### 🧊 Grotte di ghiaccio

Gallerie scavate nel ghiaccio vivo, con pareti azzurre, laghi gelati e colonne di ghiaccio che scricchiolano. Il freddo non dà tregua.

| Voce | Valore |
|------|--------|
| **Dove** | Sotto la [tundra](/wiki/bioma-tundra) e le [isole ghiacciate](/wiki/bioma-isole#isola-ghiacciata), dalle prime grotte fino a Y -32 (nella fascia media si alternano alle grotte di cristallo); dentro le vette innevate delle [montagne](/wiki/bioma-montagne) |
| **Blocchi** | Ghiaccio (`ice`), ghiaccio compatto (`packed_ice`) e ghiaccio di ghiacciaio (`glacier_ice`) su pareti e pavimenti; ghiaccioli (`icicle`) sui soffitti e grappoli di cristalli di ghiaccio (`ice_crystal`, luce 4); neve (`snow`, `snow_layer`) e neve farinosa (`powder_snow`) vicino agli imbocchi; laghi d'acqua (`water`) coperti da una lastra di ghiaccio |
| **Luce** | Buio, come ogni grotta, con un'eccezione vicino alla superficie: di giorno la luce del sole filtra attraverso il ghiaccio (non attraverso il ghiaccio compatto) e lascia le gallerie in una penombra azzurra, che di notte torna buio (vedi [Giorno e notte](/wiki/giorno-e-notte)) |
| **Risorse e reagenti** | Ghiaccio compatto, che non si scioglie, per costruire ghiacciaie che conservano il cibo; vene di [Silver](/wiki/minerale-silver) e [Bronze](/wiki/minerale-bronze) più frequenti e più vicine alla superficie; diamanti; cristalli di ghiaccio dagli elementali |
| **Creature** | [Ragni del gelo](/wiki/mostro-ragno-del-gelo), [serpenti del ghiaccio](/wiki/animale-serpente-del-ghiaccio) e [serpenti giganti del ghiaccio](/wiki/animale-serpente-gigante-del-ghiaccio), [troll del gelo](/wiki/mostro-troll-del-gelo), [elementali del ghiaccio](/wiki/mostro-elementale-del-ghiaccio) e [della neve](/wiki/mostro-elementale-della-neve); raro l'Ice Fiend ([demone del ghiaccio](/wiki/mostro-demone-del-ghiaccio)); rarissimo il Wyrm bianco (White Wyrm, vedi [Draghi e rettili](/wiki/mostri-draghi-e-rettili)) |
| **Pericoli** | Danno da freddo senza vestiti pesanti; il ghiaccio fa scivolare; la lastra dei laghi si rompe sotto i blocchi pesanti e le cavalcature, e l'acqua sotto è gelida |
| **Dungeon e strutture** | Le Caverne di ghiaccio, con l'Ice Fiend, si aprono spesso dentro questo bioma: ci si arriva dai crepacci dei ghiacciai o dai sotterranei delle fortezze di ghiaccio |

### 🌋 Caverne di lava

Il cuore caldo del mondo: caverne di basalto attraversate da fiumi e cascate di lava, dove l'aria trema per il calore e la roccia brilla di rosso.

| Voce | Valore |
|------|--------|
| **Dove** | Laghi di lava isolati già nel sottosuolo profondo (Y -16 – -32); sotto Y -32, nell'Abisso e nel Cuore del mondo, sotto qualsiasi bioma e sempre più fitte man mano che si scende; sotto le [terre vulcaniche](/wiki/bioma-terre-vulcaniche) a ogni profondità, fino a pochi blocchi dalla superficie |
| **Blocchi** | Lava (`lava`) in laghi, fiumi e cascate; basalto (`basalt`), ossidiana (`obsidian`) dove la lava incontra l'acqua, pomice (`pumice`), terra di cenere (`ash_soil`) e cenere vulcanica (`volcanic_ash`), roccia magmatica (`magma_block`) intorno alla lava, zolfo (`sulfur_ore`); pareti di basalto nero (`black_basalt`) nell'Abisso e di roccia infernale (`hellstone`) nel Cuore del mondo |
| **Luce** | Luce 15 vicino alla lava, che illumina le caverne meglio di qualsiasi torcia. Le creature di fuoco però fanno eccezione e compaiono anche alla luce della lava |
| **Risorse e reagenti** | Zolfo e cenere sulfurea (reagente), ossidiana, pomice; [Blood Rock](/wiki/minerale-blood-rock) vicino alla lava, [Black Rock](/wiki/minerale-black-rock) nell'Abisso, [Demonic](/wiki/minerale-demonic) nel Cuore del mondo; rubini più frequenti |
| **Creature** | [Lucertole di lava](/wiki/animale-lucertola-di-lava), [elementali del fuoco](/wiki/mostro-elementale-del-fuoco), [imp](/wiki/mostro-imp), [segugi infernali](/wiki/mostro-segugio-infernale), coleotteri di fuoco (Fire Beetle, vedi [Insetti e aracnidi](/wiki/mostri-insetti-e-aracnidi)) e [drake](/wiki/mostro-drake); nell'Abisso Daemon ([demoni](/wiki/mostro-demone)); [draghi](/wiki/mostro-drago) nei nidi, [Balron](/wiki/mostro-balron) nei templi demoniaci, il [Wyrm antico](/wiki/mostro-wyrm-antico) nel Cuore del mondo |
| **Pericoli** | Chi muore nella lava perde il corpo e tutto ciò che porta (vedi [Morte e fantasmi](/wiki/morte-e-fantasmi)); il calore ferisce chi non ha resistenza al fuoco; scavando si può aprire una sacca di lava; sotto Y -56 ogni vuoto è pieno di lava |
| **Dungeon e strutture** | Nidi di draghi, templi demoniaci, la tana del Wyrm antico |

### 💧 Grotte allagate

Gallerie e caverne in cui l'acqua ha preso il posto dell'aria: fiumi sotterranei, laghi neri e cunicoli completamente sommersi, che a volte sbucano in mare.

| Voce | Valore |
|------|--------|
| **Dove** | Fascia alta, dal livello del mare (Y 63) fino a Y 0, sotto [coste](/wiki/bioma-coste), [mangrovie](/wiki/bioma-mangrovie), [isole](/wiki/bioma-isole), [paludi](/wiki/bioma-palude) e fondali degli [oceani](/wiki/oceani); lungo i grandi [fiumi](/wiki/laghi-e-fiumi) |
| **Blocchi** | Acqua (`water`) che riempie gallerie intere, argilla (`clay`), sabbia (`sand`), ghiaia (`gravel`); fango (`mud`) sotto paludi e mangrovie; lichene luminoso (`glow_lichen`) sulle pareti sopra l'acqua; nelle grotte marine alghe (`kelp`), posidonia (`seagrass`) e ostriche (`pearl_oyster`) |
| **Luce** | Buio, e sott'acqua ancora di più |
| **Risorse e reagenti** | Argilla per mattoni e vasi; ostriche che danno la perla nera (reagente); pesci ciechi per [Fishing](/wiki/skill-fishing); [Silver](/wiki/minerale-silver) leggermente più frequente nelle grotte marine |
| **Creature** | Pesci ciechi, [tentacoli di palude](/wiki/mostro-tentacolo-di-palude), [melme](/wiki/mostro-slime), [lizardman](/wiki/mostro-lizardman) e [troll](/wiki/mostro-troll) nelle grotte umide; sotto le paludi [alligatori](/wiki/animale-alligatore); raro l'[elementale dell'acqua](/wiki/mostro-elementale-dell-acqua) nei laghi sotterranei più profondi |
| **Pericoli** | Sott'acqua l'aria dura circa 30 secondi (vedi [Oceani](/wiki/oceani)); le correnti trascinano; con un'armatura di piastre si va a fondo; chi muore in una galleria allagata lascia il corpo sul fondo |
| **Dungeon e strutture** | Grotte dei contrabbandieri, con l'ingresso che emerge con la bassa marea (vedi [Strutture](/wiki/strutture)) |

---

## 🗝️ Dungeon generati

I dungeon sono strutture costruite, generate insieme al terreno: corridoi in pietra lavorata, sale, porte chiuse a chiave, trappole, forzieri e un boss finale. Il livello del dungeon dipende dalla sua profondità e dal bioma.

| Dungeon | Profondità | Bioma | Abitanti | Boss |
|---------|-----------|-------|----------|------|
| **Tana dei ratman** | Superficiale | Ovunque, vicino alle città | Ratti giganti, ratman | Re dei ratman |
| **Covo orchesco** | Superficiale – medio | Foresta profonda, montagne | Orchi, orc captain | Orc Lord |
| **Miniera infestata** | Medio | Montagne | Elementali dei minerali, gargoyle selvaggi | Elementale di Valorite |
| **Cripta** | Medio – profondo | Terre dei Morti, deserto | Scheletri, mummie, lich | Lich Lord |
| **Covo dei ragni** | Medio | Giungla, foresta profonda | Ragni, terathan | Matriarca dei terathan |
| **Formicaio** | Superficiale – medio | Deserto, pianure | Formiche giganti (Solen) | Regina dei Solen |
| **Caverne di ghiaccio** | Medio – profondo | Tundra | Frost troll, elementali del ghiaccio | Ice Fiend |
| **Nido di draghi** | Profondo | Montagne, terre vulcaniche | Drake, wyvern | Drago |
| **Tempio demoniaco** | Abisso | Terre vulcaniche, Lande d'Ombra | Imp, demoni | Balron |
| **Rovine sommerse** | Fondale oceanico | [Oceani](/wiki/oceani) | Serpenti, elementali d'acqua | Kraken |

- I forzieri dei dungeon sono spesso chiusi e protetti da trappole: servono Lockpicking e Detect Hidden (vedi [Ladro](/wiki/classe-ladro)).
- I boss tornano dopo un certo tempo (vedi [Spawn delle creature](/wiki/spawn-creature)).
- I muri dei dungeon sono **molto più resistenti** della roccia normale, ma si possono scavare: aprirsi un ingresso laterale è un'arte.
- Le altre strutture sotterranee, come miniere abbandonate, templi ofidiani, roccaforti antiche e città perdute, sono descritte in [Strutture](/wiki/strutture#strutture-sotterranee-e-dungeon).

---

## 🦇 Creature del buio

Sotto terra la luce naturale è zero: le creature ostili compaiono in qualsiasi blocco buio, giorno o notte.

| Strato | Creature tipiche |
|--------|------------------|
| Sottosuolo superficiale | Ratti giganti, pipistrelli, scheletri, zombie, slime |
| Strato medio | Ragni giganti, ratman, gazer, elementali di terra e dei minerali, troll |
| Sottosuolo profondo | Ogre lord, ettin, lich, gargoyle selvaggi, lava lizard, elementali del fuoco |
| Abisso | Daemon, elder gazer, Lich Lord, drake, dread spider |
| Cuore del mondo | Balron, Ancient Wyrm, Shadow Wyrm, demoni arcani |

Le liste complete sono in [Mostri](/wiki/mostri).

Ogni [bioma sotterraneo](#biomi-sotterranei) aggiunge le sue creature a quelle dello strato: il quadro completo, bioma per bioma, è in [Creature per bioma](/wiki/creature-per-bioma). In superficie, invece, le creature cambiano con l'ora e con la luna (vedi [Giorno e notte](/wiki/giorno-e-notte)).

---

## 💡 Consigli per i minatori

- Porta **sempre torce** in abbondanza e piazzale lungo il percorso: segnano la via del ritorno e impediscono gli spawn.
- Scava a **scalinata** e mai in verticale sotto i tuoi piedi: potresti cadere in una caverna o in un lago di lava.
- Lascia il carico pesante in una **cassa** a metà strada o porta una bestia da soma.
- Per i minerali dell'Abisso vai in gruppo: un minatore solo e carico di Valorite è il bersaglio preferito dei [player killer](/wiki/player-killer-e-redenzione).
- Anche le grotte che brillano hanno bisogno di torce: la luce dei funghi luminosi (7) basta per vedere ma non ferma gli spawn, e quella dei cristalli di mana (10) li ferma solo a un paio di blocchi di distanza.
- Sotto Y -56 ogni vuoto è pieno di lava: scava solo in orizzontale e tieni pronti un secchio d'acqua e qualche blocco per tappare le colate.

---

*Vedi anche: [Minerali](/wiki/minerali) | [Il Mondo](/wiki/mondo) | [Classe Minatore Combattente](/wiki/classe-minatore-combattente) | [Blocchi](/wiki/blocchi) | [Biomi](/wiki/biomi) | [Laghi e fiumi](/wiki/laghi-e-fiumi) | [Giorno e notte](/wiki/giorno-e-notte)*
