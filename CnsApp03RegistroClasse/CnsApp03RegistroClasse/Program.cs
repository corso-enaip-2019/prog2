using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 20190306 */
/* Esercizio con cicli, Dictionary, List. */
/* Input Nome+Classe(anno). */
/* Output Data classe -> Registro alunni. */

namespace CnsApp03RegistroClasse
{
    class Program
    {
        static void Main(string[] args)
        {
            const int HOW_MANY_YEARS = 5;

            #region Preparazione registri vuoti
            /* Creazione 1*Dictionary. */
            Dictionary<int, List<string>> fullRegistry = new Dictionary<int, List<string>>();

            /* Inserimento nel Dictionary di X nuove Liste. */
            for (int i = 1; i <= HOW_MANY_YEARS; i++)
            {
                List<string> singleYearBasedRegistry = new List<string>();
                fullRegistry.Add(i, singleYearBasedRegistry);
            }
            #endregion

            #region Pre-popolamento registri
            // [...]
            fullRegistry[1].Add("pre-primina");
            fullRegistry[1].Add("pre-primino");
            fullRegistry[2].Add("pre-seconda");
            fullRegistry[2].Add("pre-secondo");
            fullRegistry[3].Add("pre-terza");
            fullRegistry[3].Add("pre-terzo");
            #endregion

            bool rePlay = true;
            while (rePlay)
            {
                string selectedMode = "?";

                bool sensedSelectedMode = false;
                while (!sensedSelectedMode)
                {
                    selectedMode = ModeRequest();

                    switch (selectedMode.ToLower())
                    {
                        case "inputalumns":
                        case "a":
                            {
                                InsertSingleAlumn(out int alumnSYear, out string alumnSName);

                                /* Aggiunta dell'alunno Y al registro dell'anno X. */
                                fullRegistry[alumnSYear].Add(alumnSName);
                                fullRegistry[alumnSYear].Sort();

                                sensedSelectedMode = true;
                                break;
                            }

                        case "registriesview":
                        case "r":
                            {
                                /* Visualizza tutti i registri. */
                                RegistriesView(fullRegistry);

                                sensedSelectedMode = true;
                                break;
                            }

                        case "quit":
                        case "q":
                            {
                                rePlay = false;
                                sensedSelectedMode = true;
                                break;
                            }

                        default:
                            {
                                selectedMode = "?";
                                //sensedSelectedMode = false;
                                break;
                            }
                    }
                }

                Console.WriteLine();
            }

            return;
        }

        /// <summary>
        /// Richiesta della mode voluta.
        /// Senza controlli, solo output stringa immessa.
        /// </summary>
        /// <returns>Una stringa in ToLower.</returns>
        private static string ModeRequest()
        {
            Console.WriteLine("Immettere \"a\" per aggiungere alunni.");
            Console.WriteLine("Immettere \"r\" per leggere i registri.");
            Console.WriteLine("Immettere \"q\" per uscire.");
            Console.Write("\t\a");

            return Console.ReadLine().ToString().ToLower();
        }

        /// <summary>
        /// Richiede all'utente d'immettere un nome per l'alunno.
        /// Cicla finchè non viene immesso un dato valido (non vuoto).
        /// </summary>
        /// <returns>Stringa con il nome dell'alunno.</returns>
        static string InputAlumnSName()
        {
            string inviteToInsertName = "Immettere il nome dell\'alunno: \a";
            string invalidInputTxt = "Dato immesso non valido!";

            string inAlumnSName;

            string alumnSName = "";

            bool validInput = false;

            while (!validInput)
            {
                Console.WriteLine(inviteToInsertName);

                inAlumnSName = Console.ReadLine();

                if (inAlumnSName.Length > 0)
                {
                    alumnSName = inAlumnSName.ToUpper();
                    validInput = true;
                }
                else
                {
                    Console.WriteLine(invalidInputTxt);
                    //validInput = false;
                }
            }

            return alumnSName;
        }



        /// <summary>
        /// Richiede all'utente d'immettere l'anno frequentato dall'alunno.
        /// Cicla finchè non viene immesso un dato fra 1 e 5 (compresi).
        /// </summary>
        /// <returns>L'anno frequentato, un intero fra 1 e 5 (compresi).</returns>
        static int InputAlumnSYear()
        {
            string inviteToInsertYear = "Immettere la classe frequentata (1-5): \a";
            string invalidInputTxt = "Dato immesso non valido!";

            string inAlumnSYear;

            int AlumnSYear = -1;

            bool validInput = false;

            while (!validInput)
            {
                Console.WriteLine(inviteToInsertYear);
                inAlumnSYear = Console.ReadLine();

                int.TryParse(inAlumnSYear, out AlumnSYear);
                if ((AlumnSYear >= 1) && (AlumnSYear <= 5))
                { validInput = true; }
                else
                {
                    Console.WriteLine(invalidInputTxt);
                    validInput = false;
                }
            }

            return AlumnSYear;
        }

