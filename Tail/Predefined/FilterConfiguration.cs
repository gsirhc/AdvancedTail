namespace Tail.Predefined
{
    using System.Collections.Generic;
    using Filter;

    public class FilterConfiguration
    {
        public static PredefinedFolder CreateUserDefinedFolder()
        {
            return new PredefinedFolder()
            {
                FolderType = PredefinedFolderType.User,
                Items = new List<PredefinedItem>(),
                Name = "Saved Filters"
            };
        }

        public static List<PredefinedFolder> AllDefaultFolders = new List<PredefinedFolder>
        {
            new PredefinedFolder
            {
                Name = "Log Level",
                Items = new List<PredefinedItem>
                {
                    new PredefinedItem
                    {
                        Name = "Full Highlighting",
                        Description = "Fatal/Error: Red, Warn: Yellow, Info: Green, Debug: Blue, Trace: Gray",
                        ClearFilter = false,
                        ClearHighlight = true,
                        Fields = new Dictionary<FormField, string>
                        {
                            { FormField.Red, "(?i)^(FATAL|ERROR)" },
                            { FormField.Yellow, "(?i)^(WARN)" },
                            { FormField.Green, "(?i)^(INFO)" },
                            { FormField.Blue, "(?i)^(DEBUG)" },
                            { FormField.Gray, "(?i)^(TRACE)" }
                        },
                        TestSuccessStrings = new [] {
                            new TestResult { TestString = "Fatal line",  ExpectedFilterResult = new FilterResult { HighlightColor = HighlightColor.ColorIndex.Red, IsMatch = true } },
                            new TestResult { TestString = "WARN line", ExpectedFilterResult = new FilterResult { HighlightColor = HighlightColor.ColorIndex.Yellow, IsMatch = true } },
                            new TestResult { TestString = "info line", ExpectedFilterResult = new FilterResult { HighlightColor = HighlightColor.ColorIndex.Green, IsMatch = true } },
                            new TestResult { TestString = "DEbug line", ExpectedFilterResult = new FilterResult { HighlightColor = HighlightColor.ColorIndex.Blue, IsMatch = true } },
                            new TestResult { TestString = "TRacE line", ExpectedFilterResult = new FilterResult { HighlightColor = HighlightColor.ColorIndex.Gray, IsMatch = true } },
                        },
                        TestFailStrings = new [] {
                            new TestResult { TestString = "Not this line with tall, or, inf, bug, ace", ExpectedFilterResult = new FilterResult { IsMatch = true, HighlightColor = HighlightColor.ColorIndex.None } }
                        }
                    },
                    new PredefinedItem
                    {
                        Name = "Subdued Trace and Debug",
                        Description = "Trace/Debug: Gray, all other levels are not highlighted",
                        ClearFilter = false,
                        ClearHighlight = true,
                        Fields = new Dictionary<FormField, string>
                        {
                            { FormField.Subtle, "(?i)^(TRACE|DEBUG)" }
                        },
                        TestSuccessStrings = new [] {
                            new TestResult { TestString = "trace line", ExpectedFilterResult = new FilterResult { HighlightColor = HighlightColor.ColorIndex.Subtle, IsMatch = true } },
                            new TestResult { TestString = "DEbug line", ExpectedFilterResult = new FilterResult { HighlightColor = HighlightColor.ColorIndex.Subtle, IsMatch = true } }
                        },
                        TestFailStrings = new [] {
                            new TestResult { TestString = "Not this line with tall, bug", ExpectedFilterResult = new FilterResult { IsMatch = true, HighlightColor = HighlightColor.ColorIndex.None } }
                        }
                    },
                    new PredefinedItem
                    {
                        Name = "Hightlight Error Only",
                        Description = "Fatal/Error: Red, all other levels are not highlighted",
                        ClearFilter = false,
                        ClearHighlight = true,
                        Fields = new Dictionary<FormField, string>
                        {
                            { FormField.Red, "(?i)^(FATAL|ERROR)" }
                        },
                        TestSuccessStrings = new [] {
                            new TestResult { TestString = "Fatal line", ExpectedFilterResult = new FilterResult { HighlightColor = HighlightColor.ColorIndex.Red, IsMatch = true } },
                            new TestResult { TestString = "error line", ExpectedFilterResult = new FilterResult { HighlightColor = HighlightColor.ColorIndex.Red, IsMatch = true } }
                        },
                        TestFailStrings = new [] {
                            new TestResult { TestString = "Not this line with tall, bug", ExpectedFilterResult = new FilterResult { IsMatch = true, HighlightColor = HighlightColor.ColorIndex.None } }
                        }
                    },
                    new PredefinedItem
                    {
                        Name = "Hide Trace",
                        Description = "Hides all Trace lines",
                        ClearFilter = true,
                        ClearHighlight = false,
                        Fields = new Dictionary<FormField, string>
                        {
                            { FormField.Filter, "(?i)^((?!TRACE).)*$" }
                        },
                        TestSuccessStrings = new [] {
                            new TestResult { TestString = "Line with ace and track", ExpectedFilterResult = new FilterResult { IsMatch = true } }
                        },
                        TestFailStrings = new [] {
                            new TestResult { TestString = "TraCE line", ExpectedFilterResult = new FilterResult { IsMatch = false } }
                        }
                    },
                    new PredefinedItem
                    {
                        Name = "Hide Trace and Debug",
                        Description = "Hides all Trace and Debug lines",
                        ClearFilter = true,
                        ClearHighlight = false,
                        Fields = new Dictionary<FormField, string>
                        {
                            { FormField.Filter, "(?i)^((?!TRACE|DEBUG).)*$" }
                        },
                        TestSuccessStrings = new [] {
                            new TestResult { TestString = "Info this line", ExpectedFilterResult = new FilterResult { IsMatch = true } }
                        },
                        TestFailStrings = new [] {
                            new TestResult { TestString = "TraCE line", ExpectedFilterResult = new FilterResult { IsMatch = false } },
                            new TestResult { TestString = "debug line", ExpectedFilterResult = new FilterResult { IsMatch = false } }
                        }
                    },
                    new PredefinedItem
                    {
                        Name = "Hide Info",
                        Description = "Hides all Info lines",
                        ClearFilter = true,
                        ClearHighlight = false,
                        Fields = new Dictionary<FormField, string>
                        {
                            { FormField.Filter, "(?i)^((?!INFO).)*$" }
                        },
                        TestSuccessStrings = new [] {
                            new TestResult { TestString = "Trace this line", ExpectedFilterResult = new FilterResult { IsMatch = true } }
                        },
                        TestFailStrings = new [] {
                            new TestResult { TestString = "inFO line", ExpectedFilterResult = new FilterResult { IsMatch = false } }
                        }
                    },
                    new PredefinedItem
                    {
                        Name = "Hide Errors and Warnings",
                        Description = "Hides all Error and Warning lines",
                        ClearFilter = true,
                        ClearHighlight = false,
                        Fields = new Dictionary<FormField, string>
                        {
                            { FormField.Filter, "(?i)^((?!ERROR|WARN).)*$" }
                        },
                        TestSuccessStrings = new [] {
                            new TestResult { TestString = "debug this line", ExpectedFilterResult = new FilterResult { IsMatch = true } }
                        },
                        TestFailStrings = new [] {
                            new TestResult { TestString = "ERROR line", ExpectedFilterResult = new FilterResult { IsMatch = false } },
                            new TestResult { TestString = "warn line", ExpectedFilterResult = new FilterResult { IsMatch = false } }
                        }
                    }
                }
            },
            new PredefinedFolder
            {
                Name = "Windows Event Log",
                Items = new List<PredefinedItem>
                {
                    new PredefinedItem
                    {
                        Name = "Show Errors Only",
                        Description = "Shows error entries, hides all others",
                        ClearFilter = true,
                        ClearHighlight = false,
                        Fields = new Dictionary<FormField, string>
                        {
                            { FormField.Filter, "(?i)^(Error)" }
                        },
                        TestSuccessStrings = new [] {
                            new TestResult { TestString = "Error [1/2/3 4:5:6] test", ExpectedFilterResult = new FilterResult { IsMatch = true } }
                        },
                        TestFailStrings = new [] {
                            new TestResult { TestString = "Information [1/2/3 4:5:6] test", ExpectedFilterResult = new FilterResult { IsMatch = false } }
                        }
                    },
                    new PredefinedItem
                    {
                        Name = "Show Message Only",
                        Description = "Trims all but the severity, time and message.",
                        ClearFilter = false,
                        ClearHighlight = false,
                        Fields = new Dictionary<FormField, string>
                        {
                            { FormField.TrimMiddle, @"(\]).*(Message=)" }
                        },
                        TestSuccessStrings = new [] {
                            new TestResult { TestString = "Error [1/2/3 4:5:6] Source=some source Message= test this message", ExpectedFilterResult = new FilterResult { IsMatch = true, Result = "Error [1/2/3 4:5:6 test this message" } }
                        },
                        TestFailStrings = new [] {
                            new TestResult { TestString = "Information [1/2/3 4:5:6] test", ExpectedFilterResult = new FilterResult { IsMatch = true, Result = "Information [1/2/3 4:5:6] test" } }
                        }
                    },
                    new PredefinedItem
                    {
                        Name = "Highlight Errors",
                        Description = "Errors are highlighted red",
                        ClearFilter = false,
                        ClearHighlight = true,
                        Fields = new Dictionary<FormField, string>
                        {
                            { FormField.Red, "(?i)^(Error)" }
                        },
                        TestSuccessStrings = new [] {
                            new TestResult { TestString = "Error [1/2/3 4:5:6] Source=some source Message= test this message", ExpectedFilterResult = new FilterResult { HighlightColor = HighlightColor.ColorIndex.Red, IsMatch = true } }
                        },
                        TestFailStrings = new [] {
                            new TestResult { TestString = "Information [1/2/3 4:5:6] Source=some source Message= test this message", ExpectedFilterResult = new FilterResult { IsMatch = true, HighlightColor = HighlightColor.ColorIndex.None } }
                        }
                    },
                    new PredefinedItem
                    {
                        Name = "Subdued",
                        Description = "Errors are default font, all others are subdued",
                        ClearFilter = false,
                        ClearHighlight = true,
                        Fields = new Dictionary<FormField, string>
                        {
                            { FormField.Subtle, "(?i)^(?!Error).*$" }
                        },
                        TestSuccessStrings = new [] {
                            new TestResult { TestString = "Information [1/2/3 4:5:6] Source=some source Message= test this message", ExpectedFilterResult = new FilterResult { HighlightColor = HighlightColor.ColorIndex.Subtle, IsMatch = true } },
                            new TestResult { TestString = "Warning [1/2/3 4:5:6] Source=some source Message= test this message", ExpectedFilterResult = new FilterResult { HighlightColor = HighlightColor.ColorIndex.Subtle, IsMatch = true } }
                        },
                        TestFailStrings = new [] {
                            new TestResult { TestString = "Error [1/2/3 4:5:6] Source=some source Message= test this message", ExpectedFilterResult = new FilterResult { IsMatch = true, HighlightColor = HighlightColor.ColorIndex.None } }
                        }
                    }
                }
            }
        };        
    }
}
