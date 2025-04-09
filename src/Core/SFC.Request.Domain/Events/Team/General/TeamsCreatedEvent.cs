using SFC.Request.Domain.Common;

namespace SFC.Request.Domain.Events.Team.General;
public class TeamsCreatedEvent(IEnumerable<TeamEntity> teams) : BaseEvent
{
    public IEnumerable<TeamEntity> Teams { get; } = teams;
}