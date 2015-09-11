
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
        private FileSystemWatcher fileSystemWatcher;

        private ISerialFileReader serialFileReader;
        private string fileToTail;
        private Action<Exception> exceptionHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="TailThread" /> class.
        /// </summary>
        /// <param name="serialFileReader">The line file reader.</param>
        public TailThread(ISerialFileReader serialFileReader, Action<Exception> exceptionHandler)
        {
            this.serialFileReader = serialFileReader;
            this.exceptionHandler = exceptionHandler;
        }

        public bool IsRunning { get { return tailThread != null && tailThread.IsAlive; } }

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
            tailThread = null;
            serialFileReader.EnableQueue(false);
            serialFileReader.ClearQueue();
        }

        private void TailFile()
        {
            try
            {
                if (!File.Exists(fileToTail))
                {
                    throw new FileNotFoundException("Could not find the file", fileToTail);
                }

                var directory = Path.GetDirectoryName(fileToTail);

                // Dispose previous instance to reduce memory usage
                if (fileSystemWatcher != null)
                {
                    fileSystemWatcher.Dispose();
                    fileSystemWatcher = null;
                }

                fileSystemWatcher = new FileSystemWatcher(directory) { Filter = fileToTail };
                fileSystemWatcher.Filter = "*.*";

                fileSystemWatcher.NotifyFilter = NotifyFilters.LastWrite;

                fileSystemWatcher.Changed += Fsw_Changed;
                fileSystemWatcher.EnableRaisingEvents = true;

                fileSystemWatcher.InternalBufferSize = 1024 * 1024 * 2;

                serialFileReader.Enqueue(fileToTail);

                while (true)
                {
                    fileSystemWatcher.WaitForChanged(WatcherChangeTypes.Changed);
                }
            }
            catch (Exception ex)
            {
                exceptionHandler(ex);
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
