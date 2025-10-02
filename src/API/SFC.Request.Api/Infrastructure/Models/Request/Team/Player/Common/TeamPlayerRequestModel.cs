using AutoMapper;

using SFC.Request.Api.Infrastructure.Models.Player;
using SFC.Request.Api.Infrastructure.Models.Team.General;
using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Application.Features.Request.Team.Player.Common.Dto;

namespace SFC.Request.Api.Infrastructure.Models.Request.Team.Player.Common;

/// <summary>
/// Request model.
/// </summary>
public class TeamPlayerRequestModel : IMapFrom<TeamPlayerRequestDto>
{
    /// <summary>
    /// Unique identifier.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Request related to this player.
    /// </summary>
    public required PlayerModel Player { get; set; }

    /// <summary>
    /// Team invite related to this team.
    /// </summary>
    public required TeamModel Team { get; set; }

    /// <summary>
    /// Team player request status.
    /// </summary>
    public int Status { get; set; }

    /// <summary>
    /// Comment from team to player in case decline action.
    /// </summary>
    public string? TeamComment { get; set; }

    /// <summary>
    /// Comment from player to team .
    /// </summary>
    public required string PlayerComment { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<TeamPlayerRequestDto, TeamPlayerRequestModel>()
                                                   .ForMember(p => p.Status, d => d.MapFrom(z => z.StatusId));
}