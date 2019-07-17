using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConCnsApp11Sqr2
{
    class Program
    {
        static void Main(string[] args)
        {
            double sqrt2_full = Math.Sqrt(2);

            //sqrt2_full = 1,4142135623731
            double[] sqrt_n_digits = new double[15] { 0d, 1d, 1.4, 1.41, 1.414, 1.4142, 1.41421, 1.414214, 1.4142136, 1.41421356, 1.414213562, 1.4142135624, 1.41421356237, 1.414213562373, 1.4142135623731 };

            Console.WriteLine($"sqrt(2) = {sqrt2_full}");
            Console.WriteLine();
            Console.WriteLine("Cifre significative");
            Console.WriteLine(" │\tεass ( = |misura-esatto| )");
            Console.WriteLine(" │\t │\t\t\t\tnumero con x cifre significative");
            Console.WriteLine(" │\t │\t\t\t\t │");

            for (int i = 1; i < 15; i++)
            {
                Console.Write(i.ToString().PadLeft(2));
                Console.Write(String.Format("\t{0:0.00000} ({0})", Math.Abs(sqrt_n_digits[i] - sqrt2_full)));
                Console.Write($"\t{sqrt_n_digits[i]}");
                Console.WriteLine();
                if (i % 3 == 0)
                { Console.WriteLine(); }
            }

            Console.ReadLine();
        }
    }
}
