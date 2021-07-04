using Odds.Domain.Entities;
using Odds.Domain.Interfaces;
using Odds.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odds.Repository.Repositories
{
    public class MarketRepository : RepositoryBase<Market>, IMarketRepository
    {
        public MarketRepository(OddsContext context):base(context)
        {

        }

        public async Task<IEnumerable<Market>> GetAllMarkets()
        {
            var markets = await GetAllAsync();
            if (markets != null)
            {
                foreach (var market in markets)
                {
                    await _context.Entry(market).Reference(s => s.MarketStatus).LoadAsync();
                    await _context.Entry(market).Collection(s => s.Selection).LoadAsync();
                    foreach (var selection in market.Selection)
                    {
                        await _context.Entry(selection).Reference(s => s.SelectionStatus).LoadAsync();
                    }
                }
            }
            return markets;
        }

        public async Task<IEnumerable<Market>> GetMarketForEvent(Guid eventGuid)
        {
            var markets = await GetAsync(x => x.EventGuid == eventGuid);
            if(markets != null) 
            {
                foreach (var market in markets)
                {
                    await _context.Entry(market).Reference(s => s.MarketStatus).LoadAsync();
                    await _context.Entry(market).Collection(s => s.Selection).LoadAsync();
                    foreach (var selection in market.Selection)
                    {
                        await _context.Entry(selection).Reference(s => s.SelectionStatus).LoadAsync();
                    }
                }
            }
            return markets;
        }
    }
}
