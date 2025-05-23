using AutoMapper;

using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Application.Features.Request.Team.Player.Common.Dto;
using SFC.Request.Domain.Entities.Request.Team.Player;

namespace SFC.Request.Application.Features.Request.Team.Player.Queries.Get;
public class GetTeamPlayerRequestViewModel : IMapFrom<TeamPlayerRequest>
{
    public required TeamPlayerRequestDto Request { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<TeamPlayerRequest, GetTeamPlayerRequestViewModel>()
                                                   .ForMember(p => p.Request, d => d.MapFrom(z => z));
}