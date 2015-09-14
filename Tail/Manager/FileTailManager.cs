namespace Tail.Manager
{
    using System;
    using System.ComponentModel.Design;
    using System.Windows.Forms;
    using Filter;
    using Process;
    using Settings;

    public class FileTailManager : ITailManager
    {
        private TailThread tailThread;

        public ISerialFileReader SerialFileReader { get; set; }
        public ITailWatcher TailWatcher { get; set; }
        public Action ClearDisplayCallback { get; set; }
        public Action<bool> SetStateCallback { get; set; }
        public Action<Exception> ExceptionCallback { get; set; }
        public Func<string> GetFileNameCallback { get; set; }
        public Func<ILineFilter> GetFilterCallback { get; set; }
        
        public bool IsRunning { get { return tailThread != null && tailThread.IsRunning; } }

        public virtual void StartTail(bool save = true, bool stop = true)
        {
            if (save)
            {
                Properties.Settings.Default.LastFile = GetFileNameCallback();
            }

            if (tailThread == null)
            {
                tailThread = new TailThread(TailWatcher);
            }

            ClearDisplayCallback();

            var file = GetFileNameCallback();

            if (stop && tailThread != null)
            {
                StopTail();
            }

            try
            {
                if (string.IsNullOrEmpty(file))
                {
                    return;
                }

                SerialFileReader.Filter = GetFilterCallback();

                SerialFileReader.EnableQueue(true);
                tailThread.Start(file);

                SetStateCallback(true);
            }
            catch (Exception ex)
            {
                ExceptionCallback(ex);
            }
        }

        public virtual void StopTail()
        {
            SerialFileReader.EnableQueue(false);
            tailThread?.Stop();
            SetStateCallback(false);
        }
    }
}
