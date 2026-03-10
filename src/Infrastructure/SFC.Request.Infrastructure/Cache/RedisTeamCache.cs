using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using SFC.Request.Application.Common.Settings;
using SFC.Request.Infrastructure.Persistence.Constants;

namespace SFC.Request.Infrastructure.Cache;

public class RedisTeamCache([FromKeyedServices(CacheInstance.Team)] IDistributedCache cache, IOptions<CacheSettings> cacheConfig)
    : RedisCache(cache, cacheConfig)
{ }