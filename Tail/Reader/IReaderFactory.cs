namespace Tail.Reader
{
    using System;
    using Tail.Process;

    public interface IReaderFactory
    {
        ITailWatcher CreateWatcher(string path, ISerialFileReader serialFileReader, Action<Exception> exceptionHandler);
        IReader CreateReader(string path);
    }
}
