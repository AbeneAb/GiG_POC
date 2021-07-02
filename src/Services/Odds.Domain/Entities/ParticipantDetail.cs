using Odds.Domain.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odds.Domain.Entities
{
    public class ParticipantDetail : EntityBase
    {
        private readonly Guid _participantGuid;
        public Guid ParticipantGuid => _participantGuid;
        public virtual Participant Participant { get; }
        private readonly int _index;
        public int Index => _index;
        private readonly string _description;
        public string Description => _description;
        protected ParticipantDetail() 
        { 
        }
        public ParticipantDetail(Guid participantGuid, int index,string description)
        {
            _participantGuid = participantGuid;
            _index = index;
            _description = description;
        }

    }
}
