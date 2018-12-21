using LabFlow.Domain.Core.Commands;
using System;

namespace LabFlow.Domain.Protocol.Commands
{
    public abstract class TigerCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }
    }
}
