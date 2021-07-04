using Odds.Domain.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Odds.Domain.Entities
{
    public class Market : EntityBase
    {
        private  Guid _eventGuid;
        public Guid EventGuid => _eventGuid;
        public virtual Event Event { get; private set; }
        private  int _marketStatusId;
        public int MarketStatusId => _marketStatusId;
        private  string _label;
        public string Label => _label;//Match Result or Total Goals
        public MarketStatus MarketStatus { get; private set; }
        private  DateTime _endDateTime;
        public DateTime EndDateTime => _endDateTime;
        private  Guid? _marketTemplate;

        public void UpdateMarket(Guid eventGuid, int marketStatus, string label, DateTime endDate, Guid?  template)
        {
            _eventGuid = eventGuid;
            _marketStatusId = marketStatus;
            _label = label;
            _endDateTime = endDate;
            _marketTemplate = template;
        }

        public Guid? MarketTemplateGuid => _marketTemplate;
        public virtual MarketTemplate MarketTemplate { get; }
        private readonly ICollection<Selection> _selections;
        public virtual List<Selection> Selection { get; set; }

        protected Market()
        {
            _selections = new HashSet<Selection>();
        }

        public Market(int marketStatus, DateTime endDateTime, string label, Guid? marketTemplate) : this()
        {
            _endDateTime = endDateTime;
            _marketTemplate = marketTemplate;
            _marketStatusId = marketStatus;
            _label = label;
        }
        public Market(Guid eventStatus,int marketStatus, DateTime endDate,string label,Guid? marketTemplate) : this(marketStatus, endDate, label, marketTemplate) 
        {
            _eventGuid = eventStatus;
        }
        public string GetMarketTemplateName() => MarketTemplate?.FriendlyName;
        public void AddSelection(Selection selection) 
        {
            _selections.Add(selection);
        }

        
    }
}
