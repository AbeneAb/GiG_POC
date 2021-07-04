using MediatR;
using Odds.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odds.Application.Features.Selection.Query
{
    public class GetSelectionListQuery : IRequest<List<SelectionVm>>
    { 
    }
}
