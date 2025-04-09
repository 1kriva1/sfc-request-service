using SFC.Request.Application.Features.Common.Dto.Common;

namespace SFC.Request.Application.Common.Dto.Player.Filters;
public class PlayerStatsBySkillRangeLimitFilterDto : RangeLimitDto<short?>
{
    public int Skill { get; set; }
}