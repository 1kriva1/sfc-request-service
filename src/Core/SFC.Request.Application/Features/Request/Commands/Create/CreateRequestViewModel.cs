using AutoMapper;

using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Application.Features.Request.Common.Dto;

namespace SFC.Request.Application.Features.Request.Commands.Create;
public class CreateRequestViewModel : IMapFrom<RequestEntity>
{
    public required RequestDto Request { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<RequestEntity, CreateRequestViewModel>()
                                                   .ForMember(p => p.Request, d => d.MapFrom(z => z));
}