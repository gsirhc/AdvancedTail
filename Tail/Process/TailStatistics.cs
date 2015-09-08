namespace Tail.Process
{
    public class TailStatistics
    {
        public int Total { get; set; }
        public int Displayed { get; set; }
        public int Ignored { get; set; }
        public int LastRead { get; set; }

        public void Reset()
        {
            Total = Displayed = Ignored = LastRead = 0;
        }
    }
}
