using System;
using System.Collections.Generic;
using System.Text;

namespace Test1BenNic_Loan
{
    class CnsGui : IGui
    {
        public float RequestFloat(string message)
        {
            float outFloat = 0f;
            bool converted = false, positive = false;

            while (!converted && !positive)
            {
                outFloat = 0f;
                Console.WriteLine(message);
                Console.WriteLine("Immettere un valore maggiore di 0 (\".\" come virgola).");

                converted = float.TryParse(Console.ReadLine(), out outFloat);
                positive = outFloat > 0;
            }

            return outFloat;
        }

        public string RequestString(string message)
        {
            string userInput = "";
            bool notValidString = true;

            while (notValidString)
            {
                userInput = "";
                Console.WriteLine(message);
                Console.WriteLine("Immettere un testo non vuoto (\"q\" per uscire).");

                userInput = Console.ReadLine();
                notValidString = string.IsNullOrEmpty(userInput) || string.IsNullOrWhiteSpace(userInput);
            }

            return userInput.ToLower();
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
            return;
        }
    }
}