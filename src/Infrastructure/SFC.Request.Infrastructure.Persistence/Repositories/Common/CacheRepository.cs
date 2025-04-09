using Microsoft.EntityFrameworkCore;

using SFC.Request.Application.Features.Common.Models.Find;
using SFC.Request.Application.Features.Common.Models.Find.Paging;
using SFC.Request.Application.Interfaces.Cache;
using SFC.Request.Application.Interfaces.Persistence.Context;
using SFC.Request.Application.Interfaces.Persistence.Repository.Common;

namespace SFC.Request.Infrastructure.Persistence.Repositories.Common;
public class CacheRepository<T, TR, TID>(Repository<T, TR, TID> repository, ICache cache)
    : IRepository<T, TR, TID>
    where T : class
    where TR : DbContext, IDbContext
{
    private readonly Repository<T, TR, TID> _repository = repository;

    protected ICache Cache { get; } = cache;

    protected virtual string CacheKey { get => $"{typeof(T).Name}"; }

    public virtual async Task<IReadOnlyList<T>> ListAllAsync()
    {
        if (!Cache.TryGet(CacheKey, out IReadOnlyList<T> list))
        {
            list = await _repository.ListAllAsync()
                                    .ConfigureAwait(false);

            await Cache.SetAsync(CacheKey, list)
                        .ConfigureAwait(false);
        }

        return list;
    }

    public Task<T?> GetByIdAsync(TID id) => _repository.GetByIdAsync(id);

    public Task<T> AddAsync(T entity) => _repository.AddAsync(entity);

    public Task DeleteAsync(T entity) => _repository.DeleteAsync(entity);

    public Task UpdateAsync(T entity) => _repository.UpdateAsync(entity);

    public Task<PagedList<T>> FindAsync(FindParameters<T> parameters) => _repository.FindAsync(parameters);

    public Task<T[]> AddRangeAsync(params T[] entities) => _repository.AddRangeAsync(entities);
}