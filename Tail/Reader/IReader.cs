namespace Tail.Reader
{
    using System;

    public interface IReader : IDisposable
    {
        long Length { get; }
        long Position { get; }
        void Seek(long position);
        int CountLines();
        string ReadLine();
    }
}
