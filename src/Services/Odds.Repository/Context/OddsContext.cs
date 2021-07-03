using Microsoft.EntityFrameworkCore;
using Odds.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Odds.Repository.Context
{
    public class OddsContext : DbContext
    {
        public const string DEFAULT_SCHEMA = "Odds";
        public DbSet<Category> Catgories { get; set; }
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventStatus> EventStatuses { get; set; }
        public DbSet<Market> Markets { get; set; }
        public DbSet<MarketTemplate> MarketTemplates { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<ParticipantDetail> ParticipantDetails { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Selection> Selections { get; set; }
        public OddsContext(DbContextOptions<OddsContext> optionsBuilder): base(optionsBuilder) 
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
