---
title: Strutture del mondo
slug: strutture
category: Mondo
visibility: Pubblica
---
# 🏰 Strutture del mondo
*Feudi, santuari, rovine e tesori: ciò che il mondo costruisce da solo*

---

## 📋 Indice

- [Panoramica](#panoramica)
- [Come leggere le schede](#come-leggere-le-schede)
- [Blocchi protetti e rinforzati](#blocchi-protetti-e-rinforzati)
- [Feudi, villaggi e strade](#feudi-villaggi-e-strade)
- [Santuari](#santuari)
- [Strutture di superficie per bioma](#strutture-di-superficie-per-bioma)
- [Strutture sotterranee e dungeon](#strutture-sotterranee-e-dungeon)
- [Strutture oceaniche e delle isole](#strutture-oceaniche-e-delle-isole)
- [Mappe del tesoro e tesori sepolti](#mappe-del-tesoro-e-tesori-sepolti)
- [Frequenza e luoghi](#frequenza-e-luoghi)
- [Strutture per bioma](#strutture-per-bioma)

---

## 📜 Panoramica

Oltre al terreno, il generatore del [mondo](/wiki/mondo) costruisce da solo le **strutture**: feudi (le città murate) e villaggi, santuari, accampamenti, torri, templi, dungeon, relitti e tesori sepolti. Ogni struttura nasce insieme ai chunk che la contengono, sempre identica per lo stesso seme, e da quel momento fa parte del mondo come una montagna: ciò che i giocatori scavano, saccheggiano o bonificano resta così per tutti (vedi [Persistenza del mondo](/wiki/persistenza-del-mondo)). Una struttura che attraversa più chunk viene decisa dal seme della zona in cui comincia, così i suoi pezzi combaciano sempre.

L'idea viene da Minecraft, l'anima da Ultima Online: feudi presidiati dalle guardie, santuari delle otto virtù, dungeon classici e mappe del tesoro. Le strutture sono fatte degli stessi blocchi che usano i giocatori: muri, tetti, porte, mobili, luci e forzieri sono nel catalogo dei [Blocchi da costruzione](/wiki/blocchi-costruzione).

| In Minecraft | In Soulslands | In Minecraft | In Soulslands |
|--------------|---------------|--------------|---------------|
| Villaggio | Villaggio e feudo | Villaggio zombie | Villaggio abbandonato |
| Avamposto dei predoni | Accampamento di briganti | Magione nel bosco | Fortezza orchesca |
| Tempio del deserto | Piramide e tomba del deserto | Tempio della giungla | Tempietto della giungla |
| Capanna della strega | Capanna della strega | Igloo | Rifugio di neve |
| Miniera abbandonata | Miniera abbandonata | Roccaforte | Roccaforte antica |
| Portale in rovina | Portale demoniaco | Città antica | Città perduta dell'Abisso |
| Rovine dei sentieri | Rovine sepolte | Relitto e rovine oceaniche | Relitti e rovine sommerse |
| Monumento oceanico | Tempio sommerso | Tesoro sepolto | Tesori dei pirati e mappe del tesoro |

> ⚠️ Le strutture del mondo non vanno confuse con le **strutture rinforzate** che le gilde costruiscono con il [Sistema di costruzioni](/wiki/sistema-costruzioni): questa pagina parla solo di ciò che genera il mondo.

---

## 🔖 Come leggere le schede

| Voce | Significato |
|------|-------------|
| **Id** | Il nome della struttura nei dati del gioco, nel formato `soulslands:nome` come i [blocchi](/wiki/blocchi). Le mod aggiungono le proprie con il loro prefisso |
| **Rarità** | Distanza media tra due strutture dello stesso tipo, dove il bioma lo permette: **comune** 300–600 blocchi, **non comune** 600–1.500, **rara** 1.500–4.000, **molto rara** 4.000–10.000, **leggendaria** una sola per regione di circa 10.000 × 10.000 blocchi |
| **Dimensione** | **Piccola** fino a 16 × 16 blocchi (un chunk), **media** fino a 48 × 48, **grande** fino a 128 × 128, **enorme** oltre |
| **Abitanti** | Creature generate con la struttura: non scompaiono mai e, se uccise, tornano poco alla volta quando nessun giocatore è vicino (vedi [Spawn delle creature](/wiki/spawn-creature)) |
| **Boss** | Il capo della struttura, nella sala più protetta: dopo l'uccisione torna in 2–6 ore reali |
| **Bottino** | Il contenuto tipico dei forzieri, che dipende dal tipo di struttura e dalla profondità, mai dalla distanza dai feudi (vedi [Frequenza e luoghi](#frequenza-e-luoghi)) |
| **Blocchi** | 🔒 protetti, 🧱 rinforzati, ⛏️ normali (vedi sotto) |

> 💡 Rarità e dimensioni sono indicative: possono cambiare con il bilanciamento e con i pacchetti dati del server.

---

## 🛡️ Blocchi protetti e rinforzati

| Tipo | Cosa si può fare | Esempi |
|------|------------------|--------|
| 🔒 **Protetti** | Nessuno può scavarli, piazzarvi blocchi o danneggiarli, nemmeno con esplosioni o magie | Feudi, santuari, carovaniere, porto dei bucanieri |
| 🧱 **Rinforzati** | Si scavano, ma da 5 a 10 volte più piano della roccia dello stesso strato e solo con un piccone adatto; rotti lasciano soltanto pietrisco | Muri, pavimenti e soffitti di dungeon, fortezze, templi, torri, piramidi, città sommerse |
| ⛏️ **Normali** | Si scavano e si raccolgono come qualsiasi blocco del mondo | Villaggi (terra libera), accampamenti, capanne, fattorie, rovine, relitti, cerchi di pietre |

- I muri rinforzati seguono la regola di [Grotte e sottosuolo](/wiki/grotte-e-sottosuolo#dungeon-generati): molto più resistenti della roccia, ma un minatore paziente può aprirsi un ingresso laterale ed evitare le trappole dell'entrata.
- Porte e forzieri chiusi si aprono con [Lockpicking](/wiki/skill-lockpicking) o con la chiave che porta il boss; le trappole si trovano con [Detect Hidden](/wiki/skill-detect-hidden) e si disinnescano con [Remove Trap](/wiki/skill-remove-trap).
- I forzieri delle strutture abitate si riempiono di nuovo qualche ora dopo essere stati svuotati, quando nessun giocatore è vicino. Quelli di relitti, tombe e tesori si svuotano una volta sola.
- Gli accampamenti all'aperto (briganti, predoni nomadi, orchi, selvaggi, lizardman, ciclopi, pirati) hanno un **cuore**: lo stendardo, il totem o il falò del capo. Se il capo è morto e il cuore viene distrutto, l'accampamento è **bonificato** e gli abitanti non tornano più. Dungeon, torri e templi non si bonificano mai.
- Una [Pietra del Territorio](/wiki/pietra-territorio-gilda) va piazzata ad almeno 2 chunk da feudi, zone di guardia e ingressi dei dungeon.

> 💡 Bonificare gli accampamenti di una zona è il primo passo per fondarvi una [città di gilda](/wiki/citta-di-gilda): quelli lasciati attivi vicino ai confini possono far partire le [invasioni](/wiki/spawn-creature#spawn-rari-e-boss).

---

## 🏰 Feudi, villaggi e strade

Le città che genera il mondo si chiamano **feudi**: grandi città murate in stile medievale, governate da un signore NPC. Intorno a loro nascono i **villaggi**, senza mura, e dalle porte dei feudi partono le **strade**. Le città dei giocatori sono un'altra cosa: le [città di gilda](/wiki/citta-di-gilda). Le regole di questa sezione sono le decisioni di Aruto del 02/11/2026 su feudi, dove nascono, villaggi, strade, eccezioni dal seme e fine dei moongate, portate nel generatore da [ADR-0033](https://github.com/Soulslands/soulslands-game/blob/main/docs/adr/0033-walled-settlements-gate-roads.md).

| Struttura e id | Dove | Rarità, dimensione | Abitanti e servizi | Blocchi |
|----------------|------|--------------------|--------------------|---------|
| **Feudo** `soulslands:fief` | Terre temperate; deserti, savane, taiga e tundra; coste e grandi isole (con porto e cantiere navale); foreste profonde, giungle e paludi; vette innevate | Circa uno ogni 20 × 20 km, mai a meno di 16 km da un altro; enorme: mura di circa 300 × 300 blocchi con almeno 40 strutture dentro | 30–60 NPC: il signore, guardie, guaritori, banchiere, fabbro, sarto, falegname, alchimista, costruttore di archi, istruttori di skill, taverna e locanda | 🔒 |
| **Feudo in rovina** `soulslands:ruined_fief` | Gli stessi biomi dei feudi | Molto raro: circa uno ogni cinque feudi vivi | Mura crollate, mostri e tesori | — |
| **Villaggio** `soulslands:village` | Nel territorio di un feudo; circa uno su quattro è isolato, lontano da ogni feudo | Molto raro: 3–6 nel territorio di un feudo; 8–15 strutture | Case e campi, un pozzo con una piccola piazza, una bottega, una piccola locanda o cappella con un guaritore; nessuna guardia | ⛏️ |
| **Villaggio di pescatori** `soulslands:fishing_village` | [Coste](/wiki/bioma-coste), foci dei fiumi | Raro (insediamento speciale); media | Pescatori, mercante di canne e reti, costruttore di barche, locanda e molo | 🔒 |
| **Strada dei feudi** `soulslands:fief_road` | Parte solo dalle porte dei feudi | Al massimo 2.000 blocchi dalla porta | Cartelli con i nomi, ponti sui [fiumi](/wiki/laghi-e-fiumi), locande di posta e santuari lungo la strada | ⛏️ |

### 🏯 Il feudo

- **Mura.** Pietra alta circa 10–12 blocchi, con camminamento, merli e torri agli angoli e lungo il perimetro; il materiale dipende dal bioma e la forma segue il terreno. Il castello del signore sorge sul punto più alto.
- **Porte.** Da 2 a 4, con portone, saracinesca e guardie NPC: una per ogni direzione in cui può partire una strada, nessuna verso una scogliera o verso il mare.
- **Dentro le mura.** Il castello, una chiesa o cattedrale (i guaritori resuscitano lì), la piazza del mercato con la fontana, la taverna e la locanda (logout sicuro), le case degli NPC con piccoli giardini e qualche villa, le botteghe (fabbro, sarto, falegname, alchimista, costruttore di archi), la banca, la caserma, l'armeria e le scuderie, le sale delle gilde e delle scuole con gli istruttori di skill. C'è il santuario delle virtù (con virtù, colore e mantra) e le guardie con la zona protetta: vedi [Guardie cittadine](/wiki/guardie-cittadine). Niente moongate e niente colonne di confine.
- **Stile.** Cambia con il bioma. Sulle coste e sulle isole grandi c'è il porto con il cantiere navale; sulle vette innevate il feudo è una fortezza su un altopiano, con mura lungo le creste e strade a tornanti, oppure una città in parte scavata nella roccia.
- **Fuori dalle mura.** Ogni feudo pesca a caso tra campi e fattorie, mulini, un piccolo borgo e un fossato; alcuni non hanno nulla.
- **Nome.** Ogni feudo ha un nome medievale generato: compare quando ci entri, sui cartelli delle strade e sulle mappe disegnate con [Cartography](/wiki/skill-cartography). Il gioco non ha una mappa automatica del mondo.
- **Rovine.** I feudi in rovina hanno le mura cadute, mostri e tesori. Intorno ci sono villaggi abbandonati e tratti di strada spezzati e invasi dalla vegetazione.
- **Il signore.** Il feudo è governato da un signore NPC. Che una gilda possa conquistarlo è un'idea per più avanti, non ancora progettata (vedi [Città di gilda](/wiki/citta-di-gilda)).
- **Dove nascono.** Il generatore li distribuisce su tutto il mondo con la stessa rarità, senza forzarne uno dove nascono i nuovi giocatori (vedi [Il Mondo](/wiki/mondo)).

### 🏘️ I villaggi

- Un villaggio non ha mura né guardie: è **terra libera**, i suoi blocchi si scavano e ci si può costruire. Per questo le guardie non arrivano (vedi [Guardie cittadine](/wiki/guardie-cittadine)).
- Ogni villaggio ha un nome generato, che compare quando ci entri, sui cartelli e sulle mappe di Cartography.
- Il villaggio di pescatori, la carovaniera e il porto dei bucanieri restano insediamenti speciali rari.

### 🛤️ Le strade

- Le strade escono **solo dalle porte dei feudi**, lunghe al massimo 2.000 blocchi, e portano ai villaggi, agli insediamenti speciali e ai santuari che trovano a portata; finiscono se non raggiungono nulla. Non esistono strade da un feudo a un altro né da un villaggio a un altro.
- Una porta con nulla a portata ha comunque una strada che sfuma (pietra, terra, sentiero) e finisce prima di 2.000 blocchi.
- Vicino al feudo la strada è lastricata, poi diventa di terra e più stretta, e finisce come sentiero.
- Seguono il terreno: passano per valli e passi, evitano pendii ripidi e acqua, salgono a tornanti dove la pendenza lo chiede e hanno ponti dove devono attraversare un fiume. Non vanno in linea retta sopra le montagne.
- Lungo la strada si incontrano cartelli con i nomi, ponti, locande di posta e santuari.
- **Deciso da Aruto (02/11/2026):** i blocchi delle strade non sono protetti: fuori dalle mura i giocatori possono scavarli e costruirci sopra. Solo i blocchi dentro le mura dei feudi restano protetti.

### 🎲 Eccezioni dal seme

Tutto nasce dal seme, e le regole fisse lasciano una piccola probabilità di eccezione, perché ogni mondo resti unico: per esempio un villaggio in un bioma diverso dal solito o una rovina accanto a un feudo vivo. Con lo stesso seme le eccezioni si ripetono identiche. I feudi stanno sempre ad almeno 16 km l'uno dall'altro, tranne in 1 caso su 100.000 per feudo: lì ne nasce un secondo proprio accanto al primo, i **feudi gemelli**.

### 🧱 Materiali e locande

- Feudi e villaggi usano i materiali del bioma: legno e paglia nelle pianure, `spruce_log` nella taiga, `acacia_log` e `red_clay` nella savana, `sandstone` nel deserto, pietra e neve nella tundra, `granite` e tetti di `slate` in montagna e nella brughiera, `limestone` sulle coste.
- Nelle **locande** il logout è immediato e sicuro come in casa (vedi [Persistenza del mondo](/wiki/persistenza-del-mondo)): un villaggio con la sua locanda è un buon posto dove fermarsi lontano dai feudi.

---

## ⛩️ Santuari

I santuari sono i punti di resurrezione del mondo: un fantasma che raggiunge l'ankh di un santuario torna in vita (vedi [Morte e fantasmi](/wiki/morte-e-fantasmi)). Dentro il loro cerchio non compare nessuna creatura ostile.

| Struttura e id | Dove | Rarità, dimensione | Cosa offre | Blocchi |
|----------------|------|--------------------|------------|---------|
| **Santuario delle virtù** `soulslands:virtue_shrine` | Dentro la zona di guardia di ogni feudo | Uno per feudo; media | Resurrezione, altare delle decime per [Chivalry](/wiki/skill-chivalry), rito della Purificazione dell'Anima ([Player killer e redenzione](/wiki/player-killer-e-redenzione)), **Pedana delle Razze** per i fantasmi (vedi [Razze](/wiki/razze)) | 🔒 |
| **Santuario del crocevia** `soulslands:wayside_shrine` | Lungo le strade dei feudi, ingresso di alcuni dungeon grandi | Non comune; piccola | Resurrezione | 🔒 |
| **Santuario antico** `soulslands:ancient_shrine` | In cima a rovine lontane, su vette e isole remote; mai nelle Lande d'Ombra | Rara; media | Resurrezione nelle terre selvagge; fuori dal cerchio gli spawn sono normali | 🔒 il cerchio, ⛏️ le rovine |
| **Santuario del caos** `soulslands:chaos_shrine` | Margini delle [Terre dei Morti](/wiki/bioma-terre-dei-morti), isole maledette; mai vicino a un feudo con guardie | Molto rara; media | Resurrezione per tutti, anche per i fantasmi **rossi** | 🔒 |

Ogni santuario delle virtù è dedicato a una delle otto virtù di Ultima Online, con il suo colore e il mantra inciso sull'altare. Ogni feudo ne ha uno; la virtù è scelta dal seme in base al bioma, e nel mondo le virtù si ripetono.

| Virtù | Mantra | Colore | Bioma preferito | Città di UO |
|-------|--------|--------|-----------------|-------------|
| Onestà (Honesty) | AHM | Blu | [Foresta incantata](/wiki/bioma-foresta-incantata) | Moonglow |
| Compassione (Compassion) | MU | Giallo | [Pianure](/wiki/bioma-pianure) | Britain |
| Valore (Valor) | RA | Rosso | [Isole](/wiki/bioma-isole) | Jhelom |
| Giustizia (Justice) | BEH | Verde | [Foresta profonda](/wiki/bioma-foresta-profonda) | Yew |
| Sacrificio (Sacrifice) | CAH | Arancione | [Montagne](/wiki/bioma-montagne) | Minoc |
| Onore (Honor) | SUMM | Viola | [Coste](/wiki/bioma-coste) | Trinsic |
| Spiritualità (Spirituality) | OM | Bianco | [Brughiera](/wiki/bioma-brughiera) | Skara Brae |
| Umiltà (Humility) | LUM | Nero | [Taiga](/wiki/bioma-taiga) | Magincia |

### 🌙 Niente moongate

I **moongate**, le porte magiche di Ultima Online, sono stati **tolti dal gioco**: quelli delle città, quelli antichi, quelli in rovina e il moongate nero delle roccaforti (**deciso da Aruto, 02/11/2026**; vedi [ADR-0033](https://github.com/Soulslands/soulslands-game/blob/main/docs/adr/0033-walled-settlements-gate-roads.md) sezione 6). Il viaggio magico resta come in Ultima Online: **Recall** e **Gate Travel** con le rune segnate (vedi [Magery](/wiki/skill-magery)). I fantasmi tornano in vita ai santuari, dai guaritori o per mano di un Chierico (vedi [Morte e fantasmi](/wiki/morte-e-fantasmi)).

---

## 🗺️ Strutture di superficie per bioma

Prima le strutture che compaiono in molti biomi, poi quelle tipiche di ciascun bioma. Il riepilogo completo è in [Strutture per bioma](#strutture-per-bioma).

### 🧭 In molti biomi

| Struttura e id | Dove | Rarità, dimensione | Abitanti e boss | Bottino | Blocchi |
|----------------|------|--------------------|-----------------|---------|---------|
| **Accampamento di briganti** `soulslands:brigand_camp` | Lungo le strade di pianure, foreste, taiga e brughiera; nei canyon rossi è un covo nascosto in una gola. Nella savana e nel deserto al suo posto c'è l'[accampamento nomade](#savana) | Non comune; media | 4–8 [briganti](/wiki/mostro-brigante) (Brigand) e una torre di vedetta in legno; capo: un brigante con nome | Forziere chiuso: oro, armi, mappe del tesoro di livello 1–2; a volte un prigioniero da liberare, che dà [karma](/wiki/karma-e-fama) | ⛏️ |
| **Villaggio abbandonato** `soulslands:abandoned_village` | Pianure, tundra, brughiera | Non comune; grande | Di notte scheletri, zombie e ghoul; ratti giganti nelle cantine | Attrezzi, semi, piccoli forzieri | ⛏️ |
| **Torre del mago** `soulslands:wizard_tower` | Colline di pianure, foresta temperata e brughiera; più spesso nella foresta incantata | Rara; media, alta 30–40 blocchi | Maghi rinnegati (Evil Mage) con un elementale dell'aria o di terra al loro servizio, mongbat; boss: un mago rinnegato con nome | Reagenti, pergamene, libri degli incantesimi, rune, `mana_crystal` | 🧱 |
| **Cimitero** `soulslands:graveyard` | Ai margini di feudi e villaggi; grande e maledetto nelle Terre dei Morti | Comune; media | Di notte scheletri, zombie, ghoul e spettri | Corredi nelle tombe (profanarle abbassa il karma); a volte un mausoleo con le scale per una cripta | ⛏️ |
| **Rovine sepolte** `soulslands:buried_ruins` | Pianure, savana, deserto, canyon rossi | Non comune; media o grande | Scheletri; nel deserto e nei canyon rossi, dove sono i resti di intere città antiche, [gargoyle selvaggi](/wiki/mostro-gargoyle) e scorpioni | Scavando la terra e la ghiaia tra i muri: monete antiche, statuette, frammenti di mappe del tesoro | ⛏️ |

### 🌾 Pianure

| Struttura e id | Dove | Rarità, dimensione | Abitanti e boss | Bottino | Blocchi |
|----------------|------|--------------------|-----------------|---------|---------|
| **Fattoria abbandonata** `soulslands:abandoned_farm` | Campagne aperte | Comune; media | Ratti giganti nel granaio; di notte scheletri e zombie | Semi di `wheat`, `cotton_plant` e `flax_plant`, attrezzi agricoli, un piccolo forziere | ⛏️ |
| **Mulino a vento** `soulslands:windmill` | Colline vicino ai fiumi | Non comune; piccola | Nessuno | Sacchi di farina, la macina, ingranaggi per [Tinkering](/wiki/skill-tinkering) | ⛏️ |

### 🌳 Foresta temperata

| Struttura e id | Dove | Rarità, dimensione | Abitanti e boss | Bottino | Blocchi |
|----------------|------|--------------------|-----------------|---------|---------|
| **Capanna del boscaiolo** `soulslands:woodcutter_hut` | Radure | Comune; piccola | Nessuno; di notte lupi intorno | Accetta, tronchi, assi, cibo | ⛏️ |
| **Accampamento orchesco** `soulslands:orc_camp` | Margini verso la foresta profonda; colline della [taiga](/wiki/bioma-taiga) | Non comune; media | [Orchi](/wiki/mostro-orco), orchi arcieri, uno sciamano orco; boss: un capitano orco (Orc Captain) | Oro, armi ed elmi orcheschi | ⛏️ |

### 🌲 Foresta profonda

| Struttura e id | Dove | Rarità, dimensione | Abitanti e boss | Bottino | Blocchi |
|----------------|------|--------------------|-----------------|---------|---------|
| **Fortezza orchesca** `soulslands:orc_fortress` | Cuore del bioma e colline boscose | Rara; grande, tre piani più i sotterranei | Orchi di ogni tipo, orchi bombaroli, capitani e bruti; boss: il Signore degli orchi (Orc Lord), nel covo orchesco sotto la fortezza | Forzieri ricchi: oro, gemme, oggetti magici, pozioni esplosive | 🧱 |
| **Abbazia in rovina** `soulslands:ruined_abbey` | Radure buie, come l'abbazia dei boschi di Yew | Rara; grande | Spettri e scheletri maghi; di notte wraith | Libri, candelabri d'argento, vino d'abbazia, pergamene | ⛏️ |

### ✨ Foresta incantata

| Struttura e id | Dove | Rarità, dimensione | Abitanti e boss | Bottino | Blocchi |
|----------------|------|--------------------|-----------------|---------|---------|
| **Cerchio delle fate** `soulslands:fairy_ring` | Radure, segnato da un anello di `glow_mushroom` | Non comune; piccola | Pixie e wisp | Funghi luminosi; chi medita dentro il cerchio recupera mana ancora più in fretta | ⛏️ |
| **Fonte della luna** `soulslands:moon_pool` | Boschi di argentofoglia, con un bordo di `marble` | Rara; piccola | Unicorni e Ki-Rin vengono a bere nelle notti di luna piena | Nessun forziere: è il posto migliore per avvicinare un unicorno (vedi [Bestie magiche](/wiki/mostri-bestie-magiche)) | ⛏️ |

### 🌴 Giungla

| Struttura e id | Dove | Rarità, dimensione | Abitanti e boss | Bottino | Blocchi |
|----------------|------|--------------------|-----------------|---------|---------|
| **Tempietto della giungla** `soulslands:jungle_temple` | Nel fitto, coperto di `vines` e `moss_block` | Non comune; media | Nessuno dentro, serpenti e ragni intorno; trappole a dardi avvelenati, fili d'inciampo e leve | Due forzieri: oro, gemme, ginseng, un idolo d'oro; i più grandi scendono al tempio ofidiano | 🧱 |
| **Villaggio dei selvaggi** `soulslands:savage_village` | Radure e rive dei fiumi; anche sulle isole tropicali più grandi | Non comune; grande | Selvaggi, sciamani selvaggi, cavalieri selvaggi; boss: il capo tribù, uno sciamano selvaggio con nome | Maschere tribali, reagenti, oro | ⛏️ |

### 🐊 Palude

| Struttura e id | Dove | Rarità, dimensione | Abitanti e boss | Bottino | Blocchi |
|----------------|------|--------------------|-----------------|---------|---------|
| **Capanna della strega** `soulslands:witch_hut` | Su palafitte, nelle zone più nebbiose | Non comune; piccola | Spesso vuota; a volte un mago rinnegato (la "strega") e un gatto nero da domare | Calderone, pozioni, reagenti (`mandrake_plant`, `nightshade_plant`, `blood_moss`), ricette di [Alchemy](/wiki/skill-alchemy) | ⛏️ |
| **Villaggio lizardman** `soulslands:lizardman_village` | Palafitte sull'acqua bassa, qui e tra le [mangrovie](/wiki/bioma-mangrovie) | Non comune; grande | 10–20 [lizardman](/wiki/mostro-lizardman); boss: un lizardman con nome | Lance, oro, gemme piccole | ⛏️ |
| **Tana dei troll** `soulslands:troll_den` | Isolotti di fango | Comune; piccola | 2–4 [troll](/wiki/mostro-troll) | Oro e resti di avventurieri: armi e armature usate | ⛏️ |

### 🦀 Mangrovie

| Struttura e id | Dove | Rarità, dimensione | Abitanti e boss | Bottino | Blocchi |
|----------------|------|--------------------|-----------------|---------|---------|
| **Covo dei pirati** `soulslands:pirate_cove` | Tra le radici delle mangrovie, nelle baie delle isole tropicali e del tesoro, tra gli isolotti degli arcipelaghi, nelle grotte marine di isole rocciose e faraglioni | Non comune; grande | 6–12 pirati; boss: il capitano, un pirata con nome | Mappe del tesoro, oro, gemme, una nave arenata con la stiva piena | ⛏️ |
| **Relitto spiaggiato** `soulslands:beached_wreck` | Incagliato tra le radici, nelle lagune | Comune; media | Granchi giganti, alligatori | Forziere della nave, a volte una mappa del tesoro | ⛏️ |

### 🏜️ Deserto

| Struttura e id | Dove | Rarità, dimensione | Abitanti e boss | Bottino | Blocchi |
|----------------|------|--------------------|-----------------|---------|---------|
| **Piramide** `soulslands:pyramid` | Tra le dune, mezza sepolta | Rara; grande | Mummie, scheletri, scheletri maghi; boss: il Signore dei lich (Lich Lord), nella cripta sotto la piramide | Camera del tesoro sotto una botola, protetta da una trappola esplosiva: oro, gioielli antichi, gemme | 🧱 |
| **Tomba del deserto** `soulslands:desert_tomb` | 5–15 blocchi sotto la sabbia: spesso la si scopre cadendoci dentro | Non comune; media | [Mummie](/wiki/mostro-mummia), scheletri, scorpioni | Gioielli antichi, bende antiche, oro | 🧱 |
| **Oasi** `soulslands:oasis` | Avvallamenti tra le dune | Non comune; media | Ostard del deserto, serpenti | Acqua dolce, palme (`palm_log` e noci di cocco) | ⛏️ |
| **Carovaniera** `soulslands:caravanserai` | Nelle oasi più grandi | Rara; media | Mercante nomade, stalliere e poche guardie | Nessun bottino: pozzo, stalla e locanda, l'unico riparo sicuro del deserto | 🔒 |

### 🌅 Savana

| Struttura e id | Dove | Rarità, dimensione | Abitanti e boss | Bottino | Blocchi |
|----------------|------|--------------------|-----------------|---------|---------|
| **Accampamento nomade** `soulslands:nomad_camp` | Lungo le piste della savana e del [deserto](/wiki/bioma-deserto), vicino a un pozzo o a un baobab | Non comune; media | Tende di pelle con 5–10 predoni nomadi ([briganti](/wiki/mostro-brigante)), [cavalli](/wiki/animale-cavallo) e [ostard del deserto](/wiki/animale-ostard-del-deserto) legati ai pali; capo: un predone con nome | Oro, merci rubate alle carovane, selle, otri d'acqua, mappe del tesoro di livello 1–2 | ⛏️ |
| **Formicaio** (dei Solen) `soulslands:solen_hive` | Prati aridi: l'ingresso è un alto cumulo di `red_clay`, simile a un termitaio | Non comune; piccola in superficie | Formiche operaie e guerriere (Solen) | È l'ingresso di un formicaio: la regina custodisce la gelatina reale | 🧱 |

### 🏞️ Canyon rossi

| Struttura e id | Dove | Rarità, dimensione | Abitanti e boss | Bottino | Blocchi |
|----------------|------|--------------------|-----------------|---------|---------|
| **Miniera abbandonata** (d'oro) `soulslands:abandoned_mine` | Pareti dei canyon: è la miniera abbandonata che affiora, con gallerie e puntelli di legno in vista | Comune; enorme | [Elementali della terra](/wiki/mostro-elementale-della-terra), scorpioni, ragni giganti nelle gallerie buie; scavando una vena d'oro può svegliarsi un elementale d'oro (Golden Elemental) | Picconi, lanterne, vene d'oro (`gold_vein`) già esposte | ⛏️ |
| **Abitazioni nella roccia** `soulslands:cliff_dwelling` | Scavate nelle pareti di `red_sandstone` | Non comune; media | [Arpie](/wiki/mostro-arpia), scorpioni; sulle mesa più alte [arpie di pietra](/wiki/mostro-arpia-di-pietra) (Stone Harpy); a volte un covo di briganti | Vasi con oro e gemme, frecce | ⛏️ |

### ⛰️ Montagne

| Struttura e id | Dove | Rarità, dimensione | Abitanti e boss | Bottino | Blocchi |
|----------------|------|--------------------|-----------------|---------|---------|
| **Rocca dei nani in rovina** `soulslands:dwarven_hold` | Scavata nei fianchi della montagna, Y 60–140 | Rara; grande | Ogre, ettin, elementali di terra; boss: il Signore degli ogre (Ogre Lord) | Forge e incudini, lingotti, armi naniche | 🧱 |
| **Accampamento dei ciclopi** `soulslands:cyclops_camp` | Vallate alte, Y 120–180 | Rara; media | 2–3 [ciclopi](/wiki/mostro-ciclope); nei più grandi un [Titano](/wiki/mostro-titano) come boss | Molto oro, pergamene | ⛏️ |
| **Nido di wyvern** `soulslands:wyvern_nest` | Pareti e cenge, Y 150–220; più in basso sulle mesa dei canyon rossi, sulle isole rocciose e in cima ai faraglioni | Non comune; piccola | 2–4 [wyvern](/wiki/mostro-wyvern), drake | Ossa di vittime con oro e gemme | ⛏️ |
| **Nido di draghi** (in vetta) `soulslands:dragon_nest` | Vette oltre Y 200 | Molto rara; media | Drake; boss: un [drago](/wiki/mostro-drago), del ghiaccio sulle vette innevate; durante i temporali può arrivare un drago del fulmine | Il tesoro del drago: molto oro, gemme, oggetti magici | ⛏️ |

### 🌨️ Taiga

| Struttura e id | Dove | Rarità, dimensione | Abitanti e boss | Bottino | Blocchi |
|----------------|------|--------------------|-----------------|---------|---------|
| **Capanna del cacciatore** `soulslands:trapper_cabin` | Rive di laghi e fiumi | Comune; piccola | Nessuno, è abbandonata; orsi e lupi grigi intorno | Pellicce, trappole, carne secca, un arco | ⛏️ |
| **Campo dei taglialegna** `soulslands:logging_camp` | Pendii di abeti e pini | Non comune; media | Nessuno di giorno; lupi di notte | Cataste di `spruce_log` e `pine_log`, assi, barili di resina, accette | ⛏️ |

### ❄️ Tundra

| Struttura e id | Dove | Rarità, dimensione | Abitanti e boss | Bottino | Blocchi |
|----------------|------|--------------------|-----------------|---------|---------|
| **Rifugio di neve** `soulslands:igloo` | Pianure innevate | Non comune; piccola | Nessuno; un rifugio su tre ha una botola verso un sotterraneo con uno zombie in catene | Pellicce, un letto, pozioni e reagenti nel laboratorio nascosto | ⛏️ |
| **Fortezza di ghiaccio** `soulslands:ice_fortress` | Ghiacciai e coste gelate, mura di `packed_ice` e `glacier_ice` | Rara; grande | [Troll del gelo](/wiki/mostro-troll-del-gelo), elementali del ghiaccio e della neve, ragni del gelo; boss: un troll del gelo con nome, nelle più grandi un Wyrm bianco (White Wyrm) | Oro, gemme, cristalli di ghiaccio, archi di [Frostwood](/wiki/legno-frostwood) | 🧱 |

### 🌫️ Brughiera

| Struttura e id | Dove | Rarità, dimensione | Abitanti e boss | Bottino | Blocchi |
|----------------|------|--------------------|-----------------|---------|---------|
| **Cerchio di pietre** `soulslands:stone_circle` | Colline nebbiose; più raro nella foresta profonda | Comune; media | Wisp di notte e nella nebbia | Un altare con reagenti | ⛏️ |
| **Tumulo funerario** `soulslands:barrow` | Colline di brughiera, anche taiga e foresta profonda | Non comune; piccola fuori, media sotto terra | [Wraith](/wiki/mostro-wraith), scheletri, ghoul; cavalieri d'ossa a guardia dei più grandi; boss: il Re del tumulo, un cavaliere d'ossa con nome | Armi antiche, gioielli, gemme | 🧱 |
| **Ometto di pietra** `soulslands:cairn` | Lungo i vecchi sentieri, nella nebbia | Comune; piccola | Nessuno | Indica la direzione del cerchio di pietre o del villaggio più vicino; a volte nasconde qualche moneta | ⛏️ |

### 🌋 Terre vulcaniche

| Struttura e id | Dove | Rarità, dimensione | Abitanti e boss | Bottino | Blocchi |
|----------------|------|--------------------|-----------------|---------|---------|
| **Forgia abbandonata** `soulslands:abandoned_forge` | Vicino ai fiumi di lava | Non comune; media | Elementali del fuoco, coleotteri di fuoco, lucertole di lava | Forgia e incudine ancora usabili, lingotti di [Blood Rock](/wiki/minerale-blood-rock), martelli | 🧱 |
| **Tempio demoniaco** `soulslands:demon_temple` | Crateri spenti; la scalinata scende fino all'Abisso | Rara; enorme | Imp, gatti e segugi infernali, gargoyle di fuoco; più in basso demoni e moloch; boss: il [Balron](/wiki/mostro-balron) | Reagenti, sangue di demone, oro, oggetti magici | 🧱 |
| **Nido di draghi** (nei crateri) `soulslands:dragon_nest` | Crateri attivi | Molto rara; media | Drake; boss: un drago di fuoco | Il tesoro del drago | ⛏️ |
| **Nido della fenice** `soulslands:phoenix_nest` | Vetta dei vulcani più alti | Leggendaria; piccola | Boss: la Fenice (Phoenix) | Piume di fenice, un tesoro | ⛏️ |

### 💀 Terre dei Morti

| Struttura e id | Dove | Rarità, dimensione | Abitanti e boss | Bottino | Blocchi |
|----------------|------|--------------------|-----------------|---------|---------|
| **Mausoleo** `soulslands:mausoleum` | Nei cimiteri maledetti | Non comune; media | Cavalieri d'ossa, scheletri maghi, ghoul; le scale scendono a una cripta | Gioielli, gemme, polvere d'osso | 🧱 |
| **Torre del lich** `soulslands:lich_tower` | Colline nebbiose | Rara; grande, alta 40–60 blocchi | Scheletri, scheletri maghi, cavalieri d'ossa, [lich](/wiki/mostro-lich); boss: il [Signore dei lich](/wiki/mostro-signore-dei-lich), e nelle notti di luna nuova un Lich antico | Polvere di lich, pergamene, oggetti magici | 🧱 |
| **Campo di battaglia antico** `soulslands:ancient_battlefield` | Pianure grigie di `dead_soil` | Non comune; grande | Cavalieri scheletrici e d'ossa, wraith; di notte nightmare; nelle notti di luna nuova un drago scheletrico | Armi e armature antiche, ossa; qui [Spirit Speak](/wiki/skill-spirit-speak) rende di più | ⛏️ |

### 🌑 Lande d'Ombra

| Struttura e id | Dove | Rarità, dimensione | Abitanti e boss | Bottino | Blocchi |
|----------------|------|--------------------|-----------------|---------|---------|
| **Portale demoniaco** `soulslands:demon_portal` | Altopiani spezzati, archi di `obsidian` e `shadow_stone` | Rara; media | Imp, succubi, demoni del caos, demoni; boss: il Balron | Sangue di demone puro, oggetti magici rari | 🧱 |
| **Fortezza in rovina** `soulslands:shadow_fortress` | Bordi delle voragini | Rara; grande | Ombre, senza testa, gazer anziani, nightmare; boss: un demone arcano (Arcane Daemon) | Oro, pergamene, [Black Rock](/wiki/minerale-black-rock) grezzo | 🧱 |
| **Tana del wyrm d'ombra** `soulslands:shadow_wyrm_lair` | Fondo delle voragini più profonde | Leggendaria; grande | Boss: il Wyrm d'ombra (Shadow Wyrm) | Tesoro, oggetti magici rari | 🧱 |

### 🌊 Coste

| Struttura e id | Dove | Rarità, dimensione | Abitanti e boss | Bottino | Blocchi |
|----------------|------|--------------------|-----------------|---------|---------|
| **Faro** `soulslands:lighthouse` | Promontori, scogliere, isole e faraglioni; acceso se serve un porto, spento se abbandonato | Non comune; media, alto 25–35 blocchi | Nei fari spenti pirati e, di notte, pirati annegati | Olio, cannocchiale, carte nautiche | 🔒 se cittadino, ⛏️ se abbandonato |
| **Relitto spiaggiato** `soulslands:beached_wreck` | Spiagge e scogli | Comune; media | Granchi giganti; di notte pirati annegati | Forziere della nave: provviste, oro, a volte una mappa del tesoro | ⛏️ |
| **Grotta dei contrabbandieri** `soulslands:smugglers_cave` | Scogliere e isole rocciose; l'ingresso emerge con la bassa marea | Non comune; media | Pirati, briganti | Merci di contrabbando, oro, chiavi | ⛏️ |

---

## 🗝️ Strutture sotterranee e dungeon

I primi dieci dungeon sono quelli di [Grotte e sottosuolo](/wiki/grotte-e-sottosuolo#dungeon-generati); gli altri si aggiungono. Le profondità sono gli strati del sottosuolo: superficiale (Y 0 – 40), medio (Y -16 – 0), profondo (Y -32 – -16), Abisso (Y -48 – -32) e Cuore del mondo (Y -64 – -48). Muri, porte e scale dei dungeon sono 🧱 rinforzati.

| Dungeon e id | Profondità | Bioma | Abitanti | Boss | Ingresso, rarità, dimensione | Bottino tipico |
|--------------|-----------|-------|----------|------|------------------------------|----------------|
| **Tana dei ratman** `soulslands:ratman_warren` | Superficiale | Ovunque | Ratti giganti, ratman | Re dei ratman | Canali di scolo fuori dalle mura, burroni; comune, media | Oro, armi |
| **Covo orchesco** `soulslands:orc_lair` | Superficiale – medio | Foresta profonda, montagne | Orchi, orc captain | Orc Lord | Sotto le fortezze orchesche o in una grotta di collina, anche nella taiga; non comune, grande | Oro, gemme, oggetti magici |
| **Miniera infestata** `soulslands:haunted_mine` | Medio | Montagne | Elementali dei minerali, gargoyle selvaggi | Elementale di Valorite | In fondo alle miniere abbandonate più profonde; rara, grande | Minerale grezzo raro, gemme |
| **Cripta** `soulslands:crypt` | Medio – profondo | Terre dei Morti, deserto | Scheletri, mummie, lich | Lich Lord | Mausolei, piramidi, cimiteri, isole maledette; non comune, grande | Gioielli antichi, polvere di lich, pergamene |
| **Covo dei ragni** `soulslands:spider_nest` | Medio | Giungla, foresta profonda | Ragni, terathan | Matriarca dei terathan | Conche buie piene di `cobweb`; non comune, media | Seta di ragno, veleno, pergamene |
| **Formicaio** `soulslands:solen_hive` | Superficiale – medio | Deserto, pianure | Formiche giganti (Solen) | Regina dei Solen | Cumuli di terra, termitai nella savana; non comune, grande | Gelatina reale, oro |
| **Caverne di ghiaccio** `soulslands:frozen_caverns` | Medio – profondo | Tundra | Frost troll, elementali del ghiaccio | Ice Fiend | Crepacci dei ghiacciai, sotterranei delle fortezze di ghiaccio, isole ghiacciate; non comune, grande | Cristalli di ghiaccio, gemme |
| **Nido di draghi** `soulslands:dragon_nest` | Profondo | Montagne, terre vulcaniche | Drake, wyvern | Drago | Caverne di lava, gallerie dalle vette; molto rara, media | Il tesoro del drago |
| **Tempio demoniaco** `soulslands:demon_temple` | Abisso | Terre vulcaniche, Lande d'Ombra | Imp, demoni | Balron | Scalinata dal tempio in superficie; rara, enorme | Sangue di demone, oggetti magici rari |
| **Rovine sommerse** `soulslands:sunken_ruins` | Fondale oceanico | [Oceani](/wiki/oceani) | Serpenti, elementali d'acqua | Kraken | Dal fondale (vedi sotto); non comune, media | Perle nere, forzieri di relitti |
| **Miniera abbandonata** `soulslands:abandoned_mine` | Superficiale – medio | Sotto colline e montagne, affiorante nei canyon rossi | Ragni giganti, ratti giganti, elementali di terra | Nessuno | Gallerie con puntelli di legno, carrelli rovesciati e `cobweb`; comune, enorme | Picconi, lanterne, minerale grezzo |
| **Tempio ofidiano** `soulslands:ophidian_temple` | Medio | Giungla | Guerrieri, maghi e cavalieri ofidiani | Matriarca ofidiana | Sotto i tempietti della giungla più grandi; rara, grande | Veleni rari, armi magiche, tesoro |
| **Roccaforte antica** `soulslands:stronghold` | Profondo | Ovunque, ad anelli intorno al centro del mondo | Cavalieri scheletrici, scheletri maghi, gargoyle di pietra | Nessuno | Si trova esplorando; molto rara, grande | Biblioteca di pergamene e libri degli incantesimi, armeria |
| **Città perduta** `soulslands:lost_city` | Abisso | Ovunque, più spesso sotto le montagne | Gazer anziani, ombre, ragni del terrore, gargoyle di pietra | Demone d'ossa (Bone Demon) | Enorme caverna di `black_basalt`; molto rara, enorme | Oggetti magici rari, lingotti di [Mytheril](/wiki/minerale-mytheril) |
| **Tana del wyrm antico** `soulslands:ancient_wyrm_lair` | Cuore del mondo | Ovunque | Elementali del fuoco, demoni arcani | [Wyrm antico](/wiki/mostro-wyrm-antico) | Solo scavando fino alla `hellstone`; leggendaria, grande | Tesoro leggendario |

- Alcuni dungeon grandi (cripte, covi orcheschi, templi) hanno un santuario del crocevia all'ingresso: è lì che tornano in vita i fantasmi del gruppo.
- **Roccaforte antica.** Come in Minecraft, le roccaforti stanno ad anelli intorno al centro del mondo: tre nel primo anello, tra 1.500 e 3.000 blocchi, e sempre di più negli anelli esterni. Non c'è nessun oggetto che le indichi: si trovano esplorando il sottosuolo (**deciso da Aruto, 02/11/2026**). Il moongate nero che un tempo stava nella sala più profonda è stato tolto: la sala resta senza porta, e la tana di un Wyrm antico si raggiunge solo scavando ([ADR-0033](https://github.com/Soulslands/soulslands-game/blob/main/docs/adr/0033-walled-settlements-gate-roads.md) sezione 6).
- **Città perduta.** Una città sepolta nel basalto nero, buia e silenziosa. Le campane d'ossa appese nelle sue vie suonano quando qualcuno corre, scava o combatte vicino: al terzo rintocco si sveglia il Demone d'ossa che la custodisce. Chi si muove piano e senza scavare può saccheggiarla senza svegliarlo.

---

## 🌊 Strutture oceaniche e delle isole

Le strutture marine seguono le profondità di [Oceani](/wiki/oceani): per esplorarle servono apnea lunga, pozioni di respirazione o una via d'aria scavata, e sempre una luce.

| Struttura e id | Dove | Rarità, dimensione | Abitanti e boss | Bottino | Blocchi |
|----------------|------|--------------------|-----------------|---------|---------|
| **Relitto** `soulslands:shipwreck` | Fondale di tutti i mari (`ocean`, `warm_ocean`, `cold_ocean`, `frozen_ocean` e le loro varianti profonde); nei mari ghiacciati è intrappolato nel `packed_ice` | Comune; media | Granchi giganti, pirati annegati; a volte un kraken nei paraggi | Forziere del capitano con una mappa del tesoro, stiva con merci e lingotti: più è profondo, più è ricco | ⛏️ |
| **Rovine sommerse** `soulslands:sunken_ruins` | Piccole in acque basse e sulle barriere coralline (`coral_reef`), grandi in acque profonde | Non comune; piccola o media | Serpenti marini, elementali d'acqua; nelle grandi il boss è un [Kraken](/wiki/mostro-kraken) | Perle, gemme, statuette; `pearl_oyster` tutto intorno | 🧱 |
| **Tempio sommerso** `soulslands:sunken_temple` | Fondale di `deep_ocean`, `deep_warm_ocean` e `deep_cold_ocean`, tra Y -5 e Y 20 | Rara; grande, circa 60 × 60 | Serpenti degli abissi, elementali d'acqua; tre Guardiani, elementali delle profondità con nome | Lingotti d'oro e di [Orialco](/wiki/minerale-orialco), perle nere, oggetti magici | 🧱 |
| **Città sommersa** `soulslands:sunken_city` | Fondo delle fosse oceaniche (`ocean_trench`), verso Y -30 | Molto rara; enorme | Serpenti degli abissi, elementali delle profondità, kraken, pirati annegati; boss: il Leviatano (Leviathan) | Tesoro leggendario, Orialco, le armi marine uniche del Leviatano | 🧱 |
| **Nave fantasma** `soulslands:ghost_ship` | Arenata sulle isole maledette, avvolta nella nebbia | Rara; media | Pirati annegati, scheletri, wraith; boss: il capitano, un pirata annegato con nome | Forziere del capitano, mappe del tesoro di livello alto | ⛏️ |
| **Porto dei bucanieri** `soulslands:buccaneer_den` | Isole remote, come Buccaneer's Den in Ultima Online | Molto rara; grande | Mercanti NPC e nessuna guardia | Mercanti che servono anche i rossi, cantiere navale, un santuario del caos poco lontano | 🔒 |

- Finché i tre Guardiani del tempio sommerso sono vivi, chi è dentro subisce la **maledizione del minatore** e scava dieci volte più piano: aprirsi una via d'aria nei muri è quasi impossibile.
- Le isole più grandi possono avere un feudo con il suo porto e il cantiere navale, come Jhelom, Moonglow o Magincia in Ultima Online.

| Tipo di isola ([Isole](/wiki/bioma-isole)) | Strutture tipiche |
|--------------------------------------------|-------------------|
| **Tropicale** | Relitti spiaggiati, covi dei pirati, fari, tesori dei pirati; sulle più grandi villaggi dei selvaggi |
| **Rocciosa** | Grotte marine con covi dei pirati o dei contrabbandieri, fari, nidi di wyvern, santuari antichi |
| **Vulcanica** | Nidi di draghi nel cratere, forge abbandonate |
| **Ghiacciata** | Ingressi delle caverne di ghiaccio, villaggi abbandonati, relitti imprigionati nel ghiaccio |
| **Dei funghi** | Nessuna: la rarità è l'isola stessa, e sotto si aprono spesso le caverne dei funghi giganti |
| **Maledetta** | Relitti spiaggiati e navi fantasma, covi dei pirati abbandonati, ingressi di cripte, santuari del caos |
| **Del tesoro** | Rovine sepolte, covi dei pirati, tesori dei pirati |
| **Arcipelago di isolotti** | Relitti incagliati sulle secche, fari, covi dei pirati nascosti tra gli isolotti |
| **Faraglioni** | Fari sui più grandi, covi dei pirati nelle grotte alla base, nidi di wyvern in cima |

---

## 💰 Mappe del tesoro e tesori sepolti

Come in Ultima Online, le **mappe del tesoro** arrivano dai bottini: forzieri di briganti, pirati e relitti, corpi di pirati e di [serpenti marini](/wiki/mostro-serpente-marino), pesca in acque profonde. Ogni mappa indica un punto preciso del mondo generato: un bioma qualsiasi, un'isola in mezzo all'oceano, la vetta o il ventre di una montagna (vedi [Esploratore](/wiki/classe-esploratore)).

| Livello | Mappa (UO) | [Cartography](/wiki/skill-cartography) | [Lockpicking](/wiki/skill-lockpicking) | Guardiani | Dove si trova la mappa |
|---------|------------|-------------|-------------|-----------|------------------------|
| 1 | Disegnata semplicemente (Plainly) | 40 | 30 | Scheletri, zombie | Briganti e predoni nomadi, relitti spiaggiati |
| 2 | Con perizia (Expertly) | 50 | 45 | Ghoul, ratman, orchi | Pirati, accampamenti orcheschi, pesca in mare aperto |
| 3 | Con abilità (Adeptly) | 60 | 60 | Scheletri maghi, ogre, gargoyle selvaggi | Relitti profondi, serpenti marini, fortezze orchesche |
| 4 | Con astuzia (Cleverly) | 70 | 80 | Lich, cavalieri d'ossa, ettin | Torri del lich, piramidi, covi dei pirati |
| 5 | Con malizia (Deviously) | 85 | 90 | Signori dei lich, demoni, gargoyle di pietra | Tempio sommerso, fortezze di ghiaccio, navi fantasma |
| 6 | Con ingegno (Ingeniously) | 95 | 99 | Demoni, titani, draghi | Città sommersa, templi demoniaci |

1. **Decifra** la mappa con Cartography: se fallisci puoi riprovare. Decifrata, mostra il terreno intorno al punto e una croce.
2. **Raggiungi** il punto e **scava** con una pala o un piccone: il forziere compare solo quando chi ha la mappa decifrata scava nel punto giusto, a qualche blocco di profondità e a volte nella roccia ([Mining](/wiki/skill-mining)). Così nemmeno chi conosce il seme del server può trovarlo prima.
3. Appena il forziere affiora compaiono i **guardiani**.
4. Dal livello 2 il forziere ha **trappole**: trovale con [Detect Hidden](/wiki/skill-detect-hidden), disinnescale con [Remove Trap](/wiki/skill-remove-trap), poi aprilo con Lockpicking.
5. Il bottino cresce con il livello: oro, gemme, reagenti, pergamene, oggetti magici; dal livello 5 in su i bottini sono eccezionali.

Ci sono poi due tesori che non chiedono di decifrare nulla:

- **Tesoro dei pirati** `soulslands:buried_treasure`: forzieri sepolti insieme al mondo, 3–6 blocchi sotto la sabbia di spiagge e isole del tesoro, a volte segnati da una croce di pietre. Ci portano le mappe dei pirati trovate nei relitti e nei covi, che si leggono senza Cartography. Il bottino è di livello 1–3.
- **Messaggio in bottiglia**: si pesca in mare aperto con [Fishing](/wiki/skill-fishing) e contiene la posizione di un naufragio. Pescando proprio in quel punto si tira su il forziere sommerso del relitto.

> 💡 Una mappa decifrata funziona per chiunque la possieda: si vende, si scambia e si può anche rubare.

---

## 📏 Frequenza e luoghi

Il pericolo e il bottino **non crescono con la distanza** dai feudi né dal centro del mondo: valgono le stesse regole dappertutto, e dipendono dal **bioma**, dal **luogo** (dungeon, rovine, profondità) e dalla **notte** (**deciso da Aruto, 02/11/2026**; vedi [Spawn delle creature](/wiki/spawn-creature#gli-stessi-ovunque)). Il livello del bottino è fisso per ogni tipo di struttura. I livelli qui sotto sono i valori di prima, riordinati per tipo di struttura invece che per distanza: sono stime nostre da rivedere.

| Tipo di struttura | Strutture | Livello del bottino |
|-------------------|-----------|---------------------|
| Dentro la zona di guardia | Feudi, santuario delle virtù | Nessun forziere |
| Semplici, di superficie | Villaggi, fattorie, mulini, capanne, cimiteri, santuari del crocevia, tane dei ratman | 1 |
| Accampamenti e rovine | Briganti e predoni nomadi, accampamenti orcheschi, rovine sepolte, miniere abbandonate, tumuli, relitti, formicai | 1 – 2 |
| Fortezze, templi e torri | Fortezze orchesche, piramidi, templi della giungla, torri del mago e del lich, fortezze di ghiaccio, nidi di wyvern, covi dei pirati, tempio sommerso, roccaforti | 2 – 4 |
| Rare e profonde | Templi demoniaci, portali, nidi di draghi, città perduta e sommersa, santuari del caos, porto dei bucanieri e tane leggendarie | 4 – 6 |

- Nessun accampamento, dungeon o torre nasce a meno di 300 blocchi da un feudo o di 100 da un villaggio; fanno eccezione i cimiteri e le tane dei ratman, che stanno appena fuori dalle mura. Due strutture non si sovrappongono mai.
- Il bioma decide che cosa può nascere. I biomi corrotti (Terre dei Morti, Lande d'Ombra, terre vulcaniche) sono frequenti allo stesso modo in tutto il mondo, e con loro le loro strutture. Sottoterra conta anche la profondità: lo stesso dungeon è più ricco negli strati più bassi.

---

## 📊 Strutture per bioma

| Bioma | In superficie | Sottoterra e dungeon |
|-------|---------------|----------------------|
| 🌾 [Pianure](/wiki/bioma-pianure) | Feudi, villaggi, strade, santuario della Compassione, fattorie abbandonate, mulini, villaggi abbandonati, briganti, rovine sepolte, cimiteri, torri del mago | Formicaio, tana dei ratman, miniera abbandonata |
| 🌿 [Steppa](/wiki/bioma-steppa) | Nessuna struttura tipica ancora definita | Nessun dungeon tipico |
| 🌳 [Foresta temperata](/wiki/bioma-foresta-temperata) | Feudi, villaggi, capanne del boscaiolo, accampamenti orcheschi, briganti, cimiteri, torri del mago | Tana dei ratman, miniera abbandonata |
| 🍁 [Foresta autunnale](/wiki/bioma-foresta-autunnale) | Come la foresta temperata, di cui è una variante; nessuna struttura propria ancora definita | Come la foresta temperata |
| 🌲 [Foresta profonda](/wiki/bioma-foresta-profonda) | Fortezze orchesche, abbazie in rovina, santuario della Giustizia, cerchi di pietre, tumuli, briganti | Covo orchesco, covo dei ragni |
| ✨ [Foresta incantata](/wiki/bioma-foresta-incantata) | Cerchi delle fate, fonti della luna, torri del mago, santuario dell'Onestà | Miniera abbandonata |
| 🌴 [Giungla](/wiki/bioma-giungla) | Tempietti della giungla, villaggi dei selvaggi | Tempio ofidiano, covo dei ragni |
| 🐊 [Palude](/wiki/bioma-palude) | Capanne della strega, villaggi lizardman, tane dei troll | Nessun dungeon tipico |
| 🦀 [Mangrovie](/wiki/bioma-mangrovie) | Villaggi lizardman su palafitte, covi dei pirati, relitti spiaggiati | Nessun dungeon tipico |
| 🏜️ [Deserto](/wiki/bioma-deserto) | Piramidi, tombe, oasi, carovaniere, villaggi di arenaria, rovine sepolte, accampamenti nomadi | Cripta, formicaio |
| 🌅 [Savana](/wiki/bioma-savana) | Villaggi, accampamenti nomadi, formicai dei Solen, rovine sepolte | Formicaio |
| 🏞️ [Canyon rossi](/wiki/bioma-canyon-rossi) | Abitazioni nella roccia, covi dei briganti nelle gole, rovine sepolte, nidi di wyvern sulle mesa | Miniere d'oro abbandonate, che affiorano |
| ⛰️ [Montagne](/wiki/bioma-montagne) | Rocche dei nani, accampamenti dei ciclopi, nidi di wyvern e di draghi, santuario del Sacrificio, santuari antichi | Miniera abbandonata e infestata, covo orchesco, nido di draghi |
| 🌼 [Prati alpini](/wiki/bioma-prati-alpini) | Nessuna struttura tipica ancora definita | Nessun dungeon tipico |
| 🌨️ [Taiga](/wiki/bioma-taiga) | Villaggi di abete, capanne del cacciatore abbandonate, campi dei taglialegna, accampamenti orcheschi, briganti, tumuli, santuario dell'Umiltà | Covo orchesco, miniera abbandonata |
| ❄️ [Tundra](/wiki/bioma-tundra) | Rifugi di neve, fortezze di ghiaccio, villaggi abbandonati | Caverne di ghiaccio |
| 🌫️ [Brughiera](/wiki/bioma-brughiera) | Cerchi di pietre, tumuli, ometti di pietra, torri del mago, villaggi e villaggi abbandonati, briganti, santuario della Spiritualità | Miniera abbandonata |
| 🌋 [Terre vulcaniche](/wiki/bioma-terre-vulcaniche) | Forge abbandonate, templi demoniaci, nidi di draghi, nido della fenice | Tempio demoniaco, nido di draghi |
| 💀 [Terre dei Morti](/wiki/bioma-terre-dei-morti) | Cimiteri maledetti, mausolei, torri del lich, campi di battaglia, santuari del caos ai margini | Cripta |
| 🌑 [Lande d'Ombra](/wiki/bioma-lande-d-ombra) | Portali demoniaci, fortezze in rovina | Tana del wyrm d'ombra, tempio demoniaco |
| 🌊 [Coste](/wiki/bioma-coste) | Feudi con porto, villaggi di pescatori, fari, relitti spiaggiati, grotte dei contrabbandieri, santuario dell'Onore | Grotte marine naturali |
| 🏔️ [Fiordi e gole](/wiki/bioma-fiordi-e-gole) | Nessuna struttura tipica ancora definita | Nessun dungeon tipico |
| 🏝️ [Isole](/wiki/bioma-isole) | Covi dei pirati, relitti e navi fantasma, fari, nidi di wyvern, santuari antichi, tesori dei pirati, porto dei bucanieri; sulle più grandi un feudo con porto, spesso con il santuario del Valore | Caverne di ghiaccio e cripte, secondo il tipo di isola |
| ⚓ [Oceani](/wiki/oceani) e barriere coralline | Relitti, rovine sommerse piccole | Nessuno |
| ⚓ Oceani profondi | Relitti più ricchi, rovine sommerse con il kraken, tempio sommerso | Nessuno |
| ⚓ Fosse oceaniche | Città sommersa | Nessuno |
| ⛏️ Sotto ogni bioma | Nessuna | Roccaforte antica, città perduta (Abisso), tana del wyrm antico (Cuore del mondo) |

---

*Vedi anche: [Il Mondo](/wiki/mondo) | [Biomi](/wiki/biomi) | [Grotte e sottosuolo](/wiki/grotte-e-sottosuolo) | [Oceani](/wiki/oceani) | [Spawn delle creature](/wiki/spawn-creature) | [Creature per bioma](/wiki/creature-per-bioma)*
