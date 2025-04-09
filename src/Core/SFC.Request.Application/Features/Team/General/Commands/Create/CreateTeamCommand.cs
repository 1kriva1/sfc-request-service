using SFC.Request.Application.Common.Dto.Team.General;
using SFC.Request.Application.Common.Enums;
using SFC.Request.Application.Features.Common.Base;

namespace SFC.Request.Application.Features.Team.General.Commands.Create;
public class CreateTeamCommand : ParentRequest
{
    public override RequestId RequestId { get => RequestId.CreateTeam; }

    public TeamDto Team { get; set; } = null!;
}