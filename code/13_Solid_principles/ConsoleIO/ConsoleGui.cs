using DepInvCon_Contracts;
using System;

namespace ConsoleIO
{
    public class ConsoleGui : IGui
    {
        public int ReadInt(string message)
        {
            Console.Write(message);

            while(true)
            {
                var canConvert = int.TryParse(Console.ReadLine(), out int value);

                if (canConvert)
                    return value;

                Console.Write("Invalid value. Re-enter: ");
            }
        }

        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}
