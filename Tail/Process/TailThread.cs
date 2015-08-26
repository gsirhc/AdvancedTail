
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
        Thread updateFileThread = null;

        private Action<string> updateCallback;

        string fileToTail = "";
        long lastPosition = 0L;
        long lineCount = 1L;
        bool initialLoad = true;

        private readonly Queue<string> queue = new Queue<string>();

        private bool enableFilter = true;
        private Action startCallback;
        private Action finishCallback;

        /// <summary>
        /// Initializes a new instance of the <see cref="TailThread"/> class.
        /// </summary>
        /// <param name="startCallback">The start callback that is called before the inital load of the file.</param>
        /// <param name="updateCallback">The update callback that is called everytime the file is read.</param>
        /// <param name="finishCallback">The finish callback that is called after the inital load of the file.</param>
        public TailThread(Action startCallback, Action<string> updateCallback, Action finishCallback)
        {
            this.startCallback = startCallback;
            this.updateCallback = updateCallback;
            this.finishCallback = finishCallback;
        }

        public ILineFilter Filter { get; set; }

        /// <summary>
        /// Starts the tail of a given file.
        /// </summary>
        /// <param name="file">The file to follow.</param>
        /// <param name="filter">The filter to apply to the lines, can be null.</param>
        /// <param name="trimTo">The trim to expression to apply to the lines.</param>
        /// <param name="trimFrom">The trim from expression to apply to the lines.</param>
        public void Start(string file, string filter, string trimTo, string trimFrom)
        {
            fileToTail = file;
            initialLoad = true;

            tailThread = new Thread(TailFile);
            tailThread.Start();

            updateFileThread = new Thread(UpdateFile);
            updateFileThread.Start();

            lastPosition = 0L;
            lineCount = 1L;
        }

        /// <summary>
        /// Stops the tail.
        /// </summary>
        public void Stop()
        {
            tailThread?.Abort();
            updateFileThread?.Abort();
        }

        private void TailFile()
        {
            var directory = Path.GetDirectoryName(fileToTail);
            var fsw = new FileSystemWatcher(directory) { Filter = fileToTail };
            fsw.Changed += Fsw_Changed;
            fsw.EnableRaisingEvents = true;

            fsw.InternalBufferSize = 1024 * 1024 * 2;

            queue.Enqueue(fileToTail);

            while (true)
            {
                fsw.WaitForChanged(WatcherChangeTypes.Changed);
            }
        }

        private void Fsw_Changed(object sender, FileSystemEventArgs e)
        {
            lock (queue)
            {
                queue.Enqueue(e.FullPath);
            }
        }

        private void UpdateFile()
        {
            var missCount = 0;

            while (true)
            {
                var next = "";

                lock (queue)
                {
                    if (queue.Count == 0 && missCount < 10)
                    {
                        Thread.Sleep(10);
                        missCount++;
                        continue;
                    }

                    next = queue.Count != 0 ? queue.Dequeue() : fileToTail;
                }

                missCount = 0;

                if (initialLoad) startCallback?.Invoke();

                using (FileStream fs = File.Open(next, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    fs.Seek(lastPosition, SeekOrigin.Begin);

                    var reader = new StreamReader(fs);

                    ReadLines(reader);

                    lastPosition = fs.Position;
                }

                if (initialLoad) finishCallback?.Invoke();

                initialLoad = false;
            }
        }

        private void ReadLines(StreamReader reader)
        {
            string line;
            while (!string.IsNullOrEmpty((line = reader.ReadLine())))
            {
                if (IsMatchFilter(ref line))
                {
                    line = "[" + lineCount.ToString().PadLeft(6) + "] " + line + Environment.NewLine;
                    updateCallback(line);
                }

                lineCount++;
            }
        }

        private bool IsMatchFilter(ref string line)
        {
            if (Filter != null)
            {
                var result = Filter.IsMatch(line);
                line = result.Result;
                return result.IsMatch;
            }

            return true;
        }
    }
}
