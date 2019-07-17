using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLogger
{
    /// <summary>
    /// Singola entry LogEntry
    /// </summary>
    public class LogEntry
    {
        // Struttura d'una singola entry LogEntry

        public enum LogLevel { Info, Warning, Error }
        // «public enum LogLevel { Info, Warning, Error }» è quasi equivalente a:
        //
        //public class LogLevel_
        //{
        //    public const string Info = "Info";
        //    public const string Warning = "Warning";
        //    public const string Error = "Error";
        //}

        public LogLevel ErrorLevel { get; set; }
        public DateTime ErrorDate { get; set; }
        public string Message { get; set; }
        public Exception Error { get; set; }

        public LogEntry()
        { ErrorDate = DateTime.Now; }

    }
}
