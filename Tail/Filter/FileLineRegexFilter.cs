using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tail.Filter
{
    using System.Text.RegularExpressions;

    public class FileLineRegexFilter : PipelineMember, ILineFilter
    {
        private Regex filter = null;

        public FileLineRegexFilter(string filterStr)
        {
            if (!string.IsNullOrWhiteSpace(filterStr))
            {
                filter = new Regex(filterStr, RegexOptions.Compiled | RegexOptions.Singleline);
            }
        }
        
        public bool EnableFilter { get; set; }

        protected override FilterResult Execute(FilterResult result)
        {
            return GetResult(result.Result);
        }

        public FilterResult IsMatch(string line)
        {
            return Next(GetResult(line));
        }

        private FilterResult GetResult(string line)
        {
            return new FilterResult()
            {
                IsMatch = !EnableFilter || filter.IsMatch(line),
                Result = line
            };
        }
    }
}
