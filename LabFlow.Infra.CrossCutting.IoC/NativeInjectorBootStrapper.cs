using LabFlow.Application.Interfaces;
using LabFlow.Application.Services;
using LabFlow.Domain.Core.Bus;
using LabFlow.Domain.Core.Events;
using LabFlow.Domain.Core.Notifications;
using LabFlow.Domain.Interfaces;
using LabFlow.Domain.Protocol.CommandHandlers;
using LabFlow.Domain.Protocol.Commands;
using LabFlow.Domain.Protocol.EventHandlers;
using LabFlow.Domain.Protocol.Events;
using LabFlow.Domain.Protocol.Interfaces;
using LabFlow.Domain.Protocol.ProcessManagers;
using LabFlow.Infra.CrossCutting.Bus;
using LabFlow.Infra.CrossCutting.Identity.Authorization;
using LabFlow.Infra.CrossCutting.Identity.Models;
using LabFlow.Infra.CrossCutting.Identity.Services;
using LabFlow.Infra.Data.Context;
using LabFlow.Infra.Data.EventSourcing;
using LabFlow.Infra.Data.Repository;
using LabFlow.Infra.Data.Repository.EventSourcing;
using LabFlow.Infra.Data.UoW;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace LabFlow.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // ASP.NET Authorization Polices
            services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();

            // Application
            services.AddScoped<ITigerAppService, TigerAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<TigerRegisteredEvent>, TigerEventHandler>();
            services.AddScoped<INotificationHandler<FootballLossReducedEvent>, TigerPlayFootballProcessManager>();
            services.AddScoped<INotificationHandler<TigerPlayFootballLogCreatedEvent>, TigerPlayFootballProcessManager>();
            services.AddScoped<INotificationHandler<TigerPleasureIncreasedEvent>, TigerPlayFootballProcessManager>();
            // Domain - Commands
            services.AddScoped<IRequestHandler<NewTigerCommand>, TigerCommandHandler>();
            services.AddScoped<IRequestHandler<IncreaseTigerPleasureCommand>, TigerCommandHandler>();
            services.AddScoped<IRequestHandler<CreateTigerPlayFootballLogCommand>, TigerFlayFootballCommandHander>();
            services.AddScoped<IRequestHandler<ReduceFootballLossCommand>, FootballCommandHander>();

            // Infra - Data
            services.AddScoped<ITigerRepository, TigerRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<LabFlowContext>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSQLContext>();

            // Infra - Identity Services
            services.AddTransient<IEmailSender, AuthEmailMessageSender>();
            services.AddTransient<ISmsSender, AuthSMSMessageSender>();

            // Infra - Identity
            services.AddScoped<IUser, AspNetUser>();
        }
    }
}
