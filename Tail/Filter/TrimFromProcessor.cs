namespace Tail.Filter
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Trims a tail line from the first match of a regular expression to the end.  For example:
    /// 
    /// Trim Regex = "fox"
    /// Tail Line: "The quick brown fox jumps over the lazy dog"
    /// 
    /// Result: "The quick brown " 
    /// </summary>
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
