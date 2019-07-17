﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            bool ok = CheckBrackets(@"
                namespace Brackets
                {
                    class Program
                    {
                        static void Main(string[] args)
                        {
                            bool ok = CheckBrackets("")

                            Console.ReadLine();
                        }
                        static bool CheckBrackets(string text)
                        {

                        }
                    }
                }",
                out int errorRow,
                out int errorColumn);

            string strOk = ok ? "OK" : $"KO: row {errorRow}, column {errorColumn}";
            Console.WriteLine($"Text is { strOk }");

            Console.ReadLine();
        }

        static List<char> openingBrackets = new List<char>() { '(', '[', '{' };
        static List<char> closingBrackets = new List<char>() { ')', ']', '}' };
        static bool CheckBrackets(string text, out int errorRow, out int errorColumn)
        {
            //Spostato in inizializzatore
            //openingBrackets.Add('(');
            //openingBrackets.Add('[');
            //openingBrackets.Add('{');

            //Spostato in inizializzatore
            //closingBrackets.Add(')');
            //closingBrackets.Add(']');
            //closingBrackets.Add('}');

            Stack<char> brackets = new Stack<char>();
            int currentRow = 1;
            int currentColumn = 1;

            for (int i = 0; i < text.Length; i++)
            {
                char currentChar = text[i];
                //if (currentChar == '(' || currentChar == '[' || currentChar == '{')
                if (openingBrackets.Contains(currentChar))
                {
                    brackets.Push(currentChar);
                }
                //else if (currentChar == ')' || currentChar == ']' || currentChar == '}')
                else if (closingBrackets.Contains(currentChar))
                {
                    //spostato in metodo separato
                    //char correspondingOpeningBracket = ' ';
                    //if (currentChar == ')')
                    //    correspondingOpeningBracket = '(';
                    //else if (currentChar == ']')
                    //    correspondingOpeningBracket = '[';
                    //else if (currentChar == '}')
                    //    correspondingOpeningBracket = '{';

                    if (brackets.Count == 0)
                    {
                        errorColumn = currentColumn;
                        errorRow = currentRow;
                        return false;
                    }
                    if (brackets.Peek() == CorrespondingOpeningBracket(currentChar))
                    {
                        brackets.Pop();
                    }
                    else
                    {
                        errorColumn = currentColumn;
                        errorRow = currentRow;
                        return false;
                    }
                }

                const char NEWLINE_CHAR = '\n';                
                if (currentChar == NEWLINE_CHAR)
                {
                    currentRow++;
                    currentColumn = 1;
                }
                else
                {
                    currentColumn++;
                }
            }

            errorColumn = currentColumn;
            errorRow = currentRow;
            return brackets.Count == 0;
        }

        static char CorrespondingOpeningBracket(char closingBracket)
        {
            int closingIndex = closingBrackets.IndexOf(closingBracket);
            return openingBrackets[closingIndex];

            char correspondingOpeningBracket = ' ';
            if (closingBracket == ')')
                correspondingOpeningBracket = '(';
            else if (closingBracket == ']')
                correspondingOpeningBracket = '[';
            else if (closingBracket == '}')
                correspondingOpeningBracket = '{';

            return correspondingOpeningBracket;
        }

        #region Alternativa

        static Dictionary<char, char> _bracketsType = new Dictionary<char, char> {
            { ')', '(' },
            { ']', '[' },
            { '}', '{' }
        };

        /// <summary>
        /// Verifica se il testo passato contiene un numero coerente di parentesi
        /// di apertura e chiusura "(", "[", "{"
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        static bool CheckBrackets2(string text)
        {
            //inizializzazione dictionary
            //_brackets.Add('{', '}');
            //_brackets.Add('[', ']');
            //_brackets.Add('(', ')');

            Stack<char> brackets = new Stack<char>();

            for (int i = 0; i < text.Length; i++)
            {
                char currentChar = text[i];
                if (_bracketsType.ContainsValue(currentChar))
                {
                    brackets.Push(currentChar);
                }
                else if (_bracketsType.ContainsKey(currentChar))
                {
                    if (brackets.Count == 0)
                        return false;

                    if (brackets.Peek() == _bracketsType[currentChar]) //MatchingBracket(currentChar))
                        brackets.Pop();
                }
            }
            
            return brackets.Count == 0;
        }

        //private static char MatchingBracket(char currentChar)
        //{
        //    return _brackets[currentChar];
        //}

        #endregion
    }
}
