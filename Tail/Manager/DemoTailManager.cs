namespace Tail.Manager
{
    using System;
    using Demo;
    using Filter;

    /// <summary>
    /// Tail Manager to run the demo.  Runs a FileTailManager with another thread to generate a file to follow.
    /// </summary>
    public class DemoTailManager : ITailManager
    {
        private FileTailManager fileTailManager;
        private DemoWriterThread demoThread = new DemoWriterThread();

        public DemoTailManager(FileTailManager fileTailManager)
        {
            this.fileTailManager = fileTailManager;
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

        public void StartTail(bool stop = true)
        {
            fileTailManager.StartTail();
            demoThread.Start();
        }

        public void StopTail()
        {
            fileTailManager.StopTail();
            demoThread.Stop();
        }
    }
}
