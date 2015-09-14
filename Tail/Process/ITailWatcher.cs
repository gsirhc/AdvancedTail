namespace Tail.Process
{
    using System;

    public interface ITailWatcher : IDisposable
    {
        void Initialize();
        void Watch(string fileToTail);
    }
}
