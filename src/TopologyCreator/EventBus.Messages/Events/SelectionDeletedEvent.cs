using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Messages.Events
{
    public class SelectionDeletedEvent : BaseEvent
    {
        public SelectionDeletedEvent(Guid Id, DateTime dateTime):base(Id,dateTime)
        {

        }
    }
}
