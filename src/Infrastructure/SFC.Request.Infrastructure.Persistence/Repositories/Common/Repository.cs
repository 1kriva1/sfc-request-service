using Microsoft.EntityFrameworkCore;

using SFC.Request.Application.Features.Common.Models.Find;
using SFC.Request.Application.Features.Common.Models.Find.Paging;
using SFC.Request.Application.Interfaces.Persistence.Context;
using SFC.Request.Application.Interfaces.Persistence.Repository.Common;
using SFC.Request.Infrastructure.Persistence.Extensions;

namespace SFC.Request.Infrastructure.Persistence.Repositories.Common;
public class Repository<T, TR, TID>(TR context) : IRepository<T, TR, TID>
    where T : class
    where TR : DbContext, IDbContext
{
    protected TR Context { get; } = context;

    public virtual async Task<T?> GetByIdAsync(TID id)
    {
        T? t = await Context.Set<T>().FindAsync(id)
                                      .ConfigureAwait(false);
        return t;
    }

    public virtual async Task<PagedList<T>> FindAsync(FindParameters<T> parameters)
    {
        return await Context.Set<T>()
                             .AsQueryable<T>()
                             .PaginateAsync(parameters)
                             .ConfigureAwait(false);
    }

    public virtual async Task<IReadOnlyList<T>> ListAllAsync()
    {
        return await Context.Set<T>()
                             .ToListAsync()
                             .ConfigureAwait(false);
    }

    public virtual async Task<T> AddAsync(T entity)
    {
        await Context.Set<T>()
                     .AddAsync(entity)
                     .ConfigureAwait(false);

        await Context.SaveChangesAsync()
                     .ConfigureAwait(false);

        return entity;
    }

    public virtual async Task<T[]> AddRangeAsync(params T[] entities)
    {
        await Context.Set<T>()
                     .AddRangeAsync(entities)
                     .ConfigureAwait(false);

        await Context.SaveChangesAsync()
                      .ConfigureAwait(false);

        return entities;
    }

    public virtual async Task UpdateAsync(T entity)
    {
        Context.Entry(entity).State = EntityState.Modified;

        await Context.SaveChangesAsync()
                     .ConfigureAwait(false);
    }

    public async Task DeleteAsync(T entity)
    {
        Context.Set<T>().Remove(entity);

        await Context.SaveChangesAsync()
                      .ConfigureAwait(false);
    }
}