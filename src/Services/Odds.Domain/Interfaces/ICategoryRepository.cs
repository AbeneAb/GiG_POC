using Odds.Domain.Entities;
using Odds.Domain.Seed;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Odds.Domain.Interfaces
{
    public interface ICategoryRepository : IAsyncRepository<Category>
    {
        Task<IEnumerable<Category>> GetAllCategories();
    }
}
