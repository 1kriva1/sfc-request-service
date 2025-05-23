using AutoMapper;

using MediatR;

using SFC.Request.Application.Common.Constants;
using SFC.Request.Application.Common.Exceptions;
using SFC.Request.Application.Interfaces.Persistence.Repository.Request.Team.Player;
using SFC.Request.Domain.Entities.Request.Team.Player;

namespace SFC.Request.Application.Features.Request.Team.Player.Queries.Get;
public class GetTeamPlayerRequestQueryHandler(IMapper mapper, ITeamPlayerRequestRepository requestRepository)
    : IRequestHandler<GetTeamPlayerRequestQuery, GetTeamPlayerRequestViewModel>
{
    private readonly IMapper _mapper = mapper;
    private readonly ITeamPlayerRequestRepository _requestRepository = requestRepository;

    public async Task<GetTeamPlayerRequestViewModel> Handle(GetTeamPlayerRequestQuery request, CancellationToken cancellationToken)
    {
        TeamPlayerRequest requestEntity = await _requestRepository
            .GetByIdAsync(request.Id, request.TeamId, request.PlayerId).ConfigureAwait(true)
                ?? throw new NotFoundException(Localization.RequestNotFound);

        return _mapper.Map<GetTeamPlayerRequestViewModel>(requestEntity);
    }
}