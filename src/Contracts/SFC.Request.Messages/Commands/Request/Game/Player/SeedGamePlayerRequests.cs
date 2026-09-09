using SFC.Request.Messages.Commands.Common;
using SFC.Request.Messages.Models.Request.Game.Player;

namespace SFC.Request.Messages.Commands.Request.Game.Player;
public class SeedGamePlayerRequests : InitiatorCommand
{
    public IEnumerable<GamePlayerRequest> GamePlayerRequests { get; init; } = [];
}