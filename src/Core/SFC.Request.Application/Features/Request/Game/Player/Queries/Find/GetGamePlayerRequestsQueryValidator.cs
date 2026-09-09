using FluentValidation;

using SFC.Request.Application.Features.Common.Validators.Common;
using SFC.Request.Application.Features.Common.Validators.Player;
using SFC.Request.Application.Features.Request.Game.Player.Queries.Find.Dto.Filters;

namespace SFC.Request.Application.Features.Request.Game.Player.Queries.Find;
public class GetGamePlayerRequestsQueryValidator : AbstractValidator<GetGamePlayerRequestsQuery>
{
    public GetGamePlayerRequestsQueryValidator()
    {
        // pagination request filter
        RuleFor(command => command)
            .SetValidator(new PaginationRequestValidator<GetGamePlayerRequestsViewModel, GetGamePlayerRequestsFilterDto>());

        // player filter
        When(p => p?.Filter?.Player != null, () =>
        {
            RuleFor(command => command.Filter.Player!)
                .SetValidator(new PlayerFilterValidator());
        });
    }
}