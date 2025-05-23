namespace SFC.Request.Application.Features.Request.Team.Player.Queries.Find.Dto.Filters;
public class GetTeamPlayerRequestsRequestFilterDto
{
    public IEnumerable<int> Statuses { get; set; } = [];
}