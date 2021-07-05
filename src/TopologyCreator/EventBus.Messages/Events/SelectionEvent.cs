using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Messages.Events
{
    public class SelectionEvent : BaseEvent
    {
        public decimal Odds { get; private set; }
        public Guid MarketGuid { get; private set; }
        public int Index { get; private set; }
        public int Status { get; private set; }
        public string Label { get; private set; }
        public SelectionEvent(Guid id, DateTime timeStamp, decimal odd, Guid marketGuid, int index, int status, string label) : base(id, timeStamp)
        {
            Odds = odd;
            MarketGuid = marketGuid;
            Index = index;
            Status = status;
            Label = label;
        }
    }
}
