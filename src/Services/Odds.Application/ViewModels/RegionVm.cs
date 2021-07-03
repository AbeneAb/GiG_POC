using Odds.Application.Features;
using Odds.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Odds.Application.ViewModels
{
    public class RegionVm : BaseViewModel<Region>
    {
        public string Name { get; private set; }
        public List<CompetitionVm> Competitions { get; private set; }
        public RegionVm(Region region):base(region)
        {
            Name = region.Name;
            Competitions = region.Competitions?.Select(c => new CompetitionVm(c)).ToList();
        }

    }
}
