using AutoMapper;

using MediatR;

using SFC.Request.Application.Interfaces.Persistence.Repository.Game.General;

namespace SFC.Request.Application.Features.Game.General.Commands.Create;

public class CreateGameCommandHandler(
    IMapper mapper,
    IGameRepository gameRepository) : IRequestHandler<CreateGameCommand>
{
    private readonly IMapper _mapper = mapper;
    private readonly IGameRepository _gameRepository = gameRepository;

    public async Task Handle(CreateGameCommand request, CancellationToken cancellationToken)
    {
        GameEntity game = _mapper.Map<GameEntity>(request.Game);

        await _gameRepository.AddAsync(game)
                             .ConfigureAwait(false);
    }
}