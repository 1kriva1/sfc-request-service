using FluentValidation;

using SFC.Request.Application.Features.Common.Validators.Common;
using SFC.Request.Application.Features.Common.Validators.Player;
using SFC.Request.Application.Features.Request.Team.Player.Queries.Find.Dto.Filters;

namespace SFC.Request.Application.Features.Request.Team.Player.Queries.Find;
public class GetTeamPlayerRequestsQueryValidator : AbstractValidator<GetTeamPlayerRequestsQuery>
{
    public GetTeamPlayerRequestsQueryValidator()
    {
        // pagination request validation
        RuleFor(command => command)
            .SetValidator(new PaginationRequestValidator<GetTeamPlayerRequestsViewModel, GetTeamPlayerRequestsFilterDto>());

        // player filter
        When(p => p?.Filter?.Player != null, () =>
        {
            RuleFor(command => command.Filter.Player!)
                .SetValidator(new PlayerFilterValidator());
        });
    }
}