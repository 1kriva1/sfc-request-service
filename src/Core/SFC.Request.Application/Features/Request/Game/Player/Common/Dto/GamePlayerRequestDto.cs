using SFC.Request.Application.Common.Dto.Common;
using SFC.Request.Application.Common.Dto.Game.General;
using SFC.Request.Application.Common.Dto.Player.General;
using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Domain.Entities.Request.Game.Player;

namespace SFC.Request.Application.Features.Request.Game.Player.Common.Dto;
public class GamePlayerRequestDto : AuditableDto, IMapFrom<GamePlayerRequest>
{
    public long Id { get; set; }

    public Guid UserId { get; set; }

    public int StatusId { get; set; }

    public string? GameComment { get; set; }

    public required GameDto Game { get; set; }

    public required string PlayerComment { get; set; }

    public required PlayerDto Player { get; set; }
}