using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odds.Client.Models
{
    public class ParticipantModel
    {
        public int Index { get; private set; }
        public string Description { get; set; }
        public string Participant { get; set; }
        public Guid EventId { get; set; }
        public string EventName { get; set; }
    }
}
