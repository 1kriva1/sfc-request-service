using AutoMapper;

using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Application.Features.Request.Game.Player.Common.Dto;
using SFC.Request.Domain.Entities.Request.Game.Player;

namespace SFC.Request.Application.Features.Request.Game.Player.Queries.Get;
public class GetGamePlayerRequestViewModel : IMapFrom<GamePlayerRequest>
{
    public required GamePlayerRequestDto Request { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<GamePlayerRequest, GetGamePlayerRequestViewModel>()
                                                   .ForMember(p => p.Request, d => d.MapFrom(z => z));
}