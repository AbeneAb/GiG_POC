using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odds.Client.Models
{
    public class EventModel
    {
        public string Label { get; set; }
        public DateTime StartDate { get; set; }
        public string EventStatus { get; set; }
        public string Competition { get; set; }
        public string Category { get; set; }
        public List<MarketModel> Market { get; set; }
        public List<ParticipantModel> ParticipantDetails { get; set; }
    }
}
