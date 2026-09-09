using SFC.Request.Domain.Common;
using SFC.Request.Domain.Entities.Game.Player;

namespace SFC.Request.Domain.Events.Game.Player;
public class GamePlayersCreatedEvent(IEnumerable<GamePlayer> gamePlayers) : BaseEvent
{
    public IEnumerable<GamePlayer> GamePlayers { get; } = gamePlayers;
}