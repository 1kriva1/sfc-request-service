using SFC.Request.Application.Common.Enums;
using SFC.Request.Application.Features.Common.Base;
using SFC.Request.Application.Features.Team.Data.Common.Dto;

namespace SFC.Request.Application.Features.Team.Data.Commands.Reset;
public class ResetTeamDataCommand : ParentRequest
{
    public override RequestId RequestId { get => RequestId.ResetTeamData; }

    public IEnumerable<TeamPlayerStatusDto> TeamPlayerStatuses { get; init; } = [];
}