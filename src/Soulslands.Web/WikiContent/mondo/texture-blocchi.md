---
title: Texture dei blocchi
slug: texture-blocchi
category: Mondo
visibility: Pubblica
---
# 🎨 Texture dei blocchi
*Come si presenta ogni blocco naturale del mondo: file, facce, colori, luci*

---

## 📋 Indice

- [Panoramica](#panoramica)
- [Regole delle texture](#regole-delle-texture)
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
- [FAQ](#faq)

---

## 📜 Panoramica

Questa pagina è la scheda di aspetto di ogni blocco del mondo di Soulslands: oggi è la descrizione che guida il generatore procedurale di texture (`texgen`, in soulslands-assets), domani anche di chi vorrà disegnare un pacchetto di risorse. Per **ogni blocco naturale** del catalogo dei [Blocchi del mondo](/wiki/blocchi), compresi tronchi, foglie e germogli di tutti gli [alberi](/wiki/alberi), dice quali file servono, quali facce sono diverse, se il blocco prende il colore del bioma, se è animato o emette luce, e com'è fatto, con una piccola palette di colori di riferimento.

In tutto sono **276 blocchi** e **377 file**. Le sezioni sono le stesse dei [Blocchi del mondo](/wiki/blocchi), così ogni blocco si trova allo stesso posto nelle due pagine. I blocchi costruiti (assi, mattoni, mobili) hanno le loro texture con i [Blocchi da costruzione](/wiki/blocchi-costruzione).

> 💡 La palette è un riferimento, non un obbligo: dà il tono del blocco (colore dominante, ombre, luci) perché blocchi vicini stiano bene insieme. Il generatore e chi disegna un pacchetto sono liberi nei dettagli.

---

## 🖌️ Regole delle texture

### Stile

| Regola | Valore |
|--------|--------|
| **Stile** | **Procedurale, per ora** (deciso da Aruto il 24/10/2026): le texture le produce `texgen`, un generatore nostro in soulslands-assets guidato da un solo file di stile, non sono dipinte a mano. Resta l'aspetto fantasy dai colori caldi, con forme grandi e leggibili e luce dall'alto già suggerita nel colore. **Dal 27/10/2026** (deciso da Aruto) ogni texture nasce dettagliata e viene poi **ridotta a pixel art** con un solo pixel e una sola palette, così tutto sembra fatto dalla stessa mano; vale anche per le immagini generate da un'IA, ammesse dal 28/10/2026. Immagini fatte da un artista o da un'IA potranno sostituire quelle generate id per id |
| **Dimensione** | **32×32** pixel per ogni faccia, texture dall'aspetto realistico ridotte a pixel art (deciso da Aruto, 27/10/2026). Le texture animate sono strisce verticali di fotogrammi 32×32 nello stesso PNG. Il pacchetto base ha ancora texture da 64×64 e il client carica solo quelle, finché le attività M2-74 e M2-75 non cambiano formato e client |
| **Formato** | PNG con canale alfa; il gioco le comprime in BC7 al momento della build |
| **Luce e atmosfera** | L'aspetto luminoso alla Valheim (nebbia, luce calda, riflessi) viene dagli **shader**, non dalle texture: le texture restano pulite, senza ombre proiettate e senza sorgenti di luce disegnate da un lato solo |
| **Ripetizione** | Ogni texture di un cubo deve **ripetersi senza giunture** su tutti e quattro i lati: nessun dettaglio grande e riconoscibile che, ripetuto, crei una griglia. I blocchi di superficie (erba, sabbia, neve) vengono anche ruotati a caso dal gioco |
| **Leggibilità** | A distanza un blocco si riconosce dal colore e dalla forma generale, da vicino dai dettagli: prima le masse, poi i dettagli |

### Nomi dei file

I file stanno in `assets/soulslands/textures/block/` e si chiamano come l'id del blocco, con un nome che dice cosa sono: inglese, minuscolo, `snake_case`, prima il soggetto e poi variante e stato. Mai nomi come `tex_17.png` o `final_v2.png`.

| File | Quando |
|------|--------|
| `<id>.png` | Il blocco ha la stessa texture su tutte le facce, oppure è una pianta, una foglia, un minerale |
| `<id>_top.png`, `<id>_side.png`, `<id>_bottom.png` | Le facce sono diverse. Una faccia senza file proprio ne cerca un altro, in quest'ordine: la faccia **sotto** prova `<id>_bottom.png`, poi `<id>.png`, poi `<id>_top.png`; una faccia **laterale** prova `<id>_side.png`, poi `<id>.png`. Così un tronco, che ha solo `oak_log_side.png` e `oak_log_top.png`, mostra gli anelli del taglio anche sotto. Scale, lastre, muri, recinti e cancelletti cercano **prima i propri file** con questa regola e solo se non ne hanno prendono quelli del blocco indicato dal campo `faces_of` (`oak_stairs` usa `oak_planks`); una faccia verso l'alto usa la catena `_top`, verso il basso `_bottom`, di lato `_side`, e una lastra mostra la metà bassa del lato del blocco di partenza. I pannelli di vetro usano `<id>.png` (o la texture del vetro) sulle due facce larghe e `<id>_edge.png` sui bordi sottili; le porte usano `<id>_bottom.png` sulla metà bassa e `<id>_top.png` sulla metà alta; torce e torce a muro `<id>.png` oppure quella di `faces_of`. Per i mobili e i blocchi composti da più scatole il pacchetto dati nomina le texture di ogni faccia, e `{wood}_planks` diventa per esempio `yew_planks.png`: il legno non ha file nuovi né tinte. Dettagli in [ADR-0026](https://github.com/Soulslands/soulslands-game/blob/main/docs/adr/0026-built-block-shapes.md) (sezione 7). Se la tabella nomina la texture di un altro blocco, vince quella (l'erba sotto usa la terra). Se non si trova nulla, il gioco disegna la texture di emergenza `missing` (scacchi viola e neri) |
| `<id>_side_overlay.png` | Solo l'erba: la frangia verde sul lato, colorata dal bioma, sopra la terra di `grass_side.png` |
| `<id>_still.png`, `<id>_flow.png` | Liquidi: superficie ferma e flusso, animati |
| `<id>_01.png`, `<id>_02.png`… | **Alternative casuali** dello stesso blocco, scelte dal gioco per ogni cella. Quando un blocco ha alternative, tutti i suoi file sono numerati e non esiste la versione senza numero |
| `<id>_autumn.png`, `<id>_ripe.png`, `<id>_snowy.png`… | **Stati** del blocco: stagione, maturazione, neve sopra. Un nome, mai un numero. Gli stati dei blocchi da costruzione esistono dalla fase F4b (proprietà nel nome del blocco, [ADR-0026](https://github.com/Soulslands/soulslands-game/blob/main/docs/adr/0026-built-block-shapes.md)) e non cambiano i nomi dei file; per gli altri blocchi, finché non hanno stati, uno stato è un blocco a parte con lo stesso nome di file. Un blocco con colore (vetro colorato) usa **file separati**, mai una tinta: `<id>_<colore>.png`, per esempio `stained_glass_red.png` e `stained_glass_pane_red_edge.png` (16 colori, approvati da Aruto il 26/10/2026) |
| `<file>_emissive.png` | Mappa delle parti che brillano, vedi sotto |

Il numero di fotogrammi e la velocità delle animazioni stanno nel modello del blocco nel pacchetto dati, non nel nome del file.

### Tinta di bioma

Come in Minecraft, alcune texture sono in **toni di grigio-verde** e il gioco le colora secondo il bioma e la stagione, così la stessa erba è verde brillante nelle pianure, giallastra nella savana d'estate e scura nella palude. Le palette di questa pagina mostrano il colore **dopo la tinta**, nella foresta temperata d'estate. I blocchi di ogni tinta sono quelli dei tag `soulslands:tint_grass`, `soulslands:tint_foliage` e `soulslands:tint_water` del pacchetto dati (soulslands-game#149): una mod tinge un suo blocco aggiungendolo a un tag.

| Tinta | Cosa colora | Da dove prende il colore |
|-------|-------------|--------------------------|
| **erba** | La faccia sopra dell'erba e la frangia sul lato, erba alta, felci, felci giganti | Dalla mappa dei colori dell'erba di ogni bioma, che cambia con le stagioni |
| **foglie** | Foglie delle latifoglie comuni (quercia, betulla, faggio, acero, frassino, melo, quercia antica, salice, mangrovia, albero della giungla, acacia, baobab), cespugli, liane | Dalla mappa dei colori delle foglie di ogni bioma e stagione |
| **acqua** | Acqua ferma e in movimento | Dal colore dell'acqua del bioma: turchese nei mari caldi, blu notte in quelli profondi, bruna nelle torbiere (vedi [Oceani](/wiki/oceani#biomi-oceanici) e [Laghi e fiumi](/wiki/laghi-e-fiumi#acqua-per-bioma)) |
| — | Tutto il resto | I colori sono quelli della texture |

### Luce e mappe emissive

Un blocco che emette luce (la colonna **Luce** dice quanto, da 0 a 15, come in [Giorno e notte](/wiki/giorno-e-notte)) ha accanto alla sua texture una **mappa emissiva** con lo stesso nome più `_emissive`, per esempio `glow_mushroom_emissive.png` o `heartwood_log_side_emissive.png`. La mappa è nera dove la texture è normale e colorata dove brilla: lo shader fa risplendere solo quelle parti anche al buio. Se la texture è animata, anche la sua mappa emissiva lo è, con gli stessi fotogrammi.

La lava brilla in ogni punto e non ha una mappa: il suo modello la segna come tutta luminosa. Le crepe calde della roccia infernale sono solo disegnate nella texture: non emette luce.

### Pacchetti di texture e mod

Un pacchetto di risorse o una mod sostituisce una texture mettendo un file **con lo stesso nome** nella stessa cartella del suo pacchetto, per esempio `assets/soulslands/textures/block/stone_01.png`: il gioco usa quello al posto dell'originale. Un pacchetto può anche aggiungere o togliere alternative numerate, ma le alternative di una texture vengono **tutte dallo stesso pacchetto**: il gioco prende quello più in alto nella pila che ha almeno un file di quella texture (`stone.png` o `stone_NN.png`) e non le mescola mai con quelle del pacchetto base. Per cambiarne una, il pacchetto deve quindi fornirle tutte: un pacchetto con il solo `stone_01.png` lascia alla pietra una sola alternativa, mentre uno con `stone_01.png` e `stone_02.png` sostituisce entrambe (scelta del PM per delega di Aruto, 25/10/2026; [ADR-0008](https://github.com/Soulslands/soulslands-game/blob/main/docs/adr/0008-client-crates-terrain-render.md), emendamento 25/10/2026, soulslands-game#146). I blocchi aggiunti da una mod hanno le texture nella cartella della mod (`assets/miamod/textures/block/`).

### Come leggere le tabelle

| Colonna | Significato |
|---------|-------------|
| **File** | I file da produrre. `stone_01..02.png` vuol dire `stone_01.png` e `stone_02.png` |
| **Tinta** | Erba, foglie o acqua se il gioco colora la texture secondo il bioma; — se no |
| **Animata** | Sì se il file è una striscia di fotogrammi |
| **Luce** | La luce emessa e le mappe emissive |
| **Palette** | Da 2 a 4 colori di riferimento: dominante, ombra, luce e, se serve, un accento |
| **Aspetto** | Motivi e materiale da rendere |

---

## 🛡️ Speciali e limiti del mondo

L'aria non ha texture. La barriera ne ha una sola, che vede solo lo staff.

| Id | File | Tinta | Animata | Luce | Palette | Aspetto |
|----|------|-------|---------|------|---------|-----------------|
| `air` | — | — | — | — | — | Nessuna texture: non si disegna |
| `world_rock` | `world_rock.png` | — | — | — | `#1c1a20` `#3a3640` `#5b5560` | Roccia nerissima a strati contorti, venature viola spente: deve sembrare antica e invalicabile |
| `barrier` | `barrier.png` | — | — | — | `#d03030` `#f0f0f0` | Cerchio rosso barrato su fondo trasparente; visibile solo allo staff in modalità costruzione |

---

## 🌱 Terreni

Erba, terriccio, micelio, sentieri e terra arata hanno una faccia **sopra** diversa dai lati; sotto usano la terra (`dirt`). Le argille dei canyon sono rese a **bande orizzontali** che continuano da un blocco all'altro, così le pareti delle mesa sembrano stratificate.

| Id | File | Tinta | Animata | Luce | Palette | Aspetto |
|----|------|-------|---------|------|---------|-----------------|
| `dirt` | `dirt_01..02.png` | — | — | — | `#5a3d26` `#7a5636` `#3e2a1a` `#94704a` | Zolle morbide bruno-calde, sassolini chiari e radichette; macchie larghe |
| `grass` | `grass_top_01..03.png`, `grass_side.png`, `grass_side_overlay.png`, `grass_side_snowy.png`; sotto: `dirt_01..02` | erba | — | — | `#5f8f3a` `#79ab48` `#3f6a2a` `#a5c96a` | Ciuffi d'erba morbidi; sul lato la frangia d'erba ricade sulla terra. Sotto usa la terra |
| `forest_soil` | `forest_soil_top_01..02.png`, `forest_soil_side.png`; sotto: `dirt_01..02` | — | — | — | `#4a3a22` `#6b5230` `#2f2416` `#8a6b3c` | Aghi di pino, foglie secche e rametti sopra terra scura |
| `mud` | `mud.png` | — | — | — | `#3d2e22` `#55402e` `#2a1f17` `#6b5a48` | Fango lucido e bagnato, impronte e pozzette che riflettono il cielo |
| `clay` | `clay.png` | — | — | — | `#8e98a6` `#a9b2bd` `#6e7884` | Argilla grigio-azzurra liscia, crepe sottili e striature umide |
| `red_clay` | `red_clay.png` | — | — | — | `#a4482c` `#c0603c` `#7c3420` | Argilla rossa compatta con striature orizzontali |
| `peat` | `peat.png` | — | — | — | `#3a2a1c` `#4e3824` `#24190f` `#6b5638` | Fibre vegetali scure pressate, filamenti di muschio |
| `moss_block` | `moss_block.png` | — | — | — | `#4f7a2e` `#6a9a3a` `#355a20` `#8cb85a` | Cuscino di muschio soffice, ciuffi tondeggianti con luci gialle |
| `mycelium` | `mycelium_top.png`, `mycelium_side.png`; sotto: `dirt_01..02` | — | — | — | `#7a6478` `#9a8098` `#594657` `#c2b0bf` | Feltro violaceo di ife con puntini chiari di spore |
| `farmland` | `farmland_side.png`, `farmland_bottom.png`, `farmland_top.png`, `farmland_top_wet.png` | — | — | — | `#4a321e` `#64462a` `#2e1f12` `#2e1f14` | Solchi paralleli di terra smossa; versione bagnata più scura e lucida |
| `dirt_path` | `dirt_path_top.png`, `dirt_path_side.png`; sotto: `dirt_01..02` | — | — | — | `#8a7048` `#a68a5c` `#6b5434` `#5a3d26` | Terra battuta chiara con ciottoli e impronte di carri |
| `ash_soil` | `ash_soil.png` | — | — | — | `#4a4440` `#625a54` `#2e2a28` `#8a3a1c` | Terra grigia di cenere con braci spente rossastre qua e là |
| `dead_soil` | `dead_soil.png` | — | — | — | `#6a6870` `#85828a` `#4a484f` | Terra grigia e secca, crepe, nessun filo verde |
| `shadow_soil` | `shadow_soil.png` | — | — | — | `#2a1838` `#3c2850` `#160c20` `#5a3a78` | Terra viola-nera che sembra bere la luce; riflessi viola tenui |
| `coarse_dirt` | `coarse_dirt.png` | — | — | — | `#6a4a2e` `#8a6a48` `#4a3220` `#a8927a` | Terra secca piena di sassi e ghiaietto, poche radici |
| `rooted_dirt` | `rooted_dirt.png` | — | — | — | `#5a3d26` `#7a5636` `#c8a878` `#3e2a1a` | Terra attraversata da radici chiare e contorte |
| `frozen_dirt` | `frozen_dirt.png` | — | — | — | `#5a4a40` `#7a6c66` `#c8d8e6` `#3e3230` | Terra bruno-grigia con cristalli di brina bianco-azzurri nelle crepe |
| `jungle_soil` | `jungle_soil_top.png`, `jungle_soil_side.png`, `jungle_soil_bottom.png` | — | — | — | `#7a3a22` `#9a5232` `#4e7a2a` `#5a2816` | Terriccio rosso grasso con foglioline verdi e radici |
| `enchanted_grass` | `enchanted_grass_top.png`, `enchanted_grass_side.png`; sotto: `dirt_01..02` | — | — | luce 3; `enchanted_grass_top_emissive.png` | `#6fae8e` `#a6d8c0` `#4a8a6e` `#e0f4ff` | Erba verde-acqua con riflessi argentei e minuscole scintille |
| `grave_ash` | `grave_ash.png` | — | — | — | `#8a8a88` `#a8a8a4` `#6a6a68` `#d8d6cc` | Cenere grigia finissima con frammenti d'osso bianchi |
| `ochre_clay` | `ochre_clay.png` | — | — | — | `#c09030` `#d8aa48` `#9a7020` | Banda ocra calda, striature orizzontali come la terracotta |
| `orange_clay` | `orange_clay.png` | — | — | — | `#c8682c` `#e08440` `#a04e1e` | Banda arancione bruciata, striature orizzontali |
| `brown_clay` | `brown_clay.png` | — | — | — | `#6e4a30` `#8a6044` `#523422` | Banda bruno-cioccolato, striature orizzontali |
| `white_clay` | `white_clay.png` | — | — | — | `#e0d6c6` `#f2ebe0` `#bdb0a0` | Caolino bianco-crema, liscio e polveroso |

---

## ❄️ Neve e ghiaccio

Il ghiaccio comune è **semitrasparente**: il canale alfa del PNG dice quanto, e il gioco lo disegna davvero trasparente perché il blocco ha il campo `translucent` (solo client, emendamento all'[ADR-0006](https://github.com/Soulslands/soulslands-game/blob/main/docs/adr/0006-data-pack-format-v1.md) in soulslands-game#140; lo stesso vale per il vetro). Ghiaccio compatto e di ghiacciaio sono opachi: tra i ghiacci solo `ice` è traslucido (scelta del PM per delega di Aruto, 25/10/2026).

| Id | File | Tinta | Animata | Luce | Palette | Aspetto |
|----|------|-------|---------|------|---------|-----------------|
| `snow_layer` |  | — | — | — | — | Strato di neve alto un ottavo di blocco: usa le texture della neve (`snow_01..02`) perché il suo id finisce in `_layer`; i lati mostrano l'ottavo più basso |
| `snow` | `snow_01..02.png` | — | — | — | `#eef3f8` `#d4e0ec` `#b6c8dc` `#ffffff` | Neve soffice, ombre azzurre morbide e scintillii bianchi |
| `ice` | `ice.png` | — | — | — | `#a8d4f0` `#cce8fa` `#7ab4dc` | Ghiaccio semitrasparente con bolle e crepe bianche; canale alfa per la trasparenza |
| `packed_ice` | `packed_ice.png` | — | — | — | `#8cbce0` `#b0d4ee` `#6a9cc8` | Ghiaccio opaco a lastre compresse, crepe fitte |
| `glacier_ice` | `glacier_ice.png` | — | — | — | `#5aa0d8` `#8cc4ec` `#3a7ab8` `#d8f0ff` | Azzurro intenso e profondo, strati antichi, riflessi brillanti |
| `powder_snow` | `powder_snow.png` | — | — | — | `#f4f8fc` `#dce8f2` `#c4d6e6` | Neve più bianca e gonfia della normale, granuli sciolti |
| `icicle` | `icicle.png` | — | — | — | `#cce8fa` `#a8d4f0` `#ffffff` | Punta di ghiaccio pendente, trasparente in cima |
| `ice_crystal` | `ice_crystal.png` | — | — | luce 4; `ice_crystal_emissive.png` | `#9ad8ff` `#d8f4ff` `#5ab0e8` | Grappolo di prismi azzurri affilati, nucleo più chiaro |

---

## 🏖️ Sabbie e ghiaie

Sabbie e ghiaie coprono superfici enormi: per questo sabbia, sabbia rossa e ghiaia hanno due alternative casuali.

| Id | File | Tinta | Animata | Luce | Palette | Aspetto |
|----|------|-------|---------|------|---------|-----------------|
| `sand` | `sand_01..02.png` | — | — | — | `#e1d296` `#ecdfae` `#c8b678` `#f6edc8` | Sabbia dorata, granelli fini e increspature del vento |
| `red_sand` | `red_sand_01..02.png` | — | — | — | `#c06a34` `#d48448` `#9a5028` | Sabbia rosso-arancio, granelli e piccoli sassi |
| `black_sand` | `black_sand.png` | — | — | — | `#2e2c2e` `#46424a` `#1a181a` `#6a6470` | Sabbia nera vulcanica con granelli lucidi |
| `gravel` | `gravel_01..02.png` | — | — | — | `#7a7672` `#9a9590` `#5a5652` `#b8b0a6` | Ciottoli tondeggianti grigi e bruni ben delineati |
| `sandstone` | `sandstone_top.png`, `sandstone_side.png`, `sandstone_bottom.png` | — | — | — | `#dcc88e` `#ecdcaa` `#c4ae70` `#d4bc80` | Strati orizzontali erosi dal vento sul lato, sopra liscia |
| `red_sandstone` | `red_sandstone_top.png`, `red_sandstone_side.png`, `red_sandstone_bottom.png` | — | — | — | `#c46a36` `#d8844c` `#a45228` `#b85e30` | Come l'arenaria, nei toni rosso-ruggine dei canyon |
| `volcanic_ash` | `volcanic_ash.png` | — | — | — | `#4a4848` `#626060` `#2e2c2c` `#7a7470` | Cenere grigio scuro, polvere fine con granelli neri |
| `quicksand` | `quicksand.png` | — | — | — | `#d8c690` `#e6d6a6` `#bca870` | Come la sabbia ma più liscia, con piccoli vortici appena visibili |
| `seashells` | `seashells.png` | — | — | — | `#f0e2d0` `#e8b8a0` `#c8a080` `#ffffff` | Conchiglie sparse su fondo trasparente: tellina rosa, murice, frammenti di madreperla |

---

## 🪨 Rocce degli strati

Le rocce degli strati sono le texture più viste del sottosuolo: devono essere tranquille, senza dettagli che saltano all'occhio, e diventare più scure e taglienti man mano che si scende. Il pietrisco di ogni strato riprende i colori della sua roccia.

| Id | File | Tinta | Animata | Luce | Palette | Aspetto |
|----|------|-------|---------|------|---------|-----------------|
| `stone` | `stone_01..02.png` | — | — | — | `#7a7874` `#949290` `#5e5c5a` `#a8a6a2` | Pietra grigia a grandi lastre, crepe morbide, luce calda sugli spigoli |
| `dark_stone` | `dark_stone.png` | — | — | — | `#4e4c50` `#646268` `#38363a` | Pietra grigio-antracite, crepe più fitte e taglienti |
| `deepslate` | `deepslate.png` | — | — | — | `#3a3c44` `#50525c` `#26282e` | Ardesia a lamine sottili inclinate, blu-grigia |
| `black_basalt` | `black_basalt.png` | — | — | — | `#1e1e22` `#2e2e34` `#121214` `#46464e` | Basalto nero vetroso a colonne strette |
| `hellstone` | `hellstone.png` | — | — | — | `#4a1a14` `#6a2a1c` `#2e0e0a` `#c0401a` | Roccia rosso-scura con crepe calde arancioni (solo disegnate, non emissive) |
| `cobblestone` | `cobblestone.png` | — | — | — | `#7a7874` `#9a9894` `#55534f` | Ciottoli irregolari incastrati, malta scura tra le pietre |
| `dark_cobblestone` | `dark_cobblestone.png` | — | — | — | `#4e4c50` `#68666c` `#323034` | Come il pietrisco, nei toni antracite |
| `cobbled_deepslate` | `cobbled_deepslate.png` | — | — | — | `#3a3c44` `#545660` `#22242a` | Scaglie d'ardesia rotte, spigoli netti |
| `cobbled_basalt` | `cobbled_basalt.png` | — | — | — | `#222226` `#34343a` `#141416` | Schegge di basalto nero, riflessi vetrosi |
| `cobbled_hellstone` | `cobbled_hellstone.png` | — | — | — | `#4a1a14` `#702e20` `#2a0c08` | Frammenti rossi con crepe arancioni disegnate |

---

## ⛰️ Altre rocce

| Id | File | Tinta | Animata | Luce | Palette | Aspetto |
|----|------|-------|---------|------|---------|-----------------|
| `granite` | `granite.png` | — | — | — | `#a06a58` `#bc8670` `#7e4e40` `#d8b0a0` | Granito rosato a grana grossa con macchie chiare e scure |
| `marble` | `marble.png` | — | — | — | `#e8e4dc` `#f6f3ee` `#c8c2b8` `#9a948c` | Marmo bianco con venature grigie morbide e lucide |
| `limestone` | `limestone.png` | — | — | — | `#cfc6ae` `#e0d8c2` `#aea488` | Calcare crema con fossili e porosità |
| `slate` | `slate.png` | — | — | — | `#4a5058` `#5e6670` `#363b42` | Ardesia grigio-blu a lastre parallele |
| `basalt` | `basalt_top.png`, `basalt_side.png` | — | — | — | `#3a3a3e` `#505056` `#26262a` `#3e3e44` | Colonne esagonali: sopra le sezioni, sul lato le colonne verticali |
| `obsidian` | `obsidian.png` | — | — | — | `#1a1024` `#2e1a40` `#0c0812` `#6a4a9a` | Vetro nero-viola con riflessi taglienti e lucidi |
| `pumice` | `pumice.png` | — | — | — | `#b8b0a0` `#cfc8ba` `#948c7c` | Pietra chiara piena di bolle e fori |
| `shadow_stone` | `shadow_stone.png` | — | — | — | `#241a30` `#36284a` `#140e1c` | Pietra viola-nera, venature che si perdono nel buio |
| `dripstone` | `dripstone.png` | — | — | — | `#8a7f72` `#a49888` `#6a6054` | Roccia bruno-crema a colate verticali ondulate |
| `stalactite` | `stalactite.png` | — | — | — | `#8a7f72` `#a49888` `#c8bca8` | Cono pendente a colate, punta più chiara e bagnata |
| `stalagmite` | `stalagmite.png` | — | — | — | `#8a7f72` `#a49888` `#6a6054` | Cono che sale dal suolo, base larga e anelli |
| `mana_crystal` | `mana_crystal.png` | — | — | luce 10; `mana_crystal_emissive.png` | `#6fb7e0` `#a8e0ff` `#3a7ab8` `#e0f8ff` | Grappolo di cristalli azzurri, nucleo luminoso e sfaccettature nette |
| `coral_stone` | `coral_stone.png` | — | — | — | `#e8e0d0` `#f6f0e4` `#c8bca8` | Pietra bianca porosa a cellette di corallo |
| `diorite` | `diorite.png` | — | — | — | `#c8c6c2` `#e2e0dc` `#5a5856` `#9a9894` | Fondo bianco con macchie nere e grigie, sale e pepe |
| `andesite` | `andesite.png` | — | — | — | `#868480` `#9e9c98` `#6a6864` | Grigio uniforme a grana fine, piccoli puntini chiari |
| `tuff` | `tuff.png` | — | — | — | `#7a7464` `#948c7a` `#5e5848` `#a8a08a` | Tufo grigio-giallastro poroso con inclusi scuri |
| `calcite` | `calcite.png` | — | — | — | `#eceae4` `#ffffff` `#cfcac0` | Bianco latte cristallino, piani di sfaldatura e riflessi |
| `mossy_stone` | `mossy_stone.png` | — | — | — | `#7a7874` `#949290` `#4f7a2e` `#6a9a3a` | La pietra comune con chiazze di muschio verde negli incavi |
| `magma_block` | `magma_block.png` | — | sì | luce 3; `magma_block_emissive.png` | `#3a1a12` `#5a2416` `#e0601a` `#ffb040` | Crosta nera spaccata da crepe di magma arancione che pulsano piano |
| `rock_salt` | `rock_salt.png` | — | — | — | `#e8d8d0` `#f6ecea` `#c8a8a0` `#ffffff` | Cristalli di sale rosati e bianchi a cubetti |
| `fulgurite` | `fulgurite.png` | — | — | — | `#c8b890` `#8a7a5a` `#e8e0c8` `#5a5040` | Vetro sabbioso fuso a radici ramificate, bruciature scure |
| `bone_block` | `bone_block_top.png`, `bone_block_side.png` | — | — | — | `#e8e0cc` `#d0c6ae` `#f6f0e0` `#ddd4bc` | Ossa compatte: sopra sezioni con midollo, sul lato ossa lunghe affiancate |
| `shadow_crystal` | `shadow_crystal.png` | — | — | — | `#1a1024` `#3a2458` `#6a4a9a` `#0c0812` | Prismi neri con riflessi viola freddi; nessuna luce, sembra bucare il buio |

---

## 💧 Liquidi

Acqua e lava hanno due texture animate: **ferma** (`_still`, la superficie e le sorgenti) e **in movimento** (`_flow`, i flussi e le cascate). L'acqua è in grigio-azzurro e prende il colore del bioma; la lava brilla tutta e non ha bisogno di una mappa emissiva.

| Id | File | Tinta | Animata | Luce | Palette | Aspetto |
|----|------|-------|---------|------|---------|-----------------|
| `water` | `water_still.png`, `water_flow.png` | acqua | sì | — | `#3a78d8` `#5a98e8` `#a8d0f8` `#d8ecff` | Increspature morbide e riflessi chiari; la schiuma sta nel flusso. In grigio-azzurro e colorata dal bioma |
| `lava` | `lava_still.png`, `lava_flow.png` | — | sì | luce 15; tutta la texture | `#e0601a` `#ffb040` `#a02a0a` `#fff0a0` | Magma denso con crosta scura che si rompe e si richiude; tutta la texture brilla |

---

## 💎 Minerali grezzi

Regola dei minerali: ogni file `<minerale>_ore.png` contiene **solo il minerale** (pepite, cristalli, venature) su fondo trasparente. Il gioco lo disegna sopra la texture della roccia in cui si trova la vena (le rocce ospiti sono i membri del tag `soulslands:ore_hosts`, con la pietra per prima; la roccia è quella più frequente attorno alla cella del minerale, la pietra se nessuna è vicina): pietra, pietra scura, ardesia profonda, basalto nero, roccia infernale, ma anche basalto nelle caverne di lava o ardesia nelle Terre dei Morti. Così un solo file per minerale va bene in ogni strato, e l'id resta lo stesso (vedi [Blocchi del mondo](/wiki/blocchi#minerali-grezzi)). Il minerale ha un bordo scuro sottile e un riflesso chiaro, perché si legga su rocce chiare e scure. Nessun minerale emette luce.

| Id | File | Tinta | Animata | Luce | Palette | Aspetto |
|----|------|-------|---------|------|---------|-----------------|
| `iron_ore` | `iron_ore.png` | — | — | — | `#c8a088` `#a07058` `#e0c8b0` | Pepite bruno-rosate opache; solo il minerale su fondo trasparente |
| `rusty_ore` | `rusty_ore.png` | — | — | — | `#a85a2a` `#c87838` `#7a3a18` | Croste color ruggine, granulose; solo il minerale su fondo trasparente |
| `old_copper_ore` | `old_copper_ore.png` | — | — | — | `#6a8a6a` `#8aa888` `#4a6a4a` | Rame vecchio verde-patina; solo il minerale su fondo trasparente |
| `steel_ore` | `steel_ore.png` | — | — | — | `#9aa4b0` `#c0c8d4` `#6a7480` | Scaglie grigio-acciaio lucide; solo il minerale su fondo trasparente |
| `dull_copper_ore` | `dull_copper_ore.png` | — | — | — | `#9a6a4a` `#b4846a` `#704a30` | Rame spento, bruno opaco; solo il minerale su fondo trasparente |
| `rose_ore` | `rose_ore.png` | — | — | — | `#d88a9a` `#f0b0c0` `#b06070` | Venature rosa brillante; solo il minerale su fondo trasparente |
| `shadow_iron_ore` | `shadow_iron_ore.png` | — | — | — | `#3a3a48` `#5a5a6e` `#24242e` | Ferro nero-bluastro, riflessi freddi; solo il minerale su fondo trasparente |
| `copper_ore` | `copper_ore.png` | — | — | — | `#c87a3a` `#e09a58` `#9a5424` `#5aa888` | Rame arancio vivo con macchie verdi; solo il minerale su fondo trasparente |
| `silver_ore` | `silver_ore.png` | — | — | — | `#c8ccd4` `#eef0f6` `#9aa0aa` | Fili d'argento brillanti; solo il minerale su fondo trasparente |
| `bronze_ore` | `bronze_ore.png` | — | — | — | `#b8863a` `#d4a458` `#8a6024` | Pepite bronzo dorato; solo il minerale su fondo trasparente |
| `orialco_ore` | `orialco_ore.png` | — | — | — | `#d8a04a` `#f0c870` `#a87a2a` `#e86a3a` | Oro-rossastro con riflessi di fuoco; solo il minerale su fondo trasparente |
| `gold_ore` | `gold_ore.png` | — | — | — | `#e8c040` `#ffe080` `#b08a20` | Pepite d'oro grosse e lucenti; solo il minerale su fondo trasparente |
| `blood_rock_ore` | `blood_rock_ore.png` | — | — | — | `#8a1a1a` `#b83030` `#5a0a0a` | Gocce rosso sangue, lucide; solo il minerale su fondo trasparente |
| `agapite_ore` | `agapite_ore.png` | — | — | — | `#b06a8a` `#d090ac` `#844a64` | Cristalli malva; solo il minerale su fondo trasparente |
| `mytheril_ore` | `mytheril_ore.png` | — | — | — | `#6ab0c8` `#9ad8ec` `#3a8098` | Venature azzurro-argento; solo il minerale su fondo trasparente |
| `verite_ore` | `verite_ore.png` | — | — | — | `#5aa05a` `#80c880` `#3a703a` | Cristalli verde smeraldo opaco; solo il minerale su fondo trasparente |
| `black_rock_ore` | `black_rock_ore.png` | — | — | — | `#1a1a1e` `#3a3a44` `#5a4a6a` | Noduli neri lucidi, riflessi viola; solo il minerale su fondo trasparente |
| `titanium_ore` | `titanium_ore.png` | — | — | — | `#b8c4d0` `#dce6f0` `#8a96a4` | Scaglie bianco-azzurre metalliche; solo il minerale su fondo trasparente |
| `valorite_ore` | `valorite_ore.png` | — | — | — | `#3a5ab8` `#5a80e0` `#24388a` | Cristalli blu profondo; solo il minerale su fondo trasparente |
| `cobalt_ore` | `cobalt_ore.png` | — | — | — | `#2a3a9a` `#4a60d0` `#1a2468` `#8aa0ff` | Blu cobalto intenso, scintille chiare; solo il minerale su fondo trasparente |
| `demonic_ore` | `demonic_ore.png` | — | — | — | `#7a1a2a` `#c02a1a` `#2a0a10` `#ff6a2a` | Schegge rosso-nere con bagliori di brace; solo il minerale su fondo trasparente |
| `coal_ore` | `coal_ore.png` | — | — | — | `#1e1e20` `#3a3a3e` `#0e0e10` | Noduli neri opachi, sfaccettati; solo il minerale su fondo trasparente |
| `sulfur_ore` | `sulfur_ore.png` | — | — | — | `#e0d040` `#f6e870` `#b0a020` | Cristalli giallo zolfo, polverosi; solo il minerale su fondo trasparente |

---

## 🌳 Legno

Ogni specie di [albero](/wiki/alberi) ha tronco, foglie e germoglio. Il **tronco** ha la corteccia sui lati (`_side`) e gli anelli del taglio sopra e sotto (`_top`, la stessa texture alle due estremità); un tronco coricato ruota le facce da solo. Le **foglie** sono una texture sola con fondo trasparente tra le foglie. Il **germoglio** è una pianta a croce.


### 🪵 Tronchi

| Id | File | Tinta | Animata | Luce | Palette | Aspetto |
|----|------|-------|---------|------|---------|-----------------|
| `oak_log` | `oak_log_side.png`, `oak_log_top.png` | — | — | — | `#5a4430` `#76583c` `#3e2e1e` `#a88456` | Corteccia scura e nodosa a solchi profondi |
| `birch_log` | `birch_log_side.png`, `birch_log_top.png` | — | — | — | `#e8e4dc` `#2a2624` `#c8c2b6` `#d8c8a0` | Corteccia bianca con segni neri orizzontali |
| `beech_log` | `beech_log_side.png`, `beech_log_top.png` | — | — | — | `#8a8a84` `#a8a8a2` `#6a6a66` `#c8a878` | Corteccia liscia grigio-argento |
| `maple_log` | `maple_log_side.png`, `maple_log_top.png` | — | — | — | `#6a5040` `#84664e` `#4a3628` `#c09a6a` | Corteccia bruna a scaglie |
| `ash_log` | `ash_log_side.png`, `ash_log_top.png` | — | — | — | `#7a7670` `#949088` `#5a5650` `#d4bc8c` | Corteccia grigia a rete di losanghe |
| `apple_log` | `apple_log_side.png`, `apple_log_top.png` | — | — | — | `#6a5444` `#86705c` `#4a3a2e` `#c8a882` | Tronco storto, corteccia a placche |
| `yew_log` | `yew_log_side.png`, `yew_log_top.png` | — | — | — | `#7a3a2a` `#9a5038` `#5a2a1e` `#c86a3a` | Corteccia rosso-bruna che si sfoglia |
| `ancient_oak_log` | `ancient_oak_log_side.png`, `ancient_oak_log_top.png` | — | — | — | `#4a3828` `#6a5038` `#2e2218` `#5a7a3a` | Corteccia enorme e muschiosa |
| `spruce_log` | `spruce_log_side.png`, `spruce_log_top.png` | — | — | — | `#4a3424` `#624630` `#2e2016` `#b08a5a` | Corteccia bruno-scura a scaglie |
| `fir_log` | `fir_log_side.png`, `fir_log_top.png` | — | — | — | `#8a8a90` `#a8a8ae` `#6a6a70` `#c0a070` | Corteccia grigio-argento liscia con bolle di resina |
| `pine_log` | `pine_log_side.png`, `pine_log_top.png` | — | — | — | `#8a4a2a` `#a8643a` `#5e3018` `#c89a5a` | Corteccia rossiccia a placche |
| `juniper_log` | `juniper_log_side.png`, `juniper_log_top.png` | — | — | — | `#6a5a4a` `#867462` `#4a3e32` `#b89a6a` | Tronco contorto a fibre sfilacciate |
| `frost_pine_log` | `frost_pine_log_side.png`, `frost_pine_log_top.png` | — | — | — | `#c8dce8` `#e8f4fa` `#9ab4c8` `#d8e8f0` | Corteccia bianco-azzurra coperta di brina |
| `willow_log` | `willow_log_side.png`, `willow_log_top.png` | — | — | — | `#5a5040` `#746852` `#3e3628` `#b8a070` | Corteccia grigio-bruna a solchi profondi |
| `bog_cypress_log` | `bog_cypress_log_side.png`, `bog_cypress_log_top.png` | — | — | — | `#6a5038` `#86684a` `#4a3626` `#5a6a3a` | Corteccia fibrosa a strisce, base muschiosa |
| `mangrove_log` | `mangrove_log_side.png`, `mangrove_log_top.png` | — | — | — | `#5a4030` `#765640` `#3e2c20` `#a07850` | Corteccia bruna liscia e umida |
| `jungle_log` | `jungle_log_side.png`, `jungle_log_top.png` | — | — | — | `#6a5034` `#866a48` `#4a3622` `#5a7a2a` | Corteccia a strisce con muschio e liane |
| `palm_log` | `palm_log_side.png`, `palm_log_top.png` | — | — | — | `#8a7054` `#a68a6a` `#6a5440` `#c8aa7a` | Tronco ad anelli di fibre intrecciate |
| `acacia_log` | `acacia_log_side.png`, `acacia_log_top.png` | — | — | — | `#7a6a5a` `#968470` `#5a4c40` `#c87a3a` | Corteccia grigia, legno interno arancio |
| `baobab_log` | `baobab_log_side.png`, `baobab_log_top.png` | — | — | — | `#9a8474` `#b4a090` `#7a6656` `#c8aa86` | Corteccia liscia grigio-rosata a pieghe |
| `silverleaf_log` | `silverleaf_log_side.png`, `silverleaf_log_top.png` | — | — | — | `#d8d8dc` `#f0f0f4` `#b0b0b8` `#e0d8c0` | Corteccia pallida quasi bianca, lucente |
| `heartwood_log` | `heartwood_log_side.png`, `heartwood_log_top.png` | — | — | luce 4; `heartwood_log_side_emissive.png`, `heartwood_log_top_emissive.png` | `#6a4a2a` `#8a6a3a` `#c8a840` `#a8d070` | Corteccia bruna con venature verde-oro che brillano |
| `bloodwood_log` | `bloodwood_log_side.png`, `bloodwood_log_top.png` | — | — | — | `#1e1414` `#2e1e1e` `#8a1a1a` `#c02a2a` | Corteccia nera contorta, rivoli di linfa rossa lucida |
| `world_tree_shoot_log` | `world_tree_shoot_log_side.png`, `world_tree_shoot_log_top.png` | — | — | — | `#6a5034` `#8a6a44` `#c8a040` `#e0c060` | Corteccia antica a spirali, venature dorate |
| `dead_tree_log` | `dead_tree_log_side.png`, `dead_tree_log_top.png` | — | — | — | `#8a8480` `#a8a29c` `#5e5a56` `#b0a48e` | Legno grigio scortecciato e spaccato |
| `charred_tree_log` | `charred_tree_log_side.png`, `charred_tree_log_top.png` | — | — | luce 3; `charred_tree_log_side_emissive.png`, `charred_tree_log_top_emissive.png` | `#1a1614` `#2e2622` `#e0601a` `#2a2220` | Legno nero spaccato con crepe di brace |

### 🍃 Foglie

Le foglie delle latifoglie comuni prendono la **tinta di bioma** delle foglie (colonna Tinta) e cambiano con le stagioni come l'erba. Quercia, betulla, faggio, acero, frassino, melo, quercia antica e salice hanno anche una texture **autunnale** (`_autumn`) con i suoi colori veri e senza tinta: in autunno il gioco passa da una all'altra. Conifere e alberi magici, morti o bruciati hanno colori fissi. D'inverno la neve sui rami è uno strato dello shader, non una texture in più.

| Id | File | Tinta | Animata | Luce | Palette | Aspetto |
|----|------|-------|---------|------|---------|-----------------|
| `oak_leaves` | `oak_leaves.png`, `oak_leaves_autumn.png` | foglie | — | — | `#4e7a2e` `#6a9a3a` `#355a20` `#b86a20` | Foglie lobate a ciuffi larghi (tinta di bioma) |
| `birch_leaves` | `birch_leaves.png`, `birch_leaves_autumn.png` | foglie | — | — | `#7aa848` `#9ac860` `#5a8834` `#e0b830` | Foglioline chiare e leggere (tinta di bioma) |
| `beech_leaves` | `beech_leaves.png`, `beech_leaves_autumn.png` | foglie | — | — | `#4a7a30` `#5e9640` `#365a22` `#a8582a` | Chioma densa e tonda (tinta di bioma) |
| `maple_leaves` | `maple_leaves.png`, `maple_leaves_autumn.png` | foglie | — | — | `#5a8a34` `#74a844` `#3e6a24` `#c02a1a` | Foglie a cinque punte (tinta di bioma) |
| `ash_leaves` | `ash_leaves.png`, `ash_leaves_autumn.png` | foglie | — | — | `#5a8a3a` `#78a84e` `#3e6a28` `#d0b040` | Foglie lanceolate leggere (tinta di bioma) |
| `apple_leaves` | `apple_leaves.png`, `apple_leaves_autumn.png`, `apple_leaves_blossom.png`, `apple_leaves_fruit.png` | foglie | — | — | `#5a8a3a` `#74a44a` `#3e6a28` `#c8902a` | Foglie ovali (tinta di bioma) |
| `yew_leaves` | `yew_leaves.png` | — | — | — | `#24442a` `#34583a` `#16301c` `#c02a2a` | Aghi piatti verde scurissimo con bacche rosse |
| `ancient_oak_leaves` | `ancient_oak_leaves.png`, `ancient_oak_leaves_autumn.png` | foglie | — | — | `#3e6a26` `#5a8a34` `#2a4a18` `#a85a1a` | Come la quercia, più cupe e fitte (tinta di bioma) |
| `spruce_leaves` | `spruce_leaves.png` | — | — | — | `#2a4a34` `#3a5e42` `#1a3022` | Aghi blu-verde scuro, rami spioventi |
| `fir_leaves` | `fir_leaves.png` | — | — | — | `#2e5038` `#40664a` `#1e3626` | Aghi verde scuro con rovescio argentato |
| `pine_leaves` | `pine_leaves.png` | — | — | — | `#3a5a34` `#4e7444` `#263e22` | Ciuffi di aghi lunghi |
| `juniper_leaves` | `juniper_leaves.png` | — | — | — | `#5a7a72` `#78968c` `#3e5a54` `#4a5aa8` | Aghi grigio-azzurri con bacche blu |
| `frost_pine_leaves` | `frost_pine_leaves.png` | — | — | — | `#8ab8d0` `#b8dcec` `#5a8ca8` `#ffffff` | Aghi come schegge di ghiaccio, punte bianche |
| `willow_leaves` | `willow_leaves.png`, `willow_leaves_autumn.png` | foglie | — | — | `#6a9a4a` `#88b860` `#4a7834` `#c8b040` | Foglie sottili pendenti (tinta di bioma) |
| `bog_cypress_leaves` | `bog_cypress_leaves.png` | — | — | — | `#4a6a3a` `#5e824a` `#344c28` | Aghi piatti verde oliva |
| `mangrove_leaves` | `mangrove_leaves.png` | foglie | — | — | `#4a7a34` `#62964a` `#345a24` | Foglie spesse e lucide (tinta di bioma) |
| `jungle_leaves` | `jungle_leaves.png` | foglie | — | — | `#3a7a2a` `#52983a` `#26581c` | Foglie grandi a ciuffi (tinta di bioma) |
| `palm_leaves` | `palm_leaves.png` | — | — | — | `#4a8a3a` `#62a84e` `#346a28` | Grandi fronde a piuma |
| `acacia_leaves` | `acacia_leaves.png` | foglie | — | — | `#6a8a34` `#84a444` `#4e6a24` | Foglioline minute, chioma piatta (tinta di bioma) |
| `baobab_leaves` | `baobab_leaves.png` | foglie | — | — | `#5a8a3a` `#74a44a` `#3e6a28` | Ciuffi radi sui rami tozzi (tinta di bioma) |
| `silverleaf_leaves` | `silverleaf_leaves.png` | — | — | luce 6; `silverleaf_leaves_emissive.png` | `#c8d8e0` `#e8f4fa` `#9ab0c0` `#ffffff` | Foglie d'argento con bordi che brillano |
| `heartwood_leaves` | `heartwood_leaves.png` | — | — | — | `#4a8a3a` `#6aa84a` `#c8c050` | Foglie verdi con riflessi dorati |
| `bloodwood_leaves` | `bloodwood_leaves.png` | — | — | — | `#5a1a24` `#7a2a34` `#3a0e14` | Foglie rosso-vino scure |
| `world_tree_shoot_leaves` | `world_tree_shoot_leaves.png` | — | — | luce 8; `world_tree_shoot_leaves_emissive.png` | `#c8a030` `#e8c860` `#9a7a20` `#fff0a0` | Chioma d'oro luminosa |
| `dead_tree_leaves` | `dead_tree_leaves.png` | — | — | — | `#6a625a` `#8a8278` `#4a443e` | Groviglio di rametti secchi su fondo trasparente |
| `charred_tree_leaves` | `charred_tree_leaves.png` | — | — | — | `#2a2420` `#3e3630` `#5a4e46` | Ramaglia bruciata nera e grigia |

### 🌱 Germogli

| Id | File | Tinta | Animata | Luce | Palette | Aspetto |
|----|------|-------|---------|------|---------|-----------------|
| `oak_sapling` | `oak_sapling.png` | — | — | — | `#4e7a2e` `#5a4430` `#6a9a3a` | Piantina con due o tre foglie della specie |
| `birch_sapling` | `birch_sapling.png` | — | — | — | `#7aa848` `#e8e4dc` `#9ac860` | Piantina con due o tre foglie della specie |
| `beech_sapling` | `beech_sapling.png` | — | — | — | `#4a7a30` `#8a8a84` `#5e9640` | Piantina con due o tre foglie della specie |
| `maple_sapling` | `maple_sapling.png` | — | — | — | `#5a8a34` `#6a5040` `#74a844` | Piantina con due o tre foglie della specie |
| `ash_sapling` | `ash_sapling.png` | — | — | — | `#5a8a3a` `#7a7670` `#78a84e` | Piantina con due o tre foglie della specie |
| `apple_sapling` | `apple_sapling.png` | — | — | — | `#5a8a3a` `#6a5444` `#74a44a` | Piantina con due o tre foglie della specie |
| `yew_sapling` | `yew_sapling.png` | — | — | — | `#24442a` `#7a3a2a` `#34583a` | Piantina con due o tre foglie della specie |
| `ancient_oak_sapling` | `ancient_oak_sapling.png` | — | — | — | `#3e6a26` `#4a3828` `#5a8a34` | Piantina con due o tre foglie della specie |
| `spruce_sapling` | `spruce_sapling.png` | — | — | — | `#2a4a34` `#4a3424` `#3a5e42` | Piantina con due o tre foglie della specie |
| `fir_sapling` | `fir_sapling.png` | — | — | — | `#2e5038` `#8a8a90` `#40664a` | Piantina con due o tre foglie della specie |
| `pine_sapling` | `pine_sapling.png` | — | — | — | `#3a5a34` `#8a4a2a` `#4e7444` | Piantina con due o tre foglie della specie |
| `juniper_sapling` | `juniper_sapling.png` | — | — | — | `#5a7a72` `#6a5a4a` `#78968c` | Piantina con due o tre foglie della specie |
| `frost_pine_sapling` | `frost_pine_sapling.png` | — | — | — | `#8ab8d0` `#c8dce8` `#b8dcec` | Piantina con due o tre foglie della specie |
| `willow_sapling` | `willow_sapling.png` | — | — | — | `#6a9a4a` `#5a5040` `#88b860` | Piantina con due o tre foglie della specie |
| `bog_cypress_sapling` | `bog_cypress_sapling.png` | — | — | — | `#4a6a3a` `#6a5038` `#5e824a` | Piantina con due o tre foglie della specie |
| `mangrove_sapling` | `mangrove_sapling.png` | — | — | — | `#4a7a34` `#5a4030` `#62964a` | Piantina con due o tre foglie della specie |
| `jungle_sapling` | `jungle_sapling.png` | — | — | — | `#3a7a2a` `#6a5034` `#52983a` | Piantina con due o tre foglie della specie |
| `palm_sapling` | `palm_sapling.png` | — | — | — | `#4a8a3a` `#8a7054` `#62a84e` | Piantina con due o tre foglie della specie |
| `acacia_sapling` | `acacia_sapling.png` | — | — | — | `#6a8a34` `#7a6a5a` `#84a444` | Piantina con due o tre foglie della specie |
| `baobab_sapling` | `baobab_sapling.png` | — | — | — | `#5a8a3a` `#9a8474` `#74a44a` | Piantina con due o tre foglie della specie |
| `silverleaf_sapling` | `silverleaf_sapling.png` | — | — | — | `#c8d8e0` `#d8d8dc` `#e8f4fa` | Piantina con due o tre foglie della specie |
| `heartwood_sapling` | `heartwood_sapling.png` | — | — | — | `#4a8a3a` `#6a4a2a` `#6aa84a` | Piantina con due o tre foglie della specie |
| `bloodwood_sapling` | `bloodwood_sapling.png` | — | — | — | `#5a1a24` `#1e1414` `#7a2a34` | Piantina con due o tre foglie della specie |
| `world_tree_shoot_sapling` | `world_tree_shoot_sapling.png` | — | — | — | `#c8a030` `#6a5034` `#e8c860` | Piantina con due o tre foglie della specie |
| `dead_tree_sapling` | `dead_tree_sapling.png` | — | — | — | `#6a625a` `#8a8480` `#8a8278` | Piantina con due o tre foglie della specie |
| `charred_tree_sapling` | `charred_tree_sapling.png` | — | — | — | `#2a2420` `#1a1614` `#3e3630` | Piantina con due o tre foglie della specie |

### 🍄 Funghi giganti e altri blocchi degli alberi

| Id | File | Tinta | Animata | Luce | Palette | Aspetto |
|----|------|-------|---------|------|---------|-----------------|
| `giant_mushroom_stem` | `giant_mushroom_stem_top.png`, `giant_mushroom_stem_side.png` | — | — | — | `#e8e0d0` `#d0c6b0` `#f0eade` `#d8d0bc` | Gambo bianco fibroso; sopra la sezione spugnosa |
| `giant_mushroom_cap` | `giant_mushroom_cap.png`, `giant_mushroom_cap_bottom.png` | — | — | — | `#a83a2a` `#c85a3a` `#f0e8d8` `#e0d4bc` | Cappello rosso-bruno a macchie chiare; sotto le lamelle |
| `mangrove_roots` | `mangrove_roots_side.png`, `mangrove_roots_top.png` | — | — | — | `#5a4030` `#765640` `#3e2c20` | Intrico di radici arcuate su fondo trasparente, fango sulle punte |
| `driftwood` | `driftwood_top.png`, `driftwood_side.png` | — | — | — | `#c8beb0` `#e0d8cc` `#a09484` `#b8ae9e` | Legno sbiancato dal sale, fibre in rilievo e crepe |
| `bee_nest` | `bee_nest_top.png`, `bee_nest_side.png`, `bee_nest_bottom.png` | — | — | — | `#c8a050` `#e0bc70` `#3a2a1a` `#a8843e` | Carta di cera ocra a strati, fori d'ingresso scuri sui lati |
| `bird_nest` | `bird_nest.png` | — | — | — | `#8a6a44` `#b8945e` `#6a5032` `#c8d8e0` | Intreccio di rametti e paglia con uova azzurre chiare |

### 🏗️ Assi, casse e postazioni

Blocchi costruiti dai giocatori. Le assi di ogni legno hanno una texture sola su tutte le facce; la cassa e le postazioni hanno `_top`, `_side` e `_bottom`.

| Id | File | Tinta | Animata | Luce | Palette | Aspetto |
|----|------|-------|---------|------|---------|-----------------|
| `plain_planks` | `plain_planks.png` | — | — | — | `#7b6553` `#937b63` `#6b5545` `#b39676` | Assi chiare e spente, venature sottili, giunti scuri |
| `oak_planks` | `oak_planks.png` | — | — | — | `#75573b` `#866644` `#5c4531` `#493625` | Assi di quercia brune, venature dritte, giunti scuri |
| `ash_planks` | `ash_planks.png` | — | — | — | `#999388` `#87837c` `#b6a78a` `#76726c` | Assi grigio chiaro di frassino, venature lunghe |
| `yew_planks` | `yew_planks.png` | — | — | — | `#a65738` `#8b4531` `#693224` `#c3673a` | Assi rossastre di tasso, venature calde |
| `chest` | `chest_top.png`, `chest_side.png`, `chest_bottom.png` | — | — | — | `#74573b` `#5c4531` `#876744` `#9ca6b2` | Cassa di assi brune con fasce e serratura di ferro |
| `station_forge` | `station_forge_top.png`, `station_forge_side.png`, `station_forge_bottom.png` | — | — | — | `#6a6864` `#7a7874` `#474549` `#592219` | Fornace di pietra grigia; sopra il fuoco con la brace |
| `station_anvil` | `station_anvil_top.png`, `station_anvil_side.png`, `station_anvil_bottom.png` | — | — | — | `#929ca8` `#b3bbc7` `#6a7480` `#59626c` | Incudine di ferro azzurrino, piano di battitura chiaro |

---

## 🌿 Piante e vegetazione

Le piante sono **a croce** (campo `model = "cross"` del pacchetto dati): due piani incrociati con la stessa texture, fondo trasparente. Le piante alte 2 blocchi sono due blocchi separati, `<id>_bottom` e `<id>_top`, ciascuno con il proprio `<id>.png`. Le colture hanno un blocco per ogni stadio di crescita, `<id>_sprout`, `<id>_growing` e `<id>_ripe`, ciascuno con il proprio `<id>.png`, non numeri. Ninfee, liane, licheni e tappeti sono **piatti**: un solo piano appoggiato sul blocco o sulla parete.

| Id | File | Tinta | Animata | Luce | Palette | Aspetto |
|----|------|-------|---------|------|---------|-----------------|
| `tall_grass` | `tall_grass_01..02.png` | erba | — | — | `#5f8f3a` `#79ab48` `#3f6a2a` | Ciuffo di fili d'erba curvi |
| `fern` | `fern.png` | erba | — | — | `#4e7a2e` `#6a9a3a` `#355a20` | Fronde di felce aperte a ventaglio |
| `bush` | `bush.png` | foglie | — | — | `#4a7a30` `#62963e` `#5a4030` | Cespuglio tondo di foglioline con rametti |
| `berry_bush` | `berry_bush.png`, `berry_bush_ripe.png` | — | — | — | `#3e6a2a` `#5a8a3a` `#c02a3a` `#6a2aa8` | Cespuglio basso; maturo con bacche rosse e blu |
| `heather` | `heather.png` | — | — | — | `#a05a9a` `#c07ab8` `#4a6a3a` | Spighe fitte di fiorellini viola-rosa su steli verdi |
| `lavender` | `lavender.png` | — | — | — | `#7a6ac8` `#9a8ae0` `#6a8a5a` | Spighe lilla sottili, steli grigio-verdi |
| `red_poppy` | `red_poppy.png` | — | — | — | `#d02a1a` `#f04a2a` `#1a1a1a` `#4a7a2e` | Corolla rossa a petali di carta, centro nero |
| `daisy` | `daisy.png` | — | — | — | `#ffffff` `#f0e8a0` `#e8c030` `#4a7a2e` | Petali bianchi a raggiera, cuore giallo |
| `cactus` | `cactus_top.png`, `cactus_side.png`, `cactus_bottom.png` | — | — | — | `#4a8a3a` `#6aa84e` `#e8e0b0` `#3e7a30` | Costoloni verdi con file di spine chiare |
| `reed` | `reed.png` | — | — | — | `#7a9a4a` `#9ab860` `#c8b878` | Canne verdi a nodi con pennacchio chiaro |
| `lily_pad` | `lily_pad.png` | — | — | — | `#3e7a30` `#5a9a44` `#2a5a20` | Foglia tonda con taglio e nervature, vista dall'alto |
| `kelp` | `kelp.png` | — | — | — | `#5a6a2a` `#7a8a3a` `#3e4a1a` | Nastri d'alga bruno-verde con vescicole |
| `seagrass` | `seagrass.png` | — | — | — | `#4a8a3a` `#62a84e` `#346a28` | Lunghe foglie a nastro ondeggianti |
| `red_coral` | `red_coral.png` | — | — | — | `#d04a4a` `#f07070` `#a02a2a` | Corallo ramificato rosso |
| `blue_coral` | `blue_coral.png` | — | — | — | `#3a6ad0` `#5a8af0` `#24489a` | Corallo a tubi blu |
| `yellow_coral` | `yellow_coral.png` | — | — | — | `#e0c030` `#f6dc60` `#b09020` | Corallo a cervello giallo |
| `vines` | `vines.png` | foglie | — | — | `#3e7a30` `#5a9a44` `#2a5a20` | Liane a foglie a cuore su fondo trasparente |
| `cobweb` | `cobweb.png` | — | — | — | `#e8e8ec` `#c8c8d0` `#ffffff` | Tela radiale con fili spezzati, semitrasparente |
| `brown_mushroom` | `brown_mushroom.png` | — | — | — | `#8a6a4a` `#a8845e` `#e8dcc8` | Fungo bruno a cappello liscio |
| `red_mushroom` | `red_mushroom.png` | — | — | — | `#c02a1a` `#e04a3a` `#ffffff` | Cappello rosso a pois bianchi |
| `glow_mushroom` | `glow_mushroom.png` | — | — | luce 7; `glow_mushroom_emissive.png` | `#4ac0c0` `#8af0e8` `#2a7a80` | Gruppetto di funghi turchesi con cappelli luminosi |
| `wheat_sprout`, `wheat_growing`, `wheat_ripe` | `wheat_sprout.png`, `wheat_growing.png`, `wheat_ripe.png` | — | — | — | `#6a9a3a` `#4a7a2e` `#7aa848` `#9ac060` | Germogli verdi, steli, spighe dorate |
| `cotton_plant_sprout`, `cotton_plant_growing`, `cotton_plant_ripe` | `cotton_plant_sprout.png`, `cotton_plant_growing.png`, `cotton_plant_ripe.png` | — | — | — | `#5a8a3a` `#3e6a2a` `#e8d8a8` `#ffffff` | Pianta verde, boccioli, fiocchi bianchi aperti |
| `flax_plant_sprout`, `flax_plant_growing`, `flax_plant_ripe` | `flax_plant_sprout.png`, `flax_plant_growing.png`, `flax_plant_ripe.png` | — | — | — | `#6a9a4a` `#4a7a34` `#7a9ae0` `#c8b070` | Steli sottili, fiorellini azzurri, steli dorati da raccolto |

### 🌾 Erbe, muschi e radici

| Id | File | Tinta | Animata | Luce | Palette | Aspetto |
|----|------|-------|---------|------|---------|-----------------|
| `dry_grass` | `dry_grass.png` | — | — | — | `#c8b070` `#e0cc8a` `#a08a50` | Ciuffo d'erba gialla e secca, fili spezzati |
| `dead_bush` | `dead_bush.png` | — | — | — | `#8a6a4a` `#a8845e` `#5e4630` | Arbusto di rametti secchi contorti |
| `large_fern_bottom`, `large_fern_top` | `large_fern_bottom.png`, `large_fern_top.png` | erba | — | — | `#4e7a2e` `#6a9a3a` `#355a20` `#5a8a34` | Felce alta due blocchi, fronde che si aprono in alto |
| `beach_grass` | `beach_grass.png` | — | — | — | `#9ab070` `#b8c88a` `#c8b878` | Fili lunghi e rigidi verde-salvia piegati dal vento |
| `gorse` | `gorse.png` | — | — | — | `#4a6a2e` `#e8c030` `#f6dc60` | Cespuglio spinoso scuro coperto di fiorellini gialli |
| `cottongrass` | `cottongrass.png` | — | — | — | `#ffffff` `#e8e8e0` `#6a8a4a` | Fiocchi bianchi lanosi in cima a steli sottili |
| `lichen` | `lichen.png` | — | — | — | `#9aa86a` `#c8c890` `#d8a840` `#6a7a4a` | Rosette piatte verde-grigio e arancio, su fondo trasparente |
| `moss_carpet` | `moss_carpet.png` | — | — | — | `#4f7a2e` `#6a9a3a` `#8cb85a` | Tappeto sottile di muschio a ciuffi |
| `silver_moss` | `silver_moss.png` | — | — | — | `#a8c0b8` `#d0e4e0` `#7a9a90` | Muschio argento-verde con punte che riflettono la luce |
| `leaf_litter` | `leaf_litter.png` | — | — | — | `#a8682a` `#c88a3a` `#7a4a1e` `#d8b050` | Foglie secche sparse di quercia e acero, su fondo trasparente |
| `hanging_moss` | `hanging_moss.png` | — | — | — | `#8a9a6a` `#a8b88a` `#6a7a4e` | Barbe di muschio grigio-verde pendenti |
| `hanging_roots` | `hanging_roots.png` | — | — | — | `#a8845e` `#c8a878` `#7a5a3a` | Radici sottili pendenti, terra sulle punte |
| `glow_lichen` | `glow_lichen.png` | — | — | luce 7; `glow_lichen_emissive.png` | `#6ac8a0` `#a8f0d0` `#3a8a6a` | Macchie di lichene con puntini verdi-azzurri luminosi |
| `cave_vines` | `cave_vines.png`, `cave_vines_berries.png` | — | — | luce 6; `cave_vines_berries_emissive.png` | `#3e6a2a` `#5a8a3a` `#f0a030` `#ffd060` | Liane pendenti; con bacche tonde arancio-oro quando sono mature |
| `shelf_fungus` | `shelf_fungus.png` | — | — | — | `#a87a4a` `#c8a070` `#6a4a2a` `#e8d8b8` | Mensole a ventaglio con anelli bruni e bordo chiaro |

### 🌼 Fiori selvatici

| Id | File | Tinta | Animata | Luce | Palette | Aspetto |
|----|------|-------|---------|------|---------|-----------------|
| `dandelion` | `dandelion.png` | — | — | — | `#f0c020` `#ffe060` `#4a7a2e` | Testa gialla piena, foglie dentate |
| `buttercup` | `buttercup.png` | — | — | — | `#f0d030` `#fff080` `#4a7a2e` | Coppette giallo lucido |
| `cornflower` | `cornflower.png` | — | — | — | `#3a6ad8` `#6a90f0` `#4a7a2e` | Fiore blu a raggi frangiati |
| `wild_rose` | `wild_rose.png` | — | — | — | `#e88aa0` `#f8b8c8` `#4a6a2e` `#c02a2a` | Rose semplici rosa a cinque petali, spine e bacche rosse |
| `lily_of_the_valley` | `lily_of_the_valley.png` | — | — | — | `#ffffff` `#e8f0e0` `#3e7a30` | Campanelle bianche su stelo arcuato |
| `bluebell` | `bluebell.png` | — | — | — | `#4a5ac8` `#7a8ae8` `#3e7a30` | Campanule blu-viola pendenti |
| `foxglove` | `foxglove.png` | — | — | — | `#b04a9a` `#d878c0` `#f0e0f0` `#4a7a2e` | Spiga di campane magenta con puntini interni |
| `forget_me_not` | `forget_me_not.png` | — | — | — | `#6aa8f0` `#a8d0ff` `#f0e040` `#4a7a2e` | Fiorellini azzurri con occhio giallo |
| `marsh_marigold` | `marsh_marigold.png` | — | — | — | `#f0c020` `#ffe060` `#2e6a24` | Coppe gialle su foglie tonde lucide |
| `orchid` | `orchid.png` | — | — | — | `#c83a9a` `#e870c0` `#ffffff` `#3e7a30` | Fiore magenta elegante a labello |
| `edelweiss` | `edelweiss.png` | — | — | — | `#f0f0e8` `#d8d8c8` `#c8c070` `#7a8a6a` | Stella di brattee bianche lanose |
| `gentian` | `gentian.png` | — | — | — | `#2a3ab8` `#4a5ae0` `#3e6a2a` | Trombette blu intenso |
| `snowdrop` | `snowdrop.png` | — | — | — | `#ffffff` `#e0f0e0` `#3e7a30` | Gocce bianche pendenti con punta verde |
| `frost_flower` | `frost_flower.png` | — | — | — | `#b8e0ff` `#e8f8ff` `#7ab0e0` | Petali di ghiaccio trasparenti con brina |
| `moonpetal` | `moonpetal.png` | — | — | luce 6; `moonpetal_emissive.png` | `#c8d8ff` `#f0f4ff` `#8aa0e0` `#3e6a5a` | Corolla bianco-lunare aperta, venature che brillano |
| `fairy_bell` | `fairy_bell.png` | — | — | luce 4; `fairy_bell_emissive.png` | `#d8a8f0` `#f0d8ff` `#6a9a6a` | Campanelle lilla con un punto di luce dentro |
| `ember_bloom` | `ember_bloom.png` | — | — | luce 5; `ember_bloom_emissive.png` | `#e04a1a` `#ff9a3a` `#2a1a14` | Petali a fiamma su stelo nero carbonizzato |
| `aloe` | `aloe.png` | — | — | — | `#6a9a7a` `#8ab89a` `#e0e8d8` | Rosetta di foglie carnose verde-azzurre a bordi dentati |
| `prickly_pear` | `prickly_pear.png` | — | — | — | `#5a8a3a` `#7aa84e` `#c02a4a` `#e8e0b0` | Pale ovali con spine e frutti rosso-viola |
| `sunflower_bottom`, `sunflower_top` | `sunflower_bottom.png`, `sunflower_top.png` | — | — | — | `#4a7a2e` `#62963e` `#f0c020` `#ffe060` | Stelo e foglie sotto, grande disco giallo sopra |

### 🍈 Frutti e piante particolari

| Id | File | Tinta | Animata | Luce | Palette | Aspetto |
|----|------|-------|---------|------|---------|-----------------|
| `bamboo` | `bamboo_side.png`, `bamboo_top.png`, `bamboo_leaves.png` | — | — | — | `#7aa83a` `#9ac860` `#5a8028` `#c8e090` | Canna verde a nodi chiari; ciuffi di foglie sottili |
| `cocoa_pod` | `cocoa_pod.png` | — | — | — | `#c8742a` `#e09a4a` `#7a4a1e` | Baccello costoluto arancio-bruno |
| `pumpkin` | `pumpkin_top.png`, `pumpkin_side.png` | — | — | — | `#c87a2a` `#4a6a2a` `#d8842a` `#f0a040` | Spicchi arancioni a coste; sopra il picciolo |
| `melon` | `melon_top.png`, `melon_side.png` | — | — | — | `#5a9a3a` `#3e7a2a` `#4a8a2e` `#7ab84e` | Buccia verde a strisce scure e chiare |
| `pitcher_plant` | `pitcher_plant.png` | — | — | — | `#7a9a3a` `#a83a3a` `#c8d870` | Ascidi a brocca verdi e rosso-vino con coperchio |
| `shadow_thorns` | `shadow_thorns.png` | — | — | — | `#2a1838` `#4a2a5a` `#8a5aa8` | Rovi neri-viola con spine dalle punte chiare |
| `grave_mold` | `grave_mold.png` | — | — | — | `#7a8a6a` `#a8b890` `#c8d0b0` `#4a5440` | Muffa grigio-verde pallida a macchie vellutate |

---

## 🪸 Coralli e piante d'acqua

Coralli e ventagli sono piante a croce o piatte; i blocchi di corallo sono cubi. Il corallo morto ha una sola texture grigia per tipo, uguale per tutti i colori.

| Id | File | Tinta | Animata | Luce | Palette | Aspetto |
|----|------|-------|---------|------|---------|-----------------|
| `purple_coral` | `purple_coral.png` | — | — | — | `#8a3ac0` `#a860e0` `#5a2088` | Corallo a dita viola |
| `pink_coral` | `pink_coral.png` | — | — | — | `#e86aa0` `#f898c0` `#b04070` | Corallo a frange rosa |
| `red_coral_block` | `red_coral_block.png` | — | — | — | `#c83a3a` `#e86060` `#902020` | Blocco poroso di polipi rossi, celle e piccoli tentacoli |
| `blue_coral_block` | `blue_coral_block.png` | — | — | — | `#3a5ac8` `#5a80e8` `#24388a` | Blocco poroso di polipi blu, celle e piccoli tentacoli |
| `yellow_coral_block` | `yellow_coral_block.png` | — | — | — | `#d8b020` `#f0d050` `#a88010` | Blocco poroso di polipi gialli, celle e piccoli tentacoli |
| `purple_coral_block` | `purple_coral_block.png` | — | — | — | `#7a30b0` `#9a50d0` `#501880` | Blocco poroso di polipi viola, celle e piccoli tentacoli |
| `pink_coral_block` | `pink_coral_block.png` | — | — | — | `#d85a90` `#f088b0` `#a03060` | Blocco poroso di polipi rosa, celle e piccoli tentacoli |
| `red_coral_fan` | `red_coral_fan.png` | — | — | — | `#d04a4a` `#f07070` | Ventaglio a rete sottile, bordo più chiaro |
| `blue_coral_fan` | `blue_coral_fan.png` | — | — | — | `#3a6ad0` `#5a8af0` | Ventaglio a rete sottile, bordo più chiaro |
| `yellow_coral_fan` | `yellow_coral_fan.png` | — | — | — | `#e0c030` `#f6dc60` | Ventaglio a rete sottile, bordo più chiaro |
| `purple_coral_fan` | `purple_coral_fan.png` | — | — | — | `#8a3ac0` `#a860e0` | Ventaglio a rete sottile, bordo più chiaro |
| `pink_coral_fan` | `pink_coral_fan.png` | — | — | — | `#e86aa0` `#f898c0` | Ventaglio a rete sottile, bordo più chiaro |
| `dead_coral` | `dead_coral.png` | — | — | — | `#9a948c` `#b8b2a8` `#78726a` | Il corallo ramificato sbiancato e grigio |
| `dead_coral_block` | `dead_coral_block.png` | — | — | — | `#9a948c` `#b8b2a8` `#78726a` | Blocco poroso grigio, celle vuote |
| `dead_coral_fan` | `dead_coral_fan.png` | — | — | — | `#9a948c` `#b8b2a8` | Ventaglio grigio spezzato |
| `sponge` | `sponge.png` | — | — | — | `#d8c040` `#e8d870` `#a89020` | Spugna gialla a pori grandi e irregolari |
| `sea_anemone` | `sea_anemone.png` | — | — | luce 6; `sea_anemone_emissive.png` | `#e070c0` `#ffa8e0` `#6a3a8a` `#a8f0ff` | Tentacoli morbidi rosa-viola con punte luminose |
| `duckweed` | `duckweed.png` | — | — | — | `#6aa83a` `#8ac850` `#4a8028` | Foglioline tonde minuscole sparse sull'acqua, su fondo trasparente |

---

## 🧪 Reagenti nel mondo

| Id | File | Tinta | Animata | Luce | Palette | Aspetto |
|----|------|-------|---------|------|---------|-----------------|
| `garlic_plant` | `garlic_plant.png` | — | — | — | `#6a9a4a` `#e8e4d8` `#4a7a34` | Foglie a nastro e testa bianca che affiora |
| `ginseng_plant` | `ginseng_plant.png` | — | — | — | `#4a7a2e` `#c02a2a` `#d8b880` | Foglie palmate con grappolo di bacche rosse |
| `mandrake_plant` | `mandrake_plant.png` | — | — | — | `#3e5a2a` `#5a7a3a` `#8a6a4a` | Rosetta di foglie larghe e grinzose, radice appena visibile |
| `nightshade_plant` | `nightshade_plant.png` | — | — | — | `#2e4a2a` `#5a2a7a` `#1a1a1e` | Fiori viola a stella e bacche nere lucide |
| `blood_moss` | `blood_moss.png` | — | — | — | `#8a1a24` `#b03040` `#5a0e14` | Muschio rosso scuro a ciuffi umidi |
| `pearl_oyster` | `pearl_oyster.png` | — | — | — | `#7a7068` `#9a9088` `#e8e4f0` `#1a1a2e` | Valve grigie rugose; aperta mostra madreperla e la perla nera |

---

## ❓ FAQ

**D: Perché 64×64 e non di più?**
R: Lo stile del gioco vive di forme grandi, non di dettagli minuti: a 64×64 una texture è nitida da vicino e leggera per la scheda video anche con migliaia di blocchi a schermo. La bellezza dell'insieme viene dagli shader.

**D: Posso disegnare un blocco con più alternative di quelle della tabella?**
R: Sì, se servono a spezzare la ripetizione su grandi superfici. Si numerano di seguito (`_03`, `_04`) e vanno aggiunte qui.

**D: Perché i minerali sono solo un ritaglio trasparente?**
R: Perché la stessa vena attraversa strati diversi: con il ritaglio sopra la roccia dello strato una vena di Iron sta bene nella pietra in superficie e nel basalto nero dell'Abisso, senza generare cinque versioni dello stesso minerale.

**D: Chi decide i colori della tinta di ogni bioma?**
R: Le mappe dei colori dell'erba, delle foglie e dell'acqua sono dati del gioco, una per bioma e stagione, e anche quelle si possono cambiare con un pacchetto di risorse.

**D: Manca la texture di un blocco nuovo?**
R: Ogni blocco aggiunto ai [Blocchi del mondo](/wiki/blocchi) va aggiunto anche qui, con i suoi file e la sua palette, nella stessa modifica.

---

*Vedi anche: [Blocchi del mondo](/wiki/blocchi) | [Blocchi da costruzione](/wiki/blocchi-costruzione) | [Alberi](/wiki/alberi) | [Biomi](/wiki/biomi) | [Giorno e notte](/wiki/giorno-e-notte)*
