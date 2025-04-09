using SFC.Request.Domain.Common;
using SFC.Request.Domain.Entities.Team.Data;

namespace SFC.Request.Domain.Events.Team.Data;

public class TeamDataResetedEvent(IEnumerable<TeamPlayerStatus> teamPlayerStatuses) : BaseEvent
{
    public IEnumerable<TeamPlayerStatus> TeamPlayerStatuses { get; } = teamPlayerStatuses;
}