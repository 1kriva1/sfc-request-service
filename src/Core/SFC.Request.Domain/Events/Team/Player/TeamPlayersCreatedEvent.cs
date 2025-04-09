using SFC.Request.Domain.Common;
using SFC.Request.Domain.Entities.Team.Player;

namespace SFC.Request.Domain.Events.Team.Player;
public class TeamPlayersCreatedEvent(IEnumerable<TeamPlayer> teamPlayers) : BaseEvent
{
    public IEnumerable<TeamPlayer> TeamPlayers { get; } = teamPlayers;
}