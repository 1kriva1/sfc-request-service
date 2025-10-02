using System.Linq.Expressions;

using SFC.Request.Application.Common.Constants;
using SFC.Request.Application.Features.Common.Constants;
using SFC.Request.Application.Features.Common.Extensions;
using SFC.Request.Application.Features.Common.Models.Find.Filters;
using SFC.Request.Application.Features.Request.Team.Player.Queries.Find.Dto.Filters;
using SFC.Request.Domain.Entities.Request.Team.Player;

namespace SFC.Request.Application.Features.Request.Team.Player.Queries.Find.Extensions;
public static class GetTeamPlayerRequestsFiltersExtensions
{
    public static IEnumerable<Filter<TeamPlayerRequest>> BuildSearchFilters(this GetTeamPlayerRequestsFilterDto filter, DateTime now)
    {
        return [
            // team
            new()
            {
                Condition = true,
                Expression = invite => invite.TeamId == filter!.TeamId
            },
            // request
            new()
            {
                Condition = filter?.Request?.Statuses?.Any() ?? false,
                Expression = invite => filter!.Request!.Statuses!.Contains((int)invite.StatusId)
            },
            // player
            new()
            {
                Condition = !string.IsNullOrEmpty(filter?.Player?.Profile?.General?.Name),
                Expression = player => player.Player.GeneralProfile.FirstName.Contains(filter!.Player!.Profile.General!.Name!)
                    || player.Player.GeneralProfile.LastName.Contains(filter.Player.Profile.General.Name!)
            },
            new()
            {
                Condition = !string.IsNullOrEmpty(filter?.Player?.Profile?.General?.City),
                Expression = player => player.Player.GeneralProfile.City.Contains(filter!.Player!.Profile.General!.City!)
            },
            new()
            {
                Condition = filter?.Player?.Profile?.General?.Tags?.Any() ?? false,
                Expression = player => player.Player.Tags.Any(tag => filter!.Player!.Profile.General!.Tags.Contains(tag.Value))
            },
            new()
            {
                Condition = filter?.Player?.Profile?.General?.Years.BuildLimitFromCondition(ValidationConstants.RangeLimit) ?? false,
                Expression = player => !player.Player.GeneralProfile.Birthday.HasValue || player.Player.GeneralProfile.Birthday <= now.AddYears(-filter!.Player!.Profile.General!.Years!.From!.Value)
            },
            new()
            {
                Condition = filter?.Player?.Profile?.General?.Years.BuildLimitToCondition(ValidationConstants.RangeLimit) ?? false,
                Expression = player => !player.Player.GeneralProfile.Birthday.HasValue || player.Player.GeneralProfile.Birthday >= now.AddYears(-filter!.Player!.Profile.General!.Years!.To!.Value)
            },
            new()
            {
                Condition = (filter?.Player?.Profile?.General?.Availability?.From.HasValue ?? false)
                    && (filter.Player.Profile.General?.Availability!.To == null || filter.Player.Profile.General.Availability.From <= filter.Player.Profile.General.Availability.To),
                Expression = player => !player.Player.Availability.From.HasValue || player.Player.Availability.From <= filter!.Player!.Profile.General!.Availability.From
            },
            new()
            {
                Condition = (filter?.Player?.Profile?.General?.Availability?.To.HasValue ?? false)
                    && (filter.Player.Profile.General.Availability.From == null || filter.Player.Profile.General.Availability.To >= filter.Player.Profile.General.Availability.From),
                Expression = player => !player.Player.Availability.To.HasValue || player.Player.Availability.To >= filter!.Player!.Profile.General!.Availability.To
            },
            new()
            {
                Condition = filter?.Player?.Profile?.General?.Availability?.Days?.Any() ?? false,
                Expression = player => player.Player.Availability.Days.Count == 0 || player.Player.Availability.Days.Any(day => filter!.Player!.Profile.General!.Availability.Days.Contains(day.Day))
            },
            new()
            {
                Condition = filter?.Player?.Profile?.General?.FreePlay.HasValue ?? false,
                Expression = player => player.Player.GeneralProfile.FreePlay == filter!.Player!.Profile.General!.FreePlay
            },
            new()
            {
                Condition = filter?.Player?.Profile?.General?.HasPhoto.HasValue ?? false,
                Expression = player => (filter!.Player!.Profile.General!.HasPhoto!.Value && player.Player.Photo != null && player.Player.Photo.Size > 0)
                    || (!filter.Player.Profile.General!.HasPhoto!.Value && (player.Player.Photo == null || player.Player.Photo.Size <= 0))
            },
            new()
            {
                Condition = filter?.Player?.Profile?.Football?.Height.BuildLimitFromCondition(PlayerConstants.PlayerSizeRange) ?? false,
                Expression = player => !player.Player.FootballProfile.Height.HasValue || player.Player.FootballProfile.Height >= filter!.Player!.Profile.Football!.Height.From
            },
            new()
            {
                Condition = filter?.Player?.Profile?.Football?.Height.BuildLimitToCondition(PlayerConstants.PlayerSizeRange) ?? false,
                Expression = player => !player.Player.FootballProfile.Height.HasValue || player.Player.FootballProfile.Height <= filter!.Player!.Profile.Football!.Height.To
            },
            new()
            {
                Condition = filter?.Player?.Profile?.Football?.Weight.BuildLimitFromCondition(PlayerConstants.PlayerSizeRange) ?? false,
                Expression = player => !player.Player.FootballProfile.Weight.HasValue || player.Player.FootballProfile.Weight >= filter!.Player!.Profile.Football!.Weight.From
            },
            new()
            {
                Condition = filter?.Player?.Profile?.Football?.Weight.BuildLimitToCondition(PlayerConstants.PlayerSizeRange) ?? false,
                Expression = player => !player.Player.FootballProfile.Weight.HasValue || player.Player.FootballProfile.Weight <= filter!.Player!.Profile.Football!.Weight.To
            },
            new()
            {
                Condition = filter?.Player?.Profile?.Football?.Positions?.Any() ?? false,
                Expression = player => !player.Player.FootballProfile.PositionId.HasValue || filter!.Player!.Profile.Football!.Positions.Contains((int)player.Player.FootballProfile.PositionId.Value)
            },
            new()
            {
                Condition = filter?.Player?.Profile?.Football?.WorkingFoot.HasValue ?? false,
                Expression = player => !player.Player.FootballProfile.WorkingFootId.HasValue || (int?)player.Player.FootballProfile.WorkingFootId == filter!.Player!.Profile.Football!.WorkingFoot
            },
            new()
            {
                Condition = filter?.Player?.Profile?.Football?.GameStyles?.Any() ?? false,
                Expression = player => !player.Player.FootballProfile.GameStyleId.HasValue || filter!.Player!.Profile.Football!.GameStyles.Contains((int)player.Player.FootballProfile.GameStyleId.Value)
            },
            new()
            {
                Condition = filter?.Player?.Profile?.Football?.Skill.HasValue ?? false,
                Expression = player => !player.Player.FootballProfile.Skill.HasValue || player.Player.FootballProfile.Skill >= filter!.Player!.Profile.Football!.Skill
            },
            new()
            {
                Condition = filter?.Player?.Profile?.Football?.PhysicalCondition.HasValue ?? false,
                Expression = player => !player.Player.FootballProfile.PhysicalCondition.HasValue
                    || player.Player.FootballProfile.PhysicalCondition >= filter!.Player!.Profile.Football!.PhysicalCondition
            },
            new()
            {
                Condition = filter?.Player?.Stats?.Total.BuildLimitFromCondition(PlayerConstants.StatValueRange) ?? false,
                Expression = FilterByStat(null, filter?.Player?.Stats?.Total?.From, null)
            },
            new()
            {
                Condition = filter?.Player?.Stats?.Total.BuildLimitToCondition(PlayerConstants.StatValueRange) ?? false,
                Expression = FilterByStat(null, null, filter?.Player?.Stats?.Total?.To)
            },
            new()
            {
                Condition = filter?.Player?.Stats?.Physical.BuildLimitFromCondition(PlayerConstants.StatValueRange) ?? false,
                Expression = FilterByStat(filter?.Player?.Stats?.Physical?.Skill, filter?.Player?.Stats?.Physical?.From, null)
            },
            new()
            {
                Condition = filter?.Player?.Stats?.Physical.BuildLimitToCondition(PlayerConstants.StatValueRange) ?? false,
                Expression = FilterByStat(filter?.Player?.Stats?.Physical?.Skill, null, filter?.Player?.Stats?.Physical?.To)
            },
            new()
            {
                Condition = filter?.Player?.Stats?.Mental.BuildLimitFromCondition(PlayerConstants.StatValueRange) ?? false,
                Expression = FilterByStat(filter?.Player?.Stats?.Mental?.Skill, filter?.Player?.Stats?.Mental?.From, null)
            },
            new()
            {
                Condition = filter?.Player?.Stats?.Mental.BuildLimitToCondition(PlayerConstants.StatValueRange) ?? false,
                Expression = FilterByStat(filter?.Player?.Stats?.Mental?.Skill, null, filter?.Player?.Stats?.Mental?.To)
            },
            new()
            {
                Condition = filter?.Player?.Stats?.Skill.BuildLimitFromCondition(PlayerConstants.StatValueRange) ?? false,
                Expression = FilterByStat(filter?.Player?.Stats?.Skill?.Skill, filter?.Player?.Stats?.Skill?.From, null)
            },
            new()
            {
                Condition = filter?.Player?.Stats?.Skill.BuildLimitToCondition(PlayerConstants.StatValueRange) ?? false,
                Expression = FilterByStat(filter?.Player?.Stats?.Skill?.Skill, null, filter?.Player?.Stats?.Skill?.To)
            },
            new()
            {
                Condition = filter?.Player?.Stats?.Raiting.HasValue ?? false,
                Expression = FilterByRaiting(filter?.Player?.Stats?.Raiting)
            }
        ];
    }

