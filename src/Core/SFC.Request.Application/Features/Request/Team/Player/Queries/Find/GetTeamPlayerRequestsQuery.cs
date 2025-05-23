using SFC.Request.Application.Common.Enums;
using SFC.Request.Application.Features.Common.Base;
using SFC.Request.Application.Features.Request.Team.Player.Queries.Find.Dto.Filters;

namespace SFC.Request.Application.Features.Request.Team.Player.Queries.Find;
public class GetTeamPlayerRequestsQuery : BasePaginationRequest<GetTeamPlayerRequestsViewModel, GetTeamPlayerRequestsFilterDto>
{
    public override RequestId RequestId { get => RequestId.GetTeamPlayerRequests; }
}