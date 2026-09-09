using AutoMapper;

using Grpc.Core;

using MediatR;

using Microsoft.AspNetCore.Authorization;

using SFC.Request.Api.Infrastructure.Extensions;
using SFC.Request.Application.Features.Request.Game.Team.Queries.Find;
using SFC.Request.Application.Features.Request.Game.Team.Queries.Get;
using SFC.Request.Contracts.Headers;
using SFC.Request.Contracts.Messages.Request.Game.Team.Find;
using SFC.Request.Contracts.Messages.Request.Game.Team.Get;
using SFC.Request.Infrastructure.Constants;

using static SFC.Request.Contracts.Services.GameTeamRequestService;

namespace SFC.Request.Api.Services;

[Authorize(Policy.General)]
public class GameTeamRequestService(IMapper mapper, ISender mediator) : GameTeamRequestServiceBase
{
    public override async Task<GetGameTeamRequestResponse> GetGameTeamRequest(GetGameTeamRequestRequest request, ServerCallContext context)
    {
        GetGameTeamRequestQuery query = mapper.Map<GetGameTeamRequestQuery>(request);

        GetGameTeamRequestViewModel model = await mediator.Send(query).ConfigureAwait(true);

        context.AddAuditableHeaderIfRequested(mapper.Map<AuditableHeader>(model.Request));

        return mapper.Map<GetGameTeamRequestResponse>(model);
    }

    public override async Task<GetGameTeamRequestsResponse> GetGameTeamRequests(GetGameTeamRequestsRequest request, ServerCallContext context)
    {
        GetGameTeamRequestsQuery query = mapper.Map<GetGameTeamRequestsQuery>(request);

        GetGameTeamRequestsViewModel result = await mediator.Send(query).ConfigureAwait(true);

        context.AddPaginationHeader(mapper.Map<PaginationHeader>(result.Metadata));

        return mapper.Map<GetGameTeamRequestsResponse>(result);
    }
}