﻿using System;

using System.Collections.Generic;

/* 20180401 */
/* PARADIGMA PROCEDURALE + Con una singola lista di P.IVA + Metodi delle classi. */
/* Regole:
 - si possono creare classi, ma solo come inermi contenitori di dati, cioè:
       - si possono dichiarare solo campi pubblici
       - niente proprietà metodi, costruttori, inizializzazioni dei campi
 - si può organizzare la logica in sottofunzioni, ma solo in forma di metodi static nella classe Program;
 - è possibile usare solo variabili locali, costanti, array, flussi di controllo (if/else, for, switch...);
 - per semplificare l'esercizio, è possibile usare anche le List<T>, con il metodo Add, ma è un'eccezione per non complicare troppo l'esercizio. */

namespace TaxesProcedural_c
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Creazione e pre_popolamento liste di P_IVA
            Dictionary<string, VATNumberNormal> vAT_Normals = new Dictionary<string, VATNumberNormal>();
            Dictionary<string, VATNumberSimple> vAT_Simples = new Dictionary<string, VATNumberSimple>();

            vAT_Normals = CreateNormalMock();
            vAT_Simples = CreateSimpleMock();

            /* Creazione della lista unica (vATs = vAT_Normals + vAT_Simples). */
            List<object> vATs = new List<object>();
            foreach (string vATKey in vAT_Normals.Keys)
            {
                vATs.Add(vAT_Normals[vATKey]);
            }
            foreach (string vATKey in vAT_Simples.Keys)
            {
                vATs.Add(vAT_Simples[vATKey]);
            }
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

        static public Dictionary<string, VATNumberNormal> CreateNormalMock()
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

        static public Dictionary<string, VATNumberSimple> CreateSimpleMock()
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

            return dicVATSimple;
        }

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
            Console.WriteLine(" fatt \t Aggiungi fattura a P.IVA;");
            Console.WriteLine(" spesa \t Aggiungi spesa a P.IVA;");
            Console.WriteLine(" calc \t Calcola guadagno netto e tasse totali;");
            Console.WriteLine(" mod \t Modifica P.IVA;");
            Console.WriteLine(" ele \t Elenca tutte le P.IVA;");
            Console.WriteLine();
            Console.WriteLine(" q \t Esci.");
        }


        static VATNumberNormal SearchVATNr(List<object> vATs)
        {
            VATNumberNormal foudVATNormal = new VATNumberNormal();

            return foudVATNormal;
        }

        static void AddBillToA_VATNr(List<object> vATs)
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

            Console.Write("Enter a VAT number: ");
            string inputCode = Console.ReadLine();

            /* Cerca nelle P.IVA "normali". */
            /* Creazione d'un oggetto VATNumberNormal vuoto/null. */
            VATNumberNormal selectedNormal = null;
            foreach (string vAT in vATs)
            {
                //if (vATs.TCode == inputCode)
                //{
                //    /* Se esiste una P.IVA corrispondente di tipo "normale",
                //     * viene "riempito" l'oggetto « selectedNormal » con la corrispettiva P.IVA
                //     * (altrimenti l'oggetto resta vuoto/null). */
                //    selectedNormal = normals[vATKey];
                //    break;
                //}
            }

            /* Trovata una P.IVA "normale" (l'oggetto « selectedNormal » è stato "riempito" quindi non è più vuoto/null). */
            if (selectedNormal != null)
            {
                Console.Write(INVITE_BILL);
                decimal newBill;
                while (true)
                {
                    if (decimal.TryParse(Console.ReadLine(), out newBill))
                        break;
                    Console.WriteLine(STR_ERR_BILL);

                }
                selectedNormal.Bills.Add(newBill);
            }
            /* Cerca nelle P.IVA "semplici" (se non è una P.IVA "normale" ...). */
            else
            {
                /* Creazione d'un oggetto VATNumberNormal vuoto/null. */
                VATNumberSimple selectedSimple = null;
                //foreach (string vATKey in simples.Keys)
                //{
                //    if (simples[vATKey].VATCode == inputCode)
                //    {
                //        selectedSimple = simples[vATKey];
                //        break;
                //    }
                //}
                /* Trovata una P.IVA "normale" (l'oggetto « selectedSimple » è stato "riempito" quindi non è più vuoto/null). */
                if (selectedSimple != null)
                {
                    Console.Write(INVITE_BILL);
                    decimal newBill;
                    while (true)
                    {
                        if (decimal.TryParse(Console.ReadLine(), out newBill))
                            break;
                        Console.WriteLine(STR_ERR_BILL);
                        Console.Write(INVITE_BILL);
                    }
                    selectedSimple.Bills.Add(newBill);
                }
                /* P.IVA non trovata. */
                else
                {
                    Console.WriteLine(STR_NOT_A_VAT_NR);
                }
            }

            //break;
            return;
        }

        static void AddExpenseToAVATNr(List<object> vATs)
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

        static void CalculateTaxesOfA_VATNr(List<object> vATs)
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

        static void EditVATNr(List<object> vATs)
        {
            return;
        }

        static void ListAllVATNrs(List<object> vATs)
        {
            //foreach (string vn in normals.Keys)
            //    Console.WriteLine(normals[vn].VATCode);
            //foreach (string vs in simples.Keys)
            //    Console.WriteLine(simples[vs].VATCode);

            return;
        }

        private static void CalculateTotalsOfA_VATNr(List<object> vATs)
        {

        }
    }
}