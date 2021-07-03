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
    public class SelectionRepository : RepositoryBase<Selection>, ISelectionRepository
    {
        public SelectionRepository(OddsContext oddsContext):base(oddsContext)
        {

        }

        public async Task<IEnumerable<Selection>> GetSelectionForMarket(Guid marketGuid)
        {
            var selections = await GetAsync(x => x.MarketGuid == marketGuid);
            if(selections != null) 
            {
                foreach(var selection in selections) 
                {
                    await _context.Entry(selection).Reference(s => s.SelectionStatus).LoadAsync();
                }
            }
            return selections;
        }
    }
}
