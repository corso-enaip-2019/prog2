using System;

using System.Collections.Generic;

/* 201850412 */
/* Singleton-Pattern + Repository-Pattern */

namespace FromInstanceToJsonXml_const
{
    class Program
    {
        static void Main(string[] args)
        {
            #region preRimepimento
            List<Person> pl = new List<Person>()
                {
                    new Person("Mario", "Greys", 18, 3500),
                    new Person("Maria", "White", 25, 2200),
                    new Person("Marck", "Black", 30, 4400),
                };
            


            List<SaverToX> savers = new List<SaverToX>();
            SaverToX xmlSaver = new XmlSaver();
            SaverToX jsonSaver = new JsonSaver();
            savers.Add(xmlSaver);
            savers.Add(jsonSaver);

            List<string> strings = new List<string>();
            foreach (SaverToX saver in savers)
            {
                foreach (Person p in pl)
                {
                    saver.ShowToScreen(p);
                }
            }
            #endregion

            bool rePlay = true;
            while (rePlay)
            {
                foreach (string str in strings)
                    Console.WriteLine(str);

                Console.Write("\nq? \a");
                rePlay = (Console.ReadLine() != "q") ? true : false;
                Console.WriteLine();
            }

            return;
        }
    }
}