using MediatR;
using Odds.Application.ViewModels;
using Odds.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Odds.Application.Features.Region.Query
{
    public class GetRegionListQueryHandler : IRequestHandler<GetRegionListQuery, List<RegionVm>>
    {
        private readonly IRegionRepository _regionRepository;
        public GetRegionListQueryHandler(IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;
        }
        public async Task<List<RegionVm>> Handle(GetRegionListQuery request, CancellationToken cancellationToken)
        {
            var region = await _regionRepository.GetAllAsync();
            return region.Select(x => new RegionVm(x)).ToList();
        }
    }
}
