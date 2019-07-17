using System;

/* 20190415 */
/* IteratorPattern (P13_DesignPatterns - P30_Iterator) */

namespace IteratorPattern
{
    public enum Season { Summer = 1, Autumn, Winter, Spring };

    class Program
    {
        static void Main(string[] args)
        {
            SeasonIterator si=new SeasonIterator();
            Season s;

            bool rePlay = true;
            while (rePlay)
            {
                //Console.WriteLine(s.GetCurrent());
                var eNames = Enum.GetNames(typeof(Season));
                var eValues = Enum.GetValues(typeof(Season));

                foreach (string season in eNames)
                {
                    Console.WriteLine(season);
                }

                Console.WriteLine();

                foreach (var  x in eValues)
                {
                    Console.WriteLine(x + "\t"+x.ToString());
                }


                Console.Write("\"q\"? \a");
                rePlay = (Console.ReadLine() != "q") ? true : false;
            }
        }
    }
}