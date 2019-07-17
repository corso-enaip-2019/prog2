using System;
using System.Collections.Generic;

namespace Exercise_01_Imperative
{
    class Program
    {
        // ESERCIZIO SUI DIVERSI PARADIGMI DI PROGRAMMAZIONE

        // Di progetto in progetto vedremo come passare dal paradigma imperativo più vecchio
        // al paradigma ad oggetti.

        // IL PROBLEMA DA RISOLVERE
        /*
         * Dobbiamo implementare un sistema di gestione delle partite IVA.
         * In un ciclo infinito, ad ogni iterazione viene chiesto all'utente cosa vuole.
         * Ci sono 4 opzioni:
         * 1) aggiungere una fattura ad una certa partita IVA
         * 2) aggiungere una spesa ad una certa partita IVA
         * 3) calcolare guadagno totale e tasse totali da pagare su una certa partita IVA
         * 4) visualizzare l'elenco di partite IVA
         * 
         * Ogni partiva IVA è identificata da un codice alfanumerico univoco.
         * Le partite IVA sono di due tipi:
         * 1) "Normali": hanno un elenco di fatture e un elenco di spese.
         *     Per calcolare la posizione fiscale va calcolato:
         *         - il guadagno lordo (totale fatture meno totale spese)
         *         - su questo va tolto il 22% di IVA
         *         - sul rimanente va tolto il 23% di IRPEF
         * 2) "Semplici": hanno solo un elenco di fatture.
         *     Per calcolare la posizione fiscale va calcolato:
         *         - l'ammontare tassabile, che è il 78% del totale delle fatture
         *         - il netto che rimane, togliendo al tassabile il 15% di tassazione unica.
         *         
         *  Se l'utente seleziona una delle prime 3 operazioni, va chiesto il codice
         *  della partita IVA da modificare.
         *  Se il codice non corrisponde ad alcuna partita IVA, va stampato un messaggio di errore,
         *  NON va creata una partiva IVA nuova.
         *  Se l'utente ha selezionato "aggiungi spese" e poi ha inserito il codice
         *  di una partita IVA semplice, va stampato un messaggio di errore
         *  (non si possono inserire spese su una partita IVA semplice).
         */

        static void Main(string[] args)
        {
            // prima di precipitarci a scrivere codice,
            // cerchiamo di stendere lo scheletro di quella che è la logica,
            // in forma di commenti indentati:

            // inizializza dati mock

            while(true)
            {
                // elenco opzioni
                // input opzione da utente

                // switch sull'opzione scelta

                // opzione 1
                    // chiedi code
                    // trova vat corrispondente
                    // if (vat trovato)
                        // chiedi Bill
                        // aggiungi Bill a vat
                    // else
                        // errore "vat non trovato"

                // opzione 2
                    // chiedi code
                    // trova vat corrispondente
                    // if (vat trovato)
                        // if (vat normal)
                            // chiedi expense
                            // aggiungi expense a vat
                        // else
                            // errore "tipo 'Simple' non ha spese"
                    // else
                        // errore "vat non trovato"

                // opzione 3
                    // chiedi code
                    // trova vat corrispondente
                    // if (vat trovato)
                        // if (vat normal)
                            // calcoli vat normale
                        // else
                            // calcoli vat simple
                    // else
                        // errore "vat non trovato"

                // opzione 4
                    // itera su vat e stampa code
            }
        }
    }
}
