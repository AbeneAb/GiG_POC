using MediatR;
using Odds.Domain.Entities;
using Odds.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using EventBus.Messages.Events;

namespace Odds.Application.Features.Selection.Command
{
    public class CreateSelectionCommandHandler : IRequestHandler<CreateSelectionCommand,Guid>
    {
        private readonly ISelectionRepository _selectionRepository;
        private readonly IPublishEndpoint _publishEndpoint;
        public CreateSelectionCommandHandler(ISelectionRepository selectionRepository,IPublishEndpoint publisher)
        {
            _selectionRepository = selectionRepository;
            _publishEndpoint = publisher;
        }

        public async Task<Guid> Handle(CreateSelectionCommand request, CancellationToken cancellationToken)
        {
            var selection = new Domain.Entities.Selection(request.MarketGuid,request.Odds, request.Index, request.Label, request.Status);
            var result = await _selectionRepository.AddAsync(selection);
            SelectionCreatedEvent @event = new SelectionCreatedEvent(result.Id,DateTime.UtcNow,result.Odds, result.MarketGuid,result.Index,result.SelectionStatusId, result.ParticipantLabel);   
            await _publishEndpoint.Publish(@event);
            return result.Id;
        }
    }
}
