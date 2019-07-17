using System;
using System.Collections.Generic;

namespace Exercise_07_ObjectOriented
{
    /*
     * Il progetto precedente era già buono con design ad oggetti,
     * ma era rimasta un'inconsistenza:
     * le opzioni erano disperse tra il metodo PrintOptions, ReadOptions, e lo switch del Main.
     * Se in seguito vengono aggiunte o tolte, è facile dimenticarsi uno dei punti di modifica.
     * 
     * Per ovviare al problema, incapsuliamo insieme, dentro una singola istanza di "Option",
     * un codice, una descrizione e un'operazione collegata (vedi classe Option in fondo).
     * 
     * Invece di duplicare le operazioni, lavoriamo per CONFIGURAZIONE.
     */
    class Program
    {
        static void Main(string[] args)
        {
            List<VatNumber> vats = CreateVatMocks();

            Console.WriteLine("*** VAT Numbers Management System ***");

            Dictionary<string, Option> options = CreateConfiguration();

            while (true)
            {
                string inputOption = ReadOption(options);
                options[inputOption].Operation(vats);
            }
        }

        static List<VatNumber> CreateVatMocks()
        {
            return new List<VatNumber>
            {
                new SimpleVatNumber
                {
                    Code = "123",
                    Bills = new List<decimal> { },
                },
                new NormalVatNumber
                {
                    Code = "124",
                    Bills = new List<decimal> { 1000, 700, 300 },
                    Expenses = new List<decimal> { 400, 500, 100 },
                },
                new NormalVatNumber
                {
                    Code = "125",
                    Bills = new List<decimal>(),
                    Expenses = new List<decimal> { 100, 50 },
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

        static Dictionary<string, Option> CreateConfiguration()
        {
            return new Dictionary<string, Option>
            {
                { "1", new Option("1", "Add a bill to a VAT number", AddBillToVatNumber) },
                { "2", new Option("2", "Add an expense to a VAT number", AddExpenseToVatNumber) },
                { "3", new Option("3", "Show data about a VAT number", CalculateTotalsOfVatNumber) },
                { "4", new Option("4", "List all the VAT numbers", ListAllVatNumbers) },
            };
        }

        private static string ReadOption(Dictionary<string, Option> options)
        {
            Console.WriteLine();
            Console.WriteLine("Available options:");
            foreach(Option o in options.Values)
                Console.WriteLine($"{o.Description} ({o.Code})");
            Console.Write("What do you want to do? ");

            string inputOption;
            while (true)
            {
                inputOption = Console.ReadLine();
                if (options.ContainsKey(inputOption))
                    break;
                Console.Write("The entered value is not valid. Re-enter: ");
            }

            return inputOption;
        }

        private static void AddBillToVatNumber(List<VatNumber> vats)
        {
            VatNumber selected = SelectVat(vats);

            if (selected != null)
                selected.AddBill();
            else
                Console.WriteLine("The entered VAT number does not exist!");
        }

        private static void AddExpenseToVatNumber(List<VatNumber> vats)
        {
            VatNumber selected = SelectVat(vats);

            if (selected != null)
                selected.AddExpense();
            else
                Console.WriteLine("The entered VAT number does not exist!");
        }

        private static void CalculateTotalsOfVatNumber(List<VatNumber> vats)
        {
            VatNumber selected = SelectVat(vats);

            if (selected != null)
                selected.CalculateAndPrint();
            else
                Console.WriteLine("The entered VAT number does not exist!");

            // per essere "a oggetti" al 100% dovrei eliminare tutti branch, if/else, switch, ecc.
            // però rischio di scrivere codice più oscuro e più difficile da gestire.
            //Dictionary<bool, Action> dict = new Dictionary<bool, Action>
            //{
            //    { true, () => selected.CalculateAndPrint() },
            //    { false, () => Console.WriteLine("The entered VAT number does not exist!") },
            //};
            //dict[selected != null]();
        }

        private static void ListAllVatNumbers(List<VatNumber> vats)
        {
            foreach (VatNumber vat in vats)
                Console.WriteLine(vat.Code);
        }

        private static VatNumber SelectVat(List<VatNumber> vats)
        {
            Console.Write("Enter a VAT number: ");
            string inputCode = Console.ReadLine();

            foreach (VatNumber vat in vats)
                if (vat.Code == inputCode)
                    return vat;

            return null;
        }
    }

    abstract class VatNumber
    {
        public string Code;
        public List<decimal> Bills;

        public abstract void CalculateAndPrint();
        public abstract void AddBill();
        public abstract void AddExpense();
    }

    class NormalVatNumber : VatNumber
    {
        const decimal IVA_PERCENTAGE = 22M;
        const decimal IRPEF_PERCENTAGE = 23M;

        public List<decimal> Expenses;

        public override void CalculateAndPrint()
        {
            //decimal profit = Utilities.Sum(Bills) - Utilities.Sum(Expenses);
            decimal profit = this.CalculateProfit();

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

        private decimal CalculateProfit()
        {
            return Utilities.Sum(Bills) - Utilities.Sum(Expenses);
        }

        public override void AddBill()
        {
            decimal newBill = Utilities.ReadDecimal("Enter the value of the bill: ");
            Bills.Add(newBill);
        }

        public override void AddExpense()
        {
            decimal newExpense = Utilities.ReadDecimal("Enter the value of the expense: ");
            Expenses.Add(newExpense);
        }
    }

    class SimpleVatNumber : VatNumber
    {
        const decimal SIMPLE_TAXABLE_PERCENTAGE = 78M;
        const decimal SIMPLE_TAX_PERCENTAGE = 15M;

        public override void CalculateAndPrint()
        {
            decimal billTotal = Utilities.Sum(Bills);

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

        public override void AddBill()
        {
            decimal newBill = Utilities.ReadDecimal("Enter the value of the bill: ");
            Bills.Add(newBill);
        }

        public override void AddExpense()
        {
            Console.WriteLine("You cannot add expenses to a VAT number of type 'simple'");
        }
    }

    class Option
    {
        public Option(string code, string description, Action<List<VatNumber>> operation)
        {
            Code = code;
            Description = description;
            Operation = operation;
        }

        public string Code;
        public string Description;
        public Action<List<VatNumber>> Operation;
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
