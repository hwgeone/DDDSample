using LabFlow.Domain.Protocol.Interfaces;
using LabFlow.Domain.Protocol.Models;
using LabFlow.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LabFlow.Infra.Data.Repository
{
    public class TigerRepository : Repository<Tiger>, ITigerRepository
    {
        public TigerRepository(LabFlowContext context)
            : base(context)
        {

        }

        public Tiger GetByName(string name)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Name == name);
        }
    }
}
