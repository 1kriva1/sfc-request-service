using SFC.Request.Application.Common.Enums;
using SFC.Request.Application.Features.Common.Base;
using SFC.Request.Application.Features.Request.Game.Player.Queries.Find.Dto.Filters;

namespace SFC.Request.Application.Features.Request.Game.Player.Queries.Find;
public class GetGamePlayerRequestsQuery : BasePaginationRequest<GetGamePlayerRequestsViewModel, GetGamePlayerRequestsFilterDto>
{
    public override RequestId RequestId { get => RequestId.GetGamePlayerRequests; }

    public GetGamePlayerRequestsQuery SetGameId(long gameId)
    {
        Filter = Filter ?? new GetGamePlayerRequestsFilterDto();

        Filter.GameId = gameId;

        return this;
    }
}