using MediatR;
using Odds.Domain.Entities;
using Odds.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Odds.Application.Features.Selection.Command
{
    public class CreateSelectionCommandHandler : IRequestHandler<CreateSelectionCommand,Guid>
    {
        private readonly ISelectionRepository _selectionRepository;
        public CreateSelectionCommandHandler(ISelectionRepository selectionRepository)
        {
            _selectionRepository = selectionRepository;
        }

        public async Task<Guid> Handle(CreateSelectionCommand request, CancellationToken cancellationToken)
        {
            var selection = new Domain.Entities.Selection(request.MarketGuid,request.Odds, request.Index, request.Label, request.Status);
            var result = await _selectionRepository.AddAsync(selection);
            return result.Id;
        }
    }
}
