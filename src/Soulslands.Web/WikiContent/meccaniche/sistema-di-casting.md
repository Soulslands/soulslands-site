---
title: Sistema di casting
slug: sistema-di-casting
category: Meccaniche
visibility: Pubblica
---
# 🔮 Sistema di casting

*Seleziona, concentra, scatena*

---

## 📜 Panoramica

Il sistema di lancio degli incantesimi di Soulslands, ereditato da Cursed Souls, è diverso da quello dell'Ultima Online tradizionale. Invece di aspettare il tempo di lancio e poi scegliere il bersaglio, qui **scegli prima il bersaglio** e poi il personaggio si concentra per lanciare. Il combattimento magico diventa più dinamico e tattico, e si adatta bene a un mondo a voxel in cui ci si muove, si salta e ci si ripara dietro i blocchi.

Vale per [Magery](/wiki/skill-magery), [Necromancy](/wiki/skill-necromancy) e le altre scuole di magia.

Gli incantesimi sono di due tipi, e la pagina di ogni incantesimo dice quale:
- **A bersaglio**: seguono le quattro fasi qui sotto. Il colpo parte contro il bersaglio scelto, con un proiettile che lo insegue oppure con un effetto che lo raggiunge subito.
- **Liberi**: si mirano come un arco in Minecraft (vedi [Archery](/wiki/skill-archery)). Dopo la concentrazione il proiettile parte verso il punto in cui guardi e colpisce la prima cosa che incontra, oppure si perde nel vuoto. Senza bersaglio non c'è la verifica della fase 4.

---

## 🎯 Come funziona

Il lancio segue 4 fasi. Come tutto il combattimento è deterministico ([Regole deterministiche](/wiki/regole-deterministiche)): con il mana, i reagenti e un bersaglio valido l'incantesimo **riesce sempre**, a qualsiasi livello di Magery e per qualsiasi cerchio. Non esiste un tiro di fallimento e nessun cerchio richiede una skill minima.

### Fase 1 — Attivazione
Quando scegli un incantesimo dal libro (o dalla barra rapida), il gioco controlla che:
- tu sia vivo e in grado di lanciare;
- tu abbia abbastanza **mana** (il costo scende con la skill: pieno a Magery 0.0, 70% a 100.0);
- tu non sia paralizzato o congelato;
- la zona in cui ti trovi permetta la magia.

### Fase 2 — Scelta del bersaglio
Il bersaglio è ciò che **guardi** quando attivi l'incantesimo: in prima persona l'entità al centro del mirino, in visuale isometrica quella sotto il cursore. Può essere un mostro, un animale, un giocatore o qualsiasi altra entità, e resta lo stesso fino alla fine del lancio. Se non guardi niente di valido, l'incantesimo non parte e **non costa nulla**.

Puoi bersagliare solo ciò che **vedi**: ciò che è fuori dal campo visivo del personaggio (le zone in grigio) o dietro blocchi solidi non è selezionabile. Gli incantesimi ad area si mirano su un blocco del terreno.

### Fase 3 — Concentrazione
Dopo la scelta del bersaglio il personaggio si concentra:
- pronuncia il **mantra** dell'incantesimo;
- le mani mostrano l'**animazione** di lancio;
- la durata dipende dal **cerchio** e dal tuo **Faster Casting**.

**Puoi muoverti liberamente** durante questa fase: non sei bloccato come nel lancio tradizionale.

| Cerchio | Tempo base | Con FC +2 |
|---------|-----------|-----------|
| 1° | 1,00 s | 0,50 s |
| 2° | 1,25 s | 0,75 s |
| 3° | 1,50 s | 1,00 s |
| 4° | 1,75 s | 1,25 s |
| 5° | 2,00 s | 1,50 s |
| 6° | 2,25 s | 1,75 s |
| 7° | 2,50 s | 2,00 s |
| 8° | 2,75 s | 2,25 s |

**Faster Casting (FC)**: ogni punto riduce il tempo di 0,25 secondi. Il limite da equipaggiamento per Magery e Necromancy è **FC +2**; la passiva razziale dell'[Elfo Oscuro](/wiki/razza-elfo-oscuro) aggiunge altri +2 (limite totale 4).

### Fase 4 — Esecuzione
Al termine della concentrazione il gioco verifica che il bersaglio sia ancora valido:
- è ancora vivo?
- è ancora nel raggio dell'incantesimo?
- lo vedi ancora (**linea di vista**)? Nel mondo a voxel basta che il bersaglio giri dietro un muro o che qualcuno piazzi un blocco in mezzo per spezzare la linea di vista.

Se **tutto è valido**: l'incantesimo colpisce, mana e reagenti vengono consumati.

Se il **bersaglio non è più valido**: l'incantesimo fallisce. Perdi **metà del mana** e i **reagenti**.

**Nessun tempo di ricarica**: subito dopo puoi lanciarne un altro.

---

## 💥 Quanto fa male una magia

Il danno di un incantesimo è un valore unico per incantesimo (nessun intervallo), più INT/10 di chi lancia; dal totale si sottraggono i punti di armatura del bersaglio per quel tipo di danno (vedi [Sistema armature](/wiki/sistema-armature)), con minimo 1 PV. Nessuna skill aggiunge o toglie danno magico: [Magery](/wiki/skill-magery) abbassa solo il mana speso e [Resisting Spells](/wiki/skill-resisting-spells) accorcia gli effetti dannosi che subisci. Lo stesso vale per le cure: valore dell'incantesimo + INT/10.

