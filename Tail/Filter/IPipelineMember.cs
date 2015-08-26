using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tail.Filter
{
    /// <summary>
    /// Simple implementation interface for executing filters or processors in a pipeline fashion.
    /// </summary>
    public interface IPipelineMember
    {
        /// <summary>
        /// Gets a value indicating whether this member is enabled.  Disabled members still pass control to the downstream member
        /// </summary>
        /// <value>
        ///   <c>true</c> if enabled; otherwise, <c>false</c>.
        /// </value>
        bool Enabled { get; }

        /// <summary>
        /// Executes the next member in the pipeline, if DownstreamMember is not null.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <returns></returns>
        FilterResult Next(FilterResult result);

        /// <summary>
        /// Gets or sets the downstream member to execute after this member is executed.
        /// </summary>
        /// <value>
        /// The downstream member.
        /// </value>
        IPipelineMember DownstreamMember { get; set; }

        /// <summary>
        /// Sets Enabled.  Will propogate the value to the DownstreamMember by default..
        /// </summary>
        /// <param name="enabled">if set to <c>true</c> [enabled].</param>
        /// <param name="propgate">Set to false to only disable this member in the pipeline.</param>
        void SetEnabled(bool enabled, bool propgate = true);
    }
}
