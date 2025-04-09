using AutoMapper;

using MediatR;

using SFC.Request.Application.Interfaces.Persistence.Repository.Team.General;
using SFC.Request.Domain.Events.Team.General;

namespace SFC.Request.Application.Features.Team.General.Commands.CreateRange;
public class CreateTeamsCommandHandler(
    IMapper mapper,
    IMediator mediator,
    ITeamRepository teamRepository) : IRequestHandler<CreateTeamsCommand>
{
    private readonly IMapper _mapper = mapper;
    private readonly IMediator _mediator = mediator;
    private readonly ITeamRepository _teamRepository = teamRepository;

    public async Task Handle(CreateTeamsCommand request, CancellationToken cancellationToken)
    {
        IEnumerable<TeamEntity> teams = _mapper.Map<IEnumerable<TeamEntity>>(request.Teams);

        await _teamRepository.AddRangeIfNotExistsAsync([.. teams])
                               .ConfigureAwait(false);

        TeamsCreatedEvent @event = new(teams);

        await _mediator.Publish(@event, cancellationToken)
                       .ConfigureAwait(false);
    }
}