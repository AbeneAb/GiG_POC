using System;

namespace EventBus.Messages.Events
{
    public class BaseEvent
    {
        public Guid Id { get; private set; }
        public DateTime CreationDate { get; private set; }
        public BaseEvent()
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.UtcNow;
        }
        public BaseEvent(Guid guid, DateTime dateTime)
        {
            Id = guid;
            CreationDate = dateTime;
        }
    }
}
