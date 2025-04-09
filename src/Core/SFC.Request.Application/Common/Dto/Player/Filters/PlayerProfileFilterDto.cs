namespace SFC.Request.Application.Common.Dto.Player.Filters;
public class PlayerProfileFilterDto
{
    public PlayerGeneralProfileFilterDto General { get; set; } = default!;

    public PlayerFootballProfileFilterDto Football { get; set; } = default!;
}