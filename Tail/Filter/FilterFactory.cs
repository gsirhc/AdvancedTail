namespace Tail.Filter
{
    using System.Collections.Generic;
    using Extensions;
    using Predefined;

    public static class FilterFactory
    {
        public static IDictionary<HighlightColor.ColorIndex, string> GetColorMap(PredefinedItem predefinedItem)
        {
            return new Dictionary<HighlightColor.ColorIndex, string>
                {
                    { HighlightColor.ColorIndex.Red, predefinedItem.Fields.GetValueOrDefault(FormField.Red, "") },
                    { HighlightColor.ColorIndex.Yellow, predefinedItem.Fields.GetValueOrDefault(FormField.Yellow, "") },
                    { HighlightColor.ColorIndex.Green, predefinedItem.Fields.GetValueOrDefault(FormField.Green, "") },
                    { HighlightColor.ColorIndex.Blue, predefinedItem.Fields.GetValueOrDefault(FormField.Blue, "") },
                    { HighlightColor.ColorIndex.Gray, predefinedItem.Fields.GetValueOrDefault(FormField.Gray, "") },
                    { HighlightColor.ColorIndex.Subtle, predefinedItem.Fields.GetValueOrDefault(FormField.Subtle, "") }
                };
        }

        public static ILineFilter CreateFilter(PredefinedItem predefinedItem)
        {
            return CreateFilter(
                predefinedItem.Fields.GetValueOrDefault(FormField.Filter, ""),
                GetColorMap(predefinedItem),
                predefinedItem.Fields.GetValueOrDefault(FormField.TrimTo, ""),
                predefinedItem.Fields.GetValueOrDefault(FormField.TrimFrom, ""),
                predefinedItem.Fields.GetValueOrDefault(FormField.TrimMiddle, "")
            );
        }

        public static ILineFilter CreateFilter(string filterRegex, 
            IDictionary<HighlightColor.ColorIndex, string> highlightColorMap, 
            string trimToRegex, string trimFromRegex, string trimMiddleRegex)
        {
            var filter = new FileLineRegexFilter(filterRegex)
            {
                DownstreamMember = new HighlightProcessor(highlightColorMap)
            };

            filter.DownstreamMember.DownstreamMember = CreateTrimProcessor(trimToRegex, trimFromRegex, trimMiddleRegex);

            return filter;
        }

        public static IFilterProcessor CreateTrimProcessor(string toRegex, string fromRegex, string trimMiddle)
        {
            // For now, trim the to, then the from
            IFilterProcessor trimTo = new TrimToProcessor(toRegex)
            {
                DownstreamMember = new TrimFromProcessor(fromRegex)
                {
                    DownstreamMember = new TrimMiddleProcessor(trimMiddle)
                }
            };

            return trimTo;
        }
    }
}
