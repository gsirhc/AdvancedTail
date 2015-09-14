using System;
using System.Diagnostics;

namespace Tail.Reader
{
    public class EventLogFileReader : IReader
    {
        private EventLog eventLog;
        private int lastIndex = 0;

        public EventLogFileReader(string logName)
        {
            this.eventLog = new EventLog(logName);
        }

        public long Length { get { return this.eventLog.Entries.Count; } }

        public long Position { get { return this.lastIndex; } }

        public int CountLines()
        {
            return this.eventLog.Entries.Count;
        }

        public void Seek(long position)
        {
            this.lastIndex = (int)position;
        }

        public string ReadLine()
        {
            if (lastIndex >= Length)
            {
                return null;
            }

            var entry = eventLog.Entries[lastIndex++];

            var type = entry.EntryType.ToString();

            return string.Format("{0} [{1}] Source={2} User={3} Message={4} ",
                (type != "0" ? type : "Information").PadRight(11),
                entry.TimeWritten.ToString("G").PadRight(23),
                entry.Source,
                entry.UserName,
                entry.Message.Replace("\r", "").Replace("\n", ""));
        }

        public void Dispose()
        {
            eventLog.Dispose();
        }
    }
}
