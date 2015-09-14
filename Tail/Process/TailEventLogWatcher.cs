namespace Tail.Process
{
    using System;
    using System.Diagnostics;
    using System.Threading;
    using Reader;

    public class TailEventLogWatcher : ITailWatcher
    {
        // This member is used to wait for events. 
        static AutoResetEvent signal;

        private ISerialFileReader serialFileReader;
        private Action<Exception> exceptionHandler;
        private string LogToTail = "";

        public TailEventLogWatcher(ISerialFileReader serialFileReader, Action<Exception> exceptionHandler)
        {
            this.serialFileReader = serialFileReader;
            this.exceptionHandler = exceptionHandler;
        }

        public void Initialize()
        {
            serialFileReader.EnableQueue(true);
        }

        public void Watch(string fileToTail)
        {
            try
            {
                LogToTail = fileToTail;
                signal = new AutoResetEvent(false);
                var myNewLog = new EventLog(ReaderFactory.GetEventLogName(LogToTail), ".", "testEventLogEvent");

                serialFileReader.Enqueue(fileToTail);

                myNewLog.EntryWritten += new EntryWrittenEventHandler(MyOnEntryWritten);
                myNewLog.EnableRaisingEvents = true;
                signal.WaitOne();
            }
            catch (Exception ex)
            {
                exceptionHandler(ex);
            }
        }

        public void MyOnEntryWritten(object source, EntryWrittenEventArgs e)
        {
            serialFileReader.Enqueue(LogToTail);
            signal.Set();
        }

        public void Dispose()
        {
            serialFileReader.EnableQueue(false);
            serialFileReader.ClearQueue();
        }
    }
}
