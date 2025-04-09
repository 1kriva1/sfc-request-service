﻿using AutoMapper;

using MediatR;

using SFC.Request.Application.Common.Constants;
using SFC.Request.Application.Common.Exceptions;
using SFC.Request.Application.Interfaces.Persistence.Repository.Team.General;

namespace SFC.Request.Application.Features.Team.General.Commands.Update;

public class UpdateTeamCommandHandler(
    IMapper mapper,
    ITeamRepository teamRepository) : IRequestHandler<UpdateTeamCommand>
{
    private readonly IMapper _mapper = mapper;
    private readonly ITeamRepository _teamRepository = teamRepository;

    public async Task Handle(UpdateTeamCommand request, CancellationToken cancellationToken)
    {
        TeamEntity team = await _teamRepository.GetByIdAsync(request.Team.Id).ConfigureAwait(true)
            ?? throw new NotFoundException(Localization.TeamNotFound);

        TeamEntity updatedTeam = _mapper.Map(request.Team, team);

        await _teamRepository.UpdateAsync(updatedTeam)
                             .ConfigureAwait(false);
    }
}