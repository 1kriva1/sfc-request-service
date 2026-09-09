using SFC.Request.Application.Common.Dto.Common;
using SFC.Request.Application.Common.Dto.Game.General;
using SFC.Request.Application.Common.Dto.Team.General;
using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Domain.Entities.Request.Game.Team;

namespace SFC.Request.Application.Features.Request.Game.Team.Common.Dto;

public class GameTeamRequestDto : AuditableDto, IMapFrom<GameTeamRequest>
{
    public long Id { get; set; }

    public Guid UserId { get; set; }

    public int StatusId { get; set; }

    public string? GameComment { get; set; }

    public required GameDto Game { get; set; }

    public required string TeamComment { get; set; }

    public required TeamDto Team { get; set; }
}