using AutoMapper;

using SFC.Request.Application.Common.Mappings.Interfaces;

namespace SFC.Request.Application.Features.Request.Commands.Update;
public class UpdateRequestDto : IMapTo<RequestEntity>
{
    public long Id { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<UpdateRequestDto, RequestEntity>();
}