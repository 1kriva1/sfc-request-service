using SFC.Request.Domain.Entities.Request.Game.Player;

namespace SFC.Request.Application.Features.Request.Game.Player.Common.Extensions;
public static class GamePlayerRequestExtension
{
    public static GamePlayerRequest SetStatus(this GamePlayerRequest value, RequestStatusEnum status)
    {
        value.StatusId = status;
        return value;
    }
}