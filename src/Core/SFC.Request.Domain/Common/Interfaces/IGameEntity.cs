namespace SFC.Request.Domain.Common.Interfaces;
public interface IGameEntity
{
    long GameId { get; set; }

    GameEntity Game { get; set; }
}