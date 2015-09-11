namespace Tail.Filter
{
    using System.Collections.Generic;
    using System.Drawing;

    /// <summary>
    /// Class to define abstract colors used in highlighting text in the log display.
    /// </summary>
    public class HighlightColor
    {
        public static Color DefaultBackground = Color.White;
        public static Color DefaultForeGround = Color.Black;

        public static Color RedBackground = Color.Salmon;
        public static Color RedForeground = Color.Black;

        public static Color YellowBackground = Color.Gold;
        public static Color YellowForeground = Color.Black;

        public static Color GreenBackground = Color.LightGreen;
        public static Color GreenForeground = Color.Black;

        public static Color BlueBackground = Color.LightBlue;
        public static Color BlueForeground = Color.Black;

        public static Color GrayBackground = Color.LightGray;
        public static Color GrayForeground = Color.Black;

        public static Color SubtleBackground = Color.White;
        public static Color SubtleForeground = Color.LightGray;

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
            Gray,
            Subtle
        }
    }
}
