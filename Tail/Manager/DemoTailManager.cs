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

            FormInterface = fileTailManager.FormInterface;

            FormInterface.GetFileNameCallback = () => demoThread.DemoFile;
            FormInterface.GetFilterCallback = () => new FileLineRegexFilter("");
        }

        public FormInterface FormInterface { get; set; }

        
        public bool IsRunning { get { return fileTailManager.IsRunning; } }

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
