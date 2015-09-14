using System;
using Tail.Process;

namespace Tail.Reader
{
    public class ReaderFactory : IReaderFactory
    {
        private const string EventLogQualifier = "EventLog: ";
        private const string EventLogPathTemplate = "{0}{1}";

        public static string EventLogToFilePath(string eventLog)
        {
            return string.Format(EventLogPathTemplate, EventLogQualifier, eventLog);
        }

        public IReader CreateReader(string path)
        {
            return new EventLogReader(path.Replace(EventLogQualifier, ""));
        }

        public ITailWatcher CreateWatcher(string path, ISerialFileReader serialFileReader, Action<Exception> exceptionHandler)
        {
            return new TailEventLogWatcher(serialFileReader, exceptionHandler);
        }
    }
}
