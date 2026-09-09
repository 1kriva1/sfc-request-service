using AutoMapper;

using MediatR;

using SFC.Request.Application.Interfaces.Persistence.Repository.Game.Player;
using SFC.Request.Domain.Entities.Game.Player;

namespace SFC.Request.Application.Features.Game.Player.Commands.Create;
public class CreateGamePlayerHandler(
    IMapper mapper,
    IGamePlayerRepository gamePlayerRepository)
    : IRequestHandler<CreateGamePlayerCommand>
{
    private readonly IMapper _mapper = mapper;
    private readonly IGamePlayerRepository _gamePlayerRepository = gamePlayerRepository;

    public async Task Handle(CreateGamePlayerCommand request, CancellationToken cancellationToken)
    {
        GamePlayer gamePlayer = _mapper.Map<GamePlayer>(request.GamePlayer);

        await _gamePlayerRepository.AddAsync(gamePlayer)
                                   .ConfigureAwait(true);
    }
}