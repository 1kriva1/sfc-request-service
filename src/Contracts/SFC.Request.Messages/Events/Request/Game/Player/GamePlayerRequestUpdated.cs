using SFC.Request.Messages.Models.Request.Game.Player;

namespace SFC.Request.Messages.Events.Request.Game.Player;
public class GamePlayerRequestUpdated
{
    public required GamePlayerRequest Request { get; set; }
}