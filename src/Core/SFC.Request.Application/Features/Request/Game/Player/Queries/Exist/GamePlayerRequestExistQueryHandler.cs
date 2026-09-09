using AutoMapper;

using MediatR;

using SFC.Request.Application.Interfaces.Persistence.Repository.Request.Game.Player;

namespace SFC.Request.Application.Features.Request.Game.Player.Queries.Exist;
public class GamePlayerRequestExistQueryHandler(IMapper mapper, IGamePlayerRequestRepository gamePlayerRequestRepository)
    : IRequestHandler<GamePlayerRequestExistQuery, GamePlayerRequestExistViewModel>
{
    private readonly IMapper _mapper = mapper;
    private readonly IGamePlayerRequestRepository _gamePlayerRequestRepository = gamePlayerRequestRepository;

    public async Task<GamePlayerRequestExistViewModel> Handle(GamePlayerRequestExistQuery request, CancellationToken cancellationToken)
    {
        bool exist = await _gamePlayerRequestRepository.AnyAsync(request.GameId, request.PlayerId, request.Status).ConfigureAwait(true);
        return _mapper.Map<GamePlayerRequestExistViewModel>(exist);
    }
}