using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Domain.Entities.Team.General;

namespace SFC.Request.Application.Common.Dto.Team.General;
public class TeamInventaryProfileDto : IMapToReverse<TeamInventaryProfile>
{
    public IEnumerable<int> Shirts { get; set; } = [];

    public bool HasManiches { get; set; }
}