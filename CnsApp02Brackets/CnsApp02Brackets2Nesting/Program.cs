using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 20190305 */
/* Esercizi con Stack e Queue. */
/* Controllo parentesi pendenti + Controllo dell'inestamento. */

// !!!!! Da completare controllo nesting!
// !!!!! Da fare il "///" di "OnlyParenthesisFromString()"!

namespace CnsApp02Brackets2Nesting
{
    class Program
    {
        static void Main(string[] args)
        {
            bool rePlay = true;

            while (rePlay)
            {
                #region Variabili
                string esito = "Ci/Non ci";
                string stringaProntaEsito = "sono parentesi pendenti";
                string invitoInputTesto = "Immettere un testo con parentesi.\n\a";
                string esitoInnestamento1 = "Le parentesi";
                string esitoInnestamento2Si = "sono";
                string esitoInnestamento2No = "non sono";
                string esitoInnestamento3 = "state innestate correttamente.";

                /*
                 #region Stringhe per messaggi all'utente
                string messageResultPendingParenthesis1Yes = "Ci";
                string messageResultPendingParenthesis1No = "Non ci";
                string messageResultPendingParenthesis2 = "sono parentesi pendenti";

                string inviteToTextInput = "Immettere un testo con parentesi da controllare.\n\a";
                
                string resultNesting1 = "Le parentesi";
                string resultNesting2Yes = "sono";
                string resultNesting2No = "non sono";
                string resultNesting3 = "state innestate correttamente.";
                #endregion
                */

                string InputTesto = "?";

                bool tutteParentesiChiuse = true;
                #endregion

                #region Input
                Console.WriteLine(invitoInputTesto);
                InputTesto = Console.ReadLine();
                #endregion

                #region Controllo Parentesi pendenti
                tutteParentesiChiuse = CheckBracketsQueue(InputTesto);

                esito = tutteParentesiChiuse ? "Non ci" : "Ci";
                Console.WriteLine($"{esito} {stringaProntaEsito}");
                #endregion

                #region Controllo Innestamento parentesi
                if (tutteParentesiChiuse)
                {
                    bool innestamentoCorretto = false;
                    innestamentoCorretto = NestingCheck(InputTesto);
                    if (innestamentoCorretto)
                    { Console.WriteLine($"{esitoInnestamento1} {esitoInnestamento2Si} {esitoInnestamento3}"); }
                    else
                    { Console.WriteLine($"{esitoInnestamento1} {esitoInnestamento2No} {esitoInnestamento3}"); }
                }
                #endregion

                Console.Write("Immettere \"q\" per uscire, altrimenti replay. \a");
                rePlay = (Console.ReadLine().ToLower() != "q") ? true : false;
            }

            return;
        }



        /// <summary>
        /// Verifica se il testo passato contiene un numero coerente di parentesi d'apertura e chiusura.
        /// Controlla le parentesi tonde « ( », quadre « [ » e graffe « { ».
        /// Lavora con le Queue.
        /// </summary>
        /// <param name="inText"></param>
        /// <returns>bool: true = n° coerente / false = n° incoerente</returns>
        static bool CheckBracketsQueue(string inText)
        {
            int parentesiCorrentiPendenti = 0;

            if (inText == string.Empty)
            { return true; }

            /* Creazione e popolamento Queue di parentesi. */
            string parentesiDaUsare = "()[]{}";
            Queue<char> codaDiParentesi = new Queue<char>();
            for (int i = 0; i < parentesiDaUsare.Length; i++)
            {
                codaDiParentesi.Enqueue(parentesiDaUsare[i]);
            }

            while (codaDiParentesi.Count > 0)
            {
                char parentesiCorrente = '?';

                /* Apertura. */
                /* Prendo ed elimino l' uscita della Queue (parentesi in apertura) come char d'utilizzare per il confronto. */
                parentesiCorrente = codaDiParentesi.Dequeue();
                for (int i = 0; i < inText.Length; i++)
                {
                    if (parentesiCorrente == inText[i])
                    { parentesiCorrentiPendenti++; }
                }

                /* Chiusura. */
                /* Prendo ed elimino l' uscita della Queue (parentesi in chiusura) come char d'utilizzare per il confronto. */
                parentesiCorrente = codaDiParentesi.Dequeue();
                for (int i = 0; i < inText.Length; i++)
                {
                    if (parentesiCorrente == inText[i])
                    { parentesiCorrentiPendenti--; }
                }

                /* Controllo se sono a 0 (-> n°Aperture=n°Chiusure, nel caso non lo siano esce con un false). */
                if (parentesiCorrentiPendenti != 0)
                { return false; }

                /* Non serve reimpostare a 0 perché se non è 0 esce prima del prossimo ciclo. */
            }

            return true;
        }



        /// <summary>
        /// Verifica se il testo passato ha le parentesi innestate correttamente.
        /// NON fa il controllo del numero coerente di paretesi.
        /// </summary>
        /// <param name="inText"></param>
        /// <returns>bool: true = tutte parentesi innestate correttamente / false = innestamento errato.</returns>
        static bool NestingCheck(string inText)
        {
            if (inText == string.Empty)
            { return true; }

            List<char> testoSoloParentesi = new List<char>();

            /* Creazione e popolamento delle liste di parentesi (aperture e chiusure). */
            List<char> parentesiAperte = new List<char>() { '(', '[', '{' };
            List<char> parentesiChiuse = new List<char>() { ')', ']', '}' };

            testoSoloParentesi = OnlyParenthesisFromString(inText);

            /* Se non ci sono parentesi l'innnestamento è già pronto. */
            if (testoSoloParentesi.Count < 1)
            { return true; }




            return false;
        }



        /// <summary>
        /// Verifica se il char immesso è una parentesi.
        /// </summary>
        /// <param name="CurrentChar"></param>
        /// <returns>bool: true = E' una parentesi / false = Non è una parentesi.</returns>
        static bool ThisCharIsAParenthesis(char currentChar)
        {
            string parenthesisList = "()[]{}";
            if (parenthesisList.Contains(currentChar))
            { return true; }

            return false;
        }



        static List<char> OnlyParenthesisFromString(string InText)
        {
            List<char> testoInLavoro = new List<char>();

            

            /* "Eliminazione" di tutto ciò che non è parentesi dal testo d'input (in realtà crea una nuova lista composta solo da parentesi). */
            for (int i = 0; i < InText.Length; i++)
            {
                /* Controlla se è una parentesi, 
                 * V -> se lo è, aggiungi char a testoInLavoro 
                 * X -> altrimenti no (passa direttamente al prossimo ciclo). */
                if (ThisCharIsAParenthesis(InText[i]))
                { testoInLavoro.Add(InText[i]); }
            }

            #region testTemp Output solo parentesi
            for (int i = 0; i < testoInLavoro.Count; i++)
            { Console.Write(testoInLavoro.ElementAt(i).ToString()); }
            Console.WriteLine();
            #endregion

            return testoInLavoro;
        }
    }
}