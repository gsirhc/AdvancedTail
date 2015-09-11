namespace Tail.Manager
{
    using System;
    using Filter;
    using Process;

    /// <summary>
    /// Interface to manage tail.  Takes some burden off the Form.
    /// </summary>
    public interface ITailManager
    {
        ISerialFileReader SerialFileReader { get; set; }

        /// <summary>
        /// Gets or sets the clear display callback.
        /// </summary>
        Action ClearDisplayCallback { get; set; }

        /// <summary>
        /// Gets or sets the set state callback.
        /// </summary>
        Action<bool> SetStateCallback { get; set; }

        /// <summary>
        /// Gets or sets the exception callback.
        /// </summary>
        Action<Exception> ExceptionCallback { get; set; }

        /// <summary>
        /// Gets or sets the get file name callback.
        /// </summary>
        Func<string> GetFileNameCallback { get; set; }

        /// <summary>
        /// Gets or sets the get filter callback.
        /// </summary>
        Func<ILineFilter> GetFilterCallback { get; set; }

        /// <summary>
        /// Gets a value indicating whether tailing a file or not.
        /// </summary>
        bool IsRunning { get; }

        /// <summary>
        /// Starts the tail.
        /// </summary>
        /// <param name="loadLastLines">Load last n lines.</param>
        /// <param name="save">if set to <c>true</c> [save].</param>
        /// <param name="stop">if set to <c>true</c> [stop].</param>
        void StartTail(bool save = true, bool stop = true);

        /// <summary>
        /// Stops the tail.
        /// </summary>
        /// <param name="formClosing">if set to <c>true</c> [form closing].</param>
        void StopTail();
    }
}