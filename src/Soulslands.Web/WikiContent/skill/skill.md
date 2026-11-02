---
title: Skill
slug: skill
category: Skill
visibility: Pubblica
---
# 📚 Sistema delle Skill

*Padroneggia le arti per diventare leggenda*

---

## 📜 Panoramica

In Soulslands il sistema delle skill segue il modello classico di Ultima Online, ereditato dallo shard **Cursed Souls**: le skill aumentano **usandole**. Più usi la spada, più diventi bravo con la spada; più scavi, più diventi un minatore esperto.

Sei libero di combinare qualsiasi skill, ma le **skill di classe** hanno una progressione a tier che richiede di svilupparle insieme (vedi il Sistema delle classi più sotto e [Classi](/wiki/classi)).

Le skill crescono nel mondo a voxel con azioni concrete: [Mining](/wiki/skill-mining) sale scavando blocchi di minerale, [Lumberjacking](/wiki/skill-lumberjacking) abbattendo alberi, [Carpentry](/wiki/skill-carpentry) e [Architecture](/wiki/skill-architecture) costruendo, [Fishing](/wiki/skill-fishing) pescando in fiumi e oceani. Tutto ciò che impari appartiene al tuo personaggio, che vive nel mondo condiviso e non lo lascia mai (vedi [Persistenza del mondo](/wiki/persistenza-del-mondo)).

---

## 📊 Skill cap

### Cap per singola skill
Ogni skill parte da 0.0 e può arrivare al massimo a **100.0** (**Grand Master**). In Soulslands non esistono pergamene o oggetti che permettano di superare 100.0.

### Cap totale

| Razza | Cap totale | Cosa significa |
|-------|-----------|----------------|
| Tutte tranne l'Umano | **700.0** | 7 skill a 100.0 |
| [Umano](/wiki/razza-umano) (passiva *Versatility*) | **750.0** | 7 skill a 100.0 più 50 punti per una skill di supporto |

Il cap totale è la somma di **tutte** le tue skill. Con 700.0 puoi avere 7 skill a Grand Master, oppure distribuire i punti come preferisci (ad esempio 5 skill a 100.0 e 4 a 50.0).

> ℹ️ Su Cursed Souls la passiva Versatility dell'Umano permetteva anche di portare ogni skill a 105.0. In Soulslands il cap per skill è 100.0 per tutti, e il vantaggio dell'Umano è il cap totale più alto.

### Blocco delle skill
Ogni skill ha tre stati, che imposti dalla finestra delle skill:
- ⬆️ **Su**: la skill può salire.
- ⬇️ **Giù**: la skill può scendere, per fare spazio ad altre.
- 🔒 **Bloccata**: la skill resta ferma.

Quando sei al cap totale e una skill sale, un'altra impostata su **Giù** scende di 0.1.

---

## ⏱️ Cosa fa una skill: rende più veloce

Nessuna skill sblocca qualcosa (**Deciso da Aruto, 27/10/2026**, vedi [Regole deterministiche](/wiki/regole-deterministiche)): a skill 0.0 puoi già scavare qualsiasi minerale, abbattere qualsiasi albero, preparare qualsiasi ricetta e domare qualsiasi creatura domabile. Come in Minecraft, tutti possono fare tutto; la skill serve a farlo **più in fretta**.

Ogni azione a tempo (raccogliere, fabbricare, domare, curare) dura il suo tempo base moltiplicato per **(1 − skill/200)**, con la skill reale: a 50.0 dura tre quarti del tempo base, a 100.0 la metà. Per la raccolta il tempo base è quello dei colpi dell'attrezzo: i colpi necessari sono i colpi del materiale dell'attrezzo × (1 − skill/200), mai meno di 1 (per esempio un piccone da 10 colpi ne chiede 10, 8 e 5 a skill 0.0, 50.0 e 100.0; uno da 4 colpi ne chiede 4, 3 e 2). Il lavoro **riesce sempre** se hai materiali, attrezzo e postazione: non esistono fallimenti né tiri. Dettagli in [Skill di crafting](/wiki/skill-crafting) e [Attrezzi](/wiki/attrezzi).

