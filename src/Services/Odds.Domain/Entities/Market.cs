using Odds.Domain.Seed;
using System;
using System.Collections.Generic;
using System.Text;

namespace Odds.Domain.Entities
{
    public class Market : EntityBase
    {
        private readonly Guid _eventGuid;
        public Guid EventGuid => _eventGuid;
        private readonly decimal _odds;
        public decimal Odds => _odds;
        private readonly Guid _participantGuid;
        public Guid ParticipantGuid => _participantGuid;
        public virtual Participant Participant { get; }
        private readonly string _label;
        public string Label => _label;
        public MarketStatus MarketStatus { get; private set; }
        private readonly DateTime _endDateTime;
        public DateTime EndDateTime => _endDateTime;
        private readonly Guid _marketTemplate;
        public Guid MarketTemplateGuid => _marketTemplate;
        public virtual MarketTemplate MarketTemplate { get; }
        private 

        protected Market()
        {

        }
        
        public Market(Guid eventGuid, decimal odds, Guid participantGuid, DateTime endDateTime,Guid marketTemplate) : base()
        {
            _eventGuid = eventGuid;
            _odds = odds;
            _participantGuid = participantGuid;
            _endDateTime = endDateTime;
            _marketTemplate = marketTemplate;
        }
        public string GetMarketTemplateName() => MarketTemplate?.FriendlyName;
        public string GetMarketLabel() => Participant?.Name;
    }
}
