using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Application.Features.Request.Game.Player.Queries.Find.Dto.Filters;

namespace SFC.Request.Api.Infrastructure.Models.Request.Game.Player.Find.Filters;

/// <summary>
/// Get Game player Requests for Request filter model.
/// </summary>
public class GetGamePlayerRequestsRequestFilterModel : IMapTo<GetGamePlayerRequestsRequestFilterDto>
{
    /// <summary>
    /// Statuses of Request.
    /// </summary>
    public IEnumerable<int> Statuses { get; set; } = default!;
}