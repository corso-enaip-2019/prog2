using System;
using System.Collections.Generic;

namespace Exercise_04_Procedural
{
    // PARADIGMA PROCEDURALE
    // Regole:
    // - si possono creare classi, ma solo come inermi contenitori di dati, cioè:
    //       - si possono dichiarare solo campi pubblici
    //       - niente proprietà metodi, costruttori, inizializzazioni dei campi
    // - si può organizzare la logica in sottofunzioni, ma solo in forma di
    //       metodi static nella classe Program.
    // - è possibile usare solo variabili locali, costanti, array,
    //       flussi di controllo (if/else, for, switch...)
    // - per semplificare l'esercizio, è possibile usare anche le List<T>, con il metodo Add,
    //       ma è un'eccezione per non complicare troppo l'esercizio

    class Program
    {
        const decimal IVA_PERCENTAGE = 22M;
        const decimal IRPEF_PERCENTAGE = 23M;
        const decimal SIMPLE_TAXABLE_PERCENTAGE = 78M;
        const decimal SIMPLE_TAX_PERCENTAGE = 15M;

        static void Main(string[] args)
        {
            List<object> vats = CreateVatMocks();

            Console.WriteLine("*** VAT Numbers Management System ***");

            while (true)
            {
                PrintOptions();
                string option = ReadOption();
                switch (option)
                {
                    case "1":
                        AddBillToVatNumber(vats);
                        break;
                    case "2":
                        AddExpenseToVatNumber(vats);
                        break;
                    case "3":
                        CalculateTotalsOfVatNumber(vats);
                        break;
                    case "4":
                        ListAllVatNumbers(vats);
                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }
        }

        static List<object> CreateVatMocks()
        {
            return new List<object>
            {
                new NormalVatNumber
                {
                    Code = "123",
                    Bills = new List<decimal> { 1000, 700, 300 },
                    Expenses = new List<decimal> { 400, 500, 100 },
                },
                new NormalVatNumber
                {
                    Code = "124",
                    Bills = new List<decimal>(),
                    Expenses = new List<decimal> { 100, 50 },
                },
                new SimpleVatNumber
                {
                    Code = "125",
                    Bills = new List<decimal> { },
                },
                new SimpleVatNumber
                {
                    Code = "126",
                    Bills = new List<decimal> { 500 },
                },
                new SimpleVatNumber
                {
                    Code = "127",
                    Bills = new List<decimal> { 100, 100, 100, 200, 500, 200 },
                },
            };
        }

        static void PrintOptions()
        {
            Console.WriteLine();
            Console.WriteLine("Available options:");
            Console.WriteLine("Add a bill to a VAT number (1)");
            Console.WriteLine("Add an expense to a VAT number (2)");
            Console.WriteLine("Show data about a VAT number (3)");
            Console.WriteLine("List all the VAT numbers (4)");
            Console.Write("What do you want to do? ");
        }

        private static string ReadOption()
        {
            string option;
            while (true)
            {
                option = Console.ReadLine();
                if (option == "1" || option == "2" || option == "3" || option == "4")
                    break;
                Console.Write("The entered value is not valid. Re-enter: ");
            }

            return option;
        }

        private static void AddBillToVatNumber(List<object> vats)
        {
            object selected = SelectVat(vats);

            if (selected is NormalVatNumber normal)
            {
                decimal newBill = ReadDecimal("Enter the value of the bill: ");
                normal.Bills.Add(newBill);
            }
            else if (selected is SimpleVatNumber simple)
            {
                decimal newBill = ReadDecimal("Enter the value of the bill: ");
                simple.Bills.Add(newBill);
            }
            else
            {
                Console.WriteLine("The entered VAT number does not exist!");
            }
        }

        private static void AddExpenseToVatNumber(List<object> vats)
        {
            object selected = SelectVat(vats);

            if (selected is NormalVatNumber normal)
            {
                decimal newExpense = ReadDecimal("Enter the value of the expense: ");
                normal.Expenses.Add(newExpense);
            }
            else if (selected is SimpleVatNumber)
            {
                Console.WriteLine("You cannot add expenses to a VAT number of type 'simple'");
            }
            else
            {
                Console.WriteLine("The entered VAT number does not exist!");
            }
        }

        private static void CalculateTotalsOfVatNumber(List<object> vats)
        {
            object selected = SelectVat(vats);

            if (selected is NormalVatNumber normal)
            {
                CalculateAndPrint(normal);
            }
            else if (selected is SimpleVatNumber simple)
            {
                CalculateAndPrint(simple);
            }
            else
            {
                Console.WriteLine("The entered VAT number does not exist!");
            }
        }

        private static void CalculateAndPrint(NormalVatNumber selected)
        {
            decimal profit = Sum(selected.Bills) - Sum(selected.Expenses);

            if (profit > 0)
            {
                decimal iva = profit * IVA_PERCENTAGE / 100;
                decimal profitWithoutIva = profit - iva;
                decimal irpef = profitWithoutIva * IRPEF_PERCENTAGE / 100;
                decimal net = profitWithoutIva - irpef;
                decimal taxTotal = iva + irpef;

                Console.WriteLine($"Total net gain: {net}; total taxes: {taxTotal}");
            }
            else
            {
                Console.WriteLine($"Profit: {profit}; total taxes: 0");
            }
        }

        private static void CalculateAndPrint(SimpleVatNumber selected)
        {
            decimal billTotal = Sum(selected.Bills);

            decimal profit = billTotal;

            if (profit > 0)
            {
                decimal taxable = profit * SIMPLE_TAXABLE_PERCENTAGE / 100;
                decimal taxes = taxable * SIMPLE_TAX_PERCENTAGE / 100;
                decimal net = profit - taxes;

                Console.WriteLine($"Net gain: {net}; total taxation: {taxes}");
            }
            else
            {
                Console.WriteLine($"Profit: {profit}");
            }
        }

        private static void ListAllVatNumbers(List<object> vats)
        {
            foreach(object vat in vats)
            {
                if (vat is NormalVatNumber normal)
                    Console.WriteLine(normal.Code);
                else if (vat is SimpleVatNumber simple)
                    Console.WriteLine(simple.Code);
                else
                    throw new InvalidOperationException();
            }
        }

        private static object SelectVat(List<object> vats)
        {
            Console.Write("Enter a VAT number: ");
            string inputCode = Console.ReadLine();

            foreach(object vat in vats)
            {
                if (vat is NormalVatNumber normal)
                {
                    if (normal.Code == inputCode)
                    {
                        return normal;
                    }
                }
                else if (vat is SimpleVatNumber simple)
                {
                    if (simple.Code == inputCode)
                    {
                        return simple;
                    }
                }
            }

            return null;
        }

        private static decimal ReadDecimal(string initialMessage)
        {
            Console.Write(initialMessage);

            decimal value;
            while (true)
            {
                if (decimal.TryParse(Console.ReadLine(), out value))
                    break;
                Console.Write("Invalid value. Re-enter: ");
            }

            return value;
        }

        private static decimal Sum(List<decimal> list)
        {
            decimal total = 0M;

            foreach (decimal item in list)
                total += item;

            return total;
        }
    }

    class NormalVatNumber
    {
        public string Code;
        public List<decimal> Bills;
        public List<decimal> Expenses;
    }

    class SimpleVatNumber
    {
        public string Code;
        public List<decimal> Bills;
    }
}
