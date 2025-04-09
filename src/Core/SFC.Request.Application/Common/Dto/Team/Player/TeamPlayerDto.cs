using SFC.Request.Application.Common.Dto.Common;
using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Domain.Entities.Team.Player;

namespace SFC.Request.Application.Common.Dto.Team.Player;
public class TeamPlayerDto : AuditableDto, IMapFromReverse<TeamPlayer>
{
    public long Id { get; set; }

    public long TeamId { get; set; }

    public long PlayerId { get; set; }

    public int StatusId { get; set; }

    public Guid UserId { get; set; }
}