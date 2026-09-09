using SFC.Request.Api.Infrastructure.Models.Base;
using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Application.Features.Request.Game.Team.Queries.Exist;

namespace SFC.Request.Api.Infrastructure.Models.Request.Game.Team.Exist;

/// <summary>
/// Described the result of check if Game Team Request **exist**.
/// </summary>
public class GameTeamRequestExistResponse : BaseResponse, IMapFrom<GameTeamRequestExistViewModel>
{
    /// <summary>
    /// Determined if Game Team Request exist.
    /// </summary>
    public bool Exist { get; set; }
}