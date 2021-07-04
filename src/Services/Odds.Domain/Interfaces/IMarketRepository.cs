using Odds.Domain.Entities;
using Odds.Domain.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odds.Domain.Interfaces
{
    public interface IMarketRepository : IAsyncRepository<Market>
    {
        Task<IEnumerable<Market>> GetMarketForEvent(Guid eventGuid);
        Task<IEnumerable<Market>> GetAllMarkets();
    }
}
