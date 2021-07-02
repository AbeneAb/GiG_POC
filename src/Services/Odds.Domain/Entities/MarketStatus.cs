using Odds.Domain.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odds.Domain.Entities
{
    public class MarketStatus : Enumeration
    {
        public static MarketStatus Open = new MarketStatus(1, nameof(Open).ToLowerInvariant());
        public static MarketStatus Closed = new MarketStatus(2, nameof(Closed).ToLowerInvariant());
        public static MarketStatus Canceled = new MarketStatus(3, nameof(Canceled).ToLowerInvariant());
        public MarketStatus(int id,string name):base(name,id)
        {

        }

    }
}
