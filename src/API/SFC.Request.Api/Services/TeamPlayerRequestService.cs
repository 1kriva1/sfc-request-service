using AutoMapper;

using Grpc.Core;

using MediatR;

using Microsoft.AspNetCore.Authorization;

using SFC.Request.Api.Infrastructure.Extensions;
using SFC.Request.Application.Features.Request.Team.Player.Queries.Find;
using SFC.Request.Application.Features.Request.Team.Player.Queries.Get;
using SFC.Request.Contracts.Headers;
using SFC.Request.Contracts.Messages.Request.Team.Player.Find;
using SFC.Request.Contracts.Messages.Request.Team.Player.Get;
using SFC.Request.Infrastructure.Constants;

using static SFC.Request.Contracts.Services.TeamPlayerRequestService;

namespace SFC.Request.Api.Services;

[Authorize(Policy.General)]
public class TeamPlayerRequestService(IMapper mapper, ISender mediator) : TeamPlayerRequestServiceBase
{
    public override async Task<GetTeamPlayerRequestResponse> GetTeamPlayerRequest(GetTeamPlayerRequestRequest request, ServerCallContext context)
    {
        GetTeamPlayerRequestQuery query = mapper.Map<GetTeamPlayerRequestQuery>(request);

        GetTeamPlayerRequestViewModel model = await mediator.Send(query).ConfigureAwait(true);

        context.AddAuditableHeaderIfRequested(mapper.Map<AuditableHeader>(model.Request));

        return mapper.Map<GetTeamPlayerRequestResponse>(model);
    }

    public override async Task<GetTeamPlayerRequestsResponse> GetTeamPlayerRequests(GetTeamPlayerRequestsRequest request, ServerCallContext context)
    {
        GetTeamPlayerRequestsQuery query = mapper.Map<GetTeamPlayerRequestsQuery>(request);

        GetTeamPlayerRequestsViewModel result = await mediator.Send(query).ConfigureAwait(true);

        context.AddPaginationHeader(mapper.Map<PaginationHeader>(result.Metadata));

        return mapper.Map<GetTeamPlayerRequestsResponse>(result);
    }
}