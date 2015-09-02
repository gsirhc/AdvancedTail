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
        FileSettingsMap fileSettingsMap = new FileSettingsMap();   

        public SettingsManager()
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
            set { Properties.Settings.Default.RunAtStartup = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to word-wrap the log display.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [word wrap]; otherwise, <c>false</c>.
        /// </value>
        public bool WordWrap
        {
            get { return Properties.Settings.Default.WordWrap; }
            set { Properties.Settings.Default.WordWrap = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to show line numbers in the file display.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [show line numbers]; otherwise, <c>false</c>.
        /// </value>
        public bool ShowLineNumbers
        {
            get { return Properties.Settings.Default.ShowLineNumbers; }
            set { Properties.Settings.Default.ShowLineNumbers = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [automatic scroll].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [automatic scroll]; otherwise, <c>false</c>.
        /// </value>
        public bool AutoScroll
        {
            get { return Properties.Settings.Default.AutoScroll; }
            set { Properties.Settings.Default.AutoScroll = value; }
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
        /// Gets or sets the load last n lines setting.
        /// </summary>
        /// <value>
        /// The load last n lines.
        /// </value>
        public int LoadLastLines
        {
            get
            {
                return Properties.Settings.Default.LoadLastLines;
            }
            set
            {
                Properties.Settings.Default.LoadLastLines = value;
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
            Properties.Settings.Default.Save();
        }
    }
}
