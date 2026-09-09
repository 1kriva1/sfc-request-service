namespace SFC.Request.Application.Features.Request.Game.Player.Queries.Find.Dto.Filters;
public class GetGamePlayerRequestsRequestFilterDto
{
    public IEnumerable<int> Statuses { get; set; } = [];
}