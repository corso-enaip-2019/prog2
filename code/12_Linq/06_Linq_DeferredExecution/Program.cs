using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_Linq_DeferredExecution
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int> { 1, 2, 3 };

            var filtered = list.Where(x => x < 5);

            list.Add(4);

            foreach(var i in filtered)
                Console.WriteLine(i);
                
            Console.WriteLine();

            // DEFERRED EXECUTION
            // l'attuale concreta collezione dietro "filtered"
            // viene creata solo nel momento in cui chiamo "foreach".
            // Ad ogni "foreach" viene ricalcolata.

            list.Add(0);

            foreach (var i in filtered)
                Console.WriteLine(i);
            Console.WriteLine();

            // I metodi di LINQ che hanno come risultato un valore singolo
            // NON hanno D.E:

            var sum = list.Sum();
            Console.WriteLine($"somma: {sum}");

            list.Add(10);
            Console.WriteLine($"somma: {sum}");

            // Anche i metodi di LINQ che restituiscono collezioni concrete
            // (List, Array, Dictionary, ...), e non interfacce (IEnumerable, IGrouping...)
            // NON hanno D.E. (queste collezioni concrete sono istanziate
            // e riempite sul momento, e poi mai più modificate da LINQ.

            var newList = list.ToList();

            foreach (var i in newList)
                Console.WriteLine(i);
            Console.WriteLine();

            list.Add(14);
            foreach (var i in newList)
                Console.WriteLine(i);
            Console.WriteLine();

            Console.Read();
        }
    }
}
