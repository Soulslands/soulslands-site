---
title: Skill di crafting
slug: skill-crafting
category: Skill
visibility: Pubblica
---
# 🔨 Skill di crafting

*Forgia, cuci, costruisci: diventa il miglior artigiano del mondo*

---

## 📜 Panoramica

Il crafting in Soulslands parte dal sistema classico di Ultima Online, ma è deterministico (**Deciso da Aruto, 27/10/2026**, vedi [Regole deterministiche](/wiki/regole-deterministiche)): con materiali, attrezzo e postazione giusti un lavoro **riesce sempre**, qualsiasi ricetta è aperta da skill 0.0 e la skill serve solo a lavorare **più in fretta**. Una vasta gamma di **materiali speciali** dà bonus fissi diversi agli oggetti.

In un mondo a voxel tutto ciò che crei esiste davvero nel mondo: le armi stanno nello zaino di chi le impugna, i mobili e i blocchi lavorati restano dove li piazzi, le case e le fortezze sono fatte dei blocchi che hai prodotto. Le materie prime si raccolgono scavando, abbattendo alberi, pescando, coltivando e [scuoiando e smembrando](/wiki/scuoiare-e-smembrare) le creature.

---

## 🛠️ Skill di crafting

| Skill | Stat primaria | Cosa produce | Dove si lavora |
|-------|--------------|-------------|----------------|
| [Blacksmithy](/wiki/skill-blacksmithy) | STR | Armi e armature in metallo | Forgia e incudine |
| [Tailoring](/wiki/skill-tailoring) | DEX | Vestiti, armature di cuoio, Leather Hooded Robe | Kit da cucito, telaio |
| [Carpentry](/wiki/skill-carpentry) | STR | Mobili, oggetti e blocchi di legno lavorato | Sega, banco da carpentiere |
| [Architecture](/wiki/skill-architecture) | INT | Strutture rinforzate nei territori di gilda | Banco da costruzione |
| [Tinkering](/wiki/skill-tinkering) | DEX | Attrezzi, congegni, gioielli, meccanismi | Attrezzi da meccanico |
| [Alchemy](/wiki/skill-alchemy) | INT | Pozioni (cura, veleno, forza, agilità...) | Mortaio e pestello |
| [Cooking](/wiki/skill-cooking) | INT | Cibo contro fame e sete | Fuoco, forno |
| [Bowcraft/Fletching](/wiki/skill-bowcraft-fletching) | DEX | Archi, balestre e frecce | Coltello da intaglio |
| [Inscription](/wiki/skill-inscription) | INT | Pergamene magiche, libri, rune | Penna da scriba |
| [Cartography](/wiki/skill-cartography) | INT | Mappe e lettura delle mappe del tesoro | Penna da cartografo |
| [Imbuing](/wiki/skill-imbuing) | INT | Proprietà magiche sugli oggetti | Forgia dell'infusione |

### Skill di raccolta (complementari)

| Skill | Stat primaria | Cosa raccoglie |
|-------|--------------|---------------|
| [Mining](/wiki/skill-mining) | STR | Minerali e pietra, scavando blocchi di roccia |
| [Lumberjacking](/wiki/skill-lumberjacking) | STR | Legname, abbattendo alberi voxel |
| [Fishing](/wiki/skill-fishing) | DEX | Pesce e oggetti rari da fiumi e oceani |

---

## ⏱️ La skill rende il lavoro più rapido

Ogni ricetta ha un tempo base. Il tempo di lavoro è **tempo base × (1 − skill/200)**, con la skill reale e arrotondato per eccesso: a 50.0 dura tre quarti del tempo base, a 100.0 la metà. Non ci sono altri effetti:

| Skill reale | Tempo di lavoro |
|-------------|-----------------|
| 0.0 | tempo base |
| 50.0 | tre quarti del tempo base |
| 100.0 | metà del tempo base |

