namespace Tail.Filter
{
    using System.Collections.Generic;
    using System.Drawing;

    /// <summary>
    /// Class to define abstract colors used in highlighting text in the log display.
    /// </summary>
    public class HighlightColor
    {
        public static Color Default = Color.White;

        public static Color Red = Color.LightCoral;
        public static Color Yellow = Color.Gold;
        public static Color Green = Color.LightGreen;
        public static Color Blue = Color.LightBlue;
        public static Color Gray = Color.LightGray;

        /// <summary>
        /// Color index to match colors above.
        /// </summary>
        public enum ColorIndex
        {
            None,
            Red,
            Yellow,
            Green,
            Blue,
            Gray
        }
    }
}