        /// <summary>
        /// Restituisce in uscita (2*out) l'anno frequentato ed il nome richiesti.
        /// </summary>
        /// <param name="name">OutPut - Nome dell'alunno.</param>
        /// <param name="alumnSYear">OutPut - Anno frequentato.</param>
        static void InsertSingleAlumn(out int alumnSYear, out string alumnSName)
        {
            alumnSName = InputAlumnSName();
            alumnSYear = InputAlumnSYear();
            Console.WriteLine($"Nome: {alumnSName}, in {alumnSYear}ª classe.");

            return;
        }

        /// <summary>
        /// Stampa a schermo tutti i singoli registri datigli come parametro d'ingresso.
        /// Usa la Console.
        /// </summary>
        /// <param name="fullRegistry">Un registro composto da Key->Anno (1-n, int), Value->List che contengono i singoli nomi (string).</param>
        static void RegistriesView(Dictionary<int, List<string>> fullRegistry)
        {
            foreach (var year in fullRegistry)
            {
                Console.WriteLine($"Classe: {year.Key.ToString()}ª:");
                foreach (var alumn in fullRegistry[year.Key])
                { Console.WriteLine($"\t{alumn.ToString()}"); }

                Console.WriteLine();
            }

            return;
        }

        /// <summary>
        /// Dato un intero 1-24,
        /// restituisce un numero romano (come stringa).
        /// Implementato con un semplice array.
        /// </summary>
        /// <param name="inIntArab">Un intero 1-24.</param>
        /// <returns>La stringa corrispondente; se l'imput è fuori i limiti, restituisce "3rr0r".</returns>
        static string From_IntArab_To_StrRoman_From1To24_Lazy(int inIntArab)
        {
            string[] romanNumerals = new string[25]
            {
                "3rr0r",
                "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X",
                "XI", "XII", "XIII", "XIV", "XV", "XVI", "XVII", "XVIII", "XIX", "XX",
                "XXI", "XXII", "XXIII", "XXIV"
            };

            return romanNumerals[inIntArab];
        }

        /// <summary>
        /// Dato un intero 1-3'999,
        /// restituisce un numero romano (come stringa).
        /// Implementato usando la recursione.
        /// </summary>
        /// <param name="inIntArab">Un intero 1-3'999.</param>
        /// <returns>La stringa corrispondente; se l'imput è fuori i limiti, restituisce "3rr0r".</returns>
        static string From_IntArab_To_StrRoman_From1To3999_Recursion(int inIntArab)
        { return "3rr0r"; }



        /// <summary>
        /// Dato un intero 1-3'999,
        /// restituisce un numero romano (come stringa).
        /// Implementato usando la base5.
        /// </summary>
        /// <param name="inIntArab">Un intero 1-3'999.</param>
        /// <returns>La stringa corrispondente; se l'imput è fuori i limiti, restituisce "3rr0r".</returns>


        static string From_IntArab_To_StrRoman_From1To3999_UsingBase5(int inIntArab)
        {
            #region Stringhe costanti
            /*
            const string ZZ = "3rr0r";
            const string u1 = "I";
            const string u5 = "V";
            const string d1 = "X";
            const string d5 = "L";
            const string h1 = "C";
            const string h5 = "D";
            const string k1 = "M";
            */
            #endregion

            if (inIntArab > 3999)
            { inIntArab = 0; }
            if (inIntArab < 1)
            { inIntArab = 0; }

            //incompleto
            string base5Number = FromBase10ToBase5_From0To3906250(inIntArab);

            /*
            string[] romanNumerals = new string[25]
            {
                "3rr0r",
                "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X",
                "XI", "XII", "XIII", "XIV", "XV", "XVI", "XVII", "XVIII", "XIX", "XX",
                "XXI", "XXII", "XXIII", "XXIV"
            };
            */

            #region Fuori limiti
            if (inIntArab < 1)
            { inIntArab = 0; }
            if (inIntArab > 3999)
            { inIntArab = 0; }
            #endregion

            //!!!!!!!!!
            return  "incomplete";
        }


        static string FromBase10ToBase5_From0To3906250(int inBase10)
        {
            int base5Number = 0;
            /*incomplete
            int exponent = 0;
            */
            #region Fuori limiti
            if (inBase10 < 0)
            { base5Number = -1; }

            /* 3'906'250[base10] = 2'000'000'000[base5] ... perché (max int32) = 2'147'483'647. */
            if (inBase10 > 3906250)
            { base5Number = -1; }
            #endregion

            //!!!!!!!!!!!!!!!! Da completare!!!!!!!
            while (inBase10 > 1)
            {
                inBase10 = inBase10 / 5;
            }

            return base5Number.ToString();
        }

    }
}
