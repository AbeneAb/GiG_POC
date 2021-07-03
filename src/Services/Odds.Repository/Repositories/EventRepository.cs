using Odds.Domain.Entities;
using Odds.Domain.Interfaces;
using Odds.Repository.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Odds.Repository.Repositories
{
    public class EventRepository : RepositoryBase<Event>, IEventRepository
    {
        public EventRepository(OddsContext context):base(context)
        {

        }

        public Task<IEnumerable<Event>> GetEventByCategory(Guid categoryGuid)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Event>> GetEventByDate(DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
