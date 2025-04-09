using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Domain.Entities.Team.General;

namespace SFC.Request.Application.Common.Dto.Team.General;
public class TeamAvailabilityDto : IMapFromReverse<TeamAvailability>
{
    public DayOfWeek Day { get; set; }

    public TimeSpan From { get; set; }

    public TimeSpan To { get; set; }
}