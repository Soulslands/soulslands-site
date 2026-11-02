---
title: Tossicità delle pozioni
slug: tossicita-pozioni
category: Meccaniche
visibility: Pubblica
---
# 🧪 Tossicità delle pozioni

*Bevi quanto vuoi, ma il corpo presenta il conto*

---

## 📜 Panoramica

In Soulslands, come su Cursed Souls, le pozioni bevute **non hanno tempi di attesa fissi**. Puoi bere Cura, Agilità, Forza, Visione notturna e tutte le altre una dietro l'altra. In cambio il tuo corpo accumula **tossicità**: un contatore invisibile che sale a ogni sorso e scende lentamente nel tempo.

Quando la tossicità supera certe soglie, il personaggio subisce **effetti collaterali**: nausea, tremori, vomito, allucinazioni, fino all'overdose. L'effetto dipende dal **mix di pozioni** bevute di recente: un'intossicazione da Cura+Stat è diversa da una da Antidoto+Visione notturna.

> Le pozioni **da lancio** (Esplosiva, Conflagrazione, Confusione) mantengono il loro tempo di ricarica (30 o 60 secondi): non si bevono e non contribuiscono alla tossicità.

Le pozioni si preparano con [Alchemy](/wiki/skill-alchemy).

---

## 🎯 Come funziona

### Accumulo
Ogni pozione bevuta aggiunge tossicità in base alla sua **potenza**:

| Potenza | Esempi | Tossicità aggiunta |
|---------|--------|-------------------|
| Minore | Cura minore, Antidoto minore | ~13 punti |
| Normale | Cura, Agilità, Ristoro | ~18 punti |
| Maggiore | Cura maggiore, Agilità maggiore, Ristoro totale | ~27 punti |

Le pozioni più potenti accumulano più in fretta, ma danno effetti migliori: una scelta strategica.

### Calo
La tossicità cala di **circa 1 punto al secondo**, sempre. Il calo continua **anche da offline**: se esci con tossicità alta e torni dopo qualche minuto, la trovi già scesa.

### Categorie
A ogni sorso il gioco memorizza la **categoria** della pozione per **45 secondi**: è questa a decidere il *tipo* di effetto collaterale.

| Categoria | Pozioni |
|-----------|---------|
| **Cura** | Cura minore, Cura, Cura maggiore |
| **Stat** | Agilità, Agilità maggiore, Forza, Forza maggiore |
| **Antidoto** | Antidoto minore, Antidoto, Antidoto maggiore |
| **Ristoro** | Ristoro, Ristoro totale |
| **Notte** | Visione notturna |
| **Veleno** | Veleno minore, Veleno, Veleno maggiore, Veleno mortale |
| **Chiarezza** | Pozione di chiarezza |

Bevendo più volte la stessa categoria le istanze si sommano: la categoria **dominante** (quella con più istanze attive) influenza il tipo di effetto.

---

## 🌡️ Le fasce di gravità

La tossicità attraversa 5 stati. Un'**icona** di stato cambia per farti capire in che fascia sei.

| Fascia | Valori | Icona | Cosa succede |
|--------|--------|-------|--------------|
| **Sicura** | 0 – 25 | Nessuna | Nessun effetto. Bevi pure |
| **Lieve** | 26 – 50 | Debolezza | Nausea, tremore, vista annebbiata |
| **Moderata** | 51 – 75 | Mente marcia | Vomito, calo delle stat, spasmi muscolari |
| **Grave** | 76 – 100 | Piaga | Allucinazioni, paralisi tossica, emorragia interna |
| **Critica** | oltre 100 | Strangolamento | **Collasso tossico** |

A ogni cambio di fascia compare un **messaggio sopra il personaggio** (*"Ti senti un po' nauseato"*, *"Stai per vomitare"*, *"Il tuo corpo cede all'overdose"*). Quando la tossicità scende compaiono messaggi di recupero.

---

## ⚡ Effetti collaterali

Quando superi una soglia, scatta un **effetto** tra quelli compatibili con le categorie attive. Gli effetti scattano **sempre nell'ordine delle tabelle qui sotto**, uno ogni **4 secondi** (il tempo minimo tra un effetto e l'altro); finché resti in una fascia negativa gli effetti compatibili si ripetono a turno, sempre nello stesso ordine. Non c'è nessun tiro: con le stesse pozioni bevute succede sempre la stessa cosa.

### Fascia lieve (26 – 50)

| Effetto | Condizione | Cosa fa |
|---------|-----------|---------|
| **Nausea** | 2 o più categorie diverse attive | -8 DEX per 20 s, suono di mal di stomaco |
| **Tremore** | Categoria Stat attiva | Perdi subito il 30% della stamina |
| **Vista annebbiata** | Categoria Notte o Antidoto attiva | Vedi più buio per 20 s |

### Fascia moderata (51 – 75)

| Effetto | Condizione | Cosa fa |
|---------|-----------|---------|
| **Vomito** | Qualsiasi | Animazione e immobilità per 2 s, **riduce la tossicità del 40%** |
| **Calo delle stat** | Domina Stat | -10 alla tua stat base più alta per 30 s (a parità, prima FOR, poi DES, poi INT) |
| **Spasmi muscolari** | Domina Ristoro | Stamina a 0 e -15 DEX per 15 s |

### Fascia grave (76 – 100)

| Effetto | Condizione | Cosa fa |
|---------|-----------|---------|
| **Allucinazioni** | Antidoto+Notte o Stat+Veleno | Suoni inquietanti e visioni fantasma per 25 s |
| **Paralisi tossica** | Veleno, oppure Cura+Stat | Paralizzato per 4 s |
| **Emorragia interna** | Domina Cura | Perdi 3 HP ogni 3 s per 30 s |

