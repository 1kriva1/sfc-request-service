using SFC.Request.Domain.Common;
using SFC.Request.Domain.Entities.Request.Game.Player;

namespace SFC.Request.Domain.Events.Request.Game.Player;
public class GamePlayerRequestCreatedEvent(GamePlayerRequest entity) : BaseEvent
{
    public GamePlayerRequest Request { get; } = entity;
}