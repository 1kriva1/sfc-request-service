using SFC.Request.Application.Common.Enums;
using SFC.Request.Application.Features.Common.Base;

namespace SFC.Request.Application.Features.Request.Game.Player.Queries.Get;

public class GetGamePlayerRequestQuery : Request<GetGamePlayerRequestViewModel>
{
    public override RequestId RequestId { get => RequestId.GetGamePlayerRequest; }

    public long Id { get; set; }

    public long GameId { get; set; }

    public long PlayerId { get; set; }
}