Le **skill di combattimento** non rendono nulla più veloce e non aggiungono danno: una skill più alta riduce solo la stamina che costano colpi, parate e attacchi speciali (vedi [Skill di combattimento](/wiki/skill-combattimento)).

### 🆚 Il bonus del Grand Master

Una skill a 100.0 conta come **120.0**: il bonus è un **+20.0 fisso** (non una percentuale) e vale solo nelle **sfide contro un altro giocatore**. Sono le uniche azioni in cui una skill si scontra con quella di un altro: rubare e curiosare negli zaini (contro il Detect Hidden della vittima), cercare un giocatore nascosto (Detect Hidden contro Hiding o Stealth) e scassinare la serratura di un altro giocatore. Vince chi ha il valore **strettamente più alto**; a parità vince chi si difende. Dettagli in [Furto](/wiki/furto) e nelle pagine delle singole skill. In tutto il resto (raccolta, crafting, cure, magia, combattimento) conta il valore reale.

---

## 📈 Come aumentano le skill

### Usare la skill
Ogni **uso utile** di una skill conta verso il prossimo 0.1, senza alcun tiro:
1. La skill deve essere su **Su**.
2. L'uso è utile se produce qualcosa (un blocco raccolto, un oggetto fabbricato, un incantesimo completato, una creatura domata), se colpisce un bersaglio vivo che non è un tuo animale o un compagno di party, o se è una sfida contro un altro giocatore.
3. Le azioni troppo facili per il tuo livello non insegnano nulla: ogni azione ha un livello fino al quale insegna.
4. Un uso conta al massimo una volta ogni **7,5 secondi** per skill.

Servono **1 + t²/18.000** usi per ogni 0.1, con t il tuo valore in decimi: 1 uso a 0.0, 14 a 50.0, 56 a 99.9. Da 0.0 a 100.0 sono circa **19.000 usi**, cioè circa **40 ore** di azione, uguali per tutte le skill (**Deciso da Aruto, 27/10/2026**). La formula è la stessa per ogni skill, quindi nessuna è "veloce" o "lenta": cambia solo quanto è comodo ripetere l'azione.

### Fino a dove insegna un'azione

| Skill attuale | Azioni che insegnano ancora |
|---------------|------------------------------|
| 0-30 | Azioni facili (lezioni dagli NPC, crafting di base, minerali di superficie) |
| 30-50 | Azioni medie (mostri deboli, gallerie poco profonde) |
| 50-70 | Azioni difficili (mostri medi, crafting avanzato, grotte) |
| 70-90 | Azioni molto difficili (sottosuolo profondo, crafting raro) |
| 90-100 | Azioni estreme (boss, materiali top) |

La tabella dice quali azioni valgono ancora quando la tua skill è a quel livello; una ricetta o un blocco smettono di insegnare quando la tua skill supera il loro livello. Anche rompere un blocco che hai piazzato tu conta come allenamento.

### Lezioni dagli NPC
Alcuni NPC dei feudi insegnano le basi di una skill: parla con l'insegnante giusto (ad esempio un mago per Magery), paga in oro e la skill sale subito fino a un livello di base.

### Crescita delle statistiche
Ogni uso utile di una skill aggiunge **75 punti di progresso** alla stat primaria e **25** alla secondaria; una stat sale di 1 quando raggiunge 2000 punti (la primaria ogni 27 usi), sempre entro i cap della tua razza. Tutti i dettagli in [Statistiche](/wiki/statistiche).

---

## 📋 Elenco completo delle skill

### ⚔️ Combattimento — [panoramica](/wiki/skill-combattimento)

| Skill | Stat | Uso |
|-------|------|-----|
| [Anatomy](/wiki/skill-anatomy) | INT | Bende più rapide |
| [Archery](/wiki/skill-archery) | DEX | Archi e balestre |
| [Bushido](/wiki/skill-bushido) | STR | Tecniche del samurai |
| [Fencing](/wiki/skill-fencing) | DEX | Armi da punta |
| [Focus](/wiki/skill-focus) | DEX | Rigenerazione di stamina e mana |
| [Healing](/wiki/skill-healing) | DEX | Cure con le bende |
| [Mace Fighting](/wiki/skill-mace-fighting) | STR | Mazze e martelli |
| [Parrying](/wiki/skill-parrying) | DEX | Parare con lo scudo |
| [Swordsmanship](/wiki/skill-swordsmanship) | STR | Spade e asce |
| [Tactics](/wiki/skill-tactics) | STR | Meno stamina nei colpi |
| [Throwing](/wiki/skill-throwing) | DEX | Armi da lancio |
| [Wrestling](/wiki/skill-wrestling) | STR | Lotta a mani nude |

