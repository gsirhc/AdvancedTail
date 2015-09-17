using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tail.Filter
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Trims a tail line in the middle (i.e. from 1 regex group to the next group).  For example:
    /// 
    /// Trim Regex = "(brown)(the)"
    /// Tail Line: "The quick brown fox jumps over the lazy dog"
    /// 
    /// Result: "The quick lazy dog" 
    /// </summary>
    public class TrimMiddleProcessor : PipelineMember, IFilterProcessor
    {
        private Regex trimMiddle = null;

        public TrimMiddleProcessor(string trimFromStr)
        {
            if (!string.IsNullOrWhiteSpace(trimFromStr))
            {
                trimMiddle = new Regex(trimFromStr, RegexOptions.Compiled | RegexOptions.Singleline);

                if (trimMiddle.GetGroupNumbers().Length < 2)
                {
                    throw new Exception("Regex must have at least two groups, exmaple: (group1)(group2)");
                }
            }
        }

        protected override FilterResult Execute(FilterResult filterResult)
        {
            if (filterResult.IsMatch && trimMiddle != null)
            {
                var line = filterResult.Result;

                var match = trimMiddle.Match(line);

                if (match.Groups.Count >= 2)
                {
                    var start = match.Groups[0].Index;
                    var end = match.Groups[match.Groups.Count - 1].Index + match.Groups[match.Groups.Count - 1].Length;
                    
                    filterResult.Result = line.Remove(start, end - start);
                }
            }

            return filterResult;
        }
    }
}
