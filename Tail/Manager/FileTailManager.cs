namespace Tail.Manager
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Design;
    using System.Reflection.Emit;
    using System.Windows.Forms;
    using Filter;
    using Process;
    using Reader;
    using Settings;

    public class FileTailManager : ITailManager
    {
        private TailThread tailThread;
        private ISerialFileReader serialFileReader = null;
        
        public FormInterface FormInterface { get; set; }

        public bool IsRunning { get { return tailThread != null && tailThread.IsRunning; } }

        public virtual void StartTail(bool save = true, bool stop = true)
        {
            serialFileReader = new CallbackFileReader(new ReaderFactory())
            {
                StartCallback = FormInterface.StartCallback,
                UpdateCallback = FormInterface.UpdateCallback,
                FinishCallback = FormInterface.FinishCallback,
                ExceptionCallback = FormInterface.ExceptionCallback,
                LoadLastLines = FormInterface.LoadLastLinesCallback,
                Filter = FormInterface.GetFilterCallback
            };

            if (save)
            {
                Properties.Settings.Default.LastFile = FormInterface.GetFileNameCallback();
            }

            if (stop && tailThread != null)
            {
                StopTail();
            }

            if (tailThread == null)
            {
                tailThread = new TailThread(TailWatcherFactory.CreateWatcher(FormInterface.GetFileNameCallback(), 
                    serialFileReader, FormInterface.ExceptionCallback));
            }

            FormInterface.ClearDisplayCallback();

            var file = FormInterface.GetFileNameCallback();
            
            try
            {
                if (string.IsNullOrEmpty(file))
                {
                    return;
                }
                
                serialFileReader.EnableQueue(true);
                tailThread.Start(file);

                FormInterface.SetStateCallback(true);
            }
            catch (Exception ex)
            {
                FormInterface.ExceptionCallback(ex);
            }
        }

        public virtual void StopTail()
        {
            serialFileReader?.EnableQueue(false);
            tailThread?.Stop();
            tailThread = null;
            FormInterface?.SetStateCallback(false);
        }
    }
}
