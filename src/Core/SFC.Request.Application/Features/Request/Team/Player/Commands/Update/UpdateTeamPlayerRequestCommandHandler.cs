using AutoMapper;

using MediatR;

using SFC.Request.Application.Common.Constants;
using SFC.Request.Application.Common.Exceptions;
using SFC.Request.Application.Interfaces.Persistence.Repository.Request.Team.Player;
using SFC.Request.Domain.Entities.Request.Team.Player;
using SFC.Request.Domain.Events.Request.Team.Player;

namespace SFC.Request.Application.Features.Request.Team.Player.Commands.Update;
public class UpdateTeamPlayerRequestCommandHandler(IMapper mapper, ITeamPlayerRequestRepository requestRepository)
    : IRequestHandler<UpdateTeamPlayerRequestCommand>
{
    private readonly IMapper _mapper = mapper;
    private readonly ITeamPlayerRequestRepository _requestRepository = requestRepository;

    public async Task Handle(UpdateTeamPlayerRequestCommand request, CancellationToken cancellationToken)
    {
        TeamPlayerRequest requestEntity = await _requestRepository
            .GetByIdAsync(request.Request.Id, request.Request.TeamId, request.Request.PlayerId).ConfigureAwait(true)
                ?? throw new NotFoundException(Localization.RequestNotFound);

        TeamPlayerRequest updatedRequestEntity = _mapper.Map(request.Request, requestEntity);

        updatedRequestEntity.AddDomainEvent(new TeamPlayerRequestUpdatedEvent(updatedRequestEntity));

        await _requestRepository.UpdateAsync(updatedRequestEntity)
                                .ConfigureAwait(false);
    }
}