namespace Tail.Process
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using Filter;

    /// <summary>
    /// Implementation of <see cref="ISerialFileReader" /> that uses callbacks to inform a parent of certain actions.
    /// </summary>
    public class CallbackSerialFileReader : ISerialFileReader
    {
        private Dictionary<string, long> lastPositionDict = new Dictionary<string, long>();
        private Dictionary<string, long> lineCountDict = new Dictionary<string, long>();
        bool initialLoad = true;

        private Action startCallback;
        private Action finishCallback;
        private Action<string, long, bool> updateCallback;

        private readonly Queue<string> queue = new Queue<string>();

        private bool enableFilter = true;

        Thread updateFileThread = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="CallbackSerialFileReader"/> class.
        /// </summary>
        /// <param name="startCallback">The start callback that is called before the inital load of the file.</param>
        /// <param name="updateCallback">The update callback that is called everytime the file is read.</param>
        /// <param name="finishCallback">The finish callback that is called after the inital load of the file.</param>
        public CallbackSerialFileReader(Action startCallback, Action<string, long, bool> updateCallback, Action finishCallback)
        {
            this.startCallback = startCallback;
            this.updateCallback = updateCallback;
            this.finishCallback = finishCallback;
            
            EnableQueue(true);
        }

        public void ClearQueue()
        {
            lock (queue)
            {
                queue.Clear();
                lastPositionDict = new Dictionary<string, long>();
                lineCountDict = new Dictionary<string, long>();
            }
        }

        public void EnableQueue(bool enable)
        {
            if (enable)
            {
                updateFileThread?.Abort();
                updateFileThread = new Thread(ReadFile);
                updateFileThread.Start();
            }
            else
            {
                updateFileThread?.Abort();
                initialLoad = true;
            }
        }

        public ILineFilter Filter { get; set; }

        public void Enqueue(string filePath)
        {
            lock (queue)
            {
                queue.Enqueue(filePath);
            }
        }

        private string Dequeue()
        {
            lock (queue)
            {
                return queue.Count != 0 ? queue.Dequeue() : null;
            }
        }

        protected virtual void ReadFile()
        {
            while (true)
            {
                var next = Dequeue();

                if (next == null)
                {
                    Thread.Sleep(10);
                    continue;
                }

                if (initialLoad) startCallback?.Invoke();

                using (FileStream fs = File.Open(next, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    if (!lastPositionDict.ContainsKey(next))
                    {
                        lastPositionDict.Add(next, 0L);
                        lineCountDict.Add(next, 1L);
                    }

                    var lastPosition =  lastPositionDict[next];                    

                    if (lastPosition > fs.Length)
                    {
                        lastPositionDict[next] = 0L;
                        lastPositionDict[next] = 1L;
                        initialLoad = true;
                        startCallback?.Invoke();
                        updateCallback("", 0, true);
                    }

                    fs.Seek(lastPosition, SeekOrigin.Begin);

                    var reader = new StreamReader(fs);

                    ReadLines(reader, next);

                    lastPositionDict[next] = fs.Position;
                }

                if (initialLoad) finishCallback?.Invoke();

                initialLoad = false;
            }
        }

        private void ReadLines(StreamReader reader, string fileKey)
        {
            string line;
            while (!string.IsNullOrEmpty((line = reader.ReadLine())))
            {
                var lineCount = lineCountDict[fileKey];

                if (IsMatchFilter(ref line))
                {
                    line = line + Environment.NewLine;
                    updateCallback(line, lineCount, false);
                }

                lineCountDict[fileKey]++;
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
