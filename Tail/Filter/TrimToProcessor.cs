namespace Tail.Filter
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Trims a tail line to the first match of a regular expression from the beginning.  For example:
    /// 
    /// Trim Regex = "fox"
    /// Tail Line: "The quick brown fox jumps over the lazy dog"
    /// 
    /// Result: "fox jumps over the lazy dog" 
    /// </summary>
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
