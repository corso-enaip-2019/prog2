using System;

/* 20180408 */
/* Test1 v1 - Calcolo mutuo. */

namespace SolidPrincipe0101
{
    class Program
    {
        static void Main(string[] args)
        {
            //instanziare io
            //io=...

            //ask how many$
            //ask how loan type
            //ask if already client

            //iloancalc =..
            //loanapp=new loanapp(io, iloancalc)
            //loanapp.run()



            Console.WriteLine("Hello World!");
        }
    }

    class LeanApplication
    {
        public void Run()
        {
            //loancalc.calculate()
            //io.print("finalamount " + loancalc.final)
        }
    }

    interface IGui
    {
        void Output(string message);

        /* E' decimal perché lavoriamo con soldi. */
        decimal InputDecimal(string question);

        bool InputBool(string question);

        string InputStringInRange(string question, string[] options);
    }

    class ConsoleGui : IGui
    {
        private const string INVALID_VALUE_MESSAGE = "Il valore inserito non è valido. Riprova: \a";

        public bool InputBool(string question)
        {
            //throw new NotImplementedException();
        }

        public decimal InputDecimal(string question)
        {
            while (true)
            {
                Console.WriteLine(question);
                var isOK = decimal.TryParse(Console.ReadLine(), out decimal value);
                if (isOK)
                {
                    return value;
                }
                Console.Write(INVALID_VALUE_MESSAGE);
            }
        }

        public string InputStringInRange(string question, string[] options)
        {
            Console.WriteLine(question);
            while (true)
            {
                if (options.Contains(value))
                {
                    return value;
                }
                Console.Write(INVALID_VALUE_MESSAGE);
            }
        }

        public void Output(string message)
        {
            //throw new NotImplementedException();
        }
    }
}