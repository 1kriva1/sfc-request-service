namespace SFC.Request.Application.Common.Dto.Team.General.Filters;
public class TeamProfileFilterDto
{
    public TeamGeneralProfileFilterDto? General { get; set; }

    public TeamFinancialProfileFilterDto? Financial { get; set; }

    public TeamInventaryProfileFilterDto? Inventary { get; set; }
}