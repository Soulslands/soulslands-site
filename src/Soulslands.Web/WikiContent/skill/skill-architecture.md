---
title: Architecture
slug: skill-architecture
category: Skill / Crafting
visibility: Pubblica
---
# 🏗️ Architecture (Architettura)

*Muro dopo muro, la tua gilda diventa una città*

---

| Proprietà | Valore |
|-----------|--------|
| **Categoria** | Skill di Crafting |
| **Skill cap** | 100.0 |
| **Stat primaria** | Intelligenza (INT) |
| **Stat secondaria** | Forza (STR) |
| **Difficoltà di allenamento** | Media-Alta |
| **Skill di classe per** | Nessuna classe: sale liberamente fino a 100.0 |
| **Serve** | Banco da costruzione e strumento da costruzione |

---

## 📜 Cosa fa

**Architecture** è una skill nata su Cursed Souls e portata in Soulslands: permette di costruire **strutture permanenti** e resistenti, ed è il cuore del [Sistema costruzioni](/wiki/sistema-costruzioni) nei territori di gilda.

### Benefici principali
- **Costruzione di strutture**: muri, pavimenti, tetti, scale, mobili fissi, porte, cancelli, luci e meccanismi.
- **Sempre a buon fine**: con i materiali e il banco da costruzione la struttura riesce sempre; la skill accorcia il tempo di lavoro (la metà a 100.0).
- **Nessuna qualità eccezionale**: una struttura è uguale chiunque la costruisca, e porta il nome del costruttore.
- **Allenamento**: ogni uso utile dello strumento da costruzione conta per la skill (vedi sotto).

### Tutte le strutture da 0.0
Nessuna struttura richiede un livello minimo di Architecture (**Deciso da Aruto, 27/10/2026**): puoi costruire tutto da skill 0.0. La tabella dice fino a che livello ogni gruppo di strutture fa ancora salire la skill.

| Gruppo di strutture | Insegna fino a Architecture |
|---------------------|----------------------------|
| Pavimenti semplici, rocce decorative | 30.0 |
| Muri in legno, staccionate, luci | 40.0 |
| Tetti, muri in pietra, scale, mobili | 50.0 |
| Porte in metallo, cancelli | 60.0 |
| Tutte le altre strutture | 100.0 |

### Durabilità
Ogni struttura ha punti struttura fissi: 100 di base, più il bonus del [legno](/wiki/legni) o del materiale usato. Non dipendono da chi la costruisce.

### Materiali e skill collegate
Ogni categoria di strutture usa materiali prodotti da un'altra skill:

| Categoria | Skill che produce il materiale | Materiale |
|-----------|-----------------|-----------|
| **Strutture in legno** | [Carpentry](/wiki/skill-carpentry) | Assi |
| **Strutture in pietra** | [Mining](/wiki/skill-mining) | Pietra |
| **Porte e cancelli** | [Blacksmithy](/wiki/skill-blacksmithy) | Lingotti di ferro |
| **Luci e meccanismi** | [Tinkering](/wiki/skill-tinkering) | Lingotti di ferro |

> 💡 Nessuna di queste skill è un requisito: servono i materiali, non il livello. Chi non ha le skill può comprarli.

## 🧱 Nel mondo a voxel

In Soulslands chiunque può scavare e piazzare blocchi semplici, come in ogni mondo a voxel. **Architecture** è ciò che distingue una capanna da una fortezza:
- Le strutture costruite con Architecture sono **blocchi rinforzati**: hanno punti struttura, resistono agli attacchi e non si possono semplicemente scavare via con un piccone.
- Permette di realizzare **elementi complessi** fatti di più blocchi (portoni a due ante, cancelli levatoi, tetti spioventi, scale a chiocciola) piazzandoli in un colpo solo.
- Nei territori di gilda (vedi [Pietra del territorio di gilda](/wiki/pietra-territorio-gilda)) solo chi ha il permesso di costruzione dal capogilda può piazzare, spostare, ruotare e bloccare le strutture; **chiunque** però può attaccarle e distruggerle in guerra.

### Attrezzi necessari

