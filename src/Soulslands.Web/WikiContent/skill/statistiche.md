---
title: Statistiche
slug: statistiche
category: Regole di gioco
visibility: Pubblica
---
# 💪 Statistiche

*Forza, Destrezza, Intelligenza: il corpo e la mente del tuo personaggio*

---

## 📜 Panoramica

Ogni personaggio di Soulslands ha tre **statistiche** (stat), come in Ultima Online:

| Stat | Nome | Determina |
|------|------|-----------|
| **STR** | Forza | Punti vita, peso trasportabile, danno in mischia |
| **DEX** | Destrezza | Stamina (e quindi quanti colpi puoi dare), velocità delle bende |
| **INT** | Intelligenza | Mana, rigenerazione del mana |

Le stat **crescono con l'uso delle skill**, fino ai cap della tua [razza](/wiki/razze) e allo **stat cap totale** del personaggio. Non si distribuiscono punti a mano: diventi forte scavando e combattendo, agile tirando con l'arco e muovendoti nell'ombra, intelligente studiando la magia.

---

## 🧮 Valori derivati

| Valore | Formula | Esempio (STR 100, DEX 80, INT 60) |
|--------|---------|-----------------------------------|
| ❤️ **Punti vita (HP)** | 70 + STR / 2 | 120 |
| ⚡ **Stamina** | = DEX | 80 |
| 🔷 **Mana** | = INT | 60 |
| 🎒 **Peso trasportabile** | 40 + 3,5 × STR (in pietre) | 390 |

I bonus da equipaggiamento, incantesimi e pozioni si **sommano** oltre il cap della razza e aumentano anche i valori derivati: un Orco con STR 160 e +15 STR da equipaggiamento arriva a 175 STR, cioè 157 HP.

---

## 💪 STR — Forza

- **Punti vita**: ogni 2 punti di STR danno 1 HP in più oltre i 70 di base.
- **Danno in mischia**: ogni 10 punti di STR aggiungono 1 al danno dell'arma (danno = arma + STR/10 + materiale).
- **Peso trasportabile**: in un mondo dove si scavano tonnellate di roccia e minerale, la STR decide quanto puoi portare. Oltre il limite di peso ti muovi lentamente, la stamina cala molto più in fretta e, se esageri, non riesci più a muoverti finché non lasci qualcosa.
- **Requisiti**: armi pesanti, armature a piastre e scudi grandi richiedono un minimo di STR (il minerale [Gold](/wiki/minerale-gold) riduce il requisito di 15 punti).
- **Skill che la allenano**: [Swordsmanship](/wiki/skill-swordsmanship), [Mace Fighting](/wiki/skill-mace-fighting), [Wrestling](/wiki/skill-wrestling), [Tactics](/wiki/skill-tactics), [Mining](/wiki/skill-mining), [Lumberjacking](/wiki/skill-lumberjacking), [Blacksmithy](/wiki/skill-blacksmithy), [Carpentry](/wiki/skill-carpentry), [Animal Taming](/wiki/skill-animal-taming), [Resisting Spells](/wiki/skill-resisting-spells), [Bushido](/wiki/skill-bushido).

## ⚡ DEX — Destrezza

- **Stamina**: uguale alla DEX. Nel mondo a voxel la stamina si consuma **combattendo, correndo, saltando, nuotando e arrampicandosi**. Senza stamina non attacchi e ti muovi a fatica.
- **Colpi**: ogni colpo, parata e attacco speciale costa stamina, quindi più DEX vuol dire più colpi prima di dover riposare.
- **Velocità delle bende**: con DEX alta una benda si applica più in fretta.
- **Malus delle armature**: le armature pesanti riducono la DEX (fino a -33 con le piastre complete, vedi [Sistema armature](/wiki/sistema-armature)).
- **Skill che la allenano**: [Archery](/wiki/skill-archery), [Fencing](/wiki/skill-fencing), [Parrying](/wiki/skill-parrying), [Healing](/wiki/skill-healing), [Hiding](/wiki/skill-hiding), [Stealth](/wiki/skill-stealth), [Stealing](/wiki/skill-stealing), [Tailoring](/wiki/skill-tailoring), [Tinkering](/wiki/skill-tinkering), [Fishing](/wiki/skill-fishing), [Musicianship](/wiki/skill-musicianship), [Throwing](/wiki/skill-throwing), [Ninjitsu](/wiki/skill-ninjitsu).

