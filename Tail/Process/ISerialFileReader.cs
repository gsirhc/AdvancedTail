namespace Tail.Process
{
    using Filter;

    /// <summary>
    /// Interface to read files serially.  Can be the same file over and over, but ensures a file is read
    /// one at a time.
    /// </summary>
    public interface ISerialFileReader
    {
        /// <summary>
        /// Gets or sets the filter to apply to the file contexts.
        /// </summary>
        /// <value>
        /// The filter.
        /// </value>
        ILineFilter Filter { get; set; }

        /// <summary>
        /// Enables the queue.  If false, will stop reading
        /// </summary>
        /// <param name="enable">if set to <c>true</c> [enable].</param>
        void EnableQueue(bool enable);

        /// <summary>
        /// Queue a specified file path to be read.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        void Enqueue(string filePath);

        /// <summary>
        /// Clears the queue.
        /// </summary>
        void ClearQueue();
    }
}