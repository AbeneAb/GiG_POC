using MediatR;
using Odds.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;
using EventBus.Messages.Events;
using EventBus.Messages.Interface;

namespace Odds.Application.Features.Selection.Command
{
    public class CreateSelectionCommandHandler : IRequestHandler<CreateSelectionCommand,Guid>
    {
        private readonly ISelectionRepository _selectionRepository;
        private readonly ISelectionUpdateSender _publishEndpoint;
        public CreateSelectionCommandHandler(ISelectionRepository selectionRepository, ISelectionUpdateSender publisher)
        {
            _selectionRepository = selectionRepository;
            _publishEndpoint = publisher;
        }

        public async Task<Guid> Handle(CreateSelectionCommand request, CancellationToken cancellationToken)
        {
            var selection = new Domain.Entities.Selection(request.MarketGuid,request.Odds, request.Index, request.Label, request.Status);
            var result = await _selectionRepository.AddAsync(selection);
            SelectionEvent @event = new SelectionEvent(result.Id,DateTime.UtcNow,result.Odds, result.MarketGuid,result.Index,result.SelectionStatusId, result.ParticipantLabel);   
            _publishEndpoint.SendSelection(@event);
            return result.Id;
        }
    }
}
