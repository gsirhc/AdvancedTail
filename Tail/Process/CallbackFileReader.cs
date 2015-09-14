namespace Tail.Process
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Threading;
    using Filter;
    using System.Linq;
    using Reader;

    /// <summary>
    /// Implementation of <see cref="ISerialFileReader" /> that uses callbacks to inform a parent of certain actions.
    /// </summary>
    public class CallbackFileReader : ISerialFileReader
    {
        private Dictionary<string, long> lastPositionDict = new Dictionary<string, long>();
        private Dictionary<string, TailStatistics> fileStatistics = new Dictionary<string, TailStatistics>();
        private bool initialLoad = true;
        
        private readonly Queue<string> queue = new Queue<string>();

        private Thread updateFileThread = null;
        private IReaderFactory readerFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="CallbackFileReader"/> class.
        /// </summary>
        public CallbackFileReader(IReaderFactory readerFactory)
        {
            this.readerFactory = readerFactory;
        }

        public Action<bool> StartCallback { get; set; }
        public Action<bool, TailStatistics> FinishCallback { get; set; }
        public Action<IList<TailLine>, bool> UpdateCallback { get; set; }
        public Action<Exception> ExceptionCallback { get; set; }
        public Func<int> LoadLastLines { get; set; }
        public Func<ILineFilter> Filter { get; set; }

        public void ClearQueue()
        {
            lock (queue)
            {
                queue.Clear();
                lastPositionDict = new Dictionary<string, long>();
                fileStatistics = new Dictionary<string, TailStatistics>();
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
                        fileStatistics.Add(next, new TailStatistics());
                    }

                    StartCallback?.Invoke(initialLoad);
                    var totalLineCount = 0;
                    var minLineCount = 0;
                    var clear = false;
                    using (var reader = readerFactory.CreateReader(next))
                    {
                        var loadLastLines = LoadLastLines();
                        if (initialLoad && loadLastLines >= 0 && lastPositionDict[next] == 0)
                        {
                            totalLineCount = reader.CountLines();
                            minLineCount = totalLineCount > loadLastLines ? totalLineCount - loadLastLines : 0;
                        }

                        var lastPosition = lastPositionDict[next];

                        if (lastPosition > reader.Length)
                        {
                            lastPositionDict[next] = lastPosition = 0L;
                            fileStatistics[next].Reset();
                            initialLoad = true;
                            StartCallback?.Invoke(initialLoad);
                            clear = true;
                        }

                        reader.Seek(lastPosition);                        
                        ReadLines(reader, next, minLineCount, clear);
                        lastPositionDict[next] = reader.Position;
                    }

                    FinishCallback?.Invoke(initialLoad, fileStatistics[next]);
                    initialLoad = false;
                }
                catch (Exception ex)
                {
                    ExceptionCallback?.Invoke(ex);
                }
            }
        }

        private void ReadLines(IReader reader, string fileKey, int minLineCount, bool clear)
        {
            var statistics = fileStatistics[fileKey];
            var lineList = new List<TailLine>();

            string line;
            var linesRead = 0;
            while (((line = reader.ReadLine()) != null))
            {
                var lineCount = ++statistics.Total;

                if (lineCount > minLineCount)
                {
                    HighlightColor.ColorIndex highlightColor;
                    if (IsMatchFilter(ref line, out highlightColor))
                    {
                        lineList.Add(new TailLine { Line = line, LineNumber = lineCount, ColorIndex = highlightColor });
                        statistics.Displayed++;                        
                    }
                    else
                    {
                        statistics.Ignored++;
                    }
                }

                linesRead++;
            }

            UpdateCallback(lineList, clear);

            statistics.LastRead = linesRead;
        }

        private bool IsMatchFilter(ref string line, out HighlightColor.ColorIndex highlightColor)
        {
            highlightColor = HighlightColor.ColorIndex.None;
            if (Filter != null)
            {
                var result = Filter().IsMatch(line);
                line = result.Result;
                highlightColor = result.HighlightColor;
                return result.IsMatch;
            }

            return true;
        }
    }
}
