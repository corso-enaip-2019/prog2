using System;

namespace Exercise_01_Imperative
{
    // PRIMA VERSIONE: PARADIGMA IMPERATIVO PRIMITIVO
    // regole:
    // - niente classi
    // - niente metodi, se non il Main
    // - è possibile usare solo variabili locali, costanti, array,
    //       flussi di controllo (if/else, for, switch...)

    class Program
    {
        const decimal IVA_PERCENTAGE = 22M;
        const decimal IRPEF_PERCENTAGE = 23M;
        const decimal SIMPLE_TAXABLE_PERCENTAGE = 78M;
        const decimal SIMPLE_TAX_PERCENTAGE = 15M;

        static void Main(string[] args)
        {
            string[] normalCodes = { "123", "124" };
            decimal[][] normalBills = { new decimal[] { 1000, 700, 300 }, new decimal[0] };
            decimal[][] normalExpenses = { new decimal[] { 400, 500, 100 }, new decimal[] { 100, 50 } };

            string[] simpleCodes = { "125", "126", "127" };
            decimal[][] simpleBills = { new decimal[0], new decimal[] { 500 }, new decimal[] { 100, 100, 100, 200, 500, 200 } };

            Console.WriteLine("*** VAT Numbers Management System ***");

            while (true)
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
                int normalSelectedIndex = -1;
                int simpleSelectedIndex = -1;

                while (true)
                {
                    option = Console.ReadLine();
                    if (option == "1" || option == "2" || option == "3" || option == "4")
                        break;
                    Console.Write("The entered value is not valid. Re-enter: ");
                }

                switch (option)
                {
                    case "1":
                        {
                            Console.Write("Enter a VAT number: ");
                            string inputCode = Console.ReadLine();
                            for(int i = 0; i < normalCodes.Length; i++)
                            {
                                if (normalCodes[i] == inputCode)
                                {
                                    normalSelectedIndex = i;
                                    break;
                                }
                            }

                            if (normalSelectedIndex != -1)
                            {
                                Console.Write("Enter the value of the bill: ");
                                decimal newBill;
                                while (true)
                                {
                                    if (decimal.TryParse(Console.ReadLine(), out newBill))
                                        break;
                                    Console.Write("Invalid value. Re-enter: ");
                                }
                                decimal[] oldBills = normalBills[normalSelectedIndex];
                                decimal[] bills = new decimal[oldBills.Length + 1];
                                for (int i = 0; i < oldBills.Length; i++)
                                    bills[i] = oldBills[i];
                                bills[bills.Length - 1] = newBill;
                                normalBills[normalSelectedIndex] = bills;
                            }
                            else
                            {
                                for (int i = 0; i < simpleCodes.Length; i++)
                                {
                                    if (simpleCodes[i] == inputCode)
                                    {
                                        simpleSelectedIndex = i;
                                        break;
                                    }
                                }

                                if (simpleSelectedIndex != -1)
                                {
                                    Console.Write("Enter the value of the bill: ");
                                    decimal newBill;
                                    while (true)
                                    {
                                        if (decimal.TryParse(Console.ReadLine(), out newBill))
                                            break;
                                        Console.Write("Invalid value. Re-enter: ");
                                    }
                                    decimal[] oldBills = simpleBills[simpleSelectedIndex];
                                    decimal[] bills = new decimal[oldBills.Length + 1];
                                    for (int i = 0; i < oldBills.Length; i++)
                                        bills[i] = oldBills[i];
                                    bills[bills.Length - 1] = newBill;
                                    simpleBills[simpleSelectedIndex] = bills;
                                }
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
                            for (int i = 0; i < normalCodes.Length; i++)
                            {
                                if (normalCodes[i] == inputCode)
                                {
                                    normalSelectedIndex = i;
                                    break;
                                }
                            }

                            if (normalSelectedIndex != -1)
                            {
                                Console.Write("Enter the value of the expense: ");
                                decimal newExpense;
                                while (true)
                                {
                                    if (decimal.TryParse(Console.ReadLine(), out newExpense))
                                        break;
                                    Console.Write("Invalid value. Re-enter: ");
                                }
                                decimal[] oldExpense = normalExpenses[normalSelectedIndex];
                                decimal[] expenses = new decimal[oldExpense.Length + 1];
                                for (int i = 0; i < oldExpense.Length; i++)
                                    expenses[i] = oldExpense[i];
                                expenses[expenses.Length - 1] = newExpense;
                                normalExpenses[normalSelectedIndex] = expenses;
                            }
                            else
                            {
                                for (int i = 0; i < simpleCodes.Length; i++)
                                {
                                    if (simpleCodes[i] == inputCode)
                                    {
                                        simpleSelectedIndex = i;
                                        break;
                                    }
                                }

                                if (simpleSelectedIndex != -1)
                                {
                                    Console.WriteLine("You cannot add expenses to a VAT number of type 'simple'");
                                }
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
                            for (int i = 0; i < normalCodes.Length; i++)
                            {
                                if (normalCodes[i] == inputCode)
                                {
                                    normalSelectedIndex = i;
                                    break;
                                }
                            }

                            if (normalSelectedIndex != -1)
                            {
                                decimal billTotal = 0M;
                                for(int i = 0; i < normalBills[normalSelectedIndex].Length; i++)
                                    billTotal += normalBills[normalSelectedIndex][i];

                                decimal expenseTotal = 0M;
                                for (int i = 0; i < normalExpenses[normalSelectedIndex].Length; i++)
                                    expenseTotal += normalExpenses[normalSelectedIndex][i];

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
                            else
                            {
                                for (int i = 0; i < simpleCodes.Length; i++)
                                {
                                    if (simpleCodes[i] == inputCode)
                                    {
                                        simpleSelectedIndex = i;
                                        break;
                                    }
                                }
                                // FOUND A SIMPLE VAT
                                if (simpleSelectedIndex != -1)
                                {
                                    decimal billTotal = 0M;
                                    for (int i = 0; i < simpleBills[simpleSelectedIndex].Length; i++)
                                        billTotal += simpleBills[simpleSelectedIndex][i];

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
                            for (int i = 0; i < normalCodes.Length; i++)
                                Console.WriteLine(normalCodes[i]);
                            for (int i = 0; i < simpleCodes.Length; i++)
                                Console.WriteLine(simpleCodes[i]);

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
}
