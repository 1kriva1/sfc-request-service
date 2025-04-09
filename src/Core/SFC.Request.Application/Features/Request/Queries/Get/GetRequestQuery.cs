using SFC.Request.Application.Common.Enums;
using SFC.Request.Application.Features.Common.Base;

namespace SFC.Request.Application.Features.Request.Queries.Get;

public class GetRequestQuery : Request<GetRequestViewModel>
{
    public override RequestId RequestId { get => RequestId.GetRequest; }

    public long Id { get; set; }
}