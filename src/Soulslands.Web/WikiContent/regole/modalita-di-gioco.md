---
title: Modalità di gioco
slug: modalita-di-gioco
category: Regole di gioco
visibility: Pubblica
---
# 🎮 Modalità di gioco
*Creativa per costruire ed esplorare, sopravvivenza per giocare sul serio*

---

## 📜 Panoramica

Ogni mondo di Soulslands nasce **creativo** o **sopravvivenza** e resta così per sempre. Ogni personaggio, dentro il mondo, ha la sua modalità: creativa o sopravvivenza.

> ⚠️ **Stato del lavoro.** Questa pagina descrive le regole decise per le prime versioni giocabili del gioco da solo. Il sopravvivenza completo (oggetti che cadono, salute, fame, danni) arriva più avanti: per ora un personaggio in sopravvivenza può esplorare, scavare e portare oggetti nello zaino, ma non ha ancora un modo di ottenerli (niente oggetti che cadono né raccolta).

**Deciso da Aruto (25/10/2026):** il volo è permesso in creativa; la tavolozza creativa contiene ogni blocco, illimitato e gratis; rompere è istantaneo in creativa; in creativa niente danni e niente fame; F5 cambia visuale come in Minecraft; il mondo si salva da solo e con un pulsante, e si salva anche quando esci. Fonte tecnica: [ADR-0025](https://github.com/Soulslands/soulslands-game/blob/main/docs/adr/0025-creative-exploration-rules.md).

---

## 🌍 Modalità del mondo e del personaggio

| Cosa | Regola |
|------|--------|
| **Modalità del mondo** | Si sceglie quando il mondo viene creato e **non cambia mai** |
| **Modalità del personaggio** | Parte uguale a quella del mondo e viene salvata con il personaggio |
| **Mondo creativo** | I giocatori autorizzati possono passare da creativa a sopravvivenza e ritorno, come in Minecraft |
| **Mondo sopravvivenza** | Nessuno può passare alla creativa, mai |
| **Mondi creati prima di questa regola** | Si aprono come creativi |

Per ora la schermata di creazione del mondo **non offre la sopravvivenza**: la mostra spenta, con la scritta "I mondi sopravvivenza arriveranno con un aggiornamento successivo". Un mondo sopravvivenza non potrebbe mai passare alla creativa e, prima delle regole complete di sopravvivenza, sarebbe quasi vuoto. Si può comunque provare la sopravvivenza passandoci da un mondo creativo.

### Chi può cambiare modalità

| Dove giochi | Chi cambia modalità e salva con il pulsante |
|-------------|---------------------------------------------|
| **Da solo** (mondo locale) | Tu, sempre |
| **Server dedicato** | **Solo gli admin** del server, indicati dall'host nelle impostazioni (`[admin] accounts`). Non esiste un'impostazione per lasciar cambiare a tutti |

Chi non ha il permesso non vede il comando nel menu. Se prova lo stesso (client modificato), il server rifiuta con un avviso. Passando da creativa a sopravvivenza il volo finisce e il personaggio cade; nel verso opposto il volo diventa possibile.

---

## 🧱 Cosa cambia tra le due modalità

| | Creativa | Sopravvivenza (prime versioni) |
|---|---|---|
| **Volo** | Sì | No |
| **Rompere un blocco** | Istantaneo | Secondo la durezza del blocco; a mani nude si impiega il triplo dove serve un attrezzo |
| **Oggetti che cadono** | Nessuno | Nessuno: il blocco scavato sparisce (gli oggetti arrivano più avanti) |
| **Piazzare un blocco** | Qualsiasi blocco della tavolozza, gratis e illimitato | Rifiutato: in sopravvivenza il piazzamento dallo zaino arriva più avanti |
| **Tasto `E`** | Apre la tavolozza e, accanto, lo zaino | Apre lo zaino |
| **Zaino** | Sì, si riempie dalla tavolozza | Sì, ma per ora si può solo riordinare e spostare oggetti da e verso i contenitori |
| **Casse** | Si aprono col tasto destro; vi si prende dalla tavolozza | Si aprono col tasto destro; si riordina e si sposta da e verso lo zaino |
| **Danni e fame** | Mai | Non ancora presenti |
| **Cadute** | Succedono, senza danni | Succedono; i danni arrivano con le regole complete |

Raggio d'azione (5 blocchi) e linea di vista valgono in entrambe. Il blocco `world_rock`, il fondo del mondo, resta indistruttibile anche in creativa *(proposta, da confermare)*.

---

## 🎒 Zaino e contenitori

**Deciso da Aruto (08/11/2026):** lo zaino arriva ora. Contiene **125 oggetti** e **non ha un limite di peso**. Gli oggetti restano nello zaino quando cambia la modalità di gioco, come in Minecraft.

- **Aprire lo zaino.** Il tasto `E` (inventario) lo apre in sopravvivenza; in creativa apre la tavolozza **e** lo zaino affiancati. Premuto di nuovo chiude (in creativa chiude entrambi), come `Esc`. Passando alla sopravvivenza la tavolozza si chiude e lo zaino resta aperto.
- **Senza griglia.** Come in Ultima Online, lo zaino non ha caselle: ogni oggetto sta dove lo posi, anche sopra altri. Il gioco tiene sempre **l'intera icona dentro l'area** del contenitore (vale per ogni contenitore), così nessun oggetto sporge dal bordo dell'apertura disegnata.
- **In creativa** trascini un blocco dalla tavolozza nello zaino nel punto che vuoi (con Maiusc prendi una pila intera; lasciato su una pila uguale si somma) o nella barra rapida; trascini un oggetto dallo zaino alla tavolozza per eliminarlo.
- **In sopravvivenza** apri lo zaino, lo riordini e **sposti gli oggetti tra uno zaino e un contenitore aperto, nei due versi**. Prendere oggetti dalla tavolozza resta solo della creativa.
- **Barili e casse.** Insieme ai forzieri, anche **barili** e **casse** sono contenitori che si piazzano nel mondo: si aprono col tasto destro come il forziere (stessa portata di 5 blocchi), tengono fino a **125 oggetti** e **400 pietre** di peso (dal pacchetto dati del gioco), e il contenuto si salva con il blocco. Chi li apre vede una finestra con la sua apertura disegnata, rotonda per il barile e rettangolare per la cassa.
- **Aprire una cassa.** Il **tasto destro** su un blocco contenitore lo apre prima di usare o posare qualsiasi cosa, con la visuale in prima persona e con le altre. Per **piazzare** un blocco accanto a una cassa invece di aprirla, tieni premuto **Maiusc** mentre fai clic destro. Gli oggetti stanno dove li lasci dentro la cassa, come nello zaino. Ne puoi tenere aperti al massimo **16** e la cassa si chiude da sola se ti allontani oltre 5 blocchi (valori nostri, non misurati).
- **Nella cassa, in creativa.** Gli oggetti arrivano dalla tavolozza: trascini un blocco dalla tavolozza dentro la cassa e lo prendi; trascini un oggetto dalla cassa sulla tavolozza e viene buttato via.
- **Nella cassa, in sopravvivenza.** Puoi guardare, riordinare e spostare gli oggetti tra la cassa e lo zaino, nei due versi. Non puoi prenderne dalla tavolozza né buttarli via.
- **Rompere una cassa piena.** Una cassa che contiene ancora oggetti **non si rompe**, in nessuna delle due modalità: il gioco rifiuta con un avviso, finché non esisteranno gli oggetti a terra (**deciso da Aruto, 03/11/2026**).
- **Grandezza delle finestre.** Le finestre dei contenitori sono più grandi di prima: lo zaino occupa il **23 %** della larghezza dello schermo 16:9. Gli oggetti dentro restano della dimensione che avevano, quindi in una finestra più grande ne entrano a vista più di prima. La finestra si ingrandisce ancora con la scala dell'interfaccia (Opzioni, Video). Le finestre si aprono da sole nel **posto libero**: la tavolozza a sinistra, lo zaino a destra, gli altri contenitori in fila verso sinistra a partire dallo zaino. Se in fila non c'è spazio (finestra piccola o scala dell'interfaccia alta) la finestra prova una cascata libera in alto a sinistra e solo senza altro posto si apre sopra qualcosa. Le finestre non si sovrappongono da sole all'HUD (globo, barre, barra rapida) né alla tavolozza, e le trascini dove vuoi, anche sopra altre cose; la finestra spostata si riapre lì, per tipo di contenitore e finché giochi. Cambiando la dimensione della finestra o la scala dell'interfaccia (Opzioni, Video) il posto si ricalcola, ma una finestra che hai spostato resta dov'è (rientra solo nello schermo). Fonte: [ADR-0041](https://github.com/Soulslands/soulslands-game/blob/main/docs/adr/0041-screen-layout.md), scelte dell'architetto che Aruto rivede.
- **Cosa arriva dopo.** Il piazzamento dallo zaino, gli oggetti che cadono e la raccolta, la banca e le borse annidate.

### Pile: dividere e unire

**Deciso da Aruto (08/11/2026):** le pile funzionano come in Ultima Online.

| Gesto | Cosa succede |
|-------|--------------|
| **Trascini una pila di 2 o più** | Si apre una piccola **finestra della quantità**, con un cursore e un numero, già impostata sull'intera pila. Conferma con `Invio` o con OK; `Esc` o il tasto destro annulla solo quella finestra. Dopo la conferma la quantità scelta resta attaccata al puntatore finché non fai clic dove vuoi lasciarla |
| **Maiusc + trascina** | Prendi **tutta la pila**, senza finestra |
| **Ctrl + trascina** | Prendi **metà pila**, arrotondata per eccesso (da 5 ne prendi 3) |
| **Maiusc e Ctrl insieme** | Tutta la pila |
| **Un oggetto solo** | Si sposta intero, senza chiedere |

I tasti contano nel momento in cui inizi a trascinare. Mentre la finestra è aperta la pila non si muove.

- **Unire.** Lasciando un oggetto sopra uno **uguale** (stesso tipo) i due diventano una pila sola, fino al **massimo della pila**. Quello che non ci sta resta dov'era, al suo posto. Se la pila di arrivo è già piena, o l'oggetto è diverso, il gioco rifiuta con un avviso. Vale nei contenitori e nello zaino; sulla barra rapida, che per ora tiene riferimenti a blocchi e non oggetti, vale la regola di prima.
- **In creativa**, un blocco preso dalla tavolozza e lasciato su una pila uguale **si somma** alla pila, fino al massimo.
- **Icona doppia.** Una pila di 2 o più si disegna con la sua icona **due volte**, la seconda poco spostata accanto alla prima, come in Ultima Online; la quantità resta scritta sull'angolo. Tavolozza e barra rapida mostrano una sola icona.
- **Il server decide.** Come per ogni spostamento, la vista cambia solo quando il server risponde: se rifiuta, la pila resta com'era. Ogni divisione e unione è registrata nel libro mastro degli oggetti, così nessun oggetto si perde né si duplica.

Fonte tecnica: ADR-0039, emendamento dell'08/11/2026; per le pile [ADR-0040](https://github.com/Soulslands/soulslands-game/blob/main/docs/adr/0040-stacks-split-merge.md). Per i contenitori come blocchi vedi [Blocchi da costruzione](/wiki/blocchi-costruzione).

---

## 🗂️ L'inventario creativo

*Il catalogo di ogni blocco e oggetto, solo per chi gioca in creativa. Nelle altre parti di questa pagina lo trovi anche con il vecchio nome "tavolozza".*

**Deciso da Aruto (03/11/2026):** il catalogo è diviso in schede e sottogruppi che seguono le sezioni delle pagine [Blocchi](/wiki/blocchi) e [Blocchi da costruzione](/wiki/blocchi-costruzione); l'icona di ogni scheda è quella di un oggetto rappresentativo; i blocchi con varianti di legno o di colore restano **una sola casella** con il selettore della variante; il catalogo esiste **solo in creativa**. Fonte tecnica: [ADR-0038](https://github.com/Soulslands/soulslands-game/blob/main/docs/adr/0038-creative-inventory.md).

- **Chi lo vede.** Solo un personaggio in creativa. In sopravvivenza il tasto `E` apre lo zaino e basta; se passi a sopravvivenza col catalogo aperto, il catalogo si chiude e lo zaino resta.
- **Come si apre.** Con `E` in creativa si apre il catalogo **accanto allo zaino**. Si chiude con `E` (fuori dal campo di ricerca) o con `Esc`. Finché è aperto prende la tastiera: scrivere non muove il personaggio.
- **Dove sta.** Contro il bordo sinistro dello schermo, **compatto**: 9 colonne per al massimo 7 righe (almeno 3), le altre voci si raggiungono con la rotella o la barra di scorrimento. Sta sopra le parti fisse dell'interfaccia (globo, barre, barra rapida) senza coprirle; solo in finestre molto strette le colonne scendono fino a 5. Fonte: [ADR-0041](https://github.com/Soulslands/soulslands-game/blob/main/docs/adr/0041-screen-layout.md), scelta dell'architetto che Aruto rivede (decisione di Aruto dell'08/11/2026: più compatto, niente sovrapposizioni di serie).
- **Schede e gruppi.** In alto una fila di schede: prima **Cerca**, poi le schede dell'albero nell'ordine qui sotto, in fondo **Altro** (le voci che nessun gruppo nomina, così nulla resta fuori). Una scheda senza voci non si vede. Se le schede sono più dello spazio, la fila scorre con la rotella e due frecce. Il nome della scheda compare al passaggio del mouse; dentro ogni scheda i gruppi hanno un'intestazione di testo.

| Scheda | Gruppi (nomi inglesi del gioco, nell'ordine) |
|--------|-----------------------------------------------|
| **Natural blocks** (`natural`) | Soils and clays; Snow and ice; Sands and gravels; Layer rocks; Other rocks; Raw ores; Trees and wood; Plants; Herbs, mosses and roots; Wild flowers; Fruits and special plants; Corals and water plants |
| **Building blocks** (`building`) | Worked stone; Stairs, slabs and walls; Bricks, clay and ice; Worked wood; Roofs; Glass; Doors, windows and passages; Roads and fields |
| **Furnishing** (`furnishing`) | Lights; Beds; Seats; Tables and counters; Training and display; Workstations; Containers |
| **Materials** (`materials`) | Ores and ingots; Gems; Wood materials; Stones and shards; Fibres; Fuel; Plant produce; Animal products |
| **Magic** (`magic`) | Reagents |

L'albero è nel file `creative/tree.toml` del pacchetto base del gioco e questa tabella lo copia. Le schede Strumenti, Combattimento, Vestiti e Cibo non ci sono ancora: le aggiungerà il primo contenuto che porta i loro oggetti. Un mod può aggiungere schede, gruppi e voci con un suo file dello stesso tipo.

- **Cerca.** Il campo in alto cerca mentre scrivi (scrivere dove capita apre il campo da solo). Trova una voce se il testo è contenuto nel suo nome nella tua lingua, nel suo id (`soulslands:oak_planks`) o nel nome di una sua variante; maiuscole e accenti non contano. I risultati sono senza intestazioni, nell'ordine del catalogo.
- **Blocchi.** Trascini una casella su una casella della barra rapida, oppure premi un numero `1`-`9` con il mouse sopra la casella: quel posto prende il blocco (la variante scelta, se c'è il selettore sotto la griglia). Poi il tasto destro lo piazza. Il tasto centrale continua a copiare il blocco che stai mirando.
- **Oggetti.** Le voci che sono oggetti senza un blocco (gemme, minerali grezzi, semi, reagenti...) non vanno sulla barra rapida, che per ora tiene solo blocchi: la loro descrizione lo dice. Puoi però trascinare **qualsiasi voce, blocchi e oggetti**, nello zaino o in una cassa aperti, nel punto in cui la lasci (con Maiusc una pila intera, come nelle regole sopra). Un oggetto trascinato dallo zaino o da una cassa sul catalogo viene eliminato.
- **Blocchi gratis.** Tutto è illimitato e gratuito, come per il resto della creativa.

---

## 💬 Parole sopra la testa

**Deciso da Aruto (03/11/2026):** quello che si dice sui canali Locale, Sussurro e Urlo si vede anche **sopra la testa di chi parla**, oltre che nel registro della chat.

- **Stile.** Il sussurro è in corsivo, grigio e più piccolo; la voce normale è com'è; l'urlo è in grassetto e più grande (le proporzioni sono proposte nostre, da tarare).
- **La tua testa.** In isometrica e in terza persona la tua riga compare sopra il tuo personaggio; in prima persona la leggi solo nel registro.
- **La testa degli altri.** La riga compare solo se il gioco riconosce chi ha parlato; se la riga arriva prima del personaggio aspetta al massimo 1 secondo, poi resta solo nel registro. Si vedono al massimo poche teste alla volta, le più vicine.
- **Testo formattato.** In ogni canale puoi scrivere `*corsivo*`, `**grassetto**`, `~~barrato~~` e `` `codice` ``, nient'altro (niente link, titoli o colori). I segni contano nei 256 caratteri della riga e quelli non chiusi si vedono come li hai scritti.

Fonte tecnica: [ADR-0039](https://github.com/Soulslands/soulslands-game/blob/main/docs/adr/0039-chests-and-speech.md), sezioni 6 e 7. Le distanze a cui si sente chi parla sono nelle regole del gioco, non in questa pagina.

---

## 🕊️ Volo

- Il volo esiste **solo in creativa**.
- Si attiva toccando due volte il salto in fretta (circa un terzo di secondo); in volo il salto sale, acquattarsi scende e la corsa vola più veloce *(proposta, come in Minecraft)*.
- **Atterrare finisce il volo**: appena il personaggio tocca terra smette di volare. Per ripartire serve rilasciare e ritoccare due volte il salto: tenere premuto non basta.
- Il server calcola il volo dai tuoi tasti, come la camminata: nessuna velocità la sceglie il client.

Velocità di partenza, prese da Minecraft Java e *da confermare* (le misurerà chi le implementa): camminata 4,3 blocchi al secondo, corsa 5,6, volo 10,9, volo in corsa 21,8, salita e discesa in volo 7,5.

---

## ⛏️ Rompere e piazzare in creativa

- **Rompere è istantaneo.** Tenendo premuto il tasto, il blocco successivo che stai mirando si rompe ogni quarto di secondo circa *(proposta, come Minecraft)*.
- Rompere in creativa non lascia oggetti.
- **Il catalogo** (tasto `E`, vedi la sezione "L'inventario creativo"; nel resto della pagina "tavolozza") mostra ogni blocco che si può piazzare: niente aria, niente liquidi (arriveranno con le regole del loro scorrere), niente blocchi indistruttibili. Una barra rapida da 9 posti, scelta con i tasti 1-9 e la rotella, decide cosa piazza il tasto destro; il tasto centrale copia il blocco mirato *(proposta)*.
- Nelle prime versioni esistono solo blocchi **cubici**; le forme (scale, lastre) seguono subito dopo.

---

## 💾 Salvataggio

Il mondo si salva in tre modi (dettagli in [Persistenza del mondo](/wiki/persistenza-del-mondo)):

1. **Da solo, ogni pochi secondi**: al massimo circa 10 secondi di gioco si perdono se il computer si spegne di colpo.
2. **Con il pulsante Salva** del menu di pausa (`Esc`): sotto il pulsante compare "Ultimo salvataggio alle 14:32:05", oppure "Non ancora salvato" se non è successo niente, e "Salvataggio..." mentre aspetti.
3. **Quando esci**: "Salva ed esci al titolo" e la chiusura della finestra salvano prima di chiudere, con una schermata "Salvataggio del mondo". Su un server remoto escono semplicemente dal server.

Il personaggio salva posizione, sguardo, modalità e se sta volando; al rientro ritrovi tutto com'era. Il menu di pausa **non ferma** il mondo *(proposta: per ora nulla può farti male)*.

---

## 🎥 Visuali (tasto F5)

F5 fa girare tre visuali, una dopo l'altra, come in Minecraft:

**prima persona → terza persona da dietro → isometrica → prima persona**

| Visuale | Come funziona |
|---------|---------------|
| **Prima persona** | Mirino al centro dello schermo; si parte da questa quando si entra nel mondo |
| **Terza persona** | La camera sta 4 blocchi dietro agli occhi e si avvicina se c'è un muro, per non entrarci; si mira come in prima persona |
| **Isometrica** | Ruotabile, con i tasti relativi alla telecamera; non è la visuale di partenza |

La quarta visuale di Minecraft (di fronte) non c'è. Finché non esistono i personaggi veri, in terza persona e in isometrica il corpo è una scatola segnaposto della misura del personaggio. Il gioco non dipende mai dalla visuale scelta.

---

## ❓ FAQ

**D: Posso portare un personaggio creativo in un mondo sopravvivenza?**
R: No. I personaggi vivono nel loro mondo ([Persistenza del mondo](/wiki/persistenza-del-mondo)).

**D: Nel mio mondo creativo passo a sopravvivenza e poi torno creativo?**
R: Sì, da solo sempre; su un server solo se sei admin.

---

## 🔗 Vedi anche

- [Persistenza del mondo](/wiki/persistenza-del-mondo) — cosa viene salvato e quando
- [Morte e fantasmi](/wiki/morte-e-fantasmi) — cosa succede quando muori (in sopravvivenza)
- [Regolamento](/wiki/regolamento) — le regole del server
- [Blocchi da costruzione](/wiki/blocchi-costruzione) — forzieri, casse e barili come contenitori
- [Il Mondo](/wiki/mondo) — come è fatto il mondo
