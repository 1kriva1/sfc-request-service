using SFC.Request.Application.Interfaces.Persistence.Context;
using SFC.Request.Application.Interfaces.Persistence.Repository.Common;
using SFC.Request.Domain.Entities.Request.Game.Player;

namespace SFC.Request.Application.Interfaces.Persistence.Repository.Request.Game.Player;

/// <summary>
/// Repository for core entity of the service.
/// </summary>
public interface IGamePlayerRequestRepository : IRepository<GamePlayerRequest, IRequestDbContext, long>
{
    Task<GamePlayerRequest?> GetByIdAsync(long id, long gameId, long playerId);

    Task<IEnumerable<GamePlayerRequest>> GetByIdsAsync(IEnumerable<long> ids);

    Task<IEnumerable<GamePlayerRequest>> GetByIdsAsync(IEnumerable<long> gameIds, IEnumerable<long> playerIds);

    Task<IReadOnlyList<GamePlayerRequest>> ListAllAsync(long gameId);

    Task<bool> AnyAsync(long id);

    Task<bool> AnyAsync(long id, Guid userId);

    Task<bool> AnyAsync(long gameId, long playerId, RequestStatusEnum? status);

    Task<GamePlayerRequest[]> AddRangeIfNotExistsAsync(params GamePlayerRequest[] entities);
}