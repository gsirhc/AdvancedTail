using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tail.Filter
{
    /// <summary>
    /// Simple factory class to create a filter processor for trimming log lines
    /// </summary>
    public static class TrimProcessorFactory
    {
        public static IFilterProcessor CreateProcessor(string toRegex, string fromRegex, string trimMiddle)
        {
            // For now, trim the to, then the from
            IFilterProcessor trimTo = new TrimToProcessor(toRegex)
            {
                DownstreamMember = new TrimFromProcessor(fromRegex)
                {
                    DownstreamMember = new TrimMiddleProcessor(trimMiddle)
                }
            };

            return trimTo;
        }
    }
}
