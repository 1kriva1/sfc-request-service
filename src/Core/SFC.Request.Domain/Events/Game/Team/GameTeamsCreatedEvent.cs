using SFC.Request.Domain.Common;
using SFC.Request.Domain.Entities.Game.Team;

namespace SFC.Request.Domain.Events.Game.Team;
public class GameTeamsCreatedEvent(IEnumerable<GameTeam> gameTeams) : BaseEvent
{
    public IEnumerable<GameTeam> GameTeams { get; } = gameTeams;
}