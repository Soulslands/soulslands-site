---
title: Guardie cittadine
slug: guardie-cittadine
category: Regole di gioco
visibility: Pubblica
---
# 🛡️ Guardie cittadine
*Dentro le mura, la legge. Fuori, la sopravvivenza*

---

## 📜 Panoramica

I **feudi** del [mondo](/wiki/mondo), le città murate che genera il generatore (vedi [Strutture](/wiki/strutture#feudi-villaggi-e-strade)), sono protetti da **guardie**: NPC invulnerabili che eliminano all'istante criminali, assassini e mostri all'interno della **zona di guardia**. È l'unico luogo davvero sicuro di Soulslands. Le [città di gilda](/wiki/citta-di-gilda) possono avere guardie proprie, con regole decise dalla gilda.

---

## 🗺️ La zona di guardia

| Caratteristica | Dettaglio |
|----------------|-----------|
| **Estensione** | La città murata e una fascia intorno alle mura; nessuna colonna segna il confine ([ADR-0033](https://github.com/Soulslands/soulslands-game/blob/main/docs/adr/0033-walled-settlements-gate-roads.md) sezione 7) |
| **Avviso** | Quando entri o esci appare il messaggio "Sei sotto la protezione delle guardie" / "Hai lasciato la protezione delle guardie" |
| **Blocchi** | Dentro i feudi non si può scavare né costruire; i villaggi sono terra libera |
| **Spawn** | Nessun mostro ostile compare nella zona (vedi [Spawn delle creature](/wiki/spawn-creature)) |

---

## ⚔️ Quando intervengono le guardie

| Situazione | Reazione |
|------------|----------|
| Un giocatore **rosso** entra nella zona | Le guardie lo attaccano a vista |
| Un giocatore diventa **grigio** (criminale) e qualcuno grida **"Guardie!"** | Una guardia compare accanto al criminale e lo uccide |
| Un giocatore attacca un innocente | Diventa criminale: basta chiamare le guardie |
| Un mostro ostile entra nella zona (inseguendo qualcuno o portato da un giocatore) | Le guardie lo uccidono |
| Qualcuno ruba ed è scoperto | Diventa criminale: guardie chiamabili (vedi [Furto](/wiki/furto)) |
| Combattimento tra gilde in **guerra** (arancioni) | Le guardie **non intervengono**: le guerre tra gilde si combattono anche in città |
| Duello consensuale | Le guardie non intervengono |

> ⚠️ Le guardie arrivano solo se **qualcuno le chiama** (tranne che per i rossi e i mostri, che attaccano da sole). In un feudo affollato qualcuno griderà sempre "Guardie!"; i villaggi non hanno guardie.

---

## 🧱 Cosa le guardie non fanno

- Non proteggono **fuori** dalla zona di guardia: un passo oltre la zona di guardia e sei nelle terre selvagge.
- Non restituiscono gli oggetti rubati o saccheggiati.
- Non impediscono il [furto](/wiki/furto): puniscono il ladro scoperto.
- Non uccidono chi è solo grigio per aver attaccato un rosso: attaccare un rosso è legale.
- Non si possono uccidere né corrompere.

---

## 🏰 Guardie nelle città di gilda

Una gilda che controlla una città può assoldare guardie tramite la [Pietra del Territorio](/wiki/pietra-territorio-gilda). Le guardie di gilda:

- Proteggono solo il territorio della gilda.
- Possono essere configurate per attaccare i rossi, i criminali, i nemici di guerra o tutti tranne alleati.
- **Possono essere uccise** durante un assedio: non sono invulnerabili come quelle dei feudi.
- Hanno un costo di mantenimento a carico della gilda (vedi [Contabile di gilda](/wiki/contabile-gilda)).

---

*Vedi anche: [Karma e fama](/wiki/karma-e-fama) | [Player killer e redenzione](/wiki/player-killer-e-redenzione) | [Città di gilda](/wiki/citta-di-gilda)*
