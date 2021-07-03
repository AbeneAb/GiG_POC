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
    public class CategoryRepository : RepositoryBase<Category>,ICategoryRepository
    {
        public CategoryRepository(OddsContext oddsContext):base(oddsContext)
        {

        }
        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            var categories = await GetAllAsync();
            foreach(Category category in categories) 
            {
                await _context.Entry(category).Collection(c => c.Regions).LoadAsync();
                foreach(Region region in category.Regions) 
                {
                    await _context.Entry(region).Collection(r => r.Competitions).LoadAsync();
                    foreach(Competition competition in region.Competitions) 
                    {
                        await _context.Entry(competition).Collection(r => r.Participants).LoadAsync();
                        await _context.Entry(competition).Collection(c => c.Events).LoadAsync();
                        foreach(Event events in competition.Events) 
                        {
                            await _context.Entry(events).Collection(e => e.Markets).LoadAsync();
                            foreach(Market market in events.Markets) 
                            {
                                await _context.Entry(market).Collection(m => m.Selection).LoadAsync();
                            }
                        }
                    }
                }
            }
            return categories;
        }
    }
}
