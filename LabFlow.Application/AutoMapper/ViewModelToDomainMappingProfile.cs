
using AutoMapper;
using LabFlow.Application.ViewModels;
using LabFlow.Domain.Protocol.Commands;

namespace LabFlow.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<TigerViewModel, NewTigerCommand>()
                .ConstructUsing(c => new NewTigerCommand(c.Name));
        }
    }
}
