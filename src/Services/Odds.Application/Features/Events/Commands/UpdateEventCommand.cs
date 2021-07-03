using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odds.Application.Features.Events.Commands
{
    public class UpdateEventCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid CategoryGuid { get; set; }
        public int EventStatus { get; set; }
        public DateTime StartTime { get; set; }
        public Guid CompetitionGuid { get; set; }
        public string Label { get; set; }
        public List<ParticipantDetailCommandUpdate> ParticipantDetails { get; set; }
        public List<MarketCommandUpdate> MarketCommands { get; set; }

    }

    public class ParticipantDetailCommandUpdate
    {
        public Guid Id { get; set; }
        public Guid ParticipantId { get; set; }
        public int Index { get; set; }
        public string Description { get; set; }
    }
    public class MarketCommandUpdate
    {
        public Guid Id { get; set; }
        public int MarketStatus { get; set; }
        public DateTime Deadline { get; set; }
        public Guid? MarketTemplate { get; set; }
        public string Label { get; set; }
        public List<SelectionCommandUpdate> Selections { get; set; }

    }
    public class SelectionCommandUpdate
    {
        public Guid Id { get; set; }
        public decimal odd { get; set; }
        public int status { get; set; }
        public int index { get; set; }
        public string participantLabel { get; set; }
    }

}
