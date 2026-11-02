---
title: Contabile di Gilda
slug: contabile-gilda
category: Gilde
visibility: Pubblica
---
# 💰 Contabile di Gilda
*L'esattore delle tasse del territorio di gilda*

---

## 📋 Indice

- [Panoramica](#panoramica)
- [Come piazzarlo](#come-piazzarlo)
- [Pagare le tasse](#pagare-le-tasse)
- [Comandi vocali](#comandi-vocali)
- [Sistema dei conti](#sistema-dei-conti)
- [Ritiro del credito](#ritiro-del-credito)
- [FAQ](#faq)

---

## 📜 Panoramica

Il **Contabile di Gilda** è un NPC legato alla [Pietra di Territorio](/wiki/pietra-territorio-gilda). Riscuote le tasse giornaliere dei membri e tiene il conto di ciascuno.

> **Tipo**: NPC mercante
> **Posizione**: dentro il territorio della gilda
> **Interazione**: trascinamento dell'oro + comandi vocali
> **Negozio**: vende Contratto d'Impiego, Contratto d'Affitto per mercanti e Atto di Merce

### Cosa fa
- Raccoglie i **pagamenti delle tasse**
- Mostra il **saldo** (debito o credito) di ogni membro
- Permette di **ritirare il credito** in eccesso
- Informa sulle tasse e sullo stato del territorio

Il credito accumulato presso il contabile è importante anche per la [città di gilda](/wiki/citta-di-gilda): ogni **25.000 oro di credito** danno diritto a un **baule personale** bloccato nel territorio.

---

## 🏗️ Come piazzarlo

1. Il Leader apre il pannello della Pietra di Territorio → pagina **Principale**
2. Clicca **"Aggiungi o sposta"** accanto a "Contabile di Gilda"
3. Il contabile compare nella **posizione attuale** del Leader
4. Bisogna trovarsi **dentro il territorio**

### Spostarlo
1. Mettiti dove vuoi spostarlo (dentro il territorio)
2. Clicca di nuovo **"Aggiungi o sposta"**
3. Il contabile si sposta nella tua posizione

> 💡 Il contabile non cammina: resta fermo dove lo metti. Conviene metterlo al coperto, in una sala di gilda.

---

## 💳 Pagare le tasse

### Metodo principale: trascina l'oro

1. Prendi dell'**oro** dallo zaino
2. **Trascinalo** sul contabile
3. Il contabile calcola da solo il tuo debito

| Situazione | Cosa succede |
|-----------|-------------|
| **Hai un debito** | L'oro salda il debito, l'eccedenza ti viene restituita |
| **Sei in pari** | Tutto l'oro diventa credito |
| **Hai già credito** | L'oro si aggiunge al credito |

### Esempi di risposta

Il contabile risponde con tono formale:

- *"Il vostro versamento di 500 oro è registrato, Ser [Nome]. Il debito residuo ammonta a 1.500 oro."*
- *"Un deposito di 1.000 oro è accreditato sul vostro conto, Dama [Nome]. Il vostro credito ammonta ora a 500 oro."*
- *"Ricevuti 2.000 oro, Ser [Nome]. 1.500 per la tassa, 500 vi vengono restituiti. Il registro è in pari."*

> ⚠️ Solo i **membri della gilda proprietaria** possono pagare qui.

---

## 🗣️ Comandi vocali

Parla vicino al contabile (entro **4 blocchi**).

| Comando | Effetto |
|---------|--------|
| **"saldo"** / **"stato"** (*balance*, *status*) | Mostra il tuo saldo |
| **"aiuto"** (*help*) | Elenco dei comandi |
| **"tasse"** (*tax*, *taxes*) | Informazioni sulle tasse del territorio |
| **"ultimo pagamento"** (*lastpay*) | Data dell'ultimo versamento |
| **"paga"** (*pay*) | Istruzioni per pagare |
| **"ritira"** (*withdraw*) | Ritira tutto il credito disponibile |
| **"ritira 1000"** (*withdraw 1000*) | Ritira una somma precisa |

### Esempio

```
Tu: "saldo"
Contabile: "Ser Arutosio, dovete 300 oro di tasse territoriali."
Contabile: "Tassa giornaliera: 100 oro."
Contabile: "Giorni in debito: 3."
Contabile: "Ultimo pagamento: 15 marzo, ore 14:30."
```

---

## 📊 Sistema dei conti

Ogni membro ha un **conto personale** presso il contabile.

### Come funzionano le tasse

1. Il Leader imposta una **tassa giornaliera** (da 0 a 10.000 oro)
2. Ogni giorno la tassa viene **addebitata** a ogni membro attivo
3. Il saldo può essere:
   - **Positivo (CREDITO)**: hai pagato in anticipo
   - **Zero (PARI)**: sei in regola
   - **Negativo (DEBITO)**: devi pagare

### Cosa viene registrato

| Dato | Descrizione |
|------|-------------|
| **Nome** | Nome del personaggio |
| **Saldo** | Positivo = credito, negativo = debito |
| **Totale versato** | Tutto l'oro pagato nella storia del conto |
| **Totale tasse addebitate** | Tutte le tasse addebitate |
| **Numero di pagamenti** | Quanti versamenti hai fatto |
| **Giorni in debito** | Giorni consecutivi in negativo |
| **Ultimo pagamento** | Data dell'ultimo versamento |
| **Stato** | Membro attivo o uscito dalla gilda |

### Membri che lasciano la gilda
- Il conto **resta nel registro**
- Lo stato diventa **"Uscito"**
- Se ha credito può ancora ritirarlo parlando col contabile
- Le tasse **non vengono più addebitate**

---

## 🏧 Ritiro del credito

1. Avvicinati al contabile (entro 4 blocchi)
2. Di' **"ritira"** per prendere tutto il credito
3. Oppure **"ritira 500"** per una somma precisa
4. L'oro finisce nel tuo zaino

### Limiti
- Puoi ritirare solo il **credito disponibile**
- Il ritiro è limitato dall'**oro presente in tesoreria**: se la tesoreria è vuota non puoi ritirare, anche se hai credito
- Ritirare credito può farti scendere sotto la soglia per nuovi bauli personali (quelli già bloccati restano)

```
Tu: "ritira 500"
Contabile: "Ser Arutosio, ritirate 500 oro di credito dalle tasse territoriali."
```

---

## ❓ FAQ

**D: Dove trovo il contabile?**
R: Lo piazza il Leader dal pannello della Pietra di Territorio (pagina Principale → "Aggiungi o sposta").

**D: Posso pagare senza il contabile?**
R: Puoi anche trascinare l'oro direttamente sulla Pietra di Territorio, ma il contabile è l'unico che ti mostra il saldo e ti restituisce il credito.

**D: Se non pago?**
R: Il debito cresce ogni giorno. Il Leader vede chi è in debito dalla pagina Tasse; le conseguenze sono a sua discrezione.

**D: Se rientro in gilda dopo esserne uscito, ritrovo il conto?**
R: Sì, il conto è permanente, debiti compresi.

**D: Dove va l'oro delle tasse?**
R: Nella **tesoreria** del territorio, da cui il Leader può ritirarlo e da cui si pagano mercanti, espansioni e lotti della città.

**D: Il contabile può essere ucciso?**
R: Sì, ma ricompare automaticamente dopo pochi secondi.

**D: E se il territorio viene conquistato?**
R: I conti dei membri della vecchia gilda vengono chiusi: il credito non ritirato è perso. Un buon motivo per difendere il territorio!

---

*Vedi anche: [Pietra di Territorio](/wiki/pietra-territorio-gilda) | [Sfera di Cristallo di Mana](/wiki/sfera-di-cristallo-mana) | [Città di gilda](/wiki/citta-di-gilda)*
