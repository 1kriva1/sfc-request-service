using SFC.Request.Application.Common.Dto.Game.General;
using SFC.Request.Application.Common.Enums;

namespace SFC.Request.Application.Features.Game.General.Commands.Create;
public class CreateGameCommand : ParentRequest
{
    public override RequestId RequestId { get => RequestId.CreateGame; }

    public GameDto Game { get; set; } = null!;
}