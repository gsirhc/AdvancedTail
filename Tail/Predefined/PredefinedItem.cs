namespace Tail.Predefined
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Script.Serialization;
    using Filter;

    /// <summary>
    /// Predefined filter configuration item contains all the field values for the form.
    /// </summary>
    public class PredefinedItem
    {
        /// <summary>
        /// Gets or sets the name of the item.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the item.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to clear existing filters or not.
        /// </summary>
        public bool ClearFilter { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether clear existing highlight values or not.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [clear highlight]; otherwise, <c>false</c>.
        /// </value>
        public bool ClearHighlight { get; set; }

        /// <summary>
        /// Gets or sets the fields.
        /// </summary>
        [ScriptIgnore]
        public Dictionary<FormField,string> Fields { get; set; }

        /// <summary>
        /// Gets or sets the fields strings for serialization.
        /// </summary>
        public Dictionary<string, string> FieldsStrings
        {
            get { return Fields?.ToDictionary(item => item.Key.ToString(), item => item.Value); }
            set { Fields = value?.ToDictionary(item => (FormField)Enum.Parse(typeof(FormField), item.Key.ToString()), item => item.Value); }
        }

        /// <summary>
        /// Set of strings that should pass the predefined item (for unit testing).
        /// </summary>
        [ScriptIgnore]
        public IEnumerable<TestResult> TestSuccessStrings { get; set; }

        /// <summary>
        /// Set of strings that should fail the predefined item (for unit testing).
        /// </summary>
        [ScriptIgnore]
        public IEnumerable<TestResult> TestFailStrings { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