## 🧠 INT — Intelligenza

- **Mana**: uguale all'INT. Ogni incantesimo e ogni tecnica speciale costano mana.
- **Rigenerazione del mana**: l'INT di base la migliora.
- **Danno magico**: ogni 10 punti di INT aggiungono 1 al danno dell'incantesimo (danno = incantesimo + INT/10); l'INT decide anche quanti incantesimi puoi lanciare.
- **Skill che la allenano**: [Magery](/wiki/skill-magery), [Evaluating Intelligence](/wiki/skill-evaluating-intelligence), [Meditation](/wiki/skill-meditation), [Necromancy](/wiki/skill-necromancy), [Spirit Speak](/wiki/skill-spirit-speak), [Alchemy](/wiki/skill-alchemy), [Inscription](/wiki/skill-inscription), [Anatomy](/wiki/skill-anatomy), [Architecture](/wiki/skill-architecture), [Animal Lore](/wiki/skill-animal-lore), [Detect Hidden](/wiki/skill-detect-hidden), [Tracking](/wiki/skill-tracking), [Cooking](/wiki/skill-cooking).

---

## 🔄 Rigenerazione

| Risorsa | Si rigenera con | Cosa la migliora | Cosa la peggiora |
|---------|-----------------|------------------|------------------|
| ❤️ **HP** | Lentamente, nel tempo | Cibo e sazietà, [Healing](/wiki/skill-healing), [Spirit Speak](/wiki/skill-spirit-speak), pozioni, set di armatura con rigenerazione HP, passiva *Blood Feast* del [Vampiro](/wiki/razza-vampiro) | Fame, sete, veleno, sanguinamento |
| ⚡ **Stamina** | Più in fretta da fermi o camminando | [Focus](/wiki/skill-focus), cibo, pozioni di ristoro, set con rigenerazione stamina | Correre, saltare, nuotare, combattere, peso eccessivo |
| 🔷 **Mana** | Nel tempo, meglio da fermi | [Meditation](/wiki/skill-meditation), [Focus](/wiki/skill-focus), INT alta, passiva *Elven Meditation* dell'[Elfo](/wiki/razza-elfo), set con rigenerazione mana | Armature pesanti (bloccano la meditazione), combattere |

> 💡 Un personaggio affamato o assetato rigenera male: porta sempre del cibo (vedi [Cooking](/wiki/skill-cooking)). Le pozioni sono istantanee ma accumulano [tossicità](/wiki/tossicita-pozioni).

---

## 📊 Stat cap per razza

Ogni razza ha un **cap individuale** per ciascuna stat: anche se hai punti liberi nello stat cap totale, la stat base non supera il cap della tua razza.

| Razza | STR cap | DEX cap | INT cap | HP max | Stamina max | Mana max | Peso max |
|-------|---------|---------|---------|--------|-------------|----------|----------|
| 🧑 [Umano](/wiki/razza-umano) | 115 | 115 | 115 | 127 | 115 | 115 | 442 |
| 🧝 [Elfo](/wiki/razza-elfo) | 85 | 140 | 130 | 112 | 140 | 130 | 337 |
| 🗿 [Gargoyle](/wiki/razza-gargoyle) | 135 | 105 | 95 | 137 | 105 | 95 | 512 |
| 🌙 [Elfo Oscuro](/wiki/razza-elfo-oscuro) | 95 | 70 | 160 | 117 | 70 | 160 | 372 |
| 💪 [Orco](/wiki/razza-orco) | 160 | 95 | 70 | 150 | 95 | 70 | 600 |
| 🧛 [Vampiro](/wiki/razza-vampiro) | 105 | 135 | 105 | 122 | 135 | 105 | 407 |
| ⛏️ [Nano](/wiki/razza-nano) | 145 | 85 | 95 | 142 | 85 | 95 | 547 |
| 😈 [Demone](/wiki/razza-demone) | 125 | 70 | 140 | 132 | 70 | 140 | 477 |

> I valori massimi sono calcolati con la singola stat al cap e senza bonus di equipaggiamento. La somma dei tre cap razziali supera sempre lo stat cap totale: **devi scegliere** quali stat portare al massimo.

