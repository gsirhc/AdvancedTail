using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tail.UnitTest.Predefined
{
    using System.Linq;
    using Filter;
    using Tail.Filter;
    using Tail.Predefined;

    [TestClass]
    public class FilterConfigurationTest
    {
        [TestMethod]
        public void TestAllPredefinedFilters()
        {
            foreach (var folder in FilterConfiguration.AllDefaultFolders)
            {
                foreach (var item in folder.Items)
                {
                    ValidatePredfinedItemTestStrings(folder, item);

                    var filter = FilterFactory.CreateFilter(item);
                    filter.SetEnabled(true);

                    foreach (var successTest in item.TestSuccessStrings)
                    {
                        TestPredefined(filter, successTest, folder, item);
                    }

                    foreach (var failTestString in item.TestFailStrings)
                    {
                        TestPredefined(filter, failTestString, folder, item);
                    }
                }
            }
        }

        private static void TestPredefined(ILineFilter filter, TestResult testResult, PredefinedFolder folder, PredefinedItem item)
        {
            var result = filter.IsMatch(testResult.TestString);
            Assert.IsNotNull(testResult.ExpectedFilterResult, $"[{folder.Name}/{item.Name}] has not defined ExpectedFilterResult");
            Assert.AreEqual(testResult.ExpectedFilterResult.IsMatch, result.IsMatch, $"[{folder.Name}/{item.Name}] failed IsMatch for '{testResult.TestString}'");
            Assert.AreEqual(testResult.ExpectedFilterResult.HighlightColor, result.HighlightColor, $"[{folder.Name}/{item.Name}] failed HighlightColor for '{testResult.TestString}'");

            if (testResult.ExpectedFilterResult.Result != null)
            {
                Assert.AreEqual(testResult.ExpectedFilterResult.Result, result.Result, $"{folder.Name}/[{item.Name}] failed Result for '{testResult.TestString}'");
            }
        }

        private static void ValidatePredfinedItemTestStrings(PredefinedFolder folder, PredefinedItem item)
        {
            Assert.IsNotNull(item.TestSuccessStrings, $"[{folder.Name}/{item.Name}] does not have TestSuccessStrings defined");
            Assert.IsTrue(item.TestSuccessStrings.Any(), $"[{item.Name}] does not have TestSuccessStrings defined");

            Assert.IsNotNull(item.TestFailStrings, $"[{folder.Name}/{item.Name}] does not have TestFailStrings defined");
            Assert.IsTrue(item.TestFailStrings.Any(), $"[{folder.Name}/{item.Name}] does not have TestFailStrings defined");
        }
    }
}
