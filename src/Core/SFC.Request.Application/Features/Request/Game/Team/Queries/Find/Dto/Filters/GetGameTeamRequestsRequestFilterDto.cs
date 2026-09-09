namespace SFC.Request.Application.Features.Request.Game.Team.Queries.Find.Dto.Filters;
public class GetGameTeamRequestsRequestFilterDto
{
    public IEnumerable<int> Statuses { get; set; } = [];
}