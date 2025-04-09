using Microsoft.EntityFrameworkCore;

using SFC.Request.Application.Interfaces.Persistence.Context;
using SFC.Request.Application.Interfaces.Persistence.Repository.Common.Data;
using SFC.Request.Domain.Common;
using SFC.Request.Infrastructure.Persistence.Extensions;

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
        Context.Clear<TEntity>();

        return AddRangeAsync(entities.ToArray());
    }
}