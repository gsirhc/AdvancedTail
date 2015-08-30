namespace Tail.Process
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using Filter;
    using System.Linq;

    /// <summary>
    /// Implementation of <see cref="ISerialFileReader" /> that uses callbacks to inform a parent of certain actions.
    /// </summary>
    public class CallbackSerialFileReader : ISerialFileReader
    {
        private Dictionary<string, long> lastPositionDict = new Dictionary<string, long>();
        private Dictionary<string, long> lineCountDict = new Dictionary<string, long>();
        private bool initialLoad = true;
        
        private readonly Queue<string> queue = new Queue<string>();

        private Thread updateFileThread = null;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CallbackSerialFileReader"/> class.
        /// </summary>
        public CallbackSerialFileReader()
        {
            LoadLastLines = 10;
        }

        public Action<bool> StartCallback { get; set; }
        public Action<bool, long> FinishCallback { get; set; }
        public Action<string, long, bool> UpdateCallback { get; set; }
        public Action<Exception> ExceptionCallback { get; set; }
        public int LoadLastLines { get; set; }

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
                    Thread.Sleep(100);
                    continue;
                }

                try
                {
                    if (!lastPositionDict.ContainsKey(next))
                    {
                        lastPositionDict.Add(next, 0L);
                        lineCountDict.Add(next, 0L);
                    }

                    StartCallback?.Invoke(initialLoad);
                    var totalLineCount = 0;
                    if (LoadLastLines >= 0 && lastPositionDict[next] == 0)
                    {
                        totalLineCount = File.ReadLines(next).Count();
                    }

                    var minLineCount = totalLineCount - LoadLastLines;

                    var linesRead = 0L;
                    using (FileStream fs = File.Open(next, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        var lastPosition = lastPositionDict[next];

                        if (lastPosition > fs.Length)
                        {
                            lastPositionDict[next] = 0L;
                            lastPositionDict[next] = 0L;
                            initialLoad = true;
                            UpdateCallback("", 0, true);
                        }

                        fs.Seek(lastPosition, SeekOrigin.Begin);

                        var reader = new StreamReader(fs);

                        linesRead = ReadLines(reader, next, minLineCount);

                        lastPositionDict[next] = fs.Position;
                    }

                    FinishCallback?.Invoke(initialLoad, linesRead);

                    initialLoad = false;
                }
                catch (Exception ex)
                {
                    ExceptionCallback?.Invoke(ex);
                }
            }
        }

        private long ReadLines(StreamReader reader, string fileKey, int minLineCount)
        {
            var previousLineCount = lineCountDict[fileKey];
            string line;
            while (((line = reader.ReadLine()) != null))
            {
                var lineCount = ++lineCountDict[fileKey];
                
                if (lineCount > minLineCount && IsMatchFilter(ref line))
                {
                    line = line + Environment.NewLine;
                    UpdateCallback(line, lineCount, false);
                }
            }

            return lineCountDict[fileKey] - previousLineCount;
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
