using SFC.Request.Application.Common.Enums;
using SFC.Request.Application.Features.Common.Base;
using SFC.Request.Application.Features.Request.Queries.Find.Dto.Filters;

namespace SFC.Request.Application.Features.Request.Queries.Find;
public class GetRequestsQuery : BasePaginationRequest<GetRequestsViewModel, GetRequestsFilterDto>
{
    public override RequestId RequestId { get => RequestId.GetRequests; }
}