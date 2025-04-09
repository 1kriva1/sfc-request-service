using SFC.Request.Application.Common.Dto.Identity;
using SFC.Request.Application.Common.Enums;
using SFC.Request.Application.Features.Common.Base;

namespace SFC.Request.Application.Features.Identity.Commands.CreateRange;
public class CreateUsersCommand : ParentRequest
{
    public override RequestId RequestId { get => RequestId.CreateUsers; }

    public IEnumerable<UserDto> Users { get; set; } = null!;
}