---
title: Blocchi del mondo
slug: blocchi
category: Mondo
visibility: Pubblica
---
# 🧱 Blocchi del mondo
*Terra, pietra, acqua, lava e tutto ciò di cui è fatto il mondo*

---

## 📋 Indice

- [Panoramica](#panoramica)
- [Come funziona un blocco](#come-funziona-un-blocco)
- [Speciali e limiti del mondo](#speciali-e-limiti-del-mondo)
- [Terreni](#terreni)
- [Neve e ghiaccio](#neve-e-ghiaccio)
- [Sabbie e ghiaie](#sabbie-e-ghiaie)
- [Rocce degli strati](#rocce-degli-strati)
- [Altre rocce](#altre-rocce)
- [Liquidi](#liquidi)
- [Minerali grezzi](#minerali-grezzi)
- [Legno](#legno)
- [Piante e vegetazione](#piante-e-vegetazione)
- [Coralli e piante d'acqua](#coralli-e-piante-dacqua)
- [Reagenti nel mondo](#reagenti-nel-mondo)
- [Dal blocco all'oggetto](#dal-blocco-alloggetto)
- [Texture](#texture)
- [FAQ](#faq)

---

## 📜 Panoramica

Il [mondo](/wiki/mondo) di Soulslands è fatto di **blocchi cubici** di un metro di lato, come in Minecraft. Questa pagina è il catalogo dei **blocchi naturali**, cioè quelli che il generatore mette nel mondo: terreni, rocce, liquidi, minerali, alberi e piante. Sono la **materia prima** da cui nascono tutti gli oggetti del gioco: lingotti, assi, mattoni, stoffe, pozioni.

I blocchi costruiti (assi, mattoni, pietra lavorata, vetro, porte, mobili, luci, forzieri) nascono da questi e sono nel catalogo dei [Blocchi da costruzione](/wiki/blocchi-costruzione); le strutture rinforzate delle gilde sono nel [Sistema di costruzioni](/wiki/sistema-costruzioni).

> 💡 Ogni blocco ha un **id** leggibile nel formato `soulslands:nome`, per esempio `soulslands:stone` o `soulslands:oak_log`. È il nome usato nei salvataggi del mondo, nei comandi del server e dalle mod. Niente numeri come `0x1A`: dal nome si capisce sempre cos'è.

---

## ⚙️ Come funziona un blocco

| Proprietà | Significato |
|-----------|-------------|
| **Durezza** | Quanto tempo serve per romperlo. I tempi di questa pagina sono con l'attrezzo giusto e la skill a 0; a skill 100.0 si scava circa il doppio più veloce (vedi [Attrezzi](/wiki/attrezzi)) |
| **Attrezzo** | Pala, piccone, accetta, forbici o mani. Con l'attrezzo sbagliato si scava molto più piano, e i blocchi che chiedono un attrezzo non lasciano nulla (vedi sotto) |
| **Skill** | Solo i [minerali](/wiki/minerali) e i legni pregiati chiedono una skill minima ([Mining](/wiki/skill-mining), [Lumberjacking](/wiki/skill-lumberjacking)). Sotto la soglia un minerale si rompe ma non rende nulla, mentre sul tronco di un legno pregiato l'ascia rimbalza |
| **Cosa lascia** | L'oggetto che finisce nello zaino. Spesso non è il blocco stesso: la pietra lascia pietrisco, il minerale lascia minerale grezzo |
| **Gravità** | Sabbia, ghiaia, neve fresca e cenere (`volcanic_ash`, `grave_ash`) cadono se sotto non c'è nulla. La terra di cenere (`ash_soil`) no |
| **Luce** | Alcuni blocchi emettono luce (lava, cristalli, funghi luminosi) da 0 a 15, la stessa scala di [Giorno e notte](/wiki/giorno-e-notte) |
| **Infiammabile** | Legno, foglie, erba secca e torba prendono fuoco |

> **Deciso dal PM per delega di Aruto (25/10/2026):** un blocco che chiede un attrezzo, rotto con quello sbagliato o a mani nude, non lascia nulla, nemmeno un minerale comune: né minerale grezzo né ghiaia al suo posto. Terra, sabbia, neve, tronchi, assi e piante rendono invece anche a mani nude. La cenere vulcanica e quella di tomba cadono come la sabbia; la terra di cenere resta ferma.

---

## 🛡️ Speciali e limiti del mondo

| Id | Nome | Note |
|----|------|------|
| `air` | Aria | Lo spazio vuoto. Non si vede e non si raccoglie |
| `world_rock` | **Roccia del Mondo** | Lo strato più basso del mondo, a Y -64, come la bedrock di Minecraft. **Indistruttibile** per qualsiasi giocatore: nessun attrezzo, incantesimo o esplosione la scalfisce. Solo lo staff del server (GM) può piazzarla o toglierla. Si genera anche in macchie irregolari fino a Y -60, così il fondo non è piatto |
| `barrier` | Barriera | Blocco invisibile e indistruttibile che solo lo staff può piazzare, per chiudere aree di eventi o confini del mondo |

> ⚠️ Sotto la Roccia del Mondo non c'è nulla. In cima, a Y 320, c'è il limite del cielo: oltre non si può costruire.

---

## 🌱 Terreni

Si scavano con la **pala** (circa 0,3 secondi) o a mani nude (tre volte più piano, circa 0,9 secondi).

| Id | Nome | Dove si trova | Cosa lascia | Note |
|----|------|---------------|-------------|------|
| `dirt` | Terra | Sotto l'erba in quasi tutti i [biomi](/wiki/biomi) | Terra | Lo strato tra la superficie e la pietra, di solito 3-5 blocchi |
| `grass` | Erba | Superficie di pianure, foreste, colline | Terra | Si diffonde da sola sulla terra vicina se c'è luce; il colore cambia con il bioma e la stagione |
| `forest_soil` | Terriccio di bosco | Foresta profonda, taiga, foresta incantata | Terra | Aghi e foglie secche; ci crescono funghi e felci |
| `mud` | Fango | [Palude](/wiki/bioma-palude), [mangrovie](/wiki/bioma-mangrovie), rive | Fango | Rallenta chi ci cammina. Seccato al sole diventa mattone crudo |
| `clay` | Argilla | Rive di [laghi e fiumi](/wiki/laghi-e-fiumi), fondali bassi | Argilla | Per vasi, mattoni e tegole |
| `red_clay` | Argilla rossa | [Canyon rossi](/wiki/bioma-canyon-rossi), qualche affioramento nella [savana](/wiki/bioma-savana) arida | Argilla rossa | Strati colorati sulle pareti dei canyon; si cuoce in terracotta |
| `peat` | Torba | [Brughiera](/wiki/bioma-brughiera), paludi | Torba | Combustibile per forni e fuochi; brucia a lungo |
| `moss_block` | Muschio | Foresta profonda, [grotte di muschio](/wiki/grotte-e-sottosuolo) | Muschio | Si stende sulla pietra umida |
| `mycelium` | Micelio | Isole dei funghi, [caverne dei funghi giganti](/wiki/grotte-e-sottosuolo) | Terra | Ci crescono i funghi giganti |
| `farmland` | Terra arata | Creata con la zappa | Terra | Per grano, cotone, lino e ortaggi; secca senza acqua vicina |
| `dirt_path` | Sentiero | Strade delle città e dei villaggi | Terra | Le strade principali delle città NPC sono protette |
| `ash_soil` | Terra di cenere | [Terre vulcaniche](/wiki/bioma-terre-vulcaniche) | Terra di cenere | Setacciata dà **cenere sulfurea** (reagente). Non cade, a differenza della cenere vulcanica e di quella di tomba |
| `dead_soil` | Terra morta | [Terre dei Morti](/wiki/bioma-terre-dei-morti) | Terra morta | Grigia e sterile: non ci cresce nulla di vivo |
| `shadow_soil` | Terra d'ombra | [Lande d'Ombra](/wiki/bioma-lande-d-ombra) | Terra d'ombra | Assorbe la luce: le torce illuminano meno |
| `coarse_dirt` | Terra grossolana | [Savana](/wiki/bioma-savana), cime delle mesa nei [canyon rossi](/wiki/bioma-canyon-rossi), radure della [taiga](/wiki/bioma-taiga) | Terra grossolana | Terra sassosa e povera: l'erba non ci si diffonde. Zappata torna terra |
| `rooted_dirt` | Terra con radici | Sotto le grandi querce della [foresta profonda](/wiki/bioma-foresta-profonda) e della [giungla](/wiki/bioma-giungla), sopra le [grotte di muschio](/wiki/grotte-e-sottosuolo) | Terra, a volte radici | Dal lato di sotto pendono radici (`hanging_roots`) |
| `frozen_dirt` | Terra gelata | Sotto la neve della [tundra](/wiki/bioma-tundra), delle vette innevate e delle isole ghiacciate | Terra gelata | Permafrost duro come la pietra: si scava con il piccone (1 secondo); senza piccone non lascia nulla. Vicino a un fuoco torna terra |
| `jungle_soil` | Terriccio rosso | [Giungla](/wiki/bioma-giungla), isole tropicali | Terra | Terra rossa e grassa sotto il sottobosco; ci crescono bene ginseng e bambù |
| `enchanted_grass` | Erba incantata | [Foresta incantata](/wiki/bioma-foresta-incantata) | Terra | Erba verde-argento che di notte brilla appena (luce 3); si diffonde solo nella foresta incantata o vicino ai cristalli di mana |
| `grave_ash` | Cenere di tomba | [Terre dei Morti](/wiki/bioma-terre-dei-morti), isole maledette | Cenere di tomba | Cenere grigia di roghi antichi; cade come la sabbia |

**Argille dei canyon.** Nelle pareti dei [canyon rossi](/wiki/bioma-canyon-rossi) l'argilla rossa si alterna ad argille di altri colori, in bande orizzontali come la terracotta delle badlands di Minecraft. Tutte si cuociono in terracotta del loro colore.

| Id | Nome | Dove si trova | Cosa lascia | Note |
|----|------|---------------|-------------|------|
| `ochre_clay` | Argilla ocra | Bande dei canyon rossi | Argilla ocra | Terracotta gialla; pigmento giallo per le tinture |
| `orange_clay` | Argilla arancione | Bande dei canyon rossi | Argilla arancione | Terracotta arancione |
| `brown_clay` | Argilla bruna | Bande dei canyon rossi, rive dei fiumi della savana | Argilla bruna | Terracotta bruna |
| `white_clay` | Argilla bianca | Bande alte dei canyon rossi, sacche sotto le scogliere di calcare delle coste | Argilla bianca (caolino) | Ceramica fine e intonaco bianco |

---

## ❄️ Neve e ghiaccio

| Id | Nome | Dove si trova | Attrezzo | Cosa lascia | Note |
|----|------|---------------|----------|-------------|------|
| `snow_layer` | Strato di neve | Sopra l'erba in [tundra](/wiki/bioma-tundra), [taiga](/wiki/bioma-taiga), vette e ovunque d'inverno | Pala, o mani nude | Palle di neve | Da 1 a 8 strati; si scioglie vicino a fonti di calore. A mani nude lascia le palle di neve, come la terra |
| `snow` | Neve | Tundra, vette sopra Y 180 | Pala, o mani nude | Palle di neve | Blocco intero di neve compatta. A mani nude lascia le palle di neve, come la terra |
| `ice` | Ghiaccio | Laghi e fiumi gelati, mari polari | Piccone | Nulla (si scioglie in acqua) | Scivoloso; se rotto lascia acqua. È l'**unico ghiaccio traslucido**: si vede attraverso |
| `packed_ice` | Ghiaccio compatto | Iceberg, [grotte di ghiaccio](/wiki/grotte-e-sottosuolo) | Piccone | Ghiaccio compatto | Non si scioglie. Opaco; senza piccone non lascia nulla |
| `glacier_ice` | Ghiaccio di ghiacciaio | Ghiacciai delle vette, mari ghiacciati | Piccone | Ghiaccio di ghiacciaio | Azzurro, durissimo, il più scivoloso. Opaco; senza piccone non lascia nulla |
| `powder_snow` | Neve farinosa | Conche della tundra, vette innevate, crepacci dei ghiacciai | Pala | Nulla (si raccoglie con il secchio) | Non regge il peso: chi ci cammina sopra affonda e prende danno da freddo. Sembra neve normale |
| `icicle` | Ghiacciolo | Soffitti delle [grotte di ghiaccio](/wiki/grotte-e-sottosuolo), sotto le sporgenze di tundra e vette | Piccone o mani | Nulla | Come la stalattite, cade su chi passa sotto se si rompe il blocco che lo regge |
| `ice_crystal` | Cristallo di ghiaccio | Grappoli nelle grotte di ghiaccio e nelle grotte di cristallo sotto la tundra | Piccone, serve Mining 50 | Frammenti di cristallo di ghiaccio | Luce 4; reagente per l'alchimia del freddo |

---

## 🏖️ Sabbie e ghiaie

Si scavano con la **pala**. Sabbia e ghiaia **cadono** se manca il blocco sotto.

| Id | Nome | Dove si trova | Cosa lascia | Note |
|----|------|---------------|-------------|------|
| `sand` | Sabbia | [Deserto](/wiki/bioma-deserto), [coste](/wiki/bioma-coste), fondali | Sabbia | Si fonde in **vetro** |
| `red_sand` | Sabbia rossa | Canyon rossi, [savana](/wiki/bioma-savana) arida | Sabbia rossa | Vetro ambrato |
| `black_sand` | Sabbia nera | Spiagge vulcaniche, isole vulcaniche | Sabbia nera | Vetro scuro; a volte contiene ossidiana |
| `gravel` | Ghiaia | Fiumi, montagne, fondali | Ghiaia, a volte selce | Setacciata può dare un po' di minerale e qualche gemma |
| `sandstone` | Arenaria | Sotto la sabbia del deserto | Arenaria | Si scava con il piccone (1 secondo); senza piccone non lascia nulla |
| `red_sandstone` | Arenaria rossa | Pareti dei canyon rossi | Arenaria rossa | Si scava con il piccone (1 secondo); senza piccone non lascia nulla |
| `volcanic_ash` | Cenere vulcanica | [Terre vulcaniche](/wiki/bioma-terre-vulcaniche), isole vulcaniche, bordi delle caverne di lava | Cenere vulcanica | Grigio scuro, cade come la sabbia. Con la calce fa una malta che indurisce anche sott'acqua |
| `quicksand` | Sabbie mobili | Conche del [deserto](/wiki/bioma-deserto), fondo delle gole dei canyon rossi | Sabbia | Sembra sabbia: chi ci entra affonda piano e soffoca se non ne esce. Le cavalcature ci restano bloccate |
| `seashells` | Conchiglie | Spiagge delle [coste](/wiki/bioma-coste), isole tropicali e isolotti | Conchiglie | Non è un blocco pieno: sta sopra la sabbia. Per decorare e per fare calce |

---

## 🪨 Rocce degli strati

La roccia cambia con la profondità, come descritto in [Grotte e sottosuolo](/wiki/grotte-e-sottosuolo). Più è profonda, più è dura e più tempo serve per romperla: qualsiasi piccone va bene, il materiale cambia solo velocità e durata dell'attrezzo (niente livelli di piccone). Rotta, lascia il suo **pietrisco**, che si usa per costruire o si lavora in mattoni.

| Id | Nome | Strato (Y) | Tempo (piccone) | Cosa lascia |
|----|------|-----------|-----------------|-------------|
| `stone` | Pietra | Da sotto la terra fino a Y 0 | 1,5 s | `cobblestone` (pietrisco) |
| `dark_stone` | Pietra scura | Y 0 – -16 | 2 s | `dark_cobblestone` |
| `deepslate` | Ardesia profonda | Y -16 – -32 | 3 s | `cobbled_deepslate` |
| `black_basalt` | Basalto nero | Y -32 – -48 | 4 s | `cobbled_basalt` |
| `hellstone` | Roccia infernale | Y -48 – -64 | 5 s, calda al tatto | `cobbled_hellstone` |
| `world_rock` | Roccia del Mondo | Y -64 | Indistruttibile | Nulla |

Tra uno strato e l'altro c'è una **fascia di passaggio** di qualche blocco dove le due rocce si mescolano.

**Pietrisco.** È ciò che lascia ogni roccia degli strati quando si rompe, e si piazza così com'è. Si forma da solo dove l'acqua raggiunge un flusso di lava, e il generatore lo usa per i muri di rovine, miniere e dungeon. Al banco da scalpellino diventa pietra lavorata e mattoni (vedi [Blocchi da costruzione](/wiki/blocchi-costruzione)).

| Id | Nome | Da quale roccia | Tempo (piccone) | Note |
|----|------|-----------------|-----------------|------|
| `cobblestone` | Pietrisco | `stone` | 1,5 s | Anche dove l'acqua raggiunge un flusso di lava |
| `dark_cobblestone` | Pietrisco scuro | `dark_stone` | 2 s | — |
| `cobbled_deepslate` | Pietrisco d'ardesia profonda | `deepslate` | 3 s | — |
| `cobbled_basalt` | Pietrisco di basalto nero | `black_basalt` | 4 s | Il basalto comune (`basalt`) invece si raccoglie intero |
| `cobbled_hellstone` | Pietrisco infernale | `hellstone` | 5 s | Resta caldo per qualche minuto dopo lo scavo |

---

## ⛰️ Altre rocce

| Id | Nome | Dove si trova | Tempo (piccone) | Uso |
|----|------|---------------|-----------------|-----|
| `granite` | Granito | [Montagne](/wiki/bioma-montagne), sacche nella pietra | 1,5 s | Costruzione, molto resistente |
| `marble` | Marmo | Montagne, [foresta incantata](/wiki/bioma-foresta-incantata) | 1,5 s | Templi, statue, pavimenti di pregio |
| `limestone` | Calcare | Coste, colline, scogliere | 1,2 s | Calce per malta e intonaco |
| `slate` | Ardesia | Montagne, brughiera | 1,5 s | Tegole e tetti |
| `basalt` | Basalto | Terre vulcaniche, isole vulcaniche, coste nere | 2 s | Costruzione scura |
| `obsidian` | Ossidiana | Dove l'acqua incontra la lava | 15 s | Lame di ossidiana, blocchi quasi indistruttibili |
| `pumice` | Pomice | Terre vulcaniche | 0,8 s | Leggera, galleggia; per levigare |
| `shadow_stone` | Pietra d'ombra | Lande d'Ombra | 3 s | Riduce il raggio della luce intorno a sé |
| `dripstone` | Roccia stillante | [Grotte di stalattiti](/wiki/grotte-e-sottosuolo) | 1,5 s | Decorativa |
| `stalactite` | Stalattite | Soffitti delle grotte | 0,5 s | Cade su chi passa sotto se si rompe il blocco che la regge |
| `stalagmite` | Stalagmite | Pavimenti delle grotte | 0,5 s | Fa danno a chi ci cade sopra |
| `mana_crystal` | Cristallo di mana | [Grotte di cristallo](/wiki/grotte-e-sottosuolo) | 2 s, serve Mining 60 | Emette luce 10; frammenti per incantesimi e Imbuing |
| `coral_stone` | Pietra corallina | Fondali delle [barriere coralline](/wiki/oceani) | 1,2 s | Blocchi bianchi e porosi |
| `diorite` | Diorite | Sacche nella pietra sopra Y 0, [montagne](/wiki/bioma-montagne), isole rocciose | 1,5 s | Pietra bianca screziata di nero per pavimenti e decorazioni |
| `andesite` | Andesite | Sacche nella pietra sopra Y 0, montagne, margini delle terre vulcaniche | 1,5 s | Pietra grigia compatta per strade e muri |
| `tuff` | Tufo | [Terre vulcaniche](/wiki/bioma-terre-vulcaniche), isole vulcaniche, sacche nella pietra scura (Y 0 – -16) | 1 s | Cenere vulcanica pressata: leggero e facile da tagliare, per case e acquedotti |
| `calcite` | Calcite | Vene nelle [grotte di stalattiti](/wiki/grotte-e-sottosuolo), scogliere di calcare e faraglioni | 1 s | Bianca e cristallina; macinata dà calce come il calcare |
| `mossy_stone` | Pietra muschiosa | Sottosuolo della [foresta profonda](/wiki/bioma-foresta-profonda) e della [giungla](/wiki/bioma-giungla), grotte di muschio | 1,5 s | Lascia pietrisco muschioso (`mossy_cobblestone`) |
| `magma_block` | Roccia magmatica | Terre vulcaniche, caverne di lava, Abisso e Cuore del mondo, bocche sul fondo delle fosse oceaniche e dei mari vicini alle terre vulcaniche | 1,5 s | Luce 3; scotta chi ci cammina sopra senza protezione dal fuoco; sott'acqua fa salire colonne di bolle |
| `rock_salt` | Salgemma | Distese di sale del [deserto](/wiki/bioma-deserto), sacche sotto deserto e coste | 1 s | Sale per conservare e cucinare ([Cooking](/wiki/skill-cooking)) |
| `fulgurite` | Folgorite | Deserto e spiagge, dove è caduto un fulmine | 0,5 s | Vetro naturale: lascia frammenti di vetro |
| `bone_block` | Blocco d'ossa | Ossa sepolte nelle [Terre dei Morti](/wiki/bioma-terre-dei-morti), fossili nel deserto e nei canyon rossi | 1 s | Lascia ossa e farina d'ossa (fertilizzante) |
| `shadow_crystal` | Cristallo d'ombra | [Lande d'Ombra](/wiki/bioma-lande-d-ombra), intorno alle voragini e nelle vene di pietra d'ombra | 3 s, serve Mining 80 | Cristallo nero che, come la pietra d'ombra, accorcia la luce intorno a sé; frammenti d'ombra per gli incantesimi oscuri |

---

## 💧 Liquidi

| Id | Nome | Luce | Comportamento |
|----|------|------|---------------|
| `water` | Acqua | 0 | Come in Minecraft c'è l'acqua **sorgente** e l'acqua che **scorre** (fino a 7 blocchi in piano). Due sorgenti vicine ne creano una terza. Si raccoglie con il secchio. Nei biomi freddi la superficie gela d'inverno. Spegne il fuoco e trasporta oggetti e creature |
| `lava` | Lava | 15 | Scorre più lenta dell'acqua: 3 blocchi in piano, 7 nelle [terre vulcaniche](/wiki/bioma-terre-vulcaniche) e nel Cuore del mondo. Brucia ciò che tocca e distrugge gli oggetti caduti dentro, **anche il bottino di un corpo**. Incendia il legno vicino |

| Incontro | Risultato |
|----------|-----------|
| L'acqua raggiunge una sorgente di lava | `obsidian` |
| L'acqua raggiunge un flusso di lava | `cobblestone` |
| La lava cade dall'alto sull'acqua | `stone` |

Dettagli su fiumi, laghi e sorgenti in [Laghi e fiumi](/wiki/laghi-e-fiumi); sul mare in [Oceani](/wiki/oceani).

---

## 💎 Minerali grezzi

Ogni [minerale](/wiki/minerali) di Soulslands è un blocco `<nome>_ore` incastonato nella roccia in **vene** di più blocchi. Si estrae con il **piccone** e la skill [Mining](/wiki/skill-mining) richiesta; lascia **minerale grezzo** da fondere in lingotti alla forgia. L'aspetto del blocco si adatta alla roccia dello strato in cui si trova, ma l'id resta lo stesso.

| Id | Minerale | Mining | Profondità tipica |
|----|----------|--------|-------------------|
| `iron_ore` | [Iron](/wiki/minerale-iron) | 0 | Ovunque |
| `rusty_ore` | [Rusty](/wiki/minerale-rusty) | 35 | Superficie – Y 20 |
| `old_copper_ore` | [Old Copper](/wiki/minerale-old-copper) | 45 | Y 40 – 0 |
| `steel_ore` | [Steel](/wiki/minerale-steel) | 55 | Y 40 – 0 |
| `dull_copper_ore` | [Dull Copper](/wiki/minerale-dull-copper) | 65 | Y 10 – -16 |
| `rose_ore` | [Rose](/wiki/minerale-rose) | 65 | Y 10 – -16 |
| `shadow_iron_ore` | [Shadow Iron](/wiki/minerale-shadow-iron) | 70 | Y 0 – -20 |
| `copper_ore` | [Copper](/wiki/minerale-copper) | 75 | Y 0 – -20 |
| `silver_ore` | [Silver](/wiki/minerale-silver) | 75 | Y 0 – -20 |
| `bronze_ore` | [Bronze](/wiki/minerale-bronze) | 80 | Y -16 – -32 |
| `orialco_ore` | [Orialco](/wiki/minerale-orialco) | 80 | Y -16 – -32 |
| `gold_ore` | [Gold](/wiki/minerale-gold) | 85 | Y -16 – -32 |
| `blood_rock_ore` | [Blood Rock](/wiki/minerale-blood-rock) | 85 | Y -20 – -32, vicino alla lava |
| `agapite_ore` | [Agapite](/wiki/minerale-agapite) | 90 | Y -24 – -40 |
| `mytheril_ore` | [Mytheril](/wiki/minerale-mytheril) | 90 | Y -32 – -48 |
| `verite_ore` | [Verite](/wiki/minerale-verite) | 95 | Y -32 – -48 |
| `black_rock_ore` | [Black Rock](/wiki/minerale-black-rock) | 95 | Y -32 – -48 |
| `titanium_ore` | [Titanio](/wiki/minerale-titanio) | 97 | Y -36 – -55 |
| `valorite_ore` | [Valorite](/wiki/minerale-valorite) | 99 | Y -40 – -55 |
| `cobalt_ore` | [Cobalto](/wiki/minerale-cobalto) | 99 | Y -48 – -64 |
| `demonic_ore` | [Demonic](/wiki/minerale-demonic) | 100 | Y -50 – -64 |

Oltre ai metalli ci sono due minerali non metallici, nuovi rispetto a Cursed Souls:

| Id | Nome | Mining | Dove | Uso |
|----|------|--------|------|-----|
| `coal_ore` | Carbone | 0 | Y 100 – 0, comunissimo | Combustibile per forge, forni e torce. In alternativa si usa il carbone di legna o la torba |
| `sulfur_ore` | Zolfo | 40 | Terre vulcaniche e vicino ai laghi di lava | Cenere sulfurea per Alchemy e Magery, polvere nera |

> 💡 Con questi 23 blocchi il catalogo dei minerali è completo: ogni minerale che il gioco conosce ha il suo blocco nel mondo. Cristalli di mana, di ghiaccio e d'ombra e il salgemma non sono minerali da fondere e stanno con le rocce.

> 💎 **Gemme**: come in Ultima Online, scavando qualsiasi vena si può trovare per caso una gemma (ambra, ametista, citrino, tormalina, smeraldo, zaffiro, rubino, zaffiro stellato, diamante). Sono oggetti, non blocchi; le più preziose escono solo negli strati profondi e con Mining alto.

---

## 🌳 Legno

Ogni specie di albero ha tre blocchi: **tronco** (`<specie>_log`), **foglie** (`<specie>_leaves`) e **germoglio** (`<specie>_sapling`), per esempio `oak_log`, `oak_leaves`, `oak_sapling`. Le specie e dove crescono sono in [Alberi](/wiki/alberi). Le foglie autunnali di acero e faggio (`maple_leaves_autumn`, `beech_leaves_autumn`) sono per ora blocchi a sé, perché i blocchi non hanno ancora stati stagionali (vedi [Texture dei blocchi](/wiki/texture-blocchi#nomi-dei-file)).

I tronchi si tagliano in **assi** al banco da carpentiere. Le assi dipendono dal tipo di [legno](/wiki/legni), non dalla specie: una betulla e un faggio danno entrambi legno comune. Come i tronchi, le assi si raccolgono anche a mani nude e rendono il loro oggetto; con l'ascia si fa solo più in fretta.

| Legno | Assi | Da quali alberi (esempi) |
|-------|------|--------------------------|
| [Comune](/wiki/legno-regular) | `plain_planks` | Betulla, faggio, acero, abete, pino, palma, acacia, salice |
| [Quercia](/wiki/legno-oak) | `oak_planks` | Quercia, esterno della quercia antica |
| [Frassino](/wiki/legno-ash) | `ash_planks` | Frassino, argentofoglia |
| [Tasso](/wiki/legno-yew) | `yew_planks` | Tasso, cipresso di palude |
| [Cuoredilegno](/wiki/legno-heartwood) | `heartwood_planks` | Albero cuoredilegno, cuore della quercia antica |
| [Legno sanguigno](/wiki/legno-bloodwood) | `bloodwood_planks` | Albero sanguigno |
| [Legno di brina](/wiki/legno-frostwood) | `frostwood_planks` | Pino di brina |

Oltre a tronchi, foglie e germogli, intorno agli alberi si trovano questi blocchi naturali:

| Id | Nome | Dove | Cosa lascia |
|----|------|------|-------------|
| `mangrove_roots` | Radici di mangrovia | Base delle mangrovie, sopra il fango e l'acqua delle [mangrovie](/wiki/bioma-mangrovie) | Legna da ardere e bastoncini; restano in piedi dopo l'abbattimento e si tagliano a parte |
| `driftwood` | Legno di deriva | Spiagge delle [coste](/wiki/bioma-coste) e delle isole, portato dal mare | Legno comune (si sega in `plain_planks`); nessuna skill richiesta |
| `maple_leaves_autumn` | Foglie di acero autunnali | Chiome degli aceri della [foresta autunnale](/wiki/bioma-foresta-autunnale) | Come le foglie estive: da sole non lasciano nulla, con le forbici si raccolgono intere; rosso fuoco, senza tinta di bioma |
| `beech_leaves_autumn` | Foglie di faggio autunnali | Chiome dei faggi della [foresta autunnale](/wiki/bioma-foresta-autunnale) | Come sopra; color rame, senza tinta di bioma |
| `bee_nest` | Alveare selvatico | Appeso ai rami di querce, betulle e faggi di pianure, foreste e brughiera | Favo: miele (cibo) e cera (candele) |
| `bird_nest` | Nido | Rami degli alberi di foreste e pianure, sporgenze delle scogliere | Uova di uccello (`bird_egg`) in primavera ed estate, bastoncini (vedi [Uccello](/wiki/animale-uccello)) |

---

## 🌿 Piante e vegetazione

Quasi tutte si raccolgono a mani nude, all'istante; erbe e fiori alti si tagliano meglio con le forbici.

| Id | Nome | Dove | Cosa lascia |
|----|------|------|-------------|
| `tall_grass` | Erba alta | Pianure, savana, foreste | A volte semi di grano |
| `fern` | Felce | Foreste, taiga, giungla | Felce |
| `bush` | Cespuglio | Ovunque ci sia erba | Bastoncini |
| `berry_bush` | Cespuglio di bacche | Foreste, taiga | Bacche (cibo, tinture) |
| `heather` | Erica | Brughiera | Fiori di erica (tinture, miele) |
| `lavender` | Lavanda | Pianure, colline | Lavanda (profumi, tinture) |
| `red_poppy` | Papavero | Pianure, prati | Papavero (tinture) |
| `daisy` | Margherita | Pianure, prati | Margherita (tinture) |
| `cactus` | Cactus | Deserto, canyon rossi | Polpa di cactus; ferisce chi lo tocca |
| `reed` | Canna | Rive, paludi | Canne per carta e frecce |
| `lily_pad` | Ninfea | Laghi, paludi | Ninfea; ci si può camminare sopra |
| `kelp` | Alga | Fondali marini | Alga (cibo, fertilizzante) |
| `seagrass` | Posidonia | Fondali bassi | Nulla |
| `red_coral`, `blue_coral`, `yellow_coral` | Coralli | Barriere coralline | Coralli (tinture, decorazione); muoiono fuori dall'acqua |
| `vines` | Liane | Giungla, mangrovie, grotte di muschio | Liane (corde); ci si arrampica |
| `cobweb` | Ragnatela | Grotte, covi dei ragni | **Seta di ragno** (reagente), con la spada, che è il suo attrezzo; con le forbici dà la seta ma ci vuole 3 volte il tempo; a mani nude nulla. Rallenta molto chi ci entra |
| `brown_mushroom`, `red_mushroom` | Funghi | Posti bui, foreste | Funghi (cucina, alchimia) |
| `glow_mushroom` | Fungo luminoso | Grotte, caverne dei funghi | Luce 7; ingrediente alchemico |
| `giant_mushroom_stem`, `giant_mushroom_cap` | Fungo gigante | Caverne dei funghi, isole dei funghi | Funghi in quantità |
| `wheat_sprout`, `wheat_growing`, `wheat_ripe` | Grano (tre stadi) | Campi coltivati, villaggi | 1 grano e da 1 a 3 semi |
| `cotton_plant_sprout`, `cotton_plant_growing`, `cotton_plant_ripe` | Cotone (tre stadi) | Pianure, savana, campi | Cotone per [Tailoring](/wiki/skill-tailoring) |
| `flax_plant_sprout`, `flax_plant_growing`, `flax_plant_ripe` | Lino (tre stadi) | Pianure, rive | Lino per stoffa e corde |

### 🌾 Erbe, muschi e radici

| Id | Nome | Dove | Cosa lascia |
|----|------|------|-------------|
| `dry_grass` | Erba secca | Savana d'estate, margini del deserto, canyon rossi, Terre dei Morti | Paglia secca (esca per il fuoco); prende fuoco facilmente |
| `dead_bush` | Arbusto secco | Deserto, canyon rossi, Terre dei Morti, isole maledette | Bastoncini |
| `large_fern_bottom`, `large_fern_top` | Felce gigante (due metà, un solo oggetto) | Foresta profonda, giungla, taiga (alta 2 blocchi) | Felce |
| `beach_grass` | Ammofila | Dune delle coste e delle isole | Fibre per corde e cesti |
| `gorse` | Ginestrone | Brughiera, cime delle isole rocciose | Fiori gialli (tinture); punge chi ci passa |
| `cottongrass` | Erioforo | Torbiere della brughiera, tundra | Fiocchi bianchi per stoppini e imbottiture |
| `lichen` | Lichene | Rocce di tundra, vette, isole rocciose e faraglioni | Lichene (tinture; cibo d'emergenza) |
| `moss_carpet` | Tappeto di muschio | Foresta profonda, giungla, palude, grotte di muschio | Muschio |
| `silver_moss` | Muschio argenteo | Foresta incantata, sulle rocce e alla base delle argentofoglie | Muschio argenteo (alchimia) |
| `leaf_litter` | Foglie cadute | Suolo della foresta profonda; foresta temperata in autunno | Foglie secche (esca, concime) |
| `hanging_moss` | Muschio pendente | Rami di salici, cipressi di palude e mangrovie | Muschio per stoppini e imbottiture |
| `hanging_roots` | Radici pendenti | Soffitti delle grotte di muschio e delle caverne dei funghi, sotto la terra con radici | Radici |
| `glow_lichen` | Lichene luminoso | Pareti delle grotte di muschio, delle caverne dei funghi e delle grotte allagate | Lichene luminoso; luce 7 |
| `cave_vines` | Liane delle grotte | Soffitti delle grotte di muschio | Bacche luminose (cibo); quando sono mature fanno luce 6 |
| `shelf_fungus` | Fungo a mensola | Tronchi di querce, tassi e alberi morti di foresta profonda e palude; pareti delle caverne dei funghi | Fungo a mensola (esca per accendere il fuoco, alchimia) |

### 🌼 Fiori selvatici

Ogni bioma ha i suoi fiori. Si raccolgono a mani nude e danno il fiore, che serve per tinture, profumi, cucina o alchimia.

| Id | Nome | Dove | Cosa lascia |
|----|------|------|-------------|
| `dandelion` | Tarassaco | Pianure, foresta temperata, coste | Tarassaco (tintura gialla, insalate) |
| `buttercup` | Ranuncolo | Pianure, prati umidi | Ranuncolo (tintura gialla) |
| `cornflower` | Fiordaliso | Pianure, intorno ai campi di grano | Fiordaliso (tintura blu) |
| `sunflower_bottom`, `sunflower_top` | Girasole (due metà, un solo oggetto) | Pianure, savana verde (alto 2 blocchi) | Semi di girasole (cibo, olio) |
| `wild_rose` | Rosa canina | Margini delle foreste, pianure, coste temperate | Petali di rosa (profumi, tintura rosa) e bacche |
| `lily_of_the_valley` | Mughetto | Sottobosco della foresta temperata | Mughetto (profumi); velenoso, per i veleni |
| `bluebell` | Giacinto dei boschi | Foresta temperata e profonda, a tappeti | Giacinto (tintura blu) |
| `foxglove` | Digitale | Radure delle foreste, brughiera | Foglie di digitale (veleni e pozioni) |
| `forget_me_not` | Nontiscordardimé | Rive di fiumi e stagni | Nontiscordardimé (tintura azzurra) |
| `marsh_marigold` | Calta palustre | Palude, rive fangose, pozze della brughiera | Calta (tintura gialla) |
| `orchid` | Orchidea | Giungla, mangrovie, isole tropicali | Orchidea (profumi, tintura magenta) |
| `edelweiss` | Stella alpina | Pendii rocciosi delle montagne sopra Y 140 | Stella alpina (rara, alchimia) |
| `gentian` | Genziana | Prati alti delle montagne, brughiera | Radice di genziana (alchimia, tintura blu) |
| `snowdrop` | Bucaneve | Taiga, margini della tundra; fiorisce anche nella neve | Bucaneve |
| `frost_flower` | Fiore di brina | Tundra e vette innevate, raro | Petali di brina (alchimia del freddo) |
| `moonpetal` | Petalo di luna | Radure della foresta incantata | Petali di luna (alchimia, [Imbuing](/wiki/skill-imbuing)); luce 6, si apre solo di notte |
| `fairy_bell` | Campanella fatata | Foresta incantata, intorno ai cerchi di funghi | Campanella fatata; luce 4 |
| `ember_bloom` | Fiore di brace | Terre vulcaniche, bordi dei laghi di lava | Petali di brace (alchimia del fuoco); luce 5 |
| `aloe` | Aloe | Savana, deserto, isole tropicali | Gel d'aloe (unguenti e bende) |
| `prickly_pear` | Fico d'India | Deserto, canyon rossi, savana arida | Fichi d'India (cibo e acqua); punge chi lo tocca |

### 🍈 Frutti e piante particolari

| Id | Nome | Dove | Cosa lascia |
|----|------|------|-------------|
| `bamboo` | Bambù | Giungla, rive dei fiumi della giungla | Canne di bambù (frecce, impalcature); cresce fino a 12 blocchi |
| `cocoa_pod` | Cacao | Sui tronchi degli alberi della giungla | Fave di cacao (cucina, tintura marrone) |
| `pumpkin` | Zucca | Pianure e foresta temperata, rara, a gruppi | Zucca (cucina, lanterne) e semi |
| `melon` | Melone | Giungla, intorno alle oasi | Fette di melone e semi |
| `pitcher_plant` | Pianta carnivora | Palude, giungla | Liquido digestivo (alchimia: acidi) |
| `shadow_thorns` | Rovi d'ombra | Lande d'Ombra | Spine d'ombra (reagente raro); feriscono e rallentano chi ci passa |
| `grave_mold` | Muffa cadaverica | Terre dei Morti: su tombe, pietra e terra morta, nelle cripte | Muffa cadaverica (reagente della necromanzia); come il muschio sanguigno è uno strato sulla pietra |

---

## 🪸 Coralli e piante d'acqua

Alghe (`kelp`), posidonia (`seagrass`), ninfee (`lily_pad`) e i coralli rosso, blu e giallo sono in [Piante e vegetazione](#piante-e-vegetazione). Le barriere coralline hanno però anche coralli di altri colori, blocchi di corallo su cui crescono, ventagli sulle pareti e la vita dei fondali caldi, come in Minecraft. I coralli vivi **muoiono fuori dall'acqua**: dopo qualche secondo all'aria diventano corallo morto, grigio.

| Id | Nome | Dove | Cosa lascia |
|----|------|------|-------------|
| `purple_coral`, `pink_coral` | Corallo viola, corallo rosa | Barriere coralline | Coralli (tinture, decorazione) |
| `red_coral_block`, `blue_coral_block`, `yellow_coral_block`, `purple_coral_block`, `pink_coral_block` | Blocchi di corallo | Barriere coralline, macchie nell'oceano caldo | Il blocco, solo con il piccone (0,8 s); per ora senza piccone non lasciano nulla |
| `red_coral_fan`, `blue_coral_fan`, `yellow_coral_fan`, `purple_coral_fan`, `pink_coral_fan` | Ventagli di corallo | Pareti e fondali delle barriere coralline | Il ventaglio |
| `dead_coral`, `dead_coral_block`, `dead_coral_fan` | Corallo morto | Dove un corallo resta all'asciutto; secche dell'oceano caldo | Corallo morto (calce, decorazione) |
| `sponge` | Spugna | Fondali della barriera corallina e dell'oceano caldo | Spugna: piazzata, assorbe l'acqua intorno a sé; si asciuga al sole o in un forno |
| `sea_anemone` | Anemone luminoso | Barriere coralline, fondali dell'oceano caldo profondo | Anemone (alchimia); luce 6, la luce naturale dei fondali |
| `duckweed` | Lenticchia d'acqua | Superficie di pozze della palude, mangrovie e stagni | Nulla; copre l'acqua come un tappeto e nasconde chi nuota sotto |

---

## 🧪 Reagenti nel mondo

Gli otto reagenti classici di Ultima Online, usati da [Magery](/wiki/skill-magery) e [Alchemy](/wiki/skill-alchemy), si trovano nel mondo come piante, blocchi o creature. Si possono anche comprare dai mercanti nelle città.

| Reagente | Da dove viene | Id | Dove |
|----------|---------------|----|------|
| Aglio (Garlic) | Pianta | `garlic_plant` | Pianure, foreste, orti |
| Ginseng | Pianta | `ginseng_plant` | Foresta profonda, giungla |
| Radice di mandragora (Mandrake Root) | Pianta | `mandrake_plant` | Paludi, Terre dei Morti, solo di notte si riconosce |
| Belladonna (Nightshade) | Pianta | `nightshade_plant` | Paludi, foreste ombrose |
| Muschio sanguigno (Blood Moss) | Blocco sulla roccia umida | `blood_moss` | Paludi, grotte di muschio |
| Perla nera (Black Pearl) | Ostrica | `pearl_oyster` | Fondali marini, più grandi in acque profonde |
| Cenere sulfurea (Sulfurous Ash) | Setaccio o piccone | `ash_soil`, `sulfur_ore` | Terre vulcaniche |
| Seta di ragno (Spider's Silk) | Ragnatela o ragni uccisi | `cobweb` | Grotte, giungla, covi dei ragni |

Le piante di reagenti ricrescono dopo qualche ora se si lascia la radice: chi le estirpa del tutto le fa sparire da quel punto.

---

## 🔨 Dal blocco all'oggetto

Esempi di come la materia prima diventa oggetto:

| Materia prima | Lavorazione | Risultato | Skill |
|---------------|-------------|-----------|-------|
| Minerale grezzo | Forgia | Lingotti | [Mining](/wiki/skill-mining) (fusione), poi [Blacksmithy](/wiki/skill-blacksmithy) |
| Tronchi | Banco da carpentiere | Assi | [Carpentry](/wiki/skill-carpentry) |
| Sabbia | Fornace | Vetro, bottiglie | [Tinkering](/wiki/skill-tinkering), [Alchemy](/wiki/skill-alchemy) |
| Argilla | Fornace | Mattoni, vasi, tegole | Architecture |
| Pietrisco | Banco da scalpellino | Mattoni di pietra, colonne, statue | Mining e Architecture |
| Cotone, lino, lana | Ruota per filare e telaio | Stoffa | [Tailoring](/wiki/skill-tailoring) |
| Carbone, torba | Combustibile | Fuoco per forge e forni | — |
| Reagenti | Ricette e incantesimi | Pozioni e magie | Alchemy, Magery |

---

## 🎨 Texture

Ogni blocco di questa pagina, compresi tronchi, foglie e germogli degli [alberi](/wiki/alberi), ha le sue texture: 32×32, dall'aspetto realistico ridotte a pixel art (deciso da Aruto il 27/10/2026; il pacchetto base ha ancora 64×64 fino a M2-75), prodotte per ora in modo procedurale dal generatore `texgen` (deciso da Aruto il 24/10/2026). Nomi dei file, facce, colori, tinte di bioma, animazioni e luci sono nella pagina [Texture dei blocchi](/wiki/texture-blocchi).

---

## ❓ FAQ

**D: Posso scavare fino in fondo al mondo?**
R: Sì, fino alla Roccia del Mondo a Y -64. Quella però non si rompe in nessun modo.

**D: Rompere la pietra a mani nude?**
R: Si può, ma piano (tre volte il tempo) e senza ricavare nulla: pietra e minerali lasciano qualcosa solo se rotti con il piccone. Terra, sabbia, tronchi, neve, foglie e piante si raccolgono anche a mani nude e rendono i loro materiali.

**D: Dove trovo mattoni, porte, mobili e forzieri?**
R: Nei [Blocchi da costruzione](/wiki/blocchi-costruzione): il catalogo di tutto ciò che si costruisce con questi blocchi naturali.

**D: Le mod possono aggiungere blocchi?**
R: Sì. Le mod aggiungono blocchi con il proprio prefisso, per esempio `miamod:pietra_lunare`, senza toccare quelli di Soulslands.

---

*Vedi anche: [Il Mondo](/wiki/mondo) | [Blocchi da costruzione](/wiki/blocchi-costruzione) | [Texture dei blocchi](/wiki/texture-blocchi) | [Biomi](/wiki/biomi) | [Alberi](/wiki/alberi) | [Grotte e sottosuolo](/wiki/grotte-e-sottosuolo) | [Minerali](/wiki/minerali) | [Attrezzi](/wiki/attrezzi)*
