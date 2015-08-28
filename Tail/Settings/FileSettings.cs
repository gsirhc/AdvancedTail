using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tail.Settings
{
    public class FileSettings
    {
        public string FilterRegex { get; set; }
        public string ToTrimRegex { get; set; }
        public string FromTrimRegex { get; set; }
        public DateTime LastUsed { get; set; }
    }
}
