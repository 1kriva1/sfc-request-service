using SFC.Request.Application.Common.Dto.Team.General.Filters;
using SFC.Request.Application.Common.Mappings.Interfaces;

namespace SFC.Request.Api.Infrastructure.Models.Team.General.Filters;

/// <summary>
/// Team **inventary profile filter** model.
/// </summary>
public class TeamInventaryProfileFilterModel : IMapTo<TeamInventaryProfileFilterDto>
{
    /// <summary>
    /// Team's **shirts**.
    /// </summary>
    public IEnumerable<int> Shirts { get; set; } = default!;
}