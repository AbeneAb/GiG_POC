using Odds.Domain.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Odds.Domain.Entities
{
    public class Event : EntityBase
    {
        private readonly Guid _categoryGuid;
        public Guid CategoryGUID => _categoryGuid;
        private Category _category;
        public virtual Category Category => _category;
        private int _eventStatusId;
        public EventStatus EventStatus { get; private set; }
        private readonly ICollection<ParticipantDetail> _participants;
        public IReadOnlyCollection<ParticipantDetail> Participants => _participants.ToList();
        private readonly ICollection<Market> _markets;
        public IReadOnlyCollection<Market> Markets => _markets.ToList();
        private readonly DateTime _startTime;
        public DateTime StartDateTime => _startTime;
        private readonly Guid _competitionGuid;
        public Guid competitionGuid => _competitionGuid;
        private Competition _competition;
        public virtual Competition Competition => _competition;

        private readonly string _label;
        public string Label => _label;

        protected Event() 
        {
            _participants = new HashSet<ParticipantDetail>();
            _markets = new HashSet<Market>();
        }
        public Event(Guid category, DateTime startDate, Guid competitionGuid, string label,int status) : this() 
        {
            _categoryGuid = category;
            _startTime = startDate;
            _competitionGuid = competitionGuid;
            _label = label;
            _eventStatusId = status == 0 ? EventStatus.PreMatch.Id: status;
        }
        public void AddMarkets(Market market) 
        {
            _markets.Add(market);
        }
        public void AddParticipants(ParticipantDetail participant) 
        {
            _participants.Add(participant);
        }

    }
}
