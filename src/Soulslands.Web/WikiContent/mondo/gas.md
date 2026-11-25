---
title: Gas
slug: gas
category: Mondo
visibility: Pubblica
---
# 💨 Gas

*Fumo che sale, veleno che ristagna e sacche che aspettano solo una torcia*

---

## 📋 Indice

- [Panoramica](#panoramica)
- [I quattro gas](#i-quattro-gas)
- [Come si comporta un gas](#come-si-comporta-un-gas)
- [Cosa fa un gas al corpo](#cosa-fa-un-gas-al-corpo)
- [Il gas di miniera ed esplosioni](#il-gas-di-miniera-ed-esplosioni)
- [Consigli](#consigli)

---

## 📜 Panoramica

**Deciso da Aruto (17/11/2026):** i gas arrivano subito, con quattro tipi: fumo, vapore, gas velenoso e gas di miniera esplosivo. Un gas si sposta **di un blocco alla volta in su o in giù, mai di lato**.

Un gas è un blocco come gli altri, ma lo attraversi come l'aria: ci cammini dentro, ci vedi attraverso e miri attraverso di lui. Non si scava e non si raccoglie, e non c'è nel catalogo creativo. Un blocco piazzato in una cella di gas lo sostituisce, e il gas sparisce; sabbia e ghiaia che cadono in un gas si scambiano con lui, e il gas resta sopra.

> ⚠️ **I numeri arrivano dopo la prova.** Questa pagina non dà ancora il danno dei gas, la forza e il raggio delle esplosioni né quanto dura il fumo: Aruto li proverà nella prima versione giocabile della sopravvivenza e solo dopo la sua prova finiranno qui.

---

## 🧪 I quattro gas

| Gas | Dove nasce | Si sposta | Svanisce | Ferisce | Esplode |
|-----|------------|-----------|----------|---------|---------|
| **Fumo** (`smoke`) | Sopra fuochi da campo, bracieri e camini accesi | Sale | Sì, dopo un po' | No | No |
| **Vapore** (`steam`) | Dove la lava tocca l'acqua dolce o di mare | Sale | Sì, dopo un po' | Sì | No |
| **Gas velenoso** (`poison_gas`) | Nelle conche di [paludi](/wiki/bioma-palude) e [mangrovie](/wiki/bioma-mangrovie), sopra il terreno basso e l'acqua | Scende | No | Sì | No |
| **Gas di miniera** (`mine_gas`) | Sotto i soffitti delle grotte, tra Y -32 e Y -1 (vedi [Grotte e sottosuolo](/wiki/grotte-e-sottosuolo)) | Sale | No | No | Sì, con una fiamma |

Tutti e quattro **tolgono l'aria**: con la testa dentro un gas il respiro scende come sott'acqua (vedi [Fame, sete e aria](/wiki/fame-sete-e-aria#laria)).

---

## 🌫️ Come si comporta un gas

- **In su o in giù, mai di lato.** Il fumo, il vapore e il gas di miniera salgono, il gas velenoso scende, una cella alla volta e solo dentro l'aria libera: un gas non entra mai nell'acqua, in un altro gas, in una pianta o in un blocco. Contro un soffitto il gas che sale si ferma e si accumula; in una buca il gas velenoso resta sul fondo.
- **Un gas fermo resta fermo.** Le sacche di gas velenoso e di gas di miniera non svaniscono e non si muovono finché qualcosa non cambia accanto a loro (un blocco scavato, una fiamma).
- **Fumo e vapore svaniscono** da soli, di tanto in tanto, e un fuoco acceso ne produce di nuovo se la cella sopra è libera. Succede solo vicino ai giocatori: lontano da tutti, i fuochi non fanno fumo e il fumo resta dov'è.
- **Il generatore del mondo** mette il gas velenoso e il gas di miniera quando crea il terreno, mai dentro una casa, un dungeon o un'altra struttura. Le sacche di gas di miniera stanno lontane dalla lava.
- **Si vede.** Un gas si disegna come un volume semitrasparente con il suo colore; quando la testa ci entra, la vista si tinge di quel colore.

---

## 😵 Cosa fa un gas al corpo

- **Conta solo la testa.** Il gas agisce sulla cella degli occhi: con i piedi nel gas e la testa fuori non succede niente. Uno strato di gas alto un solo blocco non raggiunge chi sta in piedi; le conche di gas velenoso sono più profonde.
- **Toglie l'aria.** Finita l'aria si soffoca e si perde vita come annegando.
- **Vapore e gas velenoso feriscono anche subito**, ogni secondo, oltre a togliere l'aria. Passare da un gas che ferisce all'altro non fa male prima del tempo.
- Il danno è uguale in ogni difficoltà. Fantasmi, spettatori e personaggi in creativa non ne risentono.
- Chi muore così legge "You breathed a deadly gas." (o "You suffocated." se è finita l'aria).

---

## 💥 Il gas di miniera ed esplosioni

### Cosa lo accende

Il gas di miniera **si accende** quando ha accanto (sopra, sotto o su uno dei quattro lati) una **fiamma libera**:

- la **lava**;
- torcia, torcia a muro, candela, candelabro e lampadario **accesi**;
- fuoco da campo, braciere e camino **accesi**.

Basta portare la fiamma al gas o lasciare che il gas salga fino a una torcia. Un istante dopo che fiamma e gas si toccano, il gas sparisce e l'esplosione segue subito. Il gas di miniera che l'esplosione raggiunge si accende a sua volta: una sacca intera esplode **a catena**.

Il gioco ritrova il pericolo anche dopo una pausa: una torcia lasciata accanto al gas di miniera fa esplodere la sacca anche dopo un riavvio del server, appena quella zona viene caricata. E una sacca che il generatore ha messo accanto alla lava al confine tra due pezzi di mondo esplode da sola la prima volta che quei pezzi vengono caricati insieme.

### Cosa rompe

- **Distanza e resistenza.** Un'esplosione rompe i blocchi intorno a sé secondo la distanza dal centro e la resistenza del blocco. I blocchi teneri (torce, terra, sabbia, ghiaia, vetro) si rompono in tutta l'esplosione; la pietra solo più vicino al centro; le vene di minerale ancora più vicino. L'ardesia profonda (`deepslate`) resiste molto, e l'**ossidiana** non si rompe mai: è la pietra con cui murare un deposito.
- **Un muro non ripara.** Conta solo la distanza: un muro tra il centro e un blocco o un personaggio non lo protegge.
- **I blocchi rotti non lasciano niente**: un'esplosione non è un modo di scavare.
- **Non si rompono** i blocchi indistruttibili, come la [Roccia del Mondo](/wiki/blocchi#speciali-e-limiti-del-mondo), né i liquidi.
- **Gli altri gas** raggiunti dall'esplosione spariscono.

### Le casse e gli oggetti

- **Un'esplosione non distrugge mai gli oggetti custoditi.** Una cassa, un barile o un forziere rotto da un'esplosione sparge il suo contenuto a terra nella sua cella, come quando lo rompi scavando.
- Una cassa piena si rompe solo se il suo contenuto trova posto a terra in quel pezzo di mondo senza far sparire altri oggetti; altrimenti **resta in piedi**, intera e con tutto dentro. Anche in un'esplosione molto grande solo poche casse piene si rompono nello stesso istante: le altre restano in piedi. Una cassa vuota si rompe come un blocco qualsiasi.
- Gli oggetti sparsi o rimasti senza appoggio non passano in un pezzo di mondo vicino che non ha più posto. **Un limite noto**: se esci di vista e torni, o chiudi e riapri il mondo, gli oggetti che un'esplosione aveva lasciato sospesi sopra un pezzo di mondo pieno cadono, e lì possono far sparire gli oggetti a terra più vecchi.
- Un'esplosione non sposta, non rompe e non ferisce gli oggetti a terra né i corpi dei morti.

### Il danno ai personaggi

- Un'esplosione ferisce chi è vicino, **meno quanto più è lontano** dal centro; oltre il suo raggio non fa niente.
- Se più esplosioni ti raggiungono a breve distanza di tempo, conta **la più forte, non la somma**: una sacca che esplode a catena accanto a te non ti colpisce una volta per ogni cella di gas.
- Il danno è uguale in ogni difficoltà. Fantasmi, spettatori e personaggi in creativa non ne risentono, e nemmeno il corpo di chi si è disconnesso.
- Chi muore così legge "You were blown up.". Per ora la morte conta come un incidente: il server annota chi ha acceso la sacca, ma l'esplosione non dà colpe per la [notorietà](/wiki/player-killer-e-redenzione).

Fonte tecnica: [ADR-0048](https://github.com/Soulslands/soulslands-game/blob/main/docs/adr/0048-gases-explosions.md).

---

## 💡 Consigli

- **Scendendo sotto Y 0**, guarda i soffitti delle grotte prima di piazzare una torcia: un velo di gas sotto la roccia è una sacca di gas di miniera.
- **Nelle paludi** non fermarti nelle conche: il gas velenoso ristagna dove il terreno è basso. Basta salire su un rialzo con la testa fuori.
- **Il fumo dei camini** sale e svanisce, ma in una stanza chiusa si accumula sotto il soffitto: lascia un'apertura sopra il fuoco.
- **Lava e acqua** fanno vapore: non scavare un passaggio dove si toccano senza un modo per uscire in fretta.

---

## 🔗 Vedi anche

- [Fame, sete e aria](/wiki/fame-sete-e-aria) — l'aria e il respiro
- [Grotte e sottosuolo](/wiki/grotte-e-sottosuolo) — dove si trova il gas di miniera
- [Palude](/wiki/bioma-palude) e [Mangrovie](/wiki/bioma-mangrovie) — il gas velenoso nelle conche
- [Morte e fantasmi](/wiki/morte-e-fantasmi) — cosa succede quando muori
- [Blocchi](/wiki/blocchi) — i blocchi del mondo e la loro durezza
