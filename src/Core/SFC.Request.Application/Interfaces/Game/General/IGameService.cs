using SFC.Request.Application.Common.Dto.Game.General;

namespace SFC.Request.Application.Interfaces.Game.General;
public interface IGameService
{
    Task<GameDto?> GetGameAsync(long id, CancellationToken cancellationToken = default);
}