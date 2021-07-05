using EventBus.Messages.Events;
using EventBus.Messages.Interface;
using MediatR;
using Odds.Domain.Exceptions;
using Odds.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Odds.Application.Features.Selection.Command
{
    public class UpdateSelectionCommandHandler : IRequestHandler<UpdateSelectionCommand>
    {
        private readonly ISelectionRepository _selectionRepository;
        private readonly ISelectionUpdateSender _publishEndpoint;

        public UpdateSelectionCommandHandler(ISelectionRepository selectionRepository,ISelectionUpdateSender selectionUpdateSender)
        {
            _selectionRepository = selectionRepository;
            _publishEndpoint = selectionUpdateSender;
        }

        public async Task<Unit> Handle(UpdateSelectionCommand request, CancellationToken cancellationToken)
        {
            var selection = await _selectionRepository.GetSelection(request.Id);
            selection.UpdateSelection(request.MarketGuid, request.Odds, request.Index, request.Label, request.Status);
            await _selectionRepository.UpdateAsync(selection);
            SelectionEvent @event = new SelectionEvent(selection.Id, DateTime.UtcNow, selection.Odds, selection.MarketGuid, selection.Index, selection.SelectionStatusId, selection.ParticipantLabel);
            _publishEndpoint.SendSelection(@event);
            return Unit.Value;
        }
    }
}
