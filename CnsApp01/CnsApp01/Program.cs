using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 20190301 */

namespace CnsApp01
{
    class Program
    {
        static void Main(string[] args)
        {
            // Semplici esempi con gl'if
            // Commentato via.
            #region Esempi if 1
            /*
            int i = 1;
            i = i + 1;
            if (i > 1)
            {
                Console.WriteLine("\"i\" è maggiore di 1!");
            }
            else if (i > 2)
            {
                Console.WriteLine("\"i\" è maggiore di 1!");
            }
            else
            {
                Console.WriteLine("\"i\" NON è maggiore di 2!");
            }

            Console.WriteLine("Hello World!\a");
            Console.ReadLine();
            */
            #endregion

            /* Controllare se i tre numeri immessi dall'utente corrispondano alle seguenti regole:
             * a>b+c   b>a+c   c>a+b   a>|b-c| 
             * Se sono tutte valide _contemporaneamente_, sarà un triangolo. */
            #region Esempi if 2 - logica

            string[] str_ordinali = { "primo", "secondo", "terzo" };
            string valImmesso = "?";
            string esito;

            int[] lato = new int[3];

            bool w, x, y, z;

            #region Fase d'immissione dati
            for (int i = 0; i < 3; i++)
            {
                bool conversioneRiuscita = false;
                while (!conversioneRiuscita)
                {
                    Console.Write("Immettere il " + str_ordinali[i] + " valore: \a");
                    
valImmesso = Console.ReadLine();
                    conversioneRiuscita = int.TryParse(valImmesso, out lato[i]);
                }
            }
            #endregion

            #region Controllo se è un triangolo
            // a »-» lato[0]
            // b »-» lato[1]
            // a »-» lato[2]

            // a < (b + c)
            w = (lato[0] < (lato[1] + lato[2])) ? true : false;

            // b < (a + c)
            x = (lato[1] < (lato[0] + lato[2])) ? true : false;

            // c < (a + b)) ? true : false;
            y = (lato[2] < (lato[0] + lato[1])) ? true : false;

            // a > |b-c|
            z = (lato[0] > (Math.Abs(lato[1] - lato[2]))) ? true : false;
            // |b-c|   »-»   Math.Abs(b-c)

            esito = (w && x && y && z) ? "E\' un triangolo." : "Non è un triangolo.";
            #endregion

            #region Output
            Console.WriteLine(esito);
            Console.ReadLine();
            #endregion

            #endregion

            /* Con funzioni()
             * Controllare se i tre numeri immessi dall'utente corrispondano alle seguenti regole:
             * a>b+c   b>a+c   c>a+b   a>|b-c| 
             * Se sono tutte valide _contemporaneamente_, sarà un triangolo. */
            #region Esempi if 3 - con funzioni()


            string esitoFinale;
            // Lati
            int a, b, c;
            // Test per controllare se è un triangolo
            bool Test1, Test2, Test3, Test4;

            #region Fase d'immissione dati
            a = AskAndCheckNumber("Inserisci il primo lato:\t\a");
            b = AskAndCheckNumber("Inserisci il secondo lato:\t\a");
            c = AskAndCheckNumber("Inserisci il terzo lato:\t\a");
            #endregion

            #region Controllo se è un triangolo
            // a < (b + c)
            Test1 = (a < (b + c)) ? true : false;

            // b < (a + c)
            Test2 = (b < (a + c)) ? true : false;

            // c < (a + b)) ? true : false;
            Test3 = (c < (a + b)) ? true : false;

            // a > |b-c|
            Test4 = (a > (Math.Abs(b - c))) ? true : false;
            // |b-c|   »-»   Math.Abs(b-c)

            esitoFinale = (Test1 && Test2 && Test3 && Test4) ? "E\' un triangolo." : "Non è un triangolo.";
            #endregion

            #region Output
            Console.WriteLine(esitoFinale);
            Console.ReadLine();
            #endregion
            
            
            
            #endregion
        }

        /// <summary>
        /// Mostra all'utente il messaggio d'immissione (in input) e
        /// prova a convertire il valore inserito in input in un intero (string->int).
        /// </summary>
        /// <param name="message">Messaggio mostrato all' utente.</param>
        /// <returns></returns>
        static int AskAndCheckNumber(string message)
        {
            int latoConvertito_str2int = 0;

            bool conversioneRiuscita = false;
            while (!conversioneRiuscita)
            {
                Console.Write(message);
                string valImmesso = Console.ReadLine();
                conversioneRiuscita = int.TryParse(valImmesso, out latoConvertito_str2int);

                // Dato immesso non valido NAN (no un int).
                if (!conversioneRiuscita)
                {
                    Console.WriteLine("Valore immesso non valido!\a");
                }

                // Se è un valore è <= a 0, non ha senso.
                if ((conversioneRiuscita) && (latoConvertito_str2int <= 0))
                {
                    Console.WriteLine("Valore immesso minore (od uguale)di zero!\a");
                    conversioneRiuscita = false;
                }
            }
            return latoConvertito_str2int;
        }
    }
}