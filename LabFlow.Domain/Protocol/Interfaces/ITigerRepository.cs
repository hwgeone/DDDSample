using LabFlow.Domain.Interfaces;
using LabFlow.Domain.Protocol.Models;

namespace LabFlow.Domain.Protocol.Interfaces
{
    public interface ITigerRepository : IRepository<Tiger>
    {
        Tiger GetByName(string name);
    }
}
