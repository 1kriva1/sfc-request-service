using SFC.Request.Application.Common.Enums;

namespace SFC.Request.Application.Features.Request.Game.Team.Commands.Update;
public class UpdateGameTeamRequestCommand : ParentRequest
{
    public override RequestId RequestId { get => RequestId.UpdateGameTeamRequest; }

    public required UpdateGameTeamRequestDto Request { get; set; }

    public UpdateGameTeamRequestCommand SetId(long id)
    {
        this.Request.Id = id;
        return this;
    }

    public UpdateGameTeamRequestCommand SetTeamId(long teamId)
    {
        this.Request.TeamId = teamId;
        return this;
    }

    public UpdateGameTeamRequestCommand SetGameId(long gameId)
    {
        this.Request.GameId = gameId;
        return this;
    }

    public UpdateGameTeamRequestCommand SetStatus(RequestStatusEnum status)
    {
        this.Request.Status = (int)status;
        return this;
    }
}