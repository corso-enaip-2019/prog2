using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 20190329 */
/* Done */

/* 1.1
 * As we all know, the answer to all the quesions is 42 (if you don't know that, search on the Internet!).
 * Generate a string with this truthy sentence, concatenating the sentence and the number, and print it on the Console. */

namespace Ex0101FortyTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            const string THE_QUESTION = "As we all know, the answer to all the quesions is \"";
            const int THE_ANSWER = 42;
            Console.WriteLine("« "+THE_QUESTION + THE_ANSWER + "\". »");
            Console.Read();
        }
    }
}