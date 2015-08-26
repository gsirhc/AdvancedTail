using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tail.Filter
{
    using System.Text.RegularExpressions;

    public class TrimFromProcessor : PipelineMember, IFilterProcessor
    {
        private Regex trimFrom = null;

        public TrimFromProcessor(string trimFromStr)
        {
            if (!string.IsNullOrWhiteSpace(trimFromStr))
            {
                trimFrom = new Regex(trimFromStr, RegexOptions.Compiled | RegexOptions.Singleline);
            }
        }

        protected override FilterResult Execute(FilterResult filterResult)
        {
            if (filterResult.IsMatch && trimFrom != null)
            {
                var line = filterResult.Result;

                var fromIndex = trimFrom.IsMatch(line) ? trimFrom.Match(line).Index : -1;

                if (fromIndex != -1 && fromIndex < line.Length)
                {
                    filterResult.Result = line.Substring(0, fromIndex);
                }
            }

            return filterResult;
        }
    }
}
