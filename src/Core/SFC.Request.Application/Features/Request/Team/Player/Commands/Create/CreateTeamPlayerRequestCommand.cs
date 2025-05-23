using SFC.Request.Application.Common.Enums;
using SFC.Request.Application.Features.Common.Base;

namespace SFC.Request.Application.Features.Request.Team.Player.Commands.Create;
public class CreateTeamPlayerRequestCommand : Request<CreateTeamPlayerRequestViewModel>
{
    public override RequestId RequestId { get => RequestId.CreateTeamPlayerRequest; }

    public CreateTeamPlayerRequestDto Request { get; set; } = null!;

    public CreateTeamPlayerRequestCommand SetPlayerId(long playerId)
    {
        this.Request.PlayerId = playerId;
        return this;
    }

    public CreateTeamPlayerRequestCommand SetTeamId(long teamId)
    {
        this.Request.TeamId = teamId;
        return this;
    }
}