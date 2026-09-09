using AutoMapper;

using MediatR;

using SFC.Request.Application.Interfaces.Persistence.Repository.Request.Game.Team;
using SFC.Request.Domain.Entities.Request.Game.Team;

namespace SFC.Request.Application.Features.Request.Game.Team.Queries.Gets;
public class GetsGameTeamRequestQueryHandler(IMapper mapper, IGameTeamRequestRepository gameTeamRequestRepository)
    : IRequestHandler<GetsGameTeamRequestQuery, GetsGameTeamRequestViewModel>
{
    private readonly IMapper _mapper = mapper;
    private readonly IGameTeamRequestRepository _gameTeamRequestRepository = gameTeamRequestRepository;

    public async Task<GetsGameTeamRequestViewModel> Handle(GetsGameTeamRequestQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<GameTeamRequest> GameTeamRequests = await _gameTeamRequestRepository.ListAllAsync(request.GameId).ConfigureAwait(true);
        return _mapper.Map<GetsGameTeamRequestViewModel>(GameTeamRequests);
    }
}