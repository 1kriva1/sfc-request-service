using SFC.Request.Api.Infrastructure.Models.Common;
using SFC.Request.Application.Common.Dto.Team.General.Filters;
using SFC.Request.Application.Common.Mappings.Interfaces;

namespace SFC.Request.Api.Infrastructure.Models.Team.General.Filters;

/// <summary>
/// Team **availability filter** model.
/// </summary>
public class TeamAvailabilityLimitModel :
    RangeLimitModel<TimeSpan?>,
    IMapTo<TeamAvailabilityLimitDto>
{
    /// <summary>
    /// Days of week.
    /// </summary>
    public IEnumerable<int>? Days { get; set; }
}