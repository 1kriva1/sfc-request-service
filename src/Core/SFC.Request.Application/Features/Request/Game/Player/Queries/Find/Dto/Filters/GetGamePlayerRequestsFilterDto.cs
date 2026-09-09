using SFC.Request.Application.Common.Dto.Player.General.Filters;

namespace SFC.Request.Application.Features.Request.Game.Player.Queries.Find.Dto.Filters;
public class GetGamePlayerRequestsFilterDto
{
    public long GameId { get; set; }

    public GetGamePlayerRequestsRequestFilterDto? Request { get; set; }

    public PlayerFilterDto? Player { get; set; }
}