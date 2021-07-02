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
        public Region(string name)
        {
            _name = name;
        }

        private readonly string _name;
        public string Name => _name;
        private readonly ICollection<Competition> _competitions;
        public IReadOnlyCollection<Competition> Competitions => _competitions.ToList();
        public void AddCometition() 
        {
          
        }
    }
}
