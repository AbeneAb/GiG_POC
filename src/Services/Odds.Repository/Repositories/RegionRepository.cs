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
    public class RegionRepository : RepositoryBase<Region>,IRegionRepository
    {
        public RegionRepository(OddsContext oddsContext):base(oddsContext)
        {

        }
    }
}
