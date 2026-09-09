using AutoMapper;

using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Application.Features.Request.Game.Player.Common.Dto;
using SFC.Request.Domain.Entities.Request.Game.Player;

namespace SFC.Request.Application.Features.Request.Game.Player.Commands.Creates;
public class CreatesGamePlayerRequestViewModel : IMapFrom<IEnumerable<GamePlayerRequest>>
{
    public required IEnumerable<GamePlayerRequestDto> Requests { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<IEnumerable<GamePlayerRequest>, CreatesGamePlayerRequestViewModel>()
                                                   .ForMember(p => p.Requests, d => d.MapFrom(z => z));
}