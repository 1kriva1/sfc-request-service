using AutoMapper;

using SFC.Request.Api.Infrastructure.Models.Player;
using SFC.Request.Application.Common.Dto.Game.Player;
using SFC.Request.Application.Common.Mappings.Interfaces;

namespace SFC.Request.Api.Infrastructure.Models.Game.Player;

/// <summary>
/// Game Player model.
/// </summary>
public class GamePlayerModel : IMapFrom<GamePlayerDto>
{
    /// <summary>
    /// Unique identifier.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Game Player status.
    /// </summary>
    public int Status { get; set; }

    /// <summary>
    /// Game Player related to this player.
    /// </summary>
    public required PlayerModel Player { get; set; }


    public void Mapping(Profile profile) => profile.CreateMap<GamePlayerDto, GamePlayerModel>()
                                                   .ForMember(p => p.Status, d => d.MapFrom(z => z.StatusId));
}