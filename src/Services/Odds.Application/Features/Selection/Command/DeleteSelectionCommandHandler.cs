using MediatR;
using Microsoft.Extensions.Logging;
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
    public class DeleteSelectionCommandHandler : IRequestHandler<DeleteSelectionCommand, Unit>
    {
        private readonly ISelectionRepository _selectionRepository;
        private readonly ILogger<DeleteSelectionCommand> _logger;
        public DeleteSelectionCommandHandler(ISelectionRepository selectionRepository, ILogger<DeleteSelectionCommand> logger)
        {
            _selectionRepository = selectionRepository;
            _logger = logger;
        }
        public async Task<Unit> Handle(DeleteSelectionCommand request, CancellationToken cancellationToken)
        {
            var selection = await _selectionRepository.GetByIdAsync(request.Id);
            if (selection == null) 
            {
                throw new NotFoundException(nameof(DeleteSelectionCommand), request.Id);
            }
            _logger.LogInformation($"Selection {request.Id} is successfully Deleted.");
            return Unit.Value;
        }
    }
}
