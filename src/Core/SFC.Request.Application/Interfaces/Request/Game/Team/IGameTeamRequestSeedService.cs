using SFC.Request.Domain.Entities.Request.Game.Team;

namespace SFC.Request.Application.Interfaces.Request.Game.Team;
public interface IGameTeamRequestSeedService
{
    Task<IEnumerable<GameTeamRequest>> GetSeedGameTeamRequestsAsync();

    Task SeedGameTeamRequestsAsync(CancellationToken cancellationToken = default);
}