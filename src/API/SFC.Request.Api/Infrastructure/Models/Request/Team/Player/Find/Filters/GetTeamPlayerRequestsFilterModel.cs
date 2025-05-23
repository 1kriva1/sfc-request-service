using SFC.Request.Api.Infrastructure.Models.Player.Find.Filters;
using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Application.Features.Request.Team.Player.Queries.Find.Dto.Filters;

namespace SFC.Request.Api.Infrastructure.Models.Request.Team.Player.Find.Filters;

/// <summary>
/// Get team player requests filter model.
/// </summary>
public class GetTeamPlayerRequestsFilterModel : IMapTo<GetTeamPlayerRequestsFilterDto>
{
    /// <summary>
    /// Request filter model.
    /// </summary>
    public GetTeamPlayerRequestsRequestFilterModel? Request { get; set; }

    /// <summary>
    /// Player filter model.
    /// </summary>
    public PlayerFilterModel? Player { get; set; }
}