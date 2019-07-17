using System;
using System.Collections.Generic;

namespace _01_Pre_Linq
{
    /*
     * Il primo passo per manipolare collezioni di oggetti (filtrare, proiettare...)
     * può essere quello di creare dei metodi specifici solo per lo scopo puntuale che abbiamo in quel momento,
     * come in questo esercizio.
     * Come si nota dai vari metodi statici di manipolazione, c'è un sacco di duplicazione nella logica.
     * L'algoritmo di attraversamento della lista e di riempimento della lista nuova è sempre uguale.
     * Se in futuro devo cambiare l'algoritmo, devo modificare n punti diversi.
     * Inoltre questi metodi sono rigidi, perché accettano solo collezioni di tipo List.
     * E se voglio manipolare anche Array? O Set?
     */

    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = CreateMockList();

            List<string> inverteds = InvertStrings(list);
            List<int> lengths = GetLengths(list);
            List<string> shorts = FilterShortStrings(list);
            List<string> beginningWithAs = FilterBeginningWithLetter(list, 'a');
            List<string> convertibles = FilterConvertibleToNumber(list);

            foreach (string s in inverteds)
                Console.WriteLine(s);
            Console.WriteLine();

            foreach (int i in lengths)
                Console.WriteLine(i);
            Console.WriteLine();

            foreach (string s in shorts)
                Console.WriteLine(s);
            Console.WriteLine();

            foreach (string s in beginningWithAs)
                Console.WriteLine(s);
            Console.WriteLine();

            foreach (string s in convertibles)
                Console.WriteLine(s);
            Console.WriteLine();

            Console.Read();
        }

        private static List<string> CreateMockList()
        {
            return new List<string>
            {
                "ciao",
                "22",
                "pirottino123",
                "543",
                "12.12",
                "",
                "assorrete"
            };
        }

        private static List<string> InvertStrings(List<string> input)
        {
            List<string> output = new List<string>();

            foreach(string s in input)
            {
                //string result = new string(s.Reverse().ToArray());
                //string result = string.Concat(s.Reverse());
                string result = "";
                for (int i = s.Length - 1; i >= 0; i--)
                    result += s[i];
                output.Add(result);
            }

            return output;
        }

        private static List<int> GetLengths(List<string> input)
        {
            List<int> output = new List<int>();

            foreach (string s in input)
                output.Add(s.Length);

            return output;
        }

        private static List<string> FilterShortStrings(List<string> input)
        {
            List<string> output = new List<string>();

            foreach (string s in input)
                if (s.Length < 3)
                    output.Add(s);

            return output;
        }

        private static List<string> FilterBeginningWithA(List<string> input)
        {
            List<string> output = new List<string>();

            foreach (string s in input)
                // if (s.IndexOf('a') == 0 || s.IndexOf('A') == 0)
                if (s.StartsWith('a') || s.StartsWith('A'))
                    output.Add(s);

            return output;
        }

        // more general and flexible version
        private static List<string> FilterBeginningWithLetter(List<string> input, char initial)
        {
            List<string> output = new List<string>();

            foreach (string s in input)
                if (s.StartsWith(char.ToLower(initial)) || s.StartsWith(char.ToUpper(initial)))
                    output.Add(s);

            return output;
        }

        private static List<string> FilterConvertibleToNumber(List<string> input)
        {
            List<string> output = new List<string>();

            foreach (string s in input)
                if (int.TryParse(s, out int _))
                    output.Add(s);

            return output;
        }
    }
}
