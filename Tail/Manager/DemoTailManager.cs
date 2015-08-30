namespace Tail.Manager
{
    using System;
    using Demo;
    using Filter;
    using Process;

    /// <summary>
    /// Tail Manager to run the demo.  Runs a FileTailManager with another thread to generate a file to follow.
    /// </summary>
    public class DemoTailManager : ITailManager
    {
        private ITailManager fileTailManager;
        private DemoWriterThread demoThread = new DemoWriterThread();

        public DemoTailManager(ITailManager fileTailManager)
        {
            this.fileTailManager = fileTailManager;
        }

        public ISerialFileReader SerialFileReader
        {
            get { return fileTailManager.SerialFileReader; }
            set { fileTailManager.SerialFileReader = value; }
        }

        public Action ClearDisplayCallback
        {
            get { return fileTailManager.ClearDisplayCallback; }
            set { fileTailManager.ClearDisplayCallback = value; }
        }

        public Action<bool> SetStateCallback
        {
            get { return fileTailManager.SetStateCallback; }
            set { fileTailManager.SetStateCallback = value; }
        }

        public Action<Exception> ExceptionCallback
        {
            get { return fileTailManager.ExceptionCallback; }
            set { fileTailManager.ExceptionCallback = value; }
        }
        
        public Func<string> GetFileNameCallback
        {
            get { return () => demoThread.DemoFile; }
            set { throw new NotImplementedException(); }
        }

        public Func<ILineFilter> GetFilterCallback
        {
            get { return () => new FileLineRegexFilter(""); }
            set { throw new NotImplementedException(); }
        }

        public void StartTail(bool save = true, bool stop = true)
        {
            demoThread.Start();
            fileTailManager.StartTail(false);
        }

        public void StopTail()
        {
            demoThread.Stop();
            fileTailManager.StopTail();
        }
    }
}
