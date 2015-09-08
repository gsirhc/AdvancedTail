namespace Tail.Process
{
    using System.Drawing;
    using Filter;

    public class TailLine
    {
        public int LineNumber { get; set; }
        public string Line { get; set; }
        public HighlightColor.ColorIndex ColorIndex { get; set; }
    }
}
