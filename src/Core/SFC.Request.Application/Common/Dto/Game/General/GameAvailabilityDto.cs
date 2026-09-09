using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Domain.Entities.Game.General;

namespace SFC.Request.Application.Common.Dto.Game.General;
public class GameAvailabilityDto : IMapFromReverse<GameAvailability>
{
    public DateOnly Date { get; set; }

    public TimeSpan From { get; set; }

    public TimeSpan To { get; set; }
}