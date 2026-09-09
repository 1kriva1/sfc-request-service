using SFC.Request.Application.Common.Dto.Common;
using SFC.Request.Application.Common.Dto.Player.General;
using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Domain.Entities.Game.Player;

namespace SFC.Request.Application.Common.Dto.Game.Player;
public class GamePlayerDto : AuditableDto, IMapFromReverse<GamePlayer>
{
    public long Id { get; set; }

    public Guid UserId { get; set; }

    public long GameId { get; set; }

    public long PlayerId { get; set; }

    public int StatusId { get; set; }

    public required PlayerDto Player { get; set; }
}