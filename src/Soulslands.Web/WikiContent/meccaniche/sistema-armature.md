---
title: Sistema armature
slug: sistema-armature
category: Meccaniche
visibility: Pubblica
---
# 🛡️ Sistema armature

*Guida completa al sistema delle armature di Soulslands*

---

## 📜 Panoramica

Il sistema delle armature di Soulslands, ereditato da Cursed Souls, si basa su **2 livelli di protezione** che si sommano, in punti fissi ([Regole deterministiche](/wiki/regole-deterministiche)):

1. **Resistenze base del tipo di armatura**: ogni tipo (cuoio, piastre, maglia...) ha valori fissi, con pro e contro.
2. **Bonus del materiale**: il minerale o la pelle usati nel crafting aggiungono resistenze specifiche.

Non esiste la qualità eccezionale: un pezzo è uguale chiunque lo crei, la differenza la fa il materiale ([Qualità eccezionale](/wiki/qualita-eccezionale)).

Le armature danno solo: **Armor Rating** (protezione fisica di base) e **5 resistenze**: Fisica, Fuoco, Freddo, Veleno, Energia. Le resistenze sono **punti di armatura** per tipo di danno, non percentuali.

### Come l'armatura riduce il danno

Ogni colpo ha una quantità di danno per tipo (fisico per le armi, elementale per i bonus del materiale e per le magie). Dal danno di ogni tipo si **sottraggono i punti di armatura di quel tipo**; il resto è il danno subito, e un colpo che colpisce toglie sempre almeno 1 PV. Nessun tiro, nessun intervallo.

> **Esempio:** un colpo da 22 di danno fisico contro un set con 10 punti di armatura fisica toglie 12 PV. Contro 22 punti ne toglie 1.

> 💡 Indossare un **set completo** (6 pezzi dello stesso materiale) attiva una **passiva bonus** unica per quel materiale! Vedi [Materiali: minerali](/wiki/materiali-armature-minerali) e [Materiali: cuoio](/wiki/materiali-armature-cuoio).

Le armature si forgiano con [Blacksmithy](/wiki/skill-blacksmithy) (metallo) e si cuciono con [Tailoring](/wiki/skill-tailoring) (cuoio). L'elenco dei pezzi è in [Armature](/wiki/armature).

---

## ⚔️ Tipi di armatura

Soulslands ha **8 tipi di armatura**, ognuno con un profilo unico.

| Tipo | Armor base | Fisica | Fuoco | Freddo | Veleno | Energia | Meditazione | Malus DEX set |
|------|-----------|--------|-------|--------|--------|---------|-------------|---------------|
| **Stoffa** | 3 | 1 | 1 | 1 | 1 | 1 | Piena | 0 |
| **Cuoio** | 13 | 2 | 4 | 3 | 3 | 3 | Piena | 0 |
| **Cuoio borchiato** | 22 | 2 | 4 | 3 | 3 | 4 | Dimezzata | 0 |
| **Osso** | 25 | 3 | 3 | 4 | 4 | 2 | Nessuna | -7 |
| **Anelli** | 30 | 3 | 1 | 3 | 5 | 3 | Nessuna | -11 |
| **Maglia** | 35 | 4 | 2 | 2 | 3 | 4 | Nessuna | -17 |
| **Piastre** | 45 | 5 | 1 | 2 | 3 | 2 | Nessuna | -33 |
| **Scaglie di drago** | 40 | 3 | 5 | 3 | 3 | 3 | Nessuna | — |

> Le resistenze base sono quelle del **busto**. Gli altri pezzi scalano in base allo slot (vedi sotto).

### Pro e contro

#### Stoffa — l'archetipo del mago
- **Pro**: meditazione piena, nessun malus DEX, peso minimo.
- **Contro**: protezione quasi nulla, resistenze minime.
- **Ideale per**: il mago puro che vuole la massima rigenerazione del mana.

#### Cuoio — l'archetipo dell'esploratore
- **Pro**: meditazione piena, buone resistenze elementali (fuoco forte), leggero.
- **Contro**: Armor Rating basso, fisica debole.
- **Ideale per**: ladri, esploratori, arcieri, chi ha bisogno di mobilità e di lanciare incantesimi.

#### Cuoio borchiato — l'archetipo ibrido
- **Pro**: buon compromesso tra protezione e mobilità.
- **Contro**: meditazione dimezzata, non eccelle in nulla.
- **Ideale per**: guerrieri-maghi, bardi.

#### Osso — l'archetipo del necromante
- **Pro**: freddo e veleno alti, aspetto unico.
- **Contro**: niente meditazione, energia debole, -7 DEX col set completo.
- **Ideale per**: necromanti, personaggi tribali. **Resistenze fisse**: non riceve bonus dal materiale.

#### Anelli — l'archetipo del ranger pesante
- **Pro**: ottima resistenza al veleno, buona fisica.
- **Contro**: fuoco molto debole, niente meditazione, -11 DEX.
- **Ideale per**: ranger pesanti, combattenti contro creature velenose.

#### Maglia — l'archetipo del soldato
- **Pro**: fisica ed energia buone, protezione solida.
- **Contro**: fuoco e freddo deboli, -17 DEX.
- **Ideale per**: soldati, combattenti in mischia bilanciati.

#### Piastre — l'archetipo del cavaliere
- **Pro**: massimo Armor Rating, fisica eccellente.
- **Contro**: resistenze elementali basse (il fuoco è il punto debole), -33 DEX.
- **Ideale per**: il cavaliere che vuole la massima protezione fisica.

#### Scaglie di drago — l'archetipo dell'élite
- **Pro**: fuoco eccezionale, buona protezione.
- **Contro**: difficili da ottenere, pesanti.
- **Vedi**: [Armatura in scaglie di drago](/wiki/armatura-scaglie-di-drago) per i 6 colori e i loro malus.