    #region Private

    private static Expression<Func<TeamPlayerRequest, bool>> FilterByStat(int? skill, short? from, short? to)
    {
        if (from.HasValue)
        {
            return player => ((int)Math.Ceiling((double)player.Player.Stats.Where(s => !skill.HasValue || (int?)s.Type.SkillId == skill).Sum(m => m.Value)
                / (player.Player.Stats.Where(s => !skill.HasValue || (int?)s.Type.SkillId == skill).Count() * PlayerConstants.StatMaxValue)
                * ValidationConstants.PercentageMaxValue)) >= from;
        }
        else if (to.HasValue)
        {
            return player => ((int)Math.Ceiling((double)player.Player.Stats.Where(s => !skill.HasValue || (int?)s.Type.SkillId == skill).Sum(m => m.Value)
                / (player.Player.Stats.Where(s => !skill.HasValue || (int?)s.Type.SkillId == skill).Count() * PlayerConstants.StatMaxValue)
                * ValidationConstants.PercentageMaxValue)) <= to;
        }

        return player => true;
    }

    private static Expression<Func<TeamPlayerRequest, bool>> FilterByRaiting(int? raiting)
    {
        return raiting.HasValue
            ? player => ((PlayerConstants.StarsMaxValue * (int)Math.Ceiling((double)player.Player.Stats.Sum(m => m.Value)
                / (player.Player.Stats.Count() * PlayerConstants.StatMaxValue) * ValidationConstants.PercentageMaxValue))
                / ValidationConstants.PercentageMaxValue) >= raiting
            : player => true;
    }

    #endregion Private
}