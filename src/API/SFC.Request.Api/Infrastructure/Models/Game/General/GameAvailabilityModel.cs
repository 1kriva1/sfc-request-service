using SFC.Request.Api.Infrastructure.Models.Common;
using SFC.Request.Application.Common.Dto.Game.General;
using SFC.Request.Application.Common.Mappings.Interfaces;

namespace SFC.Request.Api.Infrastructure.Models.Game.General;

/// <summary>
/// Game's **availability** model (when game is available to play).
/// </summary>
public class GameAvailabilityModel :
    RangeLimitModel<TimeSpan?>,
    IMapFromReverse<GameAvailabilityDto>
{
    /// <summary>
    /// Date.
    /// </summary>
    public DateOnly Date { get; set; }
}