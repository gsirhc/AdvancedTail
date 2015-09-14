namespace Tail.Process
{
    using System;
    using System.Diagnostics;
    using System.Threading;

    public class TailEventLogWatcher : ITailWatcher
    {
        // This member is used to wait for events. 
        static AutoResetEvent signal;

        private ISerialFileReader serialFileReader;
        private Action<Exception> exceptionHandler;

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
            signal = new AutoResetEvent(false);
            var myNewLog = new EventLog("Application", ".", "testEventLogEvent");

            serialFileReader.Enqueue(fileToTail);

            myNewLog.EntryWritten += new EntryWrittenEventHandler(MyOnEntryWritten);
            myNewLog.EnableRaisingEvents = true;
            signal.WaitOne();
        }

        public void MyOnEntryWritten(object source, EntryWrittenEventArgs e)
        {
            serialFileReader.Enqueue(source.ToString());
            signal.Set();
        }

        public void Dispose()
        {
            serialFileReader.EnableQueue(false);
            serialFileReader.ClearQueue();
        }
    }
}
