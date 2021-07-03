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
        public void AddCompetition(string name) 
        {
            var exists = _competitions.Where(c => c.Name == name).SingleOrDefault();
            if(exists != null) 
            {
                throw new DomainException($"Competition {name} exists in collector");
            }
            var collection = new Competition(name);
            _competitions.Add(collection);
        }
    }
}
