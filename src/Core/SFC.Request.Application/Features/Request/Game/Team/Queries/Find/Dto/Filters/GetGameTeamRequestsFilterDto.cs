using SFC.Request.Application.Common.Dto.Team.General.Filters;

namespace SFC.Request.Application.Features.Request.Game.Team.Queries.Find.Dto.Filters;
public class GetGameTeamRequestsFilterDto
{
    public long GameId { get; set; }

    public GetGameTeamRequestsRequestFilterDto? Request { get; set; }

    public TeamFilterDto? Team { get; set; }
}