---

## 📐 Slot e scala

Ogni pezzo copre una parte del corpo diversa. I pezzi più grandi danno più protezione.

| Slot | Quota fissa del set | Descrizione |
|------|---------------------|-------------|
| **Busto** | 7/20 | Massima protezione: il pezzo più importante |
| **Gambe** | 11/50 | Alta protezione |
| **Braccia** | 3/20 | Media protezione |
| **Elmo** | 7/50 | Media protezione |
| **Guanti** | 7/100 | Minima protezione |
| **Gorgiera** | 7/100 | Minima protezione |

Le quote sono frazioni fisse del totale del set (insieme fanno 1). I punti interi di ogni pezzo sono scritti nel pacchetto dati; i valori della colonna "Fisica", "Fuoco"... della tabella dei tipi sono quelli del busto.

> 💡 Il busto protegge **5 volte** più dei guanti: investi sempre nei pezzi migliori per busto e gambe.

---

## 💪 Malus DEX delle armature pesanti

Le armature pesanti riducono la **Destrezza**. La DEX determina la stamina; nel mondo a voxel, meno DEX significa **meno stamina** per correre, saltare, nuotare e arrampicarsi (vedi [Statistiche](/wiki/statistiche)).

| Slot | Piastre | Maglia | Anelli | Osso | Borchiato | Cuoio | Stoffa |
|------|---------|--------|--------|------|-----------|-------|--------|
| **Busto** | -12 | -6 | -4 | -3 | 0 | 0 | 0 |
| **Gambe** | -10 | -5 | -3 | -2 | 0 | 0 | 0 |
| **Braccia** | -3 | -2 | -1 | -1 | 0 | 0 | 0 |
| **Elmo** | -3 | -2 | -1 | -1 | 0 | 0 | 0 |
| **Guanti** | -3 | -1 | -1 | 0 | 0 | 0 | 0 |
| **Gorgiera** | -2 | -1 | -1 | 0 | 0 | 0 | 0 |
| **TOTALE** | **-33** | **-17** | **-11** | **-7** | **0** | **0** | **0** |

### Eccezione: Mytheril
Il [Mytheril](/wiki/minerale-mytheril) è una lega leggerissima. Con un **set completo di Mytheril** (6 pezzi) il malus DEX del set si riduce di **16 punti fissi**: ad esempio un set di piastre in Mytheril dà -17 DEX invece di -33.

> ⚠️ La riduzione vale solo con il set completo. Un singolo pezzo di Mytheril ha il malus pieno del suo tipo.

---

## 🔒 Limite di resistenza

| Limite | Valore |
|--------|--------|
| **Singola resistenza massima** | 18 punti per tipo di danno |
| **Totale massimo** | nessuno |

Non c'è un tetto sul totale: sei slot e il limite per tipo bastano a tenere la protezione in equilibrio. Per arrivare a 18 punti serve un set completo di un materiale ottimo; scegli quale tipo di danno proteggere di più.

> 💡 18 punti è il limite per tipo: contro un colpo da 25 di danno resta sempre qualcosa che passa (almeno 7, e comunque mai meno di 1 PV).

---

## 🧮 Come si calcolano le resistenze

```
Resistenza finale = Base del tipo + Bonus del materiale (massimo 18 per tipo)
```

### Esempio: busto a piastre in Mytheril

```
BASE (busto a piastre):   Fisica 5, Fuoco 1, Freddo 2, Veleno 3, Energia 2
MATERIALE (Mytheril):     Fisica +5, Fuoco +3, Freddo +3, Veleno 0, Energia +3

TOTALE:                   Fisica 10, Fuoco 4, Freddo 5, Veleno 3, Energia 5
                          Armor Rating: 45
                          Malus DEX: -12 (il set completo di Mytheril toglie 16 punti di malus a tutto il set)
```

### Confronto: busto di cuoio Wyrm

```
BASE (busto di cuoio):    Fisica 2, Fuoco 4, Freddo 3, Veleno 3, Energia 3
MATERIALE (Wyrm):         Fisica +4, Fuoco +4, Freddo +3, Veleno 0, Energia 0

TOTALE:                   Fisica 6, Fuoco 8, Freddo 6, Veleno 3, Energia 3
                          Armor Rating: 13
                          Malus DEX: 0
                          + meditazione piena!
```

**Il compromesso**: le piastre danno +32 di Armor e +4 di fisica (base), ma -12 DEX e niente meditazione. Il cuoio dà meditazione piena, nessun malus e più resistenza al fuoco.

---

## 🧱 Armature e mondo a voxel

- Le armature pesanti sono **pesanti davvero**: contano nel peso trasportabile, quindi un minatore in piastre porterà a casa meno minerale.
- **Nuotare** con un'armatura pesante consuma molta più stamina: attraversare un fiume in piastre è un rischio, un oceano è quasi un suicidio.
- Le armature si **consumano** con i colpi e si riparano con la skill che le ha prodotte (vedi [Arms Lore](/wiki/skill-arms-lore)).
- Con il [full loot](/wiki/full-loot), chi muore perde l'armatura indossata: pensa bene a cosa portare nelle zone pericolose.

---

## 📚 Pagine correlate

- [Materiali: minerali](/wiki/materiali-armature-minerali): 21 minerali con bonus e passive di set.
- [Materiali: cuoio](/wiki/materiali-armature-cuoio): 15 pelli con bonus e passive di set.
- [Armatura in scaglie di drago](/wiki/armatura-scaglie-di-drago): 6 colori con bonus e malus.
- [Qualità eccezionale](/wiki/qualita-eccezionale): perché non esiste.
