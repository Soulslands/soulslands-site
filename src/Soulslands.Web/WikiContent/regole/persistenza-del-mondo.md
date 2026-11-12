---
title: Persistenza del mondo
slug: persistenza-del-mondo
category: Regole di gioco
visibility: Pubblica
---
# 💾 Persistenza del mondo
*Il tuo personaggio appartiene al mondo*

---

## 📜 Panoramica

In Soulslands **tutto vive sul server**. Il personaggio, il suo inventario, la banca, le case, le navi, gli animali domati, ogni blocco scavato o piazzato e ogni oggetto lasciato a terra sono salvati nel mondo condiviso. Non esiste nulla salvato sul tuo computer.

> ⚠️ Non funziona come Valheim o come un server privato di Minecraft: **non puoi portare il personaggio in un altro mondo**, né il tuo equipaggiamento esce mai dal mondo di Soulslands. Il personaggio e i suoi beni esistono solo qui, come in Ultima Online.

---

## 📦 Cosa viene salvato

| Cosa | Dove vive | Note |
|------|-----------|------|
| **Personaggio** (stat, skill, karma, fama, modalità di gioco) | Server | Esiste solo in questo mondo |
| **Modalità del mondo** (creativa o sopravvivenza) | Server | Scelta alla creazione, non cambia mai ([Modalità di gioco](/wiki/modalita-di-gioco)) |
| **Inventario e equipaggiamento** | Sul personaggio, nel mondo | Se muori resta nel corpo ([Morte e fantasmi](/wiki/morte-e-fantasmi)) |
| **Banca** | Server, accessibile da ogni banchiere | Una per personaggio, non per account. Sempre al sicuro, anche se muori |
| **Case e costruzioni** | Blocchi nel mondo | Visibili e raggiungibili da tutti; protette secondo le regole di [costruzione](/wiki/sistema-costruzioni) e di [territorio](/wiki/pietra-territorio-gilda) |
| **Contenitori** (casse, forzieri) | Nel mondo | Chiusi a chiave sono sicuri, ma un [Ladro](/wiki/classe-ladro) esperto può scassinarli fuori dalle case protette |
| **Navi e pet** | Nel mondo, dove li hai lasciati | Una nave abbandonata può essere abbordata |
| **Blocchi modificati** | Nel mondo | Chi scava una montagna la scava per tutti |
| **Oggetti a terra** | Nel mondo | Scompaiono dopo **1 ora** di mondo aperto se non sono dentro una casa; la durata è l'impostazione `ground_decay_seconds` del server ([Modalità di gioco](/wiki/modalita-di-gioco), sezione "Oggetti a terra") |

---

## 🧙 Nome e numero dei personaggi

*Scelte del PM per delega di Aruto, 18/10/2026; i valori si possono ancora tarare.*

