using SFC.Request.Messages.Models.Request.Game.Player;

namespace SFC.Request.Messages.Events.Request.Game.Player;
public class GamePlayerRequestsSeeded
{
    public IEnumerable<GamePlayerRequest> GamePlayerRequests { get; init; } = [];
}