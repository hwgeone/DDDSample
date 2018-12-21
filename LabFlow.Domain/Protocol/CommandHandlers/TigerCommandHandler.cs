using LabFlow.Domain.Core.Bus;
using LabFlow.Domain.Core.Notifications;
using LabFlow.Domain.Interfaces;
using LabFlow.Domain.Protocol.Commands;
using LabFlow.Domain.Protocol.Events;
using LabFlow.Domain.Protocol.Interfaces;
using LabFlow.Domain.Protocol.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LabFlow.Domain.Protocol.CommandHandlers
{
    public class TigerCommandHandler : CommandHandler,
        IRequestHandler<NewTigerCommand>,
        IRequestHandler<IncreaseTigerPleasureCommand>
    {
        private readonly ITigerRepository _tigerRepository;
        private readonly IMediatorHandler Bus;

        public TigerCommandHandler(ITigerRepository tigerRepository,
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _tigerRepository = tigerRepository;
            Bus = bus;
        }

        public Task Handle(NewTigerCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            var tiger = new Tiger(Guid.NewGuid(), message.Name);

            if (_tigerRepository.GetByName(tiger.Name) != null)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "The tiger e-mail has already been taken."));
                return Task.CompletedTask;
            }

            _tigerRepository.Add(tiger);

            if (Commit())
            {
                Bus.RaiseEvent(new TigerRegisteredEvent(tiger.Id, tiger.Name));
            }

            return Task.CompletedTask;
        }
        public Task Handle(IncreaseTigerPleasureCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            var tiger = _tigerRepository.GetById(message.TigerId);

            tiger.IncreaseTigerPleasure();
            _tigerRepository.Update(tiger);
            if (Commit())
            {
                Bus.RaiseEvent(new TigerPleasureIncreasedEvent(tiger.Id, 50));
            }

            return Task.CompletedTask;
        }
        public void Dispose()
        {
            _tigerRepository.Dispose();
        }
    }
}
