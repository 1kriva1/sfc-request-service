using AutoMapper;

using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Application.Features.Request.Team.Player.Common.Dto;
using SFC.Request.Domain.Entities.Request.Team.Player;

namespace SFC.Request.Application.Features.Request.Team.Player.Queries.GetAll;
public class GetAllTeamPlayerRequestsViewModel : IMapFrom<IEnumerable<TeamPlayerRequest>>
{
    public required IEnumerable<TeamPlayerRequestDto> Requests { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<IEnumerable<TeamPlayerRequest>, GetAllTeamPlayerRequestsViewModel>()
                                                   .ForMember(p => p.Requests, d => d.MapFrom(z => z));
}