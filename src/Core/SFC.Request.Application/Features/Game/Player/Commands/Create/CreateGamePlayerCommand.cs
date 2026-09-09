using SFC.Request.Application.Common.Dto.Game.Player;
using SFC.Request.Application.Common.Enums;

namespace SFC.Request.Application.Features.Game.Player.Commands.Create;
public class CreateGamePlayerCommand : ParentRequest
{
    public override RequestId RequestId { get => RequestId.CreateGamePlayer; }

    public required GamePlayerDto GamePlayer { get; set; }
}