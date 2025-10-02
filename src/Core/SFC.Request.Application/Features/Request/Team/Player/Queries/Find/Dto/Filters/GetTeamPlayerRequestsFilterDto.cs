using SFC.Request.Application.Common.Dto.Player.Filters;

namespace SFC.Request.Application.Features.Request.Team.Player.Queries.Find.Dto.Filters;
public class GetTeamPlayerRequestsFilterDto
{
    public long TeamId { get; set; }

    public GetTeamPlayerRequestsRequestFilterDto? Request { get; set; }

    public PlayerFilterDto? Player { get; set; }
}