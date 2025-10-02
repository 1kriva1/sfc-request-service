using SFC.Request.Application.Common.Dto.Team.General;
using SFC.Request.Application.Common.Mappings.Interfaces;

namespace SFC.Request.Api.Infrastructure.Models.Team.General;

/// <summary>
/// Team's **inventary** profile model.
/// </summary>
public class TeamInventaryProfileModel : IMapFromReverse<TeamInventaryProfileDto>
{
    /// <summary>
    /// In what shirts team can play (multiple value).
    /// </summary>
    public IEnumerable<int> Shirts { get; set; } = [];

    /// <summary>
    /// Define if team has maniches.
    /// </summary>
    public bool HasManiches { get; set; }
}