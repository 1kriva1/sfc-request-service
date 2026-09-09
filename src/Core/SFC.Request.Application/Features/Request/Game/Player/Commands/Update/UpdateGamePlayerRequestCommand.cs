using SFC.Request.Application.Common.Enums;

namespace SFC.Request.Application.Features.Request.Game.Player.Commands.Update;
public class UpdateGamePlayerRequestCommand : ParentRequest
{
    public override RequestId RequestId { get => RequestId.UpdateGamePlayerRequest; }

    public required UpdateGamePlayerRequestDto Request { get; set; }

    public UpdateGamePlayerRequestCommand SetId(long id)
    {
        this.Request.Id = id;
        return this;
    }

    public UpdateGamePlayerRequestCommand SetPlayerId(long playerId)
    {
        this.Request.PlayerId = playerId;
        return this;
    }

    public UpdateGamePlayerRequestCommand SetGameId(long gameId)
    {
        this.Request.GameId = gameId;
        return this;
    }

    public UpdateGamePlayerRequestCommand SetStatus(RequestStatusEnum status)
    {
        this.Request.Status = (int)status;
        return this;
    }
}