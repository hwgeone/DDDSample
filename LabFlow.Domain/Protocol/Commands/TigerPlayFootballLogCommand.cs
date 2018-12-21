using LabFlow.Domain.Core.Commands;
using System;

namespace LabFlow.Domain.Protocol.Commands
{
    public class CreateTigerPlayFootballLogCommand : Command
    {
        public Guid TigerId { get; set; }
        public Guid FootballId { get; set; }
        public CreateTigerPlayFootballLogCommand(Guid tigerid,Guid footballid)
        {
            TigerId = tigerid;
            FootballId = footballid;
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}
