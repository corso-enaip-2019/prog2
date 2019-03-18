using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 20190306 */
/* Esercizi con Stack e Queue. */
/* Controllo parentesi pendenti + Indicazione eventuali errori. */

namespace CnsApp02Brackets3ErrorRowCol
{
    class Program
    {

        /* Il programma deve controllare se le varie parentesi sono state chiuse, e se non succede si devono indicare la riga e la colonna dell'errore. */
        static void Main(string[] args)
        {
            bool rePlay = true;

            while (rePlay)
            {
                #region Stringhe per messaggi all'utente
                string inviteToTextInput = "Immettere un testo con parentesi da controllare.\n\a";

                string messageResultPendingBrackets1Yes = "Ci";
                string messageResultPendingBrackets1No = "Non ci";
                string messageResultPendingBrackets2 = "sono parentesi pendenti";

                string messageResultColRowError1 = "L\'errrore è presente al";
                string messageResultColRowError2 = "° carattere della";
                string messageResultColRowError3 = "ª riga.";
                #endregion

                #region Variabili
                string UserTextInput = "?";

                bool allBracketsAreClosed = true;

                int ErrorSColumn = 0, ErrorSRow = 0;

                #endregion

                #region Input
                Console.WriteLine(inviteToTextInput);
                UserTextInput = Console.ReadLine();
                #endregion

                #region Controllo Parentesi pendenti
                allBracketsAreClosed = CheckBracketsQueue(UserTextInput);

                messageResultPendingBrackets1Yes = allBracketsAreClosed ? messageResultPendingBrackets1No : messageResultPendingBrackets1Yes;

                Console.WriteLine($"{messageResultPendingBrackets1Yes} {messageResultPendingBrackets2}");
                #endregion

                /* Se ci sono parentesi non chiuse, individuarle. */
                #region Ricerca punto errori
                if (!allBracketsAreClosed)
                {
                    FindRowAndColumnOfPendingBrackets(UserTextInput, out ErrorSColumn, out ErrorSRow);
                    Console.WriteLine($"{messageResultColRowError1} {ErrorSColumn}{messageResultColRowError2} {ErrorSRow}{messageResultColRowError3}");
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
            int currentPendingBrackets = 0;//parentesiCorrentiPendenti

            if (inText == string.Empty)
            { return true; }

            /* Creazione e popolamento Queue di parentesi. */
            string bracketsToUse = "()[]{}";
            Queue<char> bracketsQueue = new Queue<char>();
            for (int i = 0; i < bracketsToUse.Length; i++)
            {
                bracketsQueue.Enqueue(bracketsToUse[i]);
            }

            while (bracketsQueue.Count > 0)
            {
                char currentBracket = '?';

                /* Apertura. */
                /* Prendo ed elimino l' uscita della Queue (parentesi in apertura) come char d'utilizzare per il confronto. */
                currentBracket = bracketsQueue.Dequeue();
                for (int i = 0; i < inText.Length; i++)
                {
                    if (currentBracket == inText[i])
                    { currentPendingBrackets++; }
                }

                /* Chiusura. */
                /* Prendo ed elimino l' uscita della Queue (parentesi in chiusura) come char d'utilizzare per il confronto. */
                currentBracket = bracketsQueue.Dequeue();
                for (int i = 0; i < inText.Length; i++)
                {
                    if (currentBracket == inText[i])
                    { currentPendingBrackets--; }
                }

                /* Controllo se sono a 0 (-> n°Aperture=n°Chiusure, nel caso non lo siano esce con un false). */
                if (currentPendingBrackets != 0)
                { return false; }

                /* Non serve reimpostare a 0 perché se non è 0 esce prima del prossimo ciclo. */
            }

            return true;
        }



        /// <summary>
        /// Verifica se il char immesso è una parentesi.
        /// </summary>
        /// <param name="CurrentChar"></param>
        /// <returns>bool: true = E' una parentesi / false = Non è una parentesi.</returns>
        static bool ThisCharIsAParenthesis(char CurrentChar)
        {
            string ParenthesisList = "()[]{}";
            if (ParenthesisList.Contains(CurrentChar))
            { return true; }

            return false;
        }

        /// <summary>
        /// Genera un Dictionary con le coppie di parentesi (), [] e {}.
        /// </summary>
        /// <returns>Un Dictionary con le coppie di parentesi (), [] e {}.</returns>
        static Dictionary<char, char> DictionaryOfBracketsGenerator()
        {
            /* Creazione e popolamento del Dictionary con le coppie (), [] e {}. */
            Dictionary<char, char> ParenthesisCouples = new Dictionary<char, char>
                {
                    {'(',')'},{'[',']'},{'{','}'}
                };
            return ParenthesisCouples;
        }


        /// <summary>
        /// Trova la riga e la colonna della parentesi mancante.
        /// Non controlla se ci sono parentesi pendenti.
        /// </summary>
        /// <param name="inText">Stringa da controllare.</param>
        /// <param name="errRow">OutPut - Riga dell'errore.</param>
        /// <param name="errColumn">OutPut - Colonna dell'errore</param>
        static void FindRowAndColumnOfPendingBrackets(string inText, out int errRow, out int errColumn)
        {
            errRow = -1;
            errColumn = -1;

            if (inText.Length == 1)
            {
                errRow = 1;
                errColumn = 1;
            }
            else
            {
                Stack<char> workText = new Stack<char>();

                /* Creazione e popolamento del Dictionary con le coppie (), [] e {}. */
                Dictionary<char, char> ParenthesisCouples = new Dictionary<char, char>();
                ParenthesisCouples = DictionaryOfBracketsGenerator();

                for (int i = inText.Length - 1; i < 1; i--)
                {

                }

                while (workText.Count > 1)
                {

                }
            }
            return;
        }

    }
}