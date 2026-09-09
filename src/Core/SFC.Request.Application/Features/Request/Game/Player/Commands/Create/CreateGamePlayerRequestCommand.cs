using SFC.Request.Application.Common.Enums;
using SFC.Request.Application.Features.Common.Base;

namespace SFC.Request.Application.Features.Request.Game.Player.Commands.Create;
public class CreateGamePlayerRequestCommand : Request<CreateGamePlayerRequestViewModel>
{
    public override RequestId RequestId { get => RequestId.CreateGamePlayerRequest; }

    public required CreateGamePlayerRequestDto Request { get; set; }

    public CreateGamePlayerRequestCommand SetPlayerId(long playerId)
    {
        this.Request.PlayerId = playerId;
        return this;
    }

    public CreateGamePlayerRequestCommand SetGameId(long gameId)
    {
        this.Request.GameId = gameId;
        return this;
    }
}