using Odds.Domain.Seed;
using System;
using System.Collections.Generic;
using System.Text;

namespace Odds.Domain.Entities
{
    public class Participant : EntityBase
    {
        private readonly string _name;
        public string Name => _name;
        public virtual IReadOnlyCollection<ParticipantDetail> ParticipantDetails { get; private set; }
        protected Participant() 
        {
        }
        public Participant(string name) 
        {
            _name = name;
        }

    }
}