### 🔮 Magia

| Skill | Stat | Uso |
|-------|------|-----|
| [Chivalry](/wiki/skill-chivalry) | INT | Magia sacra |
| [Evaluating Intelligence](/wiki/skill-evaluating-intelligence) | INT | Leggere mana e intelletto del bersaglio |
| [Magery](/wiki/skill-magery) | INT | Magia arcana in otto cerchi |
| [Meditation](/wiki/skill-meditation) | INT | Rigenerazione del mana |
| [Mysticism](/wiki/skill-mysticism) | INT | Magia dei gargoyle |
| [Necromancy](/wiki/skill-necromancy) | INT | Magia oscura |
| [Resisting Spells](/wiki/skill-resisting-spells) | STR | Resistere agli incantesimi |
| [Spellweaving](/wiki/skill-spellweaving) | INT | Magia della natura |
| [Spirit Speak](/wiki/skill-spirit-speak) | INT | Parlare con i morti, recuperare vita |

### 🔨 Crafting — [panoramica](/wiki/skill-crafting)

| Skill | Stat | Uso |
|-------|------|-----|
| [Alchemy](/wiki/skill-alchemy) | INT | Pozioni |
| [Architecture](/wiki/skill-architecture) | INT | Strutture rinforzate e territori di gilda |
| [Blacksmithy](/wiki/skill-blacksmithy) | STR | Armi e armature in metallo |
| [Bowcraft/Fletching](/wiki/skill-bowcraft-fletching) | DEX | Archi e frecce |
| [Carpentry](/wiki/skill-carpentry) | STR | Legno, mobili, blocchi lavorati |
| [Cartography](/wiki/skill-cartography) | INT | Mappe e tesori |
| [Cooking](/wiki/skill-cooking) | INT | Cibo |
| [Imbuing](/wiki/skill-imbuing) | INT | Proprietà magiche sugli oggetti |
| [Inscription](/wiki/skill-inscription) | INT | Pergamene e libri |
| [Tailoring](/wiki/skill-tailoring) | DEX | Vestiti e armature di cuoio |
| [Tinkering](/wiki/skill-tinkering) | DEX | Attrezzi, gioielli, meccanismi |

### ⛏️ Raccolta

| Skill | Stat | Uso |
|-------|------|-----|
| [Fishing](/wiki/skill-fishing) | DEX | Pesca in fiumi, laghi e oceani |
| [Lumberjacking](/wiki/skill-lumberjacking) | STR | Abbattere alberi, bonus con le asce |
| [Mining](/wiki/skill-mining) | STR | Scavare minerali e pietra |

### 🥷 Furtività

| Skill | Stat | Uso |
|-------|------|-----|
| [Detect Hidden](/wiki/skill-detect-hidden) | INT | Scoprire nascosti e trappole |
| [Hiding](/wiki/skill-hiding) | DEX | Nascondersi |
| [Lockpicking](/wiki/skill-lockpicking) | DEX | Scassinare |
| [Ninjitsu](/wiki/skill-ninjitsu) | DEX | Arti ninja |
| [Poisoning](/wiki/skill-poisoning) | DEX | Avvelenare armi e cibo |
| [Remove Trap](/wiki/skill-remove-trap) | DEX | Disinnescare trappole |
| [Snooping](/wiki/skill-snooping) | DEX | Guardare negli zaini altrui |
| [Stealing](/wiki/skill-stealing) | DEX | Rubare |
| [Stealth](/wiki/skill-stealth) | DEX | Muoversi nascosti |

### 🎲 Varie

