using LabFlow.Domain.Core.Bus;
using LabFlow.Domain.Core.Notifications;
using LabFlow.Domain.Interfaces;
using LabFlow.Domain.Protocol.Commands;
using LabFlow.Domain.Protocol.Events;
using LabFlow.Domain.Protocol.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LabFlow.Domain.Protocol.CommandHandlers
{
    public class TigerFlayFootballCommandHander : CommandHandler,
           IRequestHandler<CreateTigerPlayFootballLogCommand>
    {
        private readonly IMediatorHandler Bus;

        public TigerFlayFootballCommandHander( 
                                     IUnitOfWork uow,
                                     IMediatorHandler bus,
                                     INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            Bus = bus;
        }
        public Task Handle(CreateTigerPlayFootballLogCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }
            TigerPlayFootballLog log = new TigerPlayFootballLog(Guid.NewGuid(),message.TigerId,message.FootballId);
            Bus.RaiseEvent(new TigerPlayFootballLogCreatedEvent(log.Id, log.TigerId, log.FootballId));

            return Task.CompletedTask;
        }
    }
}
