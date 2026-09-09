using SFC.Request.Domain.Entities.Request.Game.Team;

namespace SFC.Request.Application.Interfaces.Request.Game.Team;
public interface IGameTeamRequestService
{
    Task NotifyGameTeamRequestCreatedAsync(GameTeamRequest request, CancellationToken cancellationToken = default);

    Task NotifyGameTeamRequestUpdatedAsync(GameTeamRequest request, CancellationToken cancellationToken = default);
}