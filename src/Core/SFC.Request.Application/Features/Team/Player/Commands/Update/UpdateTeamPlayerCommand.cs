using SFC.Request.Application.Common.Dto.Team.Player;
using SFC.Request.Application.Common.Enums;
using SFC.Request.Application.Features.Common.Base;

namespace SFC.Request.Application.Features.Team.Player.Commands.Update;
public class UpdateTeamPlayerCommand : ParentRequest
{
    public override RequestId RequestId { get => RequestId.UpdateTeamPlayer; }

    public required TeamPlayerDto TeamPlayer { get; set; }
}