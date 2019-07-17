using System;
using System.Collections.Generic;

namespace Exercise_06_ObjectOriented
{
    /*
     * Sfruttando l'incapsulamento e il late binding,
     * posso affidare ad ogni oggetto la responsabilità di eseguire le operazioni che gli competono.
     * In questo modo, non devo continuare a fare if/else o switch sui tipi:
     * demando direttamente all'oggetto la scelta delle operazioni da fare.
     * Come si vede dal codice sottostante, tutti gli if/else sui tipi sono spariti.
     * Il codice diventa molto più pulito e modulare.
     * 
     * Sfruttando l'ereditarietà, posso creare una classe base, e poi estendere o sovrascrivere
     * solo le parti necessarie nelle classi derivate, evitando un sacco di duplicazione.
     */
    class Program
    {
        static void Main(string[] args)
        {
            List<VatNumber> vats = CreateVatMocks();

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

            foreach(VatNumber vat in vats)
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
