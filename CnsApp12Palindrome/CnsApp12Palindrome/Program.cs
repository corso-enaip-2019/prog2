using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 20190328 */

namespace CnsApp12Palindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Immettere una parola.\nControlla se la parola è palindroma.\n\t\a");
            string inText = Console.ReadLine();

            const string s1 = "La parola";
            string s2 = "conterrà la parola immessa ed è/non è";
            const string s3 = "palindroma.";

            s2 = (IsAPalindrome1(inText)) ? $" {inText} è " : $" {inText} NON è ";
            Console.WriteLine(s1 + s2 + s3);

            s2 = (IsAPalindrome2(inText)) ? $" {inText} è " : $" {inText} NON è ";
            Console.WriteLine(s1 + s2 + s3);

            s2 = (IsAPalindrome3(inText)) ? $" {inText} è " : $" {inText} NON è ";
            Console.WriteLine(s1 + s2 + s3);

            s2 = (IsAPalindrome4Recursive(inText)) ? $" {inText} è " : $" {inText} NON è ";
            Console.WriteLine(s1 + s2 + s3);

            Console.ReadLine();
        }

        static bool IsAPalindrome1(string inText)
        {
            for (int i = 0, j = inText.Length; i <= j; i++, j--)
            {
                if (inText[i] != inText[j - 1])
                { return false; }
            }

            return true;
        }

        static bool IsAPalindrome2(string inText)
        {
            bool isAPalindrome = true;

            for (int i = 0, j = inText.Length; i <= j; i++, j--)
            {
                if (inText[i] != inText[j - 1])
                {
                    isAPalindrome = false;
                    break;
                }
            }

            return isAPalindrome;
        }

        static bool IsAPalindrome3(string inText)
        {
            bool isAPalindrome = true;

            for (int i = 0; i < inText.Length; i++)
            {
                if (inText[i] != inText[(inText.Length - i) - 1])
                {
                    isAPalindrome = false;
                    break;
                }
            }

            return isAPalindrome;
        }

        static bool IsAPalindrome4Recursive(string inText)
        {
            if (inText.Length < 2)
            { return true; }

            if (inText[0] != inText[inText.Length - 1])
            { return false; }

            /* « inText.Substring(1, inText.Length-2); » =  Togli primo ed ultimo carattere dalla stringa. */
            string newString = inText.Substring(1, inText.Length - 2);

            return IsAPalindrome4Recursive(newString);
        }
    }
}
