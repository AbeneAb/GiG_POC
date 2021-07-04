﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odds.Application.Features.Market.Command
{
    public class CreateMarketCommand : IRequest<Guid>
    {
        public int MarketStatus { get; set; }
        public string Label { get; set; }
        public DateTime DeadLine { get; set; }
        public Guid EventId { get; set; }
    }
}

