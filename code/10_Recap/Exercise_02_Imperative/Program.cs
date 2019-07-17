using System;
using System.Collections.Generic;

namespace Exercise_02_Imperative
{
    // PARADIGMA IMPERATIVO PIU' AVANZATO
    // Regole:
    // - si possono creare classi, ma solo come inermi contenitori di dati, cioè:
    //       - si possono dichiarare solo campi pubblici
    //       - niente proprietà metodi, costruttori, inizializzazioni dei campi
    // - niente sottometodi, neanche statici: tutta la logica sta nel Main.
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
            List<NormalVatNumber> normals = new List<NormalVatNumber>
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

            List<SimpleVatNumber> simples = new List<SimpleVatNumber>
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

            Console.WriteLine("*** VAT Numbers Management System ***");

            while(true)
            {
                Console.WriteLine();
                Console.WriteLine("Available options:");
                Console.WriteLine("Add a bill to a VAT number (1)");
                Console.WriteLine("Add an expense to a VAT number (2)");
                Console.WriteLine("Show data about a VAT number (3)");
                Console.WriteLine("List all the VAT numbers (4)");
                Console.Write("What do you want to do? ");

                // READ A VALID OPTION
                string option;
                while(true)
                {
                    option = Console.ReadLine();
                    if (option == "1" || option == "2" || option == "3" || option == "4")
                        break;
                    Console.Write("The entered value is not valid. Re-enter: ");
                }

                switch(option)
                {
                    case "1":
                        {
                            Console.Write("Enter a VAT number: ");
                            string inputCode = Console.ReadLine();

                            // LOOK IN NORMALS
                            NormalVatNumber selectedNormal = null;
                            foreach(NormalVatNumber vn in normals)
                            {
                                if (vn.Code == inputCode)
                                {
                                    selectedNormal = vn;
                                    break;
                                }
                            }

                            // FOUND A NORMAL VAT
                            if (selectedNormal != null)
                            {
                                Console.Write("Enter the value of the bill: ");
                                decimal newBill;
                                while(true)
                                {
                                    if (decimal.TryParse(Console.ReadLine(), out newBill))
                                        break;
                                    Console.Write("Invalid value. Re-enter: ");
                                }
                                selectedNormal.Bills.Add(newBill);
                            }
                            // LOOK FOR A SIMPLE VAT
                            else
                            {
                                // LOOK INTO SIMPLES
                                SimpleVatNumber selectedSimple = null;
                                foreach (SimpleVatNumber vn in simples)
                                {
                                    if (vn.Code == inputCode)
                                    {
                                        selectedSimple = vn;
                                        break;
                                    }
                                }
                                // FOUND A SIMPLE VAT
                                if (selectedSimple != null)
                                {
                                    Console.Write("Enter the value of the bill: ");
                                    decimal newBill;
                                    while (true)
                                    {
                                        if (decimal.TryParse(Console.ReadLine(), out newBill))
                                            break;
                                        Console.Write("Invalid value. Re-enter: ");
                                    }
                                    selectedSimple.Bills.Add(newBill);
                                }
                                // VAT NUMBER NOT FOUND
                                else
                                {
                                    Console.WriteLine("The entered VAT number does not exist!");
                                }
                            }

                            break;
                        }
                    case "2":
                        {
                            Console.Write("Enter a VAT number: ");
                            string inputCode = Console.ReadLine();

                            // LOOK IN NORMALS
                            NormalVatNumber selectedNormal = null;
                            foreach (NormalVatNumber vn in normals)
                            {
                                if (vn.Code == inputCode)
                                {
                                    selectedNormal = vn;
                                    break;
                                }
                            }

                            // FOUND A NORMAL VAT
                            if (selectedNormal != null)
                            {
                                Console.Write("Enter the value of the expense: ");
                                decimal newExpense;
                                while (true)
                                {
                                    if (decimal.TryParse(Console.ReadLine(), out newExpense))
                                        break;
                                    Console.Write("Invalid value. Re-enter: ");
                                }
                                selectedNormal.Expenses.Add(newExpense);
                            }
                            // LOOK FOR A SIMPLE VAT
                            else
                            {
                                // LOOK INTO SIMPLES
                                SimpleVatNumber selectedSimple = null;
                                foreach (SimpleVatNumber vn in simples)
                                {
                                    if (vn.Code == inputCode)
                                    {
                                        selectedSimple = vn;
                                        break;
                                    }
                                }
                                // FOUND A SIMPLE VAT
                                if (selectedSimple != null)
                                {
                                    Console.WriteLine("The selected VAT number is of type 'simple' and does not allow expenses");
                                }
                                // VAT NUMBER NOT FOUND
                                else
                                {
                                    Console.WriteLine("The entered VAT number does not exist!");
                                }
                            }
                            break;
                        }
                    case "3":
                        {
                            Console.Write("Enter a VAT number: ");
                            string inputCode = Console.ReadLine();

                            // LOOK IN NORMALS
                            NormalVatNumber selectedNormal = null;
                            foreach (NormalVatNumber vn in normals)
                            {
                                if (vn.Code == inputCode)
                                {
                                    selectedNormal = vn;
                                    break;
                                }
                            }

                            // FOUND A NORMAL VAT
                            if (selectedNormal != null)
                            {
                                decimal billTotal = 0M;
                                foreach (decimal bill in selectedNormal.Bills)
                                    billTotal += bill;

                                decimal expenseTotal = 0M;
                                foreach (decimal expense in selectedNormal.Expenses)
                                    expenseTotal += expense;

                                decimal profit = billTotal - expenseTotal;

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
                            // LOOK FOR A SIMPLE VAT
                            else
                            {
                                // LOOK INTO SIMPLES
                                SimpleVatNumber selectedSimple = null;
                                foreach (SimpleVatNumber vn in simples)
                                {
                                    if (vn.Code == inputCode)
                                    {
                                        selectedSimple = vn;
                                        break;
                                    }
                                }
                                // FOUND A SIMPLE VAT
                                if (selectedSimple != null)
                                {
                                    decimal billTotal = 0M;
                                    foreach (decimal bill in selectedSimple.Bills)
                                        billTotal += bill;

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
                                // VAT NUMBER NOT FOUND
                                else
                                {
                                    Console.WriteLine("The entered VAT number does not exist!");
                                }
                            }
                            break;
                        }
                    case "4":
                        {
                            foreach (NormalVatNumber vn in normals)
                                Console.WriteLine(vn.Code);
                            foreach (SimpleVatNumber vn in simples)
                                Console.WriteLine(vn.Code);
                            break;
                        }
                    default:
                        {
                            throw new InvalidOperationException();
                        }
                }
            }
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
