using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tail.UnitTest.Filter
{
    using Tail.Filter;

    [TestClass]
    public class TrimMiddleProcessorTest : FilterTestBase
    {
        [TestMethod]
        public void TestTrimMiddleDocumentationRegex()
        {
            const string regex = @"(?i)(We like this line because )";

            var result = TestTrimResult<TrimMiddleProcessor>(regex, "[7:10:02pm] We like this line because it rocks and rolls");
            Assert.AreEqual("[7:10:02pm] it rocks and rolls", result.Result);

            result = TestTrimResult<TrimMiddleProcessor>(regex, "[7:10:04pm] And we like this line because it rules and rolls");
            Assert.AreEqual("[7:10:04pm] And it rules and rolls", result.Result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGroupRequirement()
        {
            new TrimMiddleProcessor("test");
        }

        [TestMethod]
        public void TestSimpleGroup()
        {
            var result = TestTrimResult<TrimMiddleProcessor>("(test)", "[7:10:02pm] test this line");
            Assert.AreEqual("[7:10:02pm]  this line", result.Result);
        }
    }
}
