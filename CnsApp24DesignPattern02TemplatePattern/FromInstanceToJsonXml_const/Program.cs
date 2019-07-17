using System;

using System.Collections.Generic;

namespace FromInstanceToJsonXml_const
{
    class Program
    {
        static void Main(string[] args)
        {
            #region preRimepimento
            List<Person> pl = new List<Person>()
                {
                    new Person("Mario", "Rossi", 18, 3500),
                    new Person("Maria", "White", 18, 3500),
                    new Person("Marck", "Black", 18, 3500),
                };

            List<SaverToX> savers = new List<SaverToX>();
            SaverToX xs = new XmlSaver();
            SaverToX js = new JsonSaver();
            savers.Add(xs);
            savers.Add(js);

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

                Console.Write("\n\"q\"? \a");

                rePlay = (Console.ReadLine() != "q") ? true : false;
            }

        }
    }
}