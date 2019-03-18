using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 20190305 */
/* Esercizi con Stack e Queue. */
/* Controllo parentesi pendenti. */

namespace CnsApp02Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            bool rePlay = true;

            while (rePlay)
            {
                string modalitaScelta = "indeterminata";
                string esito = "Ci/Non ci";
                string stringaProntaEsito = "sono parentesi pendenti";
                string invitoInputTesto = "Immettere un testo con parentesi.\n\a";

                string InputTesto = "?";

                bool tutteParentesiChiuse = true;

                #region Scelta modalita
                bool modalitaSensata = false;
                while (!modalitaSensata)
                {
                    Console.WriteLine("Immettere la modalità voluta fra:");
                    Console.WriteLine("\t\"sw\"\t\"Switch\";");
                    Console.WriteLine("\t\"qu\"\t\"Queue\";");
                    Console.WriteLine("\t\"st\"\t\"Stack\";");
                    Console.Write("\t\a");

                    modalitaScelta = Console.ReadLine().ToLower();

                    if ((modalitaScelta == "sw") || (modalitaScelta == "switch") || (modalitaScelta == "qu") || (modalitaScelta == "queue") || (modalitaScelta == "st") || (modalitaScelta == "stack"))
                    { modalitaSensata = true; }
                    else
                    {
                        Console.WriteLine("\aInput non valido!");
                        modalitaSensata = false;
                    }
                }
                #endregion

                Console.Write("La modalità scelta è: ");
                switch (modalitaScelta.ToLower())
                {
                    case "sw":
                    case "switch":
                        {
                            Console.WriteLine("Switch.");
                            Console.WriteLine(invitoInputTesto);
                            InputTesto = Console.ReadLine();
                            tutteParentesiChiuse = CheckBracketsSwitch(InputTesto);
                            break;
                        }
                    case "qu":
                    case "queue":
                        {
                            Console.WriteLine("Queue.");
                            Console.WriteLine(invitoInputTesto);
                            InputTesto = Console.ReadLine();

                            tutteParentesiChiuse = CheckBracketsQueue(InputTesto);
                            break;
                        }
                    case "st":
                    case "stack":
                        {
                            Console.WriteLine("Stack.");
                            Console.WriteLine(invitoInputTesto);
                            InputTesto = Console.ReadLine();
                            tutteParentesiChiuse = CheckBracketsStack(InputTesto);
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("Modalità non disponiible.");
                            break;
                        }
                }

                esito = tutteParentesiChiuse ? "Non ci" : "Ci";
                Console.WriteLine($"{esito} {stringaProntaEsito}");
                
            }

            Console.Write("Immettere \"q\" per uscire, altrimenti replay. \a");
            rePlay = (Console.ReadLine().ToLower() != "q") ? true : false;

            return;
        }



        #region Controllo numero coerente parentesi
        /// <summary>
        /// Verifica se il testo passato contiene un numero coerente di parentesi d'apertura e chiusura.
        /// Controlla le parentesi tonde « ( », quadre « [ » e graffe « { ».
        /// Lavora con lo switch.
        /// </summary>
        /// <param name="inText"></param>
        /// <returns>bool: true = n° coerente / false = n° incoerente</returns>
        static bool CheckBracketsSwitch(string inText)
        {
            int tondePendenti = 0, quadrePendenti = 0, graffePendenti = 0;

            if (inText == string.Empty)
            { return true; }
            for (int i = 0; i < inText.Length; i++)
            {
                switch (inText[i])
                {
                    case '(':
                        {
                            tondePendenti++;
                            break;
                        }
                    case ')':
                        {
                            tondePendenti--;
                            break;
                        }
                    case '[':
                        {
                            quadrePendenti++;
                            break;
                        }
                    case ']':
                        {
                            quadrePendenti--;
                            break;
                        }
                    case '{':
                        {
                            graffePendenti++;
                            break;
                        }
                    case '}':
                        {
                            graffePendenti--;
                            break;
                        }

                    default:
                        { break; }
                }
            }

            bool TutteParentesiChiuse = ((tondePendenti == 0) && (quadrePendenti == 0) && (graffePendenti == 0)) ? true : false;

            return TutteParentesiChiuse;
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

            //int tondePendenti = 0, quadrePendenti = 0, graffePendenti = 0;

            /* Creazione e popolamento Queue di parentesi "(" -> ")" -> "[" -> "]" -> "{" -> "}". */
            string parentesiDaUsare = "()[]{}";
            Queue<char> codaDiParentesi = new Queue<char>();
            for (int i = 0; i < parentesiDaUsare.Length; i++)
            {
                codaDiParentesi.Enqueue(parentesiDaUsare[i]);
            }

            // Commentato via.
            #region Popolamento per lungo old
            /*
            Queue<char> codaDiParentesi = new Queue<char>();
            codaDiParentesi.Enqueue('(');
            codaDiParentesi.Enqueue(')');
            codaDiParentesi.Enqueue('[');
            codaDiParentesi.Enqueue(']');
            codaDiParentesi.Enqueue('{');
            codaDiParentesi.Enqueue('}');
            */
            #endregion

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
        /// Verifica se il testo passato contiene un numero coerente di parentesi d'apertura e chiusura.
        /// Controlla le parentesi tonde « ( », quadre « [ » e graffe « { ».
        /// Lavora con lo Stack.
        /// </summary>
        /// <param name="inText"></param>
        /// <returns>bool: true = n° coerente / false = n° incoerente</returns>
        static bool CheckBracketsStack(string inText)
        {
            int parentesiCorrentiPendenti = 0;

            if (inText == string.Empty)
            { return true; }

            /* Creazione e popolamento Stack di parentesi "(" -> ")" -> "[" -> "]" -> "{" -> "}". */
            string parentesiDaUsare = "()[]{}";
            Stack<char> stackDiParentesi = new Stack<char>();
            for (int i = 0; i < parentesiDaUsare.Length; i++)
            { stackDiParentesi.Push(parentesiDaUsare[i]); }


            while (stackDiParentesi.Count > 0)
            {
                char parentesiCorrente = '?';

                /* Chiusura. */
                /* Prendo ed elimino l' uscita della Queue (parentesi in chiusura) come char d'utilizzare per il confronto. */
                parentesiCorrente = stackDiParentesi.Pop();
                for (int i = 0; i < inText.Length; i++)
                {
                    if (parentesiCorrente == inText[i])
                    { parentesiCorrentiPendenti++; }
                }

                /* Apertura. */
                /* Prendo ed elimino l' uscita della Queue (parentesi in apertura) come char d'utilizzare per il confronto. */
                parentesiCorrente = stackDiParentesi.Pop();
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
        #endregion  
    }
}