---
title: Scudi
slug: scudi
category: Equipaggiamento
visibility: Pubblica
---
# 🛡️ Scudi

*Tieni lo scudo alzato al momento giusto: ogni colpo davanti a te è parato, e parato bene diventa un contrattacco*

---

## 📜 Panoramica

Lo scudo si porta nella mano libera insieme a un'arma **a una mano**. Ha due funzioni:

1. **Parare** — finché tieni lo scudo alzato, ogni colpo in mischia o freccia che arriva davanti a te viene parato: non fa danno e ti costa stamina. La parata è un'azione, non un tiro di dado: nessun colpo "passa per fortuna".
2. **Proteggere** — come un pezzo di armatura, aggiunge Armor Rating e qualche punto di resistenza.

Gli scudi grandi parano meglio (costano meno stamina per colpo) ma pesano, richiedono molta Forza e rallentano. La skill [Parrying](/wiki/skill-parrying) non cambia la parata: abbassa solo la stamina che ogni colpo parato costa (costo pieno a 0.0, 70% a 100.0).

> 💡 Un'arma a due mani può parare con il suo valore di blocco (1 punto), molto meno di uno scudo. Lo scudo resta la scelta di chi vuole fare da muro: vedi [Guerriero](/wiki/classe-guerriero) e [Templare](/wiki/classe-templare).

---

## 📊 Tabella degli scudi

| Scudo | Nome UO | AR | Phys | Fire | Cold | Poison | Energy | FOR | Malus DEX | Blocco | Chi lo crea |
|-------|---------|----|------|------|------|--------|--------|-----|-----------|--------|-------------|
| **Brocchiere** | Buckler | 7 | 0 | 0 | 0 | 1 | 0 | 20 | 0 | 1 | Fabbro — Blacksmithy |
| **Scudo di legno** | Wooden Shield | 8 | 0 | 0 | 0 | 0 | 1 | 20 | 0 | 1 | Carpentiere — Carpentry |
| **Scudo di bronzo** | Bronze Shield | 10 | 0 | 0 | 1 | 0 | 0 | 35 | 0 | 2 | Fabbro — Blacksmithy |
| **Scudo di metallo** | Metal Shield | 11 | 0 | 1 | 0 | 0 | 0 | 45 | -1 | 2 | Fabbro — Blacksmithy |
| **Scudo a goccia di legno** | Wooden Kite Shield | 12 | 0 | 0 | 0 | 0 | 1 | 20 | 0 | 2 | Carpentiere — Carpentry |
| **Scudo a goccia di metallo** | Metal Kite Shield | 16 | 0 | 0 | 0 | 0 | 1 | 45 | -2 | 3 | Fabbro — Blacksmithy |
| **Scudo a torre** | Heater Shield | 23 | 0 | 1 | 0 | 0 | 0 | 90 | -4 | 4 | Fabbro — Blacksmithy |
| **Scudo dell'Ordine** | Order Shield | 30 | 1 | 0 | 0 | 0 | 0 | 95 | -5 | 4 | Ricompensa di gilda |
| **Scudo del Caos** | Chaos Shield | 30 | 1 | 0 | 0 | 0 | 0 | 95 | -5 | 4 | Ricompensa di gilda |

- **Blocco**: punti che si sottraggono alla stamina costata da un colpo parato (classi: bassa 1, media 2, alta 3, molto alta 4; conversione di ADR-0030). Più il blocco è alto, meno stamina perdi per colpo.
- Gli scudi in metallo ricevono i bonus del **metallo** come le armature (vedi [Minerali per armature](/wiki/materiali-armature-minerali)); quelli in legno i bonus del [legno](/wiki/legni).

> ⚠️ Gli **Scudi dell'Ordine e del Caos** non si costruiscono: vengono assegnati ai membri delle [gilde](/wiki/gilde) schierate con l'Ordine o con il Caos. Mostrano a tutti da che parte stai.

---

## 🎯 Come funziona la parata

Tutto si decide con il tasto di guardia e il tempismo, non con un tiro.

