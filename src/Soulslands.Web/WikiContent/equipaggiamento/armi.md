---
title: Armi
slug: armi
category: Equipaggiamento / Armi
visibility: Pubblica
---
# ⚔️ Armi

*Guida generale alle armi di Soulslands: come funzionano, chi le usa, chi le forgia*

---

## 📋 Indice

- Panoramica
- Le famiglie di armi
- Skill di combattimento
- Danno e tipi di danno
- Velocità d'attacco
- Una mano o due mani
- Forza richiesta
- Portata nel mondo a voxel
- Mosse speciali
- Durabilità e riparazione
- Qualità e materiali
- FAQ

---

## 📜 Panoramica

Le armi di Soulslands sono le stesse armi classiche di Ultima Online, portate in un mondo a voxel dove ogni colpo avviene in uno spazio tridimensionale fatto di blocchi. Ogni arma ha **un solo valore di danno**, una **velocità**, un **requisito di Forza**, un numero di **mani** necessarie e una **skill di combattimento** che ne governa l'uso.

Le armi non sono "di classe": chiunque può impugnare qualsiasi arma, purché abbia la Forza sufficiente. La skill giusta non cambia il danno né la velocità del colpo: abbassa solo la stamina che ogni colpo costa.

> 💡 Ogni arma che trovi nel mondo è un oggetto reale e persistente: è stata forgiata da un fabbro, può essere rubata, persa alla morte ([Full Loot](/wiki/full-loot)) e consumata dall'uso.

---

## 🗂️ Le famiglie di armi

| Famiglia | Pagina | Skill principale | Esempi |
|----------|--------|------------------|--------|
| 🗡️ **Spade** | [Spade](/wiki/armi-spade) | Swordsmanship | Katana, Spada lunga, Scimitarra |
| 🪓 **Asce** | [Asce](/wiki/armi-asce) | Swordsmanship | Ascia del boia, Ascia doppia, Accetta |
| 🔨 **Mazze e bastoni** | [Mazze](/wiki/armi-mazze) | Mace Fighting | Martello da guerra, Maglio, Bastone ferrato |
| 🤺 **Scherma** | [Scherma](/wiki/armi-scherma) | Fencing | Pugnale, Kryss, Lancia, Picca |
| 🔱 **Armi in asta** | [Armi in asta](/wiki/armi-armi-in-asta) | Swordsmanship / Fencing | Alabarda, Bardica |
| 🏹 **Archi e balestre** | [Archi](/wiki/armi-archi) | Archery | Arco composito, Balestra pesante, Yumi |

> ⚠️ Come in Ultima Online, **asce e armi in asta usano Swordsmanship**, non una skill propria. L'unica eccezione è l'**Ascia da guerra** (War Axe), che usa Mace Fighting.

---

## 🎯 Skill di combattimento

| Skill | Armi | Stat che conta di più |
|-------|------|----------------------|
| [Swordsmanship](/wiki/skill-swordsmanship) | Spade, asce, alabarde, bardiche, falci | STR |
| [Mace Fighting](/wiki/skill-mace-fighting) | Mazze, martelli, bastoni, ascia da guerra | STR |
| [Fencing](/wiki/skill-fencing) | Pugnali, kryss, lance, picche, forconi | DEX |
| [Archery](/wiki/skill-archery) | Archi e balestre | DEX |
| [Wrestling](/wiki/skill-wrestling) | Mani nude | STR |

Le skill di supporto valgono per tutte le armi:

