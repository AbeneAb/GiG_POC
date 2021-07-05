using EventBus.Messages.Events;
using EventBus.Messages.Interface;
using MediatR;
using Microsoft.Extensions.Logging;
using Odds.Domain.Exceptions;
using Odds.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Odds.Application.Features.Selection.Command
{
    public class DeleteSelectionCommandHandler : IRequestHandler<DeleteSelectionCommand, Unit>
    {
        private readonly ISelectionRepository _selectionRepository;
        private readonly ILogger<DeleteSelectionCommand> _logger;
        private readonly ISelectionUpdateSender _publishEndpoint;
        public DeleteSelectionCommandHandler(ISelectionRepository selectionRepository, ISelectionUpdateSender publisher, ILogger<DeleteSelectionCommand> logger)
        {
            _selectionRepository = selectionRepository;
            _logger = logger;
            _publishEndpoint = publisher;
        }
        public async Task<Unit> Handle(DeleteSelectionCommand request, CancellationToken cancellationToken)
        {
            var selection = await _selectionRepository.GetByIdAsync(request.Id);
            if (selection == null) 
            {
                throw new NotFoundException(nameof(DeleteSelectionCommand), request.Id);
            }
            _logger.LogInformation($"Selection {request.Id} is successfully Deleted.");
            SelectionEvent @event = new SelectionEvent(selection.Id,selection.CreatedDate, selection.Odds,selection.MarketGuid,selection.Index, selection.SelectionStatus.Id
                ,selection.ParticipantLabel);
            _publishEndpoint.SendSelection(@event);

            return Unit.Value;
        }
    }
}
