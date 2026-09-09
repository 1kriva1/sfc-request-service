using SFC.Request.Application.Common.Dto.Game.Team;
using SFC.Request.Application.Common.Enums;

namespace SFC.Request.Application.Features.Game.Team.Commands.Create;
public class CreateGameTeamCommand : ParentRequest
{
    public override RequestId RequestId { get => RequestId.CreateGameTeam; }

    public required GameTeamDto GameTeam { get; set; }
}