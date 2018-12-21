using LabFlow.Domain.Core.Events;
using System;

namespace LabFlow.Domain.Protocol.Events
{
    public class TigerRegisteredEvent : Event
    {
        public TigerRegisteredEvent(Guid id, string name)
        {
            Id = id;
            Name = name;
            AggregateId = id;
        }
        public Guid Id { get; set; }

        public string Name { get; private set; }
    }
}
