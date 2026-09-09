namespace SFC.Request.Application.Interfaces.Game.Player;
public interface IGamePlayerSeedService
{
    Task SendRequireGamePlayersSeedAsync(CancellationToken cancellationToken = default);
}