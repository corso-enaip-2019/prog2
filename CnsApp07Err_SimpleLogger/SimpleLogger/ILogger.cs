using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLogger
{
    // ObservABLE
    public interface ILogger
    {
        void LogInfo(LogEntry entry);
        void LogError(string message, LogEntry entry);



        //List<IWriter> TargetsList { get; }

        void AddTargetToTargetsList(IWriter target);
        void RemoveTargetToTargetsList(IWriter target);
    }
}