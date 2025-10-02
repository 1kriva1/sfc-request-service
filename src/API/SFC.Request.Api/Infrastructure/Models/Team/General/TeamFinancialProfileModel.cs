using SFC.Request.Application.Common.Dto.Team.General;
using SFC.Request.Application.Common.Mappings.Interfaces;

namespace SFC.Request.Api.Infrastructure.Models.Team.General;

/// <summary>
/// Team's **financial** profile model.
/// </summary>
public class TeamFinancialProfileModel : IMapFromReverse<TeamFinancialProfileDto>
{
    /// <summary>
    /// Team play only on free field and without any extra expansions.
    /// </summary>
    public bool? FreePlay { get; set; }
}