using Microsoft.EntityFrameworkCore;

using SFC.Request.Application.Interfaces.Persistence.Repository.Request;
using SFC.Request.Infrastructure.Persistence.Contexts;
using SFC.Request.Infrastructure.Persistence.Extensions;
using SFC.Request.Infrastructure.Persistence.Repositories.Common;

namespace SFC.Request.Infrastructure.Persistence.Repositories.Request;
public class RequestRepository(RequestDbContext context)
    : Repository<RequestEntity, RequestDbContext, long>(context), IRequestRepository
{
    #region Public

    public Task<bool> AnyAsync(long id)
    {
        return Context.Requests.AnyAsync(u => u.Id == id);
    }

    public Task<bool> AnyAsync(long id, Guid userId)
    {
        return Context.Requests.AnyAsync(u => u.Id == id && u.UserId == userId);
    }

    public async Task<RequestEntity[]> AddRangeIfNotExistsAsync(params RequestEntity[] entities)
    {
        await Context.Set<RequestEntity>().AddRangeIfNotExistsAsync<RequestEntity, long>(entities).ConfigureAwait(true);

        await Context.SaveChangesAsync().ConfigureAwait(true);

        return entities;
    }

    #endregion Public

    #region Ovveride

    #endregion Ovveride
}