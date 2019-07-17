using System;

/* /!\ Totalmeente incompleto /!\ */

namespace OptionalParameters
{
    class Program
    {
        static void Main(string[] args)
        {
            bool rePlay = true;
            while (rePlay)
            {

                Console.Write("\"q\"? \a");
                rePlay = (Console.ReadLine() != "q") ? true : false;
            }

        }
    }
}
