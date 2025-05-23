using SFC.Request.Domain.Entities.Request.Team.Player;

namespace SFC.Request.Application.Interfaces.Request.Team.Player;
public interface ITeamPlayerRequestService
{
    Task NotifyTeamPlayerRequestCreatedAsync(TeamPlayerRequest request, CancellationToken cancellationToken = default);

    Task NotifyTeamPlayerRequestUpdatedAsync(TeamPlayerRequest request, CancellationToken cancellationToken = default);
}