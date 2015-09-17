namespace Tail.Predefined
{
    using Filter;

    /// <summary>
    /// For unit testing predefined filters
    /// </summary>
    public class TestResult
    {
        /// <summary>
        /// Gets or sets the test string that should pass the ExpectedRegexField regex.
        /// </summary>
        public string TestString { get; set; }

        /// <summary>
        /// Gets or sets the field that should find the match.
        /// </summary>
        public FilterResult ExpectedFilterResult { get; set; }
    }
}
