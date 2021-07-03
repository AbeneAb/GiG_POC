using Odds.Application.Features;
using Odds.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odds.Application.ViewModels
{
    public class EventsVm : BaseViewModel<Event>
    {
        public string Label { get; private set; }
        public DateTime StartDate { get; private set; }
        public string EventStatus { get; private set; }
        public string Competition { get; private set; }
        public string Category { get; private set; }
        public List<ParticipantDetailVm> ParticipantDetails { get; private set; }
        public List<MarketVm> Market { get; private set; }
        public EventsVm(Event @event):base(@event)
        {
            Label = @event.Label;
            StartDate = @event.StartDateTime;
            EventStatus = @event.EventStatus.Name;
            Competition = @event.Competition?.Name;
            Category = @event.Category?.Name;
            ParticipantDetails = @event.Participants?.Select(p => new ParticipantDetailVm(p)).ToList();
            Market = @event.Markets?.Select(m => new MarketVm(m)).ToList();
        }
    }
}
