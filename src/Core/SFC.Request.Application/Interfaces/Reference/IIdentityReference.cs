using SFC.Request.Application.Common.Dto.Identity;
using SFC.Request.Domain.Entities.Identity;

namespace SFC.Request.Application.Interfaces.Reference;

/// <summary>
/// Identity user reference service.
/// </summary>
public interface IIdentityReference : IReference<User, Guid, UserDto> { }