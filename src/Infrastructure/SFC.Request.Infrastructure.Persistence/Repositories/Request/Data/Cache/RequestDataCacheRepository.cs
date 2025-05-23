using SFC.Request.Application.Interfaces.Cache;
using SFC.Request.Domain.Common;
using SFC.Request.Infrastructure.Persistence.Contexts;
using SFC.Request.Infrastructure.Persistence.Repositories.Common.Data;

namespace SFC.Request.Infrastructure.Persistence.Repositories.Request.Data.Cache;
public class RequestDataCacheRepository<TEntity, TEnum>(RequestDataRepository<TEntity, TEnum> repository, ICache cache)
    : DataCacheRepository<TEntity, RequestDbContext, TEnum>(repository, cache)
     where TEntity : EnumDataEntity<TEnum>
     where TEnum : struct
{ }