using Odds.Domain.Entities;
using Odds.Domain.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odds.Domain.Interfaces
{
    public interface IEventRepository : IAsyncRepository<Event>
    {
        Task<IEnumerable<Event>> GetAllEvent();
        Task<IEnumerable<Event>> GetEventByCategory(Guid categoryGuid);
        Task<IEnumerable<Event>> GetEventByDate(DateTime date);
    }
}
