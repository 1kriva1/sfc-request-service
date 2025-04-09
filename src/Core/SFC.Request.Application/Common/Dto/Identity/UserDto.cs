using SFC.Request.Application.Common.Dto.Common;
using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Domain.Entities.Identity;

namespace SFC.Request.Application.Common.Dto.Identity;
public class UserDto : AuditableDto, IMapTo<User>
{
    public Guid Id { get; set; }
}