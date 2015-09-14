namespace Tail.Reader
{
    using System;
    using System.IO;
    using System.Linq;

    public class FileReaderWrapper : IReader
    {
        private FileStream fileStream;
        private StreamReader reader;
        private string path;

        public FileReaderWrapper(string path)
        {
            this.path = path;
            this.fileStream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            reader = new StreamReader(this.fileStream);
        }

        public long Length { get { return fileStream.Length; } }

        public long Position { get { return fileStream.Position; } }

        public void Seek(long position)
        {
            fileStream.Seek(position, SeekOrigin.Begin);
        }

        public int CountLines()
        {
            return File.ReadLines(path).Count();
        }   

        public string ReadLine()
        {
            return reader.ReadLine();
        }

        public void Dispose()
        {
            reader.Dispose();
        }
    }
}
