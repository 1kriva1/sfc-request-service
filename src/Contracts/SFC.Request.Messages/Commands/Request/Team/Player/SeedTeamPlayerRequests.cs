using SFC.Request.Messages.Commands.Common;
using SFC.Request.Messages.Models.Request.Team.Player;

namespace SFC.Request.Messages.Commands.Request.Team.Player;
public class SeedTeamPlayerRequests : InitiatorCommand
{
    public IEnumerable<RequestEntity> Requests { get; init; } = [];
}