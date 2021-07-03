using Odds.Application.Features;
using Odds.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odds.Application.ViewModels
{
    public class ParticipantDetailVm : BaseViewModel<ParticipantDetail>
    {
        public int Index { get; private set; }
        public string Description { get; private set; }
        public string Participant { get; private set; }
        public Guid EventId { get; set; }
        public String EventName { get; set; }
        public ParticipantDetailVm(ParticipantDetail participantDetail) : base(participantDetail)
        {
            Index = participantDetail.Index;
            Description = participantDetail.Description;
            Participant = participantDetail.Participant?.Name;
            EventId = participantDetail.eventGuid;
            EventName = participantDetail.Event?.Label;
        }
    }
}
