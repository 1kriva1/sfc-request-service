using SFC.Request.Application.Common.Dto.Game.General;
using SFC.Request.Application.Common.Enums;

namespace SFC.Request.Application.Features.Game.General.Commands.Update;
public class UpdateGameCommand : ParentRequest
{
    public override RequestId RequestId { get => RequestId.UpdateGame; }

    public GameDto Game { get; set; } = null!;
}