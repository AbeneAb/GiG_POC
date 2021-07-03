using Odds.Application.Features;
using Odds.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odds.Application.ViewModels
{
    public class CompetitionVm : BaseViewModel<Competition>
    {
        public string Name { get; private set; }
        public Guid RegionId { get; private set; }
        public List<ParticipantVm> participantVms { get; private set; }
        public List<EventsVm> Events { get; private set; }

        public CompetitionVm(Competition competition):base(competition)
        {
            Name = competition.Name;
            RegionId = competition.RegionGuid;
            participantVms = competition.Participants?.Select(p => new ParticipantVm(p)).ToList();
            Events = competition.Events?.Select(e => new EventsVm(e)).ToList();
        }
    }
}
