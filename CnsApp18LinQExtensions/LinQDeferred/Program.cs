using System;

using System.Collections.Generic;
using System.Linq;

namespace LinQDeferredExecution
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int> { 1, 2, 2, 3 };

            var filtered = list.Where(x => x < 5);

            foreach (var i in filtered)
            {
                Console.Write(i + "\t");
            }

            Console.WriteLine();
            Console.WriteLine();

            list.Add(4);

            foreach (var i in filtered)
            {
                Console.Write(i + "\t");
            }


            Console.ReadLine();
        }
    }
}