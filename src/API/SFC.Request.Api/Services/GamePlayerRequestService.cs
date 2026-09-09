using AutoMapper;

using Grpc.Core;

using MediatR;

using Microsoft.AspNetCore.Authorization;

using SFC.Request.Api.Infrastructure.Extensions;
using SFC.Request.Application.Features.Request.Game.Player.Queries.Find;
using SFC.Request.Application.Features.Request.Game.Player.Queries.Get;
using SFC.Request.Contracts.Headers;
using SFC.Request.Contracts.Messages.Request.Game.Player.Find;
using SFC.Request.Contracts.Messages.Request.Game.Player.Get;
using SFC.Request.Infrastructure.Constants;

using static SFC.Request.Contracts.Services.GamePlayerRequestService;

namespace SFC.Request.Api.Services;

[Authorize(Policy.General)]
public class GamePlayerRequestService(IMapper mapper, ISender mediator) : GamePlayerRequestServiceBase
{
    public override async Task<GetGamePlayerRequestResponse> GetGamePlayerRequest(GetGamePlayerRequestRequest request, ServerCallContext context)
    {
        GetGamePlayerRequestQuery query = mapper.Map<GetGamePlayerRequestQuery>(request);

        GetGamePlayerRequestViewModel model = await mediator.Send(query).ConfigureAwait(true);

        context.AddAuditableHeaderIfRequested(mapper.Map<AuditableHeader>(model.Request));

        return mapper.Map<GetGamePlayerRequestResponse>(model);
    }

    public override async Task<GetGamePlayerRequestsResponse> GetGamePlayerRequests(GetGamePlayerRequestsRequest request, ServerCallContext context)
    {
        GetGamePlayerRequestsQuery query = mapper.Map<GetGamePlayerRequestsQuery>(request);

        GetGamePlayerRequestsViewModel result = await mediator.Send(query).ConfigureAwait(true);

        context.AddPaginationHeader(mapper.Map<PaginationHeader>(result.Metadata));

        return mapper.Map<GetGamePlayerRequestsResponse>(result);
    }
}