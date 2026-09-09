using AutoMapper;

using MediatR;

using SFC.Request.Application.Common.Constants;
using SFC.Request.Application.Common.Exceptions;
using SFC.Request.Application.Interfaces.Persistence.Repository.Request.Game.Team;
using SFC.Request.Domain.Entities.Request.Game.Team;

namespace SFC.Request.Application.Features.Request.Game.Team.Queries.Get;
public class GetGameTeamRequestQueryHandler(IMapper mapper, IGameTeamRequestRepository gameTeamRequestRepository)
    : IRequestHandler<GetGameTeamRequestQuery, GetGameTeamRequestViewModel>
{
    private readonly IMapper _mapper = mapper;
    private readonly IGameTeamRequestRepository _gameTeamRequestRepository = gameTeamRequestRepository;

    public async Task<GetGameTeamRequestViewModel> Handle(GetGameTeamRequestQuery request, CancellationToken cancellationToken)
    {
        GameTeamRequest Request = await _gameTeamRequestRepository
            .GetByIdAsync(request.Id, request.GameId, request.TeamId).ConfigureAwait(true)
                ?? throw new NotFoundException(Localization.RequestNotFound);

        return _mapper.Map<GetGameTeamRequestViewModel>(Request);
    }
}