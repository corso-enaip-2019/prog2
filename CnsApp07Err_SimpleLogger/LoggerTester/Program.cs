using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SimpleLogger;

namespace LoggerTester
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            ILogger logger = new MockLogger();

            logger.LogInfo("Messaggio informativo.");
            logger.LogError("Errore", new Exception("Error"));
            */

            LoggerA logger = new LoggerA();

            WriterConsole cnsWrt = new WriterConsole();



            Console.ReadLine();
        }
    }
}