using AutoMapper;

using MediatR;

using SFC.Request.Application.Common.Constants;
using SFC.Request.Application.Common.Exceptions;
using SFC.Request.Application.Interfaces.Persistence.Repository.Game.Player;
using SFC.Request.Domain.Entities.Game.Player;

namespace SFC.Request.Application.Features.Game.Player.Commands.Update;
public class UpdateGamePlayerHandler(IMapper mapper, IGamePlayerRepository gamePlayerRepository)
    : IRequestHandler<UpdateGamePlayerCommand>
{
    private readonly IMapper _mapper = mapper;
    private readonly IGamePlayerRepository _gamePlayerRepository = gamePlayerRepository;

    public async Task Handle(UpdateGamePlayerCommand request, CancellationToken cancellationToken)
    {
        GamePlayer gamePlayer = await _gamePlayerRepository
            .GetByIdAsync(request.GamePlayer.GameId, request.GamePlayer.PlayerId).ConfigureAwait(true)
                ?? throw new NotFoundException(Localization.GamePlayerNotFound);

        GamePlayer updatedGamePlayer = _mapper.Map(request.GamePlayer, gamePlayer);

        await _gamePlayerRepository.UpdateAsync(updatedGamePlayer)
                                   .ConfigureAwait(false);
    }
}