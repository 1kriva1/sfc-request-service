using SFC.Request.Application.Common.Dto.Game.General;
using SFC.Request.Application.Common.Mappings.Interfaces;

namespace SFC.Request.Api.Infrastructure.Models.Game.General;

/// <summary>
/// Game's **inventary** profile model.
/// </summary>
public class GameInventaryProfileModel : IMapFromReverse<GameInventaryProfileDto>
{
    /// <summary>
    /// Is it required to have shirts for play.
    /// </summary>
    public bool ShirtsRequired { get; set; }

    /// <summary>
    /// How many shirts required for game.
    /// </summary>
    public int? ShirtsCount { get; set; }
}