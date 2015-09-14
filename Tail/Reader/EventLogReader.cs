using System;
using System.Diagnostics;

namespace Tail.Reader
{
    public class EventLogReader : IReader
    {
        private EventLog eventLog;
        private int lastIndex = 0;

        public EventLogReader(string longName)
        {
            this.eventLog = new EventLog(longName);
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
            return string.Format("{0} [{1}] Source={2} User={3}: {4} ",
                entry.EntryType.ToString().PadRight(11),
                entry.TimeWritten.ToString("g").PadRight(20),
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
