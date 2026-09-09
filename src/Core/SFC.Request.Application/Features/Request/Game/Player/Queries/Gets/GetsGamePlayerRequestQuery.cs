using SFC.Request.Application.Common.Enums;
using SFC.Request.Application.Features.Common.Base;

namespace SFC.Request.Application.Features.Request.Game.Player.Queries.Gets;

public class GetsGamePlayerRequestQuery : Request<GetsGamePlayerRequestViewModel>
{
    public override RequestId RequestId { get => RequestId.GetsGamePlayerRequest; }

    public long GameId { get; set; }
}