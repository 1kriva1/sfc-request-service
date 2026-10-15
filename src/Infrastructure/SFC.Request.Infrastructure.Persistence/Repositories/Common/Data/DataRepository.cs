using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

using SFC.Request.Application.Interfaces.Persistence.Context;
using SFC.Request.Application.Interfaces.Persistence.Repository.Common.Data;
using SFC.Request.Domain.Common;

namespace SFC.Request.Infrastructure.Persistence.Repositories.Common.Data;
public class DataRepository<TEntity, TContext, TEnum>(TContext context)
    : Repository<TEntity, TContext, TEnum>(context), IDataRepository<TEntity, TContext, TEnum>
     where TEntity : EnumDataEntity<TEnum>
     where TContext : DbContext, IDbContext
     where TEnum : struct
{
    public virtual Task<bool> AnyAsync(TEnum id)
    {
        return Context.Set<TEntity>().AnyAsync(u => u.Id.Equals(id));
    }

    public Task<TEntity[]> ResetAsync(IEnumerable<TEntity> entities)
    {
        TEntity[] items = [.. entities];

        IExecutionStrategy strategy = Context.Database.CreateExecutionStrategy();

        return strategy.ExecuteAsync(async () =>
        {
            IDbContextTransaction transaction = await Context.Database
                .BeginTransactionAsync()
                .ConfigureAwait(false);

            await using (transaction.ConfigureAwait(false))
            {
                DbSet<TEntity> set = Context.Set<TEntity>();
                Dictionary<TEnum, TEntity> existing = await set.ToDictionaryAsync(e => e.Id).ConfigureAwait(false);

                HashSet<TEnum> incomingIds = [.. items.Select(i => i.Id)];

                // Remove rows that no longer exist in the new data
                set.RemoveRange(existing.Where(e => !incomingIds.Contains(e.Key)).Select(e => e.Value));

                foreach (TEntity item in items)
                {
                    if (existing.TryGetValue(item.Id, out TEntity? current))
                    {
                        Context.Entry(current).CurrentValues.SetValues(item); // update
                    }
                    else
                    {
                        await set.AddAsync(item).ConfigureAwait(false); // insert
                    }
                }

                await Context.SaveChangesAsync().ConfigureAwait(false);
                await transaction.CommitAsync().ConfigureAwait(false);

                return items;
            }
        });
    }
}