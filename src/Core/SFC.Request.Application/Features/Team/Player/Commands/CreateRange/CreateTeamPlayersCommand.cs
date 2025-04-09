using SFC.Request.Application.Common.Dto.Team.Player;
using SFC.Request.Application.Common.Enums;
using SFC.Request.Application.Features.Common.Base;

namespace SFC.Request.Application.Features.Team.Player.Commands.CreateRange;
public class CreateTeamPlayersCommand : ParentRequest
{
    public override RequestId RequestId { get => RequestId.CreateTeamPlayers; }

    public IEnumerable<TeamPlayerDto> TeamPlayers { get; set; } = null!;
}