using SFC.Request.Application.Common.Dto.Team.General.Filters;
using SFC.Request.Application.Common.Mappings.Interfaces;

namespace SFC.Request.Api.Infrastructure.Models.Team.General.Filters;

/// <summary>
/// Team filter model.
/// </summary>
public class TeamFilterModel : IMapTo<TeamFilterDto>
{
    /// <summary>
    /// Statuses of team.
    /// </summary>
    public IEnumerable<int> Statuses { get; set; } = default!;

    /// <summary>
    /// Profile filter model.
    /// </summary>
    public TeamProfileFilterModel? Profile { get; set; }
}