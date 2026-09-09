using SFC.Request.Application.Features.Common.Dto.Common;

namespace SFC.Request.Application.Common.Dto.Team.General.Filters;
public class TeamAvailabilityLimitDto : RangeLimitDto<TimeSpan?>
{
    public IEnumerable<DayOfWeek> Days { get; set; } = [];
}