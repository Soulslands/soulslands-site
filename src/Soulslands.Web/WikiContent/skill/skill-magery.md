---
title: Magery
slug: skill-magery
category: Skill / Magia
visibility: Pubblica
---
# 🔮 Magery (Magia arcana)

*Otto cerchi di potere tra le tue mani*

---

| Proprietà | Valore |
|-----------|--------|
| **Categoria** | Skill di Magia |
| **Skill cap** | 100.0 |
| **Stat primaria** | Intelligenza (INT) |
| **Stat secondaria** | Forza (STR) |
| **Difficoltà di allenamento** | Media-Alta |
| **Skill di classe per** | [Arcanista](/wiki/classe-arcanista), [Necromante](/wiki/classe-necromante), [Sciamano](/wiki/classe-sciamano) |
| **Serve** | Libro degli incantesimi e reagenti |

---

## 📜 Cosa fa

**Magery** è la magia arcana classica: otto **cerchi** di incantesimi, scritti in un libro e lanciati consumando **mana** e **reagenti**. Più è alta, meno mana spendi per ogni incantesimo.

| Cerchio | Esempi | Costo in mana | Potenza |
|---------|--------|---------------|---------|
| 1-3 | Magic Arrow, Heal, Fireball | Basso | Debole |
| 4-5 | Lightning, Greater Heal, Paralyze | Medio | Medio |
| 6 | Energy Bolt, Explosion | Alto | Forte |
| 7 | Flamestrike, Chain Lightning | Molto alto | Molto forte |
| 8 | Resurrection, Earthquake | Altissimo | Devastante |

### Nessun incantesimo fallisce

Un incantesimo con il mana, i reagenti e un bersaglio valido riesce sempre, a qualsiasi livello di Magery: non c'è un tiro di fallimento e nessun cerchio richiede una Magery minima. Si può lanciare un incantesimo dell'ottavo cerchio anche a 0.0.

Magery fa una cosa sola, come le skill di combattimento: **abbassa il mana** che un incantesimo costa. Il costo è pieno a 0.0 e scende al 70% a 100.0 (85% a 50.0). Non aggiunge danno né cura, e non rende il lancio più veloce.

- **Danno di un incantesimo** = valore dell'incantesimo + INT/10 di chi lancia, meno l'armatura del bersaglio per quel tipo di danno. Lo stesso per le cure.
- Il bonus del Grand Master (100.0 conta come 120.0) vale solo nelle sfide tra giocatori, non negli incantesimi.

Il lancio degli incantesimi segue il [Sistema di casting](/wiki/sistema-di-casting): prima scegli il bersaglio, poi il personaggio si concentra e puoi muoverti mentre lanci.

## 🧱 Nel mondo a voxel

Nel mondo a voxel la magia rispetta il terreno: ogni incantesimo mirato richiede **linea di vista** sul bersaglio, e i blocchi solidi la interrompono. Alcuni incantesimi interagiscono con il mondo:
- **Teletrasporto e Recall** ti spostano su blocchi liberi e calpestabili; non puoi comparire dentro un muro.
- I **campi** (Wall of Stone, Fire Field, Energy Field) si appoggiano al terreno e sono perfetti per chiudere un corridoio scavato.
- **Earthquake** scuote l'area attorno al mago colpendo le creature, ma non distrugge i blocchi delle costruzioni protette.
- **Nightsight** è preziosissimo nelle [grotte e nel sottosuolo](/wiki/grotte-e-sottosuolo), dove la luce del sole non arriva.

I reagenti si raccolgono nei biomi (vedi [Biomi](/wiki/biomi)) o si comprano dai mercanti.

## 📈 Come sale

Magery sale **usandola**, fino a un massimo di **100.0**. Ogni **uso utile** conta verso il prossimo 0.1, senza alcun tiro: servono 1 + t²/18.000 usi, con t il tuo valore in decimi (1 uso a 0.0, 14 a 50.0, 56 a 99.9), circa 19.000 usi in tutto e circa **40 ore** di azione per arrivare a 100.0; un uso conta al massimo una volta ogni 7,5 secondi. Le azioni troppo facili per il tuo livello non insegnano nulla. La skill deve essere impostata su **Su** (freccia in alto); se hai raggiunto il cap totale, perché salga deve scenderne un'altra impostata su **Giù**. Regole generali nella [panoramica delle skill](/wiki/skill).

| Livello | Come allenarla |
|---------|----------------|
| **0-30** | Lezioni da un mago NPC, poi incantesimi del 1° e 2° cerchio. |
| **30-50** | Incantesimi del 3° e 4° cerchio (ad esempio Fireball, Greater Heal). |
| **50-70** | Incantesimi del 5° e 6° cerchio. |
| **70-90** | Incantesimi del 7° cerchio, come Flamestrike. |
| **90-100** | Incantesimi dell'8° cerchio, come gli elementali o Earthquake. |

> ⚠️ È una **skill di classe**: oltre 60.0 e 80.0 sale solo se anche le altre due skill della classe hanno raggiunto la stessa soglia (sistema a tier, vedi [Skill](/wiki/skill)).

## 💪 Statistiche collegate

Ogni uso utile di Magery aggiunge 75 punti di progresso a **Intelligenza (INT)** e 25 a **Forza (STR)**; una statistica sale di 1 quando raggiunge 2000 punti (la principale ogni 27 usi), sempre entro i cap della tua razza (vedi [Statistiche](/wiki/statistiche)).

- **INT**: più mana (Mana = INT) e una rigenerazione del mana migliore.
- **STR**: più punti vita (HP = 70 + STR/2), più peso trasportabile e più danno in mischia.

## 🤝 Skill sinergiche

| Skill | Perché |
|-------|--------|
| [Evaluating Intelligence](/wiki/skill-evaluating-intelligence) | Skill di studio degli incantesimi; non aggiunge danno |
| [Meditation](/wiki/skill-meditation) | Recuperi il mana più in fretta |
| [Resisting Spells](/wiki/skill-resisting-spells) | Resisti agli incantesimi nemici |
| [Inscription](/wiki/skill-inscription) | Scrivi pergamene e potenzi la magia |
| [Wrestling](/wiki/skill-wrestling) | Difesa in mischia senza armi |

## 🎭 Classi che la usano

- [Arcanista](/wiki/classe-arcanista): **skill di classe**, insieme a [Evaluating Intelligence](/wiki/skill-evaluating-intelligence) e [Meditation](/wiki/skill-meditation).
- [Necromante](/wiki/classe-necromante): **skill di classe**, insieme a [Necromancy](/wiki/skill-necromancy) e [Spirit Speak](/wiki/skill-spirit-speak).
- [Sciamano](/wiki/classe-sciamano): **skill di classe**, insieme a [Spirit Speak](/wiki/skill-spirit-speak) e [Animal Taming](/wiki/skill-animal-taming).

## 💡 Consigli

- L'[Elfo Oscuro](/wiki/razza-elfo-oscuro) (INT cap 160, Faster Casting +2) e il [Demone](/wiki/razza-demone) (INT cap 140) sono le razze ideali per la magia.
- Tieni sempre una scorta di reagenti: senza reagenti il libro non serve a nulla.

---

*Vedi anche: [Skill](/wiki/skill) | [Statistiche](/wiki/statistiche) | [Classi](/wiki/classi)*
