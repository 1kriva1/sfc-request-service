using Microsoft.Extensions.DependencyInjection;

using SFC.Request.Application.Interfaces.Cache;
using SFC.Request.Domain.Common;
using SFC.Request.Infrastructure.Persistence.Constants;
using SFC.Request.Infrastructure.Persistence.Contexts;
using SFC.Request.Infrastructure.Persistence.Repositories.Common.Data;

namespace SFC.Request.Infrastructure.Persistence.Repositories.Team.Data.Cache;
public class TeamDataCacheRepository<TEntity, TEnum>(TeamDataRepository<TEntity, TEnum> repository, [FromKeyedServices(CacheInstance.Team)] ICache cache)
    : DataRelatedCacheRepository<TEntity, TeamDbContext, TEnum>(repository, cache)
     where TEntity : EnumDataEntity<TEnum>
     where TEnum : struct
{ }