using SFC.Request.Domain.Entities.Request.Team.Player;

namespace SFC.Request.Application.Interfaces.Request.Team.Player;
public interface ITeamPlayerRequestSeedService
{
    Task<IEnumerable<TeamPlayerRequest>> GetSeedTeamPlayerRequestsAsync();

    Task SeedTeamPlayerRequestsAsync(CancellationToken cancellationToken = default);
}