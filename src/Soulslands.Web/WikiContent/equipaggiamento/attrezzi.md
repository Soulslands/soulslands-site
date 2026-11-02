---
title: Attrezzi
slug: attrezzi
category: Equipaggiamento
visibility: Pubblica
---
# ⛏️ Attrezzi

*Gli strumenti per lavorare il mondo e creare oggetti*

---

## 📜 Panoramica

In Soulslands il mondo è fatto di blocchi che si possono rompere, raccogliere e ricostruire. A mani nude si rompe tutto, ma lentamente: 3 volte il tempo sui blocchi che hanno un attrezzo associato. Terra, sabbia, tronchi e piante lasciano comunque i loro materiali; pietra e minerali senza piccone non lasciano nulla. Per tutto il resto servono gli **attrezzi**: il piccone per la pietra, l'accetta per il legno, la pala per la terra, e gli strumenti da artigiano per trasformare le materie prime in oggetti.

Gli attrezzi seguono le regole di Ultima Online:

- Ogni attrezzo è legato a una **skill**: usarlo fa salire quella skill.
- Ogni attrezzo ha un numero di **usi** (durabilità). A 0 si rompe.
- Gli attrezzi da artigiano si costruiscono quasi tutti con [Tinkering](/wiki/skill-tinkering): l'inventore è il fornitore di tutti gli altri artigiani.

> 💡 Rompere un blocco con l'attrezzo sbagliato (o a mani nude, se il blocco ha un attrezzo associato) è possibile ma richiede **3 volte** il tempo normale. Pietra, minerali e gli altri blocchi che senza l'attrezzo giusto non lasciano nulla, a mani nude o con l'attrezzo sbagliato non rendono niente.

---

## 🌍 Attrezzi da raccolta

Questi attrezzi agiscono direttamente sui blocchi del mondo.

