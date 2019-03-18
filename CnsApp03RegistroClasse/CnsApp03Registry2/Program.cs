using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CnsApp03Registry2
{
    class Program
    {
        static void Main(string[] args)
        {
            const int HOW_MANY_YEARS = 5;
            const bool PRE_POPULATE_REGISTRIES = true;

            #region Preparazione registri vuoti
            /* Creazione del Registro Totale. */
            FullRegistry totalRegistry = new FullRegistry();

            /* Inserimento nel Registro Totale di X nuovi "Grade" (Classi: I, II, III ...) vuoti. */
            for (int i = 1; i <= HOW_MANY_YEARS; i++)
            {
                /* Ricavo dal numero (del ciclo) il "nome" (il numero romano corrispondente) del "Grade". */
                string gradeSName = From_IntArab_To_StrRoman_From1To24_Lazy(i);
                /* Genero un nuovo "Grade" vuoto. */
                Grade singleYearRegistry = new Grade(gradeSName);
                /* Aggiungo il "Grade" appena creato al Registro Totale tramite il suo metodo pubblico (del Registro Totale). */
                totalRegistry.RegisterGrade(i, singleYearRegistry);

                /* Se il Dictionary «totalRegistry.RegisteredGrade» fosse public,
                 * sarebbe esposta direttamente la lista.
                 * (per esempio è possibile fare un «.Clear()» che la piallerebbe). */
                // totalRegistry.RegisteredGrade.Add(i, singleYearRegistry);
            }

            #region Pre-popolamento registri
            if (PRE_POPULATE_REGISTRIES)
            {

            /* Genero un nuovo studente. */
            Student preStudent11 = new Student("pre-primina");
            /* Aggiungo lo studente a quello specifico "Grade", tramite il metodo pubblico del "Registro Totale" (tramite il metodo del "Grade"). */
            totalRegistry.AddStudentToNumberedGrade(preStudent11, 1);

            Student preStudent12 = new Student("pre-primino");
            totalRegistry.AddStudentToNumberedGrade(preStudent12,1);
            Student preStudent21 = new Student("pre-seconda");
            totalRegistry.AddStudentToNumberedGrade(preStudent21,2);
            Student preStudent22 = new Student("pre-secondo");
            totalRegistry.AddStudentToNumberedGrade(preStudent22,2);
            Student preStudent31 = new Student("pre-terza");
            totalRegistry.AddStudentToNumberedGrade(preStudent31,3);
            Student preStudent32 = new Student("pre-terzo");
            totalRegistry.AddStudentToNumberedGrade(preStudent32,3);
            Student preStudent41 = new Student("pre-quarta");
            totalRegistry.AddStudentToNumberedGrade(preStudent41,4);
            Student preStudent42 = new Student("pre-quarto");
            totalRegistry.AddStudentToNumberedGrade(preStudent42,4);
            Student preStudent51 = new Student("pre-quinta");
            totalRegistry.AddStudentToNumberedGrade(preStudent51,5);
            Student preStudent52 = new Student("pre-quinto");
            totalRegistry.AddStudentToNumberedGrade(preStudent52,5);
            }
            #endregion



            Dictionary<int, List<string>> fullRegistry = new Dictionary<int, List<string>>();

            /* Inserimento nel Dictionary di X nuove Liste. */
            for (int i = 1; i <= HOW_MANY_YEARS; i++)
            {
                List<string> singleYearBasedRegistry = new List<string>();
                fullRegistry.Add(i, singleYearBasedRegistry);
            }
            #endregion

            #region Pre-popolamento registri0
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
    }
}