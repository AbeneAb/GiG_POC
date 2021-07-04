using MediatR;
using Odds.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Odds.Application.Features.Market.Command
{
    public class UpdateMarketCommandHandler : IRequestHandler<UpdateMarketCommand>
    {
        private readonly IMarketRepository _marketRepository;
        public UpdateMarketCommandHandler(IMarketRepository marketRepository)
        {
            _marketRepository = marketRepository;
        }
        public async Task<Unit> Handle(UpdateMarketCommand request, CancellationToken cancellationToken)
        {
            var market = await _marketRepository.GetByIdAsync(request.Id);
            market.UpdateMarket(request.EventId, request.MarketStatus, request.Label, request.DeadLine, null);
            await _marketRepository.UpdateAsync(market);
            return Unit.Value;
        }
    }
}
