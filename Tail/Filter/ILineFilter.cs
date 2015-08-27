namespace Tail.Filter
{
    /// <summary>
    /// Interface for filtering lines in the tailed log.  Filters are part of the pipeline
    /// and can be joined together, if desired.  
    /// </summary>
    public interface ILineFilter : IPipelineMember
    {
        /// <summary>
        /// Determines whether the specified line matches the filter.  Executes downstream filters/process so the returned
        /// result contains whether the filter matches or not and any post process that is down to the line string..
        /// </summary>
        /// <param name="line">The line.</param>
        /// <returns><see cref="FilterResult"/></returns>
        FilterResult IsMatch(string line);        
    }
}