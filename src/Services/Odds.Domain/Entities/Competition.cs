using Odds.Domain.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Odds.Domain.Entities
{
    public class Competition : EntityBase 
    {
        private Competition() 
        {
        }
        public Competition(string name,Guid regionGuid)
        {
            _name = name;
            _regionGuid = regionGuid;
        }
        private readonly string _name;
        public string Name => _name;
        private readonly Guid _regionGuid;
        public Guid RegionGuid => _regionGuid;
        public virtual Region Region { get; }
        private ICollection<Participant> _participants;
        public IReadOnlyCollection<Participant> Participants => _participants.ToList();
        public void AddParticipant() 
        {

        }
    }
}
