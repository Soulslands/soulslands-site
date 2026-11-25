---
title: Fame, sete e aria
slug: fame-sete-e-aria
category: Meccaniche
visibility: Pubblica
---
# 🍖 Fame, sete e aria

*Mangia, bevi e torna a galla in tempo: il corpo chiede sempre qualcosa*

---

## 📋 Indice

- [Panoramica](#panoramica)
- [La fatica](#la-fatica)
- [Quando un bisogno arriva a zero](#quando-un-bisogno-arriva-a-zero)
- [La vita torna se sei sazio](#la-vita-torna-se-sei-sazio)
- [Mangiare](#mangiare)
- [Bere e la borraccia](#bere-e-la-borraccia)
- [L'aria](#laria)
- [Difficoltà e regole del mondo](#difficolta-e-regole-del-mondo)
- [FAQ](#faq)

---

## 📜 Panoramica

Nei mondi sopravvivenza ogni personaggio vivo ha **vita**, **stamina**, **fame**, **sete** e **aria**. In creativa nessuno di questi valori cambia, e un fantasma non ne ha bisogno (vedi [Morte e fantasmi](/wiki/morte-e-fantasmi)).

**Deciso da Aruto (17/11/2026):** vita, stamina, fame, sete e aria arrivano subito, con la fatica di Minecraft; la vita torna in base a quanto il personaggio è sazio e dissetato, e un bisogno a zero toglie vita fino alla morte; si mangiano i cibi vegetali crudi, si beve mirando l'acqua, l'acqua di mare non si beve, c'è una borraccia; l'aria dura 30 secondi, poi si perdono 10 punti vita al secondo, e torna piena in 2 secondi; si soffoca solo nei liquidi e nei gas. Aruto ha accettato i valori di questa pagina **come punto di partenza, da tarare dopo la prima prova**.

| Valore | Quanto | Si vede sull'HUD |
|--------|--------|------------------|
| ❤️ **Vita** | 100 per tutti, finché le [statistiche](/wiki/statistiche) non la calcoleranno dalla Forza | Barra della vita |
| ⚡ **Stamina** | 100 per tutti, finché le statistiche non la calcoleranno dalla Destrezza | Barra della stamina |
| 🍖 **Fame** | Da 0 a 20; un personaggio nuovo parte da 20 | Fila di 10 icone in basso a destra (ogni icona vale 2 punti, mezza icona 1) |
| 💧 **Sete** | Da 0 a 20; parte da 20 | Fila di 10 icone in basso a destra, sotto la fame |
| 🫧 **Aria** | 30 secondi | Fila di bolle sopra la barra rapida, solo quando non è piena |

Le file di icone si vedono solo in sopravvivenza e mai per un fantasma. Tutti i numeri li decide il server: il gioco non si fida di quello che dice il client.

---

## 😓 La fatica

Come in Minecraft, quello che fai accumula **fatica**. Ogni **4 punti** di fatica tolgono 1 punto di fame e ogni **2,4 punti** tolgono 1 punto di sete: per questo la sete scende quasi il doppio più in fretta della fame. In difficoltà difficile bastano 3 punti per la fame e 1,8 per la sete.

| Cosa fai | Fatica |
|----------|--------|
| Esistere (anche da fermo) | 0,013 al secondo |
| Correre | 0,1 per blocco percorso |
| Nuotare | 0,01 per blocco percorso |
| Saltare | 0,05 |
| Saltare correndo | 0,2 |
| Recuperare 1 punto vita | 0,3 |

Esempi (calcolo nostro, difficoltà normale): da fermo perdi 1 punto di sete ogni 3 minuti circa e 1 di fame ogni 5 minuti circa; correndo perdi 1 punto di sete ogni 24 blocchi e 1 di fame ogni 40.

### Cosa costa stamina

| Cosa fai | Stamina |
|----------|---------|
| Correre | 5 al secondo |
| Nuotare | 1 al secondo |
| Saltare | 2 |

Una spesa di stamina non viene mai rifiutata: se non ne hai abbastanza, quello che manca diventa un **debito**. Finché hai un debito cammini piano (circa 1,3 blocchi al secondo) e non puoi correre, così non spendi niente e il debito si ripaga da solo. La barra della stamina mostra il debito come numero negativo (per esempio `-25/100`). Nuotare e saltare non rallentano mai, così un debito non fa annegare nessuno. Nelle prossime versioni costeranno stamina anche colpi, parate e schivate (vedi [Statistiche](/wiki/statistiche)).

---

## ☠️ Quando un bisogno arriva a zero

| Bisogno a zero | Danno (difficoltà normale) |
|----------------|----------------------------|
| **Fame** 0 | 2 punti vita ogni 4 secondi |
| **Sete** 0 | 2 punti vita ogni 2 secondi |

In difficoltà normale e difficile la fame e la sete uccidono; in facile ti lasciano sempre almeno 1 punto vita; in pacifica non fanno danno. In difficile il danno sale a 3. La schermata di morte dice "You starved to death." o "You died of thirst.".

---

## 💗 La vita torna se sei sazio

La vita e la stamina tornano da sole, a un punto alla volta. Conta il **più basso** tra fame e sete:

| Fame e sete (il più basso) | Vita | Stamina |
|----------------------------|------|---------|
| **Sazio**: 15 o più | 1 punto ogni 2 secondi | 1 punto ogni mezzo secondo |
| **A metà**: da 5 a 14 | 1 punto ogni 6 secondi | 1 punto al secondo |
| **Basso**: da 1 a 4 | Non torna | 1 punto ogni 2 secondi |
| **Vuoto**: 0 | Non torna | Non torna |

- In difficoltà pacifica la vita torna sempre, 1 punto ogni 2 secondi, anche a fame e sete basse.
- Ogni punto di vita recuperato costa fatica (vedi sopra): guarire fa venire fame e sete.
- Mentre corri la stamina non torna. Se hai un debito, la stamina che torna lo ripaga prima.
- Con la regola del mondo **rigenerazione naturale** spenta la vita non torna mai da sola; la stamina sì.

---

## 🍓 Mangiare

Per ora si mangiano i cibi vegetali crudi. Mangiare è **istantaneo**: un'unità del cibo sparisce e fame e sete salgono subito, fino a 20.

| Cibo | Fame | Sete |
|------|------|------|
| Bacche (`berries`) | 1 | 0 |
| Bacche luminose (`glow_berries`) | 1 | 0 |
| Fette di melone (`melon_slices`) | 2 | 1 |
| Fico d'India (`prickly_pear_fruit`) | 2 | 1 |
| Favo di miele (`honeycomb`) | 3 | 0 |
| Polpa di cactus (`cactus_pulp`) | 0 | 2 |

- **Come si mangia.** Metti il cibo su una casella della barra rapida o degli slot rapidi (resta nello zaino, la casella è solo una scorciatoia) e premi il tasto d'uso (tasto destro) o il tasto dello slot rapido. Puoi anche fare doppio clic sul cibo nello zaino.
- Se fame e sete che quel cibo dà sono già a 20, il gioco rifiuta: "You are too full to eat that.".
- La cucina, la carne e i piatti cotti arrivano più avanti con la skill [Cooking](/wiki/skill-cooking).

---

## 🫗 Bere e la borraccia

- **Bere dall'acqua dolce.** Con le mani libere (una casella vuota della barra rapida, o una che non ha niente da fare) mira l'acqua di un fiume, di un lago o di una sorgente entro 5 blocchi e premi il tasto d'uso: ogni sorso dà **4 punti di sete**. L'acqua non si consuma.
- **L'acqua di mare non si beve.** Il mare, le spiagge e le mangrovie hanno un blocco a parte, l'acqua di mare (`sea_water`), salata: provando a berla il gioco risponde "You cannot drink that." (vedi [Oceani](/wiki/oceani) e [Laghi e fiumi](/wiki/laghi-e-fiumi)).
- **La borraccia** (`waterskin`) tiene **4 sorsi**, e ogni sorso dà la sete dell'acqua dolce (4 punti). Con la borraccia sulla barra rapida, il tasto d'uso mirando l'acqua dolce la **riempie**; senza mirare l'acqua **bevi** un sorso. Da piena a vuota resta nello zaino: si svuota, non si consuma.
- **Ogni personaggio nuovo** di un mondo sopravvivenza riceve una **borraccia vuota** nello zaino.
- Se la sete è già a 20 il gioco rifiuta: "You are not thirsty.". Una borraccia vuota risponde "There is nothing left to drink in it.".

---

## 🫧 L'aria

- Conta la cella degli **occhi**: quando la testa è dentro un liquido o un gas, l'aria scende; fuori torna piena in **2 secondi**.
- Da piena l'aria dura **30 secondi**. Finita l'aria si perdono **10 punti vita al secondo**: sott'acqua si annega, in un gas si soffoca.
- **Si soffoca solo nei liquidi e nei gas** (**deciso da Aruto, 17/11/2026**): sabbia, ghiaia e sabbie mobili non soffocano più, e nemmeno un blocco piazzato all'altezza della testa.
- Mentre gli occhi sono sott'acqua o in un gas la vista si colora della tinta di quel liquido o gas.
- Dove si trovano i gas e cosa fanno: [Gas](/wiki/gas). Come si nuota: [Oceani](/wiki/oceani#nuotare-e-respirare).

---

## ⚙️ Difficoltà e regole del mondo

La difficoltà si sceglie quando crei il mondo (vedi [Modalità di gioco](/wiki/modalita-di-gioco)); su un server la decide chi lo ospita e può cambiarla tra un avvio e l'altro. Un mondo hardcore si gioca sempre in difficile.

| | Pacifica | Facile | Normale | Difficile |
|---|---|---|---|---|
| **Fatica** | Nessuna: fame e sete non scendono | Sì | Sì | Sì, e fame e sete scendono più in fretta |
| **Fame o sete a zero** | Nessun danno | 2 punti vita, mai sotto 1 | 2 punti vita, fino alla morte | 3 punti vita, fino alla morte |
| **Vita a fame e sete basse** | Torna sempre | Come nella tabella sopra | Come nella tabella sopra | Come nella tabella sopra |
| **Cadute, lava, magma, annegamento, gas, esplosioni** | Uguali in ogni difficoltà | | | |

Tre **regole del mondo** cambiano i bisogni:

| Regola | Di partenza | Cosa fa |
|--------|-------------|---------|
| **Fame e sete** (`needs`) | Accesa | Spenta, fame e sete restano piene: non scendono e non fanno danno |
| **Rigenerazione naturale** (`natural_regeneration`) | Accesa | Spenta, la vita non torna da sola (la stamina sì) |
| **Tieni l'inventario** (`keep_inventory`) | Spenta | Accesa, alla morte tieni tutto (vedi [Full loot](/wiki/full-loot)) |

Fonte tecnica: [ADR-0047](https://github.com/Soulslands/soulslands-game/blob/main/docs/adr/0047-survival-basics.md).

---

## ❓ FAQ

**D: Il menu di pausa ferma la fame?**
R: Da solo sì: il menu di pausa ferma il mondo, quindi fame, sete, aria e danni si fermano con lui. Su un server il mondo non si ferma mai.

**D: In creativa ho fame?**
R: No. In creativa fame, sete e aria non cambiano e mangiare risponde che sei sazio; la borraccia però si riempie.

**D: Perché la sete scende più della fame?**
R: Perché servono meno punti di fatica per togliere un punto di sete (2,4 contro 4). Tieni la borraccia piena e una fonte d'acqua dolce vicino a casa.

---

## 🔗 Vedi anche

- [Statistiche](/wiki/statistiche) — vita, stamina e mana
- [Morte e fantasmi](/wiki/morte-e-fantasmi) — cosa succede a zero vita
- [Gas](/wiki/gas) — i gas che tolgono l'aria e quelli che esplodono
- [Oceani](/wiki/oceani) — nuotare e respirare
- [Modalità di gioco](/wiki/modalita-di-gioco) — creativa, sopravvivenza, difficoltà
