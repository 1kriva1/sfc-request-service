using SFC.Request.Application.Common.Enums;
using SFC.Request.Application.Features.Common.Base;

namespace SFC.Request.Application.Features.Request.Game.Team.Commands.Create;
public class CreateGameTeamRequestCommand : Request<CreateGameTeamRequestViewModel>
{
    public override RequestId RequestId { get => RequestId.CreateGameTeamRequest; }

    public required CreateGameTeamRequestDto Request { get; set; }

    public CreateGameTeamRequestCommand SetTeamId(long teamId)
    {
        this.Request.TeamId = teamId;
        return this;
    }

    public CreateGameTeamRequestCommand SetGameId(long gameId)
    {
        this.Request.GameId = gameId;
        return this;
    }
}