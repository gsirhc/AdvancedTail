namespace Tail.Manager
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Script.Serialization;
    using Settings;

    /// <summary>
    /// Wrapper around the Property Settings.
    /// </summary>
    public class SettingsManager
    {
        private Dictionary<string, FileSettings> fileSettingsDict;

        /// <summary>
        /// Gets the file settings for a given file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        public FileSettings GetFileSettings(string fileName)
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

            if (!fileSettingsDict.ContainsKey(fileName))
            {
                fileSettingsDict.Add(fileName, new FileSettings());
            }

            return fileSettingsDict[fileName];
        }
        
        public IEnumerable<string> GetLastUsedList(int lastUsedCount)
        {
            List<KeyValuePair<string, FileSettings>> list = fileSettingsDict.ToList();
            list.Sort((firstPair, nextPair) => -1 * firstPair.Value.LastUsed.CompareTo(nextPair.Value.LastUsed));

            return list.Take(lastUsedCount).Select(kvp => kvp.Key);
        }

        /// <summary>
        /// Gets or sets a value indicating whether run at startup or not.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [run at startup]; otherwise, <c>false</c>.
        /// </value>
        public bool RunAtStartup
        {
            get
            {
                return Properties.Settings.Default.RunAtStartup;
            }
            set
            {
                Properties.Settings.Default.RunAtStartup = value;
            }
        }

        /// <summary>
        /// Gets or sets the last file tailed.
        /// </summary>
        /// <value>
        /// The last file.
        /// </value>
        public string LastFile
        {
            get
            {
                return Properties.Settings.Default.LastFile;
            }
            set
            {
                Properties.Settings.Default.LastFile = value;
            }
        }

        /// <summary>
        /// Saves settings.
        /// </summary>
        public void Save()
        {
            var filesJson = "";
            if (fileSettingsDict != null)
            {
                var serializer = new JavaScriptSerializer();
                filesJson = serializer.Serialize(fileSettingsDict.ToDictionary(
                    item => item.Key.ToString(), 
                    item => serializer.Serialize(item.Value)));
            }

            Properties.Settings.Default.Files2 = filesJson;
            Properties.Settings.Default.Save();
        }
    }
}
