using System;

using System.Collections.Generic;

namespace TaxesOO
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Creazione e pre_popolamento liste di P_IVA
            List<VATNumber> vATs = new List<VATNumber>();
            vATs.AddRange(CreateMockVATs());
            #endregion

            Console.WriteLine("*** VAT Numbers Management System ***");
            Console.WriteLine();

            bool rePlay = true;

            while (rePlay)
            {
                rePlay = true;
                string selectedMode = AskSelectMode();

                switch (selectedMode.ToLower())
                {
                    case "spes":
                    case "s":
                        {
                            AddBillToA_VATNr(vATs);
                            break;
                        }
                    case "calc":
                    case "c":
                        {
                            CalculateTaxesOfA_VATNr(vATs);
                            break;
                        }
                    case "mod":
                    case "m":
                        {
                            EditVATNr(vATs);
                            break;
                        }
                    case "ele":
                    case "e":
                        {
                            ListAllVATNrs(vATs);
                            break;
                        }

                    case "quit":
                    case "q":
                        {
                            rePlay = false;
                            break;
                        }

                    default:
                        {
                            Console.WriteLine($"Modalità scelta non disponibile.");
                            throw new InvalidOperationException();
                            //break;
                        }
                }
            }

            return;
        }

        // incompleto
        static public List<VATNumber> CreateMockVATs()
        {
            return new List<VATNumber>
            /* devo popolare il nuovo oggettto che finirà come return. */
            {
                {
                    new VATNumberNormal
                    {
                        VATCode="123",
                        Bills=new List<decimal> { 200m,300m,400m},
                        Expenses=new List<decimal> { 100m,150m,500m}
                    }
                },
                {
                    new VATNumberNormal
                    {
                    VATCode = "456",
                    Bills = new List<decimal> { 150m, 250m, 350m },
                    Expenses = new List<decimal> { 50m, 100m, 450m }
                    }
                },
                {
                    new VATNumberNormal
                    {
                    VATCode = "789",
                    Bills = new List<decimal> { 1150m, 1250m, 1350m },
                    Expenses = new List<decimal> { 150m, 1100m, 1450m }
                    }
                },
                {
                    new VATNumberSimple
                    {
                        VATCode="321",
                        Bills=new List<decimal> { 222m,333m,444m},
                    }
                },
                {
                    new VATNumberSimple
                    {
                    VATCode = "654",
                    Bills = new List<decimal> { 1500m, 2500m, 3500m },
                    }
                },
                {
                    new VATNumberSimple
                    {
                    VATCode = "987",
                    Bills = new List<decimal> { 150m, 100m, 0m },
                    }
                },
            };
        }

        //ora +0- inutile
        static public Dictionary<string, VATNumberNormal> CreateNormalMockVATs()
        {
            /* Creazione e pre_popolamento dizionari di P_IVA (simple), per lungo. */
            Dictionary<string, VATNumberNormal> dicVATNormal = new Dictionary<string, VATNumberNormal>();

            #region #region Creazione ed aggiunta P_IVA
            VATNumberNormal vAT_N1 = new VATNumberNormal();
            vAT_N1.Bills = new List<decimal>();
            vAT_N1.Expenses = new List<decimal>();
            vAT_N1.VATCode = "123456";
            dicVATNormal.Add(vAT_N1.VATCode, vAT_N1);

            VATNumberNormal vAT_N2 = new VATNumberNormal();
            vAT_N2.Bills = new List<decimal>();
            vAT_N2.Expenses = new List<decimal>();
            vAT_N2.VATCode = "654321";
            dicVATNormal.Add(vAT_N2.VATCode, vAT_N2);

            VATNumberNormal vAT_N3 = new VATNumberNormal();
            vAT_N3.Bills = new List<decimal>();
            vAT_N3.Expenses = new List<decimal>();
            vAT_N3.VATCode = "666666";
            dicVATNormal.Add(vAT_N2.VATCode, vAT_N3);
            #endregion

            #region Aggiunte di Bills
            decimal[] billsN1 = { 1234.25m, 1000.00m, 250.00m, 9.99m };
            vAT_N1.Bills.Add(billsN1[0]);
            vAT_N1.Bills.Add(billsN1[1]);
            vAT_N1.Bills.Add(billsN1[2]);
            vAT_N1.Bills.Add(billsN1[3]);

            decimal[] billsN2 = { 4321.25m, 3000.00m, 150.00m, 99.99m };
            vAT_N2.Bills.Add(billsN2[0]);
            vAT_N2.Bills.Add(billsN2[1]);
            vAT_N2.Bills.Add(billsN2[2]);
            vAT_N2.Bills.Add(billsN2[3]);

            decimal[] billsN3 = { 4444.44m, 4000.00m, 450.00m, 4.55m };
            vAT_N3.Bills.Add(billsN3[0]);
            vAT_N3.Bills.Add(billsN3[1]);
            vAT_N3.Bills.Add(billsN3[2]);
            vAT_N3.Bills.Add(billsN3[3]);
            #endregion

            #region Aggiunte di Expenses
            decimal[] expenses01 = { 100.00m, 125.0m, 50.50m };
            vAT_N1.Expenses.Add(expenses01[0]);
            vAT_N1.Expenses.Add(expenses01[1]);
            vAT_N1.Expenses.Add(expenses01[2]);

            decimal[] expenses02 = { 500.50m, 1300.00m, 75.75m };
            vAT_N2.Expenses.Add(expenses02[0]);
            vAT_N2.Expenses.Add(expenses02[1]);
            vAT_N2.Expenses.Add(expenses02[2]);

            decimal[] expenses03 = { 44.00m, 444.44m, 4444.00m };
            vAT_N3.Expenses.Add(expenses03[0]);
            vAT_N3.Expenses.Add(expenses03[1]);
            vAT_N3.Expenses.Add(expenses03[2]);
            #endregion

            return dicVATNormal;
        }

        //ora +0- inutile
        static public List<VATNumber> CreateSimpleMockVATs()
        //static public Dictionary<string, VATNumberSimple> CreateSimpleMockVATs()
        {
            /* Creazione e pre_popolamento dizionari di P_IVA (simple), per lungo. */
            Dictionary<string, VATNumberSimple> dicVATSimple = new Dictionary<string, VATNumberSimple>();

            #region Creazione ed aggiunta P_IVA
            VATNumberSimple vAT_S1 = new VATNumberSimple();
            vAT_S1.Bills = new List<decimal>();
            vAT_S1.VATCode = "222222";
            dicVATSimple.Add(vAT_S1.VATCode, vAT_S1);

            VATNumberSimple vAT_S2 = new VATNumberSimple();
            vAT_S2.Bills = new List<decimal>();
            vAT_S2.VATCode = "333333";
            dicVATSimple.Add(vAT_S2.VATCode, vAT_S2);

            VATNumberSimple vAT_S3 = new VATNumberSimple();
            vAT_S3.Bills = new List<decimal>();
            vAT_S3.VATCode = "741000";
            dicVATSimple.Add(vAT_S3.VATCode, vAT_S3);

            VATNumberSimple vAT_S4 = new VATNumberSimple();
            vAT_S4.Bills = new List<decimal>();
            vAT_S4.VATCode = "111111";
            dicVATSimple.Add(vAT_S4.VATCode, vAT_S4);
            #endregion

            #region Aggiunte di Bills
            /* Creazione ed aggiunta per lungo, senza "scorciatoie". */
            decimal[] bills_S1 = { 1111.11m, 2222.22m, 3333.33m, 4444.44m };
            vAT_S1.Bills.Add(bills_S1[0]);
            vAT_S1.Bills.Add(bills_S1[1]);
            vAT_S1.Bills.Add(bills_S1[2]);
            vAT_S1.Bills.Add(bills_S1[3]);

            decimal[] bills_S2 = { 1111.11m, 2222.22m, 3333.33m, 4444.44m };
            vAT_S2.Bills.Add(bills_S2[0]);
            vAT_S2.Bills.Add(bills_S2[1]);
            vAT_S2.Bills.Add(bills_S2[2]);
            vAT_S2.Bills.Add(bills_S2[3]);

            decimal[] bills_S3 = { 1111.11m, 2222.22m, 3333.33m, 4444.44m };
            vAT_S3.Bills.Add(bills_S3[0]);
            vAT_S3.Bills.Add(bills_S3[1]);
            vAT_S3.Bills.Add(bills_S3[2]);
            vAT_S3.Bills.Add(bills_S3[3]);

            decimal[] bills_S4 = { 1111.11m, 2222.22m, 3333.33m, 4444.44m };
            vAT_S4.Bills.Add(bills_S4[0]);
            vAT_S4.Bills.Add(bills_S4[1]);
            vAT_S4.Bills.Add(bills_S4[2]);
            vAT_S4.Bills.Add(bills_S4[3]);
            #endregion

            /* I "simple" non hanno Expenses. */

            //return dicVATSimple;
            /*temporaneo aggiustamento*/
            List<VATNumber> outList = new List<VATNumber>();
            foreach (string vATKey in dicVATSimple.Keys)
            { outList.Add(dicVATSimple[vATKey]); }
            return outList;
        }

        //done
        static string AskSelectMode()
        {
            while (true)
            {
                ListOptionsDumb();
                Console.WriteLine();

                /* Controlla se l'opzione esiste. */
                string option = "?";
                while (true)
                {
                    option = Console.ReadLine().ToLower();
                    if (option == "fatt" || option == "f" || option == "spes" || option == "s" || option == "calc" || option == "c" || option == "mod" || option == "m" || option == "ele" || option == "e" || option == "quit" || option == "q")
                        return option;
                    Console.Write($"La modalità immessa (\"{option}\") non esiste.\nImmettere la modalità voluta: \a");
                }
            }
            //return option;
        }

        static void ListOptionsDumb()
        {
            Console.WriteLine("Immettere la modalità voluta fra:");
            Console.WriteLine(" f \t fatt \t Aggiungi fattura a P.IVA;");
            Console.WriteLine(" s \t spesa \t Aggiungi spesa a P.IVA;");
            Console.WriteLine(" c \t calc \t Calcola guadagno netto e tasse totali;");
            Console.WriteLine(" m \t mod \t Modifica P.IVA;");
            Console.WriteLine(" e \t ele \t Elenca tutte le P.IVA;");
            Console.WriteLine();
            Console.WriteLine(" q \t quit \t Esci.");
        }


        static VATNumberNormal SearchVATNr(List<VATNumber> vATs)
        {
            VATNumberNormal foudVATNormal = new VATNumberNormal();

            return foudVATNormal;
        }

        static void AddBillToA_VATNr(List<VATNumber> vATs)
        {
            VATNumber selected = SelectVAT(vATs);
            if (selected != null)
                selected.AddBill();
            else
            { /* ??? */ }

            //#region ConstStrings
            //const string STR_NAN = "Il dato immesso NON è un numero.";
            //const string STR_NOT_POSITIVE = "Il numero immesso NON è positivo.";
            //const string STR_NOT_A_VAT_NR = "Il numero immesso NON corrisponde ad una P.IVA salvata.";
            //const string STR_IS_A_VAT_NR = "P.IVA presente.";

            //const string IMPORT_IS_NEGATIVE = "L\'importo immesso è negativo.";

            //const string INVITE_BILL = "Immettere l\'importo della fattura d\'aggiungere: \a";
            //const string STR_ERR_BILL = "Valore immesso non valido.";
            //#endregion

            //Console.Write("Enter a VAT number: ");
            //string inputCode = Console.ReadLine();

            ///* Cerca nelle P.IVA "normali". */
            ///* Creazione d'un oggetto VATNumberNormal vuoto/null. */
            //VATNumberNormal selectedNormal = null;
            //foreach (string vAT in vATs)
            //{
            //    //if (vATs.TCode == inputCode)
            //    //{
            //    //    /* Se esiste una P.IVA corrispondente di tipo "normale",
            //    //     * viene "riempito" l'oggetto « selectedNormal » con la corrispettiva P.IVA
            //    //     * (altrimenti l'oggetto resta vuoto/null). */
            //    //    selectedNormal = normals[vATKey];
            //    //    break;
            //    //}
            //}

            ///* Trovata una P.IVA "normale" (l'oggetto « selectedNormal » è stato "riempito" quindi non è più vuoto/null). */
            //if (selectedNormal != null)
            //{
            //    Console.Write(INVITE_BILL);
            //    decimal newBill;
            //    while (true)
            //    {
            //        if (decimal.TryParse(Console.ReadLine(), out newBill))
            //            break;
            //        Console.WriteLine(STR_ERR_BILL);

            //    }
            //    selectedNormal.Bills.Add(newBill);
            //}
            ///* Cerca nelle P.IVA "semplici" (se non è una P.IVA "normale" ...). */
            //else
            //{
            //    /* Creazione d'un oggetto VATNumberNormal vuoto/null. */
            //    VATNumberSimple selectedSimple = null;
            //    //foreach (string vATKey in simples.Keys)
            //    //{
            //    //    if (simples[vATKey].VATCode == inputCode)
            //    //    {
            //    //        selectedSimple = simples[vATKey];
            //    //        break;
            //    //    }
            //    //}
            //    /* Trovata una P.IVA "normale" (l'oggetto « selectedSimple » è stato "riempito" quindi non è più vuoto/null). */
            //    if (selectedSimple != null)
            //    {
            //        Console.Write(INVITE_BILL);
            //        decimal newBill;
            //        while (true)
            //        {
            //            if (decimal.TryParse(Console.ReadLine(), out newBill))
            //                break;
            //            Console.WriteLine(STR_ERR_BILL);
            //            Console.Write(INVITE_BILL);
            //        }
            //        selectedSimple.Bills.Add(newBill);
            //    }
            //    /* P.IVA non trovata. */
            //    else
            //    {
            //        Console.WriteLine(STR_NOT_A_VAT_NR);
            //    }
            //}

            ////break;
            return;
        }

        static void AddExpenseToA_VATNr(List<VATNumber> vATs)
        {
            #region ConstStrings
            const string STR_NAN = "Il dato immesso NON è un numero.";
            const string STR_NOT_POSITIVE = "Il numero immesso NON è positivo.";
            const string STR_NOT_A_VAT_NR = "Il numero immesso NON corrisponde ad una P.IVA salvata.";
            const string STR_IS_A_VAT_NR = "P.IVA presente.";

            const string IMPORT_IS_NEGATIVE = "L\'importo immesso è negativo.";

            const string INVITE_BILL = "Immettere l\'importo della fattura d\'aggiungere: \a";
            const string STR_ERR_BILL = "Valore immesso non valido.";
            #endregion

            Console.Write("Immettere il numero della P.IVA.");
            string inputCode = Console.ReadLine();

            // LOOK IN NORMALS
            VATNumberNormal selectedNormal = null;
            //foreach (string vATKey in normals.Keys)
            //{
            //    if (normals[vATKey].VATCode == inputCode)
            //    {
            //        selectedNormal = normals[vATKey];
            //        break;
            //    }
            //}

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
                VATNumberSimple selectedSimple = null;
                //foreach (string vATKey in simples.Keys)
                //{
                //    if (simples[vATKey].VATCode == inputCode)
                //    {
                //        selectedSimple = simples[vATKey];
                //        break;
                //    }
                //}
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
            // break;

        }

        static void CalculateTaxesOfA_VATNr(List<VATNumber> vATs)
        {
            #region Const Tax values
            const decimal VAT_PERCENTAGE = 22m; // IVA 22%
            const decimal INCOME_TAX = 23m; // IRPEF 38%
            const decimal SIMPLE_TAXABLE_PERCENTAGE = 78m; // [% d'importo tassabile se P.IVA"semplice", 78%]
            const decimal SIMPLE_TAX_PERCENTAGE = 15m; // [% aliquota se P.IVA"semplice"?, 78%]
            #endregion

            Console.Write("Enter a VAT number: ");
            string inputCode = Console.ReadLine();

            // LOOK IN NORMALS
            VATNumberNormal selectedNormal = null;
            //foreach (string vATKey in normals.Keys)
            //{
            //    if (normals[vATKey].VATCode == inputCode)
            //    {
            //        selectedNormal = normals[vATKey];
            //        break;
            //    }
            //}

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
                    decimal VATAmount = profit * VAT_PERCENTAGE / 100;
                    decimal profitWithoutVAT = profit - VATAmount;
                    decimal incomeTaxAmount = profitWithoutVAT * INCOME_TAX / 100;
                    decimal net = profitWithoutVAT - incomeTaxAmount;
                    decimal taxTotal = VATAmount + incomeTaxAmount;

                    Console.WriteLine($"Total net gain: {net}; total taxes: {taxTotal}");
                }
                else
                {
                    Console.WriteLine("Profit: {profit}; total taxes: 0");
                }
            }
            // LOOK FOR A SIMPLE VAT
            else
            {
                // LOOK INTO SIMPLES
                VATNumberSimple selectedSimple = null;
                //foreach (string vatKey in simples.Keys)
                //{
                //    if (simples[vatKey].VATCode == inputCode)
                //    {
                //        selectedSimple = simples[vatKey];
                //        break;
                //    }
                //}
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
        }

        //0
        static void EditVATNr(List<VATNumber> vATs)
        {
            return;
        }

        //done
        static void ListAllVATNrs(List<VATNumber> vATs)
        {
            foreach (VATNumber vN in vATs)
                Console.WriteLine(vN.VATCode);

            return;
        }

        //0
        private static VATNumber SelectVAT(List<VATNumber> vATs)
        {
            VATNumber selected = new VATNumberNormal();
            return selected;
        }

        //incompleta
        private static void CalculateTotalsOfA_VATNr(List<VATNumber> vATs)
        {
            VATNumber selected = SelectVAT(vATs);

        }
    }
}