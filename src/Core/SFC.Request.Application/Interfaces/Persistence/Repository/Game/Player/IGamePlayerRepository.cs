using SFC.Request.Application.Interfaces.Persistence.Context;
using SFC.Request.Application.Interfaces.Persistence.Repository.Common;
using SFC.Request.Domain.Entities.Game.Player;

namespace SFC.Request.Application.Interfaces.Persistence.Repository.Game.Player;
public interface IGamePlayerRepository : IRepository<GamePlayer, IGameDbContext, long>
{
    Task<bool> AnyAsync(long id);

    Task<bool> AnyAsync(long gameId, long playerId);

    Task<bool> AnyAsync(long gameId, long playerId, GamePlayerStatusEnum status);

    Task<GamePlayer?> GetByIdAsync(long gameId, long playerId);

    Task<GamePlayer[]> AddRangeIfNotExistsAsync(params GamePlayer[] entities);
}