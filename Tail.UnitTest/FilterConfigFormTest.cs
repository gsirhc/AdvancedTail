using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tail.UnitTest
{
    using System.Collections.Generic;
    using System.Linq;
    using Tail.Filter;
    using Tail.Predefined;

    [TestClass]
    public class FilterConfigFormTest
    {
        [TestMethod]
        public void TestSetupPredefined()
        {
            var filterConfigForm = new FilterConfigForm();
            var predefinedFilter = new PredefinedItem
            {
                Fields = new Dictionary<FormField, string>()
            };

            foreach (var field in Enum.GetValues(typeof(FormField)).Cast<FormField>().Where(f => f != FormField.TrimMiddle))
            {
                predefinedFilter.Fields.Add(field, field.ToString().ToLower());
            }

            filterConfigForm.SetupPredefined(predefinedFilter, true);

            var expectedColorMap = FilterFactory.GetColorMap(predefinedFilter);
            var actualColorMap = filterConfigForm.HighlightColorMap;

            Assert.AreEqual(expectedColorMap.Keys.Count, actualColorMap.Keys.Count);

            foreach (var expectedKey in expectedColorMap.Keys)
            {
                Assert.AreEqual(expectedColorMap[expectedKey], actualColorMap[expectedKey], $"Key {expectedKey} differes");
            }
        }
    }
}
