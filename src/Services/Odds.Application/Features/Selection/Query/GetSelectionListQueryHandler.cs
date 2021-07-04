using MediatR;
using Odds.Application.ViewModels;
using Odds.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Odds.Application.Features.Selection.Query
{
    public class GetSelectionListQueryHandler : IRequestHandler<GetSelectionListQuery, List<SelectionVm>>
    {
        private readonly ISelectionRepository _selectionRepository;
        public GetSelectionListQueryHandler(ISelectionRepository selectionRepository)
        {
            _selectionRepository = selectionRepository;
        }
        public async Task<List<SelectionVm>> Handle(GetSelectionListQuery request, CancellationToken cancellationToken)
        {
            var selection = await _selectionRepository.GetAllSelection();
            return selection?.Select(x => new SelectionVm(x)).ToList();
        }
    }
}
