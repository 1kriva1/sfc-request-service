using AutoMapper;

using SFC.Request.Api.Infrastructure.Models.Game.General;
using SFC.Request.Api.Infrastructure.Models.Player;
using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Application.Features.Request.Game.Player.Common.Dto;

namespace SFC.Request.Api.Infrastructure.Models.Request.Game.Player.Common;

/// <summary>
/// Game player Request model.
/// </summary>
public class GamePlayerRequestModel : IMapFrom<GamePlayerRequestDto>
{
    /// <summary>
    /// Unique identifier.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Game Request related to this player.
    /// </summary>
    public required PlayerModel Player { get; set; }

    /// <summary>
    /// Game Request related to this Game.
    /// </summary>
    public required GameModel Game { get; set; }

    /// <summary>
    /// Game player Request status.
    /// </summary>
    public int Status { get; set; }

    /// <summary>
    /// Comment from Game to player for invitation.
    /// </summary>
    public string? GameComment { get; set; }

    /// <summary>
    /// Comment from player to Game if he/she refuse Request.
    /// </summary>
    public required string? PlayerComment { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<GamePlayerRequestDto, GamePlayerRequestModel>()
                                                   .ForMember(p => p.Status, d => d.MapFrom(z => z.StatusId));
}