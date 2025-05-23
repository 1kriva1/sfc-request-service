using SFC.Request.Application.Common.Enums;
using SFC.Request.Application.Features.Common.Base;

namespace SFC.Request.Application.Features.Request.Team.Player.Queries.Get;

public class GetTeamPlayerRequestQuery : Request<GetTeamPlayerRequestViewModel>
{
    public override RequestId RequestId { get => RequestId.GetTeamPlayerRequest; }

    public long Id { get; set; }

    public long TeamId { get; set; }

    public long PlayerId { get; set; }
}