using AutoMapper;

using Grpc.Core;

using MediatR;

using Microsoft.AspNetCore.Authorization;

using SFC.Request.Application.Features.Request.Data.Queries.GetAll;
using SFC.Request.Contracts.Messages.Request.Data.GetAll;
using SFC.Request.Infrastructure.Constants;

using static SFC.Request.Contracts.Services.RequestDataService;

namespace SFC.Request.Api.Services;

[Authorize(Policy.General)]
public class RequestDataService(IMapper mapper, ISender mediator) : RequestDataServiceBase
{
    public override async Task<GetAllRequestDataResponse> GetAll(GetAllRequestDataRequest request, ServerCallContext context)
    {
        GetAllRequestDataQuery query = new();

        GetAllRequestDataViewModel model = await mediator.Send(query).ConfigureAwait(true);

        return mapper.Map<GetAllRequestDataResponse>(model);
    }
}