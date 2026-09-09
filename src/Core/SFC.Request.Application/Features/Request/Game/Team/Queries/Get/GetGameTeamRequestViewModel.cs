using AutoMapper;

using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Application.Features.Request.Game.Team.Common.Dto;
using SFC.Request.Domain.Entities.Request.Game.Team;

namespace SFC.Request.Application.Features.Request.Game.Team.Queries.Get;
public class GetGameTeamRequestViewModel : IMapFrom<GameTeamRequest>
{
    public required GameTeamRequestDto Request { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<GameTeamRequest, GetGameTeamRequestViewModel>()
                                                   .ForMember(p => p.Request, d => d.MapFrom(z => z));
}