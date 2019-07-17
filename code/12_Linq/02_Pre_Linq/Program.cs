using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_Pre_Linq
{
    /*
     * In questa seconda implementazione, separiamo l'algoritmo di filtro dell'intera lista
     * dal filtro del singolo elemento.
     * In questo modo posso riutilizzare la stessa funzione Filter con N filtri singoli diversi, senza duplicazione.
     * Il filtro è rappresentato da un oggetto che implementa l'interfaccia IFilter<T>.
     * 
     * Usando poi i generics, separo l'algoritmo dal tipo specifico degli item della collezione,
     * così posso riutilizzare il metodo Filter<T> su collezioni di qualsiasi tipo,
     * anche tipi custom inventati successivamente.
     */
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = CreateMockList();

            // FILTER OPERATIONS
            IEnumerable<string> shorts = Filter<string>(list, new ShortStringFilter());
            IEnumerable<string> convertibles = Filter<string>(list, new ConvertibleInNumberFilter());
            IEnumerable<string> startWithAs = Filter<string>(list, new StartsWithFilter('a'));

            foreach (string s in shorts)
                Console.WriteLine(s);
            Console.WriteLine();

            foreach (string s in convertibles)
                Console.WriteLine(s);
            Console.WriteLine();

            foreach (string s in startWithAs)
                Console.WriteLine(s);
            Console.WriteLine();


            // PROJECTION OPERATIONS
            IEnumerable<int> lengths = Project(list, new LengthFromStringProjector());
            foreach (int i in lengths)
                Console.WriteLine(i);
            Console.WriteLine();

            IEnumerable<string> inverteds = Project(list, new InvertStringProjector());

            foreach (string s in inverteds)
                Console.WriteLine(s);
            Console.WriteLine();

            Console.Read();
        }

        private static List<string> CreateMockList()
        {
            return new List<string>
            {
                "ciao",
                "22",
                "pirottino123",
                "543",
                "12.12",
                "",
                "assorrete"
            };
        }

        // Attraverso i parametri generic divido l'algoritmo dai tipi.
        // In questo modo riutilizzo l'algoritmo su tipi diversi.
        private static IEnumerable<T> Filter<T>(IEnumerable<T> input, IFilter<T> condition)
        {
            List<T> output = new List<T>();

            foreach (T item in input)
                if (condition.Filter(item))
                    output.Add(item);

            return output;
        }

        // Nel caso di una proiezione da una collezione all'altra, ho bisogno di 2 parametri generics,
        // uno per il tipo di input e uno per il tipo di output.
        // Quando uso questo metodo, dovrò specificare due tipi concreti, e non uno solo come in Filter<T>.
        private static IEnumerable<TOutput> Project<TInput, TOutput>(IEnumerable<TInput> input, IProject<TInput, TOutput> projection)
        {
            List<TOutput> output = new List<TOutput>();

            foreach (TInput item in input)
            {
                TOutput projected = projection.Project(item);
                output.Add(projected);
            }

            return output;
        }
    }

    interface IFilter<T>
    {
        bool Filter(T item);
    }

    class ShortStringFilter : IFilter<string>
    {
        // poiché ho specificato che il tipo 'T' è 'string',
        // l'implementazione dell'interfaccia sostitusce a 'T' il tipo 'string'.
        public bool Filter(string s)
        {
            return s.Length < 3;
        }
    }

    class ConvertibleInNumberFilter : IFilter<string>
    {
        public bool Filter(string s)
        {
            return int.TryParse(s, out int _);
        }
    }

    class StartsWithAFilter : IFilter<string>
    {
        public bool Filter(string s)
        {
            return s.StartsWith('a') || s.StartsWith('A');
        }
    }

    class StartsWithFilter : IFilter<string>
    {
        private char _initialLower;
        private char _initialUpper;

        public StartsWithFilter(char initial)
        {
            _initialLower = char.ToLower(initial);
            _initialUpper = char.ToUpper(initial);
        }

        public bool Filter(string s)
        {
            return s.StartsWith(_initialLower) || s.StartsWith(_initialUpper);
        }
    }

    class NegativeDoubleFilter : IFilter<double>
    {
        // In questa classe invece il tipo concreto 'T' è un double,
        // quindi il metodo da implementare ha un parametro di tipo 'double'.
        public bool Filter(double item)
        {
            return item < 0;
        }
    }

    interface IProject<TInput, TOutput>
    {
        TOutput Project(TInput item);
    }

    class LengthFromStringProjector : IProject<string, int>
    {
        public int Project(string item)
        {
            return item.Length;
        }
    }

    class InvertStringProjector : IProject<string, string>
    {
        public string Project(string item)
        {
            string result = "";

            for (int i = item.Length - 1; i >= 0; i--)
                result += item[i];

            return result;
        }
    }
}
