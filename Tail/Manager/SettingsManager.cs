namespace Tail.Manager
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Script.Serialization;
    using Predefined;
    using Settings;

    /// <summary>
    /// Wrapper around the Property Settings.
    /// </summary>
    public class SettingsManager
    {
        FileSettingsMap fileSettingsMap = new FileSettingsMap();
        PredefinedFolder userFilterConfigs;

        private static SettingsManager instance = null;
        public static SettingsManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SettingsManager();
                }

                return instance;
            }
        }

        private SettingsManager()
        {
            if (Properties.Settings.Default.UpgradeRequired)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.UpgradeRequired = false;
            }
        }

        /// <summary>
        /// Gets the file settings for a given file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        public FileSettings GetFileSettings(string fileName)
        {
            return fileSettingsMap.Get(fileName);
        }
        
        public IEnumerable<string> GetLastUsedList(int lastUsedCount)
        {
            List<KeyValuePair<string, FileSettings>> list = fileSettingsMap.Map.ToList();
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
            get { return Properties.Settings.Default.RunAtStartup; }
            set { Properties.Settings.Default.RunAtStartup = value; Save(); }
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
                Save();
            }
        }
        
        public PredefinedFolder UserFilterConfigs
        {
            get
            {
                if (userFilterConfigs == null)
                {
                    if (!string.IsNullOrEmpty(Properties.Settings.Default.UserFilterConfigs))
                    {
                        var serializer = new JavaScriptSerializer();
                        userFilterConfigs = serializer.Deserialize<PredefinedFolder>(Properties.Settings.Default.UserFilterConfigs);
                    }
                    else
                    {
                        userFilterConfigs = FilterConfiguration.CreateUserDefinedFolder();
                    }
                }

                return userFilterConfigs;
            }
        }

        /// <summary>
        /// Saves settings.
        /// </summary>
        public void Save()
        {
            var filesJson = "";
            if (fileSettingsMap.Map.Any())
            {
                var serializer = new JavaScriptSerializer();
                filesJson = serializer.Serialize(fileSettingsMap.Map.ToDictionary(
                    item => item.Key.ToString(), 
                    item => serializer.Serialize(item.Value)));
            }

            Properties.Settings.Default.Files2 = filesJson;

            var userFilterConfigsJson = "";
            if (this.userFilterConfigs != null && this.userFilterConfigs.Items.Count > 0)
            {
                var serializer = new JavaScriptSerializer();
                userFilterConfigsJson = serializer.Serialize(this.userFilterConfigs);
            }

            Properties.Settings.Default.UserFilterConfigs = userFilterConfigsJson;

            Properties.Settings.Default.Save();
        }
    }
}
