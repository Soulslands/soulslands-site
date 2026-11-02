---
title: Modalità di gioco
slug: modalita-di-gioco
category: Regole di gioco
visibility: Pubblica
---
# 🎮 Modalità di gioco
*Creativa per costruire ed esplorare, sopravvivenza per giocare sul serio*

---

## 📜 Panoramica

Ogni mondo di Soulslands nasce **creativo** o **sopravvivenza** e resta così per sempre. Ogni personaggio, dentro il mondo, ha la sua modalità: creativa o sopravvivenza.

> ⚠️ **Stato del lavoro.** Questa pagina descrive le regole decise per le prime versioni giocabili del gioco da solo. Il sopravvivenza completo (inventario, oggetti che cadono, salute, fame, danni) arriva più avanti: per ora un personaggio in sopravvivenza può solo esplorare e scavare.

**Deciso da Aruto (25/10/2026):** il volo è permesso in creativa; la tavolozza creativa contiene ogni blocco, illimitato e gratis; rompere è istantaneo in creativa; in creativa niente danni e niente fame; F5 cambia visuale come in Minecraft; il mondo si salva da solo e con un pulsante, e si salva anche quando esci. Fonte tecnica: [ADR-0025](https://github.com/Soulslands/soulslands-game/blob/main/docs/adr/0025-creative-exploration-rules.md).

---

## 🌍 Modalità del mondo e del personaggio

| Cosa | Regola |
|------|--------|
| **Modalità del mondo** | Si sceglie quando il mondo viene creato e **non cambia mai** |
| **Modalità del personaggio** | Parte uguale a quella del mondo e viene salvata con il personaggio |
| **Mondo creativo** | I giocatori autorizzati possono passare da creativa a sopravvivenza e ritorno, come in Minecraft |
| **Mondo sopravvivenza** | Nessuno può passare alla creativa, mai |
| **Mondi creati prima di questa regola** | Si aprono come creativi |

Per ora la schermata di creazione del mondo **non offre la sopravvivenza**: la mostra spenta, con la scritta "I mondi sopravvivenza arriveranno con un aggiornamento successivo". Un mondo sopravvivenza non potrebbe mai passare alla creativa e, prima delle regole complete di sopravvivenza, sarebbe quasi vuoto. Si può comunque provare la sopravvivenza passandoci da un mondo creativo.

### Chi può cambiare modalità

| Dove giochi | Chi cambia modalità e salva con il pulsante |
|-------------|---------------------------------------------|
| **Da solo** (mondo locale) | Tu, sempre |
| **Server dedicato** | **Solo gli admin** del server, indicati dall'host nelle impostazioni (`[admin] accounts`). Non esiste un'impostazione per lasciar cambiare a tutti |

Chi non ha il permesso non vede il comando nel menu. Se prova lo stesso (client modificato), il server rifiuta con un avviso. Passando da creativa a sopravvivenza il volo finisce e il personaggio cade; nel verso opposto il volo diventa possibile.

---

## 🧱 Cosa cambia tra le due modalità

| | Creativa | Sopravvivenza (prime versioni) |
|---|---|---|
| **Volo** | Sì | No |
| **Rompere un blocco** | Istantaneo | Secondo la durezza del blocco; a mani nude si impiega il triplo dove serve un attrezzo |
| **Oggetti che cadono** | Nessuno | Nessuno: il blocco scavato sparisce (gli oggetti arrivano più avanti) |
| **Piazzare un blocco** | Qualsiasi blocco della tavolozza, gratis e illimitato | Rifiutato: in sopravvivenza si piazza dall'inventario, che ancora non esiste |
| **Danni e fame** | Mai | Non ancora presenti |
| **Cadute** | Succedono, senza danni | Succedono; i danni arrivano con le regole complete |

Raggio d'azione (5 blocchi) e linea di vista valgono in entrambe. Il blocco `world_rock`, il fondo del mondo, resta indistruttibile anche in creativa *(proposta, da confermare)*.

---

## 🕊️ Volo

- Il volo esiste **solo in creativa**.
- Si attiva toccando due volte il salto in fretta (circa un terzo di secondo); in volo il salto sale, acquattarsi scende e la corsa vola più veloce *(proposta, come in Minecraft)*.
- **Atterrare finisce il volo**: appena il personaggio tocca terra smette di volare. Per ripartire serve rilasciare e ritoccare due volte il salto: tenere premuto non basta.
- Il server calcola il volo dai tuoi tasti, come la camminata: nessuna velocità la sceglie il client.

Velocità di partenza, prese da Minecraft Java e *da confermare* (le misurerà chi le implementa): camminata 4,3 blocchi al secondo, corsa 5,6, volo 10,9, volo in corsa 21,8, salita e discesa in volo 7,5.

---

## ⛏️ Rompere e piazzare in creativa

- **Rompere è istantaneo.** Tenendo premuto il tasto, il blocco successivo che stai mirando si rompe ogni quarto di secondo circa *(proposta, come Minecraft)*.
- Rompere in creativa non lascia oggetti.
- **La tavolozza** (tasto `E`) mostra ogni blocco che si può piazzare: niente aria, niente liquidi (arriveranno con le regole del loro scorrere), niente blocchi indistruttibili. Una barra rapida da 9 posti, scelta con i tasti 1-9 e la rotella, decide cosa piazza il tasto destro; il tasto centrale copia il blocco mirato *(proposta)*.
- Nelle prime versioni esistono solo blocchi **cubici**; le forme (scale, lastre) seguono subito dopo.

---

## 💾 Salvataggio

Il mondo si salva in tre modi (dettagli in [Persistenza del mondo](/wiki/persistenza-del-mondo)):

1. **Da solo, ogni pochi secondi**: al massimo circa 10 secondi di gioco si perdono se il computer si spegne di colpo.
2. **Con il pulsante Salva** del menu di pausa (`Esc`): sotto il pulsante compare "Ultimo salvataggio alle 14:32:05", oppure "Non ancora salvato" se non è successo niente, e "Salvataggio..." mentre aspetti.
3. **Quando esci**: "Salva ed esci al titolo" e la chiusura della finestra salvano prima di chiudere, con una schermata "Salvataggio del mondo". Su un server remoto escono semplicemente dal server.

Il personaggio salva posizione, sguardo, modalità e se sta volando; al rientro ritrovi tutto com'era. Il menu di pausa **non ferma** il mondo *(proposta: per ora nulla può farti male)*.

---

## 🎥 Visuali (tasto F5)

F5 fa girare tre visuali, una dopo l'altra, come in Minecraft:

**prima persona → terza persona da dietro → isometrica → prima persona**

| Visuale | Come funziona |
|---------|---------------|
| **Prima persona** | Mirino al centro dello schermo; si parte da questa quando si entra nel mondo |
| **Terza persona** | La camera sta 4 blocchi dietro agli occhi e si avvicina se c'è un muro, per non entrarci; si mira come in prima persona |
| **Isometrica** | Ruotabile, con i tasti relativi alla telecamera; non è la visuale di partenza |

La quarta visuale di Minecraft (di fronte) non c'è. Finché non esistono i personaggi veri, in terza persona e in isometrica il corpo è una scatola segnaposto della misura del personaggio. Il gioco non dipende mai dalla visuale scelta.

---

## ❓ FAQ

**D: Posso portare un personaggio creativo in un mondo sopravvivenza?**
R: No. I personaggi vivono nel loro mondo ([Persistenza del mondo](/wiki/persistenza-del-mondo)).

**D: Nel mio mondo creativo passo a sopravvivenza e poi torno creativo?**
R: Sì, da solo sempre; su un server solo se sei admin.

---

## 🔗 Vedi anche

- [Persistenza del mondo](/wiki/persistenza-del-mondo) — cosa viene salvato e quando
- [Morte e fantasmi](/wiki/morte-e-fantasmi) — cosa succede quando muori (in sopravvivenza)
- [Regolamento](/wiki/regolamento) — le regole del server
- [Il Mondo](/wiki/mondo) — come è fatto il mondo
