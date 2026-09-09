using SFC.Request.Domain.Common;
using SFC.Request.Domain.Entities.Request.Game.Team;

namespace SFC.Request.Domain.Events.Request.Game.Team;
public class GameTeamRequestCreatedEvent(GameTeamRequest entity) : BaseEvent
{
    public GameTeamRequest Request { get; } = entity;
}