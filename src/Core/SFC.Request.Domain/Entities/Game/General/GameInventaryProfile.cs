namespace SFC.Request.Domain.Entities.Game.General;
public class GameInventaryProfile : BaseGameEntity
{
    public bool ShirtsRequired { get; set; }

    public int? ShirtsCount { get; set; }
}