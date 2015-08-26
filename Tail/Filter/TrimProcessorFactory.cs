using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tail.Filter
{
    public static class TrimProcessorFactory
    {
        public static IFilterProcessor CreateProcessor(string toRegex, string fromRegex)
        {
            IFilterProcessor trimTo = new TrimToProcessor(toRegex)
            {
                DownstreamMember = new TrimFromProcessor(fromRegex)
            };

            return trimTo;
        }
    }
}
