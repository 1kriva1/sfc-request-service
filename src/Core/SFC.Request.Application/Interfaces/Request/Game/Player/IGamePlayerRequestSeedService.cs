using SFC.Request.Domain.Entities.Request.Game.Player;

namespace SFC.Request.Application.Interfaces.Request.Game.Player;
public interface IGamePlayerRequestSeedService
{
    Task<IEnumerable<GamePlayerRequest>> GetSeedGamePlayerRequestsAsync();

    Task SeedGamePlayerRequestsAsync(CancellationToken cancellationToken = default);
}