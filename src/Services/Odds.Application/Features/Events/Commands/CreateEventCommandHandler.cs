using MediatR;
using Microsoft.Extensions.Logging;
using Odds.Domain.Interfaces;
using Odds.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Odds.Application.Features.Events.Commands
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
    {
        private readonly IEventRepository _eventRepository;
        private readonly ILogger<CreateEventCommandHandler> _logger;
        public CreateEventCommandHandler(IEventRepository eventRepository, ILogger<CreateEventCommandHandler> logger)
        {
            _eventRepository = eventRepository ?? throw new ArgumentNullException(nameof(eventRepository)); 
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var @event = new Event(request.CategoryGuid, request.StartTime,request.CompetitionGuid,request.Label,request.EventStatus);
            if(request.MarketCommands != null && request.MarketCommands.Count > 0) {
                foreach (var market in request.MarketCommands) {
                    var marketEntity = new Domain.Entities.Market(market.MarketStatus, market.Deadline, market.Label, market.MarketTemplate);
                    if(market.Selections != null && market.Selections.Count > 0) { 
                        foreach(var selection in market.Selections) {
                            var selectionEntity = new Domain.Entities.Selection(selection.odd, selection.index, selection.participantLabel, selection.status);
                            marketEntity.AddSelection(selectionEntity);
                        }
                    }
                    @event.AddMarkets(marketEntity);
                }
            }
            if(request.ParticipantDetails != null && request.ParticipantDetails.Count > 0) { 
                foreach(var participant in request.ParticipantDetails) {
                    var participantDetailEntity = new ParticipantDetail(participant.ParticipantId,participant.Index, participant.Description);
                    @event.AddParticipants(participantDetailEntity);
                }
            }
            await _eventRepository.AddAsync(@event);
            return @event.Id;
        }
    }
}