- [Tactics](/wiki/skill-tactics) — insieme alla skill dell'arma abbassa la stamina di ogni colpo e di ogni mossa speciale.
- [Anatomy](/wiki/skill-anatomy) — bende applicate più in fretta.
- [Parrying](/wiki/skill-parrying) — abbassa la stamina di ogni colpo parato con lo scudo (o con un'arma a due mani).
- [Arms Lore](/wiki/skill-arms-lore) — permette di valutare un'arma e la sua usura.

Nessuna di queste skill aggiunge danno: il danno viene solo da arma, Forza e materiale. Vedi anche [Skill di combattimento](/wiki/skill-combattimento).

---

## 💥 Danno e tipi di danno

Il danno indicato nelle tabelle (es. **12** per la katana) è il **danno base** dell'arma: un solo numero fisso, senza intervallo. Il colpo che arriva a bersaglio colpisce sempre; il danno è una somma:

```
Danno fisico = Danno base dell'arma
             + Forza / 10
             + bonus del materiale
Danno subito = Danno fisico - punti di armatura fisica del bersaglio    (minimo 1)
```

Sul danno elementale (Fuoco, Freddo, Veleno, Energia) lo stesso calcolo vale per tipo: ogni quantità elementale, data dal materiale, si riduce con i punti di armatura di quel tipo. Nessuna skill è nella formula.

> **Esempio:** una katana (danno 12) in mano a un personaggio con Forza 100 e lama di ferro (nessun bonus del materiale) fa 12 + 10 = **22** di danno fisico. Contro un set di piastre con 10 punti di armatura fisica passano **12 PV** per colpo, qualunque skill abbia il guerriero. Un guerriero a skill 100.0 e uno a 0.0 colpiscono con lo stesso ritmo e lo stesso danno; il secondo però paga più stamina per colpo e si ferma prima.

### Tipo di colpo

In Soulslands ogni arma appartiene a uno di tre tipi di colpo. Il tipo di colpo non cambia la resistenza usata (il danno fisico viene sempre ridotto dalla **Physical Resist**) ma determina alcuni effetti secondari:

| Colpo | Armi | Effetto secondario |
|-------|------|-------------------|
| **Taglio** | Spade, asce, armi in asta, falci | Più efficace contro bersagli senza armatura; le asce tagliano anche i blocchi di legno |
| **Punta** | Pugnali, kryss, lance, picche, frecce, dardi | Può causare sanguinamento; colpisce bene nelle fessure delle armature leggere |
| **Contundente** | Mazze, martelli, bastoni | Ignora parzialmente l'armatura e ne consuma la durabilità; può stordire |

### Danno elementale

Il danno di un'arma è fisico, a meno che il **materiale** con cui è forgiata non aggiunga una quantità fissa di danno elementale (Fuoco, Freddo, Veleno, Energia). Ad esempio un'arma in [Silver](/wiki/minerale-silver) aggiunge danno da Freddo ed Energia. Vedi [Minerali](/wiki/minerali) per le proprietà di ogni metallo sulle armi.

---

## ⏱️ Velocità d'attacco

La velocità è un valore numerico: **più è alto, più l'arma è veloce**. Il tempo tra un colpo e l'altro dipende dall'arma e dalla tua stamina, mai dalle skill.

### Stamina per colpo

Ogni colpo costa stamina in base alla velocità dell'arma. Il costo è pieno a skill 0.0 e scende al 70% a 100.0 (la skill è la media tra la skill dell'arma e Tactics):

| Velocità | Stamina per colpo (a skill 0.0) |
|----------|---------------------------------|
| 50+ | 2 |
| 30-49 | 3 |
| Sotto 30, armi a due mani | 5 |
| Mani nude | 1 |

Il costo non viene mai rifiutato: se la stamina non basta il colpo parte lo stesso e la differenza diventa un debito di stamina che ti rallenta. Esempio: a stamina 100 e costo 3, chi ha skill 0.0 colpisce 33 volte prima di riposare, chi ha 100.0 (costo 2) ne colpisce 50.

| Velocità | Giudizio | Esempi |
|----------|----------|--------|
| 50+ | Molto veloce | Pugnale, Kryss, Lancia corta |
| 42-49 | Veloce | Katana, Sciabola corta, Bastone ferrato |
| 33-41 | Media | Scimitarra, Ascia doppia, Mazza |
| 26-32 | Lenta | Spada lunga, Martello da guerra, Bardica |
| 25 o meno | Molto lenta | Alabarda, Arco, Balestra pesante |

> 💡 Un'arma lenta fa colpi grossi, un'arma veloce fa tanti colpi piccoli. Contro bersagli con molta armatura conviene il colpo grosso; per interrompere i caster conviene la velocità.

---

## ✋ Una mano o due mani

| Tipo | Vantaggi | Svantaggi |
|------|----------|-----------|
| **Una mano** | Puoi usare uno [scudo](/wiki/scudi) o tenere libera la mano per bere pozioni e lanciare incantesimi | Danno medio più basso |
| **Due mani** | Danno più alto, molte mosse speciali potenti | Niente scudo; Parrying funziona con penalità; per bere una pozione devi riporre l'arma |

> ⚠️ Per lanciare un incantesimo serve almeno una mano libera, oppure un'arma da mago (bacchetta, bastone). Vedi [Sistema di casting](/wiki/sistema-di-casting).

---

## 💪 Forza richiesta

Ogni arma ha un requisito di **Forza (STR)**. Se non lo soddisfi **non puoi equipaggiarla**. La Forza in eccesso non è sprecata: aumenta il danno di ogni colpo. Le razze forti come [Orco](/wiki/razza-orco) e [Nano](/wiki/razza-nano) possono usare le armi più pesanti fin da subito. Vedi [Statistiche](/wiki/statistiche).

---

## 🧱 Portata nel mondo a voxel

In Soulslands le distanze si misurano in **blocchi** (1 blocco = 1 metro circa).

| Tipo di arma | Portata |
|--------------|---------|
| Armi corte (pugnali, coltelli, bacchette) | 1 blocco |
| Armi normali a una o due mani | 1,5 blocchi |
| Armi in asta, lance, picche, falci | 2 blocchi (colpiscono anche oltre un nemico in prima fila) |
| Archi | 10-12 blocchi |
| Balestre | 7-8 blocchi |

Il bersaglio deve essere **in linea di vista**: non si può colpire attraverso un muro di pietra o di legno, mentre il vetro lascia vedere ma ferma i proiettili e le foglie possono deviare le frecce. Ciò che il tuo personaggio non vede appare in grigio e non può essere bersagliato.

---

## 🌀 Mosse speciali

