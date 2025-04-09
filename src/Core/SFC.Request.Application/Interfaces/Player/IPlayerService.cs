using SFC.Request.Application.Common.Dto.Player.General;

namespace SFC.Request.Application.Interfaces.Player;
public interface IPlayerService
{
    Task<PlayerDto?> GetPlayerAsync(long id, CancellationToken cancellationToken = default);
}