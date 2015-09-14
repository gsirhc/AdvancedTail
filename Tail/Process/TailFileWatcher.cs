namespace Tail.Process
{
    using System;
    using System.IO;

    public class TailFileWatcher : ITailWatcher
    {
        private FileSystemWatcher fileSystemWatcher;

        private ISerialFileReader serialFileReader;
        private Action<Exception> exceptionHandler;
        private string fileToTail;

        public TailFileWatcher(ISerialFileReader serialFileReader, Action<Exception> exceptionHandler)
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
            this.fileToTail = fileToTail;
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

        public void Dispose()
        {
            if (fileSystemWatcher != null)
            {
                fileSystemWatcher.Dispose();
                fileSystemWatcher = null;
            }

            serialFileReader.EnableQueue(false);
            serialFileReader.ClearQueue();
        }
    }
}
