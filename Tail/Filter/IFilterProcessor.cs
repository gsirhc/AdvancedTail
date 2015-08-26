namespace Tail.Filter
{
    /// <summary>
    /// Processes the results of a filter.  It is inteded to be executed after a filter and therefore is always a child member in a pipeline.
    /// </summary>
    public interface IFilterProcessor : IPipelineMember
    {

    }
}