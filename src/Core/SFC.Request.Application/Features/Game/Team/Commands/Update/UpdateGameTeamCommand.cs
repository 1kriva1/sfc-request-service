using SFC.Request.Application.Common.Dto.Game.Team;
using SFC.Request.Application.Common.Enums;

namespace SFC.Request.Application.Features.Game.Team.Commands.Update;
public class UpdateGameTeamCommand : ParentRequest
{
    public override RequestId RequestId { get => RequestId.UpdateGameTeam; }

    public required GameTeamDto GameTeam { get; set; }
}