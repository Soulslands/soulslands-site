---
title: Razze
slug: razze
category: Razze
visibility: Pubblica
---
# ⚔️ Razze di Soulslands

*Scegli la tua stirpe e scopri il tuo destino*

---

## 📋 Indice

- Panoramica
- Sistema delle statistiche
- Passive razziali
- Tabella completa delle razze
- Le razze nel mondo a voxel
- Build di esempio
- Come cambiare razza
- FAQ

---

## 📜 Panoramica

Soulslands eredita da Cursed Souls **8 razze giocabili**: [Umano](/wiki/razza-umano), [Elfo](/wiki/razza-elfo), [Gargoyle](/wiki/razza-gargoyle), [Elfo Oscuro](/wiki/razza-elfo-oscuro), [Orco](/wiki/razza-orco), [Vampiro](/wiki/razza-vampiro), [Nano](/wiki/razza-nano) e [Demone](/wiki/razza-demone). Ognuna ha statistiche e **cap individuali** diversi e un'**abilità passiva unica** che si attiva in base a condizioni specifiche.

La scelta della razza influenza profondamente il tuo stile di gioco:

- le statistiche iniziali e i cap determinano i tuoi limiti;
- la passiva razziale ti dà un vantaggio unico se costruisci la build giusta;
- ogni razza ha un **punto debole** che devi compensare con l'equipaggiamento;
- nel mondo a voxel ogni razza ha anche dei **tratti di esplorazione** (visione al buio, nuoto, scavo, biomi d'origine) che rendono diversa la vita in superficie, nelle grotte e in mare.

> 💡 Il personaggio appartiene al mondo: razza, statistiche e progressi sono salvati sul server insieme a tutto il resto (vedi [Persistenza del mondo](/wiki/persistenza-del-mondo)).

---

## 📊 Sistema delle statistiche

| Parametro | Valore |
|-----------|--------|
| **Stat Cap totale** | 255 alla creazione, fino a **285** con la [Progressione StatCap](/wiki/progressione-statcap) (STR + DEX + INT) |
| **Formula HP** | 70 + (STR / 2) |
| **Formula Mana** | = INT |
| **Formula Stamina** | = DEX |
| **Skill Cap** | 700 totali, **750** per gli Umani; 100.0 per singola skill per tutti |

Ogni razza ha **cap individuali per statistica**: non puoi superare il cap della tua razza anche se hai ancora punti disponibili nello Stat Cap totale. Per i dettagli sulle statistiche vedi [Statistiche](/wiki/statistiche); per le skill vedi [Skill](/wiki/skill).

> 💡 I valori "massimi" indicati nelle pagine delle razze sono calcolati con lo Stat Cap pieno a 285 e la statistica al suo cap razziale.

---

## 🛡️ Passive razziali

| Razza | Passiva | Condizione | Effetto |
|-------|---------|-----------|---------|
| 🧑 **Umano** | *Versatility* | Sempre attiva | Skill cap totale **750** invece di 700 |
| 🧝 **Elfo** | *Elven Meditation* | Mana < 30% | Mana Regeneration +3 |
| 🗿 **Gargoyle** | *Stone Skin* | HP < 40% | Resistenza fisica +4 punti |
| 🌙 **Elfo Oscuro** | *Arcane Mastery* | INT ≥ 170 | Faster Casting +2 |
| 💪 **Orco** | *Brute Force* | STR ≥ 170 | Immune a Paralyze |
| 💪 **Orco** | *Blood Rage* | HP < 30% | Danno +3 |
| 🧛 **Vampiro** | *Blood Feast* | Smembrare un cadavere umanoide | HP Regen +10 per 5 secondi |
| ⛏️ **Nano** | *Stoneform* | Stai fermo | +3 punti a ogni resistenza |
| ⛏️ **Nano** | *Mastersmith* | Sempre attiva | +10.0 alla velocità di ogni skill di crafting |
| 😈 **Demone** | *Infernal Presence* | Nome rosso (Murderer) | I mostri non ti attaccano |

### Dettagli delle passive

**🧛 Vampiro — Blood Feast**
- Devi smembrare un cadavere **umanoide** con un coltello (vedi [Scuoiare e smembrare](/wiki/scuoiare-e-smembrare))
- Puoi mangiare solo se **Fame (Hunger) < 20** (recuperi fame)
- Puoi bere sangue solo se **Sete (Thirst) < 20** (recuperi sete)
- Se sei completamente sazio (20/20) non puoi nutrirti
- Attiva un boost di **HP Regeneration +10** per **5 secondi**

**😈 Demone — Infernal Presence**
- Funziona solo se sei **Murderer** (nome rosso, vedi [Player killer e redenzione](/wiki/player-killer-e-redenzione))
- I mostri ti ignorano completamente: non ti attaccano
- Se **sei tu ad attaccare un mostro**, quello reagisce e ti attacca normalmente
- Perfetto per muoversi in dungeon e grotte pericolose senza combattere

**🌙 Elfo Oscuro — Arcane Mastery**
- Conta l'INT totale (base + equipaggiamento + buff)
- Con INT cap a 160 servono almeno **+10 INT da equipaggiamento** per attivare la passiva
- Il bonus **Faster Casting +2** si somma a quello dell'equipaggiamento (cap FC = 4, vedi [Sistema di casting](/wiki/sistema-di-casting))

**💪 Orco — Brute Force**
- Conta la STR totale (base + equipaggiamento + buff)
- Con STR cap a 160 servono almeno **+10 STR da equipaggiamento** per attivare la passiva
- Immune a **Paralyze** (spell) e **Paralyze Field**: non puoi essere fermato

---

## 📊 Tabella completa delle razze

| Razza | STR cap | DEX cap | INT cap | HP max | Mana max | Stam max | Passiva |
|-------|---------|---------|---------|--------|----------|----------|---------|
| 🧑 [Umano](/wiki/razza-umano) | 115 | 115 | 115 | 127 | 115 | 115 | Skill cap totale +50 |
| 🧝 [Elfo](/wiki/razza-elfo) | 85 | 140 | 130 | 112 | 130 | 140 | Mana regen a mana basso |
| 🗿 [Gargoyle](/wiki/razza-gargoyle) | 135 | 105 | 95 | 137 | 95 | 105 | Resistenza quando ferito |
| 🌙 [Elfo Oscuro](/wiki/razza-elfo-oscuro) | 95 | 70 | 160 | 117 | 160 | 70 | Faster Casting +2 |
| 💪 [Orco](/wiki/razza-orco) | 160 | 95 | 70 | 150 | 70 | 95 | Anti-Paralyze |
| 🧛 [Vampiro](/wiki/razza-vampiro) | 105 | 135 | 105 | 122 | 105 | 135 | HP regen dai cadaveri |
| ⛏️ [Nano](/wiki/razza-nano) | 145 | 85 | 95 | 142 | 95 | 85 | +10.0 velocità di crafting |
| 😈 [Demone](/wiki/razza-demone) | 125 | 70 | 140 | 132 | 140 | 70 | I mostri non attaccano |

> 💡 HP calcolati con STR al massimo. Formula: HP = 70 + (STR cap / 2), arrotondato per difetto.

---

## 🌍 Le razze nel mondo a voxel

Soulslands è un mondo a blocchi generato proceduralmente, con superficie, oceani e un sottosuolo profondo da scavare. Ogni razza ci si muove in modo un po' diverso. Questi tratti **non modificano** statistiche e passive descritte sopra: riguardano solo esplorazione e vita quotidiana.

| Razza | Visione al buio | Nuoto | Scavo e carico | Biomi d'origine |
|-------|-----------------|-------|----------------|-----------------|
| 🧑 Umano | Normale (serve una fonte di luce) | Standard | Standard | Pianure temperate, praterie, coste |
| 🧝 Elfo | Crepuscolare (vede bene in penombra e di notte all'aperto) | Agile e resistente | Standard | Foreste antiche e boschi |
| 🗿 Gargoyle | Normale | Lento (corpo di pietra) | Standard, buon carico | Altopiani rocciosi, canyon e rovine |
| 🌙 Elfo Oscuro | Scurovisione (vede al buio nelle grotte) | Breve (poca stamina) | Standard | Caverne profonde e foreste oscure |
| 💪 Orco | Crepuscolare | Robusto ma lento | Carico enorme | Steppe, paludi e terre aride |
| 🧛 Vampiro | Visione notturna completa | Standard | Standard | Paludi nebbiose, foreste oscure, rovine |
| ⛏️ Nano | Scurovisione a corto raggio | Pesante (si stanca presto) | Scavo di pietra e minerali più rapido, grande carico | Montagne e colline |
| 😈 Demone | Scurovisione | Breve (poca stamina) | Standard | Terre vulcaniche e desolate |

Ricorda che in Soulslands ciò che il personaggio non vede viene mostrato in grigio: le razze con scurovisione vedono i blocchi intorno a sé anche nelle [grotte](/wiki/grotte-e-sottosuolo) senza torcia, mentre le altre devono portare luce. Per i biomi vedi [Biomi](/wiki/biomi); per il mare vedi [Oceani](/wiki/oceani).

---

## 🎮 Build di esempio

### 🧑 Umano — Guerriero bilanciato
| STR | DEX | INT | HP | Mana | Stam |
|-----|-----|-----|----|------|------|
| 115 | 115 | 55 | 127 | 55 | 115 |

*Versatile. I 50 punti skill in più permettono di diversificare le skill.*

### 🧝 Elfo — Arciere veloce
| STR | DEX | INT | HP | Mana | Stam |
|-----|-----|-----|----|------|------|
| 85 | 140 | 60 | 112 | 60 | 140 |

*Massima stamina per correre e attaccare. Fragile ma sfuggente.*

### 🌙 Elfo Oscuro — Mago puro
| STR | DEX | INT | HP | Mana | Stam |
|-----|-----|-----|----|------|------|
| 55 | 70 | 160 | 97 | 160 | 70 |

*Faster Casting attivo con 160 + equipaggiamento INT. HP bassissimi: glass cannon.*

### 💪 Orco — Berserker
| STR | DEX | INT | HP | Mana | Stam |
|-----|-----|-----|----|------|------|
| 160 | 95 | 30 | 150 | 30 | 95 |

*Anti-Paralyze attivo (con +10 STR da equipaggiamento). Zero magia. Puro tank in mischia.*

### 🧛 Vampiro — Assassino
| STR | DEX | INT | HP | Mana | Stam |
|-----|-----|-----|----|------|------|
| 60 | 135 | 90 | 100 | 90 | 135 |

*Velocissimo. Si rigenera nutrendosi dei cadaveri. HP bassi.*

### ⛏️ Nano — Tank artigiano
| STR | DEX | INT | HP | Mana | Stam |
|-----|-----|-----|----|------|------|
| 145 | 45 | 95 | 142 | 95 | 45 |

*HP altissimi. Forgia più in fretta (Mastersmith). Lento.*

### 😈 Demone — Cavaliere oscuro
| STR | DEX | INT | HP | Mana | Stam |
|-----|-----|-----|----|------|------|
| 125 | 20 | 140 | 132 | 140 | 20 |

*Caster con buoni HP. Da Murderer i mostri lo ignorano.*

---

## 🔄 Come cambiare razza

Ogni personaggio **inizia come Umano**, in una città di partenza, e non c'è nessuna schermata per scegliere la razza (**deciso da Aruto, 26/10/2026**). Per cambiare razza, **sempre, anche la prima volta**, devi usare la **Pedana delle Razze** (il vecchio *Races Pad*), una struttura presente nel mondo:

1. Il tuo personaggio deve essere un **fantasma** (morto, vedi [Morte e fantasmi](/wiki/morte-e-fantasmi))
2. Cammina sopra la **Pedana delle Razze**
3. Dopo circa **10 secondi** di trasformazione la nuova razza viene applicata
4. Le tue statistiche vengono **resettate** ai valori iniziali della nuova razza
5. Il tuo **Stat Cap resta invariato**: i bonus ottenuti con la [Progressione StatCap](/wiki/progressione-statcap) non vengono persi

> ⚠️ **Attenzione**: cambiare razza resetta le statistiche base! Dovrai riallenarle. Lo Stat Cap e i bonus di progressione invece restano.

**Il cambio di razza non si paga mai**: né oro né oggetti né acquisti sul sito (**deciso da Aruto, 26/10/2026**).

### 🗺️ Dove sono le Pedane

**Deciso da Aruto (26/10/2026):** ogni razza ha la propria Pedana dentro una **struttura rara tutta sua**, e si trova esplorando il mondo. Per esempio, la Pedana degli Elfi sta in un'**antica città elfica**, rarissima, che compare solo nei biomi di foresta; quella degli Elfi Oscuri in una **cripta degli elfi oscuri** dentro una grotta di una foresta oscura, con la Pedana e le anime degli elfi oscuri; e così via per ogni razza. Per **tornare Umano** un non umano deve trovare un **antico tempio** (una specie di vecchia chiesa) che custodisce la Pedana degli Umani. Queste strutture si aggiungono al mondo più avanti, quando il gioco sarà stabile (vedi [Strutture del mondo](/wiki/strutture) per quelle già previste).

---

## ❓ FAQ

**D: Posso superare il cap individuale di una statistica con l'equipaggiamento?**
R: Sì! Il cap individuale limita solo la statistica **base**. I bonus da equipaggiamento, buff e spell si sommano oltre il cap.

**D: L'Elfo Oscuro può attivare Faster Casting con equipaggiamento INT?**
R: Sì. Il cap INT base è 160, ma con +10 INT da equipaggiamento arrivi a 170 totali e la passiva si attiva.

**D: Il Vampiro può nutrirsi all'infinito?**
R: No. Può mangiare solo se Fame < 20 e bere solo se Sete < 20. Quando è sazio (20/20) non può nutrirsi.

**D: Il Demone deve essere Murderer per la passiva?**
R: Sì. Solo con il nome rosso i mostri lo ignorano. Se non è Murderer, la passiva non funziona.

**D: L'Umano è debole perché non ha estremi?**
R: L'Umano ha lo skill cap totale più alto (750 contro 700). Ogni skill arriva comunque a 100.0 come per le altre razze, ma l'Umano può tenere una skill in più. Questo permette build più versatili.

**D: Le statistiche iniziali sono fisse?**
R: Sì. Si comincia sempre come Umano, e quando cambi razza con la Pedana delle Razze (da fantasma, anche la prima volta e mai a pagamento) le statistiche vengono resettate ai valori iniziali della razza; dovrai allenarle fino ai cap. Il tuo **Stat Cap** resta invariato.

**D: La scurovisione rende inutili le torce?**
R: No: ti permette di orientarti e di vedere i blocchi vicini nelle grotte, ma una fonte di luce resta utile per vedere lontano, segnalare la strada e tenere lontane alcune creature.

---

## 🔗 Vedi anche

- [Classi](/wiki/classi) — le 18 classi e le razze consigliate per ciascuna
- [Progressione StatCap](/wiki/progressione-statcap) — come aumentare lo StatCap da 255 a 285
- [Skill](/wiki/skill) — il sistema skill completo, il bonus del Grand Master e le build consigliate
- [Pietra territorio di gilda](/wiki/pietra-territorio-gilda) — il sistema di gilde territoriale