| Skill | Stat | Uso |
|-------|------|-----|
| [Animal Lore](/wiki/skill-animal-lore) | INT | Conoscere le creature |
| [Animal Taming](/wiki/skill-animal-taming) | STR | Domare creature |
| [Arms Lore](/wiki/skill-arms-lore) | INT | Valutare e riparare equipaggiamento |
| [Begging](/wiki/skill-begging) | DEX | Elemosinare |
| [Camping](/wiki/skill-camping) | DEX | Fuochi e accampamenti |
| [Discordance](/wiki/skill-discordance) | INT | Indebolire con la musica |
| [Forensic Evaluation](/wiki/skill-forensic-evaluation) | INT | Indagare su cadaveri e scassi |
| [Herding](/wiki/skill-herding) | INT | Guidare animali |
| [Item Identification](/wiki/skill-item-identification) | INT | Identificare oggetti |
| [Musicianship](/wiki/skill-musicianship) | DEX | Suonare |
| [Peacemaking](/wiki/skill-peacemaking) | INT | Calmare con la musica |
| [Provocation](/wiki/skill-provocation) | INT | Far combattere le creature |
| [Taste Identification](/wiki/skill-taste-identification) | INT | Riconoscere pozioni e veleni |
| [Tracking](/wiki/skill-tracking) | INT | Seguire tracce |
| [Veterinary](/wiki/skill-veterinary) | INT | Curare animali |

---

## 🏗️ Build consigliate

### ⚔️ Guerriero
```
Swordsmanship     100.0
Tactics           100.0
Anatomy           100.0
Healing           100.0
Parrying          100.0
Resisting Spells  100.0
Meditation        100.0
```

### 🔮 Mago puro
```
Magery                   100.0
Evaluating Intelligence  100.0
Meditation               100.0
Resisting Spells         100.0
Inscription              100.0
Anatomy                  100.0
Healing                  100.0
```

### 🗡️ Schermidore furtivo
```
Fencing     100.0
Tactics     100.0
Anatomy     100.0
Healing     100.0
Hiding      100.0
Stealth     100.0
Poisoning   100.0
```

### 🎵 Bardo-Domatore
```
Animal Taming  100.0
Animal Lore    100.0
Musicianship   100.0
Provocation    100.0
Magery         100.0
Meditation     100.0
Veterinary     100.0
```

### 🔨 Artigiano
```
Blacksmithy    100.0
Tailoring      100.0
Tinkering      100.0
Mining         100.0
Arms Lore      100.0
Carpentry      100.0
Lumberjacking  100.0
```

> 💡 **Artigiano umano**: con il cap totale di 750 l'[Umano](/wiki/razza-umano) può aggiungere 50 punti in una skill di utilità, ad esempio [Architecture](/wiki/skill-architecture) o [Cooking](/wiki/skill-cooking).

---

## ⚔️ Sistema delle classi

Soulslands ha **18 classi**, ognuna definita da **3 skill di classe** (vedi [Classi](/wiki/classi)). Le skill di classe non salgono liberamente fino a 100.0: progrediscono a **tre tier**.

| Tier | Requisito | Cap delle skill di classe |
|------|-----------|---------------------------|
| **Tier 1** | Nessuno | 60.0 |
| **Tier 2** | Tutte e 3 le skill a 60.0 | 80.0 |
| **Tier 3** | Tutte e 3 le skill a 80.0 | 100.0 |

### Esempio: il Guerriero (Swordsmanship + Tactics + Lumberjacking)
1. Alleni Swordsmanship: sale liberamente fino a 60.0.
2. Per superare 60.0, **anche Tactics e Lumberjacking** devono arrivare a 60.0.
3. Quando tutte e tre sono a 60.0, possono salire fino a 80.0.
4. Quando tutte e tre sono a 80.0, possono salire fino a 100.0.

### Decadimento
Se una skill di classe scende sotto la soglia del tier (ad esempio Tactics scende sotto 60.0), le altre skill della classe **calano di 0.1 al minuto** finché non si riallineano. Il calo avviene sia online sia offline (al massimo 24 ore di recupero al login).

