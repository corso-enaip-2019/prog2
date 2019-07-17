using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SimpleLogger;

namespace LoggerTester
{
    class LoggerA : ILogger
    {
        public void LogInfo(LogEntry entry)
        { }

        public void LogError(string message, LogEntry entry)
        { }

        public void Log(string message)
        { }



        #region Lista di Listeners _in ascolto_
        private List<IWriter> TargetsList { get; }

        void ILogger.AddTargetToTargetsList(IWriter target)
        { }

        void ILogger.RemoveTargetToTargetsList(IWriter target)
        { }
        #endregion



        #region ctor
        public LoggerA()
        { List<ILogger> WritersList = new List<ILogger>(); }
        #endregion
    }
}
