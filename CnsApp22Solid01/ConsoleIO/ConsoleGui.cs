using System;

using DepInvCon_Contracts;

namespace ConsoleIO
{
    public class ConsoleGui : IGui
    {
        public int ReadInt(string message)
        {
            Console.WriteLine(message);
            while (true)
            {
                var canConvert = int.TryParse(Console.ReadLine(), out int value);
                if (canConvert)
                    return value;

                Console.WriteLine("Invalid value, re-enter: ");
            }
        }

        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}