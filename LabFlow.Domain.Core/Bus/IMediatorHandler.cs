using LabFlow.Domain.Core.Commands;
using LabFlow.Domain.Core.Events;
using System.Threading.Tasks;

namespace LabFlow.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
