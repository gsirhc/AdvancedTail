using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tail.Settings
{
    public class FileSettings
    {
        public static FileSettings Default => new FileSettings
        {
            AutoScroll = true,
            EnableFilter = true,
            EnableTrim = true,
            LoadLastLines = 10
        };

        public string FilterRegex { get; set; }
        public string ToTrimRegex { get; set; }
        public string FromTrimRegex { get; set; }
        public DateTime LastUsed { get; set; }
        public bool WordWrap { get; set; }
        public bool ShowLineNumbers { get; set; }
        public bool AutoScroll { get; set; }
        public bool EnableFilter { get; set; }
        public bool EnableTrim { get; set; }
        public int LoadLastLines { get; set; }
    }
}
