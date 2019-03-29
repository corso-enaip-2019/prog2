using System;

namespace Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            string nm = "Mario";
            string srn = "Rossi";
            string gnd = "Maschio";
            decimal slr = 3141.52m;

            PrintBoth(nm, srn, gnd, slr);

            Console.WriteLine();

            Worker w1 = new Worker("Marco", "Neri", "Maschio", "vicolo Stretto 18, Roma (RM)", 12000m);
            PrintBoth(w1.Name, w1.Surname, w1.Gender, w1.Salary);

            Worker w2 = new Worker(AskForAString("Nome:","?"), AskForAString("Cognome:", "?"), AskForAString("Sesso:", "?"), AskForAString("Indirizzo:", "?"), AskForAPositiveDecimal("Salario", "?"));
            PrintBoth(w2.Name, w2.Surname, w2.Gender, w2.Salary);

            Console.ReadLine();
        }

        static void PrintInLineWorker(Worker worker)
        { Console.WriteLine($"{worker.Name}, {worker.Surname.ToUpper()} ({worker.Gender.ToUpper()[0]}) {worker.Salary}€"); }

        static void PrintLargeWorker(Worker worker)
        {
            Console.WriteLine($"Nome:\t{worker.Name}");
            Console.WriteLine($"Cognome:\t{worker.Surname.ToUpper()}");
            Console.WriteLine($"Sesso:\t{worker.Gender}");
            Console.WriteLine($"Salario:\t{worker.Salary} EUR");
        }

        static void PrintInLine(string name, string surname, string gender, decimal salary)
        { Console.WriteLine($"{name}, {surname.ToUpper()} ({gender.ToUpper()[0]}) {salary}€"); }



        static void PrintLarge(string name, string surname, string gender, decimal salary)
        {
            Console.WriteLine($"Nome:\t{name}");
            Console.WriteLine($"Cognome:\t{surname.ToUpper()}");
            Console.WriteLine($"Sesso:\t{gender}");
            Console.WriteLine($"Salario:\t{salary} EUR");
        }

        static void PrintBoth(string name, string surname, string gender, decimal salary)
        {
            PrintInLine(name, surname, gender, salary);
            PrintLarge(name, surname, gender, salary);
        }

        static string AskForAString(string message, string errMessage)
        {
            string outStr = "";

            bool sensed = false;
            while (!sensed)
            {
                Console.Write(message + " \a");
                outStr = Console.ReadLine();
                sensed = (outStr == null || outStr == "") ? false : true;
                if (!sensed)
                { Console.WriteLine(errMessage); }
                Console.WriteLine();
            }

            return outStr;
        }

        static decimal AskForAPositiveDecimal(string message, string errMessage)
        {
            decimal outDec = -3.14m;

            bool converted = false, positive = false;
            while (!converted)
            {
                Console.Write(message + " \a");
                string inStr = Console.ReadLine();

                while (!converted || !positive)
                {
                    positive = false;

                    decimal.TryParse(inStr, out outDec);
                    converted = (outDec <= 0) ? false : true;

                    if (!converted)
                    { Console.WriteLine(errMessage); }
                    else
                    { positive = (outDec > 0) ? true : false; }
                    Console.WriteLine();
                }
            }

            return outDec;
        }
    }
}
