using SFC.Request.Application.Common.Dto.Team.General;
using SFC.Request.Application.Common.Enums;
using SFC.Request.Application.Features.Common.Base;

namespace SFC.Request.Application.Features.Team.General.Commands.Update;
public class UpdateTeamCommand : ParentRequest
{
    public override RequestId RequestId { get => RequestId.UpdateTeam; }

    public TeamDto Team { get; set; } = null!;
}