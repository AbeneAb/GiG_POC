using MediatR;
using Odds.Domain.Entities;
using Odds.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Odds.Application.Features.Region.Command
{
    public class CreateRegionCommandHandler : IRequestHandler<CreateRegionCommand,Guid>
    {
        private readonly IRegionRepository _regionRepository;
        public CreateRegionCommandHandler(IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;
        }

        public async Task<Guid> Handle(CreateRegionCommand request, CancellationToken cancellationToken)
        {
            var region = new Domain.Entities.Region(request.Name);
            if(request.Competitions != null && region.Competitions.Count > 0) {  
                foreach(var comp in request.Competitions) {
                    var competition = new Competition(comp.Name);
                    if(comp.Participants != null && comp.Participants.Count > 0) {  
                        foreach(var participant in comp.Participants) {
                            competition.AddParticipant(participant.Name);
                        }
                    }
                    region.AddCompetition(competition);
                }
            }
            await _regionRepository.AddAsync(region);
            return region.Id;
        }
    }
}
