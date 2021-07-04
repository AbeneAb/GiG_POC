using MediatR;
using Odds.Domain.Exceptions;
using Odds.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Odds.Application.Features.Market.Command
{
    public class DeleteMarketCommandHandler : IRequestHandler<DeleteMarketCommand>
    {
        private readonly IMarketRepository _marketRepo;
        public DeleteMarketCommandHandler(IMarketRepository selectionRepository)
        {
            _marketRepo = selectionRepository;
        }
        public async Task<Unit> Handle(DeleteMarketCommand request, CancellationToken cancellationToken)
        {
            var market = await _marketRepo.GetByIdAsync(request.Id);
            if (market == null)
            {
                throw new NotFoundException(nameof(DeleteMarketCommandHandler), request.Id);
            }
            return Unit.Value;
        }
    }
}
