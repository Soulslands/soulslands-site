---
title: Regole deterministiche
slug: regole-deterministiche
category: Regole di gioco
visibility: Pubblica
---

# ⚖️ Regole deterministiche
*Soulslands è competitivo: niente dadi nascosti, vince chi gioca meglio*

---

## 📜 Panoramica

**Deciso da Aruto (27/10/2026):** Soulslands è un gioco competitivo e deterministico. Bonus e statistiche sono **valori fissi** che si sommano e si sottraggono, mai percentuali o moltiplicatori. Nessun tiro di dado decide un colpo, un danno, un'opera di artigianato, un bottino, un guadagno di skill o l'uso di una skill. Il generatore casuale del server serve solo alla varietà dell'IA, ai tempi di comparsa delle creature e alla generazione del mondo.

Molte pagine della wiki descrivono ancora i valori ereditati da Cursed Souls (percentuali, probabilità, intervalli). Finché la loro riscrittura non è finita, ogni pagina interessata porta sotto il titolo una riga che rimanda a questa e che sparisce quando la pagina è riscritta. Dove una pagina e questa regola dicono cose diverse, vale questa.

## 🧭 La regola in sintesi

| Ambito | Regola |
|--------|--------|
| Bonus | Numeri fissi con segno e unità, che si sommano: mai percentuali né moltiplicatori |
| Combattimento | Un colpo che arriva a segno colpisce sempre; Danno = arma + statistiche − armatura, senza intervallo. Si manca solo quando mira, portata o linea di vista non bastano |
| Parata | Attiva: la fa il giocatore, non un tiro |
| Creature | Attaccano con schemi telegrafati, che si possono leggere e schivare |
| Artigianato | Con materiali, attrezzo e postazione giusti non fallisce mai; qualsiasi ricetta è aperta da skill 0.0 e la skill rende il lavoro più rapido. Non esiste la qualità eccezionale (Aruto, 28/10/2026) |
| Skill | Non sbloccano nulla: qualsiasi minerale, legno, ricetta o creatura domabile è aperto da 0.0. Le azioni di raccolta e di crafting durano il tempo base × (1 − skill/200); il guadagno è fisso: 1 + t²/18.000 usi per ogni 0,1, circa 40 ore fino a 100.0 |
| Bottino | Fisso per ogni creatura; la rarità viene da creature e boss rari. Non esiste la Fortuna (Luck); i blocchi danno sempre lo stesso |
| Risorse | Minerali e risorse vengono dalla generazione del mondo e dallo scavo, mai da una probabilità di trovarli |
| Sfide tra giocatori | Solo le azioni contro un altro giocatore (rubare, curiosare, cercare un nascosto, scassinare la serratura di un altro giocatore) sono sfide skill contro skill, con vittoria solo per valore strettamente più alto; a 100.0 una skill conta come 120.0 (+20.0 fisso). Domare riesce sempre, ma le creature forti non si possono domare |
| Condizioni | Restano condizioni: per esempio "sotto un quarto degli HP massimi". Un effetto può portare una condizione generica, usabile anche dalle mod |
| Quote fisse | Restano frazioni: per esempio si perde metà del mana di un incantesimo annullato |

Il resto del combattimento è affidato all'abilità di chi gioca: [Sistema di casting](/wiki/sistema-di-casting), [Sistema armature](/wiki/sistema-armature).

## 🛡️ Cuoio dei mostri

**Deciso da Aruto (27/10/2026):** il cuoio dei mostri serve solo per le armature. Ogni pezzo dà un piccolo bonus fisso legato alla leggenda del mostro, un set completo della stessa pelle un bonus di set appena più grande, mai tale da aprire un divario reale. Non ci sono bonus al danno delle armi. Vedi [Cuoio](/wiki/cuoio).

## ✍️ Nota di stile per chi scrive la wiki

Regole per riscrivere le pagine con valori ereditati.

- **Un bonus è un numero di punti**, scritto con segno e unità: "Danno +2", "Resistenza al fuoco +3", "Rigenerazione HP +1 ogni 10 s", "Requisito di FOR −10". Mai "+10%", mai "×1,5", mai "dimezza" per un bonus.
- **Una resistenza sono punti di danno tolti**, non una percentuale: "Armatura fisica 12" vuol dire che un colpo perde 12 HP di danno fisico. Gli eventuali tetti sono punti.
- **Una formula è una somma**, scritta una volta sola nella pagina che la possiede, con un esempio svolto: "Danno = danno dell'arma + bonus di FOR + bonus di Tactics + bonus di materiale − armatura del bersaglio (minimo 1)". Nessun intervallo: un'arma ha un solo numero di danno.
- **Una soglia è una condizione**, scritta come frazione del massimo o come valore assoluto: "quando gli HP scendono sotto un quarto del massimo", "con Mining almeno 65,0". La condizione non cambia la grandezza del bonus: il bonus è fisso e si accende o si spegne.
- **Una quota fissa di una riserva** (mana perso in un incantesimo annullato, fama persa alla morte) si scrive come frazione: "perdi metà del mana", "perdi un decimo della fama". Le quote esatte sono ancora una domanda aperta per Aruto.
- **Niente parole di probabilità** nelle regole: né "probabilità", "possibilità di", "a volte", "raro (5%)", "con una certa probabilità". Ciò che lascia una creatura è un elenco fisso con quantità fisse; ciò che fa una skill a un dato livello è certo.
- **Velocità, non sblocchi e non fortuna**: più skill rende più rapide le azioni di raccolta e di crafting; nessuna skill dà accesso a ricette, materiali o oggetti, e non esiste la qualità eccezionale.
- Ogni pagina ancora da riscrivere porta sotto il titolo la riga: "Regola deterministica (decisione di Aruto, 27/10/2026): valori fissi, nessuna probabilità." con il rimando a questa pagina; la perde nella PR che riscrive la sua area.

## 🔗 Vedi anche

- [Full loot](/wiki/full-loot) — cosa si perde alla morte
- [Karma e fama](/wiki/karma-e-fama) — reputazione e quote fisse
- [Sistema di casting](/wiki/sistema-di-casting) — incantesimi con bersaglio
- [Qualità eccezionale](/wiki/qualita-eccezionale) — perché non esiste
- [Cuoio](/wiki/cuoio) — pelli dei mostri e armature
