using SFC.Request.Application.Interfaces.Persistence.Context;
using SFC.Request.Application.Interfaces.Persistence.Repository.Common;

namespace SFC.Request.Application.Interfaces.Persistence.Repository.Player;
public interface IPlayerRepository : IRepository<PlayerEntity, IPlayerDbContext, long>
{
    Task<bool> AnyAsync(long id);

    Task<bool> AnyAsync(long id, Guid userId);

    Task<PlayerEntity[]> AddRangeIfNotExistsAsync(params PlayerEntity[] entities);
}