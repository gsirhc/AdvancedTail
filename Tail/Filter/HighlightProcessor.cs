using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tail.Filter
{
    using System.Drawing;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Checks if a line matches a highlight color regular expression.  If so, sets the color on the Result.  
    /// </summary>
    public class HighlightProcessor : PipelineMember, IFilterProcessor
    {
        private IDictionary<HighlightColor.ColorIndex, Regex> colorRegex = new Dictionary<HighlightColor.ColorIndex, Regex>();

        public HighlightProcessor(IDictionary<HighlightColor.ColorIndex, string> HighlightColorMap)
        {
            foreach (var key in HighlightColorMap.Keys)
            {
                if (!string.IsNullOrEmpty(HighlightColorMap[key]))
                {
                    colorRegex.Add(key, new Regex(HighlightColorMap[key], RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase));
                }
            }
        }

        protected override FilterResult Execute(FilterResult filterResult)
        {
            if (filterResult.IsMatch)
            {
                var line = filterResult.Result;
                filterResult.HighlightColor = HighlightColor.ColorIndex.None;

                foreach (var regex in colorRegex)
                {
                    if (regex.Value.IsMatch(line))
                    {
                        filterResult.HighlightColor = regex.Key;
                        break; // stop on first match
                    }
                }
            }

            return filterResult;
        }
    }
}
