using MediatR;
using Odds.Application.ViewModels;
using Odds.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace Odds.Application.Features.Category.Query
{
    public class GetCategoryListQueryHandler : IRequestHandler<GetCategoryListQuery, List<CategoryVm>>
    {
        private readonly ICategoryRepository _categoryRepository;
        public GetCategoryListQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<List<CategoryVm>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Domain.Entities.Category> categories = await _categoryRepository.GetAllCategories();
            return categories.Select(c => new CategoryVm(c)).ToList();
        }
    }
}
