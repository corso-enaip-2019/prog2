using System;

using System.Collections.Generic;
using System.Linq;

namespace CnsApp18LinQExtensions
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] array01 = new string[] { "Ciao", "sono", "io", "", "come", "stai", "040", "3.14", "3,1416" };

            List<SmartPhone> originalSmartPhoneList = CreateMockSmartPhoneList();
            //ShowSPhoneList(sPhoneList);

            /* Genera una nuova collezione (non è una lista) "orderedNames" ordinandola per Modello in ordine alfabetico (ASCII-betico).
             * I singoli elementi della nuova collezione sono gli stessi della lista originale "originalSmartPhoneList", quindi le modifiche effettuate ad un elemento si ripercuotono anche nella lista originale. */
            IEnumerable<string> orderedNames = originalSmartPhoneList
                .Select(x => x.Model)
                .OrderBy(x => x);


            /* "step2" è una collection di stringhe; contiene l'elenco dei nomi dei modelli ordinati alfabeticamente (come l'"orderedNames" da una riga). */
            IEnumerable<string> step1 = originalSmartPhoneList.Select(x => x.Model);
            IEnumerable<string> step2 = step1.OrderBy(x => x);

            #region Collezioni di SmartPhone ordinate per
            IEnumerable<SmartPhone> smartPhonesOrderedByModelName = originalSmartPhoneList.OrderBy(x => x.Model);
            IEnumerable<SmartPhone> smartPhonesOrderedByModelVersion = originalSmartPhoneList.OrderBy(x => x.Version);
            IEnumerable<SmartPhone> smartPhonesOrderedByColor = originalSmartPhoneList.OrderBy(x => x.Color);
            #endregion

            bool rePlay = true;

            while (rePlay)
            {
                ShowSmartPhoneList(originalSmartPhoneList);

                ShowGroupedByColor(originalSmartPhoneList);
                Console.ReadLine();

                Console.WriteLine($"{"Colore".PadRight(12)}{"prezzo avg".PadLeft(12)}");
                ShowDicStrFlt(CalculateAveragePriceByColor_manual(originalSmartPhoneList), 12);

                rePlay = (Console.ReadLine().ToLower() != "q") ? true : false;
            }

            return;
        }

        /* Create a list with mock smartphones. */
        static List<SmartPhone> CreateMockSmartPhoneList()
        {
            List<SmartPhone> outList = new List<SmartPhone>()
            {
                new SmartPhone("Sony xPerija", "Z3", "rosa", 550.00f),
                new SmartPhone("Sony xPerija","Z3","oro",750.00f),
                new SmartPhone("HP H-Phone", "12", "nero", 456.00f),
                new SmartPhone("HP P-Phone","11","nero",366.00f),
                new SmartPhone("Samsung Wawe", "Wawe III","nero",299.99f),
                new SmartPhone("Samsung A4","A4(2019)","bianco",950.17f),
                new SmartPhone("Apple iPhone","i Max","bianco",999.99f),
                new SmartPhone("Apple","i un-po\'-meno-Max","bianco",989.99f),
            };
            return outList;
        }

        static void ShowSmartPhoneList(List<SmartPhone> inList)
        {
            foreach (SmartPhone sPh in inList)
            {
                Console.WriteLine(sPh.Model + " - " + sPh.Version);
                Console.WriteLine("\t " + sPh.Color);
                Console.WriteLine($"\t {sPh.Cost.ToString().PadLeft(8)} EUR");

                Console.WriteLine();
            }
        }

        static void ShowGroupedByColor(IEnumerable<SmartPhone> input)
        {
            IEnumerable<IGrouping<string, SmartPhone>> colors = input
                .GroupBy(x => x.Color);

            foreach (IGrouping<string, SmartPhone> color in colors)
            {
                Console.WriteLine(color.Key + ":");

                foreach (SmartPhone sP in color)
                    Console.WriteLine($" - {sP.Model} ({sP.Version}), {sP.Cost}");

                Console.WriteLine();

                return;
            }
        }

        static Dictionary<string, float> CalculateAveragePriceByColor_Average(IEnumerable<SmartPhone> input)
        {
            Dictionary<string, float> outAvgPriceDic = new Dictionary<string, float>();

            IEnumerable<IGrouping<string, SmartPhone>> colors = input
                .GroupBy(x => x.Color);

            foreach (IGrouping<string, SmartPhone> color in colors)
            {
                //outAvgPriceDic.Add(color.Key, /*???*/.Average</*?cost?*/>);

                float averagePrice = 0;
                int numOfSP = 0;
                foreach (SmartPhone sP in color)
                {
                    averagePrice += sP.Cost;
                    numOfSP++;
                }
            }

            return outAvgPriceDic;
        }

        static Dictionary<string, float> CalculateAveragePriceByColor_manual(IEnumerable<SmartPhone> input)
        {
            Dictionary<string, float> outAvgPriceDic = new Dictionary<string, float>();

            IEnumerable<IGrouping<string, SmartPhone>> colors = input
                .GroupBy(x => x.Color);

            foreach (IGrouping<string, SmartPhone> color in colors)
            {
                float averagePrice = 0;
                int numOfSP = 0;
                foreach (SmartPhone sP in color)
                {
                    averagePrice += sP.Cost;
                    numOfSP++;
                }
                outAvgPriceDic.Add(color.Key, averagePrice);
            }

            return outAvgPriceDic;
        }

        static void ShowDicStrFlt(Dictionary<string, float> inDic, int paddin)
        {
            foreach (string strKey in inDic.Keys)
            {
                Console.WriteLine($"{strKey.ToLower().PadRight(paddin)}{inDic[strKey].ToString().PadLeft(paddin)}");
            }
        }
    }
}