using AutoMapper;

using MediatR;

using SFC.Request.Application.Interfaces.Persistence.Repository.Player;
using SFC.Request.Domain.Events.Player;

namespace SFC.Request.Application.Features.Player.Commands.CreateRange;
public class CreatePlayersCommandHandler(
    IMapper mapper,
    IMediator mediator,
    IPlayerRepository playerRepository) : IRequestHandler<CreatePlayersCommand>
{
    private readonly IMapper _mapper = mapper;
    private readonly IMediator _mediator = mediator;
    private readonly IPlayerRepository _playerRepository = playerRepository;

    public async Task Handle(CreatePlayersCommand request, CancellationToken cancellationToken)
    {
        IEnumerable<PlayerEntity> players = _mapper.Map<IEnumerable<PlayerEntity>>(request.Players);

        await _playerRepository.AddRangeIfNotExistsAsync([.. players])
                               .ConfigureAwait(false);

        PlayersCreatedEvent @event = new(players);

        await _mediator.Publish(@event, cancellationToken)
                       .ConfigureAwait(false);
    }
}