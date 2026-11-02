---
title: Giorno e notte
slug: giorno-e-notte
category: Mondo
visibility: Pubblica
---
# 🌗 Giorno e notte
*Il sole sorge per tutti nello stesso istante, e nessun letto può farlo sorgere prima*

---

## 📋 Indice

- [Panoramica](#panoramica)
- [Orologio del mondo](#orologio-del-mondo)
- [Le fasi del giorno](#le-fasi-del-giorno)
- [Luce del sole e della luna](#luce-del-sole-e-della-luna)
- [Le fasi della luna](#le-fasi-della-luna)
- [Cosa cambia tra giorno e notte](#cosa-cambia-tra-giorno-e-notte)
- [Creature del giorno e della notte](#creature-del-giorno-e-della-notte)
- [Vedere al buio](#vedere-al-buio)
- [Dormire e riposare](#dormire-e-riposare)
- [Durata del giorno sul server](#durata-del-giorno-sul-server)
- [Stagioni](#stagioni)
- [Consigli](#consigli)
- [FAQ](#faq)

---

## 📜 Panoramica

Come in Minecraft, il mondo di Soulslands ha un ciclo di giorno e notte: il sole sorge, attraversa il cielo e tramonta, poi tocca alla luna. Il cielo però è **uno solo per tutti**: ogni giocatore del server vede la stessa ora, la stessa luce e la stessa fase della luna nello stesso istante, ovunque si trovi.

Un giorno completo dura **2 ore reali**, con 80 minuti di luce e 40 di buio. È la durata del giorno di Ultima Online, dove un'ora di gioco passava in 5 minuti reali, ed è sei volte quella di Minecraft. Chi ospita un server può accorciarla o allungarla (vedi [Durata del giorno sul server](#durata-del-giorno-sul-server)).

La notte cambia il mondo: gli spawn ostili in superficie raddoppiano, i non-morti escono allo scoperto e senza una luce si vede poco o nulla. E la notte non si può saltare: un letto fa riposare il personaggio, ma il sole sorge per tutti alla stessa ora.

> 💡 Sotto terra il giorno e la notte non esistono: nelle [grotte](/wiki/grotte-e-sottosuolo) è sempre buio e le creature del buio compaiono a qualsiasi ora.

---

## 🕰️ Orologio del mondo

Il tempo del mondo si misura con un orologio di **24 ore di gioco**. Con il giorno predefinito scorre così:

| Tempo di gioco | Tempo reale |
|----------------|-------------|
| 1 minuto | 5 secondi |
| 1 ora | 5 minuti |
| 1 giorno (24 ore) | 2 ore |
| 1 ciclo della luna (8 giorni) | 16 ore |
| 12 giorni | 1 giorno reale |
| 84 giorni | 7 giorni reali, cioè una stagione |

- L'ora è la stessa in tutto il mondo: non esistono fusi orari.
- Un **orologio** costruito con [Tinkering](/wiki/skill-tinkering) mostra l'ora di gioco e la fase della luna. Senza orologio basta alzare gli occhi: la posizione del sole o della luna dice più o meno che ore sono.
- L'ora è salvata insieme al mondo: dopo un riavvio del server il sole riparte esattamente da dove si era fermato.

---

## 🌅 Le fasi del giorno

Il giorno ha quattro fasi. Le ore sono quelle dell'orologio di gioco, mentre i minuti reali si contano dall'inizio dell'alba.

| Fase | Ora di gioco | Durata reale | Minuti reali | Cosa succede |
|------|--------------|--------------|--------------|--------------|
| 🌅 **Alba** | 04:00 – 06:00 | 10 minuti | 0 – 10 | Il cielo schiarisce e alle 05:00 il sole spunta all'orizzonte: da quel momento all'aperto non compaiono più mostri, e i non-morti rimasti allo scoperto bruciano o cercano riparo |
| ☀️ **Giorno** | 06:00 – 18:00 | 60 minuti | 10 – 70 | Luce piena. In superficie si muovono animali e creature diurne, le piante crescono, botteghe e mercati sono aperti. Mezzogiorno è alle 12:00 |
| 🌇 **Tramonto** | 18:00 – 20:00 | 10 minuti | 70 – 80 | Il sole tramonta alle 19:00 e da quel momento all'aperto ricominciano gli spawn ostili. In città si accendono i lampioni e le guardie prendono le torce |
| 🌑 **Notte** | 20:00 – 04:00 | 40 minuti | 80 – 120 | Spawn ostili raddoppiati in superficie: non-morti, mongbat, wraith e nightmare escono allo scoperto. Mezzanotte è alle 00:00 |

> ⚠️ Alba e tramonto durano solo 10 minuti reali. Se il sole è già basso e sei lontano da un riparo, è il momento di accendere una torcia.

---

## 💡 Luce del sole e della luna

La luce si misura come in Minecraft, da **0** (buio totale) a **15** (pieno sole), e perde un livello per ogni blocco di distanza dalla sua fonte. Ogni blocco riceve due luci: quella del **cielo**, che arriva dall'alto e cambia con l'ora, e quella dei **blocchi luminosi** come torce e lava. Conta la più forte delle due. Le creature ostili compaiono solo dove la luce è **7 o meno** (vedi [Spawn delle creature](/wiki/spawn-creature)).

| Momento | Ora di gioco | Luce del cielo |
|---------|--------------|----------------|
| Notte | 20:00 – 04:00 | Da 0 a 4, secondo la fase della luna |
| Il sole sorge | 05:00 | 8: gli spawn ostili all'aperto si fermano |
| Pieno giorno | 06:00 – 18:00 | 15 |
| Il sole tramonta | 19:00 | 7: gli spawn ostili all'aperto ricominciano |

Durante l'alba e il tramonto la luce sale o scende un livello alla volta, tra il valore della notte e 15. Anche la notte più chiara, quella di luna piena, resta buia per i mostri: con luce 4 compaiono come in una grotta.

### Meteo e biomi

| Condizione | Luce del cielo di giorno | Effetto |
|------------|--------------------------|---------|
| ☀️ Sereno | 15 | Nessuno spawn ostile all'aperto |
| 🌧️ Pioggia | 12 | Più buio, ma ancora nessuno spawn ostile |
| ⛈️ Temporale | 7 | Spawn ostili ridotti anche di giorno, come al crepuscolo |
| 🌫️ Nebbia fitta | 7 | Come il temporale, e in più il campo visivo si accorcia |
| 🌲 [Foresta profonda](/wiki/bioma-foresta-profonda) | 15 sopra le chiome, molto meno al suolo | Sotto gli alberi i mostri compaiono anche a mezzogiorno |
| 💀 [Terre dei Morti](/wiki/bioma-terre-dei-morti) | 7, perché il sole è sempre velato | I non-morti escono anche di giorno, solo un po' meno numerosi |
| 🌑 [Lande d'Ombra](/wiki/bioma-lande-d-ombra) | Non conta | Crepuscolo perenne: solo torce e incantesimi fermano gli spawn |
| ✨ [Foresta incantata](/wiki/bioma-foresta-incantata) | 15, e di notte foglie e fiori luminosi tengono il suolo in penombra | Spawn ostili ridotti anche di notte |

### Le fonti di luce

| Fonte | Luce | Note |
|-------|------|------|
| Sole a mezzogiorno | 15 | Solo dove si vede il cielo |
| Lava, fuoco da campo, lanterna | 15 | |
| Torcia | 14 | Illumina un raggio di circa 7 blocchi |
| Cristallo di mana (`mana_crystal`) | 10 | Ferma gli spawn solo a un paio di blocchi di distanza |
| Fungo luminoso (`glow_mushroom`) | 7 | Fa vedere, ma non ferma gli spawn |
| Foglie di argentofoglia (`silverleaf_leaves`) | 6 | Tengono in penombra la [foresta incantata](/wiki/bioma-foresta-incantata) di notte (vedi [Alberi](/wiki/alberi)) |
| Luna piena | 4 | Non ferma gli spawn |
| Luna nuova | 0 | Buio totale |

Le luci di tutti i blocchi sono elencate in [Blocchi](/wiki/blocchi).

> 💡 Una torcia ogni 12 blocchi lungo una galleria la tiene tutta a luce 8 o più, e lì non compare nessun mostro.

---

## 🌙 Le fasi della luna

La luna ha **8 fasi** e passa alla successiva ogni giorno a mezzogiorno, quando non si vede, così ogni notte ha una fase sola. Il ciclo parte dalla luna piena, arriva alla luna nuova il quinto giorno e torna alla luna piena dopo 8 giorni: con il giorno predefinito c'è una luna nuova ogni 16 ore reali. Gli effetti valgono di notte, in superficie.

| Giorno | Fase | Luce della luna | Effetti |
|--------|------|-----------------|---------|
| 1 | 🌕 **Luna piena** | 4 | La notte più chiara. Le bestie si agitano: i branchi di [lupi grigi](/wiki/animale-lupo-grigio) e di [lupi bianchi](/wiki/animale-lupo-bianco) sono più numerosi e cacciano più lontano dalla tana, le [melme](/wiki/mostro-slime) delle paludi compaiono più spesso e nella [foresta incantata](/wiki/bioma-foresta-incantata) unicorni e Ki-Rin vengono a bere alle fonti della luna (vedi [Strutture](/wiki/strutture)) |
| 2 | 🌖 **Gibbosa calante** | 3 | Le bestie sono ancora agitate, ma meno |
| 3 | 🌗 **Ultimo quarto** | 2 | Notte normale |
| 4 | 🌘 **Falce calante** | 1 | Notte buia: [spettri](/wiki/mostro-spettro) e [wraith](/wiki/mostro-wraith) più frequenti |
| 5 | 🌑 **Luna nuova** | 0 | Buio totale. I [lich](/wiki/mostro-lich) e le [ombre](/wiki/mostro-ombra) escono in superficie, e nei biomi corrotti possono comparire il Lich antico (Ancient Lich) e il Drago scheletrico (Skeletal Dragon), vedi [Non-morti](/wiki/mostri-non-morti) |
| 6 | 🌒 **Falce crescente** | 1 | Notte buia: spettri e wraith più frequenti |
| 7 | 🌓 **Primo quarto** | 2 | Notte normale |
| 8 | 🌔 **Gibbosa crescente** | 3 | Le bestie cominciano ad agitarsi |

> 💡 Da ricordare: **la luna piena sveglia le bestie, la luna nuova sveglia i morti.**

La luna governa anche i **moongate antichi**, gli archi magici al centro di alcuni cerchi di pietre: si aprono solo di notte e portano a una destinazione diversa per ogni fase lunare, mentre nella notte di luna nuova portano sempre ai margini di un bioma corrotto (vedi [Strutture](/wiki/strutture#santuari-e-moongate)).

### 🔴 La luna rossa

In circa una luna piena su otto la luna sorge **rossa**: in media succede una volta ogni 64 giorni di gioco, cioè ogni 5 giorni reali e poco più. Al tramonto tutti i giocatori ricevono un avviso, e fino all'alba il mondo cambia:

- la luce della luna resta 4, ma si tinge di rosso;
- gli [elementali di sangue](/wiki/mostro-elementale-di-sangue) sono più numerosi nelle [Lande d'Ombra](/wiki/bioma-lande-d-ombra), nelle cripte profonde e vicino agli altari sacrificali;
- le **varianti rare**, cioè le creature più forti con un nome proprio (vedi [Spawn delle creature](/wiki/spawn-creature)), compaiono più spesso;
- valgono anche tutti gli effetti della luna piena.

---

## 🔄 Cosa cambia tra giorno e notte

| Aspetto | ☀️ Di giorno | 🌙 Di notte |
|---------|-------------|-------------|
| **Spawn in superficie** | Soprattutto animali e creature diurne; mostri solo dove il suolo resta buio | Spawn ostili raddoppiati: escono non-morti, mongbat, wraith e nightmare |
| **Spawn sotto terra** | Invariati | Invariati |
| **Non-morti e creature d'ombra** | Bruciano, si indeboliscono o si ritirano (vedi sotto) | Liberi di vagare |
| **Vista** | Piena | Ridotta: serve una luce o una razza che vede al buio (vedi [Vedere al buio](#vedere-al-buio)) |
| **Piante** | Crescono | Quasi tutte si fermano, a meno di luci artificiali vicine (vedi sotto) |
| **Città NPC** | Botteghe e mercato aperti | Lampioni accesi, guardie con la torcia, botteghe chiuse dalle 22:00 alle 06:00 |
| **Nascondersi** | Difficile in pieno sole su una piana aperta | Più facile al buio, lontano dalle luci (vedi [Hiding](/wiki/skill-hiding)) |
| **Clima** | Nel [deserto](/wiki/bioma-deserto) il caldo consuma la stamina | Nel deserto la temperatura crolla, nella [tundra](/wiki/bioma-tundra) il freddo morde di più |

### ☀️ Il sole e i non-morti

Quando sorge il sole, i non-morti e le creature d'ombra che stanno **sotto il cielo aperto**, senza blocchi sopra la testa, ne subiscono la luce.

| Creature | Al sole |
|----------|---------|
| [Scheletro](/wiki/mostro-scheletro), [Zombie](/wiki/mostro-zombie) | Prendono fuoco e bruciano lentamente finché non trovano ombra o acqua |
| [Ghoul](/wiki/mostro-ghoul), [Scheletro mago](/wiki/mostro-scheletro-mago), [Cavaliere d'ossa](/wiki/mostro-cavaliere-d-ossa) | Si indeboliscono e cercano l'ombra di alberi, rovine e grotte; se restano al sole bruciano anche loro |
| [Spettro](/wiki/mostro-spettro), [Wraith](/wiki/mostro-wraith), [Ombra](/wiki/mostro-ombra) | Si dissolvono all'alba senza lasciare corpo |
| [Mummia](/wiki/mostro-mummia), [Lich](/wiki/mostro-lich) | Non escono mai alla luce del sole |
| [Senza testa](/wiki/mostro-headless-one), [Mongbat](/wiki/mostro-mongbat), [Nightmare](/wiki/mostro-nightmare), [Wisp](/wiki/mostro-wisp) | Non bruciano, ma all'alba tornano nelle grotte e nei boschi più fitti |

- Un non-morto **indebolito** infligge un quarto di danno in meno e non rigenera la vita.
- L'ombra di un albero o di un tetto, la pioggia, il temporale, la nebbia fitta e l'acqua proteggono i non-morti dal sole.
- Nelle [Terre dei Morti](/wiki/bioma-terre-dei-morti) e nelle [Lande d'Ombra](/wiki/bioma-lande-d-ombra) il sole è velato: lì i non-morti non bruciano e non si indeboliscono.
- Un non-morto ucciso dal sole lascia il corpo con il suo bottino, come se lo avessi ucciso tu; gli spiriti che si dissolvono invece non lasciano nulla.
- La regola vale solo per le creature: i personaggi dei giocatori non bruciano al sole, nemmeno i [Vampiri](/wiki/razza-vampiro).

> 💡 L'alba è il momento migliore per cacciare i non-morti in superficie: sono deboli e pensano a ripararsi più che a combattere (vedi [Non-morti](/wiki/mostri-non-morti)).

### 🌾 Le piante e la luce

| Pianta | Quando cresce |
|--------|---------------|
| Coltivazioni su `farmland`: `wheat`, `cotton_plant`, `flax_plant` (ognuna con i blocchi `_sprout`, `_growing`, `_ripe`), `garlic_plant`, `ginseng_plant` | Solo con luce 9 o più: di giorno all'aperto, oppure di notte e sotto terra vicino a torce e lanterne |
| Germogli d'albero (`<specie>_sapling`, vedi [Alberi](/wiki/alberi)) | Di solito con luce 9 o più. Tasso, quercia antica e cuoredilegno sono alberi d'ombra e si accontentano di 4; albero sanguigno, albero morto e albero carbonizzato crescono anche al buio |
| Funghi: `brown_mushroom`, `red_mushroom`, `glow_mushroom` | Si diffondono solo in penombra o al buio, con luce 12 o meno; su `mycelium` anche al sole |
| `nightshade_plant` | Cresce anche al buio: è l'unica pianta di reagenti che si può coltivare in una cantina |

Il concime (letame, farina d'ossa, guano di [mongbat](/wiki/mostro-mongbat)) accelera la crescita ma non sostituisce la luce: un campo al buio non cresce, neanche concimato.

La radice di mandragora (`mandrake_plant`) cresce a ogni ora, ma si riconosce solo di notte: chi la cerca gira per paludi e Terre dei Morti con il buio (vedi [Blocchi](/wiki/blocchi#reagenti-nel-mondo)).

### 🏰 Le città di notte

- Al tramonto le città NPC accendono da sole lampioni e bracieri lungo le strade e nelle piazze, che restano illuminati fino all'alba.
- Di notte le [guardie cittadine](/wiki/guardie-cittadine) girano con una **torcia** in mano: si vedono da lontano e rischiarano i vicoli. Proteggono come di giorno e arrivano quando qualcuno le chiama.
- Le **botteghe** e i banchi del mercato chiudono dalle 22:00 alle 06:00, cioè per 40 minuti reali, quando i mercanti vanno a dormire. **Banca, guaritore, stalle, taverna e locanda** restano sempre aperti.
- Nella **locanda** si affitta un letto per passare la notte e uscire dal gioco al sicuro (vedi [Dormire e riposare](#dormire-e-riposare)).

---

## 🐺 Creature del giorno e della notte

Ogni creatura ha le sue ore: in quelle è attiva e si incontra più spesso, nelle altre dorme, si nasconde o si ritira. Le ore contano **in superficie**: sotto terra, nelle cripte e nei dungeon è sempre buio, quindi anche le creature notturne sono attive a ogni ora.

| Quando | Animali | Mostri |
|--------|---------|--------|
| ☀️ **Di giorno** | [Aquila](/wiki/animale-aquila), [Capra](/wiki/animale-capra), [Capra di montagna](/wiki/animale-capra-di-montagna), [Cavallo](/wiki/animale-cavallo), [Corvo](/wiki/animale-corvo) (anche al crepuscolo), [Gallina](/wiki/animale-gallina), [Gorilla](/wiki/animale-gorilla), [Lama](/wiki/animale-lama), [Maiale](/wiki/animale-maiale), [Mucca](/wiki/animale-mucca), [Orso bruno](/wiki/animale-orso-bruno), [Orso nero](/wiki/animale-orso-nero), [Ostard della foresta](/wiki/animale-ostard-della-foresta), [Pecora](/wiki/animale-pecora), [Serpente](/wiki/animale-serpente), [Toro](/wiki/animale-toro), [Tricheco](/wiki/animale-tricheco) (di notte resta in acqua), [Uccello](/wiki/animale-uccello) | [Arpia](/wiki/mostro-arpia), [Drake](/wiki/mostro-drake) (presente sempre, più attivo di giorno), [Wyvern](/wiki/mostro-wyvern), [Unicorno](/wiki/mostri-bestie-magiche) |
| 🌅 **All'alba e al tramonto** | [Cervo](/wiki/animale-cervo), [Coniglio](/wiki/animale-coniglio), [Leopardo delle nevi](/wiki/animale-leopardo-delle-nevi), [Ostard del deserto](/wiki/animale-ostard-del-deserto), [Puma](/wiki/animale-puma) | [Tentacolo di palude](/wiki/mostro-tentacolo-di-palude) |
| 🌙 **Di notte** | [Cinghiale](/wiki/animale-cinghiale), [Lepre](/wiki/animale-lepre), [Lupo grigio e lupo dei boschi](/wiki/animale-lupo-grigio), [Pantera](/wiki/animale-pantera), [Rana toro](/wiki/animale-rana-toro), [Ratto](/wiki/animale-ratto), [Rospo gigante](/wiki/animale-rospo-gigante) | [Cavaliere d'ossa](/wiki/mostro-cavaliere-d-ossa), [Ghoul](/wiki/mostro-ghoul), [Ki-Rin](/wiki/mostri-bestie-magiche), [Mongbat](/wiki/mostro-mongbat), [Mummia](/wiki/mostro-mummia), [Nightmare](/wiki/mostro-nightmare), [Scheletro](/wiki/mostro-scheletro), [Scheletro mago](/wiki/mostro-scheletro-mago), [Senza testa](/wiki/mostro-headless-one), [Serpente degli abissi](/wiki/mostro-serpente-degli-abissi), [Spettro](/wiki/mostro-spettro), [Wisp](/wiki/mostro-wisp), [Wraith](/wiki/mostro-wraith), [Zombie](/wiki/mostro-zombie) |
| 🌗 **Sempre, ma più di notte** | [Gatto](/wiki/animale-gatto) | [Brigante](/wiki/mostro-brigante), [Elementale del ghiaccio](/wiki/mostro-elementale-del-ghiaccio), [Elementale dell'acqua](/wiki/mostro-elementale-dell-acqua), [Gatto infernale](/wiki/mostro-gatto-infernale), [Lizardman](/wiki/mostro-lizardman), [Ragno gigante](/wiki/mostro-ragno-gigante), [Scorpione gigante](/wiki/mostro-scorpione-gigante), [Troll](/wiki/mostro-troll) |
| 🌑 **Solo nelle notti senza luna** | Nessuno | [Lich](/wiki/mostro-lich) e [Ombra](/wiki/mostro-ombra) in superficie; spawn rari del [Lich antico e del Drago scheletrico](/wiki/mostri-non-morti) |
| 🔁 **Giorno e notte** | [Alligatore](/wiki/animale-alligatore), [Cane](/wiki/animale-cane), [Delfino](/wiki/animale-delfino), [Lucertola di lava](/wiki/animale-lucertola-di-lava), [Lupo bianco](/wiki/animale-lupo-bianco), [Orso grizzly](/wiki/animale-orso-grizzly), [Orso polare](/wiki/animale-orso-polare), [Ostard frenetico](/wiki/animale-ostard-frenetico), [Ratto gigante](/wiki/animale-ratto-gigante), [Serpente del ghiaccio](/wiki/animale-serpente-del-ghiaccio), [Serpente gigante](/wiki/animale-serpente-gigante), [Serpente gigante del ghiaccio](/wiki/animale-serpente-gigante-del-ghiaccio) | [Albero mietitore](/wiki/mostro-reaper), [Arpia di pietra](/wiki/mostro-arpia-di-pietra), [Balron](/wiki/mostro-balron), [Ciclope](/wiki/mostro-ciclope), [Corpser](/wiki/mostro-corpser), [Demone](/wiki/mostro-demone), [Demone del ghiaccio](/wiki/mostro-demone-del-ghiaccio), [Drago](/wiki/mostro-drago), [Elementale del fuoco](/wiki/mostro-elementale-del-fuoco), [Elementale del veleno](/wiki/mostro-elementale-del-veleno), [Elementale della terra](/wiki/mostro-elementale-della-terra), [Elementale di sangue](/wiki/mostro-elementale-di-sangue), [Ettin](/wiki/mostro-ettin), [Gargoyle di pietra](/wiki/mostro-gargoyle-di-pietra), [Gargoyle selvaggio](/wiki/mostro-gargoyle), [Gazer](/wiki/mostro-gazer), [Imp](/wiki/mostro-imp), [Kraken](/wiki/mostro-kraken), [Melma](/wiki/mostro-slime), [Ofidiano](/wiki/mostro-ophidian), [Ogre](/wiki/mostro-ogre), [Orco](/wiki/mostro-orco), [Ragno del gelo](/wiki/mostro-ragno-del-gelo), [Ratman](/wiki/mostro-ratman), [Segugio infernale](/wiki/mostro-segugio-infernale), [Serpente marino](/wiki/mostro-serpente-marino), [Signore dei lich](/wiki/mostro-signore-dei-lich), [Terathan](/wiki/mostro-terathan), [Titano](/wiki/mostro-titano), [Troll del gelo](/wiki/mostro-troll-del-gelo), [Wyrm antico](/wiki/mostro-wyrm-antico) |
| ⛈️ **Solo con il maltempo** | Nessuno | [Elementale dell'aria](/wiki/mostro-elementale-dell-aria) durante i temporali, [Elementale della neve](/wiki/mostro-elementale-della-neve) durante le bufere (nelle [grotte di ghiaccio](/wiki/grotte-e-sottosuolo#grotte-di-ghiaccio) a ogni ora) |

La scheda di ogni creatura indica le sue ore alla voce **Quando**. Per sapere quali creature vivono in ogni bioma vedi [Creature per bioma](/wiki/creature-per-bioma).

---

## 👁️ Vedere al buio

In Soulslands ciò che il personaggio non vede è mostrato in grigio. Di notte la vista dipende dalla luna e dalla razza; sotto terra, senza una luce, quasi tutti sono ciechi.

| Razza | Vista al buio | Di notte all'aperto | Nelle grotte senza luce |
|-------|---------------|---------------------|-------------------------|
| [Umano](/wiki/razza-umano), [Gargoyle](/wiki/razza-gargoyle) | Normale | Sagome fino a circa 16 blocchi con la luna piena, appena 3 o 4 blocchi con la luna nuova | Quasi nulla: serve una luce |
| [Elfo](/wiki/razza-elfo), [Orco](/wiki/razza-orco) | Crepuscolare | Quasi come di giorno: circa 32 blocchi con la luna piena e 16 con la luna nuova | Pochi blocchi: serve comunque una luce |
| [Nano](/wiki/razza-nano) | Scurovisione a corto raggio | Come la vista normale, ma i blocchi entro circa 8 si vedono sempre | I blocchi entro circa 8; per vedere lontano serve una lanterna |
| [Elfo Oscuro](/wiki/razza-elfo-oscuro), [Demone](/wiki/razza-demone) | Scurovisione | Almeno 16 blocchi in toni smorzati, con qualsiasi luna | Circa 16 blocchi in toni smorzati |
| [Vampiro](/wiki/razza-vampiro) | Visione notturna completa | Come di giorno | Come di giorno |

I raggi sono indicativi e possono cambiare con il bilanciamento.

- **Luci portatili**: una torcia o una lanterna in mano illumina intorno a te mentre cammini, ma ti fa notare da lontano. Chi vede al buio ti scorge molto prima che tu possa vedere lui.
- **Magia e pozioni**: l'incantesimo Nightsight di [Magery](/wiki/skill-magery) e la pozione di Visione notturna di [Alchemy](/wiki/skill-alchemy) danno a chiunque, per un po' di tempo, la vista notturna. La pozione si prepara con ingredienti come l'occhio di [gazer](/wiki/mostro-gazer), l'ala di [mongbat](/wiki/mostro-mongbat), i baffi di [gatto](/wiki/animale-gatto) o l'occhio di [ragno gigante](/wiki/mostro-ragno-gigante); con l'occhio di [gatto infernale](/wiki/mostro-gatto-infernale) dura il doppio.
- **Vedere non è illuminare**: per gli spawn conta la luce dei blocchi, non i tuoi occhi. Anche chi vede al buio deve piazzare torce per tenere lontani i mostri (vedi [Razze](/wiki/razze)).

---

## 🛏️ Dormire e riposare

Il **letto** è un mobile costruito con [Carpentry](/wiki/skill-carpentry) e si piazza come un blocco.

| Cosa fa il letto | Come funziona |
|------------------|---------------|
| **Riposare** | Mentre sei a letto, vita e stamina si rigenerano al doppio della velocità |
| **Uscire dal gioco al sicuro** | Se ti corichi nel letto della tua casa, in una casa della tua gilda o in un letto affittato in una **locanda**, esci subito dal mondo e il personaggio è al sicuro (vedi [Persistenza del mondo](/wiki/persistenza-del-mondo)). Quando rientri ti svegli nel letto |
| **Far passare la notte** | **No**: la notte dura per tutti 40 minuti reali (vedi sotto) |
| **Rinascere** | **No**: il letto non è un punto di rinascita. Chi muore diventa fantasma dove è caduto (vedi [Morte e fantasmi](/wiki/morte-e-fantasmi)) |

- Non puoi coricarti se un mostro ostile è a pochi blocchi da te o se sei in combattimento.
- Si può dormire a qualsiasi ora, anche di giorno.
- Nelle terre selvagge il letto è la **tenda** o il sacco a pelo: stesi accanto al fuoco di un accampamento sicuro ([Camping](/wiki/skill-camping)) permettono anch'essi di uscire dal gioco al sicuro, come in Ultima Online. Un letto piazzato in mezzo al nulla, senza accampamento, non basta: il personaggio resta nel mondo per 5 minuti, come in qualsiasi altro posto.

### Perché la notte non si salta

In Minecraft, quando tutti i giocatori di un mondo dormono, la notte passa in un attimo. In Soulslands non può succedere: il mondo è **uno solo** e lo condividono fino a migliaia di giocatori, che vivono la stessa notte nello stesso istante. Chi dorme riposa e può uscire dal gioco, ma non può far sorgere il sole per tutti gli altri. Chi non vuole affrontare il buio passa la notte in città, in casa o fuori dal gioco.

---

## ⚙️ Durata del giorno sul server

La durata del giorno è un'**impostazione del server**: chi ospita un mondo può sceglierla tra **20 minuti**, come in Minecraft, e **4 ore**. Le proporzioni restano sempre le stesse: un dodicesimo di alba, metà di giorno, un dodicesimo di tramonto e un terzo di notte.

| Durata del giorno | Alba | Giorno | Tramonto | Notte | 1 ora di gioco | Ciclo della luna |
|-------------------|------|--------|----------|-------|----------------|------------------|
| 20 minuti (minimo, come Minecraft) | 1 min 40 s | 10 min | 1 min 40 s | 6 min 40 s | 50 s | 2 ore 40 min |
| 1 ora | 5 min | 30 min | 5 min | 20 min | 2 min 30 s | 8 ore |
| **2 ore (predefinita)** | 10 min | 60 min | 10 min | 40 min | 5 min | 16 ore |
| 4 ore (massimo) | 20 min | 2 ore | 20 min | 1 ora 20 min | 10 min | 32 ore |

- Si imposta nel file di configurazione del server, `server.toml`, ad esempio con `day_length_minutes = 120` nella sezione `[world]` (il nome della chiave non è ancora definitivo).
- Si può cambiare anche su un mondo già avviato: l'ora resta la stessa e cambia solo la velocità con cui passa.
- Il server conta il tempo in tick, 20 al secondo: con il giorno predefinito un'ora di gioco vale 6.000 tick e un giorno intero 144.000.
- Tutto ciò che si misura in **giorni di gioco** segue la durata scelta: le fasi della luna, la crescita delle piante, il latte e la lana che gli animali domati danno una volta al giorno di gioco. I tempi in **minuti reali** invece non cambiano: il minuto da fantasma e il decadimento dei corpi ([Morte e fantasmi](/wiki/morte-e-fantasmi)), il logout, il ritorno dei boss e la durata delle stagioni.

---

## 🍂 Stagioni

Oltre al giorno e alla notte il mondo ha **quattro stagioni** di 7 giorni reali ciascuna, uguali per tutti come l'ora del giorno. Le stagioni cambiano il clima e il paesaggio, non la durata del giorno: l'alba arriva sempre alle 04:00 e la notte alle 20:00. Il meteo è descritto nella pagina [Il Mondo](/wiki/mondo#meteo-e-stagioni).

| Stagione | Cosa cambia |
|----------|-------------|
| 🌱 **Primavera** | Piogge più frequenti, prati fioriti di `red_poppy` e `daisy` |
| ☀️ **Estate** | Le paludi si restringono, il deserto è più caldo e il fuoco si propaga facilmente su foglie ed erba secca |
| 🍂 **Autunno** | Le latifoglie cambiano colore: aceri rosso fuoco, betulle e frassini gialli, faggi color rame (vedi [Alberi](/wiki/alberi)) |
| ❄️ **Inverno** | La neve scende fino alle foreste temperate, i laghi del nord ghiacciano e gli orsi passano più tempo nelle grotte |

---

## 💡 Consigli

- Guarda il cielo: quando il sole è basso mancano 10 minuti reali al buio, abbastanza per rientrare o accendere un fuoco.
- Porta sempre qualche torcia, anche per un viaggio breve: una caduta in un burrone o un temporale possono lasciarti al buio.
- Scegli la luna giusta: la luna piena per cacciare lupi e melme, la luna nuova per i lich e i loro tesori, se te la senti.
- Caccia i non-morti all'alba, quando sono deboli.
- Metti qualche lanterna accanto ai campi: i raccolti crescono anche di notte.
- Prima di uscire dal gioco lontano da casa cerca una locanda o prepara un accampamento sicuro.

---

## ❓ FAQ

**D: Se dormo, la notte passa?**
R: No. Il letto ti fa riposare e ti permette di uscire dal gioco al sicuro, ma il mondo è condiviso e la notte dura per tutti 40 minuti reali.

**D: Tutti i giocatori vedono la stessa ora?**
R: Sì. C'è un solo cielo per tutto il mondo: quando per te è mezzanotte, è mezzanotte per tutti.

**D: Sotto terra è giorno o notte?**
R: Né l'uno né l'altra: la luce del cielo non arriva sotto terra, quindi è sempre buio e gli spawn non cambiano con l'ora. Fanno eccezione i burroni aperti verso il cielo, dove il sole arriva fino in fondo, e le [grotte di ghiaccio](/wiki/grotte-e-sottosuolo#grotte-di-ghiaccio) vicine alla superficie, dove di giorno filtra un po' di luce attraverso il ghiaccio.

**D: Il mio Vampiro brucia al sole?**
R: No. Il sole ferisce soltanto i non-morti e le creature d'ombra, mai i personaggi dei giocatori.

**D: Il mio server può avere giorni più corti?**
R: Sì, da 20 minuti fino a 4 ore. Vedi [Durata del giorno sul server](#durata-del-giorno-sul-server).

**D: Come faccio a sapere che ore sono?**
R: Guarda il sole o la luna, oppure costruisci un orologio con [Tinkering](/wiki/skill-tinkering): mostra l'ora di gioco e la fase della luna.

---

*Vedi anche: [Il Mondo](/wiki/mondo) | [Spawn delle creature](/wiki/spawn-creature) | [Grotte e sottosuolo](/wiki/grotte-e-sottosuolo) | [Razze](/wiki/razze) | [Creature per bioma](/wiki/creature-per-bioma)*
