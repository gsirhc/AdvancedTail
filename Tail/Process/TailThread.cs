
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
        private ISerialFileReader serialFileReader;
        private string fileToTail;

        /// <summary>
        /// Initializes a new instance of the <see cref="TailThread" /> class.
        /// </summary>
        /// <param name="serialFileReader">The line file reader.</param>
        public TailThread(ISerialFileReader serialFileReader)
        {
            this.serialFileReader = serialFileReader;
        }

        //public ILineFilter Filter { get; set; }

        /// <summary>
        /// Starts the tail of a given file.
        /// </summary>
        /// <param name="file">The file to follow.</param>
        public void Start(string file)
        {
            this.fileToTail = file;

            serialFileReader.EnableQueue(true);

            tailThread = new Thread(TailFile);
            tailThread.Start();                    
        }

        /// <summary>
        /// Stops the tail.
        /// </summary>
        public void Stop()
        {
            tailThread?.Abort();
            serialFileReader.EnableQueue(false);
            serialFileReader.ClearQueue();
        }

        private void TailFile()
        {
            var directory = Path.GetDirectoryName(fileToTail);
            var fsw = new FileSystemWatcher(directory) { Filter = fileToTail };
            fsw.Filter = "*.*";

            fsw.NotifyFilter = NotifyFilters.LastWrite;

            fsw.Changed += Fsw_Changed;
            fsw.EnableRaisingEvents = true;

            fsw.InternalBufferSize = 1024 * 1024 * 2;
            
            serialFileReader.Enqueue(fileToTail);

            while (true)
            {
                fsw.WaitForChanged(WatcherChangeTypes.Changed);
            }
        }

        private void Fsw_Changed(object sender, FileSystemEventArgs e)
        {
            if (e.FullPath == fileToTail)
            {
                serialFileReader.Enqueue(e.FullPath);
            }
        }        
    }
}
