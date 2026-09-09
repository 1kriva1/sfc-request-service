using FluentValidation;

using SFC.Request.Application.Common.Constants;
using SFC.Request.Application.Common.Exceptions;
using SFC.Request.Application.Common.Extensions;
using SFC.Request.Application.Interfaces.Persistence.Repository.Game.General;
using SFC.Request.Application.Interfaces.Persistence.Repository.Game.Player;
using SFC.Request.Application.Interfaces.Persistence.Repository.Player;
using SFC.Request.Application.Interfaces.Persistence.Repository.Request.Game.Player;

namespace SFC.Request.Application.Features.Request.Game.Player.Commands.Create;
public class CreateGamePlayerRequestCommandValidator : AbstractValidator<CreateGamePlayerRequestCommand>
{
    private readonly IGameRepository _gameRepository;
    private readonly IPlayerRepository _playerRepository;
    private readonly IGamePlayerRequestRepository _gamePlayerRequestRepository;
    private readonly IGamePlayerRepository _gamePlayerRepository;

    public CreateGamePlayerRequestCommandValidator(
        IGameRepository gameRepository,
        IPlayerRepository playerRepository,
        IGamePlayerRequestRepository gamePlayerRequestRepository,
        IGamePlayerRepository gamePlayerRepository)
    {
        _gameRepository = gameRepository;
        _playerRepository = playerRepository;
        _gamePlayerRequestRepository = gamePlayerRequestRepository;
        _gamePlayerRepository = gamePlayerRepository;

        SetRulesForRequest();
    }

    private void SetRulesForRequest()
    {
        RuleFor(p => p.Request.PlayerComment)
           .RequiredProperty(ValidationConstants.DescriptionValueMaxLength, "Comment")
           .OverridePropertyName("Request.Comment");

        RuleFor(request => request.Request)
            // Game not found
            .MustAsync(async (request, cancellation) => await _gameRepository.AnyAsync(request.GameId).ConfigureAwait(true))
            .WithException(new NotFoundException(Localization.GameNotFound))
            // player not found
            .MustAsync(async (request, cancellation) => await _playerRepository.AnyAsync(request.PlayerId).ConfigureAwait(true))
            .WithException(new NotFoundException(Localization.PlayerNotFound))
            // player already in Game
            .MustAsync(async (request, cancellation) => !await _gamePlayerRepository
                .AnyAsync(request.GameId, request.PlayerId).ConfigureAwait(false))
            .WithException(new ConflictException(Localization.PlayerAlreadyInGame))
            // request already exist
            .MustAsync(async (request, cancellation) => !await _gamePlayerRequestRepository
                .AnyAsync(request.GameId, request.PlayerId, RequestStatusEnum.Actual).ConfigureAwait(false))
            .WithException(new ConflictException(Localization.GamePlayerRequestActiveAlreadyExist));
    }
}