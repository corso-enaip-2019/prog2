using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SimpleLogger;

namespace LoggerTester
{
    public class MockWriter : IWriter
    {
        public MockWriter()
        { }

        void IWriter.WriteLog(LogEntry entry)
        { }
    }
}