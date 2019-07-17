using System;
using System.Collections.Generic;

namespace Exercise_05_Procedural
{
    /* PARADIGMA PROCEDURALE
     * 
     * Posso incapsulare non solo i dati dentro una classe, ma anche le operazioni relative.
     * Cioè, il calcolo specifico delle tasse su una partita IVA normale sta insieme
     * ai campi che definiscono una partiva IVA normale, non ha senso che sia il Program
     * a conoscere questi dettagli (vedere il metodo CalculateTotalsOfVatNumber).
     * 
     * Inoltre, per lo stesso discorso, i metodi comuni, semplici e di utilità,
     * li sposto in una classe a parte (Utilities).
     * 
     * Il codice è meglio organizzato, ma mi restano, irrisolvibili, i vari if/else/switch sui tipi.
     * Cioè devo dall'esterno capire il tipo esatto di un oggetto prima di potergli affidare un'operazione.
     * 
     * Questo va contro il nostro senso comune: quando incontro una Persona, voglio poterla chiamare per nome,
     * o chiederle un prospetto delle sue entrate (stipendio, borse di studio, pensione...)
     * anche prima di chiederle esattamente che tipo di Persona è (Lavoratore, Studente, Pensionato...),
     */

    class Program
    {
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
                decimal newBill = Utilities.ReadDecimal("Enter the value of the bill: ");
                normal.Bills.Add(newBill);
            }
            else if (selected is SimpleVatNumber simple)
            {
                decimal newBill = Utilities.ReadDecimal("Enter the value of the bill: ");
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
                decimal newExpense = Utilities.ReadDecimal("Enter the value of the expense: ");
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
                NormalVatNumber.CalculateAndPrint(normal);
            }
            else if (selected is SimpleVatNumber simple)
            {
                SimpleVatNumber.CalculateAndPrint(simple);
            }
            else
            {
                Console.WriteLine("The entered VAT number does not exist!");
            }
        }

        private static void ListAllVatNumbers(List<object> vats)
        {
            foreach (object vat in vats)
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

            foreach (object vat in vats)
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
    }

    class NormalVatNumber
    {
        const decimal IVA_PERCENTAGE = 22M;
        const decimal IRPEF_PERCENTAGE = 23M;

        public string Code;
        public List<decimal> Bills;
        public List<decimal> Expenses;

        public static void CalculateAndPrint(NormalVatNumber selected)
        {
            decimal profit = Utilities.Sum(selected.Bills) - Utilities.Sum(selected.Expenses);

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
    }

    class SimpleVatNumber
    {
        const decimal SIMPLE_TAXABLE_PERCENTAGE = 78M;
        const decimal SIMPLE_TAX_PERCENTAGE = 15M;

        public string Code;
        public List<decimal> Bills;

        public static void CalculateAndPrint(SimpleVatNumber selected)
        {
            decimal billTotal = Utilities.Sum(selected.Bills);

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
    }

    class Utilities
    {
        public static decimal ReadDecimal(string initialMessage)
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

        public static decimal Sum(List<decimal> list)
        {
            decimal total = 0M;

            foreach (decimal item in list)
                total += item;

            return total;
        }
    }
}
