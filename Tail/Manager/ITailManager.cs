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
        /// <value>
        /// The clear display callback.
        /// </value>
        Action ClearDisplayCallback { get; set; }

        /// <summary>
        /// Gets or sets the set state callback.
        /// </summary>
        /// <value>
        /// The set state callback.
        /// </value>
        Action<bool> SetStateCallback { get; set; }

        /// <summary>
        /// Gets or sets the exception callback.
        /// </summary>
        /// <value>
        /// The exception callback.
        /// </value>
        Action<Exception> ExceptionCallback { get; set; }

        /// <summary>
        /// Gets or sets the get file name callback.
        /// </summary>
        /// <value>
        /// The get file name callback.
        /// </value>
        Func<string> GetFileNameCallback { get; set; }

        /// <summary>
        /// Gets or sets the get filter callback.
        /// </summary>
        /// <value>
        /// The get filter callback.
        /// </value>
        Func<ILineFilter> GetFilterCallback { get; set; }

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