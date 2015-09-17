using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tail.UnitTest.Filter
{
    using Tail.Filter;

    [TestClass]
    public class FileLineRegexFilterTest : FilterTestBase
    {
        [TestMethod]
        public void TestFilterDocumentationRegex()
        {
            var regex = "to see";

            TestFilterResult(regex, "[7:10:01pm] This is a test log line", false);
            TestFilterResult(regex, "[7:10:02pm] We want to see this line because it rocks", true);
            TestFilterResult(regex, "[7:10:03pm] But not this line", false);
            TestFilterResult(regex, "[7:10:04pm] And we want to see this line because it rules", true);

            regex = "rules|rocks";

            TestFilterResult(regex, "[7:10:01pm] This is a test log line", false);
            TestFilterResult(regex, "[7:10:02pm] We want to see this line because it rocks", true);
            TestFilterResult(regex, "[7:10:03pm] But not this line", false);
            TestFilterResult(regex, "[7:10:04pm] And we want to see this line because it rules", true);
        }

        
    }
}
