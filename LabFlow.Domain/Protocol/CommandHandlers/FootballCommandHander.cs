using System.Threading;
using System.Threading.Tasks;
using LabFlow.Domain.Core.Bus;
using LabFlow.Domain.Core.Notifications;
using LabFlow.Domain.Interfaces;
using LabFlow.Domain.Protocol.Commands;
using MediatR;

namespace LabFlow.Domain.Protocol.CommandHandlers
{
    public class FootballCommandHander : CommandHandler,
        IRequestHandler<ReduceFootballLossCommand>
    {
        private readonly IMediatorHandler Bus;

        public FootballCommandHander(IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            Bus = bus;
        }

        public Task Handle(ReduceFootballLossCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

 
          // Bus.RaiseEvent(new ReduceFootballLossCommand(tiger.Id, 50));
          
            return Task.CompletedTask;
        }
    }
}
