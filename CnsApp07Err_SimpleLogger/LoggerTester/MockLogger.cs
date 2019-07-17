using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SimpleLogger;

namespace LoggerTester
{
    /// <summary>
    /// Logger fasullo che dati i parametri in ingresso, non fa nulla.
    /// </summary>
    public class MockLogger : ILogger
    {
        public void LogInfo(string message)
        { }

        public void LogError(string message, Exception e)
        { }



        #region Lista di Listeners _in ascolto_
        public List<IWriter> TargetsList { get; }

        void ILogger.AddTargetToTargetsList(IWriter target)
        { }

        void ILogger.RemoveTargetToTargetsList(IWriter target)
        { }

        void ILogger.LogInfo(LogEntry entry)
        {
        }

        void ILogger.LogError(string message, LogEntry entry)
        {
        }
        #endregion



        #region ctor
        public MockLogger()
        { List<ILogger> WritersList = new List<ILogger>(); }
        #endregion
    }
}