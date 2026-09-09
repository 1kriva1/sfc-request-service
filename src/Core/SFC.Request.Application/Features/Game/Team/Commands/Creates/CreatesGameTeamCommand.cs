using SFC.Request.Application.Common.Dto.Game.Team;
using SFC.Request.Application.Common.Enums;

namespace SFC.Request.Application.Features.Game.Team.Commands.Creates;
public class CreatesGameTeamCommand : ParentRequest
{
    public override RequestId RequestId { get => RequestId.CreateGameTeams; }

    public IEnumerable<GameTeamDto> GameTeams { get; set; } = null!;
}