using AutoMapper;

using MediatR;

using SFC.Request.Application.Interfaces.Persistence.Repository.Identity;
using SFC.Request.Domain.Entities.Identity;
using SFC.Request.Domain.Events.Identity;

namespace SFC.Request.Application.Features.Identity.Commands.CreateRange;
public class CreateUsersCommandHandler(IMapper mapper, IMediator mediator, IUserRepository userRepository)
    : IRequestHandler<CreateUsersCommand>
{
    private readonly IMapper _mapper = mapper;
    private readonly IMediator _mediator = mediator;
    private readonly IUserRepository _userRepository = userRepository;

    public async Task Handle(CreateUsersCommand request, CancellationToken cancellationToken)
    {
        IEnumerable<User> users = _mapper.Map<IEnumerable<User>>(request.Users);

        await _userRepository.AddRangeIfNotExistsAsync([.. users]).ConfigureAwait(false);

        await PublishUsersCreatedEventAsync(users, cancellationToken).ConfigureAwait(false);
    }

    private Task PublishUsersCreatedEventAsync(IEnumerable<User> users, CancellationToken cancellationToken)
    {
        UsersCreatedEvent @event = new(users);
        return _mediator.Publish(@event, cancellationToken);
    }
}