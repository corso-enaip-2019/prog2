using System;
using System.Collections.Generic;

namespace _04_ExtensionMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * L'ereditarietà classica di C# ha alcuni problemi:
             * 1) non posso ereditare da più classi, solo da una.
             *     In caso di più feature tra una classe derivata e l'altra, ho duplicazione di codice 
             * 2) Se la classe che uso è 'sealed', cioè non posso derivarla, vuol dire che non posso aggiungerci funzionalità.
             * 3) Se devo aggiungere la stessa funzionalità a N classi diverse, devo duplicare il codice N volte.
             * 
             * Per questo, in programmazione si è inventato il concetto di MIXIN:
             * Una classe ha le sue funzionalità di base, poi posso agganciarci dall'esterno altre funzionalità.
             * 
             * Nel caso di C#, per ottenere questo sono stati introdotti i METODI D'ESTENSIONE.
             * 
             * Un M.E. è un metodo statico che viene dichiarato in una classe statica e ha nel primo parametro la keyword 'this' (vedi in fondo).
             */


            List<string> list = new List<string>
            {
                "ciao",
                "123",
                "",
                "pippo",
            };

            // siccome Filter è un metodo d'estensione,
            // non serve che scrivo: IEnumerable<string> result = Program.Filter(list, x => x.Length < 3);
            // Posso scrivere direttamente:
            IEnumerable<string> result = list.Filter(x => x.Length < 3);
            // Come se Filter fosse un metodo d'istanza delle List<T>!
            // => Ho aggiunto funzionalità a una classe di .NET "bloccata", 'List<T>'.

            string[] array = new[]
            {
                "ciao",
                "123",
                "",
                "pippo",
            };

            // Lo stesso metodo d'estensione vale per gli array:
            IEnumerable<string> resultFromArray = array.Filter(x => x.Length < 3);

            // Questo perché ho dichiarato il primo parametro del M.E. come 'IEnumerable<T>',
            // quindi qualsiasi collezione (liste, array, set...) che implementa quell'interfaccia
            // si ritrova quel metodo in più.

            // il metodo d'estensione Filter non si può applicare agli 'int',
            // perché gli 'int' NON implementano 'IEnumerable<T>':
            //int i = 5;
            //i.Filter(x => x < 3);
        }
    }

    static class Extensions
    {
        // con il 'this', io creo il metodo d'estensione,
        // che posso usare su un oggetto come se fosse un metodo suo.
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> input, Filter<T> condition)
        {
            List<T> output = new List<T>();

            foreach (T item in input)
                if (condition(item))
                    output.Add(item);

            return output;
        }

    }

    delegate bool Filter<T>(T item);
}
