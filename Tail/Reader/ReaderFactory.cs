using System;
using Tail.Process;

namespace Tail.Reader
{
    /// <summary>
    /// Factory to create a reader for a given path.  Called on demand to open the IDisposable reader.
    /// </summary>
    public class ReaderFactory : IReaderFactory
    {
        private const string EventLogQualifier = "EventLog: ";
        private const string EventLogPathTemplate = "{0}{1}";

        public static string EventLogToFilePath(string eventLog)
        {
            return string.Format(EventLogPathTemplate, EventLogQualifier, eventLog);
        }

        public static string GetEventLogName(string path)
        {
            return path.Replace(EventLogQualifier, "");
        }

        public static ReaderType GetReaderType(string path)
        {
            return path.StartsWith(EventLogQualifier) ? ReaderType.EventLog : ReaderType.File;
        }

        public IReader CreateReader(string path)
        {
            switch (GetReaderType(path))
            {
                case ReaderType.File:
                    return new FileReaderWrapper(path);
                case ReaderType.EventLog:
                    return new EventLogFileReader(GetEventLogName(path));
                default:
                    throw new NotImplementedException(); 
            }
        }
    }
}
