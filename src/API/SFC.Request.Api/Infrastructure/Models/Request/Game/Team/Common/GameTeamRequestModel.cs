using AutoMapper;

using SFC.Request.Api.Infrastructure.Models.Game.General;
using SFC.Request.Api.Infrastructure.Models.Team.General;
using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Application.Features.Request.Game.Team.Common.Dto;

namespace SFC.Request.Api.Infrastructure.Models.Request.Game.Team.Common;

/// <summary>
/// Game Team Request model.
/// </summary>
public class GameTeamRequestModel : IMapFrom<GameTeamRequestDto>
{
    /// <summary>
    /// Unique identifier.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Game Request related to this Team.
    /// </summary>
    public required TeamModel Team { get; set; }

    /// <summary>
    /// Game Request related to this Game.
    /// </summary>
    public required GameModel Game { get; set; }

    /// <summary>
    /// Game Team Request status.
    /// </summary>
    public int Status { get; set; }

    /// <summary>
    /// Comment from Game to Team for invitation.
    /// </summary>
    public string? GameComment { get; set; }

    /// <summary>
    /// Comment from Team to Game if he/she refuse Request.
    /// </summary>
    public required string? TeamComment { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<GameTeamRequestDto, GameTeamRequestModel>()
                                                   .ForMember(p => p.Status, d => d.MapFrom(z => z.StatusId));
}