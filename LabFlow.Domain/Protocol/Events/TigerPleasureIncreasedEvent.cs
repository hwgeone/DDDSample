using LabFlow.Domain.Core.Events;
using System;

namespace LabFlow.Domain.Protocol.Events
{
    public class TigerPleasureIncreasedEvent : Event
    {
        public TigerPleasureIncreasedEvent(Guid id, int pleasure)
        {
            Id = id;
            Pleasure = pleasure;
            AggregateId = id;
        }
        public Guid Id { get; set; }

        public int Pleasure { get; private set; }
    }
}
