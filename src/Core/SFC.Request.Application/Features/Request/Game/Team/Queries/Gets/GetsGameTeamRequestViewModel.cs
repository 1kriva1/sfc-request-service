using AutoMapper;

using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Application.Features.Request.Game.Team.Common.Dto;
using SFC.Request.Domain.Entities.Request.Game.Team;

namespace SFC.Request.Application.Features.Request.Game.Team.Queries.Gets;
public class GetsGameTeamRequestViewModel : IMapFrom<IEnumerable<GameTeamRequest>>
{
    public required IEnumerable<GameTeamRequestDto> Requests { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<IEnumerable<GameTeamRequest>, GetsGameTeamRequestViewModel>()
                                                   .ForMember(p => p.Requests, d => d.MapFrom(z => z));
}