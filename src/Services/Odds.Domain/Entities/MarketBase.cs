namespace Odds.Domain.Entities
{
    public class MarketBase
    {
        private readonly decimal _odds;
        private readonly Guid _participantGuid;
        private readonly string _label;
        private readonly DateTime _endDateTime;
        private readonly Guid _marketTemplate;
    }
}