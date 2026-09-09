using SFC.Request.Application.Common.Dto.Game.Player;
using SFC.Request.Application.Common.Enums;

namespace SFC.Request.Application.Features.Game.Player.Commands.Creates;
public class CreatesGamePlayerCommand : ParentRequest
{
    public override RequestId RequestId { get => RequestId.CreateGamePlayers; }

    public IEnumerable<GamePlayerDto> GamePlayers { get; set; } = null!;
}