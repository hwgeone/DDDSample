using LabFlow.Domain.Core.Models;
using System;

namespace LabFlow.Domain.Protocol.Models
{
    public class TigerPlayFootballLog : Entity
    {
        public Guid TigerId { get; set; }
        public Guid FootballId { get; set; }

        public TigerPlayFootballLog()
        { }

        public TigerPlayFootballLog(Guid id,Guid tigerid,Guid footballid)
        {
            Id = id;
            TigerId = tigerid;
            FootballId = footballid;
        }
    }
}
