using Odds.Application.Features;
using Odds.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odds.Application.ViewModels
{
    public class MarketVm : BaseViewModel<Market>
    {
        public string MarketStatus { get; set; }
        public string Label { get; set; }
        public DateTime DeadLine { get; set; }
        public Guid EventId { get; set; }
        public List<SelectionVm> Selections { get; set; } 

        public MarketVm(Market market) :base(market)
        {
            MarketStatus = market.MarketStatus.Name;
            Label = market.Label;
            DeadLine = market.EndDateTime;
            EventId = market.EventGuid;
            Selections = market.Selection?.Select(s => new SelectionVm(s)).ToList();
        }
    }
}
