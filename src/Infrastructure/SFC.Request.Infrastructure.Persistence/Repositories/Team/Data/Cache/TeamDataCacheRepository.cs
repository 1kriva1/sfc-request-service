using SFC.Request.Application.Interfaces.Cache;
using SFC.Request.Domain.Common;
using SFC.Request.Infrastructure.Persistence.Contexts;
using SFC.Request.Infrastructure.Persistence.Repositories.Common.Data;

namespace SFC.Request.Infrastructure.Persistence.Repositories.Team.Data.Cache;
public class TeamDataCacheRepository<TEntity, TEnum>(TeamDataRepository<TEntity, TEnum> repository, ICache cache)
    : DataCacheRepository<TEntity, TeamDbContext, TEnum>(repository, cache)
     where TEntity : EnumDataEntity<TEnum>
     where TEnum : struct
{ }