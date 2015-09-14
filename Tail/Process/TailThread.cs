
namespace Tail.Process
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Windows.Forms;
    using Filter;

    /// <summary>
    /// A thread container to follow text files.  Uses a file watcher to detect changes and also
    /// periodically checks the file should a watch event not be caught. 
    /// </summary>
    public class TailThread
    {
        Thread tailThread = null;
        private ITailWatcher tailWatcher;
        private string fileToTail;

        /// <summary>
        /// Initializes a new instance of the <see cref="TailThread" /> class.
        /// </summary>
        /// <param name="serialFileReader">The line file reader.</param>
        public TailThread(ITailWatcher tailWatcher)
        {
            this.tailWatcher = tailWatcher;
        }

        public bool IsRunning { get { return tailThread != null && tailThread.IsAlive; } }

        /// <summary>
        /// Starts the tail of a given file.
        /// </summary>
        /// <param name="file">The file to follow.</param>
        public void Start(string file)
        {
            this.fileToTail = file;
            tailWatcher.Initialize();

            tailThread = new Thread(TailFile);
            tailThread.Start();                    
        }

        /// <summary>
        /// Stops the tail.
        /// </summary>
        public void Stop()
        {
            tailThread?.Abort();
            tailThread = null;
            tailWatcher.Dispose();
        }

        private void TailFile()
        {
            tailWatcher.Watch(fileToTail);
        }        
    }
}
