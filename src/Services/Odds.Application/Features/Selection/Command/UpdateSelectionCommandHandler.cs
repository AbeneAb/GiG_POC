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
        public UpdateSelectionCommandHandler(ISelectionRepository selectionRepository)
        {
            _selectionRepository = selectionRepository;
        }

        public async Task<Unit> Handle(UpdateSelectionCommand request, CancellationToken cancellationToken)
        {
            var selection = await _selectionRepository.GetByIdAsync(request.Id);
            selection.UpdateSelection(request.MarketGuid, request.Odds, request.Index, request.Label, request.Status);
            await _selectionRepository.UpdateAsync(selection);
            return Unit.Value;
        }
    }
}
