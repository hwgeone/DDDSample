using AutoMapper;
using AutoMapper.QueryableExtensions;
using LabFlow.Application.EventSourcedNormalizers;
using LabFlow.Application.Interfaces;
using LabFlow.Application.ViewModels;
using LabFlow.Domain.Core.Bus;
using LabFlow.Domain.Protocol.Commands;
using LabFlow.Domain.Protocol.Interfaces;
using LabFlow.Infra.Data.Repository.EventSourcing;
using System;
using System.Collections.Generic;

namespace LabFlow.Application.Services
{
    public class TigerAppService : ITigerAppService
    {
        private readonly IMapper _mapper;
        private readonly ITigerRepository _tigerRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public TigerAppService(IMapper mapper,
                                  ITigerRepository tigerRepository,
                                  IMediatorHandler bus,
                                  IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _tigerRepository = tigerRepository;
            Bus = bus;
            _eventStoreRepository = eventStoreRepository;
        }

        public IEnumerable<TigerViewModel> GetAll()
        {
            return _tigerRepository.GetAll().ProjectTo<TigerViewModel>();
        }

        public TigerViewModel GetById(Guid id)
        {
            return _mapper.Map<TigerViewModel>(_tigerRepository.GetById(id));
        }

        public void Register(TigerViewModel customerViewModel)
        {
            var registerCommand = _mapper.Map<NewTigerCommand>(customerViewModel);
            Bus.SendCommand(registerCommand);
        }

        public IList<TigerHistoryData> GetAllHistory(Guid id)
        {
            return TigerHistory.ToJavaScriptTigerHistory(_eventStoreRepository.All(id));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void PlayFootball(TigerViewModel tigerViewModel, FootballViewModel footballViewModel)
        {
            var command1 = new CreateTigerPlayFootballLogCommand(new Guid("0BDB8297-2AD5-4E0F-9973-5BA0DE319B83"),new Guid("0BDB8297-2AD5-4E0F-9973-5BA0DE319B83"));

            Bus.SendCommand(command1);
        }
    }
}
