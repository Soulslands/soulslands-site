---
title: Pietra di Territorio
slug: pietra-territorio-gilda
category: Gilde
visibility: Pubblica
---
# 🏰 Pietra di Territorio
*La pietra fondamentale per reclamare, gestire e difendere un territorio di gilda*

---

## 📋 Indice

- [Panoramica](#panoramica)
- [Chunk e territorio](#chunk-e-territorio)
- [Come piazzare la pietra](#come-piazzare-la-pietra)
- [Cattura del territorio](#cattura-del-territorio)
- [Gestione del territorio](#gestione-del-territorio)
- [Sicurezza e guardie](#sicurezza-e-guardie)
- [Espansione del territorio](#espansione-del-territorio)
- [Mercanti e NPC](#mercanti-e-npc)
- [Barriere magiche](#barriere-magiche)
- [Tasse giornaliere](#tasse-giornaliere)
- [Assedio e difesa](#assedio-e-difesa)
- [Comandi e interazioni](#comandi-e-interazioni)
- [FAQ](#faq)

---

## 📜 Panoramica

La **Pietra di Territorio** è il blocco speciale che permette a una gilda di reclamare una porzione del mondo a voxel. Una volta piazzata e catturata, diventa il cuore dell'insediamento: da lì il Leader gestisce confini, guardie, mercanti, tasse, barriere magiche e permessi di costruzione.

> **Peso**: 500 stones
> **Tipo**: Oggetto unico, piazzabile come blocco
> **Accesso alla gestione**: solo il Leader della gilda (o lo staff)

### Cosa puoi fare con un territorio
- Proteggere la zona con guardie armate
- Impedire ai non membri di scavare o costruire nei tuoi chunk
- Piazzare mercanti NPC (banchiere, fabbro, mago...)
- Decidere chi può entrare e cosa può fare
- Espandere i confini comprando nuovi chunk
- Attivare barriere magiche (anti-Recall, anti-Gate, anti-campi magici)
- Riscuotere tasse giornaliere dai membri
- Costruire una [città di gilda](/wiki/citta-di-gilda)

---

## 🧊 Chunk e territorio

Il mondo di Soulslands è diviso in **chunk**: colonne di **16 × 16 blocchi** che si estendono in verticale dalla roccia madre fino al limite del cielo. I territori di gilda sono fatti di chunk interi.

| Concetto | Dettaglio |
|----------|-----------|
| **Unità di territorio** | 1 chunk = 16 × 16 blocchi, tutta l'altezza del mondo |
| **Territorio iniziale** | 3 × 3 chunk (48 × 48 blocchi) centrati sul chunk della pietra |
| **Area centrale (core)** | I 9 chunk iniziali: non possono mai essere rimossi |
| **Territorio massimo** | 49 chunk |
| **Raggio massimo** | 3 chunk dal chunk della pietra in ogni direzione |

Possedere un chunk significa possederne **tutto**: la superficie, le grotte sotterranee, le vene di [minerale](/wiki/minerali), gli alberi e lo spazio aereo sopra.

### Protezione dei blocchi

| Chi | Può scavare / rompere blocchi | Può piazzare blocchi |
|-----|-------------------------------|----------------------|
| Leader e membri con permesso di costruzione | ✅ | ✅ |
| Membri senza permesso | ❌ (solo raccolta di risorse, se il Leader la consente) | ❌ |
| Non membri | ❌ | ❌ |
| Nemici in guerra, durante la finestra di assedio | ✅ (blocchi comuni e terreno; non la pietra, non le strutture rinforzate, non i blocchi dei lotti) | ✅ (scale, ponti e opere d'assedio) |

Fa eccezione la **distruzione delle strutture**: chiunque può colpire e abbattere le strutture costruite con il [Sistema di costruzioni](/wiki/sistema-costruzioni). Chi lo fa senza essere in guerra con la gilda proprietaria diventa **criminale** e le guardie del territorio lo attaccano; un nemico in guerra può farlo legittimamente.

> 💡 Fuori dai territori il mondo resta libero: chiunque può scavare e costruire, come in qualsiasi zona selvaggia.

---

## 🗺️ Come piazzare la pietra

La pietra analizza i dintorni quando la usi e ti dice se il luogo è adatto.

### Requisiti del luogo

| Requisito | Dettaglio |
|-----------|----------|
| **Mondo di gioco valido** | Non in zone speciali o istanze |
| **Lontano dalle zone protette** | Almeno **2 chunk** di distanza da feudi, villaggi, aree sorvegliate dalle guardie e ingressi dei dungeon |
| **Lontano da altri territori** | Tra i confini di due territori deve restare almeno **1 chunk libero**, calcolato sul raggio massimo raggiungibile da entrambi |
| **Su un blocco solido** | Non in acqua, lava o a mezz'aria; non dentro un contenitore |
| **Chunk libero** | Nessun altro territorio o lotto già presente nei 3 × 3 chunk iniziali |

### Messaggi di piazzamento

Usando la pietra, il tuo personaggio esamina la zona e commenta:

- *"Questo è un buon posto..."* — il luogo è valido
- *"Ci sono terre protette troppo vicine..."* — troppo vicino a un feudo o a una zona protetta
- *"Vedo il segno di un'altra gilda..."* — troppo vicino a un altro territorio
- *"Questo luogo non va bene..."* — sei dentro una zona protetta

> 💡 Il messaggio indica anche la **direzione cardinale** in cui spostarti per trovare un punto valido.

La pietra si può piazzare anche **nel sottosuolo** (in una grotta, per esempio): il territorio comprende comunque l'intera colonna dei chunk, superficie inclusa.

---

## ⚔️ Cattura del territorio

Una pietra appena piazzata in un luogo valido va **catturata** per attivare il territorio.

1. La pietra deve essere a terra in un luogo valido
2. Uno o più membri della gilda restano vicino alla pietra, entro il raggio di cattura
3. La barra di progresso avanza a ogni tick
4. Se non c'è nessuno, il progresso cala lentamente
5. Se nel raggio ci sono membri di **gilde diverse**, la pietra è **contestata** e il progresso si ferma. I personaggi nascosti non contano, né per la cattura né per la contesa, finché non si rivelano
6. A 100% il territorio è conquistato

| Parametro | Pietra libera | Pietra nemica (assedio) |
|-----------|--------------|-------------------------|
| **Tempo di cattura** | 10 secondi | 5 minuti |
| **Tick di aggiornamento** | 2 secondi | 2 secondi |
| **Raggio di cattura** | 5 blocchi | 5 blocchi |

Per la cattura di una pietra nemica vedi [Assedio e difesa](#assedio-e-difesa).

---

## 🏛️ Gestione del territorio

Dopo la cattura, il Leader usa la pietra per aprire il **pannello di gestione**, diviso in pagine.

### Pagina principale

- **Stato del territorio**: numero di chunk e giocatori presenti nell'area (i nascosti non si contano finché non si rivelano)
- **Consenti edifici**: abilita o disabilita i lotti della [città di gilda](/wiki/citta-di-gilda)
- **Campo anti-magia**: attiva un campo che impedisce di lanciare incantesimi nell'area
- **Tassa giornaliera**: da 0 a 10.000 oro per membro (vedi [Contabile di Gilda](/wiki/contabile-gilda))
- **Contabile di Gilda**: piazza o sposta l'NPC esattore
- **Tesoreria**: ritira oro dalla cassa del territorio
- **Distruggi pietra**: elimina il territorio (l'oro in tesoreria torna al Leader)

> ⚠️ Distruggere la pietra rimuove guardie, mercanti, barriere e confini. Gli edifici dei lotti vengono demoliti e le strutture del sistema di costruzioni diventano orfane: restano dove sono e non decadono, salvo una regola del server che lo preveda.

---

## 🛡️ Sicurezza e guardie

La pagina **Sicurezza** controlla guardie e regole del territorio.

### Guardie

- Attaccano **criminali e assassini** (personaggi red) che entrano nel territorio
- **Proteggono i membri della gilda** e i loro alleati: chi li attacca diventa un bersaglio
- Raggiungono rapidamente il colpevole, come le [guardie cittadine](/wiki/guardie-cittadine)
- Chiunque può chiamarle gridando **"Guardie!"** (o *"Guards!"*)
- Durante un assedio difendono la pietra dagli attaccanti

| Opzione | Descrizione |
|---------|-------------|
| **Guardie attive** | Abilita o disabilita le guardie |
| **Numero guardie** | Da 0 a 15 |
| **Forza guardie** | Da 1 a 10 (moltiplica le statistiche) |

| Tipo | Stile | Specialità |
|------|-------|-----------|
| **Guardia guerriero** | Corpo a corpo | Combatte con l'alabarda |
| **Guardia arciere** | A distanza | Arciere a cavallo |
| **Guardia mago** | Incantatore | Lancia Lightning, Paralyze e Flame Strike |

### Regole del territorio

| Regola | Descrizione |
|--------|-------------|
| **Consenti non membri** | I non membri possono entrare (se disattivato, vengono respinti ai confini) |
| **Consenti combattimento** | Permette il combattimento nel territorio |
| **Consenti incantesimi** | Permette l'uso della magia |
| **Consenti raccolta ai membri** | I membri senza permesso di costruzione possono comunque minare e tagliare alberi |
| **Finestra di vulnerabilità** | Le 2 ore giornaliere in cui la pietra può essere assediata (vedi sotto) |

---

## 📐 Espansione del territorio

La pagina **Espandi** permette di aggiungere o togliere chunk.

### Come espandere

1. Clicca **"Inizia modifica"**
2. Ai confini dei chunk compaiono **segnalatori colorati**:
   - 🟢 **Verde**: chunk attuali
   - 🟡 **Giallo**: chunk che stai aggiungendo
   - 🔴 **Rosso**: chunk che stai rimuovendo
3. Usa **"Aggiungi chunk"** sul chunk adiacente che vuoi
4. Usa **"Rimuovi chunk"** per toglierne uno (mai dall'area centrale)
5. **"Applica bozza"** conferma e paga dalla tesoreria
6. Oppure **"Pausa"** per nascondere i segnalatori senza perdere la bozza

- **Pausa**: nasconde i segnalatori e conserva la bozza
- **Annulla**: scarta la bozza e torna al territorio originale
- Se ti allontani più di 1 chunk dal confine, la modifica va in pausa automaticamente

### Costo dell'espansione

```
Costo per chunk = Costo base + (chunk già posseduti × costo incrementale)
```

| Parametro | Valore |
|-----------|--------|
| **Costo base** | 50.000 oro per chunk |
| **Costo incrementale** | +5.000 oro per ogni chunk già posseduto |
| **Massimo chunk** | 49 |
| **Raggio massimo** | 3 chunk dal chunk della pietra |

> 💡 Esempio: con i 9 chunk iniziali, aggiungerne 2 costa (50.000 + 9 × 5.000) + (50.000 + 10 × 5.000) = 95.000 + 100.000 = **195.000 oro**.

### Regole della forma

- I chunk devono essere **adiacenti** lato a lato (niente diagonali)
- Il territorio deve restare **contiguo** (niente isole)
- Deve sempre contenere l'**area centrale** di 3 × 3 chunk
- Minimo **9 chunk**

### Conferma definitiva

**"Conferma territorio"** blocca la forma per sempre: dopo la conferma non si può più modificare (solo lo staff può sbloccarla). Fallo solo quando sei sicuro.

Se il territorio si **restringe**, gli edifici dei lotti rimasti fuori vengono eliminati e i bauli personali fuori dai confini vengono sbloccati (vedi [Città di gilda](/wiki/citta-di-gilda)).

---

## 🏪 Mercanti e NPC

La pagina **Mercanti** permette di piazzare NPC commercianti nel territorio.

| Mercante | Servizio |
|----------|----------|
| Banchiere | Servizi bancari |
| Fabbro | Riparazioni, armi e armature |
| Provveditore | Oggetti di uso comune |
| Mago | Reagenti e pergamene |
| Armaiolo | Armature |
| Addestratore di animali | Stalla e addestramento |
| Alchimista | Pozioni |
| Sarto | Stoffe e vestiti |
| Carpentiere | Mobili e oggetti in legno |
| Inventore | Attrezzi |
| Arcaio | Archi e frecce |
| Macellaio | Carne e cibo |
| Bardo | Strumenti musicali |
| Erborista | Erbe e ingredienti |

- **Aggiungi**: piazza un mercante (costa oro dalla tesoreria)
- **Sposta**: lo porta alla tua posizione
- **Elimina**: lo rimuove
- **Massimo**: 15 mercanti per territorio

---

## 🔮 Barriere magiche

La pagina **Barriere** controlla le barriere del territorio. Serve una [Sfera di Cristallo di Mana](/wiki/sfera-di-cristallo-mana) collegata.

1. Piazza la sfera nel territorio
2. Clicca **"Collega Sfera di Cristallo"**
3. Indica la sfera: viene legata alla pietra e non si può più spostare

| Barriera | Mana ogni 5 secondi | Effetto |
|----------|---------------------|---------|
| **Prelievo di mana** | Variabile (ricarica) | Preleva mana dai giocatori nel territorio per caricare la sfera |
| **Blocca Recall** | 5 | Impedisce Recall e Mark |
| **Blocca Gate** | 8 | Impedisce Gate Travel e Sacred Journey |
| **Blocca campi magici** | 10 | Impedisce Fire Field, Poison Field, Paralyze Field e Wall of Stone |

- Le barriere consumano mana dalla sfera ogni 5 secondi
- Se il mana finisce si **disattivano da sole**
- Se nel territorio ci sono portali o teletrasporti, puoi abilitarli o bloccarli uno per uno

---

## 💰 Tasse giornaliere

La pagina **Tasse** mostra lo stato dei conti dei membri.

1. Il Leader imposta la **tassa giornaliera** (es. 100 oro al giorno)
2. Ogni giorno la tassa viene addebitata a ogni membro
3. I membri pagano portando oro al [Contabile di Gilda](/wiki/contabile-gilda) o trascinandolo sulla pietra
4. L'oro finisce nella **tesoreria** del territorio

| Colonna | Descrizione |
|---------|-------------|
| **Nome** | Personaggio e stato (Membro / Uscito) |
| **Saldo** | DEBITO, CREDITO o PARI |
| **Giorni in debito** | Da quanto il membro è in negativo |
| **Ultimo pagamento** | Data dell'ultimo versamento |

Ordinamento per **debito**, **nome** o **ultimo pagamento**.

---

## 🏴 Assedio e difesa

Durante una [guerra tra gilde](/wiki/gilde) attiva, la pietra può essere assediata.

| Parametro | Valore |
|-----------|--------|
| **Condizione** | Guerra attiva con la gilda proprietaria (accettata da entrambe; diventa attiva 24 ore dopo l'accettazione) |
| **Finestra di vulnerabilità** | 2 ore al giorno, scelte dal Leader proprietario (modificabili al massimo una volta a settimana) |
| **Punti integrità della pietra** | 10.000 |
| **Riparazione** | Fuori dalla finestra il Leader può ripristinare l'integrità pagando oro dalla tesoreria |
| **Cattura** | A integrità zero, 5 minuti nel raggio di 5 blocchi, contestabile dai difensori |

Quando la cattura riesce il territorio passa alla gilda attaccante, con tutte le conseguenze descritte nella pagina [Gilde](/wiki/gilde#conquista-dei-territori).

> 💡 Una pietra protetta da mura spesse, guardie al massimo e barriere che impediscono Recall e Gate costringe gli assedianti ad arrivare a piedi: un enorme vantaggio per chi difende.

---

## ⌨️ Comandi e interazioni

| Azione | Come |
|--------|------|
| **Aprire il pannello** | Usa la pietra (solo Leader o staff) |
| **Chiamare le guardie** | Grida "Guardie!" dentro il territorio |
| **Pagare le tasse** | Trascina l'oro sul Contabile di Gilda |
| **Controllare il saldo** | Di' "saldo" vicino al Contabile |
| **Ritirare il credito** | Di' "ritira" o "ritira 1000" al Contabile |

---

## ❓ FAQ

**D: Posso spostare la pietra dopo averla piazzata?**
R: No. Una volta attivata è fissa: puoi solo distruggerla e piazzarne una nuova.

**D: Cosa succede se distruggo la pietra?**
R: Guardie, mercanti, barriere e confini spariscono. L'oro della tesoreria torna al Leader.

**D: Posso avere più territori?**
R: Sì, purché rispettino le distanze minime tra loro.

**D: Le guardie attaccano i miei alleati?**
R: No. Proteggono membri e alleati e attaccano criminali, assassini, chi aggredisce un membro e i nemici durante un assedio.

**D: Se il mana della sfera finisce?**
R: Le barriere si spengono. Guardie e mercanti continuano a funzionare.

**D: Posso cambiare forma dopo la conferma?**
R: No, la conferma è definitiva. Solo lo staff può sbloccarla.

**D: I nemici possono scavare un tunnel sotto le mie mura?**
R: Fuori dalle finestre di assedio no: nei chunk del territorio i non membri non possono rompere blocchi. Durante un assedio, invece, i nemici in guerra possono scavare il terreno e i blocchi comuni: per questo le difese serie si fanno con le **strutture rinforzate**, che non si scavano ma vanno abbattute colpo su colpo.

---

*Vedi anche: [Gilde](/wiki/gilde) | [Sfera di Cristallo di Mana](/wiki/sfera-di-cristallo-mana) | [Contabile di Gilda](/wiki/contabile-gilda) | [Sistema di costruzioni](/wiki/sistema-costruzioni)*
