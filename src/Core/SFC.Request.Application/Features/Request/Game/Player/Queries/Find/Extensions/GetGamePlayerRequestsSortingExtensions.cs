using System.Linq.Expressions;

using SFC.Request.Application.Common.Dto.Player.General.Filters;
using SFC.Request.Application.Features.Common.Dto.Common;
using SFC.Request.Application.Features.Common.Extensions;
using SFC.Request.Application.Features.Common.Models.Find.Sorting;
using SFC.Request.Application.Features.Request.Game.Player.Queries.Find.Dto.Filters;
using SFC.Request.Domain.Entities.Player;
using SFC.Request.Domain.Entities.Request.Game.Player;

namespace SFC.Request.Application.Features.Request.Game.Player.Queries.Find.Extensions;
public static class GetGamePlayerRequestsSortingExtensions
{
    public static IEnumerable<Sorting<GamePlayerRequest, dynamic>> BuildGamePlayerRequestSorting(this IEnumerable<SortingDto> sorting)
        => sorting.BuildSearchSorting<GamePlayerRequest>(BuildGameSortingExpression);

    private static Expression<Func<GamePlayerRequest, dynamic>>? BuildGameSortingExpression(string name)
    {
        return name switch
        {
            $"{nameof(GetGamePlayerRequestsFilterDto.Request)}.{nameof(GetGamePlayerRequestsRequestFilterDto.Statuses)}" => p => p.StatusId,
            $"{nameof(GetGamePlayerRequestsFilterDto.Player)}.{nameof(PlayerGeneralProfile.FirstName)}" => p => p.Player.GeneralProfile.FirstName,
            $"{nameof(GetGamePlayerRequestsFilterDto.Player)}.{nameof(PlayerGeneralProfile.LastName)}" => p => p.Player.GeneralProfile.LastName,
            $"{nameof(GetGamePlayerRequestsFilterDto.Player)}.{nameof(PlayerFootballProfile.PhysicalCondition)}" => p => p.Player.FootballProfile.PhysicalCondition!,
            $"{nameof(GetGamePlayerRequestsFilterDto.Player)}.{nameof(PlayerFootballProfile.Height)}" => p => p.Player.FootballProfile.Height!,
            $"{nameof(GetGamePlayerRequestsFilterDto.Player)}.{nameof(PlayerFootballProfile.Weight)}" => p => p.Player.FootballProfile.Weight!,
            $"{nameof(GetGamePlayerRequestsFilterDto.Player)}.{nameof(PlayerStatsFilterDto.Raiting)}" => p => p.Player.Stats.Sum(m => m.Value),
            _ => null
        };
    }
}