using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odds.Application.Features.Selection.Command
{
    public class UpdateSelectionCommand : IRequest
    {
        public Guid Id { get; set; }
        public decimal Odds { get; set; }
        public Guid MarketGuid { get; set; }
        public int Index { get; set; }
        public int Status { get; set; }
        public string Label { get; set; }
    }
}
