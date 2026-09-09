using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Application.Features.Request.Game.Team.Queries.Find.Dto.Filters;

namespace SFC.Request.Api.Infrastructure.Models.Request.Game.Team.Find.Filters;

/// <summary>
/// Get Game Team Requests for Request filter model.
/// </summary>
public class GetGameTeamRequestsRequestFilterModel : IMapTo<GetGameTeamRequestsRequestFilterDto>
{
    /// <summary>
    /// Statuses of Request.
    /// </summary>
    public IEnumerable<int> Statuses { get; set; } = default!;
}