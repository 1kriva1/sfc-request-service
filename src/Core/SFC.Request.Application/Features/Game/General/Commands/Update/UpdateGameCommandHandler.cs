using AutoMapper;

using MediatR;

using SFC.Request.Application.Common.Constants;
using SFC.Request.Application.Common.Exceptions;
using SFC.Request.Application.Interfaces.Persistence.Repository.Game.General;

namespace SFC.Request.Application.Features.Game.General.Commands.Update;

public class UpdateGameCommandHandler(
    IMapper mapper,
    IGameRepository gameRepository) : IRequestHandler<UpdateGameCommand>
{
    private readonly IMapper _mapper = mapper;
    private readonly IGameRepository _gameRepository = gameRepository;

    public async Task Handle(UpdateGameCommand request, CancellationToken cancellationToken)
    {
        GameEntity game = await _gameRepository.GetByIdAsync(request.Game.Id).ConfigureAwait(true)
            ?? throw new NotFoundException(Localization.GameNotFound);

        GameEntity updatedGame = _mapper.Map(request.Game, game);

        await _gameRepository.UpdateAsync(updatedGame)
                               .ConfigureAwait(false);
    }
}