---
title: Blocchi da costruzione
slug: blocchi-costruzione
category: Mondo
visibility: Pubblica
---
# 🏠 Blocchi da costruzione
*Muri, tetti, porte, mobili, luci e contenitori: tutto ciò che si costruisce con le proprie mani*

---

## 📋 Indice

- [Panoramica](#panoramica)
- [Come funzionano i blocchi costruiti](#come-funzionano-i-blocchi-costruiti)
- [Chi li crea](#chi-li-crea)
- [Pietra lavorata](#pietra-lavorata)
- [Mattoni, argilla e ghiaccio](#mattoni-argilla-e-ghiaccio)
- [Legno](#legno)
- [Tetti](#tetti)
- [Vetro e stoffa](#vetro-e-stoffa)
- [Porte, finestre e passaggi](#porte-finestre-e-passaggi)
- [Luci](#luci)
- [Mobili](#mobili)
- [Decorazioni](#decorazioni)
- [Stazioni di lavoro](#stazioni-di-lavoro)
- [Contenitori](#contenitori)
- [Strade, campi e miniere](#strade-campi-e-miniere)
- [Navi e porti](#navi-e-porti)
- [Usati nelle strutture](#usati-nelle-strutture)
- [Note di sviluppo](#note-di-sviluppo)
- [FAQ](#faq)

---

## 📜 Panoramica

Questa pagina è il catalogo dei **blocchi costruiti**: quelli che nascono dalla materia prima dei [blocchi naturali](/wiki/blocchi) grazie alle skill di crafting. Mattoni di marmo, assi di quercia, tetti di paglia, porte, finestre, letti, sedie, tavoli, torce, forge, forzieri e botti.

Sono gli stessi blocchi con cui il generatore del mondo costruisce le [strutture](/wiki/strutture): la casa di un villaggio, il tempio di marmo, la cripta, la nave arenata sono fatti di questi blocchi, e un giocatore può costruire le stesse cose con gli stessi pezzi. Per questo il catalogo viene **prima** delle strutture: senza un muro di marmo non si può progettare un tempio di marmo.

> 💡 Come i blocchi naturali, ogni blocco ha un **id** leggibile `soulslands:nome`, per esempio `soulslands:marble_bricks` o `soulslands:wooden_chair`. In questa pagina gli id sono scritti senza il prefisso.

---

## ⚙️ Come funzionano i blocchi costruiti

Il mondo è fatto di celle cubiche di un metro. Anche gli oggetti che non sono cubi, come una sedia, una torcia o un letto, sono **blocchi**: occupano una cella e hanno un **modello** proprio al posto del cubo, come i blocchi non pieni di Minecraft.

| Proprietà | Significato |
|-----------|-------------|
| **Forma** | Cubo pieno, oppure un modello: scala, lastra (mezzo blocco), muretto, staccionata, pannello, mobile, torcia |
| **Orientamento** | Molti blocchi si girano verso chi li piazza: scale, porte, sedie, letti, forzieri, torce a muro. Scale e lastre possono stare anche capovolte, in alto nella cella |
| **Celle** | Quasi tutti occupano una cella. Alcuni ne occupano di più e si piazzano in un colpo solo: porte (1 × 2 in altezza), letti (2), letto a due piazze (2 × 2), tavolo lungo (2), guardaroba (2 in altezza) |
| **Solido** | Si urta e ci si sta sopra. Torce, tappeti, stendardi, quadri, corde e scale a pioli non sono solidi: ci si passa attraverso o ci si arrampica |
| **Luce** | Torce, lanterne, bracieri e camini emettono luce da 0 a 15, come in [Giorno e notte](/wiki/giorno-e-notte) |
| **Legno e colore** | I mobili non hanno un id per ogni legno: il [legno](/wiki/legni) è una proprietà del blocco piazzato, come l'orientamento (una `wooden_chair` di tasso è una sedia di tasso). Allo stesso modo tappeti, stendardi, stoffe e vetri colorati hanno un **colore**, che si dà con le tinture |
| **Contenitore** | Forzieri, casse, botti, armadi e librerie **contengono oggetti**. Il contenuto si salva nel mondo insieme al blocco (vedi [Contenitori](#contenitori)) |

I **blocchi strutturali** (assi, scale, porte, staccionate di legno) hanno invece un id per ogni legno, come in Minecraft: `oak_planks`, `oak_stairs`, `oak_door`. Così le assi delle strutture del mondo restano gli stessi blocchi che usa il giocatore.

---

## 🛠️ Chi li crea

Chiunque può **piazzare** e **rompere** un blocco comune. Per **crearlo** serve la skill giusta, con lo strumento e la stazione indicati in [Attrezzi](/wiki/attrezzi).

| Famiglia | Skill | Materia prima | Dove si lavora |
|----------|-------|---------------|----------------|
| Pietra lavorata, tegole di ardesia, statue, colonne, sarcofagi | [Mining](/wiki/skill-mining) | Pietrisco e pietra | Banco da scalpellino (`station_stonecutter`) |
| Mattoni, terracotta, coppi, intonaco | [Architecture](/wiki/skill-architecture) | Argilla, argilla rossa, calcare | Fornace (`station_kiln`) |
| Assi, scale e porte di legno, mobili, casse, botti | [Carpentry](/wiki/skill-carpentry) | Tronchi e assi | Banco da lavoro (`station_workbench`) |
| Porte e grate di ferro, saracinesche, catene, forzieri di metallo, ancore | [Blacksmithy](/wiki/skill-blacksmithy) | Lingotti | Forgia e incudine (`station_forge`, `station_anvil`) |
| Luci in metallo, vetro, meccanismi, serrature e trappole | [Tinkering](/wiki/skill-tinkering) | Lingotti, sabbia, ingranaggi | Fornace per il vetro, nessuna stazione per il resto |
| Tappeti, stendardi, arazzi, tende, vele, corde, stoffe | [Tailoring](/wiki/skill-tailoring) | Stoffa, pelli, lino | Kit da sarto; stoffa al filatoio e al telaio |
| Fuoco da campo | [Camping](/wiki/skill-camping) | Legna da ardere | Ovunque |

> 🧱 Le **strutture rinforzate** del [Sistema di costruzioni](/wiki/sistema-costruzioni) hanno lo stesso aspetto di questi blocchi, ma sono elementi modulari con punti vita, craftati con Architecture e piazzabili solo nel territorio di una gilda. I blocchi di questa pagina invece sono **blocchi comuni**: si piazzano ovunque e si rompono con l'attrezzo giusto.

---

## 🪨 Pietra lavorata

La pietra grezza e il suo pietrisco sono nei [blocchi naturali](/wiki/blocchi#rocce-degli-strati); al banco da scalpellino si lavorano in pietra **levigata**, **mattoni** e **colonne**. Più la roccia è profonda, più è dura da rompere anche lavorata.

| Materiale | Grezza | Pietrisco | Levigata | Mattoni | Colonna | Decorative | Dove si vede |
|-----------|--------|-----------|----------|---------|---------|------------|--------------|
| Pietra | `stone` | `cobblestone`, `mossy_cobblestone` | `polished_stone` | `stone_bricks`, `mossy_stone_bricks` | `stone_pillar` | `cracked_stone_bricks`, `chiseled_stone_bricks` | Mura delle città, castelli, dungeon, rovine |
| Pietra scura | `dark_stone` | `dark_cobblestone` | `polished_dark_stone` | `dark_stone_bricks` | `dark_stone_pillar` | `cracked_dark_stone_bricks` | Dungeon e cripte |
| Ardesia profonda | `deepslate` | `cobbled_deepslate` | `polished_deepslate` | `deepslate_bricks` | `deepslate_pillar` | `cracked_deepslate_bricks` | Roccaforti antiche, dungeon profondi |
| Basalto nero | `black_basalt` | `cobbled_basalt` | `polished_black_basalt` | `black_basalt_bricks` | `black_basalt_pillar` | `cracked_black_basalt_bricks` | Città perduta dell'Abisso |
| Roccia infernale | `hellstone` | `cobbled_hellstone` | `polished_hellstone` | `hellstone_bricks` | `hellstone_pillar` | — | Tempio demoniaco, tana del wyrm antico |
| Granito | `granite` | — | `polished_granite` | `granite_bricks` | `granite_pillar` | — | Case di montagna, rocche dei nani, ponti |
| Marmo | `marble` | — | `polished_marble` | `marble_bricks` | `marble_pillar` | `chiseled_marble` | Templi, santuari, palazzi, fonti della luna |
| Calcare | `limestone` | — | `polished_limestone` | `limestone_bricks` | `limestone_pillar` | — | Città della costa, fari |
| Arenaria | `sandstone` | — | `polished_sandstone` | `sandstone_bricks` | `sandstone_pillar` | `chiseled_sandstone`, `cracked_sandstone_bricks` | Villaggi del deserto, piramidi, tombe |
| Arenaria rossa | `red_sandstone` | — | `polished_red_sandstone` | `red_sandstone_bricks` | `red_sandstone_pillar` | `chiseled_red_sandstone` | Abitazioni nella roccia dei canyon |
| Ardesia | `slate` | — | `polished_slate` | `slate_bricks` | `slate_pillar` | — | Case della brughiera e della montagna |
| Basalto | `basalt` | — | `polished_basalt` | `basalt_bricks` | `basalt_pillar` | — | Forge abbandonate, isole vulcaniche |
| Ossidiana | `obsidian` | — | `polished_obsidian` | `obsidian_bricks` | `obsidian_pillar` | — | Portali demoniaci |
| Pietra d'ombra | `shadow_stone` | — | `polished_shadow_stone` | `shadow_stone_bricks` | `shadow_stone_pillar` | — | Portali e fortezze delle Lande d'Ombra |
| Pietra corallina | `coral_stone` | — | — | `coral_stone_bricks` | `coral_stone_pillar` | — | Rovine e tempio sommersi |

- **Pietrisco**: è ciò che lascia la roccia rotta; si piazza così com'è. Pietrisco e mattoni **muschiosi** si fanno unendo pietrisco o mattoni a un `moss_block`, come in Minecraft.
- **Colonna**: un blocco pieno con le venature in verticale; si può girare in orizzontale come una trave.
- **Decorative**: mattoni incrinati (rovine), scolpiti (templi, ingressi). Esistono solo come blocco intero.
- Il basalto nero lascia `cobbled_basalt`, il basalto comune non lascia pietrisco: si lavora direttamente.

### Forme: scale, lastre e muretti

Ogni blocco che ha delle forme ne ha tre: **scala**, **lastra** (mezzo blocco, sotto o sopra) e **muretto** (muro sottile che si unisce ai vicini, alto come una staccionata). L'id segue sempre la stessa regola:

| Blocco | Scala | Lastra | Muretto |
|--------|-------|--------|---------|
| `cobblestone` | `cobblestone_stairs` | `cobblestone_slab` | `cobblestone_wall` |
| `polished_granite` | `polished_granite_stairs` | `polished_granite_slab` | `polished_granite_wall` |
| `marble_bricks` | `marble_brick_stairs` | `marble_brick_slab` | `marble_brick_wall` |

I nomi in `_bricks` perdono la *s* (`marble_bricks` → `marble_brick_stairs`), come in Minecraft. Hanno le forme:

| Materiale | Blocchi con scala, lastra e muretto |
|-----------|-------------------------------------|
| Pietra | `stone`, `cobblestone`, `mossy_cobblestone`, `polished_stone`, `stone_bricks`, `mossy_stone_bricks` |
| Pietra scura | `dark_cobblestone`, `polished_dark_stone`, `dark_stone_bricks` |
| Ardesia profonda | `cobbled_deepslate`, `polished_deepslate`, `deepslate_bricks` |
| Basalto nero | `cobbled_basalt`, `polished_black_basalt`, `black_basalt_bricks` |
| Roccia infernale | `cobbled_hellstone`, `polished_hellstone`, `hellstone_bricks` |
| Granito, marmo, calcare, arenaria, arenaria rossa, ardesia, basalto | La grezza, la levigata e i mattoni (es. `granite`, `polished_granite`, `granite_bricks`) |
| Ossidiana, pietra d'ombra | La levigata e i mattoni |
| Pietra corallina | `coral_stone_bricks` |
| Argilla e ghiaccio | `bricks`, `mud_bricks`, `terracotta`, `ice_bricks` (vedi sotto) |

---

## 🧱 Mattoni, argilla e ghiaccio

| Id | Nome | Da cosa | Skill | Forme | Note |
|----|------|---------|-------|-------|------|
| `bricks` | Mattoni | `clay` cotta nella fornace | Architecture | `brick_stairs`, `brick_slab`, `brick_wall` | Rossi, il muro classico delle città |
| `terracotta` | Terracotta | `red_clay` cotta | Architecture | `terracotta_stairs`, `terracotta_slab`, `terracotta_wall` | Arancione; si tinge con le tinture. Villaggi della savana |
| `mud_bricks` | Mattoni crudi | `mud` seccato al sole | Nessuna | `mud_brick_stairs`, `mud_brick_slab`, `mud_brick_wall` | Villaggi della savana e delle paludi, oasi |
| `plaster` | Intonaco | Calce di `limestone` e sabbia | Architecture | — | Muro bianco liscio, tra le travi delle case a graticcio |
| `ice_bricks` | Mattoni di ghiaccio | `packed_ice` | Mining | `ice_brick_stairs`, `ice_brick_slab`, `ice_brick_wall` | Non si sciolgono; fortezze di ghiaccio |
| `snow_bricks` | Mattoni di neve | `snow` | Nessuna | — | Rifugi di neve; si sciolgono vicino al fuoco |

---

## 🌳 Legno

Le assi si ricavano dai tronchi al banco da lavoro con [Carpentry](/wiki/skill-carpentry). Come nei [blocchi naturali](/wiki/blocchi#legno), le assi dipendono dal **tipo di legno**, non dalla specie dell'albero: betulla, abete e palma danno tutte `plain_planks`. Le assi si raccolgono anche a mani nude, come i tronchi (l'ascia fa solo più in fretta). Ogni legno ha la sua serie completa:

| Legno | Assi | Scala | Lastra | Staccionata | Cancelletto | Porta | Botola | Trave |
|-------|------|-------|--------|-------------|-------------|-------|--------|-------|
| [Comune](/wiki/legno-regular) | `plain_planks` | `plain_stairs` | `plain_slab` | `plain_fence` | `plain_fence_gate` | `plain_door` | `plain_trapdoor` | `plain_beam` |
| [Quercia](/wiki/legno-oak) | `oak_planks` | `oak_stairs` | `oak_slab` | `oak_fence` | `oak_fence_gate` | `oak_door` | `oak_trapdoor` | `oak_beam` |
| [Frassino](/wiki/legno-ash) | `ash_planks` | `ash_stairs` | `ash_slab` | `ash_fence` | `ash_fence_gate` | `ash_door` | `ash_trapdoor` | `ash_beam` |
| [Tasso](/wiki/legno-yew) | `yew_planks` | `yew_stairs` | `yew_slab` | `yew_fence` | `yew_fence_gate` | `yew_door` | `yew_trapdoor` | `yew_beam` |
| [Cuoredilegno](/wiki/legno-heartwood) | `heartwood_planks` | `heartwood_stairs` | `heartwood_slab` | `heartwood_fence` | `heartwood_fence_gate` | `heartwood_door` | `heartwood_trapdoor` | `heartwood_beam` |
| [Legno sanguigno](/wiki/legno-bloodwood) | `bloodwood_planks` | `bloodwood_stairs` | `bloodwood_slab` | `bloodwood_fence` | `bloodwood_fence_gate` | `bloodwood_door` | `bloodwood_trapdoor` | `bloodwood_beam` |
| [Legno di brina](/wiki/legno-frostwood) | `frostwood_planks` | `frostwood_stairs` | `frostwood_slab` | `frostwood_fence` | `frostwood_fence_gate` | `frostwood_door` | `frostwood_trapdoor` | `frostwood_beam` |

- **Trave**: legno squadrato con le venature lungo l'asse, verticale o orizzontale. È lo scheletro delle case a graticcio, con l'intonaco tra una trave e l'altra.
- I **tronchi** (`oak_log`, `spruce_log`, `palm_log`...) si piazzano anche interi: le capanne di tronchi della taiga sono fatte così.
- Per lavorare un legno pregiato serve Carpentry allo stesso livello del suo [Lumberjacking](/wiki/legni#tabella-comparativa): Quercia 65.0, Frassino 80.0, Tasso 95.0, i tre rari 100.0.
- Porte e botole si aprono a mano e si chiudono a chiave con una serratura (vedi [Porte, finestre e passaggi](#porte-finestre-e-passaggi)).

---

## 🏚️ Tetti

I tetti si fanno con le **scale** e le **lastre** del materiale scelto. Questi materiali esistono solo per i tetti:

| Materiale | Blocco | Scala | Lastra | Skill | Dove si vede |
|-----------|--------|-------|--------|-------|--------------|
| Paglia | `thatch` | `thatch_stairs` | `thatch_slab` | Carpentry (livello basso), dalla paglia del grano | Pianure, villaggi, fattorie. Brucia! |
| Coppi di argilla | `clay_roof_tiles` | `clay_roof_tile_stairs` | `clay_roof_tile_slab` | Architecture, alla fornace | Città, savana, coste calde |
| Tegole di ardesia | `slate_roof_tiles` | `slate_roof_tile_stairs` | `slate_roof_tile_slab` | Mining, al banco da scalpellino | Montagna, brughiera, città del nord |
| Scandole di legno | `wooden_shingles` | `wooden_shingle_stairs` | `wooden_shingle_slab` | Carpentry | Taiga, capanne, campi dei taglialegna |

Anche le scale e le lastre di legno e di pietra vanno bene per i tetti.

---

## 🪟 Vetro e stoffa

Il vetro si fonde dalla sabbia alla fornace con [Tinkering](/wiki/skill-tinkering). Il **pannello** è una lastra sottile in verticale che si unisce ai vicini, come in Minecraft.

**Deciso da Aruto (26/10/2026):** il vetro rotto lascia **schegge di vetro** (`glass_shard`) invece di tornare com'era: ogni blocco di vetro e ogni pannello, chiari, ambrati, scuri o colorati. Un blocco ne dà da **1 a 3**, un pannello da **0 a 1** (una scheggia una volta su due; le quantità sono un dettaglio del PM). Le schegge serviranno come risorsa per i mestieri futuri (fase F7).

| Id | Nome | Da cosa | Note |
|----|------|---------|------|
| `glass` | Vetro | `sand` | Trasparente |
| `glass_pane` | Pannello di vetro | `glass` | Le finestre di case e botteghe |
| `amber_glass` | Vetro ambrato | `red_sand` | Luce calda; canyon e savana |
| `amber_glass_pane` | Pannello di vetro ambrato | `amber_glass` | |
| `dark_glass` | Vetro scuro | `black_sand` | Si vede fuori ma non dentro |
| `dark_glass_pane` | Pannello di vetro scuro | `dark_glass` | |
| `stained_glass` | Vetro colorato | `glass` e una tintura | Ha un **colore**; le vetrate di templi e abbazie |
| `stained_glass_pane` | Vetrata | `stained_glass` | |

I blocchi di stoffa si fanno con [Tailoring](/wiki/skill-tailoring):

| Id | Nome | Note |
|----|------|------|
| `cloth_block` | Blocco di stoffa | Come la lana di Minecraft; ha un **colore**. Attutisce le cadute e i rumori |
| `canvas` | Tela | Pareti e tetti delle tende, tendoni del mercato |
| `hide_canvas` | Pelle tesa | Tende dei nomadi e dei selvaggi, fatte di pelli |

---

## 🚪 Porte, finestre e passaggi

Porte, botole, staccionate e cancelletti di legno sono nella tabella del [legno](#legno). Qui il resto:

| Id | Nome | Skill | Note |
|----|------|-------|------|
| `iron_door` | Porta di ferro | Blacksmithy | Non si sfonda a calci: si apre a mano, con una leva o con la chiave |
| `iron_trapdoor` | Botola di ferro | Blacksmithy | Cantine, prigioni, camere del tesoro |
| `iron_bars` | Sbarre di ferro | Blacksmithy | Si uniscono ai vicini; finestre di prigioni e celle |
| `iron_grate` | Grata a pavimento | Blacksmithy | Fogne delle città, ingressi delle tane dei ratman; ci si cammina sopra |
| `iron_gate` | Cancello di ferro | Blacksmithy | Due ante, 2 × 2 celle; mura e cimiteri |
| `portcullis` | Saracinesca | Blacksmithy (la grata) e Tinkering (l'argano) | Si alza e si abbassa con una leva; ingressi di castelli e fortezze |
| `chain` | Catena | Blacksmithy | Si appende al soffitto; regge lanterne e lampadari |
| `secret_stone_door` | Porta segreta di pietra | Tinkering e Mining | Sembra un muro di `stone_bricks`; si scopre con [Detect Hidden](/wiki/skill-detect-hidden) |
| `window_shutters` | Imposte | Carpentry | Ante di legno che chiudono una finestra |
| `ladder` | Scala a pioli | Carpentry | Ci si arrampica |
| `rope_ladder` | Scala di corda | Tailoring | Si srotola verso il basso; pozzi, navi, palafitte |
| `scaffolding` | Impalcatura | Carpentry | Si sale dentro e si scende accucciati; cantieri, miniere |
| `lever` | Leva | Tinkering | Apre porte, saracinesche e botole collegate |
| `pressure_plate` | Piastra a pressione | Tinkering | Si attiva camminandoci sopra |
| `tripwire_hook` | Gancio del filo | Tinkering | Tende il filo d'inciampo tra due ganci |
| `tripwire` | Filo d'inciampo | Tinkering | Quasi invisibile; fa scattare trappole e allarmi |
| `dart_trap` | Trappola a dardi | Tinkering | Nascosta in un muro, spara dardi avvelenati; tempietti della giungla |
| `spike_trap` | Trappola a punte | Tinkering | Punte che escono dal pavimento; dungeon e piramidi |

> 🔐 Ogni porta, botola e contenitore può avere una **serratura** fatta con Tinkering, con la sua chiave. Le serrature si scassinano con [Lockpicking](/wiki/skill-lockpicking), le trappole si trovano con Detect Hidden e si disinnescano con [Remove Trap](/wiki/skill-remove-trap).

---

## 🕯️ Luci

| Id | Nome | Luce | Skill | Note |
|----|------|------|-------|------|
| `torch` | Torcia | 14 | Nessuna (bastoncino e carbone) | Si pianta a terra |
| `wall_torch` | Torcia a muro | 14 | Nessuna | La stessa torcia piazzata su una parete |
| `lantern` | Lanterna | 15 | Tinkering | A terra o appesa a una catena; non si spegne con la pioggia |
| `street_lamp` | Lampione | 15 | Tinkering | Palo con lanterna; strade e piazze delle città |
| `candle` | Candela | 4 | Tinkering (sego o cera) | Fino a 4 candele nella stessa cella, ognuna aggiunge luce: la luce vale 4, 8, 12 e 15 con 1, 2, 3 e 4 candele (**Deciso da Aruto (26/10/2026)**). Si aggiunge una candela piazzandola sulla cella della candela |
| `candelabrum` | Candelabro | 12 | Tinkering | Da tavolo o da terra; d'argento nelle abbazie |
| `chandelier` | Lampadario | 15 | Tinkering | Appeso al soffitto; sale delle taverne e dei castelli |
| `brazier` | Braciere | 15 | Blacksmithy | Brucia carbone o legna; templi e ingressi |
| `campfire` | Fuoco da campo | 15 | [Camping](/wiki/skill-camping) | Per cucinare e per l'accampamento sicuro; a volte è il **cuore** di un accampamento nemico |
| `fireplace` | Camino | 13 | Mining | Di pietra, scalda e cucina come un fuoco; case e locande |
| `mana_crystal_lamp` | Lampada di cristallo | 13 | Tinkering | Un frammento di `mana_crystal` in una gabbia d'argento: luce azzurra senza fuoco, che non si spegne mai |
| `lighthouse_beacon` | Lanterna del faro | 15 | Tinkering | Visibile da lontanissimo, brucia olio; si spegne nei fari abbandonati |

> 🌑 Nelle [Lande d'Ombra](/wiki/bioma-lande-d-ombra) la terra e la pietra d'ombra assorbono la luce: tutte le luci illuminano meno. La lampada di cristallo resiste meglio.

---

## 🪑 Mobili

I mobili si fanno con [Carpentry](/wiki/skill-carpentry), come in Ultima Online, nel legno che si sceglie dal menu. I letti chiedono anche stoffa ([Tailoring](/wiki/skill-tailoring)). I mobili che contengono oggetti (armadi, cassettoni, librerie, scaffali, scrivanie) sono tra i [contenitori](#contenitori).

### Letti

| Id | Nome | Celle | Note |
|----|------|-------|------|
| `bedroll` | Giaciglio | 1 × 2 | Tailoring; si arrotola e si porta nello zaino. Accampamenti |
| `straw_bed` | Pagliericcio | 1 × 2 | Carpentry, paglia; fienili, prigioni, accampamenti |
| `bed` | Letto | 1 × 2 | Carpentry e stoffa; case e locande |
| `large_bed` | Letto a due piazze | 2 × 2 | Carpentry e stoffa; case ricche, castelli |
| `bunk_bed` | Letto a castello | 1 × 2, alto 2 | Caserme delle guardie, navi, campi dei taglialegna |

### Sedute

| Id | Nome | Note |
|----|------|------|
| `stool` | Sgabello | Il primo mobile del carpentiere |
| `foot_stool` | Poggiapiedi | |
| `wooden_chair` | Sedia di legno | |
| `straw_chair` | Sedia impagliata | Fattorie, villaggi |
| `cushioned_chair` | Sedia imbottita | Con cuscino di stoffa |
| `fancy_chair` | Sedia elegante | Intagliata, con cuscino |
| `wooden_bench` | Panca | Taverne, chiese, giardini |
| `wooden_throne` | Trono di legno | Capi villaggio, sale dei capitani |
| `royal_throne` | Trono reale | Dorato e imbottito; castelli e palazzi |

### Tavoli e banconi

| Id | Nome | Celle | Note |
|----|------|-------|------|
| `small_table` | Tavolino | 1 | |
| `round_table` | Tavolo rotondo | 1 | Taverne |
| `low_table` | Tavolo basso | 1 | Davanti al camino |
| `long_table` | Tavolo lungo | 2 | Sale da pranzo, refettori delle abbazie |
| `counter` | Bancone | 1 | Botteghe, taverne, banche; si unirà ai vicini più avanti: nella prima versione delle strutture (fase F4b) i banconi non si uniscono ancora (**Deciso da Aruto (26/10/2026)**) |

### Addestramento

| Id | Nome | Skill | Note |
|----|------|-------|------|
| `training_dummy` | Manichino da addestramento | Carpentry | Si colpisce per allenare le skill di combattimento ai livelli bassi |
| `archery_butte` | Bersaglio da tiro | Carpentry | Per [Archery](/wiki/skill-archery) ai livelli bassi |
| `weapon_rack` | Rastrelliera per armi | Carpentry | Armerie, caserme; mostra fino a 4 armi |
| `armor_stand` | Manichino per armature | Carpentry | Mostra un'armatura completa |

---

## 🖼️ Decorazioni

| Id | Nome | Skill | Note |
|----|------|-------|------|
| `carpet` | Tappeto | Tailoring | Strato sottile sul pavimento; ha un **colore** e si unisce ai vicini in tappeti grandi |
| `fur_rug` | Tappeto di pelliccia | Tailoring | Pelle d'orso o di lupo; capanne del cacciatore |
| `banner` | Stendardo | Tailoring | Su un'asta, ha un **colore**; zone di guardia, accampamenti |
| `wall_banner` | Stendardo a muro | Tailoring | Lo stesso stendardo appeso a una parete |
| `tapestry` | Arazzo | Tailoring | Grande, 2 × 2 sulla parete; castelli, abbazie |
| `curtain` | Tenda da finestra | Tailoring | Si apre e si chiude |
| `painting` | Quadro | Mercanti e bottini | Diversi soggetti; si appende |
| `stone_statue` | Statua di pietra | Mining e Architecture | Alta 2 celle |
| `marble_statue` | Statua di marmo | Mining e Architecture | Alta 2 celle; templi e piazze |
| `gargoyle_statue` | Statua di gargoyle | Mining e Architecture | Tetti di torri e cripte; a volte non è una statua... |
| `flower_pot` | Vaso da fiori | Architecture (argilla) | Ci si pianta un fiore, un fungo o una pianta di reagente |
| `potted_plant` | Pianta in vaso | Architecture | Pianta ornamentale già cresciuta |
| `cauldron` | Calderone | Blacksmithy | Sopra un fuoco cucina zuppe; nelle capanne delle streghe bolle sempre |
| `ankh` | Ankh | Non craftabile | Il simbolo dei santuari: un fantasma che lo tocca torna in vita (vedi [Morte e fantasmi](/wiki/morte-e-fantasmi)) |
| `altar` | Altare | Mining e Architecture | Santuari delle virtù (con il mantra), cerchi di pietre, templi |
| `tombstone` | Lapide | Mining | Si può incidere un nome |
| `grave_cross` | Croce di legno | Carpentry | Tombe povere, campi di battaglia |
| `skull` | Teschio | Non craftabile | Cripte, tane, covi dei mostri |
| `bone_pile` | Mucchio d'ossa | Non craftabile | Resti di avventurieri nelle tane |
| `bone_bell` | Campana d'ossa | Non craftabile | Città perduta: suona se qualcuno corre, scava o combatte vicino |
| `tribal_totem` | Totem | Carpentry | Villaggi dei selvaggi, accampamenti orcheschi; spesso è il **cuore** dell'accampamento |
| `milestone` | Pietra miliare | Mining | Segna una strada; ai bivi e alle porte dei feudi i nomi stanno sui cartelli (`signpost`) |
| `signpost` | Cartello | Carpentry | Su un palo; ci si scrive sopra |
| `wall_sign` | Insegna | Carpentry | Appesa sopra la porta di una bottega |
| `wall_shelf` | Mensola | Carpentry | Ci si posano oggetti in vista |

---

## 🔥 Stazioni di lavoro

Le stazioni sono i blocchi accanto ai quali si lavora (vedi [Attrezzi](/wiki/attrezzi#blocchi-stazione)): per usarle bisogna stare entro **2 blocchi**. Hanno tutte il prefisso `station_`.

| Id | Nome | Serve a | Come si ottiene |
|----|------|---------|-----------------|
| `station_forge` | Forgia | Fondere il minerale in lingotti, [Blacksmithy](/wiki/skill-blacksmithy) | Carpentry e Blacksmithy, pietra e lingotti |
| `station_anvil` | Incudine | Blacksmithy, insieme alla forgia | Blacksmithy, lingotti di ferro |
| `station_workbench` | Banco da lavoro | [Carpentry](/wiki/skill-carpentry): assi, mobili, blocchi di legno | Carpentry, assi |
| `station_construction_bench` | Banco da costruzione | Architecture: le strutture rinforzate del [Sistema di costruzioni](/wiki/sistema-costruzioni) | Tinkering o Carpentry |
| `station_stonecutter` | Banco da scalpellino | Mining: pietra lavorata, tegole di ardesia, statue | Tinkering, lingotti e pietra |
| `station_kiln` | Fornace | Cuocere argilla in mattoni, coppi e terracotta (Architecture); fondere la sabbia in vetro (Tinkering, Alchemy) | Mining, pietra e argilla |
| `station_oven` | Forno | [Cooking](/wiki/skill-cooking): pane, torte | Carpentry, pietra |
| `station_spinning_wheel` | Filatoio | Filare cotone, lino e lana | Carpentry |
| `station_loom` | Telaio | Tessere la stoffa per [Tailoring](/wiki/skill-tailoring) | Carpentry |
| `station_dye_tub` | Vasca da tintore | Tingere vestiti, cuoio e stoffe | Carpentry |
| `station_millstone` | Macina | Macinare il grano in farina | Carpentry e pietra; nei mulini a vento gira da sola |
| `station_imbuing_forge` | Forgia dell'infusione | [Imbuing](/wiki/skill-imbuing) | Materiali rari; si trova anche in alcuni luoghi antichi |
| `station_alchemy_table` | Tavolo da alchimista | Banco del laboratorio di [Alchemy](/wiki/skill-alchemy) | Carpentry |
| `station_scribe_desk` | Scrittoio dello scriba | Banco di [Inscription](/wiki/skill-inscription) | Carpentry |
| `station_fletcher_bench` | Banco da arcaio | Banco di [Bowcraft/Fletching](/wiki/skill-bowcraft-fletching) | Carpentry |
| `station_tanning_rack` | Telaio per pelli | Decorazione di concerie e capanne di cacciatori | Carpentry |

> 💡 Alchemy, Inscription e Bowcraft non chiedono una stazione: i loro banchi sono facoltativi e servono ad arredare laboratori e botteghe. Il banco da costruzione si consuma con l'uso (~500 utilizzi, vedi [Sistema di costruzioni](/wiki/sistema-costruzioni#banco-da-costruzione)).

---

## 📦 Contenitori

I contenitori sono blocchi che **contengono oggetti**. Come in Ultima Online non hanno una griglia: chi apre un forziere vede una finestra in cui ogni oggetto sta dove è stato posato, e dentro un contenitore se ne possono mettere altri (una borsa dentro una cassa).

Il **contenuto si salva nel mondo** insieme al blocco: una cassa lasciata in una casa ritrova le stesse cose al ritorno, per tutti. Si chiudono a chiave con una serratura, e nella [città di gilda](/wiki/citta-di-gilda) si possono **bloccare** a terra e assegnare a un membro (bauli personali).

### Zaini, borse e sacchetti non sono blocchi

> 🎒 **Zaino, borse e sacchetti sono oggetti, non blocchi.** Sono contenitori che il personaggio porta con sé: lo zaino è il suo inventario, e borse e sacchetti stanno dentro lo zaino (per esempio il sacchetto per reagenti `reagent_pouch`, vedi [Attrezzi](/wiki/attrezzi)). Si possono lasciare cadere a terra, dove restano **oggetti** con il loro contenuto e, come ogni oggetto a terra all'aperto, spariscono dopo 1 ora di mondo aperto (vedi [Persistenza del mondo](/wiki/persistenza-del-mondo)). Non si piazzano mai come blocchi e non occupano una cella del mondo.
>
> I contenitori di questa pagina invece sono **blocchi**: si piazzano in una cella, si urtano, si girano, e non scadono.

Un contenitore piazzato si può **raccogliere** con tutto il suo contenuto, come in Ultima Online, se non è bloccato e se il personaggio ne regge il peso; piazzato di nuovo, torna blocco con dentro le stesse cose. I forzieri delle [strutture](/wiki/strutture) invece sono fissati al loro posto: si aprono (o si scassinano) ma non si portano via.

### Forzieri, casse e botti

| Id | Nome | Skill | Note |
|----|------|-------|------|
| `chest` | Forziere di legno | Carpentry | Il forziere classico; è quello del bottino di briganti, relitti, dungeon e tesori sepolti. Come i tronchi, si raccoglie anche a mani nude; con l'ascia si fa solo più in fretta |
| `ornate_chest` | Forziere decorato | Carpentry | Intagliato, con rinforzi dorati; castelli, capitani pirati |
| `metal_chest` | Baule di metallo | Blacksmithy | Più robusto, serrature migliori; il "baule di metallo dal fabbro" dei bauli personali |
| `metal_box` | Scatola di metallo | Blacksmithy | Piccola |
| `strongbox` | Cassaforte | Tinkering | Piccola, con la serratura più difficile da scassinare; banche e botteghe |
| `trunk` | Baule | Carpentry | Baule da viaggio con cinghie di cuoio; locande, navi |
| `coffer` | Cofanetto | Carpentry | Piccolissimo, per gioielli e gemme; sta anche sopra un tavolo |
| `wooden_box` | Scatola di legno | Carpentry | Piccola |
| `small_crate` | Cassetta | Carpentry | |
| `crate` | Cassa | Carpentry | Magazzini, stive, moli |
| `large_crate` | Cassa grande | Carpentry | Stive delle navi, carovaniere |
| `barrel` | Botte | Carpentry | Grande; cibo, frecce, merci. In taverne e stive |
| `keg` | Barilotto | Carpentry | Contiene **liquidi**: bevande o pozioni dello stesso tipo, che si spillano una alla volta |
| `basket` | Cesto | Carpentry (vimini e canne) | Piccolo; mercati, fattorie |
| `clay_vase` | Vaso di terracotta | Architecture | Piccolo; nelle abitazioni nella roccia nasconde oro e gemme |
| `coffin` | Bara | Carpentry | Cimiteri, cripte; dentro c'è il corredo del morto (profanarlo abbassa il [karma](/wiki/karma-e-fama)) |
| `sarcophagus` | Sarcofago | Mining | Di pietra, 1 × 2; piramidi, tombe del deserto, mausolei |

### Mobili contenitori

| Id | Nome | Celle | Note |
|----|------|-------|------|
| `bookcase` | Libreria | 1 | Libri, pergamene e mappe; biblioteche delle roccaforti e delle torri dei maghi |
| `shelf` | Scaffale | 1 | Gli oggetti posati si vedono da fuori; botteghe, dispense |
| `armoire` | Armadio | 1, alto 2 | Vestiti e armature |
| `fancy_armoire` | Armadio decorato | 1, alto 2 | Intagliato |
| `wardrobe` | Guardaroba | 2, alto 2 | Armadio a due ante, il più capiente dei mobili |
| `dresser` | Cassettone | 1 | Cassetti per vestiti e gioielli |
| `nightstand` | Comodino | 1 | Piccolo, accanto al letto |
| `writing_desk` | Scrivania | 1 | Con cassetto; ci si scrive e si legge |

### Contenitori speciali

| Id | Nome | Note |
|----|------|------|
| `bank_chest` | Forziere della banca | Nelle banche delle città e delle [città di gilda](/wiki/citta-di-gilda): apre la **banca personale** di chi lo usa. Non contiene oggetti suoi: la banca è del personaggio ed è la stessa da ogni banchiere |

---

## 🌾 Strade, campi e miniere

| Id | Nome | Skill | Note |
|----|------|-------|------|
| `dirt_path` | Sentiero | Pala (nessuna skill) | Già nei [blocchi naturali](/wiki/blocchi#terreni): strade dei villaggi |
| `paving_stones` | Lastricato | Mining | Strade e piazze delle città, strade del regno, ponti |
| `farmland` | Terra arata | Zappa (nessuna skill) | Già nei blocchi naturali: per grano, cotone, lino e ortaggi |
| `hay_bale` | Balla di fieno | Nessuna (grano) | Fienili, stalle; attutisce le cadute; i cavalli la mangiano |
| `trough` | Abbeveratoio | Carpentry | Acqua o biada per gli animali nelle stalle e nei recinti |
| `hitching_post` | Palo per legare | Carpentry | Ci si legano cavalli e ostard: stalle, locande, accampamenti nomadi |
| `scarecrow` | Spaventapasseri | Carpentry e Tailoring | Tiene lontani i corvi dai campi |
| `well_winch` | Argano del pozzo | Carpentry | Il tettuccio con corda e secchio sopra un pozzo di pietra; da qui si prende acqua |
| `windmill_sails` | Pale del mulino | Carpentry e Tailoring | Grandi pale di tela che girano e muovono la macina |
| `mine_rail` | Binario | Blacksmithy | Per i carrelli delle miniere |
| `mine_support` | Puntello | Carpentry | Travi di sostegno delle gallerie delle miniere |

I recinti si fanno con le **staccionate** e i **cancelletti** di legno; i pozzi con pietrisco e mattoni intorno all'acqua.

---

## ⚓ Navi e porti

Le navi del mondo (relitti, navi fantasma, la nave arenata del covo dei pirati) e i porti sono fatti di questi blocchi, più le assi e i tronchi normali per moli e pontili.

| Id | Nome | Skill | Note |
|----|------|-------|------|
| `ship_hull` | Fasciame | Carpentry | Assi incatramate dello scafo; resiste all'acqua |
| `ship_hull_stairs` | Fasciame a scala | Carpentry | Per la curva della prua e della chiglia |
| `ship_hull_slab` | Fasciame a lastra | Carpentry | Ponti e bordi |
| `mast` | Albero maestro | Carpentry | Tronco verticale, si impila |
| `sail` | Vela | Tailoring | Tela appesa all'albero; ha un **colore** (nero per i pirati) |
| `rope` | Corda | Tailoring (lino) | Sartie, ormeggi; ci si arrampica |
| `ship_wheel` | Timone | Carpentry | |
| `capstan` | Argano | Carpentry | Alza l'ancora |
| `anchor` | Ancora | Blacksmithy | |
| `cannon` | Cannone | Blacksmithy | Navi e fortezze dei pirati, porto dei bucanieri |
| `mooring_post` | Bitta | Carpentry | Sui moli, per ormeggiare |
| `fishing_net` | Rete da pesca | Tailoring | Appesa ad asciugare nei villaggi di pescatori |

> ⚠️ In questa pagina ci sono i **blocchi** delle navi. Le navi delle strutture sono relitti fermi, fatti di blocchi normali; le navi che si guidano avranno regole proprie.

---

## 🏰 Usati nelle strutture

Il generatore delle [strutture](/wiki/strutture) usa questi blocchi, scegliendo il materiale secondo il bioma:

| Strutture | Famiglie di blocchi |
|-----------|---------------------|
| **Feudi** e **villaggi** | Pietra lavorata o mattoni per le mura, travi e intonaco o assi per le case, tetti di paglia, coppi, ardesia o scandole secondo il bioma; vetri, porte, lampioni, lastricato; dentro letti, tavoli, sedie, banconi, forzieri, botti, librerie e le stazioni delle botteghe (forgia e incudine dal fabbro, telaio dal sarto, forno dal fornaio), il forziere della banca |
| **Santuari** | Marmo levigato e colonne, ankh, altare, stendardi del colore della virtù |
| **Fattorie, mulini, fienili** | Assi, paglia, staccionate, terra arata, balle di fieno, abbeveratoi, macina e pale del mulino, pozzo |
| **Accampamenti** (briganti, nomadi, orchi, selvaggi) | Tela e pelle tesa per le tende, fuoco da campo, totem o stendardo come cuore, giacigli, casse, pali per legare |
| **Capanne e torri** (boscaiolo, cacciatore, strega, mago) | Tronchi, scandole, letti, tavoli, calderone, librerie, lanterne |
| **Templi, piramidi, tombe** | Arenaria, marmo, mattoni scolpiti e incrinati, sarcofagi, trappole a dardi e a punte, porte segrete, bracieri |
| **Cripte, cimiteri, mausolei** | Pietra scura e ardesia profonda, lapidi, croci, bare, teschi, ossa, candelabri |
| **Dungeon e fortezze** | Mattoni dello strato, porte di ferro, sbarre, saracinesche, leve, catene, torce a muro, rastrelliere per armi, forzieri |
| **Città perduta, tempio demoniaco** | Basalto nero e roccia infernale lavorati, campane d'ossa, bracieri |
| **Miniere abbandonate** | Puntelli, binari, impalcature, lanterne, casse |
| **Relitti, navi fantasma, porti** | Fasciame, alberi, vele, corde, ancora, timone, cannoni, casse, botti, bitte e assi per i moli |
| **Fari** | Calcare o pietra lavorata, scale, lanterna del faro |
| **Rovine sommerse** | Pietra corallina e marmo, colonne, forzieri |

---

## 🧪 Note di sviluppo

- **Capacità dei contenitori.** Per tre contenitori il valore è deciso nel pacchetto dati del gioco: forziere (`chest`), botte (`barrel`) e cassa (`crate`) tengono **125 oggetti** e **400 pietre** di peso, come lo zaino (125 oggetti, senza limite di peso); le finestre, grandi il 23 % della larghezza dello schermo, mostrano l'apertura disegnata (rotonda per la botte, rettangolare per la cassa). Per gli altri contenitori resta una proposta, sul modello di Ultima Online (dove zaini e forzieri tengono fino a 125 oggetti): quattro taglie che decidono la grandezza della finestra e il numero massimo di oggetti. **Piccola** (`coffer`, `wooden_box`, `metal_box`, `strongbox`, `basket`, `clay_vase`, `nightstand`, `writing_desk`): 25 oggetti. **Media** (`ornate_chest`, `trunk`, `small_crate`, `dresser`, `shelf`, `bookcase`, `coffin`): 125. **Grande** (`metal_chest`, `large_crate`, `armoire`, `fancy_armoire`, `sarcophagus`): 125 con un peso massimo più alto. **Molto grande** (`wardrobe`): 175. Il barilotto (`keg`) è a parte: un solo liquido, fino a 100 dosi. Da confermare.
- **Proprietà dei blocchi.** `facing`, `wood`, `color`, `half` (lastre e scale in alto o in basso), `open` (porte, botole, cancelletti), `lit` (luci accese o spente), `locked` e la chiave. Sono proprietà del blocco piazzato, non id diversi.
- **Come si salvano le proprietà e cosa ha deciso [ADR-0026](https://github.com/Soulslands/soulslands-game/blob/main/docs/adr/0026-built-block-shapes.md).** Le proprietà stanno nel **nome** del blocco nella palette del chunk, nella forma `<id>/<chiave>.<valore>/...` con le chiavi in ordine alfabetico, per esempio `soulslands:oak_door/facing.north/half.lower/hinge.left/open.false`: mai come id separati e senza cambiare il formato dei salvataggi. Ogni combinazione di proprietà è uno **stato** del blocco, e gli stati esistono per i blocchi da costruzione dalla fase F4b. Un nome senza una proprietà carica il valore di partenza (il primo della lista), così un blocco salvato prima di averla non va perso. I collegamenti di muri, recinti e pannelli (vetri e sbarre) non si salvano: si ricavano dai quattro vicini orizzontali, ogni volta che servono. Gli oggetti restano un solo id per tipo: tipo di legno e colore di un blocco rotto e rimesso a terra si perdono finché la fase F7 non decide come tenerli (domanda aperta dell'ADR).
- **Valori approvati da Aruto (26/10/2026).** I valori che la wiki non aveva ancora, proposti dall'ADR, sono stati approvati così come proposti. (1) Muri, recinti e cancelletti chiusi **fermano a 1,5 blocchi di altezza** come in Minecraft: un salto da terra non li supera, un salto da una lastra o da un gradino accanto sì; pannelli di vetro e sbarre di ferro restano a 1 blocco; la forma disegnata e il contorno della mira restano a 1 blocco. (2) I mobili si fanno in **tutti e 7 i legni** (`plain`, `oak`, `ash`, `yew`, `heartwood`, `bloodwood`, `frostwood`), `plain` di partenza; il giaciglio (`bedroll`) non ha legno. (3) `stained_glass` e `stained_glass_pane` hanno i **16 colori** dei coloranti di Minecraft, `white` di partenza. (4) Porte, botole, cancelletti e imposte si aprono a mano allo stesso modo in sopravvivenza e in creativa (anche le porte di ferro); serrature e chiavi arrivano con la fase F7. (5) Le lampade si accendono e si spengono a mano, senza combustibile; torce e lanterne si piazzano accese. (6) La luce delle candele è 4, 8, 12, 15. (7) Il lampione (`street_lamp`) occupa 2 celle (palo e lanterna); camino, braciere, fuoco da campo, candelabro e lampadario ne occupano 1 (il lampadario è sempre appeso). (8) La collisione dei mobili segue la loro forma: sedia e sgabello sono seduta più schienale, il letto è alto 9/16, tavoli, banconi e troni occupano il loro ingombro. (9) Le scale sono **dritte** (niente scale ad angolo) e i banconi non si uniscono ancora. (10) Una torcia resta al suo posto se si rompe il blocco che la regge. (11) Un blocco di più celle (porta, letto) **non può stare a cavallo di un confine di cella**: la cella è la griglia fissa del server di 8 × 8 colonne di chunk, cioè 256 × 256 blocchi, quindi un letto o una porta si rifiuta solo su quelle linee di confine (chiave di errore `error-block-crosses_cell`). (12) La **cerniera** di una porta sta alla sinistra di chi la piazza, a destra se alla sua sinistra c'è già una porta con lo stesso orientamento (porte doppie).
- **Come si piazzano e si usano.** Il client sceglie l'orientamento (`facing`) dallo sguardo e la metà (`half`) dal punto della faccia colpita; il server controlla solo che lo stato sia uno stato valido da piazzare. Si usa un blocco (porta, botola, cancelletto, lampada) con il tasto destro; con il tasto di scivolata premuto si piazza sempre. Chiavi di rifiuto nuove: `error-block-not_usable` e `error-block-crosses_cell`. Il dettaglio tecnico di rete e simulazione sta nella documentazione per lo sviluppo, riservata allo staff.
- **Rinforzati.** I muri 🧱 delle strutture sono questi stessi blocchi con la marca di blocco rinforzato o protetto descritta in [Strutture](/wiki/strutture#blocchi-protetti-e-rinforzati), non id separati.
- Il pacchetto dati del gioco contiene già `chest`, `cobblestone`, `dark_cobblestone`, `cobbled_basalt`, `cobbled_deepslate`, `cobbled_hellstone`, `plain_planks`, `oak_planks`, `ash_planks`, `yew_planks`, `dirt_path`, `farmland`, `station_forge` e `station_anvil`: questa pagina usa gli stessi id.

---

## ❓ FAQ

**D: Perché lo zaino non si può piazzare come un forziere?**
R: Perché è un oggetto che porti addosso, non un pezzo del mondo. Se lo lasci a terra resta un oggetto, e prima o poi sparisce. Per conservare le cose costruisci o compra un forziere, una cassa o un armadio e piazzali in casa: il contenuto resta lì, salvato nel mondo.

**D: Posso mettere una cassa dentro un'altra cassa?**
R: Le borse e i sacchetti sì, come in Ultima Online. I contenitori piazzati come blocchi no: un forziere si raccoglie, ma finché è un blocco sta nella sua cella.

**D: Se rompo un forziere pieno con il piccone, perdo il contenuto?**
R: No. Un forziere si **raccoglie** con il suo contenuto, non si scava: si prende intero, se non è bloccato e se ne reggi il peso. I forzieri bloccati in una casa o in una città di gilda e quelli fissi delle strutture non si raccolgono.

**D: Una sedia di tasso è un blocco diverso da una sedia di quercia?**
R: È la stessa `wooden_chair` con un legno diverso: cambia il colore e, come per tutte le strutture in legno, i [legni pregiati](/wiki/legni#bonus-sulle-strutture) la rendono più resistente. Assi, scale e porte invece hanno un id per ogni legno.

**D: Chi costruisce le case dei villaggi?**
R: Il generatore del mondo, con questi stessi blocchi. Un giocatore può costruirne una identica: le assi, i coppi e le porte sono gli stessi.

**D: I blocchi di questa pagina sono indistruttibili come le strutture rinforzate?**
R: No: sono blocchi comuni e si rompono con l'attrezzo giusto. Le difese vere si costruiscono con il [Sistema di costruzioni](/wiki/sistema-costruzioni), solo nel territorio di una gilda.

**D: Le mod possono aggiungere mobili e blocchi?**
R: Sì, con il loro prefisso, per esempio `miamod:trono_di_cristallo`, come per i [blocchi naturali](/wiki/blocchi).

---

*Vedi anche: [Blocchi del mondo](/wiki/blocchi) | [Strutture del mondo](/wiki/strutture) | [Sistema di costruzioni](/wiki/sistema-costruzioni) | [Attrezzi](/wiki/attrezzi) | [Legni](/wiki/legni) | [Carpentry](/wiki/skill-carpentry) | [Architecture](/wiki/skill-architecture) | [Tinkering](/wiki/skill-tinkering)*
