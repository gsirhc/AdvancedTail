using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tail.Filter
{
    using System.Text.RegularExpressions;

    public class TrimToProcessor : PipelineMember, IFilterProcessor
    {
        private Regex trimTo = null;

        public TrimToProcessor(string trimStr)
        {
            if (!string.IsNullOrWhiteSpace(trimStr))
            {
                trimTo = new Regex(trimStr, RegexOptions.Compiled | RegexOptions.Singleline);
            }
        }
        
        protected override FilterResult Execute(FilterResult filterResult)
        {
            if (filterResult.IsMatch && trimTo != null)
            {
                var line = filterResult.Result;

                var toIndex = trimTo.IsMatch(line) ? trimTo.Match(line).Index : -1;

                if (toIndex != -1 && toIndex < line.Length)
                {
                    filterResult.Result = line.Substring(toIndex);
                }
            }

            return filterResult;
        }
    }
}
