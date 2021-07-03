using Odds.Application.Features;
using Odds.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Odds.Application.ViewModels
{
    public class CategoryVm : BaseViewModel<Category>
    {
        public string Name { get; private set; }
        public List<RegionVm> Region { get; private set; }
        public CategoryVm(Category category): base(category)
        {
            Name = category.Name;
            Region = category.Regions?.Select(r => new RegionVm(r)).ToList();
        }
    }
}
