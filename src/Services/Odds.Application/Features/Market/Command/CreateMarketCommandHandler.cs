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
    public class CreateMarketCommandHandler : IRequestHandler<CreateMarketCommand, Guid>
    {
        private readonly IMarketRepository _marketRepository;
        public CreateMarketCommandHandler(IMarketRepository repository)
        {
            _marketRepository = repository;
        }
        public async Task<Guid> Handle(CreateMarketCommand request, CancellationToken cancellationToken)
        {
            var market = new Domain.Entities.Market(request.EventId,request.MarketStatus, request.DeadLine,request.Label, null);
            await _marketRepository.AddAsync(market);
            return market.Id;
        }
    }
}
