using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odds.Client.Models
{
    public class CompetitionModel
    {
        public string Name { get;  set; }
        public Guid RegionId { get;  set; }
        public List<ParticipantModel> Participants { get; set; }
        public List<EventModel> Events { get; set; }
    }
}
