using SFC.Request.Application.Features.Common.Dto.Common;

namespace SFC.Request.Application.Common.Dto.Player.Filters;
public class PlayerAvailabilityLimitFilterDto : RangeLimitDto<TimeSpan?>
{
    public IEnumerable<DayOfWeek> Days { get; set; } = [];
}