- **Nessun fallimento**: se hai materiali, attrezzo e postazione il lavoro finisce, sempre. Non si spreca materiale e non esistono più i "lavori falliti".
- **Nessuna ricetta bloccata**: puoi preparare qualsiasi ricetta da 0.0; sarà solo lenta. Ogni ricetta insegna la skill finché la tua skill è sotto il suo livello (vedi [Skill](/wiki/skill)): le ricette troppo facili per te non fanno più salire la skill.
- **Nessuna qualità eccezionale**: un oggetto è identico chiunque lo fabbrichi (vedi [Qualità eccezionale](/wiki/qualita-eccezionale)).
- Il bonus del Grand Master (+20.0) vale solo nelle sfide tra giocatori, non nel crafting.

---

## ⛏️ Bonus razziale del Nano

Il [Nano](/wiki/razza-nano) ha la passiva **Mastersmith**:
> **+10.0 a ogni skill di crafting** per la velocità di lavoro, sempre attiva (deciso da Aruto, 31/10/2026).

Il bonus conta solo nel calcolo del tempo di lavoro, fino al massimo di 100.0: un Nano con 90.0 in una skill di crafting lavora come chi ha 100.0. Non esiste alcuna qualità eccezionale.

| Razza | Una skill di crafting a 90.0 lavora come | Una skill di crafting a 100.0 lavora come |
|-------|------------------------------|-------------------------------|
| Qualsiasi | 90.0 | 100.0 |
| **Nano** | **100.0** | 100.0 |

### Build consigliata per un Nano artigiano
```
Blacksmithy    100.0
Tailoring      100.0
Tinkering      100.0
Mining         100.0
Arms Lore      100.0
Carpentry      100.0
Lumberjacking  100.0
```

> 💡 Il Nano ha STR cap 145, perfetto per Mining e Blacksmithy. Il DEX cap basso (85) lo rende lento ma resistente.

---

## 🐾 Materiali: pelli

Soulslands ha **15 tipi di pelle** (4 classiche e 11 speciali). Le pelli dei mostri danno alle armature in cuoio un piccolo bonus fisso per pezzo, legato alla leggenda del mostro, e un bonus di set un po' più grande. Le pelli si ottengono [scuoiando](/wiki/scuoiare-e-smembrare) la creatura corrispondente. Tabelle complete in [Materiali delle armature: cuoio](/wiki/materiali-armature-cuoio); panoramica in [Cuoio](/wiki/cuoio).

### Pelli classiche

| Pelle | Livello | Bonus per pezzo | Bonus del set di 6 |
|-------|---------|-----------------|--------------------|
| [Regular](/wiki/cuoio-regular) | Base | Nessuno | Nessuno |
| [Spined](/wiki/cuoio-spined) | Medio | Rigenerazione stamina +1 | Rigenerazione stamina +2 |
| [Horned](/wiki/cuoio-horned) | Alto | Rigenerazione mana +1 | Rigenerazione mana +2 |
| [Barbed](/wiki/cuoio-barbed) | Elite | Bonus HP +2 | Bonus HP +3 |

### Pelli speciali

| Pelle | Fonte | Bonus per pezzo | Bonus del set di 6 |
|-------|-------|-----------------|--------------------|
| [Lizard](/wiki/cuoio-lizard) | Lizardman | Resistenza al veleno +1 | Resistenza al veleno +2 |
| [Ogre](/wiki/cuoio-ogre) | Ogre | Resistenza fisica +1 | Resistenza fisica +2 |
| [Troll](/wiki/cuoio-troll) | Troll | Rigenerazione HP +1 | Rigenerazione HP +2 |
| [Ettin](/wiki/cuoio-ettin) | Ettin | Resistenza al freddo +1 | Resistenza al freddo +2 |
| [Cyclop](/wiki/cuoio-cyclop) | Ciclope | Bonus HP +2 | Bonus HP +3 |
| [Gargoyle](/wiki/cuoio-gargoyle) | Gargoyle | Rigenerazione HP +1 | Rigenerazione HP +2 |
| [Serpent](/wiki/cuoio-serpent) | Serpente | Resistenza al veleno +1 | Resistenza al veleno +3 |
| [Daemon](/wiki/cuoio-daemon) | Demone | Resistenza all'energia +1 | Resistenza all'energia +2 |
| [Dragon](/wiki/cuoio-dragon) | Drago | Resistenza al fuoco +1 | Resistenza al fuoco +2 |
| [Balron](/wiki/cuoio-balron) | Balron | Resistenza al fuoco +1 | Resistenza al fuoco +3 |
| [Wyrm](/wiki/cuoio-wyrm) | Wyrm | Rigenerazione mana +1 | Rigenerazione mana +3 |

