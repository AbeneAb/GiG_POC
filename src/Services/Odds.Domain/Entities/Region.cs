using Odds.Domain.Exceptions;
using Odds.Domain.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Odds.Domain.Entities
{
    public class Region : EntityBase
    {
        private Region() 
        {
            _competitions = new HashSet<Competition>();
        }
        public Region(string name):this()
        {
            _name = name;
        }

        private readonly string _name;
        public string Name => _name;
        private readonly ICollection<Competition> _competitions;
        public IReadOnlyCollection<Competition> Competitions => _competitions.ToList();
        public void AddCompetition(Competition competition) 
        {
            var exists = _competitions.Where(c => c.Name == competition.Name).SingleOrDefault();
            if(exists != null) 
            {
                throw new DomainException($"Competition {competition.Name} exists in collector");
            }
            _competitions.Add(competition);
        }
    }
}