### Fascia critica (oltre 100)

| Effetto | Condizione | Cosa fa |
|---------|-----------|---------|
| **Collasso tossico** | Qualsiasi | HP al 10%, immobile per 5 s, tossicità dimezzata |

> Il **vomito** e il **collasso** sono le uniche due "valvole di sfogo" che riducono la tossicità da sole. Se resti in fascia moderata, il vomito arriva sempre nel suo turno e può tenerti lontano dal collasso.

### Nel mondo a voxel
Gli effetti si sentono anche nel movimento: con gli **spasmi muscolari** o la **paralisi** non puoi saltare né nuotare, e un collasso mentre nuoti in acque profonde o ti arrampichi su una parete è particolarmente pericoloso. Le allucinazioni mostrano creature che non esistono tra i blocchi d'ombra.

---

## 🎭 Combinazioni chiave

### Cura + Stat (guaritore da battaglia)
Bevi Cura maggiore e Agilità maggiore in combattimento: Cura e Stat attive insieme, in fascia grave scatta la **paralisi tossica**. Il guaritore si blocca in mezzo ai nemici.

### Antidoto + Notte (esploratore avvelenato)
Scendi in una grotta con Visione notturna, ti avveleni e bevi un Antidoto maggiore: in fascia grave arrivano le **allucinazioni**, mentre sei in un covo nemico.

### Stat + Veleno (assassino improvvisato)
Usi il veleno per l'arma mentre ti pompi di Forza: **allucinazioni** e paralisi sono in agguato.

### Solo Cura (il tank che si cura sempre)
Bevi solo pozioni di Cura: domina Cura e in fascia grave rischi l'**emorragia interna**, 30 secondi di danno continuo mentre cerchi di curarti ancora. Una spirale mortale.

### Solo Ristoro (abuso di stamina)
Bevi Ristoro di continuo per combattere senza sosta: in fascia moderata arrivano gli **spasmi muscolari**, stamina a zero e -15 DEX.

---

## 💡 Strategie e consigli

### Contro le creature
- **Bevi con criterio** nei momenti critici: 2-3 Cure maggiori di fila ti salvano la vita, 10 ti uccidono da sole.
- Tra un combattimento e l'altro **lascia scendere** la tossicità fino alla fascia sicura prima di prepararti con altre pozioni.
- In fascia grave il vomito non scatta più (è un effetto della fascia moderata): senza via di fuga smetti di bere, perché oltre 100 arriva il collasso.

### Contro i giocatori
- Puoi **logorare i guaritori** aspettando che accumulino tossicità: in fascia moderata vomitano (2 s immobili), in fascia grave sono paralizzabili.
- Veleno sull'arma più pozioni di stat su te stesso: con cautela, o ti paralizzi da solo.
- La Pozione di chiarezza ha una sua categoria: attento a sommarla alle altre.

### Per guaritori e supporto
- Le pozioni di **categorie diverse** fanno scattare la nausea più facilmente (soglia "2+ categorie").
- Se devi curarti a lungo, alterna **Cura + Antidoto + Ristoro** invece di bere solo Cura: così eviti l'emorragia interna.
- Un **vomito "programmato"** in un momento tranquillo può essere una strategia: 2 secondi fermo e torni pulito.

### Creature e compagni
Anche le **creature** e i **compagni** che bevono pozioni accumulano tossicità. Una creatura guaritrice che beve Cure maggiori a ripetizione finirà per vomitare davanti a te, aprendoti una finestra d'attacco.

---

## ❓ FAQ

**D: Come vedo la mia tossicità?**
R: Non c'è una barra numerica: ti affidi all'**icona di stato** e ai **messaggi** al cambio di fascia. Il personaggio "sente" il malessere, non lo legge su un grafico.

**D: Il calo funziona anche da offline?**
R: Sì. Se esci con tossicità 80 e rientri dopo 2 minuti, è a 0. Il tuo personaggio resta comunque nel mondo (vedi [Persistenza del mondo](/wiki/persistenza-del-mondo)).

**D: Un riavvio del server mi "cura"?**
R: No. Tossicità, categorie attive e timer degli effetti sono salvati con il mondo.

**D: Le pozioni da lancio contano?**
R: No. Hanno il loro tempo di ricarica (30/60 s). Solo le pozioni **bevute** danno tossicità.

**D: Posso bere due Agilità di fila?**
R: Sì: la seconda rinnova la durata dell'effetto (non lo raddoppia), ma aggiunge altri ~18 punti di tossicità e una seconda istanza di Stat.

**D: Come riduco in fretta la tossicità?**
R: Solo con il **vomito** (-40%, in fascia moderata) e il **collasso** (dimezza, oltre 100). Il vomito scatta nel suo turno della sequenza degli effetti. Altrimenti devi aspettare.

**D: Un compagno che beve Cure a ripetizione si autodistrugge?**
R: Oggi le creature non controllano la propria tossicità prima di bere: spesso i guaritori si sabotano da soli, e tu puoi approfittarne. Potrebbe essere bilanciato in futuro.

**D: L'effetto della pozione si applica anche se poi vomito?**
R: Sì. La pozione agisce **prima** di aggiungere tossicità: l'effetto collaterale arriva dopo e non annulla il beneficio.

**D: Non vedo nessuna icona. Posso bere?**
R: Sì: senza icona sei in fascia sicura (0-25).

---

*Vedi anche: [Alchemy](/wiki/skill-alchemy) | [Poisoning](/wiki/skill-poisoning) | [Healing](/wiki/skill-healing)*
