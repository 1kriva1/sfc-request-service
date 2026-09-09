using SFC.Request.Application.Common.Enums;
using SFC.Request.Application.Features.Common.Base;

namespace SFC.Request.Application.Features.Request.Game.Player.Commands.Creates;
public class CreatesGamePlayerRequestCommand : Request<CreatesGamePlayerRequestViewModel>
{
    public override RequestId RequestId { get => RequestId.CreateGamePlayerRequests; }

    public required IEnumerable<CreatesGamePlayerRequestDto> Requests { get; set; }

    public CreatesGamePlayerRequestCommand SetGameId(long gameId)
    {
        foreach (CreatesGamePlayerRequestDto Request in Requests)
        {
            Request.GameId = gameId;
        }

        return this;
    }
}