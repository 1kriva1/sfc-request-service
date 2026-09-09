using SFC.Request.Domain.Entities.Request.Game.Player;

namespace SFC.Request.Application.Interfaces.Request.Game.Player;
public interface IGamePlayerRequestService
{
    Task NotifyGamePlayerRequestCreatedAsync(GamePlayerRequest request, CancellationToken cancellationToken = default);

    Task NotifyGamePlayerRequestUpdatedAsync(GamePlayerRequest request, CancellationToken cancellationToken = default);
}