using System;

using System.Collections.Generic;

namespace TaxesProcedural
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Creazione e pre_popolamento dizionario di P_IVA
            Dictionary<int, VATNumberNormal> dicVATNr = new Dictionary<int, VATNumberNormal>();

            VATNumberNormal vATNr01 = new VATNumberNormal(123456);
            VATNumberNormal vATNr02 = new VATNumberNormal(654321);
            VATNumberNormal vATNr03 = new VATNumberNormal(666666);

            dicVATNr.Add(vATNr01.VATCode, vATNr01);
            dicVATNr.Add(vATNr02.VATCode, vATNr02);
            dicVATNr.Add(vATNr03.VATCode, vATNr03);

            /* Creazione ed aggiunta per lungo, senza "scorciatoie". */
            VATNumberNormal vATNr04 = new VATNumberNormal();
            vATNr04.Bills = new List<decimal>();
            vATNr04.Expenses = new List<decimal>();
            vATNr04.VATCode = 111111;
            dicVATNr.Add(vATNr04.VATCode, vATNr04);
            #endregion

            #region Aggiunte di Bills ed Expenses
            decimal[] bills01 = { 1234.25m, 1000.00m, 250.00m, 9.99m };
            decimal[] bills02 = { 4321.25m, 3000.00m, 150.00m, 99.99m };
            decimal[] bills03 = { 4444.44m, 4000.00m, 450.00m, 4.55m };

            vATNr01.Bills.AddRange(bills01);
            vATNr02.Bills.AddRange(bills02);
            vATNr03.Bills.AddRange(bills03);

            decimal[] expenses01 = { 100.00m, 125.0m, 50.50m };
            decimal[] expenses02 = { 500.50m, 1300.00m, 75.75m };
            decimal[] expenses03 = { 44.00m, 444.44m, 4444.00m };

            vATNr01.Expenses.AddRange(expenses01);
            vATNr02.Expenses.AddRange(expenses02);
            vATNr03.Expenses.AddRange(expenses03);

            /* Creazione ed aggiunta per lungo, senza "scorciatoie". */
            decimal[] bills04 = { 1111.11m, 2222.22m, 3333.33m, 4444.44m };
            vATNr04.Bills.Add(bills04[0]);
            vATNr04.Bills.Add(bills04[1]);
            vATNr04.Bills.Add(bills04[2]);
            vATNr04.Bills.Add(bills04[3]);
            decimal[] expenses04 = { 0.01m, 0.22m, 3.33m, 44.44m };
            vATNr04.Bills.Add(expenses04[0]);
            vATNr04.Bills.Add(expenses04[1]);
            vATNr04.Bills.Add(expenses04[2]);
            vATNr04.Bills.Add(expenses04[3]);
            #endregion

            #region ConstStrings
            const string STR_NAN = "Il dato immesso NON è un numero.";
            const string STR_NOT_POSITIVE = "Il numero immesso NON è positivo.";
            const string STR_NOT_A_VAT_NR = "Il numero immesso NON corrisponde ad una P.IVA salvata.";
            const string STR_IS_A_VAT_NR = "P.IVA presente.";
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


                //selectedMode = AskForAString("Modalità:", "Stringa non valida.");

                bool isEmpty = true, selectedModeExists = false;

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
                                        /* recupero stringa->numero P.IVA */
                                        /* static int AskForAPositiveInt(string message, string errMessage) */

                                        int inInt = -1;

                                        bool converted = false, positive = false, isPresentInDictionary = false;

                                        #region Acquisizione numero fattura
                                        while (!converted || !positive || !isPresentInDictionary)
                                        {
                                            Console.Write(modeMessage + " \a");

                                            converted = false;
                                            positive = false;
                                            isPresentInDictionary = false;



                                            string inStr = Console.ReadLine();



                                            converted = int.TryParse(inStr, out inInt);

                                            if (!converted)
                                            {
                                                Console.WriteLine(STR_NAN);
                                            }
                                            else
                                            {
                                                positive = (inInt > 0) ? true : false;

                                                if (!positive)
                                                {
                                                    Console.WriteLine(STR_NOT_POSITIVE);
                                                }
                                                else
                                                {
                                                    isPresentInDictionary = dicVATNr.ContainsKey(inInt);
                                                    if (!isPresentInDictionary)
                                                    {
                                                        Console.WriteLine(STR_NOT_A_VAT_NR);
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine(STR_IS_A_VAT_NR);
                                                    }
                                                }
                                            }

                                            Console.WriteLine();
                                        }
                                        #endregion

                                        //Console.WriteLine("fuori da acquisizione n° P.IVA");
                                        int activeVATNr = inInt;


                                        #region Acquisizione importo fattura
                                        decimal inDec = -3.14m;
                                        converted = false;
                                        positive = false;

                                        while (!converted || !positive)
                                        {
                                            string inviteAddBillMessage = "Immettere l\'importo della fattura d\'aggiungere:";
                                            converted = false;
                                            positive = false;
                                            isPresentInDictionary = false;



                                            Console.Write(inviteAddBillMessage + " \a");
                                            string inStr = Console.ReadLine();



                                            converted = decimal.TryParse(inStr, out inDec);

                                            if (!converted)
                                            {
                                                Console.WriteLine(STR_NAN);
                                            }
                                            else
                                            {
                                                positive = inDec > 0;

                                                if (!positive)
                                                {
                                                    Console.WriteLine(STR_NOT_POSITIVE);
                                                }
                                                else
                                                {
                                                    Console.WriteLine($"Importo della fattura: {inDec}€.");
                                                }
                                            }

                                            Console.WriteLine();
                                        }
                                        #endregion

                                        //Console.WriteLine("fuori da acquisizione valore fattura");
                                        decimal billValue = inDec;

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

                                        foreach (int vATNr in dicVATNr.Keys)
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
                                        break;
                                    }
                            }
                        }


                    }




                    Console.Write("... Uscita ... ");
                    Console.ReadLine();
                    return;
                }
            }
        }
    }
}