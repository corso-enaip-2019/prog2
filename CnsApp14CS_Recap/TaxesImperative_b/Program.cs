using System;

using System.Collections.Generic;

/* 20180401 */

/* PARADIGMA IMPERATIVO PIU' AVANZATO */
/* Regole:
 - si possono creare classi, ma solo come inermi contenitori di dati, cioè:
 -- si possono dichiarare solo campi pubblici
 -- niente proprietà metodi, costruttori, inizializzazioni dei campi
 - niente sottometodi, neanche statici: tutta la logica sta nel Main;
 - è possibile usare solo variabili locali, costanti, array, flussi di controllo (if/else, for, switch...);
 - per semplificare l'esercizio, è possibile usare anche le List<T>, con il metodo Add, ma è un'eccezione per non complicare troppo l'esercizio. */

namespace TaxesImperative_b
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Creazione e pre_popolamento dizionario di P_IVA
            Dictionary<string, VATNumberNormal> dicVATNr = new Dictionary<string, VATNumberNormal>();

            /* Creazione ed aggiunta per lungo, senza "scorciatoie". */
            VATNumberNormal vATNr01 = new VATNumberNormal();
            vATNr01.Bills = new List<decimal>();
            vATNr01.Expenses = new List<decimal>();
            vATNr01.VATCode = "123456";
            dicVATNr.Add(vATNr01.VATCode, vATNr01);

            VATNumberNormal vATNr02 = new VATNumberNormal();
            vATNr02.Bills = new List<decimal>();
            vATNr02.Expenses = new List<decimal>();
            vATNr02.VATCode = "654321";
            dicVATNr.Add(vATNr02.VATCode, vATNr02);

            VATNumberNormal vATNr03 = new VATNumberNormal();
            vATNr03.Bills = new List<decimal>();
            vATNr03.Expenses = new List<decimal>();
            vATNr03.VATCode = "666666";
            dicVATNr.Add(vATNr03.VATCode, vATNr03);

            VATNumberNormal vATNr04 = new VATNumberNormal();
            vATNr04.Bills = new List<decimal>();
            vATNr04.Expenses = new List<decimal>();
            vATNr04.VATCode = "111111";
            dicVATNr.Add(vATNr04.VATCode, vATNr04);
            #endregion

            #region Aggiunte di Bills
            /* Creazione ed aggiunta per lungo, senza "scorciatoie". */
            decimal[] bills01 = { 1234.25m, 1000.00m, 250.00m, 9.99m };
            vATNr01.Bills.Add(bills01[0]);
            vATNr01.Bills.Add(bills01[1]);
            vATNr01.Bills.Add(bills01[2]);
            vATNr01.Bills.Add(bills01[3]);

            decimal[] bills02 = { 4321.25m, 3000.00m, 150.00m, 99.99m };
            vATNr02.Bills.Add(bills02[0]);
            vATNr02.Bills.Add(bills02[1]);
            vATNr02.Bills.Add(bills02[2]);
            vATNr02.Bills.Add(bills02[3]);

            decimal[] bills03 = { 4444.44m, 4000.00m, 450.00m, 4.55m };
            vATNr03.Bills.Add(bills03[0]);
            vATNr03.Bills.Add(bills03[1]);
            vATNr03.Bills.Add(bills03[2]);
            vATNr03.Bills.Add(bills03[3]);

            decimal[] bills04 = { 1111.11m, 2222.22m, 3333.33m, 4444.44m };
            vATNr04.Bills.Add(bills04[0]);
            vATNr04.Bills.Add(bills04[1]);
            vATNr04.Bills.Add(bills04[2]);
            vATNr04.Bills.Add(bills04[3]);
            #endregion

            #region Aggiunte di Expenses
            /* Creazione ed aggiunta per lungo, senza "scorciatoie". */
            decimal[] expenses01 = { 100.00m, 125.0m, 50.50m };
            vATNr01.Expenses.Add(expenses01[0]);
            vATNr01.Expenses.Add(expenses01[1]);
            vATNr01.Expenses.Add(expenses01[2]);

            decimal[] expenses02 = { 500.50m, 1300.00m, 75.75m };
            vATNr02.Expenses.Add(expenses02[0]);
            vATNr02.Expenses.Add(expenses02[1]);
            vATNr02.Expenses.Add(expenses02[2]);

            decimal[] expenses03 = { 44.00m, 444.44m, 4444.00m };
            vATNr03.Expenses.Add(expenses03[0]);
            vATNr03.Expenses.Add(expenses03[1]);
            vATNr03.Expenses.Add(expenses03[2]);

            decimal[] expenses04 = { 0.01m, 0.22m, 3.33m, 44.44m };
            vATNr04.Expenses.Add(expenses04[0]);
            vATNr04.Expenses.Add(expenses04[1]);
            vATNr04.Expenses.Add(expenses04[2]);
            vATNr04.Expenses.Add(expenses04[3]);
            #endregion

            #region ConstStrings
            const string STR_NAN = "Il dato immesso NON è un numero.";
            const string STR_NOT_POSITIVE = "Il numero immesso NON è positivo.";
            const string STR_NOT_A_VAT_NR = "Il numero immesso NON corrisponde ad una P.IVA salvata.";
            const string STR_IS_A_VAT_NR = "P.IVA presente.";

            const string INPORT_IS_NEGATIVE = "L\'importo immesso è negativo.";


            #endregion

            #region ConstNumbers
            const decimal VAT_PERCENT = 22m; // IVA 22%
            const decimal INCOME_TAX = 23m; // IRPEF 38%
            const decimal SIMPLE_TAXABLE_PERCENTAGEX = 78m; // [% d'importo tassabile se P.IVA"semplice", 78%]
            const decimal TAX_PERCENTAGE = 15m; // [% aliquota se P.IVA"semplice"?, 78%]
            #endregion


            string mode = "?";

            while (mode != "quit")
            {
                string selectedMode = "?";
                string modeMessage = "/!\\ Modalità scelta ND.";

                Console.WriteLine("Immettere la modalità voluta fra:");
                Console.WriteLine(" fatt \t Aggiungi fattura a P.IVA;");
                Console.WriteLine(" spesa \t Aggiungi spesa a P.IVA;");
                Console.WriteLine(" calc \t Calcola guadagno netto e tasse totali;");
                Console.WriteLine(" mod \t Modifica P.IVA;");
                Console.WriteLine(" ele \t Elenca tutte le P.IVA;");
                Console.WriteLine();
                Console.WriteLine(" q \t Esci.");
                Console.WriteLine();

                bool isEmpty = true, selectedModeExists = false;

                /* Acquisizione modalità dall'utente. */



                /* switch per scelta modalità (con svolgimento interno). */
                /* [...] */
                //fake VATNumberNormal trovato
                VATNumberNormal selectedNormal = new VATNumberNormal();
                selectedNormal.Bills = new List<decimal>();
                selectedNormal.Expenses = new List<decimal>();
                selectedNormal.VATCode = "100000";
                //fake VATNumberSimple trovato
                VATNumberSimple selectedSimple = new VATNumberSimple();
                selectedSimple.Bills = new List<decimal>();
                selectedSimple.VATCode = "100001";

                /* [...] */
                /* Modalità Aggiunta spese. */
                #region Aggiunta spese
                /* Acquisizione n° P.IVA. */
                /* Trovata P.IVA "normale". */
                /* Trovata P.IVA "semplice". */
                /* Se è una P.IVA "semplice", non si possono inserire delle spese. */

                #endregion

                /* Modalità Calcolo tasse. */
                #region Calcolo tasse
                /* [...] */
                /* Trovata una "VATNumberNormal". */
                #region Calcolo tasse di P_IVA _normale_
                if (selectedNormal != null)
                {
                    decimal billTotal = 0.00m;
                    foreach (decimal bill in selectedNormal.Bills)
                        billTotal += bill;
                    /* [...] */
                }
                #endregion
                #region Calcolo tasse di P_IVA _semplice_
                else
                {
                    /* Trovata una "VATNumberSimple". */
                    /* Se la P.IVA è "semplice" (VATNumberSimple), cambia il calcolo delle tasse. */
                    decimal billTotal = 0.00m;
                    foreach (decimal bill in selectedNormal.Bills)
                        billTotal += bill;
                    decimal profit = 0.00m;


                    foreach (decimal bill in selectedSimple.Bills)
                    {
                        /* [...] */
                        if (profit > 0)
                        {
                            /* Calcolo delle tasse per P.IVA "semplice". */
                        }
                        else
                        {
                            /* Se non c'è un guadagno (fattura negativa), non viene tassata e quindi visualizza il guadagno (negativo) / la perdita. */
                            Console.WriteLine($"Guadagno: {profit}%");
                        }


                    }

                }
                #endregion
                #endregion


                #region Codice impostato da me da riformattare
                /*temp*/
                bool daEseguire = false;
                if (daEseguire)
                {
                    while (!selectedModeExists)
                    {
                        selectedModeExists = false;

                        while (isEmpty || !selectedModeExists)
                        {
                            isEmpty = true;
                            Console.Write("Modalità: \a");
                            selectedMode = Console.ReadLine().ToLower();
                            isEmpty = (selectedMode == null || selectedMode == "");
                            if (isEmpty)
                            {
                                Console.WriteLine("\tImmessa stringa vuota.");
                            }
                            else
                            {
                                switch (selectedMode.ToLower())
                                {
                                    case "fatt":
                                    case "f":
                                        {
                                            selectedModeExists = true;
                                            modeMessage = "\nAggiungi fattura a P.IVA.\n\nImmettere il numero di P.IVA cui aggiungere la fattura:";

                                            /* recupero stringa numero P.IVA */
                                            bool converted = false, isPresentInDictionary = false;

                                            string inStr = "";

                                            #region Acquisizione numero fattura
                                            while (!isPresentInDictionary)
                                            {
                                                Console.Write(modeMessage + " \a");

                                                isPresentInDictionary = false;

                                                inStr = Console.ReadLine();

                                                isPresentInDictionary = dicVATNr.ContainsKey(inStr);
                                                if (!isPresentInDictionary)
                                                {
                                                    Console.WriteLine(STR_NOT_A_VAT_NR);
                                                }
                                                else
                                                {
                                                    Console.WriteLine(STR_IS_A_VAT_NR);
                                                }

                                                Console.WriteLine();
                                            }
                                            #endregion

                                            //Console.WriteLine("fuori da acquisizione n° P.IVA");
                                            string activeVATNr = inStr;

                                            #region Acquisizione importo fattura
                                            decimal inDecInport = 0.00m;
                                            converted = false;

                                            while (!converted)
                                            {
                                                string inviteAddBillMessage = "Immettere l\'importo della fattura d\'aggiungere:";

                                                converted = false;
                                                isPresentInDictionary = false;

                                                Console.Write(inviteAddBillMessage + " \a");
                                                string inStrInport = Console.ReadLine();

                                                converted = decimal.TryParse(inStrInport, out inDecInport);

                                                if (!converted)
                                                {
                                                    Console.WriteLine(STR_NAN);
                                                }
                                                else
                                                {
                                                    if (inDecInport < 0)
                                                    {
                                                        Console.WriteLine(INPORT_IS_NEGATIVE);
                                                    }

                                                    Console.WriteLine($"Importo della fattura: {inDecInport}€.");
                                                }

                                                Console.WriteLine();
                                            }
                                            #endregion

                                            //Console.WriteLine("fuori da acquisizione valore fattura");
                                            decimal billValue = inDecInport;

                                            /* Aggiunta effettiva della fattura. */
                                            dicVATNr[activeVATNr].Bills.Add(billValue);

                                            /* Stampa di tutte le fatture di quella P.IVA. */
                                            Console.WriteLine("P.IVA: " + dicVATNr[activeVATNr].VATCode.ToString());
                                            Console.WriteLine("Fatture:");
                                            foreach (decimal bill in dicVATNr[activeVATNr].Bills)
                                            {
                                                //string billStr = string.Format($"{0m:000'000'000,##}", bill);
                                                //Console.WriteLine(billStr.PadLeft(15));
                                                Console.WriteLine(bill.ToString().PadLeft(15));
                                            }

                                            break;
                                        }

                                    case "spes":
                                    case "s":
                                        {
                                            selectedModeExists = true;
                                            modeMessage = "Immettere il numero di P.IVA cui aggiungere la spesa: \a";
                                            break;
                                        }
                                    case "calc":
                                    case "c":
                                        {
                                            selectedModeExists = true;
                                            modeMessage = "Immettere il numero di P.IVA cui calcolare guadagno netto e tasse totali: \a";
                                            break;
                                        }

                                    case "mod":
                                    case "m":
                                        {
                                            selectedModeExists = true;
                                            modeMessage = "Immettere il numero di P.IVA della P.IVA da modificare: \a";
                                            break;
                                        }

                                    case "ele":
                                    case "e":
                                        {
                                            selectedModeExists = true;

                                            Console.WriteLine();
                                            modeMessage = "Visualizza tutte le P.IVA: ";
                                            Console.WriteLine();

                                            Console.WriteLine(modeMessage);

                                            foreach (string vATNr in dicVATNr.Keys)
                                            {
                                                Console.WriteLine($" » {dicVATNr[vATNr].VATCode}");
                                            }
                                            break;
                                        }

                                    case "quit":
                                    case "q":
                                        {
                                            selectedModeExists = true;
                                            modeMessage = "Uscita ...";
                                            break;
                                        }

                                    default:
                                        {
                                            Console.WriteLine($"Modalità scelta ({selectedMode}) non disponibile.");
                                            selectedModeExists = false;

                                            throw new InvalidOperationException();

                                            break;
                                        }
                                }
                            }
                        }


                        Console.Write("... Uscita ... ");
                        Console.ReadLine();
                        return;
                    }
                    #endregion 
                }
            }
        }
    }
}