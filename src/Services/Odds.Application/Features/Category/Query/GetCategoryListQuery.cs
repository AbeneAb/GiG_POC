using MediatR;
using Odds.Application.ViewModels;
using System.Collections.Generic;

namespace Odds.Application.Features.Category.Query
{
    public class GetCategoryListQuery : IRequest<List<CategoryVm>>
    {
        public GetCategoryListQuery()
        {

        }
    }
}
