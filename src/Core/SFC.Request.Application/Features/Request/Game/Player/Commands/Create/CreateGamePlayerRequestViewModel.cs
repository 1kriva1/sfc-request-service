using AutoMapper;

using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Application.Features.Request.Game.Player.Common.Dto;
using SFC.Request.Domain.Entities.Request.Game.Player;

namespace SFC.Request.Application.Features.Request.Game.Player.Commands.Create;
public class CreateGamePlayerRequestViewModel : IMapFrom<GamePlayerRequest>
{
    public required GamePlayerRequestDto Request { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<GamePlayerRequest, CreateGamePlayerRequestViewModel>()
                                                   .ForMember(p => p.Request, d => d.MapFrom(z => z));
}