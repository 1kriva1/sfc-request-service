using SFC.Request.Application.Common.Dto.Identity;
using SFC.Request.Application.Common.Enums;
using SFC.Request.Application.Features.Common.Base;

namespace SFC.Request.Application.Features.Identity.Commands.Create;
public class CreateUserCommand : ParentRequest
{
    public override RequestId RequestId { get => RequestId.CreateUser; }

    public UserDto User { get; set; } = null!;
}