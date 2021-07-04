using MediatR;
using Odds.Application.ViewModels;
using Odds.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Odds.Application.Features.Market.Query
{
    public class GetMarketListQueryHandler : IRequestHandler<GetMarketListQuery,List<MarketVm>>
    {
        private readonly IMarketRepository _marketRepository;
        public GetMarketListQueryHandler(IMarketRepository marketRepo)
        {
            _marketRepository = marketRepo;
        }

        public async Task<List<MarketVm>> Handle(GetMarketListQuery request, CancellationToken cancellationToken)
        {
            var market = await _marketRepository.GetAllMarkets();
            return market?.Select(x => new MarketVm(x)).ToList();

        }
    }
}
