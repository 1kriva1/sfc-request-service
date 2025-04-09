using AutoMapper;

using SFC.Request.Application.Common.Dto.Identity;
using SFC.Request.Application.Interfaces.Identity;
using SFC.Request.Application.Interfaces.Persistence.Repository.Identity;
using SFC.Request.Application.Interfaces.Reference;
using SFC.Request.Domain.Entities.Identity;

namespace SFC.Request.Infrastructure.Services.Reference;
public class IdentityReference(
    IMapper mapper,
    IUserRepository userRepository,
    IIdentityService identityService) : BaseReference<User, Guid, UserDto>(mapper), IIdentityReference
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IIdentityService _identityService = identityService;

    protected override Task<User?> GetFromLocalAsync(Guid id, CancellationToken cancellationToken = default)
        => _userRepository.GetByIdAsync(id);

    protected override Task<UserDto?> GetFromReferenceAsync(Guid id, CancellationToken cancellationToken = default)
        => _identityService.GetUserAsync(id, cancellationToken);

    protected override Task<User> AddLocalAsync(User entity, CancellationToken cancellationToken = default)
        => _userRepository.AddAsync(entity);
}