using AutoMapper;

using Grpc.Core;

using MediatR;

using Microsoft.AspNetCore.Authorization;

using SFC.Request.Api.Infrastructure.Extensions;
using SFC.Request.Application.Features.Request.Queries.Find;
using SFC.Request.Application.Features.Request.Queries.Get;
using SFC.Request.Contracts.Headers;
using SFC.Request.Contracts.Messages.Find;
using SFC.Request.Contracts.Messages.Get;
using SFC.Request.Infrastructure.Constants;

using static SFC.Request.Contracts.Services.RequestService;

namespace SFC.Request.Api.Services;

[Authorize(Policy.General)]
public class RequestService(IMapper mapper, ISender mediator) : RequestServiceBase
{
    public override async Task<GetRequestResponse> GetRequest(GetRequestRequest request, ServerCallContext context)
    {
        GetRequestQuery query = mapper.Map<GetRequestQuery>(request);

        GetRequestViewModel model = await mediator.Send(query).ConfigureAwait(true);

        context.AddAuditableHeaderIfRequested(mapper.Map<AuditableHeader>(model.Request));

        return mapper.Map<GetRequestResponse>(model);
    }

    public override async Task<GetRequestsResponse> GetRequests(GetRequestsRequest request, ServerCallContext context)
    {
        GetRequestsQuery query = mapper.Map<GetRequestsQuery>(request);

        GetRequestsViewModel result = await mediator.Send(query).ConfigureAwait(true);

        context.AddPaginationHeader(mapper.Map<PaginationHeader>(result.Metadata));

        return mapper.Map<GetRequestsResponse>(result);
    }
}