---

## ⚡ Interruzione

Durante la concentrazione alcuni eventi fanno fallire l'incantesimo.

### Danno fisico
Se subisci un **colpo fisico** (spada, freccia, mazza, arma da lancio...) l'incantesimo **fallisce sempre**. Nemmeno l'incantesimo *Protection* aiuta.
- **Mana perso**: tutto.

### Danno non fisico
Se subisci **danno magico** (fuoco, freddo, veleno, energia) l'incantesimo **fallisce**, a meno che tu abbia attivo *Protection*: con *Protection* il danno non fisico non ti interrompe mai.
- **Mana perso**: tutto.

### Annullamento volontario
Puoi annullare il lancio:
1. passando dalla modalità guerra a quella pace (o viceversa) con il tasto dedicato;
2. lanciando un altro incantesimo prima che finisca la concentrazione.

È meno costoso di un'interruzione:
- **Mana perso**: metà.
- **Reagenti**: non consumati.

### Tabella riassuntiva

| Causa | Mana perso | Reagenti persi | Protection aiuta? |
|-------|-----------|----------------|-------------------|
| Danno fisico | Tutto | No | No: fallimento garantito |
| Danno non fisico | Tutto | No | Sì: con Protection attivo non interrompe |
| Cambio modalità / nuovo incantesimo | Metà | No | — |
| Bersaglio non valido | Metà | Sì | — |

> Ogni fallimento produce un **effetto visivo** sopra la testa di chi lancia e un **suono** caratteristico: tu e i tuoi avversari saprete che l'incantesimo è andato a vuoto.

---

## 🛡️ Il ruolo di Protection

*Protection* (secondo cerchio di Magery) ha un ruolo preciso:
- **Non protegge** dai danni fisici: un colpo di spada interrompe sempre.
- **Protegge** dai danni magici: fa sì che nessun incantesimo nemico interrompa il tuo (il danno magico non ti interrompe più).
- **Penalità**: riduce il tuo Faster Casting di 2.

Contro altri maghi ti rende più sicuro ma più lento; contro i guerrieri non serve.

---

## ⚔️ Strategie

### Per i maghi
- **Tieni le distanze** dai guerrieri: i loro colpi ti interrompono sempre.
- Usa *Protection* contro altri maghi.
- **Muoviti** mentre lanci: non restare fermo.
- **Usa il terreno**: lancia da dietro una copertura, sali su un rialzo, metti un blocco tra te e un guerriero che ti carica.
- Sotto pressione, **annulla** il lancio per perdere solo metà del mana invece di tutto.
- Niente tempo di ricarica: se non vieni interrotto puoi lanciare in rapida successione.

### Per i guerrieri
- **Resta addosso** ai maghi: ogni colpo fisico li interrompe.
- I maghi devono scegliere se scappare o rischiare il mana.
- *Protection* non li aiuta contro di te.

### Per gli arcieri
- Le frecce sono danno **fisico**: interrompono come le spade.
- Puoi interrompere i maghi **da lontano**.
- Sei il nemico naturale dei maghi che cercano di tenere le distanze.

---

## 💡 Consigli
- Impara a riconoscere il **suono del fallimento**: ti dice che l'avversario ha sprecato un incantesimo.
- Un singolo **colpo fisico** basta a interrompere un mago.
- Meglio **annullare** e perdere metà del mana che subire un'interruzione e perderlo tutto.
- Il **Faster Casting** è fondamentale: meno tempo passi a concentrarti, meno occasioni dai di interromperti.
- Un **Elfo Oscuro** con INT totale ≥ 170 ottiene +2 FC razziale: il lancio più veloce del gioco.

---

## ❓ FAQ

**D: Posso muovermi mentre lancio?**
R: Sì, liberamente, anche saltare. Non sei mai bloccato.

**D: Come annullo un incantesimo?**
R: Cambiando modalità guerra/pace o lanciando un altro incantesimo. Perdi metà del mana di quello annullato.

**D: Il danno da veleno interrompe il lancio?**
R: È danno non fisico: interrompe il lancio, a meno che tu abbia *Protection* attivo. Il danno fisico invece interrompe sempre, anche con *Protection*.

**D: C'è un tempo di ricarica tra un incantesimo e l'altro?**
R: No. I limiti sono il mana e il tempo di concentrazione del successivo.

**D: Protection conviene?**
R: Dipende dal nemico. Contro guerrieri e arcieri non serve e ti rallenta (-2 FC). Contro altri maghi può salvarti incantesimi importanti.

**D: E se il bersaglio esce dal raggio o si nasconde dietro un muro durante la concentrazione?**
R: Alla fine della concentrazione il gioco controlla raggio e linea di vista. Se non sono validi l'incantesimo fallisce: perdi metà del mana e i reagenti.

---

*Vedi anche: [Magery](/wiki/skill-magery) | [Skill di combattimento](/wiki/skill-combattimento) | [Statistiche](/wiki/statistiche)*
