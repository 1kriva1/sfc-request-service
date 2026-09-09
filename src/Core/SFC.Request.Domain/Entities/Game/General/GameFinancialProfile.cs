namespace SFC.Request.Domain.Entities.Game.General;
public class GameFinancialProfile : BaseGameEntity
{
    public bool FreeGame { get; set; }

    public decimal? PayAmount { get; set; }
}