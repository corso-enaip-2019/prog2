using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLogger
{
    // ObservER
    public interface IWriter
    {
        void WriteLog(LogEntry entry);
    }
}