using System;

using System.Collections.Generic;

/* 20180401 */

/* PARADIGMA PROCEDURALE */
/* Regole:
 - si possono creare classi, ma solo come inermi contenitori di dati, cioè:
       - si possono dichiarare solo campi pubblici
       - niente proprietà metodi, costruttori, inizializzazioni dei campi
 - si può organizzare la logica in sottofunzioni, ma solo in forma di metodi static nella classe Program;
 - è possibile usare solo variabili locali, costanti, array, flussi di controllo (if/else, for, switch...);
 - per semplificare l'esercizio, è possibile usare anche le List<T>, con il metodo Add, ma è un'eccezione per non complicare troppo l'esercizio. */

namespace TaxesProcedural_a
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Creazione e pre_popolamento
            Dictionary<string, VATNumberNormal> vATNormals = new Dictionary<string, VATNumberNormal>();
            Dictionary<string, VATNumberSimple> vATSimples = new Dictionary<string, VATNumberSimple>();
            vATNormals = CreateNormalMock();
            vATSimples = CreateSimpleMock();

            #region Old_Creazione e pre_popolamento
            //#region Creazione e pre_popolamento dizionari di P_IVA (normal/simple)
            //Dictionary<string, VATNumberNormal> dicVATNormal = new Dictionary<string, VATNumberNormal>();
            //Dictionary<string, VATNumberSimple> dicVATSimple = new Dictionary<string, VATNumberSimple>();

            ///* Creazione ed aggiunta per lungo, senza "scorciatoie". */
            ///* "normali" */
            //VATNumberNormal vAT_N1 = new VATNumberNormal();
            //vAT_N1.Bills = new List<decimal>();
            //vAT_N1.Expenses = new List<decimal>();
            //vAT_N1.VATCode = "123456";
            //dicVATNormal.Add(vAT_N1.VATCode, vAT_N1);

            //VATNumberNormal vAT_N2 = new VATNumberNormal();
            //vAT_N2.Bills = new List<decimal>();
            //vAT_N2.Expenses = new List<decimal>();
            //vAT_N2.VATCode = "654321";
            //dicVATNormal.Add(vAT_N2.VATCode, vAT_N2);

            //VATNumberNormal vAT_N3 = new VATNumberNormal();
            //vAT_N3.Bills = new List<decimal>();
            //vAT_N3.Expenses = new List<decimal>();
            //vAT_N3.VATCode = "666666";
            //dicVATNormal.Add(vAT_N2.VATCode, vAT_N3);

            ///* "semplici" */
            //VATNumberSimple vAT_S1 = new VATNumberSimple();
            //vAT_S1.Bills = new List<decimal>();
            //vAT_S1.VATCode = "222222";
            //dicVATSimple.Add(vAT_S1.VATCode, vAT_S1);

            //VATNumberSimple vAT_S2 = new VATNumberSimple();
            //vAT_S2.Bills = new List<decimal>();
            //vAT_S2.VATCode = "333333";
            //dicVATSimple.Add(vAT_S2.VATCode, vAT_S2);

            //VATNumberSimple vAT_S3 = new VATNumberSimple();
            //vAT_S3.Bills = new List<decimal>();
            //vAT_S3.VATCode = "741000";
            //dicVATSimple.Add(vAT_S3.VATCode, vAT_S3);

            //VATNumberSimple vAT_S4 = new VATNumberSimple();
            //vAT_S4.Bills = new List<decimal>();
            //vAT_S4.VATCode = "111111";
            //dicVATSimple.Add(vAT_S4.VATCode, vAT_S4);
            //#endregion

            //#region Aggiunte di Bills
            ///* Creazione ed aggiunta per lungo, senza "scorciatoie". */
            ///* "normali" */
            //decimal[] billsN1 = { 1234.25m, 1000.00m, 250.00m, 9.99m };
            //vAT_N1.Bills.Add(billsN1[0]);
            //vAT_N1.Bills.Add(billsN1[1]);
            //vAT_N1.Bills.Add(billsN1[2]);
            //vAT_N1.Bills.Add(billsN1[3]);

            //decimal[] billsN2 = { 4321.25m, 3000.00m, 150.00m, 99.99m };
            //vAT_N2.Bills.Add(billsN2[0]);
            //vAT_N2.Bills.Add(billsN2[1]);
            //vAT_N2.Bills.Add(billsN2[2]);
            //vAT_N2.Bills.Add(billsN2[3]);

            //decimal[] billsN3 = { 4444.44m, 4000.00m, 450.00m, 4.55m };
            //vAT_N3.Bills.Add(billsN3[0]);
            //vAT_N3.Bills.Add(billsN3[1]);
            //vAT_N3.Bills.Add(billsN3[2]);
            //vAT_N3.Bills.Add(billsN3[3]);

            ///* "semplici" */
            //decimal[] bills_S1 = { 1111.11m, 2222.22m, 3333.33m, 4444.44m };
            //vAT_S1.Bills.Add(bills_S1[0]);
            //vAT_S1.Bills.Add(bills_S1[1]);
            //vAT_S1.Bills.Add(bills_S1[2]);
            //vAT_S1.Bills.Add(bills_S1[3]);

            //decimal[] bills_S2 = { 1111.11m, 2222.22m, 3333.33m, 4444.44m };
            //vAT_S2.Bills.Add(bills_S2[0]);
            //vAT_S2.Bills.Add(bills_S2[1]);
            //vAT_S2.Bills.Add(bills_S2[2]);
            //vAT_S2.Bills.Add(bills_S2[3]);

            //decimal[] bills_S3 = { 1111.11m, 2222.22m, 3333.33m, 4444.44m };
            //vAT_S3.Bills.Add(bills_S3[0]);
            //vAT_S3.Bills.Add(bills_S3[1]);
            //vAT_S3.Bills.Add(bills_S3[2]);
            //vAT_S3.Bills.Add(bills_S3[3]);

            //decimal[] bills_S4 = { 1111.11m, 2222.22m, 3333.33m, 4444.44m };
            //vAT_S4.Bills.Add(bills_S4[0]);
            //vAT_S4.Bills.Add(bills_S4[1]);
            //vAT_S4.Bills.Add(bills_S4[2]);
            //vAT_S4.Bills.Add(bills_S4[3]);
            //#endregion

            //#region Aggiunte di Expenses
            ///* Creazione ed aggiunta per lungo, senza "scorciatoie". */
            ///* "normali" */
            //decimal[] expenses01 = { 100.00m, 125.0m, 50.50m };
            //vAT_N1.Expenses.Add(expenses01[0]);
            //vAT_N1.Expenses.Add(expenses01[1]);
            //vAT_N1.Expenses.Add(expenses01[2]);

            //decimal[] expenses02 = { 500.50m, 1300.00m, 75.75m };
            //vAT_N2.Expenses.Add(expenses02[0]);
            //vAT_N2.Expenses.Add(expenses02[1]);
            //vAT_N2.Expenses.Add(expenses02[2]);

            //decimal[] expenses03 = { 44.00m, 444.44m, 4444.00m };
            //vAT_N3.Expenses.Add(expenses03[0]);
            //vAT_N3.Expenses.Add(expenses03[1]);
            //vAT_N3.Expenses.Add(expenses03[2]);
            //#endregion
            #endregion
            #endregion

            #region ConstStrings
            const string STR_NAN = "Il dato immesso NON è un numero.";
            const string STR_NOT_POSITIVE = "Il numero immesso NON è positivo.";
            const string STR_NOT_A_VAT_NR = "Il numero immesso NON corrisponde ad una P.IVA salvata.";
            const string STR_IS_A_VAT_NR = "P.IVA presente.";

            const string INPORT_IS_NEGATIVE = "L\'importo immesso è negativo.";
            #endregion

            #region Vecchio pre-popolamento
            /*
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
            */
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
                            AddBillToA_VATNr(vATNormals, vATSimples);
                            break;
                        }
                    case "calc":
                    case "c":
                        {
                            CalculateTaxesOfA_VATNr(vATNormals, vATSimples);
                            break;
                        }
                    case "mod":
                    case "m":
                        {
                            EditVATNr(vATNormals, vATSimples);
                            break;
                        }
                    case "ele":
                    case "e":
                        {
                            ListAllVATNrs(vATNormals, vATSimples);
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
                Console.WriteLine("Immettere la modalità voluta fra:");
                Console.WriteLine(" fatt \t Aggiungi fattura a P.IVA;");
                Console.WriteLine(" spesa \t Aggiungi spesa a P.IVA;");
                Console.WriteLine(" calc \t Calcola guadagno netto e tasse totali;");
                Console.WriteLine(" mod \t Modifica P.IVA;");
                Console.WriteLine(" ele \t Elenca tutte le P.IVA;");
                Console.WriteLine();
                Console.WriteLine(" q \t Esci.");
                Console.WriteLine();

                // READ A VALID OPTION
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

        static VATNumberNormal SearchVATNrNormal(Dictionary<string, VATNumberNormal> normals)
        {
            VATNumberNormal foudVATNormal = new VATNumberNormal();

            return foudVATNormal;
        }

        static VATNumberSimple SearchVATNrSimple(Dictionary<string, VATNumberSimple> simples)
        {
            VATNumberSimple foundVATSimple = new VATNumberSimple();

            return foundVATSimple;
        }

        static void AddBillToA_VATNr(Dictionary<string, VATNumberNormal> normals, Dictionary<string, VATNumberSimple> simples)
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
            foreach (string vATKey in normals.Keys)
            {
                if (normals[vATKey].VATCode == inputCode)
                {
                    /* Se esiste una P.IVA corrispondente di tipo "normale",
                     * viene "riempito" l'oggetto « selectedNormal » con la corrispettiva P.IVA
                     * (altrimenti l'oggetto resta vuoto/null). */
                    selectedNormal = normals[vATKey];
                    break;
                }
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
                foreach (string vATKey in simples.Keys)
                {
                    if (simples[vATKey].VATCode == inputCode)
                    {
                        selectedSimple = simples[vATKey];
                        break;
                    }
                }
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

        static void AddExpenseToAVATNr(Dictionary<string, VATNumberNormal> normals, Dictionary<string, VATNumberSimple> simples)
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
            foreach (string vATKey in normals.Keys)
            {
                if (normals[vATKey].VATCode == inputCode)
                {
                    selectedNormal = normals[vATKey];
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
                VATNumberSimple selectedSimple = null;
                foreach (string vATKey in simples.Keys)
                {
                    if (simples[vATKey].VATCode == inputCode)
                    {
                        selectedSimple = simples[vATKey];
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
            // break;

        }

        static void CalculateTaxesOfA_VATNr(Dictionary<string, VATNumberNormal> normals, Dictionary<string, VATNumberSimple> simples)
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
            foreach (string vATKey in normals.Keys)
            {
                if (normals[vATKey].VATCode == inputCode)
                {
                    selectedNormal = normals[vATKey];
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
                foreach (string vatKey in simples.Keys)
                {
                    if (simples[vatKey].VATCode == inputCode)
                    {
                        selectedSimple = simples[vatKey];
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
        }

        static void EditVATNr(Dictionary<string, VATNumberNormal> normals, Dictionary<string, VATNumberSimple> simples)
        {
            return;
        }

        static void ListAllVATNrs(Dictionary<string, VATNumberNormal> normals, Dictionary<string, VATNumberSimple> simples)
        {
            foreach (string vn in normals.Keys)
                Console.WriteLine(normals[vn].VATCode);
            foreach (string vs in simples.Keys)
                Console.WriteLine(simples[vs].VATCode);
        }
    }

    #region vecchie classi NormalVatNumber e SimpleVatNumber
    /* 
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
    */
    #endregion
}
