using SFC.Request.Application.Common.Enums;
using SFC.Request.Application.Features.Common.Base;

namespace SFC.Request.Application.Features.Request.Data.Queries.GetAll;

public class GetAllRequestDataQuery : Request<GetAllRequestDataViewModel>
{
    public override RequestId RequestId { get => RequestId.GetAllRequestData; }
}