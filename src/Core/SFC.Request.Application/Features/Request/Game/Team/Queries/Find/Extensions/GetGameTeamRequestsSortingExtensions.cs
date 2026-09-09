using System.Linq.Expressions;

using SFC.Request.Application.Features.Common.Dto.Common;
using SFC.Request.Application.Features.Common.Extensions;
using SFC.Request.Application.Features.Common.Models.Find.Sorting;
using SFC.Request.Application.Features.Request.Game.Team.Queries.Find.Dto.Filters;
using SFC.Request.Domain.Entities.Request.Game.Team;
using SFC.Request.Domain.Entities.Team.General;

namespace SFC.Request.Application.Features.Request.Game.Team.Queries.Find.Extensions;
public static class GetGameTeamRequestsSortingExtensions
{
    public static IEnumerable<Sorting<GameTeamRequest, dynamic>> BuildGameTeamRequestSorting(this IEnumerable<SortingDto> sorting)
        => sorting.BuildSearchSorting<GameTeamRequest>(BuildGameTeamRequestsSortingExpression);

    private static Expression<Func<GameTeamRequest, dynamic>>? BuildGameTeamRequestsSortingExpression(string name)
    {
        return name switch
        {
            $"{nameof(GetGameTeamRequestsFilterDto.Request)}.{nameof(GetGameTeamRequestsRequestFilterDto.Statuses)}" => p => p.StatusId,
            $"{nameof(GetGameTeamRequestsFilterDto.Team)}.{nameof(TeamGeneralProfile.Name)}" => p => p.Team.GeneralProfile.Name,
            $"{nameof(GetGameTeamRequestsFilterDto.Team)}.{nameof(TeamGeneralProfile.City)}" => p => p.Team.GeneralProfile.City,
            _ => null
        };
    }
}