using AutoMapper;

using MediatR;

using SFC.Request.Application.Interfaces.Persistence.Repository.Request.Team.Player;
using SFC.Request.Domain.Entities.Request.Team.Player;
using SFC.Request.Domain.Events.Request.Team.Player;

namespace SFC.Request.Application.Features.Request.Team.Player.Commands.Create;
public class CreateTeamPlayerRequestCommandHandler(
    IMapper mapper,
    ITeamPlayerRequestRepository requestRepository)
    : IRequestHandler<CreateTeamPlayerRequestCommand, CreateTeamPlayerRequestViewModel>
{
    private readonly IMapper _mapper = mapper;
    private readonly ITeamPlayerRequestRepository _requestRepository = requestRepository;

    public async Task<CreateTeamPlayerRequestViewModel> Handle(CreateTeamPlayerRequestCommand request, CancellationToken cancellationToken)
    {
        TeamPlayerRequest requestEntity = _mapper.Map<TeamPlayerRequest>(request.Request);

        requestEntity.AddDomainEvent(new TeamPlayerRequestCreatedEvent(requestEntity));

        await _requestRepository.AddAsync(requestEntity)
                                .ConfigureAwait(false);

        return _mapper.Map<CreateTeamPlayerRequestViewModel>(requestEntity);
    }
}