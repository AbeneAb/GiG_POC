using Odds.Domain.Entities;
using Odds.Domain.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odds.Domain.Interfaces
{
    public interface ISelectionRepository : IAsyncRepository<Selection>
    {
        Task<Selection> GetSelection(Guid Id);
        Task<IEnumerable<Selection>> GetSelectionForMarket(Guid marketGuid);
        Task<IEnumerable<Selection>> GetAllSelection();
        Task<IEnumerable<Selection>> GetSelectionByMarketAndId(Guid guid,decimal odds);
    }
}
