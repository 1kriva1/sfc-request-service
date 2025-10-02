using SFC.Request.Application.Common.Dto.Common;
using SFC.Request.Application.Common.Dto.Player.General;
using SFC.Request.Application.Common.Dto.Team.General;
using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Domain.Entities.Request.Team.Player;

namespace SFC.Request.Application.Features.Request.Team.Player.Common.Dto;
public class TeamPlayerRequestDto : AuditableDto, IMapFrom<TeamPlayerRequest>
{
    public long Id { get; set; }

    public Guid UserId { get; set; }

    public int StatusId { get; set; }

    public required TeamDto Team { get; set; }

    public string? TeamComment { get; set; }

    public required string PlayerComment { get; set; }

    public required PlayerDto Player { get; set; }
}