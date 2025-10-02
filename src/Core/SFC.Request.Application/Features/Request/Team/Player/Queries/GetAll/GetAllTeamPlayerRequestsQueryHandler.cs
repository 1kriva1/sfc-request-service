using AutoMapper;

using MediatR;

using SFC.Request.Application.Interfaces.Persistence.Repository.Request.Team.Player;
using SFC.Request.Domain.Entities.Request.Team.Player;

namespace SFC.Request.Application.Features.Request.Team.Player.Queries.GetAll;
public class GetAllTeamPlayerRequestsQueryHandler(IMapper mapper, ITeamPlayerRequestRepository teamPlayerRequestRepository)
    : IRequestHandler<GetAllTeamPlayerRequestsQuery, GetAllTeamPlayerRequestsViewModel>
{
    private readonly IMapper _mapper = mapper;
    private readonly ITeamPlayerRequestRepository _teamPlayerRequestRepository = teamPlayerRequestRepository;

    public async Task<GetAllTeamPlayerRequestsViewModel> Handle(GetAllTeamPlayerRequestsQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<TeamPlayerRequest> teamPlayerRequests = await _teamPlayerRequestRepository.ListAllAsync(request.TeamId).ConfigureAwait(true);
        return _mapper.Map<GetAllTeamPlayerRequestsViewModel>(teamPlayerRequests);
    }
}