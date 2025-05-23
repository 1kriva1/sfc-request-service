using SFC.Request.Messages.Models.Request.Team.Player;

namespace SFC.Request.Messages.Events.Request.Team.Player;
public class TeamPlayerRequestsSeeded
{
    public IEnumerable<TeamPlayerRequest> Requests { get; init; } = [];
}