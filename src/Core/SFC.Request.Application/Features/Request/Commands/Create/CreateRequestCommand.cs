using SFC.Request.Application.Common.Enums;
using SFC.Request.Application.Features.Common.Base;
using SFC.Request.Application.Features.Request.Common.Dto;

namespace SFC.Request.Application.Features.Request.Commands.Create;
public class CreateRequestCommand : Request<CreateRequestViewModel>
{
    public override RequestId RequestId { get => RequestId.CreateRequest; }

    public CreateRequestDto Request { get; set; } = null!;
}