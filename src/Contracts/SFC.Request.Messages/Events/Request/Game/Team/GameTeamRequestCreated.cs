using SFC.Request.Messages.Models.Request.Game.Team;

namespace SFC.Request.Messages.Events.Request.Game.Team;
public class GameTeamRequestCreated
{
    public required GameTeamRequest Request { get; set; }
}