using SFC.Request.Application.Common.Enums;
using SFC.Request.Application.Features.Common.Base;

namespace SFC.Request.Application.Features.Request.Team.Player.Queries.GetAll;

public class GetAllTeamPlayerRequestsQuery : Request<GetAllTeamPlayerRequestsViewModel>
{
    public override RequestId RequestId { get => RequestId.GetAllTeamPlayerRequests; }

    public long TeamId { get; set; }
}