using SFC.Request.Domain.Common;

namespace SFC.Request.Domain.Events.Game.General;
public class GamesCreatedEvent(IEnumerable<GameEntity> games) : BaseEvent
{
    public IEnumerable<GameEntity> GameTeams { get; } = games;
}