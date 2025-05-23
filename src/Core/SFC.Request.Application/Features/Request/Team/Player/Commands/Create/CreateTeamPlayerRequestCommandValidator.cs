using FluentValidation;

using SFC.Request.Application.Common.Constants;
using SFC.Request.Application.Common.Exceptions;
using SFC.Request.Application.Common.Extensions;
using SFC.Request.Application.Interfaces.Persistence.Repository.Player;
using SFC.Request.Application.Interfaces.Persistence.Repository.Request.Team.Player;
using SFC.Request.Application.Interfaces.Persistence.Repository.Team.General;
using SFC.Request.Application.Interfaces.Persistence.Repository.Team.Player;

namespace SFC.Request.Application.Features.Request.Team.Player.Commands.Create;
public class CreateTeamPlayerRequestCommandValidator : AbstractValidator<CreateTeamPlayerRequestCommand>
{
    private readonly ITeamRepository _teamRepository;
    private readonly IPlayerRepository _playerRepository;
    private readonly ITeamPlayerRequestRepository _teamPlayerRequestRepository;
    private readonly ITeamPlayerRepository _teamPlayerRepository;

    public CreateTeamPlayerRequestCommandValidator(
        ITeamRepository teamRepository,
        IPlayerRepository playerRepository,
        ITeamPlayerRequestRepository teamPlayerRequestRepository,
        ITeamPlayerRepository teamPlayerRepository)
    {
        _teamRepository = teamRepository;
        _playerRepository = playerRepository;
        _teamPlayerRequestRepository = teamPlayerRequestRepository;
        _teamPlayerRepository = teamPlayerRepository;

        SetRulesForRequest();
    }

    private void SetRulesForRequest()
    {
        RuleFor(p => p.Request.PlayerComment)
           .RequiredProperty(ValidationConstants.DescriptionValueMaxLength, "Comment")
           .OverridePropertyName("Request.Comment");

        RuleFor(invite => invite.Request)
        // team not found
            .MustAsync(async (request, cancellation) => await _teamRepository.AnyAsync(request.TeamId).ConfigureAwait(true))
            .WithException(new NotFoundException(Localization.TeamNotFound))
        // player not found
            .MustAsync(async (request, cancellation) => await _playerRepository.AnyAsync(request.PlayerId).ConfigureAwait(true))
            .WithException(new NotFoundException(Localization.PlayerNotFound))
            // player already in team
            .MustAsync(async (request, cancellation) => !await _teamPlayerRepository
                .AnyAsync(request.TeamId, request.PlayerId, TeamPlayerStatusEnum.Active).ConfigureAwait(false))
            .WithException(new ConflictException(Localization.PlayerAlreadyInTeam))
            // invite already exist
            .MustAsync(async (invite, cancellation) => !await _teamPlayerRequestRepository
                .AnyAsync(invite.TeamId, invite.PlayerId, RequestStatusEnum.Actual).ConfigureAwait(false))
            .WithException(new ConflictException(Localization.TeamPlayerRequestActiveAlreadyExist));
    }
}