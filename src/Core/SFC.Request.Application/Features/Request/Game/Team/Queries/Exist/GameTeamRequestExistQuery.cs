using SFC.Request.Application.Common.Enums;
using SFC.Request.Application.Features.Common.Base;

namespace SFC.Request.Application.Features.Request.Game.Team.Queries.Exist;

public class GameTeamRequestExistQuery : Request<GameTeamRequestExistViewModel>
{
    public override RequestId RequestId { get => RequestId.ExistGameTeamRequest; }

    public long GameId { get; set; }

    public long TeamId { get; set; }

    public RequestStatusEnum? Status { get; set; }

    public GameTeamRequestExistQuery SetTeamId(long teamId)
    {
        this.TeamId = teamId;
        return this;
    }

    public GameTeamRequestExistQuery SetGameId(long gameId)
    {
        this.GameId = gameId;
        return this;
    }
}