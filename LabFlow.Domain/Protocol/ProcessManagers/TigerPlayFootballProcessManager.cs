using LabFlow.Domain.Core.Bus;
using LabFlow.Domain.Protocol.Commands;
using LabFlow.Domain.Protocol.Events;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// 流程管理器 也可以说是领域服务吧 回头要放在父层
/// </summary>
namespace LabFlow.Domain.Protocol.ProcessManagers
{
    public class TigerPlayFootballProcessManager :
                 INotificationHandler<TigerPlayFootballLogCreatedEvent>,
                 INotificationHandler<TigerPleasureIncreasedEvent>,
                 INotificationHandler<FootballLossReducedEvent>
    {
        private readonly IMediatorHandler Bus;

        public TigerPlayFootballProcessManager(
                              IMediatorHandler bus)
        {
            Bus = bus;
        }
        public Task Handle(TigerPleasureIncreasedEvent message, CancellationToken cancellationToken)
        {
            //send other command if need
            return Task.CompletedTask;
        }

        public Task Handle(TigerPlayFootballLogCreatedEvent notification, CancellationToken cancellationToken)
        {
            Bus.SendCommand(new IncreaseTigerPleasureCommand(notification.TigerId, 50));
            Bus.SendCommand(new ReduceFootballLossCommand(notification.FootballId, 50));
            return Task.CompletedTask;
        }

        public Task Handle(FootballLossReducedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
