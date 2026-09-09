using SFC.Request.Api.Infrastructure.Models.Team.General.Filters;
using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Application.Features.Request.Game.Team.Queries.Find.Dto.Filters;

namespace SFC.Request.Api.Infrastructure.Models.Request.Game.Team.Find.Filters;

/// <summary>
/// Get Game Team Requests filter model.
/// </summary>
public class GetGameTeamRequestsFilterModel : IMapTo<GetGameTeamRequestsFilterDto>
{
    /// <summary>
    /// Request filter model.
    /// </summary>
    public GetGameTeamRequestsRequestFilterModel? Request { get; set; }

    /// <summary>
    /// Team filter model.
    /// </summary>
    public TeamFilterModel? Team { get; set; }
}