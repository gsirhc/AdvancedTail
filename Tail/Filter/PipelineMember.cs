using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tail.Filter
{
    public abstract class PipelineMember : IPipelineMember
    {
        public IPipelineMember DownstreamMember { get; set; }

        public bool Enabled { get; private set; }

        public void SetEnabled(bool enabled, bool propgate = true)
        {
            Enabled = enabled;

            if (propgate)
            {
                DownstreamMember?.SetEnabled(enabled);
            }
        }

        public FilterResult Next(FilterResult result)
        {
            result = Enabled ? Execute(result) : result;

            if (DownstreamMember != null)
            {
                return DownstreamMember.Next(result);
            }

            return result;
        }

        protected abstract FilterResult Execute(FilterResult result);
    }
}

