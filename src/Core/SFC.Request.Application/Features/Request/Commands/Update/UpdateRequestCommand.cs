using SFC.Request.Application.Common.Enums;
using SFC.Request.Application.Features.Common.Base;

namespace SFC.Request.Application.Features.Request.Commands.Update;
public class UpdateRequestCommand : ParentRequest
{
    public override RequestId RequestId { get => RequestId.UpdateRequest; }

    public long Id { get; set; }

    public required UpdateRequestDto Request { get; set; }

    public UpdateRequestCommand SetRequestId(long id)
    {
        Id = id;
        return this;
    }
}