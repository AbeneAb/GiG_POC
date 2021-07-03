using Odds.Domain.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Odds.Domain.Entities
{
    public class Market : EntityBase
    {
        private readonly Guid _eventGuid;
        public Guid EventGuid => _eventGuid;
        public virtual Event Event { get; private set; }
        private readonly int _marketStatusId;
        public int MarketStatusId => _marketStatusId;
        private readonly string _label;
        public string Label => _label;//Match Result or Total Goals
        public MarketStatus MarketStatus { get; private set; }
        private readonly DateTime _endDateTime;
        public DateTime EndDateTime => _endDateTime;
        private readonly Guid? _marketTemplate;
        public Guid? MarketTemplateGuid => _marketTemplate;
        public virtual MarketTemplate MarketTemplate { get; }
        private readonly ICollection<Selection> _selections;
        public IReadOnlyCollection<Selection> Selection => _selections.ToList();

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
        public string GetMarketTemplateName() => MarketTemplate?.FriendlyName;
        public void AddSelection(Selection selection) 
        {
            _selections.Add(selection);
        }

        
    }
}
