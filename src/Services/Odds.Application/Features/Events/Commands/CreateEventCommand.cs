using System;
using System.Collections.Generic;
using MediatR;

namespace Odds.Application.Features.Events.Commands
{
    public class CreateEventCommand : IRequest<Guid>
    {
        public Guid CategoryGuid { get; set; }
        public int EventStatus { get; set; }
        public DateTime StartTime { get; set; }
        public Guid CompetitionGuid { get; set; }
        public string Label { get; set; }
        public List<ParticipantDetailCommand> ParticipantDetails { get; set; }
        public List<MarketCommand> MarketCommands { get; set; }
        

    }
    public class ParticipantDetailCommand
    {
        public Guid ParticipantId { get; set; }
        public int Index { get; set; }
        public string Description { get; set; }
    }
    public class MarketCommand
    {
        public int MarketStatus { get; set; }
        public DateTime Deadline { get; set; }
        public Guid? MarketTemplate { get; set; }
        public string Label { get; set; }
        public List<SelectionCommand> Selections { get; set; }

    }
    public class SelectionCommand
    {
        public decimal odd { get; set; }
        public int status { get; set; }
        public int index { get; set; }
        public string participantLabel { get; set; }
    }

}
