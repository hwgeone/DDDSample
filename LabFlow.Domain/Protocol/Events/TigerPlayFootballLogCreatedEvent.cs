using LabFlow.Domain.Core.Events;
using System;

namespace LabFlow.Domain.Protocol.Events
{
    public class TigerPlayFootballLogCreatedEvent : Event
    {
        public TigerPlayFootballLogCreatedEvent(Guid id, Guid tigerid,Guid footballid)
        {
            Id = id;
            TigerId = tigerid;
            FootballId = footballid;
            AggregateId = id;
        }
        public Guid Id { get; set; }

        public Guid TigerId { get; set; }

        public Guid FootballId { get; private set; }
    }
}
