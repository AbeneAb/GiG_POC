using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odds.Repository.Context
{
    public class OddsContextDesignTimeFactory : IDesignTimeDbContextFactory<OddsContext>
    {
        public OddsContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<OddsContext>()
               .UseNpgsql("Host=localhost;Port=5432;Database=OddsDb;Username=admin;Password=admin1234");

            return new OddsContext(optionsBuilder.Options);
        }
    }
}
