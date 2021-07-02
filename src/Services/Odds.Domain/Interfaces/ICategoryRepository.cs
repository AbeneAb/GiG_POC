using Odds.Domain.Entities;
using Odds.Domain.Seed;

namespace Odds.Domain.Interfaces
{
    public interface ICategoryRepository : IAsyncRepository<Category>
    {
    }
}
