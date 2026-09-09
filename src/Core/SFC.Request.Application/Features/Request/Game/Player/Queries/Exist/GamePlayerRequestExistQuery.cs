using SFC.Request.Application.Common.Enums;
using SFC.Request.Application.Features.Common.Base;

namespace SFC.Request.Application.Features.Request.Game.Player.Queries.Exist;

public class GamePlayerRequestExistQuery : Request<GamePlayerRequestExistViewModel>
{
    public override RequestId RequestId { get => RequestId.ExistGamePlayerRequest; }

    public long GameId { get; set; }

    public long PlayerId { get; set; }

    public RequestStatusEnum? Status { get; set; }

    public GamePlayerRequestExistQuery SetPlayerId(long playerId)
    {
        this.PlayerId = playerId;
        return this;
    }

    public GamePlayerRequestExistQuery SetGameId(long gameId)
    {
        this.GameId = gameId;
        return this;
    }
}