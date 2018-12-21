using LabFlow.Domain.Core.Commands;
using System;

namespace LabFlow.Domain.Protocol.Commands
{
    public class ReduceFootballLossCommand : Command
    {
        public Guid FootballId { get; set; }
        public int LossReduce { get; set; }
        public ReduceFootballLossCommand(Guid footballId, int lossreduce)
        {
            FootballId = footballId;
            LossReduce = lossreduce;
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}
