using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Application.Features.Request.Team.Player.Queries.Find.Dto.Filters;

namespace SFC.Request.Api.Infrastructure.Models.Request.Team.Player.Find.Filters;

/// <summary>
/// Get team player requests for request filter model.
/// </summary>
public class GetTeamPlayerRequestsRequestFilterModel : IMapTo<GetTeamPlayerRequestsRequestFilterDto>
{
    /// <summary>
    /// Statuses of request.
    /// </summary>
    public IEnumerable<int> Statuses { get; set; } = default!;
}