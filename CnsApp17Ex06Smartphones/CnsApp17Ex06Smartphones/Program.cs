using System;

using System.Collections.Generic;

/* 20190404 */

/* 6 - Smartphones
 * Create a Smartphone class, with properties: Model, Version, Cost, Color.
 * Create a list with mock smartphones.
 * Create a method that filters the list based on color (example, I want only the dark-gray ones). The method returns a new list of Smartphones.
 * Create a method that filters the list returning just the ones costing less than a certain amount (passed as a parameter). */

namespace CnsApp17Ex06Smartphones
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Smartphone> sPhoneList = new List<Smartphone>(CreateMockSPh());
            ShowSPhoneList(sPhoneList);

            bool rePlay = true;
            while (rePlay)
            {
                /* Richiesta input */
                Console.WriteLine("c1 - Colore (con il metodo diretto)");
                Console.WriteLine("c2 - Colore (con i generics + generics)");
                Console.WriteLine("p1 - Prezzo (con il metodo diretto)");
                Console.WriteLine("p2 - Prezzo (con i generics + generics)");
                string option = Console.ReadLine();
                option = (string.IsNullOrWhiteSpace(option)) ? "???" : option;

                switch (option.ToLower())
                {
                    case "c2":
                        {
                            Console.Write("Immettere il colore cercato: ");

                            IEnumerable<Smartphone> listOfBlacks = FilterGenerics(sPhoneList, FilterBlacks);
                            //IEnumerable<Smartphone> listOfThatColor = FilterGenerics(sPhoneList, FilterThatColor);

                            //IEnumerable<Smartphone> listOfBlacks = FilterOfGenerics00(sPhoneList, Filters.ColorFilter.Filter("nero"));
                            //IEnumerable<Smartphone> listOfBlacks = FilterOfGenerics(sPhoneList, s => s.Filters.Color == "nero");
                            //IEnumerable<Smartphone> listOfThatColor = FilterOfGenerics(sPhoneList, s => s.Filters.Color == Console.ReadLine());
                            //ShowGenSMartPhonesList(listOfBlacks);
                            //ShowSPhoneList(listOfBlacks);

                            break;
                        }
                    /*
                case "p2":
                    {
                        Console.Write("Immettere il prezzo massimo (EUR): ");
                        IEnumerable<Smartphone> listOfLess500Price = FilterOfGenerics(sPhoneList, s => s.Filters.Cost <= 500f);
                        IEnumerable<Smartphone> listOfLessThatPrice = FilterOfGenerics(sPhoneList, s => s.Filters.Cost == Console.ReadLine());

                        break;
                    }
                    */
                    case "c1":
                        {
                            Console.Write("Immettere il colore cercato: ");

                            IFilter<Smartphone> colorFilter = new Filters.ColorFilter(Console.ReadLine());

                            List<Smartphone> filteredList = new List<Smartphone>();
                            foreach (Smartphone sPh in sPhoneList)
                            {
                                if (colorFilter.Filter(sPh))
                                    filteredList.Add(sPh);
                            }

                            ShowSPhoneList(filteredList);

                            break;
                        }
                    case "p1":
                        {
                            Console.Write("Immettere il prezzo massimo: ");

                            IFilter<Smartphone> costFilter = new Filters.CostLessFilter(float.Parse(Console.ReadLine()));

                            List<Smartphone> filteredList = new List<Smartphone>();
                            foreach (Smartphone sPh in sPhoneList)
                            {
                                if (costFilter.Filter(sPh))
                                    filteredList.Add(sPh);
                            }

                            ShowSPhoneList(filteredList);

                            break;
                        }

                    default:
                        break;
                }

                Console.WriteLine("Uscire (q)?");
                rePlay = (Console.ReadLine().ToLower() != "q") ? true : false;
            }

            return;
        }

        /* Create a list with mock smartphones. */
        static List<Smartphone> CreateMockSPh()
        {
            List<Smartphone> outList = new List<Smartphone>()
            {
                new Smartphone("Sony xPerija", "Z3", "rosa", 550.00f),
                new Smartphone("Sony xPerija","Z3","oro",750.00f),
                new Smartphone("HP H-Phone", "12", "nero", 456.00f),
                new Smartphone("HP P-Phone","11","nero",366.00f),
                new Smartphone("Samsung Wawe", "Wawe III","nero",299.99f),
                new Smartphone("Samsung A4","A4(2019)","bianco",950.17f),
                new Smartphone("Apple iPhone","i Max","bianco",999.99f),
                new Smartphone("Apple","i un-po\'-meno-Max","bianco",989.99f),
            };
            return outList;
        }

        static void ShowSPhoneList(List<Smartphone> inList)
        {
            foreach (Smartphone sPh in inList)
            {
                Console.WriteLine(sPh.Model + " - " + sPh.Version);
                Console.WriteLine("\t " + sPh.Color);
                Console.WriteLine($"\t {sPh.Cost.ToString().PadLeft(8)} EUR");

                //string price = string.Format("{0:0'000,##}", sPh.Cost);
                //Console.WriteLine(price);
                //Console.WriteLine(string.Format("\t +{0f,0'000.##}",sPh.Cost));

                Console.WriteLine();
            }
        }

        static void ShowGenSMartPhonesList<T>(IEnumerable<Smartphone> input)
        {
            foreach (Smartphone sPh in input)
            {
                Console.WriteLine(sPh.Model.ToString() + " - " + sPh.Version.ToString());
                Console.WriteLine(" " + sPh.Color.ToString());
                Console.WriteLine(" " + sPh.Cost.ToString());

                Console.WriteLine();
            }

            return;
        }

        static IEnumerable<Smartphone> FilterOfSmartPhones(IEnumerable<Smartphone> input, IFilter<Smartphone> condition)
        {
            List<Smartphone> outList = new List<Smartphone>();

            foreach (Smartphone sPh in input)
            {
                if (condition.Filter(sPh))
                {
                    outList.Add(sPh);
                }
            }

            return outList;
        }

        static IEnumerable<T> FilterOfGenerics<T>(IEnumerable<T> input, IFilter<T> condition)
        {
            List<T> outList = new List<T>();

            foreach (T item in input)
            {
                if (condition.Filter(item))
                {
                    outList.Add(item);
                }
            }

            return outList;
        }



        #region Filter con delegate e generics
        delegate bool Filter<T>(T item);

        static IEnumerable<T> FilterGenerics<T>(IEnumerable<T> input, Filter<T> condition)
        {
            List<T> outList = new List<T>();

            foreach (T item in input)
                if (condition(item))
                    outList.Add(item);

            return outList;
        }

        static bool FilterBlacks(Smartphone s)
        {
            return s.Color == "nero";
        }

        static bool FilterThatColor(Smartphone sPh, string color)
        {
            return sPh.Color.ToLower() == color.ToLower();
        }

        //static bool FilterShortStrings(string sPh)
        //{
        //    return s.Length < 3;
        //}
        #endregion
        //delegate IEnumerable<T> FilterOfGenerics00<T>(IEnumerable<T> input, IFilter<T> condition);
    }
}