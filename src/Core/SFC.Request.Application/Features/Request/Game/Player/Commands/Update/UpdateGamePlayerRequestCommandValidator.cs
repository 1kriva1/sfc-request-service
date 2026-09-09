using FluentValidation;

using SFC.Request.Application.Common.Constants;
using SFC.Request.Application.Common.Exceptions;
using SFC.Request.Application.Common.Extensions;
using SFC.Request.Application.Interfaces.Persistence.Repository.Request.Game.Player;
using SFC.Request.Domain.Entities.Request.Game.Player;

namespace SFC.Request.Application.Features.Request.Game.Player.Commands.Update;
public class UpdateGamePlayerRequestCommandValidator : AbstractValidator<UpdateGamePlayerRequestCommand>
{
    private readonly IGamePlayerRequestRepository _gamePlayerRequestRepository;

    public UpdateGamePlayerRequestCommandValidator(IGamePlayerRequestRepository gamePlayerRequestRepository)
    {
        _gamePlayerRequestRepository = gamePlayerRequestRepository;

        SetRulesForRequest();
    }

    private void SetRulesForRequest()
    {
        RuleFor(request => request.Request)
            .MustAsync((request, cancellation) => IsRequestHasActualStatusAsync(request))
            .WithException(new ConflictException(Localization.RequestAlreadyFinalized));

        When(p => p.Request.Status == (int)RequestStatusEnum.Declined, () =>
        {
            RuleFor(p => p.Request.GameComment!)
                .RequiredProperty(ValidationConstants.DescriptionValueMaxLength, "Comment")
                .OverridePropertyName("Request.Comment");
        });
    }

    private async Task<bool> IsRequestHasActualStatusAsync(UpdateGamePlayerRequestDto request)
    {
        GamePlayerRequest? gamePlayerRequest = await _gamePlayerRequestRepository.GetByIdAsync(request.Id).ConfigureAwait(true);
        return gamePlayerRequest is null || gamePlayerRequest.StatusId == (int)RequestStatusEnum.Actual;
    }
}