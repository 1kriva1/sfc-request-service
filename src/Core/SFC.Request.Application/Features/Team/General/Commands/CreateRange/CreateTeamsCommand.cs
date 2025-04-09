using SFC.Request.Application.Common.Dto.Team.General;
using SFC.Request.Application.Common.Enums;
using SFC.Request.Application.Features.Common.Base;

namespace SFC.Request.Application.Features.Team.General.Commands.CreateRange;
public class CreateTeamsCommand : ParentRequest
{
    public override RequestId RequestId { get => RequestId.CreateTeams; }

    public IEnumerable<TeamDto> Teams { get; set; } = null!;
}