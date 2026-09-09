using AutoMapper;

using MediatR;

using SFC.Request.Application.Interfaces.Persistence.Repository.Game.General;
using SFC.Request.Domain.Events.Game.General;

namespace SFC.Request.Application.Features.Game.General.Commands.Creates;

public class CreatesGameCommandHandler(
    IMapper mapper,
    IMediator mediator,
    IGameRepository gameRepository) : IRequestHandler<CreatesGameCommand>
{
    private readonly IMapper _mapper = mapper;
    private readonly IMediator _mediator = mediator;
    private readonly IGameRepository _gameRepository = gameRepository;

    public async Task Handle(CreatesGameCommand request, CancellationToken cancellationToken)
    {
        IEnumerable<GameEntity> games = _mapper.Map<IEnumerable<GameEntity>>(request.Games);

        await _gameRepository.AddRangeIfNotExistsAsync([.. games])
                               .ConfigureAwait(false);

        GamesCreatedEvent @event = new(games);

        await _mediator.Publish(@event, cancellationToken)
                       .ConfigureAwait(false);
    }
}