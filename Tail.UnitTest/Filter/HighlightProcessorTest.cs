namespace Tail.UnitTest.Filter
{
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Tail.Filter;

    [TestClass]
    public class HighlightProcessorTest : FilterTestBase
    {
        private Dictionary<HighlightColor.ColorIndex, string> colorRegexs;

        [TestInitialize]
        public void Setup()
        {
            this.colorRegexs = new Dictionary<HighlightColor.ColorIndex, string>
            {
                { HighlightColor.ColorIndex.Red, "" },
                { HighlightColor.ColorIndex.Yellow, "" },
                { HighlightColor.ColorIndex.Green, "" },
                { HighlightColor.ColorIndex.Blue, "" },
                { HighlightColor.ColorIndex.Gray, "" },
                { HighlightColor.ColorIndex.Subtle, "" },
            };
        }

        [TestMethod]
        public void TestSingleColor()
        {
            colorRegexs[HighlightColor.ColorIndex.Red] = "(?i)^(FATAL|ERROR)";
            var processor = new HighlightProcessor(colorRegexs);
            processor.SetEnabled(true);

            var result = TestProcessorResults("Fatal [7:10:02pm] Some really bad happened", processor);
            Assert.AreEqual(HighlightColor.ColorIndex.Red, result.HighlightColor);

            result = TestProcessorResults("Error [7:10:02pm] Some no as bad happened", processor);
            Assert.AreEqual(HighlightColor.ColorIndex.Red, result.HighlightColor);

            result = TestProcessorResults("Info [7:10:02pm] nothing bad happened", processor);
            Assert.AreEqual(HighlightColor.ColorIndex.None, result.HighlightColor);
        }

        public void TestMultipleColors()
        {
            colorRegexs[HighlightColor.ColorIndex.Red] = "(?i)^(FATAL|ERROR)";
            colorRegexs[HighlightColor.ColorIndex.Blue] = "(?i)^(INFO)";
            var processor = new HighlightProcessor(colorRegexs);
            processor.SetEnabled(true);

            var result = TestProcessorResults("Fatal [7:10:02pm] Some really bad happened", processor);
            Assert.AreEqual(HighlightColor.ColorIndex.Red, result.HighlightColor);

            result = TestProcessorResults("Info [7:10:02pm] nothing bad happened", processor);
            Assert.AreEqual(HighlightColor.ColorIndex.Blue, result.HighlightColor);

            result = TestProcessorResults("Warn [7:10:02pm] no color please", processor);
            Assert.AreEqual(HighlightColor.ColorIndex.None, result.HighlightColor);
        }
    }
}