Vedi [Cuoio](/wiki/cuoio) per le leggende dietro ogni bonus.

---

## ⛏️ Materiali: minerali

Soulslands ha **21 tipi di minerale** (9 classici e 12 speciali), ognuno con bonus fissi su armi e armature di metallo. Si estraggono scavando i blocchi di minerale: più sono rari, più sono profondi. Tutti si scavano da [Mining](/wiki/skill-mining) 0.0; il materiale del piccone e la skill riducono solo i colpi necessari. Tabelle complete in [Materiali delle armature: minerali](/wiki/materiali-armature-minerali); panoramica in [Minerali](/wiki/minerali).

### Minerali classici
| Minerale | Dettagli |
|----------|----------|
| [Iron](/wiki/minerale-iron) | Base, nessun bonus |
| [Dull Copper](/wiki/minerale-dull-copper) | Massima resistenza fisica pura |
| [Shadow Iron](/wiki/minerale-shadow-iron) | Specialista energia, durevolissimo |
| [Copper](/wiki/minerale-copper) | Specialista veleno |
| [Bronze](/wiki/minerale-bronze) | Specialista freddo |
| [Gold](/wiki/minerale-gold) | Leggero: −15 punti di requisito STR |
| [Agapite](/wiki/minerale-agapite) | Bilanciato su tutte le resistenze |
| [Verite](/wiki/minerale-verite) | Bilanciato alto |
| [Valorite](/wiki/minerale-valorite) | Forte ovunque tranne il fuoco |

### Minerali speciali
| Minerale | Dettagli |
|----------|----------|
| [Rusty](/wiki/minerale-rusty) | Il primo minerale speciale, vicino alla superficie |
| [Old Copper](/wiki/minerale-old-copper) | Rame antico, fisica e veleno |
| [Steel](/wiki/minerale-steel) | Acciaio, durevolissimo |
| [Rose](/wiki/minerale-rose) | Fisica ed energia |
| [Silver](/wiki/minerale-silver) | Argento, freddo ed energia, efficace contro i non-morti |
| [Orialco](/wiki/minerale-orialco) | Lega leggendaria |
| [Blood Rock](/wiki/minerale-blood-rock) | Specialista fuoco aggressivo |
| [Mytheril](/wiki/minerale-mytheril) | Leggero: restituisce 16 punti del malus DEX col set completo |
| [Black Rock](/wiki/minerale-black-rock) | Roccia vulcanica, il più bilanciato e durevole |
| [Titanio](/wiki/minerale-titanio) | Fisica e freddo fortissimi |
| [Cobalto](/wiki/minerale-cobalto) | Il migliore in assoluto |
| [Demonic](/wiki/minerale-demonic) | Fuoco ed energia puri, il più raro |

---

## 🔧 Scegliere il materiale

Quando apri il menu di uno strumento (martello, kit da cucito, ecc.) puoi scegliere il **materiale** da usare:

1. **Apri il menu** usando lo strumento (vicino alla forgia o al banco, se servono).
2. **Scegli il materiale** dall'elenco in alto: compaiono solo quelli che hai nell'inventario.
3. **Scegli la ricetta**.
4. **Lavora**: il gioco usa il materiale scelto dal tuo zaino.

### Regole

