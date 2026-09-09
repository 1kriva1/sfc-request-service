using AutoMapper;

using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Application.Features.Request.Game.Team.Common.Dto;
using SFC.Request.Domain.Entities.Request.Game.Team;

namespace SFC.Request.Application.Features.Request.Game.Team.Commands.Creates;
public class CreatesGameTeamRequestViewModel : IMapFrom<IEnumerable<GameTeamRequest>>
{
    public required IEnumerable<GameTeamRequestDto> Requests { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<IEnumerable<GameTeamRequest>, CreatesGameTeamRequestViewModel>()
                                                   .ForMember(p => p.Requests, d => d.MapFrom(z => z));
}