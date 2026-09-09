using SFC.Request.Application.Common.Enums;
using SFC.Request.Application.Features.Common.Base;

namespace SFC.Request.Application.Features.Request.Game.Team.Commands.Creates;
public class CreatesGameTeamRequestCommand : Request<CreatesGameTeamRequestViewModel>
{
    public override RequestId RequestId { get => RequestId.CreateGameTeamRequests; }

    public required IEnumerable<CreatesGameTeamRequestDto> Requests { get; set; }

    public CreatesGameTeamRequestCommand SetGameId(long gameId)
    {
        foreach (CreatesGameTeamRequestDto request in Requests)
        {
            request.GameId = gameId;
        }

        return this;
    }
}