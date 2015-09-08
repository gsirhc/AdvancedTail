using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tail.Filter
{
    using System.Drawing;

    /// <summary>
    /// Filter results and including the final result after processing
    /// </summary>
    public class FilterResult
    {
        /// <summary>
        /// Gets or sets a value indicating whether filter was a match.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is match; otherwise, <c>false</c>.
        /// </value>
        public bool IsMatch { get; set; }

        /// <summary>
        /// Gets or sets the result after processing all filters and processors in the pipeline.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public string Result { get; set; }

        /// <summary>
        /// Gets or sets the color to highlight the line, if any.
        /// </summary>
        /// <value>
        /// The color of the highlight.
        /// </value>
        public HighlightColor.ColorIndex HighlightColor { get; set;}
    }
}
