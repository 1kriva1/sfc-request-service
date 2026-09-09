using Microsoft.Extensions.DependencyInjection;

using SFC.Request.Application.Interfaces.Cache;
using SFC.Request.Domain.Common;
using SFC.Request.Infrastructure.Persistence.Constants;
using SFC.Request.Infrastructure.Persistence.Contexts;
using SFC.Request.Infrastructure.Persistence.Repositories.Common.Data;

namespace SFC.Request.Infrastructure.Persistence.Repositories.Game.Data.Cache;
public class GameDataCacheRepository<TEntity, TEnum>(GameDataRepository<TEntity, TEnum> repository, [FromKeyedServices(CacheInstance.Game)] ICache cache)
    : DataRelatedCacheRepository<TEntity, GameDbContext, TEnum>(repository, cache)
     where TEntity : EnumDataEntity<TEnum>
     where TEnum : struct
{ }