| Attrezzo | Nome UO | Skill | Cosa fa nel mondo a voxel | Usi | Chi lo crea |
|----------|---------|-------|---------------------------|-----|-------------|
| **Piccone** | Pickaxe | [Mining](/wiki/skill-mining) | Rompe blocchi di pietra, roccia e **minerale**. Dai blocchi di minerale ottieni minerale grezzo, in quantità fissa. Qualsiasi [minerale](/wiki/minerali) si scava da skill 0.0: la skill e il materiale del piccone decidono solo quanto ci metti | 50 | Tinkering |
| **Pala** | Shovel | [Mining](/wiki/skill-mining) | Scava rapidamente terra, sabbia, ghiaia, argilla e neve.  La ghiaia dà ghiaia: la selce si ottiene con una ricetta (3 ghiaia fanno 1 selce, proposta) | 50 | Tinkering |
| **Accetta** | Hatchet | [Lumberjacking](/wiki/skill-lumberjacking) | Abbatte gli alberi: colpendo il tronco alla base, l'albero crolla e lascia **tronchi**. Taglia anche blocchi di legno lavorato. Il tipo di [legno](/wiki/legni) dipende dall'albero e dal bioma | 50 | Tinkering |
| **Ascia** (qualsiasi) | Axe | [Lumberjacking](/wiki/skill-lumberjacking) | Come l'accetta, più lenta ma è anche un'arma migliore. Vedi [Asce](/wiki/armi-asce) | — | Blacksmithy |
| **Canna da pesca** | Fishing Pole | [Fishing](/wiki/skill-fishing) | Si lancia in un blocco d'acqua: pesci, scarpe vecchie, bottiglie con messaggi e, in alto mare, creature marine. Vedi [Oceani](/wiki/oceani) | 50 | Carpentry |
| **Coltello da scuoiare** | Skinning Knife | — | Scuoia e smembra i cadaveri per ricavarne cuoio, carne, piume e scaglie. Vedi [Scuoiare e smembrare](/wiki/scuoiare-e-smembrare) e [Attrezzi per le creature](#attrezzi-per-le-creature) | 50 | Tinkering |
| **Mannaia / Coltello da macellaio** | Cleaver / Butcher Knife | — | Come il coltello da scuoiare, con più carne e meno cuoio | 50 | Tinkering |
| **Forbici** | Scissors | [Tailoring](/wiki/skill-tailoring) | Tagliano il cuoio grezzo in pezzi lavorabili, tosano le pecore e recuperano stoffa dai vestiti vecchi | 50 | Tinkering |
| **Zappa** *(nuovo)* | — | — | Ara i blocchi di terra per coltivare cotone, lino, grano e ortaggi | 50 | Tinkering |
| **Secchio** *(nuovo)* | — | — | Raccoglie e versa un blocco d'acqua o di lava; serve anche per mungere | 100 | Tinkering |

### Velocità di scavo

Regole di scavo (decisione del PM per delega di Aruto, 18/10/2026; il tempo base di ogni blocco è la sua durezza, quello con l'attrezzo giusto è nella tabella):

| Situazione | Regola |
|---|---|
| Attrezzo giusto | Tempo base del blocco |
| Attrezzo sbagliato | **3 volte** il tempo base |
| Mani nude su un blocco senza attrezzo associato (`tool = "none"`) | Il tempo base del blocco, cioè la sua durezza |
| Mani nude su un blocco che ha un attrezzo associato | **3 volte** il tempo base, come con l'attrezzo sbagliato |
| Pietra, minerali e altri blocchi che senza l'attrezzo giusto non lasciano nulla | Senza l'attrezzo giusto non lasciano nulla (come in Minecraft) |
| Tronchi, terra, sabbia | Si rompono anche a mani nude, a 3 volte il tempo, e lasciano comunque i loro materiali |
| Portata | 5 blocchi, per scavare e per piazzare |
| Livelli di attrezzo | Non esistono (come in UO): qualsiasi piccone scava qualsiasi minerale, da Mining 0.0. Il materiale dell'attrezzo decide i colpi necessari (tabella sotto) e la durata; la skill li riduce |

| Blocco | Attrezzo giusto | Tempo con l'attrezzo giusto |
|--------|-----------------|------------------------------|
| Terra, sabbia | pala | 0,3 s |
| Legno (tronco) | accetta | 1 s |
| Pietra | piccone | 1,5 s |
| Minerale comune | piccone | 2 s |
| Minerale raro | piccone | 3-5 s |

### Colpi per materiale e skill

Il tempo di scavo è il tempo base del blocco (tabella sopra) per i **colpi** dell'attrezzo diviso 10. I colpi dipendono dal **materiale dell'attrezzo** e si riducono con la skill di raccolta del blocco (Mining per pietra e minerali, Lumberjacking per i tronchi): **colpi = colpi del materiale × (1 − skill/200)**, mai meno di 1. Un attrezzo da 10 colpi a skill 0.0 scava esattamente il tempo base: per questo i tempi della tabella sono quelli di un attrezzo di pietra a skill 0.0.

| Materiale dell'attrezzo | Colpi a skill 0.0 | A 50.0 | A 100.0 |
|-------------------------|-------------------|--------|---------|
| Pietra | 10 | 8 | 5 |
| Iron, Rusty | 8 | 6 | 4 |
| Livello 1 (Old Copper, Steel) | 7 | 6 | 4 |
| Livello 2 (Dull Copper, Rose, Shadow Iron, Copper, Silver) | 6 | 5 | 3 |
| Livello 3 (Bronze, Orialco, Gold, Blood Rock, Agapite) | 5 | 4 | 3 |
| Livello 4 (Mytheril, Verite, Black Rock, Titanio, Valorite, Cobalto, Demonic) | 4 | 3 | 2 |

*Valori decisi da Aruto (28/10/2026); le colonne a 50.0 e 100.0 sono calcolate con la formula, arrotondando per eccesso.* Un piccone di Demonic a Mining 100.0 scava un minerale in 2 colpi contro i 10 della pietra a 0.0. Alcuni [biomi](/wiki/biomi) e le zone profonde delle [grotte](/wiki/grotte-e-sottosuolo) hanno rocce più dure.

---

## 🐾 Attrezzi per le creature

Ogni creatura dà materiali diversi a seconda dello **strumento** che usi: con il solo coltello da una capra ottieni pelle e carne, ma per le corna serve la mannaia e per il latte il secchio. Alcune risorse si raccolgono **da vive**, senza uccidere l'animale, e si rinnovano nel tempo. L'elenco completo, creatura per creatura, è in [Materiali delle creature](/wiki/materiali-creature).

| Attrezzo | ID oggetto | Da viva | Da morta | Usi | Chi lo crea |
|----------|------------|---------|----------|-----|-------------|
| **Coltello da scuoiare** | `tool_skinning_knife` | — | Pelli, carne, piume, scaglie, seta, ghiandole e organi morbidi | 50 | Tinkering |
| **Mannaia** | `tool_cleaver` | — | Ossa, corna, zanne, denti, artigli, zoccoli, carapaci | 50 | Tinkering |
| **Forbici** | `tool_scissors` | Tosano lana, pelo e crine (pecore, lama, cavalli) | — | 50 | Tinkering |
| **Secchio** *(nuovo)* | `tool_bucket` | Munge il latte (mucche, capre, pecore) | Raccoglie melma e liquidi in grande quantità | 100 | Tinkering |
| **Fiala vuota** | `empty_vial` | Munge il veleno da serpenti e ragni domati o immobilizzati | Sangue, veleno, icore, ectoplasma | 1 (si riempie) | Si compra dagli alchimisti |
| **Sacchetto per reagenti** *(nuovo)* | `tool_reagent_pouch` | — | Polveri e ceneri (polvere spettrale, polvere di lich, cenere di demone, essenze degli elementali): senza il sacchetto svaniscono | 30 | Tailoring |
| **Piccone** | `tool_pickaxe` | — | Minerale, cristalli e pietra dai corpi di elementali e gargoyle | 50 | Tinkering |
| **A mani nude** | — | Uova, piume cadute, letame | Oggetti già staccati | — | — |

> 💡 [Animal Lore](/wiki/skill-animal-lore) ti dice se un animale è pronto per essere munto o tosato; ogni creatura dà sempre la stessa quantità di materiali, con qualsiasi skill.

---

## 🔨 Attrezzi da artigiano

Questi strumenti aprono il **menu di crafting** della loro skill. Molti richiedono anche un **blocco stazione** vicino (forgia, incudine, telaio...).

| Attrezzo | Nome UO | Skill | Cosa crea | Stazione necessaria | Chi lo crea |
|----------|---------|-------|-----------|--------------------|-------------|
| **Martello da fabbro** | Smith's Hammer | [Blacksmithy](/wiki/skill-blacksmithy) | Armi e armature in metallo, scudi, ripara il metallo | Forgia + incudine entro 2 blocchi | Tinkering |
| **Mazza da forgia** | Sledge Hammer | [Blacksmithy](/wiki/skill-blacksmithy) | Come il martello da fabbro, più usi | Forgia + incudine | Tinkering |
| **Tenaglie** | Tongs | [Blacksmithy](/wiki/skill-blacksmithy) | Come il martello da fabbro; ripara senza consumare durabilità extra | Forgia + incudine | Tinkering |
| **Kit da sarto** | Sewing Kit | [Tailoring](/wiki/skill-tailoring) | Vestiti, armature di cuoio, borchiate e d'osso, borse | — | Tinkering |
| **Attrezzi da inventore** | Tinker's Tools | [Tinkering](/wiki/skill-tinkering) | Attrezzi, gioielli, serrature, trappole, congegni | — | Tinkering |
| **Sega** | Saw / Dovetail Saw | [Carpentry](/wiki/skill-carpentry) | Mobili, bastoni, scudi di legno, casse, blocchi di legno lavorato | Banco da lavoro *(nuovo)* | Tinkering |
| **Pialla** | Smoothing Plane / Jointing Plane | [Carpentry](/wiki/skill-carpentry) | Come la sega (strumento alternativo) | Banco da lavoro | Tinkering |
| **Martello da carpentiere** *(nuovo)* | — | [Carpentry](/wiki/skill-carpentry) | Piazza e ruota blocchi da costruzione nelle case. Vedi [Sistema costruzioni](/wiki/sistema-costruzioni) | — | Tinkering |
| **Attrezzi da arcaio** | Fletcher's Tools | [Bowcraft/Fletching](/wiki/skill-bowcraft-fletching) | Archi, balestre, aste di freccia, frecce e dardi | — | Tinkering |
| **Mortaio e pestello** | Mortar and Pestle | [Alchemy](/wiki/skill-alchemy) | Pozioni, usando reagenti e bottiglie vuote. Vedi [Tossicità delle pozioni](/wiki/tossicita-pozioni) | — | Tinkering |
| **Padella / Mattarello / Setaccio** | Skillet / Rolling Pin / Flour Sifter | [Cooking](/wiki/skill-cooking) | Cibo e bevande | Fuoco o forno | Tinkering |
| **Penna da scriba** | Scribe's Pen | [Inscription](/wiki/skill-inscription) | Pergamene magiche e libri | — | Tinkering |
| **Penna da cartografo** | Mapmaker's Pen | [Cartography](/wiki/skill-cartography) | Mappe della zona esplorata | — | Tinkering |
| **Grimaldello** | Lockpick | [Lockpicking](/wiki/skill-lockpicking) | Apre forzieri e porte chiuse a chiave | — | Tinkering |
| **Bende** | Bandage | [Healing](/wiki/skill-healing) | Curano le ferite; si ricavano tagliando la stoffa con le forbici | — | chiunque, con le forbici |

### Strumenti musicali

| Strumento | Nome UO | Skill |
|-----------|---------|-------|
| Liuto | Lute | [Musicianship](/wiki/skill-musicianship) |
| Arpa | Lap Harp / Standing Harp | Musicianship |
| Tamburo | Drum | Musicianship |
| Tamburello | Tambourine | Musicianship |
| Flauto di bambù | Bamboo Flute | Musicianship |

Il [Bardo](/wiki/classe-bardo) li usa per calmare, provocare o scoraggiare le creature. Si costruiscono con [Carpentry](/wiki/skill-carpentry).

---

## 🧱 Blocchi stazione

Nel mondo a voxel le stazioni di lavoro sono **blocchi** che si piazzano nella propria casa, bottega o [città di gilda](/wiki/citta-di-gilda).

| Stazione | Usata per | Come si ottiene |
|----------|-----------|-----------------|
| **Forgia** | Fondere minerale in lingotti, Blacksmithy | Carpentry + Blacksmithy, pietra e lingotti |
| **Incudine** | Blacksmithy | Blacksmithy, lingotti di ferro |
| **Banco da lavoro** *(nuovo)* | Carpentry | Carpentry, assi |
| **Filatoio** | Filare cotone, lino, lana | Carpentry |
| **Telaio** | Tessere la stoffa | Carpentry |
| **Forno** | Cooking (pane, torte) | Carpentry, pietra |
| **Vasca da tintore** | Tingere vestiti e cuoio | Carpentry |

---

## ⭐ Qualità e materiali degli attrezzi

- Non esiste la [qualità eccezionale](/wiki/qualita-eccezionale): un attrezzo ha gli stessi usi chiunque lo fabbrichi.
- Un attrezzo spezzato dall'usura lascia indietro **un quinto** dei materiali con cui era fatto (arrotondato per difetto); un attrezzo piazzato (una forgia, un banco) si recupera intero con l'azione di raccolta.
- Gli attrezzi in metallo forgiati con metalli rari **lavorano più in fretta**: un piccone in [Steel](/wiki/minerale-steel) dura di più, un piccone in un metallo raro scava con meno colpi. Nessun minerale richiede una skill: il materiale e la skill sommano i loro effetti sul tempo.

---

## ❓ FAQ

**D: Posso costruire senza Carpentry?**
R: Puoi piazzare e rompere i blocchi semplici (terra, pietra grezza, tronchi). I blocchi lavorati (assi, mattoni, porte, finestre, mobili) vanno creati da un artigiano. Vedi [Sistema costruzioni](/wiki/sistema-costruzioni).

**D: Il piccone serve anche per scavare la terra?**
R: Sì, ma la pala è tre volte più veloce. Il piccone è indispensabile solo per pietra e minerale.

**D: Gli attrezzi si possono rubare?**
R: Sì, come qualsiasi oggetto nello zaino. Vedi [Furto](/wiki/furto).

---

*Vedi anche: [Armi](/wiki/armi) | [Minerali](/wiki/minerali) | [Legni](/wiki/legni) | [Skill di crafting](/wiki/skill-crafting) | [Sistema costruzioni](/wiki/sistema-costruzioni)*

> ⚖️ Usi, velocità di scavo e bonus dei materiali degli attrezzi sono **da bilanciare**. Gli oggetti segnati *(nuovo)* non esistevano in Ultima Online e sono proposte per il mondo a voxel.
