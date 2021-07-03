using MediatR;
using Odds.Application.Features.Events.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odds.Application.Features.Region.Command
{
    public class CreateRegionCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public List<CompetitionCommand> Competitions { get; set; }
    }
    public class CompetitionCommand
    {
        public string Name { get; init; }
        public List<ParticipantCommand> Participants { get; set; }
    }
    public class ParticipantCommand
    {
        public string Name { get; init; }
    }

}
