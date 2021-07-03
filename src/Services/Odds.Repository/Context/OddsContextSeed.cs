using Microsoft.Extensions.Logging;
using Odds.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odds.Repository.Context
{
    public class OddsContextSeed
    {
        public static async Task SeedAsync(OddsContext oddsContext, ILogger<OddsContextSeed> logger) 
        {
            if (!oddsContext.Catgories.Any())
            {
                IEnumerable<Category> sampledata = GetPreConfiguredCategories();
                oddsContext.Catgories.AddRange(sampledata);

                await oddsContext.SaveChangesAsync();
            }
            if (!oddsContext.Events.Any()) 
            {
                await oddsContext.AddRangeAsync(GetPreconfiguredEvents());
                await oddsContext.SaveChangesAsync();
            }
        }
        private static IEnumerable<Category> GetPreConfiguredCategories() 
        {

            var football = GetFootballCategory();
            var basketBall = GetBasketBallCategory();

            return new List<Category> { football,basketBall};
            
        }
        private static Category GetFootballCategory() 
        {
            var england = new Region("England");
            var epl = new Competition("Premier League");
            var liverpool = new Participant("Liverpool");
            var city = new Participant("Man City");
            var chelsea = new Participant("Chelsea");
            var utd = new Participant("Man United");
            var leeds = new Participant("Leeds Utd");
            var arsenal = new Participant("Arsenal");

            var eplParticipant = new List<Participant> { liverpool, city, chelsea, utd, leeds, arsenal };
            foreach (var part in eplParticipant)
            {
                epl.AddParticipant(part.Name);
            }
            var faCup = new Competition("FA Cup");
            var norwich = new Participant("Norwich");
            var southhampton = new Participant("Southhampton");
            var wycomb = new Participant("Wycomb");
            var bolton = new Participant("Bolton");
            var faCupPartcicpant = new List<Participant> { norwich, southhampton, wycomb, bolton, liverpool, leeds, arsenal, city };
            foreach (var part in faCupPartcicpant)
            {
                faCup.AddParticipant(part.Name);
            }

            var eplCompetition = new List<Competition> { epl, faCup };
            foreach (var comp in eplCompetition)
            {
                england.AddCompetition(comp.Name);
            }

            var spain = new Region("Spain");
            var laliga = new Competition("La Liga");
            var copaDelrey = new Competition("Copa Del Rey");
            var realMadrid = new Participant("Real Madrid");
            var barcelona = new Participant("Barcelona");
            var bilbao = new Participant("Atl. Bilbao");
            var atlMadrid = new Participant("Atl. Madrid");
            var celta = new Participant("Celta Vigo");
            var valencia = new Participant("Valencia");
            var tenerife = new Participant("Tenerife");
            var oviedo = new Participant("Oviedo");
            var cadiz = new Participant("Cadiz");
            var girona = new Participant("Girona");
            var laligaParticipant = new List<Participant> { realMadrid, barcelona, bilbao, atlMadrid, celta, valencia };

            foreach (var part in laligaParticipant)
            {
                laliga.AddParticipant(part.Name);
            }
            var copaDelreyParticipant = new List<Participant> { barcelona, atlMadrid, tenerife, oviedo, cadiz, girona };
            foreach (var part in copaDelreyParticipant)
            {
                copaDelrey.AddParticipant(part.Name);
            }
            var spainCompetition = new List<Competition> { laliga, copaDelrey };
            foreach (var comp in spainCompetition)
            {
                spain.AddCompetition(comp.Name);
            }

            var regions = new List<Region> { england, spain };
            var category = new Category("Football", null);
            foreach (var region in regions)
            {
                category.AddRegion(region.Name);
            }
            return category;
        }
        private static Category GetBasketBallCategory() 
        {
            var usa = new Region("USA");
            var nba = new Competition("NBA");
            var laLakers = new Participant("Los angeles Lakers");
            var boston = new Participant("Boston Celtic");
            var suns = new Participant("Suns");
            var spurs = new Participant("San antonio Spurs");
            var heat = new Participant("Miami Heat");
            var bulls = new Participant("Chicago Bulls");

            var nbaParticipant = new List<Participant> { laLakers, boston, suns, spurs, heat, bulls };
            foreach (var part in nbaParticipant)
            {
                nba.AddParticipant(part.Name);
            }
            usa.AddCompetition(nba.Name);
            var basket = new Category("BasketBall", null);
            basket.AddRegion(usa.Name);
            return basket;
        }
        private static IEnumerable<Event> GetPreconfiguredEvents() 
        {

            return Enumerable.Empty<Event>();
        }
    }
}
