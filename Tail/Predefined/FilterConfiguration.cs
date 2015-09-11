namespace Tail.Predefined
{
    using System.Collections.Generic;

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
                FolderType = PredefinedFolderType.Highlight,
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
                        }
                    },
                    new PredefinedItem
                    {
                        Name = "Error Only Highlighting",
                        Description = "Fatal/Error: Red, all other levels are not highlighted",
                        ClearFilter = false,
                        ClearHighlight = true,
                        Fields = new Dictionary<FormField, string>
                        {
                            { FormField.Red, "(?i)^(FATAL|ERROR)" }
                        }
                    }
                }
            },
            new PredefinedFolder
            {
                Name = "Remove - Log Levels",
                FolderType = PredefinedFolderType.Filter,
                Items = new List<PredefinedItem>
                {
                    new PredefinedItem
                    {
                        Name = "Trace",
                        Description = "Hides all Trace lines",
                        ClearFilter = true,
                        ClearHighlight = false,
                        Fields = new Dictionary<FormField, string>
                        {
                            { FormField.Filter, "(?i)^((?!TRACE).)*$" }
                        }
                    },
                    new PredefinedItem
                    {
                        Name = "Trace and Debug",
                        Description = "Hides all Trace and Debug lines",
                        ClearFilter = true,
                        ClearHighlight = false,
                        Fields = new Dictionary<FormField, string>
                        {
                            { FormField.Filter, "(?i)^((?!TRACE|DEBUG).)*$" }
                        }
                    },
                    new PredefinedItem
                    {
                        Name = "Info",
                        Description = "Hides all Info lines",
                        ClearFilter = true,
                        ClearHighlight = false,
                        Fields = new Dictionary<FormField, string>
                        {
                            { FormField.Filter, "(?i)^((?!INFO).)*$" }
                        }
                    },
                    new PredefinedItem
                    {
                        Name = "Errors and Warnings",
                        Description = "Hides all Error and Warning lines",
                        ClearFilter = true,
                        ClearHighlight = false,
                        Fields = new Dictionary<FormField, string>
                        {
                            { FormField.Filter, "(?i)^((?!ERROR|WARN).)*$" }
                        }
                    }
                }
            }
        };        
    }
}
