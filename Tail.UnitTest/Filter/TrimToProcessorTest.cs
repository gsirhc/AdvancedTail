using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tail.UnitTest.Filter
{
    using Tail.Filter;

    [TestClass]
    public class TrimToProcessorTest : FilterTestBase
    {
        [TestMethod]
        public void TestTrimToDocumentationRegex()
        {
            const string regex = "it";

            var result = TestTrimResult<TrimToProcessor>(regex, "[7:10:02pm] We like this line because it rocks and rolls");
            Assert.AreEqual("it rocks and rolls", result.Result);

            result = TestTrimResult<TrimToProcessor>(regex, "[7:10:04pm] And we like this line because it rules and rolls");
            Assert.AreEqual("it rules and rolls", result.Result);            
        }

        [TestMethod]
        public void TestDocumentRegexWtihTrimFrom()
        {
            const string regex = "it";
            var downstream = new TrimFromProcessor("and rolls");
            downstream.SetEnabled(true);

            var result = TestTrimResult<TrimToProcessor>(regex, "[7:10:02pm] We like this line because it rocks and rolls", downstream);
            Assert.AreEqual("it rocks ", result.Result);

            result = TestTrimResult<TrimToProcessor>(regex, "[7:10:04pm] And we like this line because it rules and rolls", downstream);
            Assert.AreEqual("it rules ", result.Result);
        }        
    }
}
