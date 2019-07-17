using System;

namespace CnsApp19ExCondos
{
    class Program
    {
        static void Main(string[] args)
        {

            bool rePlay = true;
            while (rePlay)
            {

                rePlay = (Console.Read() != 'q') ? true : false;
            }
            Console.ReadLine();
        }
    }
}