### Skill condivise
Alcune skill appartengono a più classi (ad esempio Tactics è nel Guerriero, nel Mazziere, nello Spadaccino e nell'Arciere). In questo caso vale come cap il **tier più alto** tra tutte le classi a cui appartiene.

### Le 18 classi

| Categoria | Classe | Skill 1 | Skill 2 | Skill 3 |
|-----------|--------|---------|---------|---------|
| **Combattimento** | [Guerriero](/wiki/classe-guerriero) | Swordsmanship | Tactics | Lumberjacking |
| | [Mazziere](/wiki/classe-mazziere) | Mace Fighting | Tactics | Wrestling |
| | [Spadaccino](/wiki/classe-spadaccino) | Fencing | Tactics | Poisoning |
| | [Arciere](/wiki/classe-arciere) | Archery | Tactics | Chivalry |
| | [Templare](/wiki/classe-templare) | Swordsmanship | Chivalry | Parrying |
| | [Minatore Combattente](/wiki/classe-minatore-combattente) | Mining | Blacksmithy | Arms Lore |
| **Magia** | [Arcanista](/wiki/classe-arcanista) | Magery | Evaluating Intelligence | Meditation |
| | [Necromante](/wiki/classe-necromante) | Necromancy | Spirit Speak | Magery |
| | [Alchimista](/wiki/classe-alchimista) | Alchemy | Poisoning | Taste Identification |
| | [Chierico](/wiki/classe-chierico) | Healing | Chivalry | Spirit Speak |
| | [Sciamano](/wiki/classe-sciamano) | Spirit Speak | Animal Taming | Magery |
| **Supporto** | [Bardo](/wiki/classe-bardo) | Musicianship | Provocation | Discordance |
| **Furtività** | [Ladro](/wiki/classe-ladro) | Stealing | Snooping | Hiding |
| | [Assassino](/wiki/classe-assassino) | Fencing | Poisoning | Ninjitsu |
| | [Ninja](/wiki/classe-ninja) | Ninjitsu | Hiding | Stealth |
| **Natura** | [Tamer](/wiki/classe-tamer) | Animal Taming | Animal Lore | Veterinary |
| | [Ranger](/wiki/classe-ranger) | Archery | Animal Taming | Animal Lore |
| **Esplorazione** | [Esploratore](/wiki/classe-esploratore) | Cartography | Lockpicking | Detect Hidden |

> 💡 Le skill che **non appartengono a nessuna classe** (ad esempio Resisting Spells o Anatomy) non hanno limiti di tier: salgono liberamente fino a 100.0. Una skill di classe resta vincolata ai tier anche se non hai scelto quella classe.

---

## ❓ FAQ

**D: Posso avere tutte le skill a 100.0?**
R: No. Con 700.0 di cap totale (750.0 per l'Umano) puoi avere al massimo 7 skill a Grand Master. Devi scegliere quelle importanti per il tuo stile.

**D: Le skill scendono da sole?**
R: Solo se un'altra skill su "Su" sale e sei al cap totale: allora scende di 0.1 una skill su "Giù". Blocca le skill che non vuoi perdere. Fanno eccezione le skill di classe, che decadono se un'altra skill della stessa classe scende sotto la soglia del tier.

**D: Serve molto tempo per arrivare a Grand Master?**
R: Circa 40 ore di azione utile, uguali per tutte le skill: servono circa 19.000 usi e un uso conta al massimo ogni 7,5 secondi.

**D: Il bonus del Grand Master funziona anche a skill bassa?**
R: No: è un +20.0 fisso che si aggiunge solo quando la skill reale è 100.0, e vale solo nelle sfide contro altri giocatori.

**D: Posso vedere il valore potenziato nella finestra delle skill?**
R: No. Vedi sempre il valore reale (0-100); il +20.0 è applicato solo nelle sfide.

**D: Il Nano ha un bonus aggiuntivo sul crafting?**
R: Sì. La passiva **Mastersmith** del [Nano](/wiki/razza-nano) conta come +10.0 in ogni skill di crafting per la velocità di lavoro. Non esiste la qualità eccezionale: un oggetto è uguale chiunque lo fabbrichi.

---

*Vedi anche: [Statistiche](/wiki/statistiche) | [Skill di combattimento](/wiki/skill-combattimento) | [Skill di crafting](/wiki/skill-crafting) | [Razze](/wiki/razze) | [Progressione dello stat cap](/wiki/progressione-statcap)*
