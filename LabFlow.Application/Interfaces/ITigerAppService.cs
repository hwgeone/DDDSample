using LabFlow.Application.EventSourcedNormalizers;
using LabFlow.Application.ViewModels;
using LabFlow.Domain.Protocol.Models;
using System;
using System.Collections.Generic;

namespace LabFlow.Application.Interfaces
{
    public interface ITigerAppService : IDisposable
    {
        void Register(TigerViewModel tigerViewModel);
        IEnumerable<TigerViewModel> GetAll();
        TigerViewModel GetById(Guid id);
        IList<TigerHistoryData> GetAllHistory(Guid id);

        void PlayFootball(TigerViewModel tigerViewModel, FootballViewModel footballViewModel);
    }
}
