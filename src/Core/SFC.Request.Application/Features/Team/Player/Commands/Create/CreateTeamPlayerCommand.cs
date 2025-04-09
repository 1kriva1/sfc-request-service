using SFC.Request.Application.Common.Dto.Team.Player;
using SFC.Request.Application.Common.Enums;
using SFC.Request.Application.Features.Common.Base;

namespace SFC.Request.Application.Features.Team.Player.Commands.Create;
public class CreateTeamPlayerCommand : ParentRequest
{
    public override RequestId RequestId { get => RequestId.CreateTeamPlayer; }

    public required TeamPlayerDto TeamPlayer { get; set; }
}