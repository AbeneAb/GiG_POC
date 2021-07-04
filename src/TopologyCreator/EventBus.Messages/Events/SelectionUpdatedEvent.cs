using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Messages.Events
{
    public class SelectionUpdatedEvent : BaseEvent
    {
        public decimal Odds { get; set; }
        public Guid MarketGuid { get; set; }
        public int Index { get; set; }
        public int Status { get; set; }
        public string Label { get; set; }
    }
}
