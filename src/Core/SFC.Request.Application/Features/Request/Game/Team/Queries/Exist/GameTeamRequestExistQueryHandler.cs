using AutoMapper;

using MediatR;

using SFC.Request.Application.Interfaces.Persistence.Repository.Request.Game.Team;

namespace SFC.Request.Application.Features.Request.Game.Team.Queries.Exist;
public class GameTeamRequestExistQueryHandler(IMapper mapper, IGameTeamRequestRepository gameTeamRequestRepository)
    : IRequestHandler<GameTeamRequestExistQuery, GameTeamRequestExistViewModel>
{
    private readonly IMapper _mapper = mapper;
    private readonly IGameTeamRequestRepository _gameTeamRequestRepository = gameTeamRequestRepository;

    public async Task<GameTeamRequestExistViewModel> Handle(GameTeamRequestExistQuery request, CancellationToken cancellationToken)
    {
        bool exist = await _gameTeamRequestRepository.AnyAsync(request.GameId, request.TeamId, request.Status).ConfigureAwait(true);
        return _mapper.Map<GameTeamRequestExistViewModel>(exist);
    }
}