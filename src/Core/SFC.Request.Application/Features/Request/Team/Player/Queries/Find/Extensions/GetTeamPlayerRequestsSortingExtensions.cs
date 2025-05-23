using System.Linq.Expressions;

using SFC.Request.Application.Common.Dto.Player.Filters;
using SFC.Request.Application.Features.Common.Dto.Common;
using SFC.Request.Application.Features.Common.Extensions;
using SFC.Request.Application.Features.Common.Models.Find.Sorting;
using SFC.Request.Application.Features.Request.Team.Player.Queries.Find.Dto.Filters;
using SFC.Request.Domain.Entities.Player;
using SFC.Request.Domain.Entities.Request.Team.Player;

namespace SFC.Request.Application.Features.Request.Team.Player.Queries.Find.Extensions;
public static class GetTeamPlayerRequestsSortingExtensions
{
    public static IEnumerable<Sorting<TeamPlayerRequest, dynamic>> BuildRequestSearchSorting(this IEnumerable<SortingDto> sorting)
        => sorting.BuildSearchSorting(BuildExpression);

    private static Expression<Func<TeamPlayerRequest, dynamic>>? BuildExpression(string name)
    {
        return name switch
        {
            $"{nameof(GetTeamPlayerRequestsFilterDto.Request)}.{nameof(GetTeamPlayerRequestsRequestFilterDto.Statuses)}" => p => p.StatusId,
            $"{nameof(GetTeamPlayerRequestsFilterDto.Player)}.{nameof(PlayerGeneralProfile.FirstName)}" => p => p.Player.GeneralProfile.FirstName,
            $"{nameof(GetTeamPlayerRequestsFilterDto.Player)}.{nameof(PlayerGeneralProfile.LastName)}" => p => p.Player.GeneralProfile.LastName,
            $"{nameof(GetTeamPlayerRequestsFilterDto.Player)}.{nameof(PlayerFootballProfile.PhysicalCondition)}" => p => p.Player.FootballProfile.PhysicalCondition!,
            $"{nameof(GetTeamPlayerRequestsFilterDto.Player)}.{nameof(PlayerFootballProfile.Height)}" => p => p.Player.FootballProfile.Height!,
            $"{nameof(GetTeamPlayerRequestsFilterDto.Player)}.{nameof(PlayerFootballProfile.Weight)}" => p => p.Player.FootballProfile.Weight!,
            $"{nameof(GetTeamPlayerRequestsFilterDto.Player)}.{nameof(PlayerStatsFilterDto.Raiting)}" => p => p.Player.Stats.Sum(m => m.Value),
            _ => null
        };
    }
}