| Attrezzo | Uso | Durabilità | Note |
|----------|-----|-----------|------|
| **Banco da costruzione** | Realizzare nuove strutture | ~500 utilizzi | Va piazzato a terra nel territorio, non si usa a cavallo. Si costruisce con Tinkering o Carpentry |
| **Strumento da costruzione** | Piazzare, spostare, ruotare, bloccare strutture | ~200 utilizzi | Va tenuto nell'inventario. Si costruisce con Tinkering |

## 📈 Come sale

Architecture sale **usandola**, fino a un massimo di **100.0**. Ogni **uso utile** conta verso il prossimo 0.1, senza alcun tiro: servono 1 + t²/18.000 usi, con t il tuo valore in decimi (1 uso a 0.0, 14 a 50.0, 56 a 99.9), circa 19.000 usi in tutto e circa **40 ore** di azione per arrivare a 100.0; un uso conta al massimo una volta ogni 7,5 secondi. Le azioni troppo facili per il tuo livello non insegnano nulla. La skill deve essere impostata su **Su** (freccia in alto); se hai raggiunto il cap totale, perché salga deve scenderne un'altra impostata su **Giù**. Regole generali nella [panoramica delle skill](/wiki/skill).

Architecture sale in **due modi**: realizzando strutture al banco da costruzione (la skill sale solo se la ricetta insegna ancora al tuo livello) e usando lo **strumento da costruzione** per piazzare, spostare, ruotare o bloccare una struttura. Lo strumento è il modo più economico di allenarla: non consuma risorse, solo la sua durabilità.

| Livello | Come allenarla |
|---------|----------------|
| **0-25** | Pavimenti in legno, rocce decorative. |
| **25-40** | Muri in legno, staccionate. |
| **40-55** | Tetti, muri in pietra, scale. |
| **55-70** | Mobili, porte in metallo. |
| **70-100** | Cancelli e strutture avanzate. |

## 💪 Statistiche collegate

Ogni uso utile di Architecture aggiunge 75 punti di progresso a **Intelligenza (INT)** e 25 a **Forza (STR)**; una statistica sale di 1 quando raggiunge 2000 punti (la principale ogni 27 usi), sempre entro i cap della tua razza (vedi [Statistiche](/wiki/statistiche)).

- **INT**: più mana (Mana = INT) e una rigenerazione del mana migliore.
- **STR**: più punti vita (HP = 70 + STR/2), più peso trasportabile e più danno in mischia.

## 🤝 Skill sinergiche

| Skill | Perché |
|-------|--------|
| [Carpentry](/wiki/skill-carpentry) | Strutture in legno (consigliata 80.0) |
| [Mining](/wiki/skill-mining) | Strutture in pietra (consigliata 80.0) |
| [Blacksmithy](/wiki/skill-blacksmithy) | Porte in metallo (consigliata 60.0) |
| [Tinkering](/wiki/skill-tinkering) | Luci e meccanismi (consigliata 60.0) |
| [Lumberjacking](/wiki/skill-lumberjacking) | Raccolta del legno (consigliata 80.0) |

## 🎭 Classi che la usano

- [Minatore Combattente](/wiki/classe-minatore-combattente): con Mining e Blacksmithy già alte è un costruttore naturale di fortificazioni.

## 💡 Consigli

- Inizia dai pavimenti: sono i più facili e costano poche risorse.
- Porta materiali a sufficienza: la struttura riesce sempre, ma consuma tutti i materiali della ricetta.
- Piazza e riprendi la stessa struttura con lo strumento da costruzione per allenarti senza sprecare risorse.
- Proteggi le costruzioni con le guardie del territorio e le barriere magiche della gilda.
- Costruisci vicino alla pietra del territorio: le strutture al centro sono più difficili da raggiungere per i nemici.
- Pietra e metallo durano più del legno: investi in materiali migliori.
- Template consigliato: Architecture 100, Carpentry 80, Mining 80, Lumberjacking 80, Blacksmithy 60, Tinkering 60.

---

*Vedi anche: [Skill](/wiki/skill) | [Statistiche](/wiki/statistiche) | [Classi](/wiki/classi)*