- Il materiale deve essere **nel tuo inventario**.
- Nessun materiale richiede una skill minima: puoi usare qualsiasi materiale da skill 0.0.
- Il materiale **cambia i bonus** dell'oggetto (resistenze, danni, attributi), sempre per valori fissi.
- Se il materiale non basta, il lavoro non parte.
- Puoi cambiare materiale in qualsiasi momento senza chiudere il menu.

---

## 👘 Leather Hooded Robe

Le **Leather Hooded Robe** sono un oggetto speciale di [Tailoring](/wiki/skill-tailoring). Ogni tipo di pelle dà un bonus diverso:
- La tunica prende il **colore** della pelle usata.
- Conta come **un pezzo** di armatura di quella pelle e ne dà il bonus per pezzo (deciso da Aruto, 31/10/2026).
- Richiedono molta pelle.

> 💡 Consulta le pagine delle singole pelli in [Cuoio](/wiki/cuoio) per il bonus di ogni tunica.

---

## ♻️ Smontare, riprendere, usura

Un oggetto fabbricato non è perso per sempre (**Deciso da Aruto, 28/10/2026**):

| Azione | Cosa torna |
|--------|-----------|
| **Smontare** un oggetto o **distruggere** uno piazzato (per esempio con l'assedio) | Il costo dell'oggetto **meno un quinto** (ne restano 4/5), arrotondato per difetto per ogni risorsa. Un oggetto che costa 10 lingotti ne restituisce 8; uno da 4 ne restituisce 3; uno da 1 ne restituisce 0 |
| **Riprendere** un oggetto piazzato con l'azione di raccolta (forgia, banco, mobile) | L'oggetto **intero** |
| Un attrezzo o un'arma che si **rompe per usura** | Un **quinto** dei materiali (per difetto) |
| Rompere normalmente un **blocco da costruzione** (assi, mattoni, pietra lavorata, scale, mura, tetti) | Il blocco **intero** |
| Vetro | Il vetro rotto lascia **cocci di vetro** con la stessa regola: un blocco costruito con 4 cocci ne restituisce 3, un vetro sottile nessuno (proposta: raccoglilo per tenerlo) |

Per un oggetto che si può fare in più modi, il costo preso in conto è quello della ricetta più economica, così smontare non rende mai più di quanto serve a fabbricare. Una pila si smonta oggetto per oggetto. Le materie prime (pietra, minerali, tronchi, terra, sabbia) lasciano sé stesse.

---

## ❓ FAQ

**D: Qual è la razza migliore per il crafting?**
R: Il Nano, grazie a Mastersmith (+10.0 a ogni skill di crafting per la velocità). Ma qualsiasi razza con skill 100.0 lavora alla stessa velocità massima.

**D: Serve Mining per fare il fabbro?**
R: Non obbligatoriamente: i lingotti si comprano. Ma scavarli da sé fa risparmiare molto oro.

**D: Come ottengo le pelli speciali?**
R: Uccidendo le creature corrispondenti (troll per il cuoio di troll, draghi per il cuoio di drago...) e scuoiandone il cadavere con un coltello. Ogni creatura dà sempre la stessa quantità di pelle.

**D: A 100.0 cambio qualcosa rispetto a 50.0, oltre alla velocità?**
R: No. Tutte le ricette sono aperte da 0.0 e il risultato è lo stesso: cambia solo il tempo, che a 100.0 è la metà del tempo base.

**D: Posso usare materiali diversi nello stesso oggetto?**
R: No. Ogni oggetto usa un solo materiale: niente armature metà Iron e metà Valorite.

**D: Come funziona l'eccezionale?**
R: Non esiste: un oggetto è uguale chiunque lo fabbrichi. Vedi [Qualità eccezionale](/wiki/qualita-eccezionale).

---

*Vedi anche: [Skill](/wiki/skill) | [Sistema armature](/wiki/sistema-armature) | [Attrezzi](/wiki/attrezzi) | [Legni](/wiki/legni) | [Razze](/wiki/razze)*
