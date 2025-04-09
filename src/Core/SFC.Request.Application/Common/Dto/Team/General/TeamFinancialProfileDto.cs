using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Domain.Entities.Team.General;

namespace SFC.Request.Application.Common.Dto.Team.General;
public class TeamFinancialProfileDto : IMapFromReverse<TeamFinancialProfile>
{
    public bool FreePlay { get; set; }
}