Ogni arma ha **due mosse speciali** (primaria e secondaria), come nell'era Age of Shadows di Ultima Online. Si attivano consumando **stamina** (10 punti, 20 per le armi a due mani, ridotti dalla skill come un colpo) e non richiedono una skill minima. Se la stamina non basta la mossa parte lo stesso, ma il suo danno cala dei punti che mancano.

| Mossa | Effetto |
|-------|---------|
| **Armor Ignore** | Il colpo ignora l'armatura del bersaglio (danno leggermente ridotto) |
| **Bleed Attack** | Il bersaglio sanguina e perde vita per alcuni secondi |
| **Concussion Blow** | Danno extra in base alla differenza tra vita e mana del bersaglio |
| **Crushing Blow** | Colpo con +10 al danno |
| **Disarm** | Fa cadere l'arma dalle mani del bersaglio |
| **Dismount** | Disarciona il bersaglio dalla cavalcatura |
| **Double Strike** | Due colpi in rapida successione |
| **Infectious Strike** | Applica il veleno presente sull'arma |
| **Mortal Strike** | Il bersaglio non può essere curato per alcuni secondi |
| **Moving Shot** | Permette di tirare con l'arco mentre ci si muove |
| **Paralyzing Blow** | Paralizza il bersaglio per pochi secondi |
| **Shadow Strike** | Colpo che, se hai Stealth, ti nasconde subito dopo |
| **Whirlwind Attack** | Colpisce tutti i nemici adiacenti |

Le mosse di ogni arma sono indicate nelle pagine delle singole famiglie.

---

## 🛠️ Durabilità e riparazione

Ogni arma ha dei **punti durabilità** (es. 45/60). Ogni colpo andato a segno, e ogni parata, può consumarne uno. A 0 l'arma **si rompe e scompare**.

- Le armi in metallo si riparano con [Blacksmithy](/wiki/skill-blacksmithy) vicino a una forgia e un'incudine.
- Le armi in legno (bastoni, archi, balestre) si riparano con [Carpentry](/wiki/skill-carpentry) o [Bowcraft/Fletching](/wiki/skill-bowcraft-fletching).
- Ogni riparazione **riduce di 1 la durabilità massima**: un'arma riparata troppe volte diventa fragile.
- Una riparazione non fallisce mai (deciso da Aruto, 31/10/2026): servono comunque i materiali, e costa 1 punto di durabilità massima.
- Alcuni materiali, come [Steel](/wiki/minerale-steel) e [Shadow Iron](/wiki/minerale-shadow-iron), aumentano molto la durabilità.

| Durabilità tipica | Valore base |
|-------------------|-------------|
| Armi leggere (pugnali, coltelli) | 30-50 |
| Armi normali | 40-70 |
| Armi pesanti e in asta | 50-90 |
| Archi e balestre | 30-60 |

---

## ⭐ Qualità e materiali

Un'arma è uguale chiunque la forgi: non esiste la qualità eccezionale ([Qualità eccezionale](/wiki/qualita-eccezionale)). La durabilità è fissa per arma e materiale, senza tiri.

Il **metallo** usato cambia profondamente l'arma: alcuni minerali aggiungono danno elementale, altri durabilità. Le proprietà dei metalli sulle armature sono descritte in [Materiali delle armature — minerali](/wiki/materiali-armature-minerali), quelle sulle armi nelle pagine dei singoli [minerali](/wiki/minerali). Archi e bastoni dipendono invece dal tipo di [legno](/wiki/legni).

> 💡 Il [Nano](/wiki/razza-nano) ha +10.0 alla velocità di ogni skill di crafting: è il fabbro più rapido del mondo.

---

## ❓ FAQ

**D: Posso usare un'arma senza la skill relativa?**
R: Sì. Chiunque può usare qualsiasi arma da skill 0.0: se il colpo arriva a bersaglio colpisce sempre e fa lo stesso danno. La skill ti fa solo spendere meno stamina per colpo.

**D: Perché le asce usano Swordsmanship?**
R: È la tradizione di Ultima Online: spade, asce e armi in asta sono tutte "armi da taglio" e condividono la stessa skill. Il danno delle asce però non dipende da Lumberjacking, solo da arma, Forza e materiale.

**D: Le armi servono anche a rompere i blocchi?**
R: Solo in parte. Le asce tagliano i blocchi di legno e le mazze possono frantumare blocchi fragili, ma per lavorare davvero il mondo servono gli [attrezzi](/wiki/attrezzi): piccone, pala, accetta.

**D: Le armi si consumano anche colpendo i blocchi?**
R: Sì. Usare una spada per tagliare l'erba o un martello da guerra per rompere la pietra ne consuma la durabilità molto più in fretta che in combattimento.

---

*Vedi anche: [Spade](/wiki/armi-spade) | [Asce](/wiki/armi-asce) | [Mazze](/wiki/armi-mazze) | [Scherma](/wiki/armi-scherma) | [Armi in asta](/wiki/armi-armi-in-asta) | [Archi](/wiki/armi-archi) | [Armature](/wiki/armature) | [Scudi](/wiki/scudi)*

> ⚖️ I valori di durabilità, portata e requisiti delle mosse speciali sono indicativi e **da bilanciare** durante lo sviluppo.
