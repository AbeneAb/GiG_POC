using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odds.Application.Features.Selection.Command
{
    public class DeleteSelectionCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
