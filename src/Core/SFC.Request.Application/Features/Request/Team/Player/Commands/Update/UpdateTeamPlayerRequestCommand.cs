using SFC.Request.Application.Common.Enums;
using SFC.Request.Application.Features.Common.Base;

namespace SFC.Request.Application.Features.Request.Team.Player.Commands.Update;
public class UpdateTeamPlayerRequestCommand : ParentRequest
{
    public override RequestId RequestId { get => RequestId.UpdateTeamPlayerRequest; }

    public required UpdateTeamPlayerRequestDto Request { get; set; }

    public UpdateTeamPlayerRequestCommand SetId(long id)
    {
        this.Request.Id = id;
        return this;
    }

    public UpdateTeamPlayerRequestCommand SetPlayerId(long playerId)
    {
        this.Request.PlayerId = playerId;
        return this;
    }

    public UpdateTeamPlayerRequestCommand SetTeamId(long teamId)
    {
        this.Request.TeamId = teamId;
        return this;
    }

    public UpdateTeamPlayerRequestCommand SetStatus(RequestStatusEnum status)
    {
        this.Request.Status = (int)status;
        return this;
    }
}