using SFC.Request.Application.Interfaces.Persistence.Context;
using SFC.Request.Application.Interfaces.Persistence.Repository.Common;

namespace SFC.Request.Application.Interfaces.Persistence.Repository.Request;

/// <summary>
/// Repository for core entity of the service.
/// </summary>
public interface IRequestRepository : IRepository<RequestEntity, IRequestDbContext, long>
{
    Task<bool> AnyAsync(long id);

    Task<bool> AnyAsync(long id, Guid userId);

    Task<RequestEntity[]> AddRangeIfNotExistsAsync(params RequestEntity[] entities);
}