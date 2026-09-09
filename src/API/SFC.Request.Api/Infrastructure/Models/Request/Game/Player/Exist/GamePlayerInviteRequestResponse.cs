using SFC.Request.Api.Infrastructure.Models.Base;
using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Application.Features.Request.Game.Player.Queries.Exist;

namespace SFC.Request.Api.Infrastructure.Models.Request.Game.Player.Exist;

/// <summary>
/// Described the result of check if Game player Request **exist**.
/// </summary>
public class GamePlayerRequestExistResponse : BaseResponse, IMapFrom<GamePlayerRequestExistViewModel>
{
    /// <summary>
    /// Determined if Game player Request exist.
    /// </summary>
    public bool Exist { get; set; }
}