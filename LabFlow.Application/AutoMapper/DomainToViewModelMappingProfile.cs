using AutoMapper;
using LabFlow.Application.ViewModels;
using LabFlow.Domain.Protocol.Models;

namespace LabFlow.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Tiger, TigerViewModel>();
        }
    }
}
