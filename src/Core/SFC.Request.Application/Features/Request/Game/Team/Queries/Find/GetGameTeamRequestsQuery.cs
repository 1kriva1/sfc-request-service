using SFC.Request.Application.Common.Enums;
using SFC.Request.Application.Features.Common.Base;
using SFC.Request.Application.Features.Request.Game.Team.Queries.Find.Dto.Filters;

namespace SFC.Request.Application.Features.Request.Game.Team.Queries.Find;
public class GetGameTeamRequestsQuery : BasePaginationRequest<GetGameTeamRequestsViewModel, GetGameTeamRequestsFilterDto>
{
    public override RequestId RequestId { get => RequestId.GetGameTeamRequests; }

    public GetGameTeamRequestsQuery SetGameId(long gameId)
    {
        Filter = Filter ?? new GetGameTeamRequestsFilterDto();

        Filter.GameId = gameId;

        return this;
    }
}