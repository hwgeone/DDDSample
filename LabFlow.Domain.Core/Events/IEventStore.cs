using System;
using System.Collections.Generic;
using System.Text;

namespace LabFlow.Domain.Core.Events
{
    public interface IEventStore
    {
        void Save<T>(T theEvent) where T : Event;
    }
}
