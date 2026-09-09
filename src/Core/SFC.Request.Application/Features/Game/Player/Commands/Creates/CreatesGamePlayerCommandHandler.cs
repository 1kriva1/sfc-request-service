using AutoMapper;

using MediatR;

using SFC.Request.Application.Interfaces.Persistence.Repository.Game.Player;
using SFC.Request.Domain.Entities.Game.Player;
using SFC.Request.Domain.Events.Game.Player;

namespace SFC.Request.Application.Features.Game.Player.Commands.Creates;

public class CreatesGamePlayerCommandHandler(
    IMapper mapper,
    IMediator mediator,
    IGamePlayerRepository gamePlayerRepository) : IRequestHandler<CreatesGamePlayerCommand>
{
    private readonly IMapper _mapper = mapper;
    private readonly IMediator _mediator = mediator;
    private readonly IGamePlayerRepository _gamePlayerRepository = gamePlayerRepository;

    public async Task Handle(CreatesGamePlayerCommand request, CancellationToken cancellationToken)
    {
        IEnumerable<GamePlayer> gamePlayers = _mapper.Map<IEnumerable<GamePlayer>>(request.GamePlayers);

        await _gamePlayerRepository.AddRangeIfNotExistsAsync([.. gamePlayers])
                               .ConfigureAwait(false);

        GamePlayersCreatedEvent @event = new(gamePlayers);

        await _mediator.Publish(@event, cancellationToken)
                       .ConfigureAwait(false);
    }
}