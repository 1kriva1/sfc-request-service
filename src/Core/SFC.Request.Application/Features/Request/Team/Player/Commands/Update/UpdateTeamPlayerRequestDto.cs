using AutoMapper;

using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Domain.Entities.Request.Team.Player;

namespace SFC.Request.Application.Features.Request.Team.Player.Commands.Update;
public class UpdateTeamPlayerRequestDto : IMapTo<TeamPlayerRequest>
{
    public long Id { get; set; }

    public long TeamId { get; set; }

    public long PlayerId { get; set; }

    public int Status { get; set; }

    public string? TeamComment { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<UpdateTeamPlayerRequestDto, TeamPlayerRequest>()
                                                   .ForMember(p => p.StatusId, d => d.MapFrom(z => z.Status));
}