---
title: Karma e fama
slug: karma-e-fama
category: Regole di gioco
visibility: Pubblica
---
# ⚖️ Karma e fama

*Ciò che fai ti segue, e tutti possono leggerlo nel tuo nome*

---

## 📋 Indice

- [Panoramica](#panoramica)
- [Fama](#fama)
- [Karma](#karma)
- [Titoli](#titoli)
- [Colori del nome (notorietà)](#colori-del-nome-notorieta)
- [Azioni criminali](#azioni-criminali)

---

## 📜 Panoramica

Come in Ultima Online, ogni personaggio ha due valori di reputazione:

| Valore | Intervallo | Cosa misura |
|--------|-----------|-------------|
| **Fama** | 0 – 15.000 | Quanto sei famoso: cresce sconfiggendo creature pericolose, cala morendo e con il tempo |
| **Karma** | -15.000 – +15.000 | Quanto sei buono o malvagio: cresce con le buone azioni, cala con quelle malvagie |

Fama e karma insieme danno il tuo **titolo**. Il **colore del nome** invece dipende dalle tue azioni contro gli altri giocatori.

---

## 🏆 Fama

| Come si guadagna | Come si perde |
|------------------|---------------|
| Uccidere mostri pericolosi (più è forte il mostro, più fama) | Morire (perdi un decimo della fama) |
| Sconfiggere boss | Lento decadimento se non si combatte |
| Completare imprese e difese di città | — |

La fama conta anche per la **redenzione** dei personaggi rossi: più fama hai, più la purificazione di un [Chierico](/wiki/classe-chierico) può riportarti al blu (vedi [Player killer e redenzione](/wiki/player-killer-e-redenzione)).

---

## ☯️ Karma

| Azione | Effetto sul karma |
|--------|-------------------|
| Uccidere mostri malvagi (non-morti, demoni, orchi, banditi) | ⬆️ |
| Curare e resuscitare altri giocatori | ⬆️ |
| Purificare l'anima di un rosso (Chierici) | ⬆️⬆️ |
| Fare elemosina, aiutare i nuovi giocatori nelle missioni | ⬆️ |
| Uccidere creature buone (unicorni, ki-rin, delfini, pixie) | ⬇️ |
| Uccidere giocatori innocenti | ⬇️⬇️ |
| Rubare, saccheggiare corpi di innocenti | ⬇️ |
| Usare necromanzia e veleni su innocenti | ⬇️ |

> 💡 Il karma influisce su alcune creature (gli unicorni attaccano chi ha karma negativo, i ki-rin si lasciano domare solo da chi ha karma positivo) e su alcune arti sacre, come la [Chivalry](/wiki/skill-chivalry) dei [Templari](/wiki/classe-templare) e dei [Chierici](/wiki/classe-chierico).

---

## 📜 Titoli

Il titolo appare davanti al nome quando qualcuno ti esamina. Esempi (fama alta):

| Karma | Fama bassa | Fama alta |
|-------|-----------|-----------|
| Molto alto (oltre +10.000) | Stimato | **Gran Signore / Gran Dama** |
| Alto | Onorevole | Nobile |
| Neutro | — | Celebre |
| Basso | Losco | Famigerato |
| Molto basso (sotto -10.000) | Malvagio | **Signore Oscuro / Dama Oscura** |

---

## 🎨 Colori del nome (notorietà)

| Colore | Significato | Si può attaccare senza conseguenze? |
|--------|-------------|-------------------------------------|
| 🔵 **Blu** | Innocente | No: attaccarlo ti rende criminale, ucciderlo ti dà un'uccisione |
| ⚪ **Grigio** | Criminale (temporaneo, circa 2 minuti) o aggressore | Il criminale sì, da chiunque; l'aggressore solo da chi è coinvolto (chi ha colpito o è stato colpito) |
| 🟠 **Arancione** | Nemico della tua gilda in [guerra](/wiki/gilde) | Sì |
| 🟢 **Verde** | Membro della tua gilda, di una gilda alleata o del tuo party | Non conviene: è un alleato |
| 🔴 **Rosso** | Assassino ([player killer](/wiki/player-killer-e-redenzione)) | Sì, da chiunque, e le guardie lo attaccano |
| 🟡 **Giallo** | NPC invulnerabile (banchieri, guaritori, guardie) | No |

Se più colori valgono insieme, vince il più grave: rosso e criminale si vedono sopra verde e arancione, così un membro rosso della tua gilda resta rosso anche per te. Il giallo vince su tutto tranne che su sé stessi: un personaggio vede sé stesso nel proprio colore di base (rosso, criminale o blu), mai verde o arancione ([ADR-0013](https://github.com/Soulslands/soulslands-game/blob/main/docs/adr/0013-society-notoriety-world-services.md)).

---

## 🚨 Azioni criminali

Queste azioni ti rendono **grigio** per circa 2 minuti: chiunque può attaccarti senza conseguenze e le [guardie](/wiki/guardie-cittadine) intervengono se le chiamano.

- Attaccare per primo un giocatore blu.
- Saccheggiare il corpo di un giocatore blu che non sia della tua gilda o del tuo party.
- Farsi vedere mentre si ruba a un giocatore blu, o perdere la sfida del furto (vedi [Furto](/wiki/furto)). Uno snooping scoperto costa solo karma, e rubare a un rosso o a un grigio non è mai criminale.
- Danneggiare o uccidere l'animale domato di un altro giocatore blu.
- Scassinare contenitori di proprietà altrui.

Uccidere un giocatore blu ti dà un'**uccisione** (murder count) e, oltre una certa soglia, il nome **rosso**.

---

*Vedi anche: [Player killer e redenzione](/wiki/player-killer-e-redenzione) | [Guardie cittadine](/wiki/guardie-cittadine) | [Furto](/wiki/furto)*
