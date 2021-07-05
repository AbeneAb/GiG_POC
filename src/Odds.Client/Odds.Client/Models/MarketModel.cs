using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odds.Client.Models
{
    public class MarketModel
    {
        public string MarketStatus { get; set; }
        public string Label { get; set; }
        public DateTime DeadLine { get; set; }
        public Guid EventId { get; set; }
        public List<SelectionModel> Selections { get; set; }
    }
}