- **Guardia.** Finché tieni lo scudo alzato, sei in guardia: ogni colpo in mischia o freccia che arriva da davanti a te (entro 75° dalla direzione in cui guardi) è **parato** e non toglie PV. In guardia non puoi attaccare, lanciare o schivare, e cammini piano.
- **Costo.** Ogni colpo parato ti costa stamina: il danno che avrebbe fatto dopo l'armatura meno il blocco dello scudo, almeno 1, ridotto dalla tua skill Parrying (70% a 100.0). Alzare lo scudo costa anche 2 punti di stamina ogni volta.
- **Stamina finita.** Nessun costo viene rifiutato: la stamina scende a 0 e **i punti che mancano escono dai PV**. A stamina 0 la guardia resta su, ma ogni colpo parato ti costa il suo costo intero in PV.
- **Contrattacco.** Se alzi lo scudo negli ultimi **0,25 s** prima che un colpo in mischia arrivi (e lo tieni alzato), il colpo è **contrattaccato**: non fa danno, non costa stamina e l'attaccante resta **scoperto per 0,35 s**: non può colpire, parare, schivare né lanciare, e in quel tempo non può essere parato né contrattaccato.
- **Contrattacco mancato.** Se alzi lo scudo e nessun colpo arriva nei 0,25 s, il contrattacco resta bloccato per **0,5 s**: continui a parare, ma non a contrattaccare. Così non si guadagna nulla ad alzare e abbassare lo scudo di continuo.
- Le frecce e i dardi sono parati ma mai contrattaccati: l'arciere lontano non resta scoperto.
- Ogni parata consuma un po' di **durabilità** dello scudo.
- Lo scudo non para gli incantesimi, e non para i colpi alle spalle.
- Un attacco di creatura che colpisce più bersagli è contrattaccato solo per chi l'ha contrattaccato: gli altri lo subiscono normalmente, e la creatura resta scoperta una volta sola.
- I colpi delle creature sono **telegrafati**: una creatura mostra un'animazione prima di colpire, e il colpo cade su chi sta nella sua area in quel momento. Leggere l'animazione e alzare lo scudo al momento giusto è il tuo vantaggio.

| Situazione | Esito |
|------------|-------|
| Scudo alzato da tempo | Colpo parato: 0 PV, costa stamina |
| Scudo alzato negli ultimi 0,25 s | Contrattacco: 0 PV, 0 stamina, attaccante scoperto 0,35 s |
| Stamina insufficiente | Parato, ma la differenza esce dai PV |
| Contrattacco mancato | Contrattacco bloccato per 0,5 s |

*Fonte: ADR-0030 di soulslands-game, sezione 3.4; decisioni di Aruto del 28/10 e 31/10/2026.*

---

## 🧭 Quale scudo scegliere?

| Obiettivo | Scelta consigliata | Perché |
|-----------|-------------------|--------|
| Mago o arciere in emergenza | **Brocchiere** | Leggero, nessun malus |
| Combattente agile | **Scudo a goccia di metallo** | Buon blocco, Forza moderata |
| Tank puro | **Scudo a torre** | Il blocco più alto tra gli scudi costruibili |
| Assedi tra gilde | **Scudo dell'Ordine / Caos** | Il massimo dell'AR, se sei in una gilda schierata |

---

## 🔨 Crafting

- **Scudi in metallo**: [Blacksmithy](/wiki/skill-blacksmithy), da 6 (brocchiere) a 24 lingotti (scudo a torre)
- **Scudi in legno**: [Carpentry](/wiki/skill-carpentry), da 8 a 12 assi
- **Qualità**: non esiste la [qualità eccezionale](/wiki/qualita-eccezionale): lo scudo è lo stesso chiunque lo crei, la differenza la fa il materiale

---

*Vedi anche: [Armature](/wiki/armature) | [Armi](/wiki/armi) | [Sistema armature](/wiki/sistema-armature)*

> ⚖️ AR e resistenze seguono gli scudi classici di Ultima Online; malus DEX e costi in materiale sono **da bilanciare**; i punti di blocco sono quelli di ADR-0030 (decisione di Aruto del 28/10/2026).
