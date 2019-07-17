using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SimpleLogger;

namespace LoggerTester
{
    class WriterConsole : IWriter
    {
        void IWriter.WriteLog(LogEntry entry)
        {
            Console.WriteLine($"{entry.ErrorDate}");
            Console.WriteLine($"\t{entry.ErrorLevel}");
            Console.WriteLine($"\t{entry.Message}");
            Console.WriteLine($"\t{entry.Error.Message}");
            Console.WriteLine($"\t{entry.Error.StackTrace}");
            Console.WriteLine();
        }
    }
}
