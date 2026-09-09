using SFC.Request.Application.Common.Dto.Game.Player;
using SFC.Request.Application.Common.Enums;

namespace SFC.Request.Application.Features.Game.Player.Commands.Update;
public class UpdateGamePlayerCommand : ParentRequest
{
    public override RequestId RequestId { get => RequestId.UpdateGamePlayer; }

    public required GamePlayerDto GamePlayer { get; set; }
}