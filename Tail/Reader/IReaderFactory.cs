namespace Tail.Reader
{
    using System;
    using Tail.Process;

    public interface IReaderFactory
    {
        IReader CreateReader(string path);
    }
}