| Regola | Valore |
|--------|--------|
| Lunghezza del nome | Da 3 a 16 caratteri |
| Caratteri ammessi | Lettere A-Z senza accenti, più spazio, apostrofo e trattino come separatori; niente cifre né altri simboli |
| Separatori | Mai all'inizio o alla fine, mai due di fila, al massimo due per nome (`Iolo Blackthorn`, `D'Arc` e `Anne-Marie` vanno bene; `X-Y-Z-W` no) |
| Unicità | Il nome è unico tra tutti i giocatori confrontando **solo le lettere**, senza maiuscole e separatori: `Anne Marie`, `Anne-Marie` e `AnneMarie` sono lo stesso nome |
| Dove si sceglie | Il nome del personaggio è il **nome Soulslands** del tuo account: lo scegli sul sito dello studio (dal launcher o dalla pagina dell'account) e su ogni server hai lo stesso nome. Non si sceglie più alla creazione del personaggio (**cambiato da Aruto, 26/10/2026**) |
| Cambio del nome | **Al massimo una volta all'anno** (**deciso da Aruto, 26/10/2026**). La prima scelta e il primo cambio non aspettano niente (una correzione gratis); un cambio che differisce solo per maiuscole o separatori non conta. Il vecchio nome resta riservato a te per 30 giorni |
| Parole riservate | Nessuna parola del nome può essere, per esempio, `admin`, `gm`, `staff`, `moderator`, `system`, `server`; la prima parola non può essere `lord` o `lady`, perché i titoli vengono da fama e karma |
| Personaggi per account | **Uno per account in ogni mondo**, come in Minecraft (**deciso da Aruto, 26/10/2026**; sostituisce i 5 per mondo del 18/10/2026). Niente schermata di creazione né di scelta: un mondo o un server nuovo ti dà un personaggio nuovo (zaino vuoto, abilità a 0) con lo stesso nome. Corpo e skin sono dell'account e non si salvano nel mondo; la razza sì, ed è l'Umano finché non la cambi |

La **classe** non si sceglie né si salva: i livelli di classe si calcolano dalle skill.

---

## 🎒 Contenitori e banca

| Contenitore | Limiti |
|-------------|--------|
| Zaino | 125 oggetti; il peso non ha un tetto proprio, lo limita il peso trasportabile del personaggio (vedi [Statistiche](/wiki/statistiche)) |
| Banca | 125 oggetti, nessun limite di peso |
| Borse e casse | 125 oggetti e 400 stone |

I contenitori si annidano fino a 8 livelli. La distanza per aprire un contenitore è di 3 blocchi.

---

## 🚪 Logout

Quando esci dal gioco il personaggio **non sparisce subito**.

| Dove fai logout | Cosa succede |
|-----------------|-------------|
| Dentro la tua **casa** o una **locanda** | Il personaggio scompare dal mondo immediatamente, al sicuro |
| Dentro un **feudo** con guardie | Il personaggio resta visibile per **30 secondi** |
| **Ovunque** altrove | Il personaggio resta nel mondo per **5 minuti**, attaccabile da mostri e giocatori |
| In combattimento o subito dopo un'aggressione | Il timer riparte: chi scollega per sfuggire a un combattimento lascia il personaggio indifeso |

> 💡 Prima di uscire nelle terre selvagge, costruisci un riparo chiuso e illuminato: non ferma i giocatori, ma tiene lontani i mostri (vedi [Spawn delle creature](/wiki/spawn-creature)).

---

## 🏚️ Decadimento

Un mondo può essere condiviso da moltissimi giocatori, ma i blocchi e le costruzioni non scompaiono da soli, come in Minecraft. I tempi indicati qui sono quelli predefiniti del server dedicato; chi ospita un server può cambiarli.

| Cosa | Quando decade |
|------|---------------|
| Oggetti lasciati a terra all'aperto | Dopo **1 ora** di mondo aperto (**deciso da Aruto, 10/11/2026**): il tempo passa solo mentre il server è acceso. Si cambia con l'impostazione `ground_decay_seconds` nella sezione `[items]` di `server.toml` (3600 secondi; da 60 secondi a 7 giorni, oppure 0 per non farli mai scomparire). Un chunk (32 blocchi di lato) tiene al massimo 1.024 oggetti sciolti a terra (impostazione `ground_per_chunk`, da 64 a 4.096): oltre, i più vecchi scompaiono prima del tempo |
| Corpi | Ossa dopo 20 minuti, spariscono dopo 30 |
| Case e costruzioni | **Mai**, per impostazione predefinita, anche se il proprietario non torna. Decadono solo se una regola del server lo attiva, con la durata che quella regola stabilisce |
| Costruzioni nel territorio di una gilda | Restano al loro posto; la [Pietra del Territorio](/wiki/pietra-territorio-gilda) ne decide la protezione, non la durata |
| Blocchi naturali scavati | **Non** ricrescono: il mondo resta come lo lasciate (gli alberi piantati invece crescono) |

---

## 🔒 Sicurezza dei dati

- Il mondo viene salvato continuamente e con copie di sicurezza regolari.
- **Salvataggio automatico:** il server chiude un'epoca di salvataggio ogni 5-10 secondi (5 per impostazione predefinita), quindi un guasto improvviso costa al massimo gli ultimi 10 secondi di gioco.
- **Pulsante Salva:** nel menu di pausa chiede un salvataggio subito, e sotto il pulsante compare l'ora dell'ultimo salvataggio confermato ("Non ancora salvato" prima del primo). Su un server dedicato lo vedono solo gli admin.
- **Uscendo:** "Salva ed esci al titolo" e la chiusura della finestra salvano prima di chiudere, con una schermata "Salvataggio del mondo".
- Il personaggio salva anche modalità di gioco e stato di volo (vedi [Modalità di gioco](/wiki/modalita-di-gioco)).
- Fonte: [ADR-0025](https://github.com/Soulslands/soulslands-game/blob/main/docs/adr/0025-creative-exploration-rules.md).
- Il salvataggio procede per epoche: ogni gruppo di modifiche conta solo quando è scritto per intero. Se il server si ferma di colpo, il mondo riparte dall'ultima epoca confermata, mai da una a metà, e nessun oggetto risulta perso o duplicato.
- In caso di problemi gravi lo staff può ripristinare il mondo a un salvataggio precedente: in quel caso tutti i giocatori tornano allo stesso momento.
- Lo staff **non restituisce** oggetti persi per morte, furto o saccheggio: fanno parte del gioco (vedi [Regolamento](/wiki/regolamento)).

---

## ❓ FAQ

**D: Posso avere più personaggi?**
R: No: un account ha **un solo personaggio in ogni mondo**, come in Minecraft (**deciso da Aruto, 26/10/2026**, vedi la tabella sopra). Un altro mondo o un altro server ti dà un personaggio nuovo, con la sua banca; gli oggetti non passano da un mondo all'altro.

**D: Se il server si riavvia perdo qualcosa?**
R: No: il salvataggio è continuo. Al massimo si perdono gli ultimi 10 secondi prima di un guasto improvviso.

---

*Vedi anche: [Modalità di gioco](/wiki/modalita-di-gioco) | [Il Mondo](/wiki/mondo) | [Morte e fantasmi](/wiki/morte-e-fantasmi) | [Sistema costruzioni](/wiki/sistema-costruzioni)*
