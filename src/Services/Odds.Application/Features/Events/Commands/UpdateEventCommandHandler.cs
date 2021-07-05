using MediatR;
using Odds.Domain.Entities;
using Odds.Domain.Exceptions;
using Odds.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Odds.Application.Features.Events.Commands
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand>
    {
        private readonly IEventRepository _eventRepository;
        public UpdateEventCommandHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public async Task<Unit> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var eventToUpdate = await _eventRepository.GetByIdAsync(request.Id);
            if(eventToUpdate == null) 
            {
                throw new NotFoundException(nameof(Event), request.Id);
            }
            eventToUpdate.UpdateEvent(request.CategoryGuid, request.StartTime, request.CompetitionGuid, request.Label, request.EventStatus);
            if (request.MarketCommands != null && request.MarketCommands.Count > 0)
            {
                foreach (var market in request.MarketCommands)
                {
                    var marketEntity = new Domain.Entities.Market(market.MarketStatus, market.Deadline, market.Label, market.MarketTemplate);
                    eventToUpdate.AddMarkets(marketEntity);
                    if (market.Selections != null && market.Selections.Count > 0)
                    {
                        foreach (var selection in market.Selections)
                        {
                            var selectionEntity = new Odds.Domain.Entities.Selection(selection.odd, selection.index, selection.participantLabel, selection.status);
                            marketEntity.AddSelection(selectionEntity);
                        }
                    }
                }
            }
            if (request.ParticipantDetails != null && request.ParticipantDetails.Count > 0)
            {
                foreach (var participant in request.ParticipantDetails)
                {
                    var participantDetailEntity = new ParticipantDetail(participant.ParticipantId, participant.Index, participant.Description);
                    eventToUpdate.AddParticipants(participantDetailEntity);
                }
            }
            await _eventRepository.UpdateAsync(eventToUpdate);
            return Unit.Value;
        }
    }
}
