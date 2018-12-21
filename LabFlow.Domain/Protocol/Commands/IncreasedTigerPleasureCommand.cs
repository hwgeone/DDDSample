using LabFlow.Domain.Core.Commands;
using System;

namespace LabFlow.Domain.Protocol.Commands
{
    public class IncreaseTigerPleasureCommand : Command
    {
        public Guid TigerId { get; set; }
        public int PleasureAdd { get; set; }
        public IncreaseTigerPleasureCommand(Guid tigerId, int pleasureAdd)
        {
            TigerId = tigerId;
            PleasureAdd = pleasureAdd;
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}