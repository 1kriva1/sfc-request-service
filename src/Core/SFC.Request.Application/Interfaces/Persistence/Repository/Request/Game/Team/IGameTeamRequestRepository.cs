using SFC.Request.Application.Interfaces.Persistence.Context;
using SFC.Request.Application.Interfaces.Persistence.Repository.Common;
using SFC.Request.Domain.Entities.Request.Game.Team;

namespace SFC.Request.Application.Interfaces.Persistence.Repository.Request.Game.Team;

/// <summary>
/// Repository for core entity of the service.
/// </summary>
public interface IGameTeamRequestRepository : IRepository<GameTeamRequest, IRequestDbContext, long>
{
    Task<GameTeamRequest?> GetByIdAsync(long id, long gameId, long teamId);

    Task<IEnumerable<GameTeamRequest>> GetByIdsAsync(IEnumerable<long> ids);

    Task<IEnumerable<GameTeamRequest>> GetByIdsAsync(IEnumerable<long> gameIds, IEnumerable<long> teamIds);

    Task<IReadOnlyList<GameTeamRequest>> ListAllAsync(long gameId);

    Task<bool> AnyAsync(long id);

    Task<bool> AnyAsync(long id, Guid userId);

    Task<bool> AnyAsync(long gameId, long teamId, RequestStatusEnum? status);

    Task<GameTeamRequest[]> AddRangeIfNotExistsAsync(params GameTeamRequest[] entities);
}