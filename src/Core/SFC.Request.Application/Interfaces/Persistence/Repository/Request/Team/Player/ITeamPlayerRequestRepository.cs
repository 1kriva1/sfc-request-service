using SFC.Request.Application.Interfaces.Persistence.Context;
using SFC.Request.Application.Interfaces.Persistence.Repository.Common;
using SFC.Request.Domain.Entities.Request.Team.Player;

namespace SFC.Request.Application.Interfaces.Persistence.Repository.Request.Team.Player;

/// <summary>
/// Repository for core entity of the service.
/// </summary>
public interface ITeamPlayerRequestRepository : IRepository<TeamPlayerRequest, IRequestDbContext, long>
{
    Task<bool> AnyAsync(long id);

    Task<bool> AnyAsync(long id, Guid userId);

    Task<bool> AnyAsync(long teamId, long playerId, RequestStatusEnum status);

    Task<TeamPlayerRequest?> GetByIdAsync(long id, long teamId, long playerId);

    Task<IEnumerable<TeamPlayerRequest>> GetByIdsAsync(IEnumerable<long> teamIds, IEnumerable<long> playerIds);

    Task<TeamPlayerRequest[]> AddRangeIfNotExistsAsync(params TeamPlayerRequest[] entities);
}