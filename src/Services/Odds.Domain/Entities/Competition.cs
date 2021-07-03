using Odds.Domain.Exceptions;
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
            _participants = new HashSet<Participant>();
            _events = new HashSet<Event>();
        }
        public Competition(string name) : this()
        {
            _name = name;
        }
        private readonly string _name;
        public string Name => _name;
        private readonly Guid _regionGuid;
        public Guid RegionGuid => _regionGuid;
        public virtual Region Region { get; }
        private ICollection<Participant> _participants;
        public IReadOnlyCollection<Participant> Participants => _participants.ToList();
        private ICollection<Event> _events;
        public IReadOnlyCollection<Event> Events => _events?.ToList();
        public void AddParticipant(string name)
        {
            var exists = _participants.Where(x => x.Name == name).SingleOrDefault();
            if (exists != null)
            {
                throw new DomainException($"Participant {name} has been added!");
            }
            var paricipant = new Participant(name);
            _participants.Add(paricipant);
        }
    }
}
