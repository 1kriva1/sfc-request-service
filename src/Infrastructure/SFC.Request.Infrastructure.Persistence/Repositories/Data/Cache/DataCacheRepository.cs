using Microsoft.Extensions.DependencyInjection;

using SFC.Request.Application.Interfaces.Cache;
using SFC.Request.Domain.Common;
using SFC.Request.Infrastructure.Persistence.Constants;
using SFC.Request.Infrastructure.Persistence.Contexts;
using SFC.Request.Infrastructure.Persistence.Repositories.Common.Data;

namespace SFC.Request.Infrastructure.Persistence.Repositories.Data.Cache;
public class DataCacheRepository<TEntity, TEnum>(DataRepository<TEntity, TEnum> repository, [FromKeyedServices(CacheInstance.Data)] ICache cache)
    : DataRelatedCacheRepository<TEntity, DataDbContext, TEnum>(repository, cache)
     where TEntity : EnumDataEntity<TEnum>
     where TEnum : struct
{ }