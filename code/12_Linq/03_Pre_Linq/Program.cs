using System;
using System.Collections.Generic;

namespace _03_Pre_Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Smartphone> items = CreateMocks();

            // le classi e le interfacce dell'ultimo esercizio servivano solo per passare singoli metodi di filtro al metodo Filter.
            // A questo punto, invece di creare interi oggetti, usiamo i delegate.
            // Questa versione di Filter non accetta un intero oggetto di filtro, ma solo un singolo metodo
            // (vedi più avanti come è dichiarato il metodo Filter).
            // Possiamo quindi passare come parametro un metodo.
            // In questo caso, passiamo un metodo statico di Program dichiarato poco sotto:
            IEnumerable<Smartphone> blacks = Filter(items, FilterBlacks);

            // Possiamo però usare anche metodi anonimi:
            //IEnumerable<Smartphone> whites = Filter(items, delegate (Smartphone s) { return s.Color == "White"; });

            // I metodi anonimi sono più concisi in forma di lambda function.
            // Le lambda si possono scrivere in molti modi, qui sono presentate dalla più verbosa alla più sintetica:
            //IEnumerable<Smartphone> whites = Filter(items, (Smartphone s) => { return s.Color == "White";  });
            //IEnumerable<Smartphone> whites = Filter(items, (s) => { return s.Color == "White"; });
            //IEnumerable<Smartphone> whites = Filter(items, s => { return s.Color == "White"; });
            IEnumerable<Smartphone> whites = Filter(items, s => s.Color == "White");

            IEnumerable<Smartphone> cheaps = Filter(items, s => s.Price < 500);

            foreach (Smartphone sp in whites)
                Console.WriteLine($"{sp.Model} - {sp.Version} - {sp.Color}");
            Console.WriteLine();

            foreach (Smartphone sp in cheaps)
                Console.WriteLine($"{sp.Model} - {sp.Version} - {sp.Color}");

            Console.Read();
        }

        static List<Smartphone> CreateMocks()
        {
            return new List<Smartphone>
            {
                new Smartphone("iPhone", 8, "Grey", 1200),
                new Smartphone("Galaxy S8", 0, "White", 800),
                new Smartphone("Nokia", 3310, "White", 200),
            };
        }

        // questa funzione di filtro è limitata solo agli Smartphone:
        //static IEnumerable<Smartphone> Filter(IEnumerable<Smartphone> input, SmartphoneFilter condition)
        //{
        //    List<Smartphone> output = new List<Smartphone>();

        //    foreach (Smartphone item in input)
        //        if (condition(item))
        //            output.Add(item);

        //    return output;
        //}

        // questa versione di Filter è più flessibile, posso usarla con qualsiasi tipo 'T':
        static IEnumerable<T> Filter<T>(IEnumerable<T> input, Filter<T> condition)
        {
            List<T> output = new List<T>();

            foreach (T item in input)
                if (condition(item))
                    output.Add(item);

            return output;
        }

        static bool FilterBlacks(Smartphone s)
        {
            return s.Color == "Black";
        }

        static bool FilterShortStrings(string s)
        {
            return s.Length < 3;
        }
    }

    class Smartphone
    {
        public string Model { get; }
        public int Version { get; }
        public string Color { get; }
        public decimal Price { get; set; }

        public Smartphone(string model, int version, string color, decimal price)
        {
            Model = model;
            Version = version;
            Color = color;
            Price = price;
        }
    }

    // questo delegate è troppo specifico, si rivolge solo a Smartphone.
    //delegate bool SmartphoneFilter(Smartphone s);

    // questo delegate è più generale, posso riutilizzarlo su tipi 'T' diversi:
    delegate bool Filter<T>(T item);
}