### Esempi di distribuzione (stat cap 285)

| Razza e ruolo | STR | DEX | INT | HP | Stamina | Mana |
|---------------|-----|-----|-----|----|---------|------|
| Umano guerriero bilanciato | 115 | 115 | 55 | 127 | 115 | 55 |
| Elfo arciere veloce | 85 | 140 | 60 | 112 | 140 | 60 |
| Elfo Oscuro mago puro | 55 | 70 | 160 | 97 | 70 | 160 |
| Orco berserker | 160 | 95 | 30 | 150 | 95 | 30 |
| Vampiro assassino | 60 | 135 | 90 | 100 | 135 | 90 |
| Nano artigiano corazzato | 145 | 45 | 95 | 142 | 45 | 95 |
| Demone cavaliere oscuro | 125 | 20 | 140 | 132 | 20 | 140 |

---

## 📈 Stat cap totale

Lo **stat cap totale** è il limite della somma STR + DEX + INT (valori base, senza equipaggiamento).

| Fase | Stat cap |
|------|----------|
| Personaggio nuovo | **255** |
| Massimo raggiungibile | **285** |

Si sale da 255 a 285 con le imprese descritte in [Progressione dello stat cap](/wiki/progressione-statcap): un premio di anzianità e gli artefatti delle creature leggendarie (Ogre Lord, serpente marino, Lich Lord, wyrm antico, balron e infine l'Harrower). Ogni passo vale una sola volta per personaggio e l'ordine è libero.

---

## 🌱 Come crescono le stat

Le stat salgono **usando le skill**:
- Ogni skill ha una **stat primaria** e, spesso, una **secondaria** (indicate in ogni pagina skill).
- Ogni **uso utile** di una skill aggiunge punti di progresso alle sue stat, senza alcun tiro: **75** alla primaria e **25** alla secondaria. Una stat sale di **1 punto** quando il suo progresso raggiunge 2000 (una stat primaria sale ogni 27 usi circa).
- Restano il breve tempo di attesa tra un guadagno e l'altro e i blocchi Su, Giù e Bloccata.
- Una stat non sale oltre il **cap della razza**, e la somma non supera lo **stat cap totale**.

### Blocco delle stat
Come per le skill, ogni stat può essere impostata su:
- ⬆️ **Su**: può salire.
- ⬇️ **Giù**: può scendere per fare spazio alle altre.
- 🔒 **Bloccata**: resta ferma.

Quando sei allo stat cap totale e una stat su "Su" sale, una stat su "Giù" scende di 1. Così puoi, per esempio, trasformare un minatore forte in un mago bloccando l'INT su "Su" e la STR su "Giù".

### Cambio di razza
Se cambi razza (da fantasma, tramite il rituale descritto nella pagina [Razze](/wiki/razze)) le stat base tornano ai valori iniziali della nuova razza e vanno riallenate; lo **stat cap totale** e i bonus della progressione invece **restano**.

---

## ❓ FAQ

**D: Posso superare il cap della razza con l'equipaggiamento?**
R: Sì. Il cap limita solo la stat base; equipaggiamento, incantesimi e pozioni si sommano oltre.

**D: Conviene portare tutte le stat al massimo?**
R: Non è possibile: la somma dei cap razziali supera sempre lo stat cap totale. Scegli in base al tuo stile.

**D: Le passive razziali contano la stat totale o quella base?**
R: Quella totale. Per esempio l'[Orco](/wiki/razza-orco) attiva *Brute Force* con STR totale ≥ 170 e l'[Elfo Oscuro](/wiki/razza-elfo-oscuro) attiva *Arcane Mastery* con INT totale ≥ 170: in entrambi i casi servono almeno +10 dall'equipaggiamento.

**D: Perché non riesco a sollevare il minerale che ho scavato?**
R: Hai superato il peso trasportabile. Lascia qualcosa in un contenitore, usa un animale da soma o aumenta la STR.

---

*Vedi anche: [Skill](/wiki/skill) | [Razze](/wiki/razze) | [Progressione dello stat cap](/wiki/progressione-statcap) | [Skill di combattimento](/wiki/skill-combattimento)*
