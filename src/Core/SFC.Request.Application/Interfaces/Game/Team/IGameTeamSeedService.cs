namespace SFC.Request.Application.Interfaces.Game.Team;
public interface IGameTeamSeedService
{
    Task SendRequireGameTeamsSeedAsync(CancellationToken cancellationToken = default);
}