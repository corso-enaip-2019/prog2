using System;
using System.Collections.Generic;

namespace P30_Iterator
{
    class Program
    {
        static void Main(string[] args)
        {
            var si = new SeasonIterator();

            // questo è l'algoritmo di utilizzo di un ITERATOR:
            while(si.HasNext())
            {
                si.MoveToNext();
                var current = si.Current;
                Console.WriteLine(current);
            }

            // C# ha creato un design pattern simile, ENUMERATOR.
            // Questo pattern viene sfruttato dai foreach.
            // Ad esempio, quando faccio un foreach:

            var list = new List<int> { 1, 2, 3 };

            foreach(var i in list)
                Console.WriteLine(i);
            Console.WriteLine();
            // Quello che succede è questo:

            // Prima di C# 5.0:
            var enumerator1 = list.GetEnumerator();
            var current1 = 0;
            while(enumerator1.MoveNext())
            {
                current1 = enumerator1.Current;
                Console.WriteLine(current1);

                // generava problemi in caso di closure
                // (che vedremo più avanti).
            }
            Console.WriteLine();

            // Dopo C# 5.0:
            var enumerator2 = list.GetEnumerator();
            while(enumerator2.MoveNext())
            {
                var current2 = enumerator2.Current;
                Console.WriteLine(current2);
            }

            Console.Read();
        }
    }

    // L'idea dell'ITERATOR è questa:
    interface IIterator<T>
    {
        T Current { get; }
        bool HasNext();
        void MoveToNext();
    }

    // esempio di implementazione:
    enum Season
    {
        Winter = 1,
        Spring = 2,
        Summer = 3,
        Autumn = 4
    }

    // voglio implementare una classe che mi permetta di iterare
    // su tutti i valori dell'enum:

    class SeasonIterator : IIterator<Season>
    {
        public Season Current { get; private set; }

        public bool HasNext()
        {
            return (int)Current < 4;
        }

        public void MoveToNext()
        {
            if (Current == 0)
                Current = Season.Winter;
            else if (Current == Season.Winter)
                Current = Season.Spring;
            else if (Current == Season.Spring)
                Current = Season.Summer;
            else if (Current == Season.Summer)
                Current = Season.Autumn;
            else
                throw new InvalidOperationException("end of iteration!");
        }
    }
}
