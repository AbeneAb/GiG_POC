using Microsoft.EntityFrameworkCore;
using Odds.Domain.Entities;
using Odds.Domain.Interfaces;
using Odds.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odds.Repository.Repositories
{
    public class EventRepository : RepositoryBase<Event>, IEventRepository
    {
        public EventRepository(OddsContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Event>> GetAllEvent()
        {
            var events = await GetAllAsync();
            if(events != null) 
            {
                foreach(var @event in events) 
                {
                    await _context.Entry(@event).Reference(e => e.Competition).LoadAsync();
                    await _context.Entry(@event).Collection(e => e.Participants).LoadAsync();
                    await _context.Entry(@event).Reference(e => e.Category).LoadAsync();
                    await _context.Entry(@event).Reference(e => e.EventStatus).LoadAsync();
                    await _context.Entry(@event).Collection(e => e.Markets).LoadAsync();
                    if(@event.Markets != null && @event.Markets.Count > 0) 
                    {
                        foreach (var market in @event.Markets)
                        {
                            await _context.Entry(market).Reference(m => m.MarketStatus).LoadAsync();
                            await _context.Entry(market).Collection(s => s.Selection).LoadAsync();
                            foreach (var selection in market.Selection)
                            {
                                await _context.Entry(selection).Reference(s => s.SelectionStatus).LoadAsync();
                            }
                        }
                    }
                    if(@event.Participants != null && @event.Participants.Count > 0) 
                    {
                        foreach(var participant in @event.Participants) 
                        {
                            await _context.Entry(participant).Reference(p => p.Participant).LoadAsync();
                        }
                    }

                }
            }
            return events;

        }
        public async Task<IEnumerable<Event>> GetEventByCategory(Guid categoryGuid)
        {

            var events = (await FindAsync(x => x.CategoryGUID == categoryGuid)).ToList();
            if (events != null)
            {
                foreach (var eve in events)
                {
                    await _context.Entry(eve).Collection(i => i.Participants).LoadAsync();
                    await _context.Entry(eve).Reference(i => i.EventStatus).LoadAsync();
                    await _context.Entry(eve).Collection(i => i.Markets).LoadAsync();
                    if (eve.Markets != null && eve.Markets.Count > 0)
                    {
                        foreach (var market in eve.Markets)
                        {
                            await _context.Entry(market).Collection(s => s.Selection).LoadAsync();
                            foreach(var selection in market.Selection) 
                            {
                                await _context.Entry(selection).Reference(s => s.SelectionStatus).LoadAsync();
                            }
                        }
                    }
                }
            }
            return events;
        }
        public async Task<IEnumerable<Event>> GetEventByDate(DateTime date)
        {
            var events = await GetAsync(x => x.StartDateTime <= date && x.IsActive == true);
            if (events != null)
            {
                foreach (var @event in events)
                {
                    await _context.Entry(@event).Collection(e => e.Participants).LoadAsync();
                    await _context.Entry(@event).Reference(e => e.EventStatus).LoadAsync();
                    await _context.Entry(@event).Collection(e => e.Markets).LoadAsync();
                    if (@event.Markets != null && @event.Markets.Count > 0)
                    {
                        foreach (var market in @event.Markets)
                        {
                            await _context.Entry(market).Collection(s => s.Selection).LoadAsync();
                            foreach (var selection in market.Selection)
                            {
                                await _context.Entry(selection).Reference(s => s.SelectionStatus).LoadAsync();
                            }
                        }
                    }
                }
            }
            return events;
        }
        
    }
}
