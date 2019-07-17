using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_Linq
{
    class Program
    {
        /*
         * LINQ (Language INtegrated Query) è una parte di .NET che contiene una serie di metodi d'estensione
         * per manipolare collezioni.
         * 
         * Tutti i suoi metodi si agganciano a collezioni 'IEnumerable<T>'.
         * Sono di tre tipi:
         * 1) metodi che restituiscono altri 'IEnumerable<T>' (Select(), Where(), GroupBy(), OrderBy(), Distinct() ...)
         * 2) metodi che restituiscono una collezione concreta (ToList(), ToArray(), ...)
         * 3) metodi che restituiscono un singolo valore (Sum(), Average(), ...)
         */

        static void Main(string[] args)
        {
            List<Smartphone> list = CreateMocks();

            IEnumerable<Smartphone> step1 = list.Where(x => x.Price < 1000); // FILTRO
            IEnumerable<string> step2 = step1.Select(x => x.Model); // PROIEZIONE
            IEnumerable<string> step3 = step2.OrderBy(x => x); // ORDINAMENTO

            // Posso concatenare più metodi di LINQ a formare una catena:
            IEnumerable<string> orderedNames = list
                .Where(x => x.Price < 1000)
                .Select(x => x.Model)
                .OrderBy(x => x);


            IEnumerable<IGrouping<string, Smartphone>> groups = list.GroupBy(x => x.Color); // RAGGRUPPAMENTO

            foreach(IGrouping<string, Smartphone> group in groups)
            {
                Console.WriteLine(group.Key);
                foreach(Smartphone s in group)
                    Console.WriteLine($"\t{s.Model} {s.Version}");
            }

            Console.WriteLine();

            // Con il 'var' sfrutto la TYPE INFERENCE di C#:
            // C# capisce da solo il tipo della variabile,
            // non devo specificarlo io esplicitamente (=> IMPLICIT TYPING)
            var averagePricePerColors = list
                .GroupBy(x => x.Color)
                .Select(g => new ColorAverage
                    {
                        Color = g.Key,
                        Average = g.Average(x => x.Price)
                    });

            foreach (var colorAverage in averagePricePerColors)
                Console.WriteLine($"{colorAverage.Color} - {colorAverage.Average} €");

            // il 'var' NON rende le variabili dinamiche.
            // Una variabile dichiarata con un tipo RESTA di quel tipo.
            var ints = new List<int>();
            ints.Add(5);
            // queste righe danno errore:
            //ints.Add("Ciao");
            //ints = 4;

            // Con il 'var' non devo ripetere i nomi delle classi,
            // il che è utile soprattutto se i nomi sono lunghi e/o complicati.
            var dict = new Dictionary<string, Dictionary<int, List<string>>>();

            var newColl1 = averagePricePerColors
                .Select(x => new Smartphone { Color = x.Color });

            var newColl2 = averagePricePerColors
                .Select(x => 1)
                .Select(x => x * 2);

            Console.Read();
        }

        static List<Smartphone> CreateMocks()
        {
            return new List<Smartphone>
            {
                new Smartphone("iPhone", 8, "Grey", 1200),
                new Smartphone("Galaxy S8", 0, "White", 800),
                new Smartphone("Nokia", 3310, "White", 200),
                new Smartphone("iPhone", 5, "Pink", 400),
                new Smartphone("Huawei", 2, "Black", 500),
            };
        }
    }

    class Smartphone
    {
        public Smartphone(string model, int version, string color, decimal price)
        {
            Model = model;
            Version = version;
            Color = color;
            Price = price;
        }

        public Smartphone() { }

        public string Model { get; set; }
        public int Version { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
    }

    class ColorAverage
    {
        public string Color { get; set; }
        public decimal Average { get; set; }
    }
}
