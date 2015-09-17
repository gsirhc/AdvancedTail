using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tail.UnitTest.Filter
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Tail.Filter;

    public class FilterTestBase
    {
        protected FilterResult TestTrimResult<T>(string regex, string line, IPipelineMember downstreamTest = null) where T:IFilterProcessor
        {
            var processor = (T)Activator.CreateInstance(typeof(T), new object[] { regex });
            processor.SetEnabled(true);
            processor.DownstreamMember = downstreamTest;

            return TestProcessorResults(line, processor);
        }

        protected static FilterResult TestProcessorResults(string line, IFilterProcessor processor)
        {
            var resultToTest = new FilterResult
            {
                IsMatch = true,
                Result = line
            };

            return processor.Next(resultToTest);
        }

        protected void TestFilterResult(string regex, string line, bool assertTrue)
        {
            var filter = new FileLineRegexFilter(regex);
            TestFilterResult(filter, line, assertTrue);
        }

        protected void TestFilterResult(FileLineRegexFilter filter, string line, bool assertTrue)
        {
            filter.SetEnabled(true);

            var result = filter.IsMatch(line);

            if (assertTrue)
            {
                Assert.IsTrue(result.IsMatch);
            }
            else
            {
                Assert.IsFalse(result.IsMatch);
            }
        }
    }
}
