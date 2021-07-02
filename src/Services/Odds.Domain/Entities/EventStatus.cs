using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Odds.Domain.Seed;
using Odds.Domain.Exceptions;

namespace Odds.Domain.Entities
{
    public class EventStatus : Enumeration
    {
        public static EventStatus PreMatch = new EventStatus(1, nameof(PreMatch).ToLowerInvariant());
        public static EventStatus Live = new EventStatus(2, nameof(Live).ToLowerInvariant());
        public static EventStatus PostMatch = new EventStatus(3, nameof(PostMatch).ToLowerInvariant());
        public static EventStatus Canceled = new EventStatus(4, nameof(Canceled).ToLowerInvariant());
        public static EventStatus Postphoned = new EventStatus(5, nameof(Postphoned).ToLowerInvariant());
        public EventStatus(int id, string name):base(name,id)
        {
            
        }
        public static IEnumerable<EventStatus> List() => new[] { PreMatch, Live, PostMatch, Canceled, Postphoned };
        public static EventStatus FromName(string name) 
        {
            var status = List().SingleOrDefault(x => String.Equals(x.Name, name, StringComparison.CurrentCultureIgnoreCase));
            if(status == null) 
            {
                throw new DomainException($"Status {name} not found!");
            }
            return status;
        }
        public static EventStatus FromId(int id) 
        {
            var status = List().SingleOrDefault(x => x.Id == id);
            if(status == null) 
            {
                throw new Exception();
            }
            return status;
        }
    }
}
