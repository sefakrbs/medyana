using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utilities
{
    /// <summary>
    /// Writes logs to the .Net event log. Logs can be viewed via Event Viewer program.
    /// </summary>
    public static class Logger
    {
        /// <summary>
        /// Writes information logs to the .Net event log
        /// </summary>
        /// <param name="source"></param>
        /// <param name="message"></param>
        public static void WriteDebug(string message)
        {
            EventLog.WriteEntry("Application", message, EventLogEntryType.Information);
        }

        /// <summary>
        /// Writes error logs to the .Net event log
        /// </summary>
        /// <param name="source"></param>
        /// <param name="message"></param>
        public static void WriteError(string message)
        {
            EventLog.WriteEntry("Application", message, EventLogEntryType.Error);
        }

        /// <summary>
        /// Writes warning logs to the .Net event log
        /// </summary>
        /// <param name="source"></param>
        /// <param name="message"></param>
        public static void WriteWarning(string message)
        {
            EventLog.WriteEntry("Application", message, EventLogEntryType.Warning);
        }
    }
}
