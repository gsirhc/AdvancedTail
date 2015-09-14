using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tail.Manager
{
    using Filter;
    using Process;

    public class FormInterface
    {
        public Action<bool> StartCallback { get; set; }
        public Action<bool, TailStatistics> FinishCallback { get; set; }
        public Action<IList<TailLine>, bool> UpdateCallback { get; set; }
        public Action ClearDisplayCallback { get; set; }
        public Action<bool> SetStateCallback { get; set; }
        public Action<Exception> ExceptionCallback { get; set; }
        public Func<string> GetFileNameCallback { get; set; }
        public Func<ILineFilter> GetFilterCallback { get; set; }
        public Func<int> LoadLastLinesCallback { get; set; }
    }
}
