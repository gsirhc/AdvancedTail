namespace Tail.Process
{
    using System;
    using System.Diagnostics.Eventing.Reader;
    using Reader;

    /// <summary>
    /// Factory to create an appropriate watch for a given path.
    /// </summary>
    public static class TailWatcherFactory
    {
        public static ITailWatcher CreateWatcher(string path, ISerialFileReader serialFileReader, Action<Exception> exceptionHandler)
        {
            switch (ReaderFactory.GetReaderType(path))
            {
                case ReaderType.File:
                    return new TailFileWatcher(serialFileReader, exceptionHandler);
                case ReaderType.EventLog:
                    return new TailEventLogWatcher(serialFileReader, exceptionHandler);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
