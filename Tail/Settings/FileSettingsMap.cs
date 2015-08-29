using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tail.Settings
{
    using System.Collections.Concurrent;
    using System.Web.Script.Serialization;

    public class FileSettingsMap
    {
        private Dictionary<string, FileSettings> fileSettingsDict;
        private object threadLock = new object();

        public FileSettings Get(string fileName)
        {
            lock (threadLock)
            {
                if (!SafeMap.ContainsKey(fileName))
                {
                    SafeMap.Add(fileName, new FileSettings());
                }

                return SafeMap[fileName];
            }
        }

        public IEnumerable<KeyValuePair<string, FileSettings>> Map
        {
            get
            {
                lock (threadLock)
                {
                    return SafeMap.ToArray();
                }
            }
        }

        private IDictionary<string, FileSettings> SafeMap
        {
            get
            {
                if (fileSettingsDict == null)
                {
                    var serializer = new JavaScriptSerializer();
                    fileSettingsDict = new Dictionary<string, FileSettings>();
                    var dict = (Dictionary<string, object>)serializer.DeserializeObject(Properties.Settings.Default.Files2);
                    if (dict != null)
                    {
                        foreach (var kvp in dict)
                        {
                            fileSettingsDict.Add(kvp.Key, serializer.Deserialize<FileSettings>(kvp.Value.ToString()));
                        }
                    }
                }

                return fileSettingsDict;
            }
        } 
    }
}
