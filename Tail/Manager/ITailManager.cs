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
        /// <summary>
        /// Gets or sets the form interface callbacks.
        /// </summary>
        FormInterface FormInterface { get; set; }

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