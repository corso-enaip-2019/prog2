using System;
using System.Collections.Generic;

namespace Exercise_03_Procedural
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
            List<NormalVatNumber> normals = CreateNormalMocks();
            List<SimpleVatNumber> simples = CreateSimpleMocks();

            Console.WriteLine("*** VAT Numbers Management System ***");

            while (true)
            {
                PrintOptions();
                string option = ReadOption();
                switch (option)
                {
                    case "1":
                            AddBillToVatNumber(normals, simples);
                            break;
                    case "2":
                            AddExpenseToVatNumber(normals, simples);
                            break;
                    case "3":
                            CalculateTotalsOfVatNumber(normals, simples);
                            break;
                    case "4":
                        ListAllVatNumbers(normals, simples);
                        break;
                    default:
                            throw new InvalidOperationException();
                }
            }
        }

        static List<NormalVatNumber> CreateNormalMocks()
        {
            return new List<NormalVatNumber>
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
            };
        }

        static List<SimpleVatNumber> CreateSimpleMocks()
        {
            return new List<SimpleVatNumber>
            {
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

        private static void AddBillToVatNumber(List<NormalVatNumber> normals, List<SimpleVatNumber> simples)
        {
            SelectedVat selected = SelectVat(normals, simples);

            if (selected.Normal != null)
            {
                decimal newBill = ReadDecimal("Enter the value of the bill: ");
                selected.Normal.Bills.Add(newBill);
            }
            else if (selected.Simple != null)
            {
                decimal newBill = ReadDecimal("Enter the value of the bill: ");
                selected.Simple.Bills.Add(newBill);
            }
            else
            {
                Console.WriteLine("The entered VAT number does not exist!");
            }
        }

        private static void AddExpenseToVatNumber(List<NormalVatNumber> normals, List<SimpleVatNumber> simples)
        {
            SelectedVat selected = SelectVat(normals, simples);

            if (selected.Normal != null)
            {
                decimal newExpense = ReadDecimal("Enter the value of the expense: ");
                selected.Normal.Expenses.Add(newExpense);
            }
            else if (selected.Simple != null)
            {
                Console.WriteLine("You cannot add expenses to a VAT number of type 'simple'");
            }
            else
            {
                Console.WriteLine("The entered VAT number does not exist!");
            }
        }

        private static void CalculateTotalsOfVatNumber(List<NormalVatNumber> normals, List<SimpleVatNumber> simples)
        {
            SelectedVat selected = SelectVat(normals, simples);

            if (selected.Normal != null)
            {
                CalculateAndPrint(selected.Normal);
            }
            else if (selected.Simple != null)
            {
                CalculateAndPrint(selected.Simple);
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

        private static void ListAllVatNumbers(List<NormalVatNumber> normals, List<SimpleVatNumber> simples)
        {
            foreach (NormalVatNumber vn in normals)
                Console.WriteLine(vn.Code);

            foreach (SimpleVatNumber vn in simples)
                Console.WriteLine(vn.Code);
        }

        private static SelectedVat SelectVat(List<NormalVatNumber> normals, List<SimpleVatNumber> simples)
        {
            Console.Write("Enter a VAT number: ");
            string inputCode = Console.ReadLine();

            foreach (NormalVatNumber vn in normals)
                if (vn.Code == inputCode)
                    return new SelectedVat { Normal = vn };

            foreach (SimpleVatNumber vn in simples)
                if (vn.Code == inputCode)
                    return new SelectedVat { Simple = vn };

            return new SelectedVat();
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

    class SelectedVat
    {
        public NormalVatNumber Normal;
        public SimpleVatNumber Simple;
    }
}
