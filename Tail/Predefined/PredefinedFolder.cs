namespace Tail.Predefined
{
    using System;
    using System.Collections.Generic;
    using System.Web.Script.Serialization;

    /// <summary>
    /// Predefined folder containing all related items
    /// </summary>
    public class PredefinedFolder
    {
        /// <summary>
        /// Gets or sets the name of the folder.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the type of items in the folder.
        /// </summary>
        [ScriptIgnore]
        public PredefinedFolderType FolderType { get; set; }

        /// <summary>
        /// Gets or sets the folder type string for serialization.
        /// </summary>
        public string FolderTypeString
        {
            get { return FolderType.ToString(); }
            set { FolderType = (PredefinedFolderType)Enum.Parse(typeof(PredefinedFolderType), value); }
        }

        /// <summary>
        /// Gets or sets the related items.
        /// </summary>
        public List<PredefinedItem> Items { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
