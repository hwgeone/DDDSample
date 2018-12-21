using LabFlow.Domain.Protocol.Events;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LabFlow.Domain.Protocol.EventHandlers
{
    public class TigerEventHandler :
    INotificationHandler<TigerRegisteredEvent>
    {

        public Task Handle(TigerRegisteredEvent message, CancellationToken cancellationToken)
        {
            // Send some greetings e-mail

            return Task.CompletedTask;
        }

    }
}
