using SFC.Request.Api.Infrastructure.Models.Player.Find.Filters;
using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Application.Features.Request.Game.Player.Queries.Find.Dto.Filters;

namespace SFC.Request.Api.Infrastructure.Models.Request.Game.Player.Find.Filters;

/// <summary>
/// Get Game player Requests filter model.
/// </summary>
public class GetGamePlayerRequestsFilterModel : IMapTo<GetGamePlayerRequestsFilterDto>
{
    /// <summary>
    /// Request filter model.
    /// </summary>
    public GetGamePlayerRequestsRequestFilterModel? Request { get; set; }

    /// <summary>
    /// Player filter model.
    /// </summary>
    public PlayerFilterModel? Player { get; set; }
}