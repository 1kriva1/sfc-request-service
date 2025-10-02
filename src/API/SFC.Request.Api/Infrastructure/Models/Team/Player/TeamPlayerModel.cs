using AutoMapper;

using SFC.Request.Api.Infrastructure.Models.Player;
using SFC.Request.Application.Common.Dto.Team.Player;
using SFC.Request.Application.Common.Mappings.Interfaces;

namespace SFC.Request.Api.Infrastructure.Models.Team.Player;

/// <summary>
/// Team player model.
/// </summary>
public class TeamPlayerModel : IMapFrom<TeamPlayerDto>
{
    /// <summary>
    /// Unique identifier.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Team player status.
    /// </summary>
    public int Status { get; set; }

    /// <summary>
    /// Team player related to this player.
    /// </summary>
    public required PlayerModel Player { get; set; }


    public void Mapping(Profile profile) => profile.CreateMap<TeamPlayerDto, TeamPlayerModel>()
                                                   .ForMember(p => p.Status, d => d.MapFrom(z => z.StatusId));
}