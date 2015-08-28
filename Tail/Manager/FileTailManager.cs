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
        private ISerialFileReader serialFileReader;

        public FileTailManager(TailThread tailThread, ISerialFileReader serialFileReader)
        {
            this.tailThread = tailThread;
            this.serialFileReader = serialFileReader;
        }

        public Action ClearDisplayCallback { get; set; }

        public Action<bool> SetStateCallback { get; set; }

        public Action<Exception> ExceptionCallback { get; set; }

        public Func<string> GetFileNameCallback { get; set; }

        public Func<ILineFilter> GetFilterCallback { get; set; }
        
        public virtual void StartTail(bool stop = true)
        {
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

                serialFileReader.Filter = GetFilterCallback();
                
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
            tailThread.Stop();
            SetStateCallback(false);
        }
    }
}
